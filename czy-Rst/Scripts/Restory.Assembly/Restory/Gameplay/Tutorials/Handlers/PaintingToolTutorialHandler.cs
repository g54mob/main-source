using Restory.Data.Tutorials;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Work.StateMachine;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class PaintingToolTutorialHandler : TutorialHandlerBase
	{
		private readonly WorkStateMachine workStateMachine;

		private readonly PaintingToolWorkplaceItem paintingTool;

		public PaintingToolTutorialHandler(WorkStateMachine workStateMachine, PaintingToolWorkplaceItem paintingTool, PaintingToolTutorial tutorial)
			: base(tutorial)
		{
			this.workStateMachine = workStateMachine;
			this.paintingTool = paintingTool;
		}

		public override void Init()
		{
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			paintingTool.Trigger.OnClick += ResolvePaintingToolTriggerClick;
		}

		public override void Cleanup()
		{
			workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			paintingTool.Trigger.OnClick -= ResolvePaintingToolTriggerClick;
		}

		private void ResolveWorkStateChanged()
		{
			if (!base.IsCompleted && paintingTool.IsAvailable && workStateMachine.ActiveState is DetectionWorkState)
			{
				paintingTool.ToggleIndicator(isActive: true);
			}
		}

		private void ResolvePaintingToolTriggerClick()
		{
			if (!base.IsCompleted)
			{
				paintingTool.ToggleIndicator(isActive: false);
				CompleteTutorial();
			}
		}
	}
}
