using System.Collections;
using CTS.BBT.AI;
using CTS.Emotes;

namespace CTS
{
	public class AgentActionBark : AgentAction<Agent>
	{
		private string _text = "";

		private float _duration = 2f;

		public AgentActionBark(string text, float duration)
		{
			_text = text;
			_duration = duration;
		}

		public override IEnumerator ActionRoutine()
		{
			EmoteManagerBBT.Play(base.ActionAgent, _text).SetStayDuration(_duration);
			yield break;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnCancel()
		{
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		protected override void OnStopped()
		{
		}
	}
}
