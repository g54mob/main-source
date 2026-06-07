using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class SelectPerkButton : MonoBehaviour
	{
		private CampaignModeSettingsManager _manager;

		public void Init(CampaignModeSettingsManager manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			_manager.IntroManager.Next(false);
		}
	}
}
