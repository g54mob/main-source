using CTS.BBT.AI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class AgentCredibilityPanel : AbsAgentPanel
	{
		[SerializeField]
		private TMP_Text _credibilityText;

		public override void SetAgentInfo()
		{
			if (base._agent is Customer customer)
			{
				_credibilityText.text = customer.Credibility.ToString();
			}
		}

		public override void ClearAgentInfo()
		{
		}
	}
}
