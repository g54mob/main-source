using System;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class DataViewButtons : MonoBehaviour, IOnHubTabClose, IOnHubTabOpen
	{
		[Serializable]
		private struct DataViewButton
		{
			public DynamicButton Button;

			public DataViewManager.Mode Mode;
		}

		[SerializeField]
		private DataViewButton[] _attractivenessButton;

		private DataViewManager _dataViewManager;

		public void Setup(DataViewManager dataViewManager)
		{
			_dataViewManager = dataViewManager;
			DataViewManager dataViewManager2 = _dataViewManager;
			dataViewManager2.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Combine(dataViewManager2.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterDataViewMode));
			DataViewManager dataViewManager3 = _dataViewManager;
			dataViewManager3.OnOverlayDisabled = (Action)Delegate.Combine(dataViewManager3.OnOverlayDisabled, new Action(OnOverlayDisabled));
			for (int i = 0; i < _attractivenessButton.Length; i++)
			{
				DataViewManager.Mode mode = _attractivenessButton[i].Mode;
				_attractivenessButton[i].Button.onPrimaryDown.AddListener(delegate
				{
					_dataViewManager.ToggleMode(mode, setByPlayer: true);
				});
			}
			TooltipSpawner[] componentsInChildren = GetComponentsInChildren<TooltipSpawner>();
			for (int num = 0; num < componentsInChildren.Length; num++)
			{
				componentsInChildren[num].enabled = false;
			}
		}

		private void OnOverlayDisabled()
		{
			for (int i = 0; i < _attractivenessButton.Length; i++)
			{
				ButtonAnimator component = _attractivenessButton[i].Button.GetComponent<ButtonAnimator>();
				if (!(component == null) && component.CurrentState != ButtonAnimator.State.Unselectable)
				{
					component.CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		private void OnEnterDataViewMode(DataViewManager.Mode mode)
		{
			for (int i = 0; i < _attractivenessButton.Length; i++)
			{
				ButtonAnimator component = _attractivenessButton[i].Button.GetComponent<ButtonAnimator>();
				if (!(component == null) && component.CurrentState != ButtonAnimator.State.Unselectable)
				{
					if (_attractivenessButton[i].Mode == mode)
					{
						component.CurrentState = ButtonAnimator.State.Selected;
					}
					else
					{
						component.CurrentState = ButtonAnimator.State.Selectable;
					}
				}
			}
		}

		void IOnHubTabClose.OnHubTabClose()
		{
			_dataViewManager.DisableOverlay(setByPlayer: true);
			TooltipSpawner[] componentsInChildren = GetComponentsInChildren<TooltipSpawner>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}

		void IOnHubTabOpen.OnHubTabOpen()
		{
			if (!_dataViewManager.ModeSetByPlayer)
			{
				_dataViewManager.DisableOverlay(setByPlayer: true);
			}
			TooltipSpawner[] componentsInChildren = GetComponentsInChildren<TooltipSpawner>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = true;
			}
		}

		protected void OnDestroy()
		{
			if (_dataViewManager != null)
			{
				DataViewManager dataViewManager = _dataViewManager;
				dataViewManager.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Remove(dataViewManager.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterDataViewMode));
				DataViewManager dataViewManager2 = _dataViewManager;
				dataViewManager2.OnOverlayDisabled = (Action)Delegate.Remove(dataViewManager2.OnOverlayDisabled, new Action(OnOverlayDisabled));
			}
		}
	}
}
