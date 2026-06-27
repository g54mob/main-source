using Restory.Data.Identifications;
using UnityEngine;
using Zenject;

namespace Restory.EventSystems.ExitEvents
{
	public class GUI_ExitEventHandler : MonoBehaviour, IExitEventHandler
	{
		[SerializeField]
		[HideInInspector]
		private MonoBehaviour exitablePanelComponent;

		[SerializeField]
		private UniqueIdentificator identificator;

		private ExitEventDispatcher dispatcher;

		private bool ignorePanelChangesWhileCloseExecution;

		public string ID => identificator.ID;

		public IExitablePanel ExitablePanel
		{
			get
			{
				return exitablePanelComponent as IExitablePanel;
			}
			set
			{
				exitablePanelComponent = value as MonoBehaviour;
			}
		}

		[Inject]
		private void Construct(ExitEventDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
			if (ExitablePanel.IsVisible && base.isActiveAndEnabled)
			{
				dispatcher.Register(this);
			}
		}

		private void OnEnable()
		{
			ExitablePanel.OnIsVisibleChanged += ResolvePanelVisibilityChanged;
			if (ExitablePanel.IsVisible && (bool)dispatcher)
			{
				dispatcher.Register(this);
			}
		}

		private void OnDisable()
		{
			ExitablePanel.OnIsVisibleChanged -= ResolvePanelVisibilityChanged;
			if (!ExitablePanel.IsVisible && (bool)dispatcher)
			{
				dispatcher.Unregister(this);
			}
		}

		public void ExecuteExit()
		{
			ignorePanelChangesWhileCloseExecution = true;
			ExitablePanel.OnExitEvent();
			ignorePanelChangesWhileCloseExecution = false;
		}

		public void ConfirmExitExecution()
		{
			if (ExitablePanel.IsVisible)
			{
				Debug.LogError("ExitablePanel " + ID + " still visible");
				ExitablePanel.OnExitEvent();
			}
		}

		private void ResolvePanelVisibilityChanged()
		{
			if (ignorePanelChangesWhileCloseExecution)
			{
				if (ExitablePanel.IsVisible)
				{
					Debug.LogError("Unexpected ExitablePanel " + ID + " activation while should be closing");
				}
			}
			else if (ExitablePanel.IsVisible)
			{
				dispatcher.Register(this);
			}
			else
			{
				dispatcher.Unregister(this);
			}
		}
	}
}
