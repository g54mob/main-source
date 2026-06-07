using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Receivables;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class MissionFailedPanel : MonoBehaviour
	{
		public OrePenaltyScreen OrePenaltyScreen;

		private int _currentPenalty;

		private List<BaseReceivable> _penalties;

		private MissionRewardUiManager _manager;

		public void Init(MissionRewardUiManager manager, List<BaseReceivable> penalties)
		{
			_manager = manager;
			_penalties = penalties;
			_currentPenalty = 0;
			if (_penalties.Any())
			{
				Show(_currentPenalty);
			}
		}

		public void Show(int index)
		{
			OrePenaltyScreen.gameObject.SetActive(false);
			OreReceivable penalty;
			if (_penalties.Count > _currentPenalty && (penalty = _penalties[_currentPenalty] as OreReceivable) != null)
			{
				OrePenaltyScreen.gameObject.SetActive(true);
				OrePenaltyScreen.Init(penalty);
			}
		}

		public void Continue()
		{
			_currentPenalty++;
			if (_penalties.Count > _currentPenalty)
			{
				Show(_currentPenalty);
			}
			else
			{
				_manager.Continue();
			}
		}
	}
}
