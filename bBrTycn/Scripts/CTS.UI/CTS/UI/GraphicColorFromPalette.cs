using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	public class GraphicColorFromPalette : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Graphic _graphic;

		[SerializeField]
		private PaletteData _color;

		protected override void OnAwake()
		{
			base.OnAwake();
			_graphic.color = _color;
		}
	}
}
