using System;
using NSEipix.Base;
using NSMedieval.State;

namespace NSMedieval
{
	public class HumanoidController : MonoSingleton<HumanoidController>
	{
		public event Action<HumanoidBehaviour> OnActivateBehaviourEvent;

		public event Action<HumanoidBehaviour> OnDeactivateBehaviourEvent;

		public void OnActivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			this.OnActivateBehaviourEvent?.Invoke(humanoidBehaviour);
		}

		public void OnDeactivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			this.OnDeactivateBehaviourEvent?.Invoke(humanoidBehaviour);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnActivateBehaviourEvent = null;
			this.OnDeactivateBehaviourEvent = null;
		}
	}
}
