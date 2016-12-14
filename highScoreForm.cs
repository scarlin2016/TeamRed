using System;
using System.Drawing;
using System.Windows.Forms;

public class Form2 : Form
{
  private Label label1;
  public  TextBox textBox1;
  private Button button1;
  private Button button2;

  private System.ComponentModel.Container components = null;

  public Form2()
  {
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
    label1 = new Label();
    textBox1 = new TextBox();
    button1 = new Button();
    button2 = new Button();

    // label1
    label1.Location = new Point(16, 16);
    label1.Name = "New High Score";
    label1.Text = "Enter Your Name:";

    // textBox1
    textBox1.Location = new Point(120, 16);
    textBox1.Name = "textBox1";
    label1.TabIndex = 0;
    textBox1.Text = "";

    // button1
    button1.DialogResult = DialogResult.OK;
    button1.Location = new Point(32, 48);
    button1.Name = "button1";
    button1.Text = "OK";

    // button2
    button2.DialogResult = DialogResult.Cancel;
    button2.Location = new Point(120, 48);
    button2.Name = "button2";
    button2.Text = "Cancel";

    // name
    ClientSize = new Size(232, 78);
    Controls.Add(button2);
    Controls.Add(button1);
    Controls.Add(textBox1);
    Controls.Add(label1);
    this.Text = "Name Entry";
  }
}