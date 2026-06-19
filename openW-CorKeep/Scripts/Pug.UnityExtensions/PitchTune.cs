using System.Collections.Generic;
using UnityEngine;

public class PitchTune
{
	private static readonly int[,] scales = new int[12, 7]
	{
		{ 0, 2, 4, 5, 7, 9, 11 },
		{ 1, 3, 4, 6, 8, 10, 12 },
		{ 2, 4, 6, 7, 9, 11, 13 },
		{ 3, 5, 7, 8, 10, 12, 14 },
		{ 4, 6, 8, 9, 11, 13, 15 },
		{ 5, 7, 9, 10, 12, 14, 16 },
		{ 6, 8, 10, 11, 13, 15, 17 },
		{ 7, 9, 11, 12, 14, 16, 18 },
		{ 8, 10, 12, 13, 15, 17, 19 },
		{ 9, 11, 13, 14, 16, 18, 20 },
		{ 10, 12, 14, 15, 17, 19, 21 },
		{ 11, 13, 15, 16, 17, 20, 22 }
	};

	public const string marseillaise = "CCCFFGGC'AFFAFDA#GEFFGAAAA#AAGGAA#A#A#C'A#AC'C'C'AFC'AFCCCEGA#GEGFD#DFFFEFGGG#G#G#G#A#G#GG#GFFFG#FFEC'C'C'AFGC'C'C'AFGCFGAA#C'D'GD'C'AA#GF";

	public const string duGamla = "BBGGGABBAGF#AAF#GAF#BGEDDGGAF#F#GEDEF#DDGF#GABGC'BAGDGF#GABGC'BAG";

	public static float SemitoneToPitch(int semitone)
	{
		return Mathf.Pow(1.05946f, semitone);
	}

	public static float ScaleNoteToPitch(int noteInScale, int scaleID = 0, int startOctave = 0)
	{
		int num = noteInScale / 7 + startOctave;
		return SemitoneToPitch(12 * num + scales[scaleID, noteInScale % 7]);
	}

	public static int NoteToSemitone(char c)
	{
		return c switch
		{
			'C' => 0, 
			'D' => 2, 
			'E' => 4, 
			'F' => 5, 
			'G' => 7, 
			'A' => 9, 
			'B' => 11, 
			_ => -1, 
		};
	}

	public static float[] ParseScore(string score)
	{
		List<int> list = ParseScoreToSemitones(score);
		float[] array = new float[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = SemitoneToPitch(list[i]);
		}
		return array;
	}

	public static List<int> ParseScoreToSemitones(string score)
	{
		List<int> list = new List<int>();
		int num = 0;
		int num2 = -1;
		foreach (char c in score)
		{
			int num3 = NoteToSemitone(c);
			if (num3 >= 0)
			{
				list.Add(num3 + num);
				num2++;
				continue;
			}
			switch (c)
			{
			case '\'':
				list[num2] += 12;
				break;
			case '#':
				list[num2]++;
				break;
			case 'b':
				list[num2]--;
				break;
			case '+':
				num += 12;
				break;
			case '-':
				num -= 12;
				break;
			}
		}
		return list;
	}
}
