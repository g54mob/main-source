using Restory.Data.Identifications;
using Restory.UI.Presenters.Notepad;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using Zenject;

namespace Restory.EventSystems.ExitEvents
{
	public class GUI_NotepadExitEventHandler : MonoBehaviour, IExitEventHandler
	{
		[SerializeField]
		private GUI_NotepadWindow notepadWindow;

		[SerializeField]
		private UniqueIdentificator identificator;

		private ExitEventDispatcher dispatcher;

		private bool ignorePanelChangesWhileCloseExecution;

		public string ID => identificator.ID;

		[Inject]
		private void Construct(ExitEventDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
			if (notepadWindow.IsVisible && base.isActiveAndEnabled)
			{
				dispatcher.Register(this);
			}
		}

		private void OnEnable()
		{
			notepadWindow.OnIsVisibleChanged += ResolveNotepadVisibilityChanged;
			notepadWindow.OnSlidingStateChanged += ResolveNotepadSlidingStateChanged;
			if (notepadWindow.IsVisible && !notepadWindow.IsSlidingMode && (bool)dispatcher)
			{
				dispatcher.Register(this);
			}
		}

		private void OnDisable()
		{
			notepadWindow.OnIsVisibleChanged -= ResolveNotepadVisibilityChanged;
			notepadWindow.OnSlidingStateChanged -= ResolveNotepadSlidingStateChanged;
			if ((bool)dispatcher)
			{
				dispatcher.Unregister(this);
			}
		}

		public void ExecuteExit()
		{
			ignorePanelChangesWhileCloseExecution = true;
			notepadWindow.OnExitEvent();
			ignorePanelChangesWhileCloseExecution = false;
		}

		public void ConfirmExitExecution()
		{
			if (notepadWindow.IsVisible)
			{
				Debug.LogError("notepadWindow " + ID + " still visible");
				notepadWindow.OnExitEvent();
			}
		}

		private void ResolveNotepadVisibilityChanged()
		{
			if (ignorePanelChangesWhileCloseExecution)
			{
				if (notepadWindow.IsVisible)
				{
					Debug.LogError("Unexpected notepadWindow " + ID + " activation while should be closing");
				}
			}
			else if (notepadWindow.IsVisible && !notepadWindow.IsSlidingMode)
			{
				dispatcher.Register(this);
			}
			else
			{
				dispatcher.Unregister(this);
			}
		}

		private void ResolveNotepadSlidingStateChanged(SlidingPanelState _)
		{
			dispatcher.Unregister(this);
		}
	}
}
