using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.UI;
using NSMedieval.View;

namespace NSMedieval
{
	public class SelectableObjectController : MonoSingleton<SelectableObjectController>, IObserver
	{
		private readonly List<SelectableObject> deselectedObjectsList = new List<SelectableObject>();

		private bool isShuttingDown;

		public event Action<SelectableObject> OnRegisteredEvent;

		public event Action<SelectableObject> OnRemovedEvent;

		public event Action<SelectableObject> OnSelectedEvent;

		public event Action<SelectableObject> OnMultiSelectedEvent;

		public event Action<SelectableObject> OnDeSelectedEvent;

		public event Action<List<SelectableObject>> ObjectsDeselectedEvent;

		public event Action DataUpdatedEvent;

		public event Action DeselectAllEvent;

		public event Action OnSelectNothingClickEvent;

		public event Action<SelectableObject> OnHoverEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnHoverEvent = null;
			this.OnRegisteredEvent = null;
			this.OnRemovedEvent = null;
			this.OnSelectedEvent = null;
			this.OnMultiSelectedEvent = null;
			this.OnDeSelectedEvent = null;
			this.DataUpdatedEvent = null;
			this.DeselectAllEvent = null;
			this.OnSelectNothingClickEvent = null;
		}

		public void OnRegistered(SelectableObject selectableObject)
		{
			if (!isShuttingDown)
			{
				this.OnRegisteredEvent?.Invoke(selectableObject);
			}
		}

		public void OnRemoved(SelectableObject selectableObject)
		{
			if (!isShuttingDown)
			{
				this.OnRemovedEvent?.Invoke(selectableObject);
			}
		}

		public void OnSelectNothingClick()
		{
			this.OnSelectNothingClickEvent?.Invoke();
		}

		public void OnDataUpdated()
		{
			this.DataUpdatedEvent?.Invoke();
		}

		internal void OnHovered(SelectableObject selectableObject)
		{
			if (!isShuttingDown)
			{
				this.OnHoverEvent?.Invoke(selectableObject);
			}
		}

		internal void OnSelected(SelectableObject selectableObject)
		{
			if (!isShuttingDown && !MonoSingleton<UIController>.Instance.HideUI)
			{
				MonoSingleton<SelectableObjectManager>.Instance.OnSelectedEvent(selectableObject);
				this.OnSelectedEvent?.Invoke(selectableObject);
				if (VisualDebugManager.IsEnabled)
				{
					selectableObject.GetAsWorldObject()?.ShowVisualDebuggingAid();
				}
			}
		}

		internal void OnMultiSelected(SelectableObject selectableObject)
		{
			if (!isShuttingDown && !MonoSingleton<UIController>.Instance.HideUI)
			{
				MonoSingleton<SelectableObjectManager>.Instance.OnSelectedEvent(selectableObject);
				this.OnMultiSelectedEvent?.Invoke(selectableObject);
				if (VisualDebugManager.IsEnabled)
				{
					selectableObject.GetAsWorldObject()?.ShowVisualDebuggingAid();
				}
			}
		}

		internal void OnDeselectAll()
		{
			MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
			this.DeselectAllEvent?.Invoke();
		}

		internal void OnDeselected(SelectableObject selectableObject)
		{
			if (!isShuttingDown && selectableObject.Selected)
			{
				MonoSingleton<SelectableObjectManager>.Instance.OnDeSelectedEvent(selectableObject);
				deselectedObjectsList.Add(selectableObject);
				this.OnDeSelectedEvent?.Invoke(selectableObject);
				selectableObject.GetAsWorldObject()?.HideVisualDebuggingAid();
				MonoSingleton<TaskController>.Instance.OptimizedCall(this, "OnDeselected", delegate
				{
					this.ObjectsDeselectedEvent?.Invoke(deselectedObjectsList);
					deselectedObjectsList?.Clear();
				});
			}
		}

		protected override void OnApplicationQuit()
		{
			base.OnApplicationQuit();
			isShuttingDown = true;
		}
	}
}
