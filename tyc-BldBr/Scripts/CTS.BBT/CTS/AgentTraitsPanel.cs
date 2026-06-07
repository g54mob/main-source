using CTS.BBT.AI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class AgentTraitsPanel : AbsAgentPanel
	{
		[SerializeField]
		private TMP_Text _traitDesc;

		private void Start()
		{
			LocalizationChanged();
		}

		public override void ClearAgentInfo()
		{
		}

		public override void SetAgentInfo()
		{
			LocalizationChanged();
		}

		protected override void LocalizationChanged()
		{
			_traitDesc.text = "";
			if (!(base._agent is Worker worker))
			{
				return;
			}
			foreach (StatisticBonusFactory currentPassife in worker.PassiveFeatures.CurrentPassives)
			{
				TMP_Text traitDesc = _traitDesc;
				traitDesc.text = traitDesc.text + currentPassife.Name.GetLocalizedString() + ", ";
			}
			if (_traitDesc.text.Length > 2)
			{
				_traitDesc.text = _traitDesc.text.Substring(0, _traitDesc.text.Length - 2);
			}
		}
	}
}
