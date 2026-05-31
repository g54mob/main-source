using UnityEngine;

namespace __Project__.Scripts.Computer.Management.MusicPlayerTab
{
	public class MusicPlayerTab : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_LockedUI;

		[SerializeField]
		private GameObject m_UnlockedUI;

		public bool IsSpeakerExist()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateUI()
		{
		}
	}
}
