using Restory.Data.Equipment;
using Restory.Gameplay.Equipment;
using Restory.UserInterface.CommonElements;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.CleaningToolsSelectionWindow
{
	public class GUI_CleaningTool : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Button selectToolButton;

		[SerializeField]
		private ElementCleanerToolInfoBase toolInfo;

		[SerializeField]
		private GUI_SlidingPanelTweener slidingPanelTweener;

		[SerializeField]
		private GUI_CleaningToolCountAndCurrentUsesLeft toolCountAndUsesLeft;

		private bool isSelected;

		private bool isPointerEnter;

		private CleaningToolSelectionService cleaningToolSelectionService;

		public GUI_CleaningToolCountAndCurrentUsesLeft ToolCountAndUsesLeft => toolCountAndUsesLeft;

		public ElementCleanerToolInfoBase ToolInfo => toolInfo;

		[Inject]
		private void Construct(CleaningToolSelectionService cleaningToolSelectionService)
		{
			this.cleaningToolSelectionService = cleaningToolSelectionService;
		}

		private void Awake()
		{
			toolCountAndUsesLeft.Hide();
		}

		private void OnEnable()
		{
			selectToolButton.onClick.AddListener(ResolveSelectToolButtonClicked);
		}

		private void OnDisable()
		{
			if (selectToolButton.MonoShellExists())
			{
				selectToolButton.onClick.RemoveListener(ResolveSelectToolButtonClicked);
			}
		}

		public void SetIsSelected(bool isSelected, bool instanly = false)
		{
			if (this.isSelected != isSelected)
			{
				this.isSelected = isSelected;
				UpdateTweener(instanly);
				if (isSelected)
				{
					toolCountAndUsesLeft.SetToolInfo(toolInfo);
					toolCountAndUsesLeft.Show();
				}
				else
				{
					toolCountAndUsesLeft.Hide();
				}
			}
		}

		private void UpdateTweener(bool instanly)
		{
			SlidingPanelState state = (isSelected ? SlidingPanelState.Open : ((!isPointerEnter) ? SlidingPanelState.Hidden : SlidingPanelState.Peeking));
			if (instanly)
			{
				slidingPanelTweener.SetState(state);
			}
			else
			{
				slidingPanelTweener.TransitionToState(state);
			}
		}

		public void Clear()
		{
			toolInfo = null;
		}

		private void ResolveSelectToolButtonClicked()
		{
			if (toolInfo != null)
			{
				cleaningToolSelectionService.TryToSelectTool(toolInfo);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isPointerEnter = true;
			UpdateTweener(instanly: false);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerEnter = false;
			UpdateTweener(instanly: false);
		}
	}
}
