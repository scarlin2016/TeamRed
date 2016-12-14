using System;

/// <summary>
/// Summary description for CalculateScore
/// </summary>
public class CalculateScore
{
  private int Total = 0;
  public int TotalScore
  {
    get { return Total; }	
  }

  public CalculateScore()
  {
  }

  public void ResetScores()
  {
    Total = 0;
  }
  public void UpdateTotals( int Score )
  {
	  Total += Score;
  }

  

  public int AddUpDice( int DieNumber, Dice[] myDice )
  {
    int Sum = 0;

    for( int i = 0; i < 5; i++ )
    {
      if( myDice[i].RollNumber == DieNumber )
      {
        Sum += DieNumber;
      }
    }

    return Sum;
  }
   public int AddUpChance( Dice[] myDice )
  {
    int Sum = 0;

    for( int i = 0; i < 5; i++ )
    {
      Sum += myDice[i].RollNumber;
    }

    return Sum;
  }
  }