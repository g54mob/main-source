using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class NameGenerator : SingletonScriptableObjectAsset<NameGenerator>
	{
		[SerializeField]
		[HideInInspector]
		private string[] _keys;

		[SerializeField]
		[HideInInspector]
		private int[] _valueLengths;

		[SerializeField]
		[HideInInspector]
		private string[] _values;

		private Dictionary<string, string[]> _nameTable;

		public string[] AllNames => null;

		public Dictionary<string, string[]> NameTable => null;

		private void EnsureDictionary()
		{
		}

		public string GetRandomFirstName(string race, bool isFemale)
		{
			return null;
		}
	}
}
