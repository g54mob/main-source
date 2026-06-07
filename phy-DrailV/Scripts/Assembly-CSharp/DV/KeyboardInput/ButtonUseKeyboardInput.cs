using DV.CabControls;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class ButtonUseKeyboardInput : AKeyboardInput
	{
		public ActionReference useAction;

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
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			useAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (InputManager.NewPlayer.GetButtonDown(useAction.id) && PlayerCanReach())
			{
				button.Use();
				if (button.IsHoldMode)
				{
					buttonHeldByKeyboard = true;
				}
				RailDriverDisplayDV.DisplayNotification(button.IsOn ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
			else if (!(button == null) && button.IsHoldMode && button.IsOn && buttonHeldByKeyboard && (InputManager.NewPlayer.GetButtonUp(useAction.id) || !PlayerCanReach()))
			{
				button.Use();
				buttonHeldByKeyboard = false;
				RailDriverDisplayDV.DisplayNotification(button.IsOn ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
		}
	}
}
