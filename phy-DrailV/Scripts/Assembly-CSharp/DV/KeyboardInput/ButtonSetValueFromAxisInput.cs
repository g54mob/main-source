using DV.CabControls;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class ButtonSetValueFromAxisInput : AKeyboardInput
	{
		public ActionReference useAction;

		public bool useReturnToZero;

		private ButtonBase button;

		private bool buttonHeldByKeyboard;

		public override bool FixedUpdateTick => false;

		public void Start()
		{
			button = GetComponent<ButtonBase>();
			if (button == null)
			{
				Debug.LogError("ButtonUseKeyboardInput could not find ButtonBase.");
				Object.Destroy(this);
			}
			else if (button.IsHoldMode)
			{
				Debug.LogError("Do not use this with hold-type buttons!");
			}
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			useAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (!PlayerCanReach())
			{
				return;
			}
			if (button.IsOn)
			{
				if (!InputManager.NewPlayer.GetNegativeButtonDown(useAction.id) && (!useReturnToZero || !InputManager.NewPlayer.GetButtonUp(useAction.id)))
				{
					return;
				}
			}
			else if (!InputManager.NewPlayer.GetButtonDown(useAction.id))
			{
				return;
			}
			if (useAction.CanMoveOverridableBaseControl)
			{
				button.Use();
				RailDriverDisplayDV.DisplayNotification(button.IsOn ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
		}
	}
}
