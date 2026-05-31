using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class AgentXP_Panel : AbsAgentPanel
	{
		[SerializeField]
		private Image _bar;

		public override void ClearAgentInfo()
		{
			if (base._agent is Worker worker)
			{
				worker.Level.ExperienceAdded -= SetXPValue;
			}
		}

		public override void SetAgentInfo()
		{
			if (base._agent is Worker worker)
			{
				worker.Level.ExperienceAdded += SetXPValue;
				SetXPValue(0f);
			}
		}

		private void SetXPValue(float xp)
		{
			if (base._agent is Worker worker)
			{
				_bar.fillAmount = worker.Level.ToNextLevelUnitInterval;
			}
		}
	}
}
