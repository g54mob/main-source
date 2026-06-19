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

		internal int H1_px = 48;

		internal int H2_px = 40;

		internal int H3_px = 32;

		internal int H4_px = 24;

		internal int H5_px = 18;

		internal int ParagraphBig_px = 24;

		internal int ParagraphNormal_px = 18;

		internal int SmallTextRegular_px = 16;

		internal int SmallTextSemibold_px = 16;

		internal int MainNavigation_px = 20;

		public Color Highlight;

		public Color Inactive1;

		public Color Inactive2;

		public Color Inactive3;

		public Color PositiveAccent;

		public Color NegativeAccent;

		public bool LightMode;

		private void Reset()
		{
			SetColorsToDefault();
		}

		[ContextMenu("Restore Default Colors")]
		public void SetColorsToDefault()
		{
			ColorUtility.TryParseHtmlString("#1B2038", out Dark1);
			ColorUtility.TryParseHtmlString("#212945", out Dark2);
			ColorUtility.TryParseHtmlString("#0E101B", out Dark3);
			ColorUtility.TryParseHtmlString("#FFFFFF", out White);
			ColorUtility.TryParseHtmlString("#07C1D8", out Highlight);
			ColorUtility.TryParseHtmlString("#C1C4D7", out Inactive1);
			ColorUtility.TryParseHtmlString("#AEB1C2", out Inactive2);
			ColorUtility.TryParseHtmlString("#737684", out Inactive3);
			ColorUtility.TryParseHtmlString("#7EEF8C", out PositiveAccent);
			ColorUtility.TryParseHtmlString("#DB5355", out NegativeAccent);
		}

		public void RefreshUI()
		{
			ColorSetter[] componentsInChildren = GetComponentsInChildren<ColorSetter>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Refresh(this);
			}
		}

		public ColorBlock GetColorBlock_Button()
		{
			return new ColorBlock
			{
				fadeDuration = 0.1f,
				normalColor = Inactive2,
				highlightedColor = Highlight,
				pressedColor = Inactive2,
				disabledColor = Dark3,
				colorMultiplier = 1f
			};
		}

		public ColorBlock GetColorBlock_Dropdown()
		{
			return new ColorBlock
			{
				normalColor = Inactive2,
				highlightedColor = Highlight,
				pressedColor = Inactive2,
				disabledColor = Dark3
			};
		}

		public Color GetSchemeColor(ColorSetterType enumType)
		{
			return enumType switch
			{
				ColorSetterType.Dark1 => Dark1, 
				ColorSetterType.Dark2 => Dark2, 
				ColorSetterType.Dark3 => Dark3, 
				ColorSetterType.White => White, 
				ColorSetterType.Highlight => Highlight, 
				ColorSetterType.Inactive1 => Inactive1, 
				ColorSetterType.Inactive2 => Inactive2, 
				ColorSetterType.Inactive3 => Inactive3, 
				ColorSetterType.PositiveAccent => PositiveAccent, 
				ColorSetterType.NegativeAccent => NegativeAccent, 
				_ => default(Color), 
			};
		}
	}
}
