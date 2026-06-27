using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment;
using Restory.UserInterface.CommonElements;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Presenters.CleaningToolsSelectionWindow
{
	public class GUI_CleaningToolsSelectionWindow : MonoBehaviour, IKeyDownHandler, IEventSystemHandler
	{
		private static readonly int[] CleaningToolsInputData = new int[10] { 57, 58, 59, 60, 61, 62, 63, 64, 65, 66 };

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_SlidingPanelTweener slidingPanelTweener;

		[SerializeField]
		private List<GUI_CleaningTool> cleaningTools = new List<GUI_CleaningTool>();

		[SerializeField]
		private ToolsCategory cleaningBrushToolCategory;

		private bool isShown;

		private CleaningToolSelectionService cleaningToolSelectionService;

		private AvailableToolsTrackingService availableToolsService;

		private GUI_RewiredPanelInputModule inputModule;

		public IReadOnlyList<GUI_CleaningTool> CleaningTools => cleaningTools;

		[Inject]
		private void Construct(CleaningToolSelectionService cleaningToolSelectionService, AvailableToolsTrackingService availableToolsService, GUI_RewiredPanelInputModule inputModule)
		{
			this.availableToolsService = availableToolsService;
			this.cleaningToolSelectionService = cleaningToolSelectionService;
			this.inputModule = inputModule;
			if (base.isActiveAndEnabled && isShown)
			{
				SubscribeServices();
			}
		}

		private void OnEnable()
		{
			if (isShown)
			{
				SubscribeServices();
				inputModule.AddSelectedPanel(base.gameObject);
			}
			slidingPanelTweener.OnTransitionComplete += ResolveOnTransitionComplete;
		}

		private void OnDisable()
		{
			UnsubscribeServices();
			inputModule.RemoveSelectedPanel(base.gameObject);
			slidingPanelTweener.OnTransitionComplete -= ResolveOnTransitionComplete;
		}

		private void SubscribeServices()
		{
			if (availableToolsService.MonoShellExists())
			{
				availableToolsService.OnToolsListChanged += ResolveAvailableToolsListChanged;
				ResolveAvailableToolsListChanged();
			}
			if (cleaningToolSelectionService.MonoShellExists())
			{
				cleaningToolSelectionService.OnToolSwitched += ResolveOnToolSwitched;
				ResolveOnToolSwitched();
			}
		}

		private void UnsubscribeServices()
		{
			if (availableToolsService.MonoShellExists())
			{
				availableToolsService.OnToolsListChanged -= ResolveAvailableToolsListChanged;
				ResolveAvailableToolsListChanged();
			}
			if (cleaningToolSelectionService.MonoShellExists())
			{
				cleaningToolSelectionService.OnToolSwitched -= ResolveOnToolSwitched;
				ResolveOnToolSwitched();
			}
		}

		public void Show()
		{
			if (!isShown)
			{
				isShown = true;
				if (base.isActiveAndEnabled)
				{
					SubscribeServices();
					inputModule.AddSelectedPanel(base.gameObject);
				}
				slidingPanelTweener.TransitionToState(SlidingPanelState.Open);
			}
		}

		public void Hide()
		{
			if (isShown)
			{
				isShown = false;
				UnsubscribeServices();
				inputModule.RemoveSelectedPanel(base.gameObject);
				canvasGroup.interactable = false;
				slidingPanelTweener.TransitionToState(SlidingPanelState.Hidden);
			}
		}

		private void ResolveAvailableToolsListChanged()
		{
			availableToolsService.TryGetBestToolInCategory(cleaningBrushToolCategory, out var bestTool);
			foreach (GUI_CleaningTool cleaningTool in cleaningTools)
			{
				if (cleaningTool.ToolInfo.ToolsCategory.ID == cleaningBrushToolCategory.ID)
				{
					cleaningTool.gameObject.SetActive((bool)bestTool && cleaningTool.ToolInfo.ID == bestTool.ID);
				}
				else
				{
					cleaningTool.gameObject.SetActive(availableToolsService.AvailableTools.Contains(cleaningTool.ToolInfo));
				}
			}
		}

		private void ResolveOnToolSwitched()
		{
			foreach (GUI_CleaningTool cleaningTool in cleaningTools)
			{
				cleaningTool.SetIsSelected(cleaningTool.ToolInfo == cleaningToolSelectionService.CurrentlySelectedTool);
			}
		}

		private void ResolveOnTransitionComplete()
		{
			SlidingPanelState state = slidingPanelTweener.State;
			if (state != SlidingPanelState.Hidden && (uint)(state - 2) <= 1u)
			{
				canvasGroup.interactable = true;
			}
		}

		public void OnKeyDown(KeyEventData eventData)
		{
			int num = CleaningToolsInputData.IndexOf(eventData.ActionId);
			if (num >= 0 && num < cleaningTools.Count)
			{
				GUI_CleaningTool gUI_CleaningTool = cleaningTools[num];
				if (gUI_CleaningTool.gameObject.activeSelf)
				{
					cleaningToolSelectionService.TryToSelectTool(gUI_CleaningTool.ToolInfo);
				}
			}
		}
	}
}
