using System;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class NameGeneratorUtility
	{
		[Serializable]
		private class CallsignsData
		{
			public string[] Callsigns;
		}

		[Serializable]
		private class NamesData
		{
			public string[] Boys;

			public string[] Girls;

			public string[] Last;
		}

		private static CallsignsData _callsigns;

		private static NamesData _names;

		public static int JsonBoyNameCount { get; set; } = 1000;

		public static string JsonCallsignResourceLocation { get; set; } = "Other/callsigns";

		public static int JsonGirlNameCount { get; set; } = 1000;

		public static int JsonLastNameCount { get; set; } = 1000;

		public static string JsonNameResourceLocation { get; set; } = "Other/names";

		private static CallsignsData Callsigns
		{
			get
			{
				if (_callsigns == null)
				{
					_callsigns = JsonUtility.FromJson<CallsignsData>(Resources.Load<TextAsset>(JsonCallsignResourceLocation).text);
				}
				return _callsigns;
			}
		}

		private static NamesData Names
		{
			get
			{
				if (_names == null)
				{
					_names = JsonUtility.FromJson<NamesData>(Resources.Load<TextAsset>(JsonNameResourceLocation).text);
				}
				return _names;
			}
		}

		public static string Callsign(bool addFlair)
		{
			string text = Callsigns.Callsigns[UnityEngine.Random.Range(0, Callsigns.Callsigns.Length)];
			if (addFlair)
			{
				text = "the \"" + text + "\"";
			}
			return text;
		}

		public static string FirstName(bool? boy)
		{
			if (!boy.HasValue)
			{
				boy = UnityEngine.Random.Range(0, 2) == 0;
			}
			if (boy.Value)
			{
				return Names.Boys[UnityEngine.Random.Range(0, JsonBoyNameCount)];
			}
			return Names.Girls[UnityEngine.Random.Range(0, JsonGirlNameCount)];
		}

		public static string FullName(bool? boy, bool callsign)
		{
			return FirstName(boy) + " " + (callsign ? Callsign(addFlair: true) : string.Empty) + " " + LastName();
		}

		public static string LastName()
		{
			return Names.Last[UnityEngine.Random.Range(0, JsonLastNameCount)];
		}
	}
}
