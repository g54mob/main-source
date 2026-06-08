using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiScalingAffectedRewardProgressBubble : UiScalingAffected
	{
		[SerializeField]
		private RectTransform displayMaskRectTransform;

		[SerializeField]
		private RectTransform iconCircle;

		private Vector2 defaultDisplayMaskRectTransformSizeDelta;

		private Vector2 defaultIconCircleSizeDelta;

		protected override void OnValidate()
		{
			if (usesAutoScalingForText)
			{
				usesAutoScalingForText = false;
			}
			base.OnValidate();
		}

		protected override void Initialize()
		{
			defaultIconCircleSizeDelta = iconCircle.sizeDelta;
			defaultDisplayMaskRectTransformSizeDelta = displayMaskRectTransform.sizeDelta;
			base.Initialize();
		}

		protected override void AutoScaleRectTransform(float uiScaling, bool shouldRebuildLayoutGroupsAndCanvases = true)
		{
			base.AutoScaleRectTransform(uiScaling, shouldRebuildLayoutGroupsAndCanvases: false);
			if (!isDefaultSize)
			{
				displayMaskRectTransform.sizeDelta *= uiScaling;
				iconCircle.sizeDelta = new Vector2(iconCircle.sizeDelta.x, iconCircle.sizeDelta.y * uiScaling);
			}
			if (shouldRebuildLayoutGroupsAndCanvases)
			{
				RebuildLayoutGroupsAndCanvases();
			}
		}

		protected override void ResetRectTransformToDefaultUiScaling()
		{
			displayMaskRectTransform.sizeDelta = defaultDisplayMaskRectTransformSizeDelta;
			iconCircle.sizeDelta = defaultIconCircleSizeDelta;
			base.ResetRectTransformToDefaultUiScaling();
		}
	}
}
