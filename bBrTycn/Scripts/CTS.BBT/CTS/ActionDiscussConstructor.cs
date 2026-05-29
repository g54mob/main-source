using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ActionDiscussConstructor : ActionConstructor<AgentActionDiscuss>
	{
		[SerializeField]
		private SoftReference<Agent> _target;

		[SerializeField]
		private bool _specificTalkDuration;

		[SerializeField]
		[ShowIf("_specificTalkDuration")]
		[Min(1f)]
		private int _talkDuration = 1;

		protected override AgentActionDiscuss ConstructAction()
		{
			return new AgentActionDiscuss(_target, initiator: true, _specificTalkDuration ? new int?(_talkDuration) : ((int?)null));
		}
	}
}
