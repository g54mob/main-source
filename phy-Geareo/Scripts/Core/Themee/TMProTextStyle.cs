using TMPro;
using UnityEngine;

namespace Themee
{
	public class TMProTextStyle : Style
	{
		public TMP_Text text;

		private float font_size;

		private Color color;

		private bool auto_size;

		private float min_size;

		private float max_size;

		private FontStyles fontStyle;

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
