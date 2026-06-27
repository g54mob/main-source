using Restory.Data.Equipment;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.CleaningToolsSelectionWindow
{
	public class GUI_CleaningToolCountAndCurrentUsesLeft : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[Space]
		[SerializeField]
		private GameObject countContainer;

		[SerializeField]
		private TextMeshProUGUI countText;

		[SerializeField]
		private Image countIcon;

		[Space]
		[SerializeField]
		private GameObject currentUsesLeftFillContainer;

		[SerializeField]
		private Image currentUsesLeftFillImage;

		[Space]
		[SerializeField]
		private GUI_CleaningToolCountAndCurrentUsesLeftErrorAnimator errorAnimator;

		private ToolInfo toolInfo;

		private AvailableToolsTrackingService availableToolsService;

		[Inject]
		private void Construct(AvailableToolsTrackingService availableToolsService)
		{
			this.availableToolsService = availableToolsService;
		}

		private void OnEnable()
		{
			if (availableToolsService.MonoShellExists())
			{
				availableToolsService.OnToolResourceChanged += ResolveOnToolResourceChanged;
			}
		}

		private void OnDisable()
		{
			if (availableToolsService.MonoShellExists())
			{
				availableToolsService.OnToolResourceChanged -= ResolveOnToolResourceChanged;
			}
		}

		public void SetToolInfo(ToolInfo toolInfo)
		{
			this.toolInfo = toolInfo;
			ResolveOnToolResourceChanged(toolInfo);
		}

		public void Show()
		{
			canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.blocksRaycasts = false;
		}

		public void PlayError()
		{
			Debug.Log("Play error animation");
			errorAnimator.PlayError();
		}

		private void ResolveOnToolResourceChanged(ToolInfo info)
		{
			if (!(info != toolInfo))
			{
				int toolCount = availableToolsService.GetToolCount(toolInfo);
				if (toolCount > 1)
				{
					countContainer.SetActive(value: true);
					countText.text = toolCount.ToString();
					countIcon.sprite = toolInfo.Icon;
				}
				else
				{
					countContainer.SetActive(value: false);
				}
				if (toolInfo.IsConsumable && toolInfo.MaxUses > 0f)
				{
					currentUsesLeftFillContainer.SetActive(value: true);
					float toolCurrentUsesLeft = availableToolsService.GetToolCurrentUsesLeft(toolInfo);
					currentUsesLeftFillImage.fillAmount = toolCurrentUsesLeft / toolInfo.MaxUses;
				}
				else
				{
					currentUsesLeftFillContainer.SetActive(value: false);
				}
			}
		}
	}
}
