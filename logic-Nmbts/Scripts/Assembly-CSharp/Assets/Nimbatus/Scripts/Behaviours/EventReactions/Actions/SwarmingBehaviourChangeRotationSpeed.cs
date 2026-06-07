using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SwarmingBehaviourChangeRotationSpeed : NimbatusAction
	{
		public float Speed;

		private SwarmingBehaviour _swarmingBehaviour;

		protected override void OnInit()
		{
			_swarmingBehaviour = Behaviour.GetCoreBehaviour<SwarmingBehaviour>();
		}

		public override void Execute()
		{
			if (_swarmingBehaviour != null)
			{
				_swarmingBehaviour.SetRotationSpeed(Speed);
			}
		}
	}
}
