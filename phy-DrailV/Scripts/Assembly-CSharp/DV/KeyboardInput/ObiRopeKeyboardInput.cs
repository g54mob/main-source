using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class ObiRopeKeyboardInput : AKeyboardInput
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
			float axis = InputManager.NewPlayer.GetAxis(applyAction.id);
			if (!(Mathf.Abs(axis) < 0.1f) && PlayerCanReach())
			{
				GetComponent<CabItemObiRope>()?.ApplyForce(applyAction.Multiplier * axis * forceVector);
				RailDriverDisplayDV.DisplayNotification(DV.RailDriver.RailDriver.DisplayBuffer.ON);
			}
		}
	}
}
