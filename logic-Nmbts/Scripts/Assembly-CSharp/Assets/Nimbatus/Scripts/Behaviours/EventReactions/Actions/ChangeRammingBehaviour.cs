using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ChangeRammingBehaviour : NimbatusAction
	{
		public bool ChangeChargeTime;

		[ShowIf("ChangeChargeTime", true)]
		public float Time;

		public bool ChangeRotationSpeed;

		[ShowIf("ChangeRotationSpeed", true)]
		public float Speed;

		public bool ChangeRammingImpulse;

		[ShowIf("ChangeRammingImpulse", true)]
		public float RammingImpulse;

		public bool ResetCharge;

		private RammingBehaviour _rammingBehaviour;

		protected override void OnInit()
		{
			_rammingBehaviour = Behaviour.GetCoreBehaviour<RammingBehaviour>();
		}

		public override void Execute()
		{
			if (_rammingBehaviour != null)
			{
				if (ChangeChargeTime)
				{
					_rammingBehaviour.ChargeUpTime = Time;
				}
				if (ChangeRotationSpeed)
				{
					_rammingBehaviour.RotationSpeed = Speed;
				}
				if (ChangeRammingImpulse)
				{
					_rammingBehaviour.RammingImpulse = RammingImpulse;
				}
				if (ResetCharge)
				{
					_rammingBehaviour.ResetCharge();
				}
			}
		}
	}
}
