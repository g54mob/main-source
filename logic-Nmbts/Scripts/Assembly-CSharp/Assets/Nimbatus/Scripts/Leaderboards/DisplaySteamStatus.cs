using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class DisplaySteamStatus : MonoBehaviour
	{
		public UILabel ConnectionLabel;

		private void Update()
		{
			if (!SteamManager.Connected)
			{
				ConnectionLabel.text = LocalizationManager.GetTermTranslation("Tournaments/Not Connected");
			}
			else
			{
				ConnectionLabel.text = LocalizationManager.GetTermTranslation("Tournaments/Connected");
			}
		}
	}
}
