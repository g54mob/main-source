using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[AddComponentMenu("Assets/Uber Audio/Bank Mounter")]
	public class AudioBankMounter : MonoBehaviour
	{
		public List<string> BanksToMount = new List<string>();

		private void Start()
		{
			if (AudioManager.Instance == null)
			{
				return;
			}
			foreach (string item in BanksToMount)
			{
				AudioManager.Instance.LoadEventBank(item);
			}
		}

		private void OnDestroy()
		{
			if (AudioManager.Instance == null)
			{
				return;
			}
			foreach (string item in BanksToMount)
			{
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.UnloadEventBank(item);
				}
			}
		}
	}
}
