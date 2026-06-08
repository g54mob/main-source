using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiScalingAffectedStatsScreen : UiScalingAffected
	{
		[SerializeField]
		private HorizontalOrVerticalLayoutGroup rowTitleLayoutGroup;

		[SerializeField]
		private RectTransform containerIcon;

		[SerializeField]
		private RectTransform containerStats;

		[SerializeField]
		private int largeRowTitleLayoutGroupPaddingRight = 150;

		[SerializeField]
		private int smallRowTitleLayoutGroupPaddingRight;

		[SerializeField]
		private int largeRowTitleLayoutGroupPaddingLeft = 150;

		[SerializeField]
		private int smallRowTitleLayoutGroupPaddingLeft;

		[SerializeField]
		private int defaultRowTitleLayoutGroupPaddingRight;

		[SerializeField]
		private int defaultRowTitleLayoutGroupPaddingLeft;

		[SerializeField]
		private int defaultContainerStatsLayoutGroupPaddingRight;

		[SerializeField]
		private int defaultContainerStatsLayoutGroupPaddingLeft;

		[SerializeField]
		private Vector2 defaultContainerIconAnchoredPosition;

		private UiStatsScreen uiStatsScreen;

		protected override void Initialize()
		{
			if (uiStatsScreen == null)
			{
				uiStatsScreen = GetComponent<UiStatsScreen>();
			}
			if (!isInitialized)
			{
				defaultRowTitleLayoutGroupPaddingRight = rowTitleLayoutGroup.padding.right;
				defaultRowTitleLayoutGroupPaddingLeft = rowTitleLayoutGroup.padding.left;
				defaultContainerIconAnchoredPosition = containerIcon.anchoredPosition;
				defaultContainerStatsLayoutGroupPaddingRight = containerStats.GetComponent<HorizontalOrVerticalLayoutGroup>().padding.right;
				defaultContainerStatsLayoutGroupPaddingLeft = containerStats.GetComponent<HorizontalOrVerticalLayoutGroup>().padding.left;
			}
			base.Initialize();
		}

		protected override void AutoScaleRectTransform(float uiScaling, bool shouldRebuildLayoutGroupsAndCanvases = true)
		{
			base.AutoScaleRectTransform(uiScaling, shouldRebuildLayoutGroupsAndCanvases: false);
		}

		protected override void UpdateUi(UiScalingLevelData uiScalingLevel)
		{
			base.UpdateUi(uiScalingLevel);
			ScaleRowTitleSpacing(uiScalingLevel.scalingValue);
			AdjustUiIconToggleStatsPosition(uiScalingLevel.scalingValue);
		}

		private void AdjustUiIconToggleStatsPosition(float uiScaling)
		{
			UiScalingLevelId scalingLevel = uiScalingManager.GetScalingLevel(uiScaling);
			HorizontalOrVerticalLayoutGroup component = containerStats.GetComponent<HorizontalOrVerticalLayoutGroup>();
			switch (scalingLevel)
			{
			case UiScalingLevelId.Default:
				containerIcon.anchoredPosition = defaultContainerIconAnchoredPosition;
				component.padding.right = defaultContainerStatsLayoutGroupPaddingRight;
				component.padding.left = defaultContainerStatsLayoutGroupPaddingLeft;
				break;
			case UiScalingLevelId.Large:
				containerIcon.anchoredPosition = new Vector2(defaultContainerIconAnchoredPosition.x * 2f, 0f);
				if (uiStatsScreen.isLeftSided)
				{
					component.padding.left = defaultContainerStatsLayoutGroupPaddingLeft + (int)defaultContainerIconAnchoredPosition.x;
				}
				else
				{
					component.padding.right = defaultContainerStatsLayoutGroupPaddingRight + (int)defaultContainerIconAnchoredPosition.x;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void ScaleRowTitleSpacing(float uiScaling)
		{
			switch (uiScalingManager.GetScalingLevel(uiScaling))
			{
			case UiScalingLevelId.Default:
				rowTitleLayoutGroup.padding.right = defaultRowTitleLayoutGroupPaddingRight;
				rowTitleLayoutGroup.padding.left = defaultRowTitleLayoutGroupPaddingLeft;
				break;
			case UiScalingLevelId.Large:
				rowTitleLayoutGroup.padding.right = largeRowTitleLayoutGroupPaddingRight;
				rowTitleLayoutGroup.padding.left = largeRowTitleLayoutGroupPaddingLeft;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
