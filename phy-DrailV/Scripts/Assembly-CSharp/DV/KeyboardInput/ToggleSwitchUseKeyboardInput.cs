using DV.CabControls;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class ToggleSwitchUseKeyboardInput : AKeyboardInput
	{
		public ActionReference useAction;

		private ToggleSwitchBase toggleSwitch;

		public override bool FixedUpdateTick => false;

		public void Start()
		{
			toggleSwitch = GetComponent<ToggleSwitchBase>();
			if (toggleSwitch == null)
			{
				Debug.LogError("ToggleSwitchUseKeyboardInput could not find ToggleSwitchBase.");
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
				toggleSwitch.Use();
				RailDriverDisplayDV.DisplayNotification(toggleSwitch.IsOn ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
		}
	}
}
