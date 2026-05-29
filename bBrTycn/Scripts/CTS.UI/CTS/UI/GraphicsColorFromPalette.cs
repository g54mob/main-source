using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[Constructor("Construct")]
	public class GraphicsColorFromPalette : CTSBehaviour
	{
		[SerializeField]
		private PaletteData _paletteData;

		[SerializeField]
		private Graphic[] _graphics;

		private void Construct()
		{
			Color color = _paletteData.GetColor();
			Graphic[] graphics = _graphics;
			for (int i = 0; i < graphics.Length; i++)
			{
				graphics[i].color = color;
			}
		}
	}
}
