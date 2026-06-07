using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class PhysicsForceKeyboardInput : AKeyboardInput
	{
		public Vector3 forceVector;

		public ActionReference applyAction;

		public override bool FixedUpdateTick => true;

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			applyAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (InputManager.NewPlayer.GetAnyDirButton(applyAction.id) && PlayerCanReach())
			{
				float axis = InputManager.NewPlayer.GetAxis(applyAction.id);
				Apply(applyAction.Multiplier * axis * forceVector);
				RailDriverDisplayDV.DisplayNotification((axis > 0.5f) ? DV.RailDriver.RailDriver.DisplayBuffer.UP : DV.RailDriver.RailDriver.DisplayBuffer.DN);
			}
		}

		protected virtual void Apply(Vector3 force)
		{
			GetComponent<Rigidbody>()?.AddRelativeForce(force);
		}
	}
}
