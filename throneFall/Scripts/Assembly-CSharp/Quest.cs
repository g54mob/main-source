using System;
using System.Collections.Generic;

[Serializable]
public class Quest
{
	public enum EType
	{
		BeatTheLevel = 0,
		AchieveScoreOf = 2,
		BeatTheLevelWith = 1,
		BeatTheLevelWithout = 3
	}

	public EType questType;

	public List<Equippable> beatTheLevelWith = new List<Equippable>();

	public int achieveScoreOf;

	public List<Equippable> beatTheLevelWithout = new List<Equippable>();

	private bool IsBeatLevelWith => questType == EType.BeatTheLevelWith;

	private bool IsAchieveScoreOf => questType == EType.AchieveScoreOf;

	private bool IsBeatLevelWithout => questType == EType.BeatTheLevelWithout;

	public bool CheckBeaten(LevelData _myLevelData)
	{
		try
		{
			List<Equippable> countQuestsAsIncompleteWith = PerkManager.instance.countQuestsAsIncompleteWith;
			switch (questType)
			{
			case EType.BeatTheLevel:
				return _myLevelData.beatenBest;
			case EType.AchieveScoreOf:
				return _myLevelData.highscoreBest >= achieveScoreOf;
			case EType.BeatTheLevelWith:
			{
				for (int k = 0; k < _myLevelData.levelHasBeenBeatenWith.Count; k++)
				{
					List<Equippable> list2 = _myLevelData.levelHasBeenBeatenWith[k];
					int num = beatTheLevelWith.Count;
					for (int l = 0; l < list2.Count; l++)
					{
						if (beatTheLevelWith.Contains(list2[l]))
						{
							num--;
						}
						if (num <= 0 && !ContainsAnyItemsFromList(list2, countQuestsAsIncompleteWith))
						{
							return true;
						}
					}
				}
				return false;
			}
			case EType.BeatTheLevelWithout:
			{
				for (int i = 0; i < _myLevelData.levelHasBeenBeatenWith.Count; i++)
				{
					List<Equippable> list = _myLevelData.levelHasBeenBeatenWith[i];
					bool flag = true;
					for (int j = 0; j < list.Count; j++)
					{
						if (beatTheLevelWithout.Contains(list[j]))
						{
							flag = false;
							break;
						}
					}
					if (flag && !ContainsAnyItemsFromList(list, countQuestsAsIncompleteWith))
					{
						return true;
					}
				}
				return false;
			}
			default:
				return false;
			}
		}
		catch
		{
			return false;
		}
	}

	private bool ContainsAnyItemsFromList(List<Equippable> mainList, List<Equippable> checkList)
	{
		foreach (Equippable check in checkList)
		{
			if (mainList.Contains(check))
			{
				return true;
			}
		}
		return false;
	}

	public string GetMissionStatement()
	{
		string result = "";
		switch (questType)
		{
		case EType.AchieveScoreOf:
			result = TextTranslator.Translate("Achieve Score") + " " + achieveScoreOf;
			break;
		case EType.BeatTheLevel:
			result = TextTranslator.Translate("Achieve Victory");
			break;
		case EType.BeatTheLevelWith:
			result = TextTranslator.Translate("Achieve Victory With");
			foreach (Equippable item in beatTheLevelWith)
			{
				result = result + " " + item.displayName + " +";
			}
			result = result.Remove(result.Length - 1, 1);
			break;
		case EType.BeatTheLevelWithout:
			result = TextTranslator.Translate("Achieve Victory Without");
			foreach (Equippable item2 in beatTheLevelWithout)
			{
				result = result + " " + item2.displayName + " +";
			}
			result = result.Remove(result.Length - 1, 1);
			break;
		}
		return result;
	}
}
