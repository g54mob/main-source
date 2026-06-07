using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine.Video;

namespace Assets.Nimbatus.GUI.CampaignTutorial.Scripts
{
	public class CampaignTutorialWorkshop : CampaignTutorialTextbox
	{
		public UITexture Image;

		public VideoPlayer VideoPlayer;

		public override void Init(CampaignTutorialTextboxSetting textSetting, CampaignTutorialSetting setting)
		{
			SetActive(true);
			TextLabel.text = textSetting.Text.GetTranslation();
			if (setting.IsWorkshop)
			{
				if (setting.Image != null)
				{
					Image.mainTexture = setting.Image;
					Image.gameObject.SetActive(true);
					VideoPlayer.gameObject.SetActive(false);
				}
				else if (setting.Video != null)
				{
					VideoPlayer.clip = setting.Video;
					Image.gameObject.SetActive(false);
					VideoPlayer.gameObject.SetActive(true);
				}
				else
				{
					Image.gameObject.SetActive(false);
					VideoPlayer.gameObject.SetActive(false);
				}
			}
		}

		public void Show(bool show)
		{
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.ResetWorkshopFlags();
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Next();
			SetActive(show);
		}
	}
}
