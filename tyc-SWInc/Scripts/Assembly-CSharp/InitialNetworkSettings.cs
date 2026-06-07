using System.IO;

public class InitialNetworkSettings : IByteData
{
	public string[][] UnlockedSpecs;

	public PersonalityGraph Personalities;

	public DifficultyValues.DifficultySetting Difficulty;

	public int StartYear;

	public InitialNetworkSettings(string[][] unlockedSpecs, PersonalityGraph personalities, DifficultyValues.DifficultySetting difficulty, int startYear)
	{
		UnlockedSpecs = unlockedSpecs;
		Personalities = personalities;
		Difficulty = difficulty;
		StartYear = startYear;
	}

	public static InitialNetworkSettings GetCurrentSettings()
	{
		return new InitialNetworkSettings(GameSettings.Instance.GetAllUnlockedSpecializations(), GameSettings.Instance.Personalities, GameSettings.Instance.Difficulty, SDateTime.Now().RealYear);
	}

	public void WriteData(Stream st)
	{
		st.WriteInt(UnlockedSpecs.Length);
		for (int i = 0; i < UnlockedSpecs.Length; i++)
		{
			st.WriteInt(UnlockedSpecs[i].Length);
			for (int j = 0; j < UnlockedSpecs[i].Length; j++)
			{
				st.WriteStringUTF8(UnlockedSpecs[i][j]);
			}
		}
		Personalities.WriteData(st);
		Difficulty.WriteData(st);
		st.WriteInt(StartYear);
	}

	public static InitialNetworkSettings ReadData(Stream st)
	{
		int num = st.ReadInt();
		string[][] array = new string[num][];
		for (int i = 0; i < num; i++)
		{
			int num2 = st.ReadInt();
			string[] array2 = (array[i] = new string[num2]);
			for (int j = 0; j < num2; j++)
			{
				array2[j] = st.ReadStringUTF8();
			}
		}
		PersonalityGraph personalities = PersonalityGraph.ReadData(st);
		DifficultyValues.DifficultySetting difficulty = DifficultyValues.DifficultySetting.ReadData(st);
		return new InitialNetworkSettings(array, personalities, difficulty, st.ReadInt());
	}
}
