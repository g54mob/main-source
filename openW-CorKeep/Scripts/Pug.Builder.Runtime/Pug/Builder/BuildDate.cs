using System;
using System.Globalization;
using UnityEngine;

namespace Pug.Builder
{
	public static class BuildDate
	{
		public static readonly string DateFilePath = "Assets/Resources/date.txt";

		private static readonly string dateFileAssetPath = "date";

		public new static string ToString()
		{
			TextAsset textAsset = Resources.Load<TextAsset>(dateFileAssetPath);
			if (textAsset != null && DateTime.TryParse(textAsset.text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var result))
			{
				return result.ToString("ddd, MMM dd, yyyy", new CultureInfo("en-US"));
			}
			return "";
		}
	}
}
