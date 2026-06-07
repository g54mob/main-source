using DV.CabControls;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class ToggleValueKeyboardInput : AKeyboardInput
	{
		public ActionReference useAction;

		public override bool FixedUpdateTick => false;

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			useAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (InputManager.NewPlayer.GetButtonDown(useAction.id) && PlayerCanReach())
			{
				ControlImplBase component = GetComponent<ControlImplBase>();
				component?.SetValue(1f - Mathf.Round(component.Value));
				RailDriverDisplayDV.DisplayNotification((component.Value > 0.5f) ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
		}
	}
}
