using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterTextMeshProInputField : TMP_InputField, IBetterTransitionUiElement, IResolutionDependency
	{
		[SerializeField]
		private List<Transitions> betterTransitions;

		[SerializeField]
		private List<Graphic> additionalPlaceholders;

		[SerializeField]
		private FloatSizeModifier pointSizeScaler;

		[SerializeField]
		private bool overridePointSize;

		public List<Transitions> BetterTransitions => null;

		public List<Graphic> AdditionalPlaceholders => null;

		public FloatSizeModifier PointSizeScaler => null;

		public bool OverridePointSizeSettings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		public override void OnUpdateSelected(BaseEventData eventData)
		{
		}

		private void DisplayPlaceholders(string input)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public void OnResolutionChanged()
		{
		}

		public void CalculateSize()
		{
		}

		private void OverrideBetterTextMeshSize(BetterTextMeshProUGUI better, float size)
		{
		}
	}
}
