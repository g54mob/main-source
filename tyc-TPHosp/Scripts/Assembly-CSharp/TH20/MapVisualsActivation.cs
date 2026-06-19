using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	[DisallowMultipleComponent]
	public class MapVisualsActivation : MonoBehaviour
	{
		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig _levelConfig;

		[SerializeField]
		private List<GameObject> m_playableList;

		[SerializeField]
		private List<GameObject> m_lockedList;

		private Metagame _metagame;

		private MetagameHospitalRecord _hospitalRecord;

		public void Initialise(Metagame metagame, MetagameMap metagameMap, SaveSystem saveSystem)
		{
			_metagame = metagame;
			_hospitalRecord = metagame.GetHospitalRecord(_levelConfig.Instance);
			Refresh();
		}

		public void Refresh()
		{
			bool flag = _levelConfig.Instance.IsVisible(_metagame) || (_hospitalRecord != null && _hospitalRecord.IsVisible());
			bool flag2 = _levelConfig.Instance.IsPlayable(_metagame) || (_hospitalRecord != null && _hospitalRecord.IsPlayable());
			SetLevelPlayable(flag && flag2);
		}

		public void SetLevelPlayable(bool levelPlayable)
		{
			foreach (GameObject playable in m_playableList)
			{
				GameObjectUtils.SetActive(playable, levelPlayable);
			}
			foreach (GameObject locked in m_lockedList)
			{
				GameObjectUtils.SetActive(locked, !levelPlayable);
			}
		}
	}
}
