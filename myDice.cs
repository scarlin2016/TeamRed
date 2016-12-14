using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Summary description for Dice.
/// </summary
public class Dice : System.Windows.Forms.UserControl
{
  /// <summary> 
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.Container components = null;

  // constructor for Dice
  public Dice( int seed )
  {
    InitializeRandomRoll( seed );
    InitializeComponent();
  }

  /// <summary> 
  /// Clean up any resources being used.
  /// </summary>
  protected override void Dispose( bool disposing )
  {
    if( disposing )
    {
      if(components != null)
      {
        components.Dispose();
      }
    }
    base.Dispose( disposing );
  }

  private void InitializeComponent()
  {
    this.Name = "Dice";
    this.Size = new Size( 48, 48 );
    this.Click += new System.EventHandler( UserControl1_Click );
  }

  #region - variables
  ///
  /// private members
  ///
  private const int dotWidth = 12;
  private Random RandomPick;

  ///
  /// value of dice
  ///
  private int m_nRoll = 1;
  public int RollNumber
  {
    get { return m_nRoll;  }
    set { m_nRoll = value; }
  }

  ///
  /// Hold state of dice
  ///
  private bool m_bHoldState = true;
  public bool HoldState
  {
    get { return m_bHoldState; }
    set
    {
      m_bHoldState = value;
      Invalidate();
    }
  }
  #endregion

  protected void UserControl1_Click( object sender, System.EventArgs e )
  {
    HoldState = !HoldState;
  }

  ///
  /// Routines to draw dice
  ///
  #region - Routines to draw dice
  protected override void OnPaint( PaintEventArgs pe )
  {
    Graphics g = pe.Graphics;
    Pen blackPen = new Pen( Color.Black, 1 );
    Pen redPen = new Pen( Color.Red, 1 );

    // Draw background of dice
    Rectangle rect = new Rectangle( 0,
                                    0, 
                                    this.Size.Width, 
                                    this.Size.Height );

    SolidBrush whiteBrush = new SolidBrush( Color.White );
    g.FillRectangle( whiteBrush, rect );

    if (HoldState)
    {
      g.DrawRectangle( redPen, rect );
    }
    else
    {
      g.DrawRectangle( blackPen, rect );
    }

    // Draw dice dependant upon roll number
    switch( RollNumber )
    {
      case 1:
        DrawOne(g);
        break;
      case 2:
        DrawTwo(g);
        break;
      case 3:
        DrawThree(g);
        break;
      case 4:
        DrawFour(g);
        break;
      case 5:
        DrawFive(g);
        break;
      case 6:
        DrawSix(g);
        break;
      default:
        break;
    }

    // Dispose of objects
    blackPen.Dispose();
    redPen.Dispose();
    whiteBrush.Dispose();
  }

  public void DrawDot( Graphics g, Point p )
  {
    SolidBrush myBrush;

    if( HoldState )
    {
      myBrush = new SolidBrush( Color.Red );
    }
    else
    {
      myBrush = new SolidBrush( Color.Black );
    }

    g.FillEllipse( myBrush, p.X, p.Y, dotWidth, dotWidth );
    myBrush.Dispose();
  }

  ///
  /// Draw one dot
  ///
  public void DrawOne( Graphics g )
  {
    Rectangle rect = this.ClientRectangle;
    DrawDot( g, new Point( (rect.Left + rect.Right - dotWidth)/2, (rect.Top + rect.Bottom - dotWidth)/2 ) );
  }

  ///
  /// Draw two dots
  ///
  public void DrawTwo( Graphics g )
  {
    Rectangle rect = this.ClientRectangle;
    DrawDot( g, new Point( (rect.Right - 3 - dotWidth), (rect.Top + 3) ) ); // Top Right
    DrawDot( g, new Point( (rect.Left + 3), (rect.Bottom - 3 - dotWidth) ) ); // Bottom Left
  }

  ///
  /// Draw three dots
  ///
  public void DrawThree( Graphics g )
  {
    Rectangle rect = this.ClientRectangle;
    DrawOne(g);
    DrawTwo(g);
  }

  ///
  /// Draw four dots
  ///
  public void DrawFour( Graphics g )
  {
    Rectangle rect = this.ClientRectangle;
    DrawTwo(g);
    DrawDot( g, new Point( (rect.Left + 3), (rect.Top + 3) ) ); // Top Left
    DrawDot( g, new Point( (rect.Right - 3 - dotWidth), (rect.Bottom - 3 - dotWidth) ) ); // Bottom Right
  }

  ///
  /// Draw five dots
  ///
  public void DrawFive( Graphics g )
  {
    DrawOne(g);
    DrawFour(g);
  }

  ///
  /// Draw six dots
  ///
  public void DrawSix( Graphics g )
  {
    DrawFour(g);
    Rectangle rect = this.ClientRectangle;
    DrawDot( g, new Point( (rect.Left + rect.Right - dotWidth)/2, (rect.Top + 3) ) ); // Top Middle
    DrawDot( g, new Point( (rect.Left + rect.Right - dotWidth)/2, (rect.Bottom - 3 - dotWidth) ) ); // Bottom Middle
  }
  #endregion

  ///
  /// Routine to get random number
  ///
  #region - Routines to create random number
  public void Roll()
  {
    // If the dice is not held, roll it
    if( !HoldState )
    {
      RollNumber = RandomPick.Next(1,7);
      this.Invalidate();
    }
  }

  public void InitializeRandomRoll( int nSeed )
  {
    DateTime aTime = new DateTime(1000);
    aTime = DateTime.Now;
    nSeed += (int)(aTime.Millisecond);
    RandomPick = new Random(nSeed);
  }
  #endregion
}