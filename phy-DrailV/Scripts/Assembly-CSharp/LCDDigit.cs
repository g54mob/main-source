using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LCDDigit : MonoBehaviour
{
	public char displayedChar;

	public bool displayDot;

	public bool displayColon;

	private char lastChar;

	private GameObject[] children;

	public static Dictionary<char, string> charMap = new Dictionary<char, string>
	{
		{ ' ', "________________" },
		{ '0', "12_45__8_012_4_6" },
		{ '1', "__________12_4__" },
		{ '2', "_2345__8901_____" },
		{ '3', "_23_5__89012____" },
		{ '4', "1_3_____9_12____" },
		{ '5', "123_5__890_2____" },
		{ '6', "12345__890_2____" },
		{ '7', "_2_____8__12____" },
		{ '8', "12345__89012____" },
		{ '9', "123_5__89012____" },
		{ 'A', "1234___89_12____" },
		{ 'B', "12345__8_0___45_" },
		{ 'C', "12_45__8_0______" },
		{ 'D', "_2__5678_012____" },
		{ 'E', "12345__8_0______" },
		{ 'F', "1234___89_______" },
		{ 'G', "12_45__890_2____" },
		{ 'H', "1_34____9_12____" },
		{ 'I', "_2__5678_0______" },
		{ 'J', "___45____012____" },
		{ 'K', "1_34_________45_" },
		{ 'L', "1__45____0______" },
		{ 'M', "1__4______1234__" },
		{ 'N', "1__4______123_5_" },
		{ 'O', "12_45__8_012____" },
		{ 'P', "1234___89_1_____" },
		{ 'Q', "12_45__8_012__5_" },
		{ 'R', "1234___89_1___5_" },
		{ 'S', "_2__5__890_23___" },
		{ 'T', "12___678__1_____" },
		{ 'U', "1__45____012____" },
		{ 'V', "1__4_________4_6" },
		{ 'W', "1__45_7__012____" },
		{ 'X', "____________3456" },
		{ 'Y', "______7_____34__" },
		{ 'Z', "_2__5__8_0___4_6" },
		{ '-', "__3_____9_______" },
		{ '+', "__3__67_9_______" }
	};

	private void Start()
	{
		List<Transform> list = new List<Transform>(GetComponentsInChildren<Transform>());
		list.RemoveAt(0);
		children = list.Select((Transform t) => t.gameObject).ToArray();
	}

	private void Update()
	{
		if (lastChar != displayedChar)
		{
			lastChar = displayedChar;
			DisplayChar(displayedChar);
		}
		children[0].SetActive(displayColon);
		children[1].SetActive(displayDot);
	}

	private void DisplayChar(char chr)
	{
		if (!charMap.ContainsKey(chr))
		{
			Debug.LogError("LCDDigit can't display character '" + chr + "'");
			return;
		}
		char[] array = charMap[chr].ToCharArray();
		for (int i = 0; i < 16; i++)
		{
			children[i + 2].SetActive(array[i] != '_');
		}
	}
}
