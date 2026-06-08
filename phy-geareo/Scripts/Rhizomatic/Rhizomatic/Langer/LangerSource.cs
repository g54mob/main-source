using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Langer
{
	[CreateAssetMenu(fileName = "LangerSource", menuName = "Langer/LangerSource")]
	public class LangerSource : ScriptableObject
	{
		[Serializable]
		public class Entry
		{
			public LangerLanguage language;

			public TextAsset source;
		}

		public Entry[] entries;

		public LangerSource[] fallbacks;

		public Dictionary<LangerLanguage, Dictionary<string, string>> baked;

		public void TryBake()
		{
		}

		public void Bake()
		{
		}

		public string Get(string key, LangerLanguage language)
		{
			return null;
		}

		public void EnsureKey(string key)
		{
		}
	}
}
