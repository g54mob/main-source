using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class Idle : State
	{
		public override string StateName => "Idle";

		public override string StateIDName => "Idle";

		public bool HasLocomotion { get; private set; }

		public override void InitializeState()
		{
			HasLocomotion = animal.HasState(StateEnum.Locomotion);
		}

		public override void Activate()
		{
			base.Activate();
			base.CanExit = true;
		}

		public override bool TryActivate()
		{
			if (HasLocomotion)
			{
				if (animal.MovementAxisSmoothed == Vector3.zero && !animal.MovementDetected)
				{
					return General.Grounded == animal.Grounded;
				}
				return false;
			}
			return General.Grounded == animal.Grounded;
		}
	}
}
