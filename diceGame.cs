using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// Summary description for dieroller.
/// </summary>
class YahtzeeForm : Form
{
  // Visual Components
  private Dice[] TheDice = new Dice[5]{ null, null, null, null, null };

  private Button RollButton;
  private Button HoldButton0;
  private Button HoldButton1;
  private Button HoldButton2;
  private Button HoldButton3;
  private Button HoldButton4;


  
  private Button Turn1Button;
  private Button Turn2Button;
  private Button Turn3Button;
  private Button Turn4Button;



  
  private Label Turn1Score;
  private Label Turn2Score;
  private Label Turn3Score;
  private Label Turn4Score;

  private Label TotalScore;


  private Label TotalLabel;

  private MainMenu mainMenu;

  private int RollCount = 0;
  private int ScoreCount = 0;

  private CalculateScore TheScore = new CalculateScore();

  private HighScoreTable highScoreTable = new HighScoreTable();

  /// <summary> 
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.Container components = null;

  public YahtzeeForm()
  {
    InitializeComponent();

    // Add File Menu
    MenuItem File = mainMenu.MenuItems.Add("&File");
    File.MenuItems.Add( new MenuItem( "&High Scores",
	            new EventHandler( this.FileScore_Clicked ),
	            Shortcut.CtrlH ));
    File.MenuItems.Add("-"); // Gives us a seperator
    File.MenuItems.Add( new MenuItem( "E&xit", 
	            new EventHandler( this.FileExit_Clicked ),
	            Shortcut.CtrlX ));


    // Load high score table...
    highScoreTable.Load( Application.StartupPath+@"\score.txt" );
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

  void InitializeComponent()
  {
    Random RandomScore = new Random();

    TheDice[0] = new Dice( RandomScore.Next() );
    TheDice[1] = new Dice( RandomScore.Next() );
    TheDice[2] = new Dice( RandomScore.Next() );
    TheDice[3] = new Dice( RandomScore.Next() );
    TheDice[4] = new Dice( RandomScore.Next() );

    SuspendLayout();

    //
    // myDice1
    //
    TheDice[0].Location = new Point( 90, 10 );
    TheDice[0].TabIndex = 0;

    //
    // myDice2
    //
    TheDice[1].Location = new Point( 140, 10 );
    TheDice[1].TabIndex = 0;

    //
    // myDice3
    //
    TheDice[2].Location = new Point( 190, 10 );
    TheDice[2].TabIndex = 0;

    //
    // myDice4
    //
    TheDice[3].Location = new Point( 240, 10 );
    TheDice[3].TabIndex = 0;

    //
    // myDice5
    //
    TheDice[4].Location = new Point( 290, 10 );
    TheDice[4].TabIndex = 0;

    //
    // RollButton
    //
    RollButton = new Button();
    RollButton.Text = "Roll Dice";
    RollButton.Location = new Point( 10, 30 );
    RollButton.Size = new Size( 70, 20 );
    RollButton.Click += new EventHandler(RollButton_Clicked);
    RollButton.TabIndex = 0;
    RollButton.BackColor = Color.LightGray;

    //
    // HoldButton0
    //
    HoldButton0 = new Button();
    HoldButton0.Text = "Hold";
    HoldButton0.Location = new Point( 90, 65 );
    HoldButton0.Size = new Size( 50, 20 );
    HoldButton0.Click += new EventHandler(HoldButton0_Clicked);
    HoldButton0.TabIndex = 0;
    HoldButton0.BackColor = Color.LightGray;

    //
    // HoldButton1
    //
    HoldButton1 = new Button();
    HoldButton1.Text = "Hold";
    HoldButton1.Location = new Point( 140, 65 );
    HoldButton1.Size = new Size( 50, 20 );
    HoldButton1.Click += new EventHandler(HoldButton1_Clicked);
    HoldButton1.TabIndex = 0;
    HoldButton1.BackColor = Color.LightGray;

    //
    // HoldButton2
    //
    HoldButton2 = new Button();
    HoldButton2.Text = "Hold";
    HoldButton2.Location = new Point( 190, 65 );
    HoldButton2.Size = new Size( 50, 20 );
    HoldButton2.Click += new EventHandler(HoldButton2_Clicked);
    HoldButton2.TabIndex = 0;
    HoldButton2.BackColor = Color.LightGray;
    //
    // HoldButton3
    //
    HoldButton3 = new Button();
    HoldButton3.Text = "Hold";
    HoldButton3.Location = new Point( 240, 65 );
    HoldButton3.Size = new Size( 50, 20 );
    HoldButton3.Click += new EventHandler(HoldButton3_Clicked);
    HoldButton3.TabIndex = 0;
    HoldButton3.BackColor = Color.LightGray;

    //
    // HoldButton4
    //
    HoldButton4 = new Button();
    HoldButton4.Text = "Hold";
    HoldButton4.Location = new Point( 290, 65 );
    HoldButton4.Size = new Size( 50, 20 );
    HoldButton4.Click += new EventHandler(HoldButton4_Clicked);
    HoldButton4.TabIndex = 0;
    HoldButton4.BackColor = Color.LightGray;
	//
    // Turn1Button
    //
    Turn1Button = new Button();
    Turn1Button.Text = "Turn 1 (Total Dice)";
    Turn1Button.Location = new Point( 50, 260 );
    Turn1Button.Size = new Size( 160, 20 );
    Turn1Button.Click += new EventHandler(Turn1Button_Clicked);
    Turn1Button.TabIndex = 0;
    Turn1Button.BackColor = Color.LightGray;

    //
    // Turn1Score
    //
    Turn1Score = new Label();
    Turn1Score.Location = new Point( 220, 260 );
    Turn1Score.TabIndex = 0;
    Turn1Score.Text = "";
    Turn1Score.Size = new Size( 70, 20 );
    Turn1Score.TextAlign = ContentAlignment.MiddleCenter;
    Turn1Score.BackColor = Color.White;
    Turn1Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

    //
    // Turn2Button
    //
    Turn2Button = new Button();
    Turn2Button.Text = "Turn 2 (Total Dice)";
    Turn2Button.Location = new Point( 50, 280 );
    Turn2Button.Size = new Size( 160, 20 );
    Turn2Button.Click += new EventHandler(Turn2Button_Clicked);
    Turn2Button.TabIndex = 0;
    Turn2Button.BackColor = Color.LightGray;

    //
    // Turn2Score
    //
    Turn2Score = new Label();
    Turn2Score.Location = new Point( 220, 280 );
    Turn2Score.TabIndex = 0;
    Turn2Score.Text = "";
    Turn2Score.Size = new Size( 70, 20 );
    Turn2Score.TextAlign = ContentAlignment.MiddleCenter;
    Turn2Score.BackColor = Color.White;
    Turn2Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

    //
    // Turn3Button
    //
    Turn3Button = new Button();
    Turn3Button.Text = "Turn 3 (Total Dice)";
    Turn3Button.Location = new Point( 50, 300 );
    Turn3Button.Size = new Size( 160, 20 );
    Turn3Button.Click += new EventHandler(Turn3Button_Clicked);
    Turn3Button.TabIndex = 0;
    Turn3Button.BackColor = Color.LightGray;

    //
    // Turn3Score
    //
    Turn3Score = new Label();
    Turn3Score.Location = new Point( 220, 300 );
    Turn3Score.TabIndex = 0;
    Turn3Score.Text = "";
    Turn3Score.Size = new Size( 70, 20 );
    Turn3Score.TextAlign = ContentAlignment.MiddleCenter;
    Turn3Score.BackColor = Color.White;
    Turn3Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

    //
    // Turn4Button
    //
    Turn4Button = new Button();
    Turn4Button.Text = "Turn 4 (Total Dice)";
    Turn4Button.Location = new Point( 50, 320 );
    Turn4Button.Size = new Size( 160, 20 );
    Turn4Button.Click += new EventHandler(Turn4Button_Clicked);
    Turn4Button.TabIndex = 0;
    Turn4Button.BackColor = Color.LightGray;

    //
    // Turn4Score
    //
    Turn4Score = new Label();
    Turn4Score.Location = new Point( 220, 320 );
    Turn4Score.TabIndex = 0;
    Turn4Score.Text = "";
    Turn4Score.Size = new Size( 70, 20 );
    Turn4Score.TextAlign = ContentAlignment.MiddleCenter;
    Turn4Score.BackColor = Color.White;
    Turn4Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;


    //
    // TotalLabel
    //
    TotalLabel = new Label();
    TotalLabel.Location = new Point( 50, 460 );
    TotalLabel.Name = "TotalLabel";
    TotalLabel.Size = new Size( 160, 20 );
    TotalLabel.Text = "Total :";
    TotalLabel.TextAlign = ContentAlignment.MiddleRight;
    TotalLabel.Font = new Font(TotalLabel.Font, FontStyle.Bold);

    //
    // TotalScore
    //
    TotalScore = new Label();
    TotalScore.Location = new Point( 220, 460 );
    TotalScore.TabIndex = 0;
    TotalScore.Text = TheScore.TotalScore.ToString();
    TotalScore.Size = new Size( 70, 20 );
    TotalScore.TextAlign = ContentAlignment.MiddleCenter;
    TotalScore.BackColor = Color.White;
    TotalScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;  

    this.Controls.AddRange(new System.Windows.Forms.Control[] { TheDice[0],
                                                                TheDice[1],
                                                                TheDice[2],
                                                                TheDice[3],
                                                                TheDice[4],
                                                                RollButton,
                                                                HoldButton0,
                                                                HoldButton1,
                                                                HoldButton2,
                                                                HoldButton3,
                                                                HoldButton4,
                                                                Turn1Button,
                                                                Turn1Score,
																Turn2Button,
																Turn2Score,
																Turn3Button,
																Turn3Score,
																Turn4Button,
																Turn4Score,
                                                                TotalLabel,
                                                                TotalScore });

    // Add main menu component
    mainMenu = new MainMenu();

    this.ClientSize = new Size( 350, 500 );
    this.Name = "DiceGame";
    this.Text = "DiceGame";
    this.BackColor = Color.Green;
    this.ResumeLayout(false);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.Menu = mainMenu;
  }

  private void RollButton_Clicked( object ob, EventArgs e )
  {
    if( RollCount < 3 )
    {
      if( RollCount == 0 )
      {
        TheDice[0].HoldState = false;
        TheDice[1].HoldState = false;
        TheDice[2].HoldState = false;
        TheDice[3].HoldState = false;
        TheDice[4].HoldState = false;

        HoldButton0.Text = "Hold";
        HoldButton1.Text = "Hold";
        HoldButton2.Text = "Hold";
        HoldButton3.Text = "Hold";
        HoldButton4.Text = "Hold";
      }

      TheDice[0].Roll();
      TheDice[1].Roll();
      TheDice[2].Roll();
      TheDice[3].Roll();
      TheDice[4].Roll();

      RollCount++;

      if( RollCount == 3 )
      {
        TheDice[0].HoldState = true;
        TheDice[1].HoldState = true;
        TheDice[2].HoldState = true;
        TheDice[3].HoldState = true;
        TheDice[4].HoldState = true;
      }
    }
  }

  private void HoldButton0_Clicked( object ob, EventArgs e )
  {
    if( RollCount != 0 )
    {
      if( TheDice[0].HoldState == true )
      {
        TheDice[0].HoldState = false;
        HoldButton0.Text = "Hold";
      }
      else
      {
        TheDice[0].HoldState = true;
        HoldButton0.Text = "Free";
      }
    }
  }

  private void HoldButton1_Clicked( object ob, EventArgs e )
  {
    if( RollCount != 0 )
    {
      if( TheDice[1].HoldState == true )
      {
        TheDice[1].HoldState = false;
        HoldButton1.Text = "Hold";
      }
      else
      {
        TheDice[1].HoldState = true;
        HoldButton1.Text = "Free";
      }
    }
  }

  private void HoldButton2_Clicked( object ob, EventArgs e )
  {
    if( RollCount != 0 )
    {
      if( TheDice[2].HoldState == true )
      {
        TheDice[2].HoldState = false;
        HoldButton2.Text = "Hold";
      }
      else
      {
        TheDice[2].HoldState = true;
        HoldButton2.Text = "Free";
      }
    }
  }

  private void HoldButton3_Clicked( object ob, EventArgs e )
  {
    if( RollCount != 0 )
    {
      if( TheDice[3].HoldState == true )
      {
        TheDice[3].HoldState = false;
        HoldButton3.Text = "Hold";
      }
      else
      {
        TheDice[3].HoldState = true;
        HoldButton3.Text = "Free";
      }
    }
  }

  private void HoldButton4_Clicked( object ob, EventArgs e )
  {
    if( RollCount != 0 )
    {
      if( TheDice[4].HoldState == true )
      {
        TheDice[4].HoldState = false;
        HoldButton4.Text = "Hold";
      }
      else
      {
        TheDice[4].HoldState = true;
        HoldButton4.Text = "Free";
      }
    }
  }


  private void Turn1Button_Clicked( object ob, EventArgs e ) 
  {
    if( (RollCount > 0) && (Turn1Score.Text == "") )
    {
      int Score = TheScore.AddUpChance(TheDice);

      string message = "The Total is " + Score.ToString() + ". Do you wish to accept this?";
      DialogResult result;

      // Displays the MessageBox.
      result = MessageBox.Show( message, 
	                    "Turn 1 Total", 
	                    MessageBoxButtons.YesNo, 
	                    MessageBoxIcon.Question );

      if(result == DialogResult.Yes)
      {
        Turn1Score.Text = Score.ToString();
        TheScore.UpdateTotals( Score );
        Reset();
      }
    }
  }
  
  private void Turn2Button_Clicked( object ob, EventArgs e )
{
	if( (RollCount > 0) && (Turn2Score.Text == "") )
	{
		int Score = TheScore.AddUpChance(TheDice);
		
		string message = "The Total is " + Score.ToString() + ". Do you wish to accept this?";
		DialogResult result;
		
		// Displays the messageBox.
		result = MessageBox.Show( message,
						"Turn 2 Total",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
		if(result == DialogResult.Yes)
		{
			Turn2Score.Text = Score.ToString();
			TheScore.UpdateTotals( Score );
			Reset();
		}
	}
}

private void Turn3Button_Clicked( object ob, EventArgs e )
{
	if( (RollCount > 0) && (Turn3Score.Text == "") )
	{
		int Score = TheScore.AddUpChance(TheDice);
		
		string message = "The Total is " + Score.ToString() + ". Do you wish to accept this?";
		DialogResult result;
		
		// Displays the messageBox.
		result = MessageBox.Show( message,
						"Turn 3 Total",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
		if(result == DialogResult.Yes)
		{
			Turn3Score.Text = Score.ToString();
			TheScore.UpdateTotals( Score );
			Reset();
		}
	}
}

private void Turn4Button_Clicked( object ob, EventArgs e )
{
	if( (RollCount > 0) && (Turn4Score.Text == "") )
	{
		int Score = TheScore.AddUpChance(TheDice);
		
		string message = "The Total is " + Score.ToString() + ". Do you wish to accept this?";
		DialogResult result;
		
		// Displays the messageBox.
		result = MessageBox.Show( message,
						"Turn 4 Total",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
		if(result == DialogResult.Yes)
		{
			Turn4Score.Text = Score.ToString();
			TheScore.UpdateTotals( Score );
			Reset();
		}
	}
}

  private void Reset()
  {
    RollCount = 0;
    ScoreCount++;
    HoldButton0.Text = "Hold";
    HoldButton1.Text = "Hold";
    HoldButton2.Text = "Hold";
    HoldButton3.Text = "Hold";
    HoldButton4.Text = "Hold";

    TheDice[0].HoldState = true;
    TheDice[1].HoldState = true;
    TheDice[2].HoldState = true;
    TheDice[3].HoldState = true;
    TheDice[4].HoldState = true;

    TotalScore.Text = TheScore.TotalScore.ToString();

    if( ScoreCount == 4 )
    {
      CheckHighScore();

      DialogResult result;

      // Displays the MessageBox.
      result = MessageBox.Show( "Your Score is " + TotalScore.Text + ". Would You like to play again?", 
	                    "End Of Game", 
	                    MessageBoxButtons.YesNo, 
	                    MessageBoxIcon.Question );

      if( result == DialogResult.Yes )
      {
        // Reset Everything
        TheScore.ResetScores();
        RollCount = 0;
        ScoreCount = 0;
        HoldButton0.Text = "Hold";
        HoldButton1.Text = "Hold";
        HoldButton2.Text = "Hold";
        HoldButton3.Text = "Hold";
        HoldButton4.Text = "Hold";
        TotalScore.Text = TheScore.TotalScore.ToString();
        Turn1Score.Text = "";
		Turn2Score.Text = "";
		Turn3Score.Text = "";
		Turn4Score.Text = "";

        TheDice[0].HoldState = true;
        TheDice[0].RollNumber = 1;
        TheDice[1].HoldState = true;
        TheDice[1].RollNumber = 1;
        TheDice[2].HoldState = true;
        TheDice[2].RollNumber = 1;
        TheDice[3].HoldState = true;
        TheDice[3].RollNumber = 1;
        TheDice[4].HoldState = true;
        TheDice[4].RollNumber = 1;
      }
      else
      {
        this.Close();
      }
    }
  } 

  // File->Exit Menu item handler
  private void FileExit_Clicked( object sender, System.EventArgs e )
  {
    this.Close();
  }

  // File->High Scores Menu item handler
  private void FileScore_Clicked( object sender, System.EventArgs e )
  {
    HighScore HighScoreForm = new HighScore( highScoreTable );
    HighScoreForm.StartPosition = FormStartPosition.CenterScreen;
    HighScoreForm.Show();
  }


  private void CheckHighScore()
  {
    highScoreTable.Load( Application.StartupPath+@"\score.txt" );

    int score = Int32.Parse(TotalScore.Text);

    int scoreIndex = highScoreTable.GetIndexOfScore( score );

    if( scoreIndex > -1 )
    {
      string name = "";
      using( Form2 aForm = new Form2() )
      {
        aForm.StartPosition = FormStartPosition.CenterScreen;

        if( aForm.ShowDialog() == DialogResult.OK )
        {
          name = aForm.textBox1.Text;

          highScoreTable.Update( name, score );
        }
      }
    }
  }

  public static void Main(string[] args)
  {
    Application.Run( new YahtzeeForm() );
  }
}
