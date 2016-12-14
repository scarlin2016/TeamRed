
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using System.Text;
using System.Collections;

public class HighScoreEntry
{
  public string name;
  public int score;

  public HighScoreEntry( string name, int score )
  {
    this.name = name;
    this.score = score;
  }
}


public class HighScoreTable
{
  private ArrayList table;

  private bool isLoaded;

  public HighScoreTable()
  {
    table = new ArrayList();
    isLoaded = false;
  }

  public void Load( string path )
  {
    if( File.Exists( path ) )
    {
      table = new ArrayList();

      using( StreamReader textStream = new StreamReader(path, Encoding.UTF8) )
      {
        string scoreLine;

        while( (scoreLine = textStream.ReadLine()) != null )
        {
          string[] scoreParts = scoreLine.Split(',');

          if( scoreParts.Length != 2 )
          {
	throw new ApplicationException("Score file corrupt!");
          }
          else
          {
	table.Add(new HighScoreEntry(scoreParts[0],Int32.Parse(scoreParts[1])));
          }
        }
        textStream.Close();
      }
    }
    else
    {
      for( int index = 0; index < 10; index++ )
      {
        table.Add( new HighScoreEntry("Nobody",0));
      }
      Save( path );
    }		
    isLoaded = true;
  }

  public void Save( string path )
  {
    if( File.Exists( path ) )
    {
      File.Delete( path );
    }

    using( StreamWriter textStream = new StreamWriter(path,false, Encoding.UTF8) )
    {
      foreach( object tableEntry in table )
      {	
        HighScoreEntry highScoreEntry = tableEntry as HighScoreEntry;

        textStream.WriteLine("{0},{1}",highScoreEntry.name,highScoreEntry.score );
      }
      textStream.Close();
    }
  }

  public int GetIndexOfScore( int score )
  {
    for( int index = 0; index < table.Count; index++ )
    {
      HighScoreEntry highScoreEntry = table[index] as HighScoreEntry;

      if( score > highScoreEntry.score && index < 10)
      {
        return index;
      }
    }
    return -1;
  }

  public void Update( string name, int score )
  {
    if( !isLoaded ) Load( Application.StartupPath+@"\score.txt" );

    int index = GetIndexOfScore( score );

    if( index > -1 )
    {
      if( table.Count > 9 ) table.RemoveAt( 9 );
      table.Insert( index, new HighScoreEntry( name, score ) );
      Save( Application.StartupPath+@"\score.txt" );
    }
  }

  public void Populate( ListView listView )
  {
    listView.Items.Clear();

    foreach( object entry in table )
    {
      HighScoreEntry highScoreEntry = entry as HighScoreEntry;
      listView.Items.Add( new ListViewItem( new string[] { highScoreEntry.name, highScoreEntry.score.ToString() } ));
    }
  }
}


public class HighScore : Form
{
  private ListView listView1;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader2;
  private HighScoreTable highScoreTable = null;

  private System.ComponentModel.Container components = null;

  public HighScore( HighScoreTable highScoreTableReference )
  {
    InitializeComponent();
    highScoreTable = highScoreTableReference;
  }

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  protected override void Dispose( bool disposing )
  {
    if( disposing )
    {
      if (components != null) 
      {
        components.Dispose();
      }
    }
    base.Dispose( disposing );
  }

  private void InitializeComponent()
  {
    this.listView1 = new ListView();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();

    // 
    // listView1
    // 
    listView1.Columns.AddRange(new ColumnHeader[] {
				    columnHeader1,
				    columnHeader2});
    listView1.GridLines = true;
    listView1.Location = new Point(16, 16);
    listView1.Name = "listView1";
    listView1.Scrollable = false;
    listView1.Size = new Size(210, 162);
    listView1.TabIndex = 0;
    listView1.View = View.Details;

    // 
    // columnHeader1
    // 
    columnHeader1.Text = "Name";
    columnHeader1.Width = 150;

    // 
    // columnHeader2
    // 
    columnHeader2.Text = "Score";

    // 
    // HighScore
    // 
    this.ClientSize = new Size(242, 192);
    this.Controls.Add( listView1 );
    this.Text = "High Scores";

    // Now Load Scores
    this.Load += new System.EventHandler( HighScoreForm_Load );

    this.ResumeLayout(false);
  }

  private void HighScoreForm_Load( object sender, System.EventArgs e )
  {
    highScoreTable.Load( Application.StartupPath+@"\score.txt" );
    highScoreTable.Populate( listView1 );
  }
}
    