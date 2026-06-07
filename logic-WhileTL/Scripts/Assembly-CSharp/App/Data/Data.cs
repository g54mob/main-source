using System.Collections.Generic;
using UnityEngine;

namespace App.Data
{
	public class Data
	{
		public string KeyName;

		public string Sprite;

		public int RC;

		public int GC;

		public int BC;

		public int RS;

		public int GS;

		public int BS;

		public int RT;

		public int GT;

		public int BT;

		public string words;

		public string truePredict;

		public string colorsQueue;

		public float Time;

		public int RandomSeed;

		public string GetRandomWord()
		{
			List<string> list = new List<string>();
			for (char c = 'A'; c <= 'Z'; c = (char)(c + 1))
			{
				if (words.Contains(c.ToString()))
				{
					list.Add(c.ToString());
				}
			}
			if (list.Count == 0)
			{
				return "";
			}
			return list[Random.Range(0, list.Count)];
		}

		public void InitEmpty()
		{
			RC = 10;
			GC = 10;
			BC = 10;
			RS = 10;
			GS = 10;
			BS = 10;
			RT = 10;
			GT = 10;
			BT = 10;
			RandomSeed = 1234;
			Time = 0f;
			words = "";
			KeyName = "Sandbox";
		}
	}
}
