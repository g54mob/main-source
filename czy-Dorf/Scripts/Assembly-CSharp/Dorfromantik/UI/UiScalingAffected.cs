using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiScalingAffected : MonoBehaviour
	{
		[SerializeField]
		private bool usesAutoScalingForRectTransform = true;

		[SerializeField]
		private RectTransform rectTransformToScale;

		[SerializeField]
		private bool shouldOnlyScaleX;

		[SerializeField]
		private bool shouldOnlyScaleY;

		[SerializeField]
		private bool shouldKeepDefaultAnchoredPosition = true;

		[SerializeField]
		protected bool usesAutoScalingForText;

		[SerializeField]
		private TextMeshProUGUI singleTextToUpdate;

		[SerializeField]
		protected bool shouldScaleMultipleTexts;

		[SerializeField]
		protected List<TextMeshProUGUI> textsToUpdate = new List<TextMeshProUGUI>();

		[SerializeField]
		private bool shouldUpdateAdditionalLayoutGroups;

		[SerializeField]
		private List<HorizontalOrVerticalLayoutGroup> additionalLayoutGroupsToUpdate;

		[SerializeField]
		private bool shouldUpdateParentHorizontalOrVerticalLayoutGroup = true;

		[SerializeField]
		private bool shouldUpdateLayoutElementMinHeight;

		[SerializeField]
		protected UiScalingManager uiScalingManager;

		[SerializeField]
		private bool isSubscribedToUiScalingManager;

		[SerializeField]
		protected bool isDefaultSize = true;

		[SerializeField]
		protected bool isInitialized;

		private Dictionary<TextMeshProUGUI, UiScalingAffectedTextMeshInfo> textMeshInfosByTextToUpdate = new Dictionary<TextMeshProUGUI, UiScalingAffectedTextMeshInfo>();

		private Vector2 defaultAnchoredPosition;

		private Vector2 defaultSizeDelta;

		private HorizontalOrVerticalLayoutGroup parentHorizontalOrVerticalLayoutGroup;

		protected virtual void OnValidate()
		{
			if (usesAutoScalingForText && !shouldScaleMultipleTexts)
			{
				if (singleTextToUpdate == null)
				{
					singleTextToUpdate = GetComponent<TextMeshProUGUI>();
				}
				if (shouldScaleMultipleTexts && !textsToUpdate.Contains(singleTextToUpdate))
				{
					textsToUpdate.Add(singleTextToUpdate);
				}
			}
			if (usesAutoScalingForRectTransform)
			{
				if (rectTransformToScale == null)
				{
					rectTransformToScale = GetComponent<RectTransform>();
				}
				if (shouldUpdateParentHorizontalOrVerticalLayoutGroup && parentHorizontalOrVerticalLayoutGroup == null)
				{
					parentHorizontalOrVerticalLayoutGroup = GetComponentInParent<HorizontalOrVerticalLayoutGroup>();
				}
			}
		}

		private void Start()
		{
			Initialize();
			if ((bool)uiScalingManager)
			{
				uiScalingManager.OnUiScalingLevelChanged += UpdateUi;
				isSubscribedToUiScalingManager = true;
			}
			else
			{
				Debug.LogError(uiScalingManager.name + " is not referenced!", base.gameObject);
			}
		}

		protected virtual void OnEnable()
		{
			Initialize();
			UpdateUi(uiScalingManager.CurrentUiScalingLevel);
		}

		private void OnDestroy()
		{
			if ((bool)uiScalingManager && isSubscribedToUiScalingManager)
			{
				uiScalingManager.OnUiScalingLevelChanged -= UpdateUi;
				isSubscribedToUiScalingManager = true;
			}
		}

		protected virtual void Initialize()
		{
			if (isInitialized)
			{
				return;
			}
			if (usesAutoScalingForRectTransform)
			{
				if (rectTransformToScale == null)
				{
					rectTransformToScale = GetComponent<RectTransform>();
				}
				defaultAnchoredPosition = rectTransformToScale.anchoredPosition;
				defaultSizeDelta = rectTransformToScale.sizeDelta;
				if (shouldUpdateLayoutElementMinHeight && (bool)rectTransformToScale.GetComponent<LayoutElement>())
				{
					defaultSizeDelta = new Vector2(rectTransformToScale.GetComponent<LayoutElement>().minWidth, rectTransformToScale.GetComponent<LayoutElement>().minHeight);
				}
			}
			if (usesAutoScalingForText)
			{
				if (!shouldScaleMultipleTexts)
				{
					if (singleTextToUpdate == null)
					{
						singleTextToUpdate = GetComponent<TextMeshProUGUI>();
					}
					if (!textsToUpdate.Contains(singleTextToUpdate))
					{
						textsToUpdate.Add(singleTextToUpdate);
					}
				}
				foreach (TextMeshProUGUI item in textsToUpdate)
				{
					textMeshInfosByTextToUpdate.Add(item, new UiScalingAffectedTextMeshInfo(item));
				}
			}
			isInitialized = true;
		}

		protected virtual void UpdateUi(UiScalingLevelData uiScalingLevel)
		{
			if (usesAutoScalingForText)
			{
				AutoScaleText(uiScalingLevel.scalingValue);
			}
			if (usesAutoScalingForRectTransform)
			{
				AutoScaleRectTransform(uiScalingLevel.scalingValue);
			}
		}

		private void AutoScaleText(float uiScaling)
		{
			ResetTextsToDefaultUiScaling(textsToUpdate);
			CheckIfUiScalingIsDefaultSize(uiScaling);
			if (!isDefaultSize)
			{
				foreach (TextMeshProUGUI item in textsToUpdate)
				{
					ScaleTextMesh(item, uiScaling);
				}
			}
			if (additionalLayoutGroupsToUpdate != null && additionalLayoutGroupsToUpdate.Count > 0)
			{
				RebuildLayoutGroupsAndCanvases();
			}
		}

		private void ScaleTextMesh(TextMeshProUGUI textMeshToScale, float uiScaling)
		{
			if (textMeshToScale.enableAutoSizing)
			{
				textMeshToScale.fontSizeMax *= uiScaling;
				textMeshToScale.fontSizeMin *= uiScaling;
			}
			textMeshToScale.fontSize *= uiScaling;
		}

		private void ResetTextsToDefaultUiScaling(List<TextMeshProUGUI> textMeshesToReset)
		{
			foreach (TextMeshProUGUI item in textMeshesToReset)
			{
				UiScalingAffectedTextMeshInfo uiScalingAffectedTextMeshInfo = textMeshInfosByTextToUpdate[item];
				if (item.enableAutoSizing)
				{
					item.fontSizeMin = uiScalingAffectedTextMeshInfo.defaultTextSizeMin;
					item.fontSizeMax = uiScalingAffectedTextMeshInfo.defaultTextSizeMax;
				}
				item.fontSize = uiScalingAffectedTextMeshInfo.defaultTextSize;
			}
		}

		protected virtual void AutoScaleRectTransform(float uiScaling, bool shouldRebuildLayoutGroupsAndCanvases = true)
		{
			ResetRectTransformToDefaultUiScaling();
			CheckIfUiScalingIsDefaultSize(uiScaling);
			if (!isDefaultSize)
			{
				if (shouldOnlyScaleX)
				{
					rectTransformToScale.sizeDelta = new Vector2(rectTransformToScale.sizeDelta.x * uiScaling, rectTransformToScale.sizeDelta.y);
				}
				else if (shouldOnlyScaleY)
				{
					rectTransformToScale.sizeDelta = new Vector2(rectTransformToScale.sizeDelta.x, rectTransformToScale.sizeDelta.y * uiScaling);
				}
				else
				{
					rectTransformToScale.sizeDelta *= uiScaling;
				}
				if (shouldUpdateLayoutElementMinHeight && (bool)rectTransformToScale.GetComponent<LayoutElement>())
				{
					rectTransformToScale.GetComponent<LayoutElement>().minHeight = defaultSizeDelta.y * uiScaling;
				}
			}
			if (shouldRebuildLayoutGroupsAndCanvases)
			{
				RebuildLayoutGroupsAndCanvases();
			}
		}

		protected void RebuildLayoutGroupsAndCanvases()
		{
			if (shouldUpdateParentHorizontalOrVerticalLayoutGroup && parentHorizontalOrVerticalLayoutGroup != null)
			{
				UiUtility.RebuildHorizontalOrVerticalLayoutGroup(parentHorizontalOrVerticalLayoutGroup);
			}
			if (shouldUpdateAdditionalLayoutGroups)
			{
				UiUtility.RebuildHorizontalOrVerticalLayoutGroups(additionalLayoutGroupsToUpdate);
			}
			UiUtility.RebuildCanvas();
		}

		protected virtual void ResetRectTransformToDefaultUiScaling()
		{
			rectTransformToScale.sizeDelta = defaultSizeDelta;
			if (shouldUpdateLayoutElementMinHeight && (bool)rectTransformToScale.GetComponent<LayoutElement>())
			{
				rectTransformToScale.GetComponent<LayoutElement>().minHeight = defaultSizeDelta.y;
			}
			if (shouldKeepDefaultAnchoredPosition)
			{
				rectTransformToScale.anchoredPosition = defaultAnchoredPosition;
			}
		}

		protected void CheckIfUiScalingIsDefaultSize(float uiScaling)
		{
			UiScalingLevelId scalingLevel = uiScalingManager.GetScalingLevel(uiScaling);
			isDefaultSize = scalingLevel == UiScalingLevelId.Default;
		}
	}
}
