using TMPro;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterTextMeshProUGUI : TextMeshProUGUI, IResolutionDependency
	{
		[SerializeField]
		private BetterText.FittingMode fitting;

		[SerializeField]
		private MarginSizeModifier marginSizerFallback;

		[SerializeField]
		private MarginSizeConfigCollection customMarginSizers;

		[SerializeField]
		private FloatSizeModifier fontSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customFontSizers;

		[SerializeField]
		private FloatSizeModifier minFontSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customMinFontSizers;

		[SerializeField]
		private FloatSizeModifier maxFontSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customMaxFontSizers;

		public BetterText.FittingMode Fitting
		{
			get
			{
				return default(BetterText.FittingMode);
			}
			set
			{
			}
		}

		public MarginSizeModifier MarginSizer => null;

		public FloatSizeModifier FontSizer => null;

		public FloatSizeModifier MinFontSizer => null;

		public FloatSizeModifier MaxFontSizer => null;

		public bool IgnoreFontSizerOptions { get; set; }

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public void CalculateSize()
		{
		}

		public void RegisterMaterials(Material[] materials)
		{
		}
	}
}
