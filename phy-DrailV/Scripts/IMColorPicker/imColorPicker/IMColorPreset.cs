using System.Collections.Generic;
using UnityEngine;

namespace imColorPicker
{
	public class IMColorPreset : ScriptableObject
	{
		[SerializeField]
		private List<Color> colors;

		public List<Color> Colors => colors;

		public void Save(Color color)
		{
			colors.Add(color);
		}

		public void Remove(int index)
		{
			colors.RemoveAt(index);
		}
	}
}
