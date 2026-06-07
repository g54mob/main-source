using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[Obsolete]
	public class BetterVerticalLayoutGroup : VerticalLayoutGroup, IBetterHorizontalOrVerticalLayoutGroup, IResolutionDependency
	{
		[SerializeField]
		private MarginSizeModifier paddingSizerFallback;

		[SerializeField]
		private FloatSizeModifier spacingSizerFallback;

		public MarginSizeModifier PaddingSizer => null;

		public FloatSizeModifier SpacingSizer => null;

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		public void CalculateCellSize()
		{
		}
	}
}
