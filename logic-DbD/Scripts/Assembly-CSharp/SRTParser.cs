using System;
using System.Collections.Generic;
using UnityEngine;

public class SRTParser
{
	private enum eReadState
	{
		Index = 0,
		Time = 1,
		Text = 2
	}

	private List<SubtitleBlock> _subtitles;

	public SRTParser(string textAssetResourcePath)
	{
		Load(Resources.Load<TextAsset>(textAssetResourcePath));
	}

	public SRTParser(TextAsset textAsset)
	{
		_subtitles = Load(textAsset);
	}

	public static List<SubtitleBlock> Load(TextAsset textAsset)
	{
		if (textAsset == null)
		{
			Debug.LogError("Subtitle file is null");
			return null;
		}
		string[] array = textAsset.text.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
		eReadState eReadState2 = eReadState.Index;
		List<SubtitleBlock> list = new List<SubtitleBlock>();
		int index = 0;
		double num = 0.0;
		double to = 0.0;
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i];
			switch (eReadState2)
			{
			case eReadState.Index:
			{
				if (int.TryParse(text2, out var result3))
				{
					index = result3;
					eReadState2 = eReadState.Time;
				}
				break;
			}
			case eReadState.Time:
			{
				text2 = text2.Replace(',', '.');
				string[] array2 = text2.Split(new string[1] { "-->" }, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length == 2 && TimeSpan.TryParse(array2[0], out var result) && TimeSpan.TryParse(array2[1], out var result2))
				{
					num = result.TotalSeconds;
					to = result2.TotalSeconds;
					eReadState2 = eReadState.Text;
				}
				break;
			}
			case eReadState.Text:
				if (text != string.Empty)
				{
					text += "\r\n";
				}
				text += text2;
				if (string.IsNullOrEmpty(text2) || i == array.Length - 1)
				{
					list.Add(new SubtitleBlock(index, num, to, text));
					text = string.Empty;
					eReadState2 = eReadState.Index;
				}
				break;
			}
		}
		return list;
	}

	public SubtitleBlock GetForTime(float time)
	{
		if (_subtitles.Count > 0)
		{
			SubtitleBlock subtitleBlock = _subtitles[0];
			if ((double)time >= subtitleBlock.To)
			{
				_subtitles.RemoveAt(0);
				if (_subtitles.Count == 0)
				{
					return null;
				}
				subtitleBlock = _subtitles[0];
			}
			if (subtitleBlock.From > (double)time)
			{
				return SubtitleBlock.Blank;
			}
			return subtitleBlock;
		}
		return null;
	}
}
