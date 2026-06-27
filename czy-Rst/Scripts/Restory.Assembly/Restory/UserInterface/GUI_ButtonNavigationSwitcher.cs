using Restory.Infrastructure.CommonServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[RequireComponent(typeof(Selectable))]
	public class GUI_ButtonNavigationSwitcher : MonoBehaviour
	{
		private Selectable button;

		private Navigation navigationForKeyboardAndMouse;

		private ControlsManager controlsManager;

		[Inject]
		private void Construct(ControlsManager controlsManager)
		{
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				this.controlsManager.OnControlsTypeChanged += ResolveControlsTypeChanged;
			}
		}

		private void Awake()
		{
			button = GetComponent<Selectable>();
			navigationForKeyboardAndMouse.mode = Navigation.Mode.None;
		}

		private void OnEnable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged += ResolveControlsTypeChanged;
				SwitchButtonNavigation();
			}
		}

		private void OnDisable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged -= ResolveControlsTypeChanged;
			}
		}

		private void ResolveControlsTypeChanged(InputControlsType newControlsType)
		{
			SwitchButtonNavigation(newControlsType);
		}

		private void SwitchButtonNavigation()
		{
			SwitchButtonNavigation(controlsManager.ControlType);
		}

		private void SwitchButtonNavigation(InputControlsType newControlsType)
		{
			if (newControlsType == InputControlsType.KeyboardAndMouse && button != null)
			{
				button.navigation = navigationForKeyboardAndMouse;
			}
		}
	}
}
