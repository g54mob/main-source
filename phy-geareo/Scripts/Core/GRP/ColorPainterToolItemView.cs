using GRP.Pages.NSProjectFrame;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class ColorPainterToolItemView : ToolItemView<ColorPainterToolItemViewable>
	{
		public ColorPicker colorPicker;

		private Color lastColor;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		private void ColorChanged(Color color)
		{
		}

		private void StartEdit(Color color)
		{
		}

		private void EndEdit(Color color)
		{
		}
	}
}
