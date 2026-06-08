using UnityEngine;
using UnityEngine.UI;

namespace Themee
{
	public class SelectableStyle : Style
	{
		public Selectable selectable;

		private Color normal_color;

		private Color highlighted_color;

		private Color pressed_color;

		private Color selected_color;

		private Color disabled_color;

		protected override void Setup()
		{
		}

		protected override void Build()
		{
		}

		private void Reset()
		{
		}
	}
}
