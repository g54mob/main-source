using System;
using PixelCrushers.DialogueSystem;
using Restory.Gameplay.Common;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Work.StateMachine;
using Restory.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.DemoEnd
{
	public class DemoEndWindowSwitcher : MonoBehaviour, IActiveStateSwitchRequester
	{
		[SerializeField]
		private GUI_DemoEndWindow demoEndWindowPrefab;

		private DialogueSystemController dialogueSystemController;

		private Transform gameCanvas;

		private TimeSystem timeSystem;

		private WorkStateMachine workStateMachine;

		private DiContainer container;

		private GUI_DemoEndWindow demoEndWindowInstance;

		[Inject]
		public void Construct(DialogueSystemController dialogueSystemController, [Inject(Id = "GameplayOverlayCanvas")] Transform gameCanvas, TimeSystem timeSystem, WorkStateMachine workStateMachine, DiContainer container)
		{
			this.container = container;
			this.dialogueSystemController = dialogueSystemController;
			this.gameCanvas = gameCanvas;
			this.timeSystem = timeSystem;
			this.workStateMachine = workStateMachine;
		}

		public void PrepareToShowGameEndWindowAfterConversationEnds()
		{
			timeSystem.BlockTimeSystem(this);
			dialogueSystemController.conversationEnded += ResolveConversationEndedWhenPrepared;
		}

		private void ResolveConversationEndedWhenPrepared(Transform t)
		{
			dialogueSystemController.conversationEnded -= ResolveConversationEndedWhenPrepared;
			ShowDemoEndWindow(CloseDemoEndWindow);
		}

		private void ShowDemoEndWindow(Action onCloseWindowButtonClickedCallback)
		{
			if (!(workStateMachine.ActiveState is DisabledWorkState))
			{
				workStateMachine.Enter<DisabledWorkState>();
			}
			demoEndWindowInstance = container.InstantiatePrefabForComponent<GUI_DemoEndWindow>(demoEndWindowPrefab, gameCanvas);
			demoEndWindowInstance.SetUp(onCloseWindowButtonClickedCallback);
		}

		private void CloseDemoEndWindow()
		{
			UnityEngine.Object.Destroy(demoEndWindowInstance.gameObject);
			timeSystem.StopBlockingTimeSystem(this);
			workStateMachine.Enter<DetectionWorkState>();
		}
	}
}
