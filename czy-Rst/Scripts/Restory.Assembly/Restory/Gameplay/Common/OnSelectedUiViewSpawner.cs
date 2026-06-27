using System.Collections;
using Restory.Infrastructure.CommonServices;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.Gameplay.Common
{
	public class OnSelectedUiViewSpawner : UiViewSpawnerBase, ISelectHandler, IEventSystemHandler, IDeselectHandler, IActiveStateSwitchable
	{
		[SerializeField]
		private float displayDelay;

		private bool isSelected;

		private bool isActive = true;

		private ControlsManager controlsManager;

		private bool subscribeOnControlsTypeChanged;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (isActive != value)
				{
					isActive = value;
					UpdateViews();
				}
			}
		}

		public bool IsSelected => isSelected;

		private bool IsJoystickActive
		{
			get
			{
				if (controlsManager != null)
				{
					return controlsManager.ControlType == InputControlsType.Joystick;
				}
				return false;
			}
		}

		[Inject]
		private void Construct(ControlsManager controlsManager)
		{
			this.controlsManager = controlsManager;
			SubscribeOnControlsTypeChanged();
		}

		private void OnEnable()
		{
			SubscribeOnControlsTypeChanged();
		}

		private void OnControlsTypeChanged(InputControlsType controlsType)
		{
			if (controlsType == InputControlsType.KeyboardAndMouse)
			{
				DisposeViews();
			}
		}

		private void OnDisable()
		{
			Dispose(views);
			UnsubscribeOnControlsTypeChanged();
		}

		public void UpdateViews()
		{
			if (isActive && isSelected)
			{
				InstantiateViews();
			}
			else
			{
				DisposeViews();
			}
		}

		public void InstantiateViews(bool instantly = false)
		{
			if (instantly || displayDelay <= 0f)
			{
				InstantiateViewsInstantly();
			}
			else
			{
				InstantiateViewsDelay();
			}
		}

		public void InstantiateViewsDelay()
		{
			StartCoroutine(InstantiateViewsDelayCoroutine());
			IEnumerator InstantiateViewsDelayCoroutine()
			{
				yield return new WaitForSecondsRealtime(displayDelay);
				if (isSelected)
				{
					InstantiateViewsInstantly();
				}
			}
		}

		public void InstantiateViewsInstantly()
		{
			Instantiate(views);
		}

		public void DisposeViews()
		{
			Dispose(views);
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (IsJoystickActive)
			{
				isSelected = true;
				UpdateViews();
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (IsJoystickActive)
			{
				isSelected = false;
				DisposeViews();
			}
		}

		private void SubscribeOnControlsTypeChanged()
		{
			if (!subscribeOnControlsTypeChanged && !(controlsManager == null))
			{
				subscribeOnControlsTypeChanged = true;
				controlsManager.OnControlsTypeChanged += OnControlsTypeChanged;
			}
		}

		private void UnsubscribeOnControlsTypeChanged()
		{
			if (subscribeOnControlsTypeChanged && !(controlsManager == null))
			{
				subscribeOnControlsTypeChanged = false;
				controlsManager.OnControlsTypeChanged -= OnControlsTypeChanged;
			}
		}
	}
}
