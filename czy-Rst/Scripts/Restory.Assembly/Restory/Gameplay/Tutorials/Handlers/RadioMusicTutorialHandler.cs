using Restory.Data.Tutorials;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class RadioMusicTutorialHandler : TutorialHandlerBase
	{
		private DragObjectRegistrator dragObjectRegistrator;

		private InteractiveObject radioInteractiveObject;

		public RadioMusicTutorialHandler(DragObjectRegistrator dragObjectRegistrator, RadioMusicTutorial tutorial)
			: base(tutorial)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
		}

		public override void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartedDragging;
		}

		public override void Cleanup()
		{
			if (dragObjectRegistrator != null)
			{
				dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartedDragging;
			}
			if (radioInteractiveObject.MonoShellExists())
			{
				radioInteractiveObject.OnDragComplete -= ResolveInteractiveObjectSuccessfullyCompletedDragging;
			}
		}

		private void ResolveInteractiveObjectStartedDragging()
		{
			if (!base.IsCompleted && dragObjectRegistrator.DraggingObject.TryGetComponent<RadioFunctionalObject>(out var component) && component.TryGetComponent<InteractiveObject>(out radioInteractiveObject))
			{
				radioInteractiveObject.OnDragComplete += ResolveInteractiveObjectSuccessfullyCompletedDragging;
			}
		}

		private void ResolveInteractiveObjectSuccessfullyCompletedDragging()
		{
			radioInteractiveObject.OnDragComplete -= ResolveInteractiveObjectSuccessfullyCompletedDragging;
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartedDragging;
			if (!base.IsCompleted)
			{
				radioInteractiveObject.Activate();
				CompleteTutorial();
			}
		}
	}
}
