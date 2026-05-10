using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public abstract class SelectableSwapperEvent<T> : CTSBehaviour where T : UnityEngine.Object
	{
		[Serializable]
		protected struct Swapper
		{
			public T TargetGraphic;

			public SelectableSwapData<T> SwapData;
		}

		[Inject(false)]
		private ISelectable _selectable;

		[SerializeField]
		private List<Swapper> _swapList = new List<Swapper>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_selectable.SelectionStateChanged += OnSelectableStateChanged;
			OnSelectableStateChanged(_selectable.CurrentState);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_selectable.SelectionStateChanged -= OnSelectableStateChanged;
		}

		protected virtual void OnSelectableStateChanged(ESelectionState selectionState)
		{
			Swap(_swapList, selectionState);
		}

		protected void Swap(List<Swapper> swapList, ESelectionState selectionState)
		{
			foreach (Swapper swap in swapList)
			{
				try
				{
					swap.SwapData.ApplyTo(swap.TargetGraphic, selectionState);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
