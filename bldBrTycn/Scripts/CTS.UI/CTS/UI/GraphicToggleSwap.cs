using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	public class GraphicToggleSwap : CTSBehaviour
	{
		[Serializable]
		public struct Swapper
		{
			public Graphic Graphic;

			public PaletteData OnPalette;

			public PaletteData OffPalette;
		}

		[SerializeField]
		private Swapper[] _swappers;

		public void SetValue(bool isOn)
		{
			if (isOn)
			{
				Swapper[] swappers = _swappers;
				for (int i = 0; i < swappers.Length; i++)
				{
					Swapper swapper = swappers[i];
					swapper.Graphic.color = swapper.OnPalette.GetColor();
				}
			}
			else
			{
				Swapper[] swappers = _swappers;
				for (int i = 0; i < swappers.Length; i++)
				{
					Swapper swapper2 = swappers[i];
					swapper2.Graphic.color = swapper2.OffPalette.GetColor();
				}
			}
		}
	}
}
