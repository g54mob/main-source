using System;
using UnityEngine;

namespace CTS.Core
{
	public class SelectableObject : CTSBehaviour, ILockable
	{
		[SerializeField]
		private SelectionModes _selectionModes;

		[field: SerializeField]
		public Component SelectionTarget { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool Selectable { get; private set; } = true;

		public event Action<bool> SelectabilityChanged;

		public event Action<SelectionMode> HoverEnter;

		public event Action<SelectionMode> HoverExit;

		public event Action<SelectionMode> Selected;

		public event Action<SelectionMode> Deselected;

		protected override void OnDisabled()
		{
			base.OnDisabled();
			WorldSelector.Deselect(this);
		}

		public bool IsSelected()
		{
			return WorldSelector.IsObjectSelected(this);
		}

		public void SetSelectionTarget(Component component)
		{
			if (!(component == SelectionTarget))
			{
				bool num = IsSelected();
				if (num && (bool)SelectionTarget)
				{
					WorldSelector.Deselect(this);
				}
				SelectionTarget = component;
				if (num)
				{
					WorldSelector.SelectObject(this);
				}
			}
		}

		public bool CanBeSelectedByMode(SelectionMode mode)
		{
			if (_selectionModes == null)
			{
				return false;
			}
			return _selectionModes.CanBeSelectedBy(mode);
		}

		internal void EnterHover(SelectionMode selectionMode)
		{
			try
			{
				this.HoverEnter?.Invoke(selectionMode);
				OnEnterHover(selectionMode);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnEnterHover(SelectionMode selectionMode)
		{
		}

		internal void ExitHover(SelectionMode selectionMode)
		{
			try
			{
				this.HoverExit?.Invoke(selectionMode);
				OnExitHover(selectionMode);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnExitHover(SelectionMode selectionMode)
		{
		}

		internal void Select(SelectionMode selectionMode)
		{
			try
			{
				this.Selected?.Invoke(selectionMode);
				OnSelected(selectionMode);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnSelected(SelectionMode selectionMode)
		{
		}

		internal void Deselect(SelectionMode selectionMode)
		{
			try
			{
				this.Deselected?.Invoke(selectionMode);
				OnDeselected(selectionMode);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnDeselected(SelectionMode selectionMode)
		{
		}

		void ILockable.OnLocked()
		{
			Selectable = false;
			this.SelectabilityChanged?.Invoke(obj: false);
			WorldSelector.Deselect(this);
		}

		void ILockable.OnUnlocked()
		{
			Selectable = true;
			this.SelectabilityChanged?.Invoke(obj: true);
		}
	}
}
