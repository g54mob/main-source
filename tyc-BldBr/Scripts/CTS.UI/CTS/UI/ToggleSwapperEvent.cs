using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public abstract class ToggleSwapperEvent<T> : CTSBehaviour where T : UnityEngine.Object
	{
		[Serializable]
		protected struct Swapper
		{
			public T TargetGraphic;

			public SelectableSwapData<T> SwapOnData;

			public SelectableSwapData<T> SwapOffData;
		}

		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private List<Swapper> _swapList = new List<Swapper>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.SelectionStateChanged += OnSelectableStateChanged;
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
			OnSelectableStateChanged(_toggle.CurrentState);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.SelectionStateChanged -= OnSelectableStateChanged;
			_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}

		private void OnToggleValueChanged(bool arg0)
		{
			OnSelectableStateChanged(_toggle.CurrentState);
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
					if (_toggle.isOn)
					{
						swap.SwapOnData.ApplyTo(swap.TargetGraphic, selectionState);
					}
					else
					{
						swap.SwapOffData.ApplyTo(swap.TargetGraphic, selectionState);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
