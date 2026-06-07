using System.Collections.Generic;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	[SerializeField]
	public class Vector3IntSerlializableDictionary
	{
		public Dictionary<string, int> dictionary = new Dictionary<string, int>();

		public void Add(Vector3Int key, int value)
		{
			dictionary[key.ToString()] = value;
		}
	}
}
