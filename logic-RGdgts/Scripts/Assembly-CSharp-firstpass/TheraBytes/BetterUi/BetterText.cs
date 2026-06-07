using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterText : Text, IResolutionDependency
	{
		public enum FittingMode
		{
			SizerOnly = 0,
			StayInBounds = 1,
			BestFit = 2
		}

		[SerializeField]
		private FittingMode fitting;

		[SerializeField]
		private FloatSizeModifier fontSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customFontSizers;

		private bool isCalculatingSize;

		public FloatSizeModifier FontSizer => null;

		public FittingMode Fitting
		{
			get
			{
				return default(FittingMode);
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public override void SetVerticesDirty()
		{
		}

		private void CalculateSize()
		{
		}
	}
}
