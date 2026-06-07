using System;
using UnityEngine;

namespace UI.Xml
{
	[Serializable]
	public class MaterialDictionary : SerializableDictionary<string, Material>
	{
		public MaterialDictionary()
		{
			_Comparer = StringComparer.OrdinalIgnoreCase;
		}
	}
}
