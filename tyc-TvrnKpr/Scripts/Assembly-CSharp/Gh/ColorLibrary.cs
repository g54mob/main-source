using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	[Serializable]
	public class ColorLibrary
	{
		[Serializable]
		public class ColorEntry
		{
			public string id;

			public Color color;

			public ColorEntry(string id, Color color)
			{
			}
		}

		[SerializeField]
		private List<ColorEntry> _colorEntries;

		public void AddColor(string id, Color color)
		{
		}

		public Color GetColor(string id)
		{
			return default(Color);
		}
	}
}
