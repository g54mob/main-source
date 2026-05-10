using CTS.BBT;
using UnityEngine;

namespace CTS
{
	public class ActionPlayAnimConstructor : ActionConstructor<AgentActionPlayAnim>
	{
		[SerializeField]
		private AnimKey _anim;

		[SerializeField]
		private bool _cancellable = true;

		protected override AgentActionPlayAnim ConstructAction()
		{
			return new AgentActionPlayAnim(_anim, _cancellable);
		}
	}
}
