using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiScalingAffectedTutorialTextBox : UiScalingAffected
	{
		[SerializeField]
		private int backgroundLeftOffsetForLargeUiSize = 16;

		[SerializeField]
		private GameObject spacerLeftSide;

		[SerializeField]
		private RectTransform textContainer;

		private HorizontalLayoutGroup horizontalLayoutGroup;

		private Vector2 defaultTextContainerAnchoredPosition;

		private Vector2 defaultTextContainerSizeDelta;

		private Vector3 defaultTextContainerLocalPosition;

		protected override void Initialize()
		{
			if (horizontalLayoutGroup == null)
			{
				horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
			}
			backgroundLeftOffsetForLargeUiSize = Math.Abs(backgroundLeftOffsetForLargeUiSize);
			defaultTextContainerAnchoredPosition = textContainer.anchoredPosition;
			defaultTextContainerSizeDelta = textContainer.sizeDelta;
			defaultTextContainerLocalPosition = textContainer.localPosition;
			base.Initialize();
		}

		protected override void AutoScaleRectTransform(float uiScaling, bool shouldRebuildLayoutGroupsAndCanvases = true)
		{
			base.AutoScaleRectTransform(uiScaling, shouldRebuildLayoutGroupsAndCanvases: false);
			if (uiScalingManager.GetScalingLevel(uiScaling) == UiScalingLevelId.Large)
			{
				spacerLeftSide.SetActive(value: false);
				horizontalLayoutGroup.padding.left = -backgroundLeftOffsetForLargeUiSize;
				textContainer.anchoredPosition = new Vector2((float)backgroundLeftOffsetForLargeUiSize / 2f, textContainer.anchoredPosition.y);
				textContainer.sizeDelta = new Vector2(textContainer.sizeDelta.x - (float)backgroundLeftOffsetForLargeUiSize, textContainer.sizeDelta.y);
				textContainer.localPosition = new Vector3((float)backgroundLeftOffsetForLargeUiSize / 2f, textContainer.localPosition.y, textContainer.localPosition.z);
			}
			else
			{
				spacerLeftSide.SetActive(value: true);
				horizontalLayoutGroup.padding.left = 0;
				textContainer.anchoredPosition = defaultTextContainerAnchoredPosition;
				textContainer.sizeDelta = defaultTextContainerSizeDelta;
				textContainer.localPosition = defaultTextContainerLocalPosition;
			}
			if (shouldRebuildLayoutGroupsAndCanvases)
			{
				RebuildLayoutGroupsAndCanvases();
			}
		}
	}
}
