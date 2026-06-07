using UnityEngine;

namespace KevinIglesias
{
	public class ThrowHealing : StateMachineBehaviour
	{
		private CastSpells cS;

		public CastHand castHand;

		public float spawnDelay;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}
	}
}
