using System;
using System.Collections.Generic;

[Serializable]
public class LevelData
{
	public int questsCompleteWhenLastVisitingMap;

	public bool beaten;

	public int highscore;

	public List<int> dayToDayScore = new List<int>();

	public List<int> dayToDayNetworth = new List<int>();

	public bool beatenBest;

	public int highscoreBest;

	public List<int> dayToDayScoreBest = new List<int>();

	public List<int> dayToDayNetworthBest = new List<int>();

	public List<List<Equippable>> levelHasBeenBeatenWith = new List<List<Equippable>>();

	public void SaveScoreAndStatsToBestIfBest(bool _endOfMatch)
	{
		beatenBest = beaten || beatenBest;
		if (highscore > highscoreBest)
		{
			highscoreBest = highscore;
			dayToDayScoreBest = new List<int>(dayToDayScore);
			dayToDayNetworthBest = new List<int>(dayToDayNetworth);
		}
		if (_endOfMatch && beaten)
		{
			levelHasBeenBeatenWith.Add(new List<Equippable>(PerkManager.instance.CurrentlyEquipped));
		}
		beaten = false;
		highscore = 0;
		dayToDayScore = new List<int>();
		dayToDayScore.Add(0);
		dayToDayNetworth = new List<int>();
	}
}
