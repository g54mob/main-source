using System;
using Restory.Infrastructure.CommonServices;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_ControlsTypeEnabler : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private InputControlsType controlsTypes = InputControlsType.KeyboardAndMouse;

		private ControlsManager controlsManager;

		[Inject]
		private void Construct(DisposableManager disposableManager, ControlsManager controlsManager)
		{
			disposableManager.Add(this);
			this.controlsManager = controlsManager;
			this.controlsManager.OnControlsTypeChanged += ResolveOnControlsTypeChanged;
			if (base.isActiveAndEnabled)
			{
				ResolveOnControlsTypeChanged(this.controlsManager.ControlType);
			}
		}

		private void OnEnable()
		{
			if (controlsManager != null)
			{
				ResolveOnControlsTypeChanged(controlsManager.ControlType);
			}
		}

		public void Dispose()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged -= ResolveOnControlsTypeChanged;
			}
		}

		private void ResolveOnControlsTypeChanged(InputControlsType type)
		{
			if (target != null)
			{
				target.SetActive(type == controlsTypes);
			}
		}
	}
}
