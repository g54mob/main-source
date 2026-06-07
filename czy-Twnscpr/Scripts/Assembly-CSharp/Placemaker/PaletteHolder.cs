using System;
using UnityEngine;

namespace Placemaker
{
	public class PaletteHolder : MonoBehaviour
	{
		public WorldMaster master;

		public Palette palette;

		public int selectedColorIndex;

		public Action<int> onNewColor;

		public void OnStart()
		{
		}

		public void SelectNextPicker(int delta = 1)
		{
		}

		public void SelectPicker(int i)
		{
		}
	}
}
