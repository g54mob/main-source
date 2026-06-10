using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class ColorScheme : MonoBehaviour
	{
		public Color Dark1;

		public Color Dark2;

		public Color Dark3;

		public Color White;

		internal int H1_px;

		internal int H2_px;

		internal int H3_px;

		internal int H4_px;

		internal int H5_px;

		internal int ParagraphBig_px;

		internal int ParagraphNormal_px;

		internal int SmallTextRegular_px;

		internal int SmallTextSemibold_px;

		internal int MainNavigation_px;

		public Color Highlight;

		public Color Inactive1;

		public Color Inactive2;

		public Color Inactive3;

		public Color PositiveAccent;

		public Color NegativeAccent;

		public bool LightMode;

		private void Reset()
		{
		}

		[ContextMenu("Restore Default Colors")]
		public void SetColorsToDefault()
		{
		}

		public void RefreshUI()
		{
		}

		public ColorBlock GetColorBlock_Button()
		{
			return default(ColorBlock);
		}

		public ColorBlock GetColorBlock_Dropdown()
		{
			return default(ColorBlock);
		}

		public Color GetSchemeColor(ColorSetterType enumType)
		{
			return default(Color);
		}
	}
}
