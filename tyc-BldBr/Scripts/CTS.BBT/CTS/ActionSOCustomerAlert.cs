using CTS.BBT;
using CTS.BBT.AI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Actions/Customer Alert")]
	public class ActionSOCustomerAlert : ActionData
	{
		[SerializeField]
		private float _baseDuration = 1f;

		[SerializeField]
		private bool _playAnimation = true;

		[SerializeField]
		[ShowIf("_playAnimation")]
		private AnimKey _animation = AgentAnim.Scared;

		public override AgentAction InstantiateAction()
		{
			return new CustomerActionAlert(null)
			{
				BaseDuration = _baseDuration,
				Animation = (_playAnimation ? new AnimKey?(_animation) : ((AnimKey?)null))
			};
		}
	}
}
