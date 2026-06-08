using UnityEngine;

public class QuestRowStarString : MonoBehaviour
{
	private static string starSymbol = "☆";

	private static AsciiString[] starStrings;

	private static AsciiString starsBG;

	public static void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, int difficulty)
	{
		InitStarStrings();
		int relicLevelForDifficulty = UpgradeRelicScreen.GetRelicLevelForDifficulty(difficulty);
		Color colorForLevel = UpgradeRelicScreen.GetColorForLevel(relicLevelForDifficulty);
		bool isRainbow = relicLevelForDifficulty >= 7;
		starsBG.isRainbow = isRainbow;
		starsBG.Draw(r, offsetX, offsetY, colorForLevel * ColorConstants.darkGrey);
		int num = (difficulty - 1) % 5;
		starStrings[num].isRainbow = isRainbow;
		starStrings[num].Draw(r, offsetX, offsetY, colorForLevel);
	}

	private static void InitStarStrings()
	{
		if (starStrings != null)
		{
			return;
		}
		starsBG = new AsciiString();
		starsBG.SetValue("☆ ☆ ☆ ☆ ☆");
		starStrings = new AsciiString[5];
		for (int i = 0; i < 5; i++)
		{
			AsciiString asciiString = new AsciiString();
			starStrings[i] = asciiString;
			string text = starSymbol;
			for (int j = 0; j < i; j++)
			{
				text = text + " " + starSymbol;
			}
			asciiString.SetValue(text);
		}
	}
}
