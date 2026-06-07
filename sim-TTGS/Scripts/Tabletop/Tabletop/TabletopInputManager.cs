using Simulator;
using Simulator.GameWorld;
using Tabletop.GameWorld;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Tabletop
{
	public class TabletopInputManager : InputManager
	{
		protected override void OnRegisterPlayerActions()
		{
			base.OnRegisterPlayerActions();
			m_playerMap.FindAction("Collection").performed += OnPlayerInput_Collection;
		}

		protected override void OnUnregisterPlayerActions()
		{
			base.OnUnregisterPlayerActions();
			m_playerMap.FindAction("Collection").performed -= OnPlayerInput_Collection;
		}

		private void OnPlayerInput_Collection(InputAction.CallbackContext context)
		{
			if (IPlayerInputReceiver.HasCurrent(out var receiver) && receiver is ITabletopPlayerInputReceiver tabletopPlayerInputReceiver)
			{
				tabletopPlayerInputReceiver.OnPlayerInput_Collection();
			}
		}

		protected override void OnRegisterUIActions()
		{
			base.OnRegisterUIActions();
			m_uiMap.FindAction("CloseCollection").performed += OnUIInput_CloseCollection;
		}

		protected override void OnUnregisterUIActions()
		{
			base.OnUnregisterUIActions();
			m_uiMap.FindAction("CloseCollection").performed -= OnUIInput_CloseCollection;
		}

		private void OnUIInput_CloseCollection(InputAction.CallbackContext context)
		{
			if (World.Loaded && TabletopWorld.TabletopHUDPopup.IsActive && TabletopWorld.TabletopHUDPopup.CurrentTabletopModule == ETabletopHUDPopupModuleType.COLLECTION && Collection.Mode != ECollectionMode.SQUAD_EDITION && !InputManager.InputFieldFocused && !(context.control is ButtonControl { wasPressedThisFrame: false }))
			{
				TabletopWorld.TabletopHUDPopup.OnCancel();
			}
		}
	}
}
