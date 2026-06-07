using System;
using System.Text;
using ProfanityFilter;
using UnityEngine;

namespace Tabletop
{
	public static class ProfanityManager
	{
		private const string path = "Profanities";

		public static global::ProfanityFilter.ProfanityFilter ProfanityFilter { get; private set; }

		public static void Init()
		{
			TextAsset[] array = Resources.LoadAll<TextAsset>("Profanities");
			StringBuilder stringBuilder = new StringBuilder();
			TextAsset[] array2 = array;
			foreach (TextAsset textAsset in array2)
			{
				stringBuilder.Append(textAsset.text);
			}
			ProfanityFilter = new global::ProfanityFilter.ProfanityFilter(stringBuilder.ToString().Split(new char[2] { '\n', '\r' }, stringBuilder.Length, StringSplitOptions.RemoveEmptyEntries));
		}
	}
}
