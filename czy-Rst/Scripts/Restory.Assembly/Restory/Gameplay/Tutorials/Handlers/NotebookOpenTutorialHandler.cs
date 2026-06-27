using Restory.Data.Tutorials;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.UI.Presenters.Notepad;
using Restory.UserInterface.CommonElements;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class NotebookOpenTutorialHandler : TutorialHandlerBase
	{
		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly GUI_NotepadWindow notepadWindow;

		private readonly GUI_NotepadWindowPreviewer notepadWindowPreviewer;

		private bool isNotepadVisible;

		[Inject]
		public NotebookOpenTutorialHandler(DisassembleStateMachine disassembleStateMachine, GUI_NotepadWindow notepadWindow, GUI_NotepadWindowPreviewer notepadWindowPreviewer, NotebookOpenTutorial tutorial)
			: base(tutorial)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.notepadWindow = notepadWindow;
			this.notepadWindowPreviewer = notepadWindowPreviewer;
		}

		public override void Init()
		{
			notepadWindow.OnIsVisibleChanged += ResolveIsVisibleChanged;
			notepadWindow.OnSlidingStateChanged += ResolveSlidingStateChanged;
		}

		public override void Cleanup()
		{
			notepadWindow.OnIsVisibleChanged -= ResolveIsVisibleChanged;
			notepadWindow.OnSlidingStateChanged -= ResolveSlidingStateChanged;
		}

		private void ResolveIsVisibleChanged()
		{
			if (!base.IsCompleted)
			{
				isNotepadVisible = notepadWindow.IsVisible;
			}
		}

		private void ResolveSlidingStateChanged(SlidingPanelState state)
		{
			if (!base.IsCompleted && disassembleStateMachine.ActiveState is DetectionDisassembleState)
			{
				if (state == SlidingPanelState.Peeking && !isNotepadVisible)
				{
					notepadWindowPreviewer.PreviewNotepad();
				}
				Complete();
			}
		}

		private void Complete()
		{
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}
	}
}
