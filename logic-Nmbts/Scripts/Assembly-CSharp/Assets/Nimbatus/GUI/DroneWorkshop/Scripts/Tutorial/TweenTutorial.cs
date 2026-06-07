using Assets.Nimbatus.GUI.CampaignTutorial.Scripts;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class TweenTutorial : MonoBehaviour
	{
		public ShowTutorial Tutorial;

		public CampaignTutorialWorkshop CampaignTutorial;

		public bool Tween;

		public void Start()
		{
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null)
			{
				ShowTutorial tutorial = Tutorial;
				if ((object)tutorial != null)
				{
					tutorial.Show(false);
				}
			}
			else
			{
				base.gameObject.SetActive(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.TutorialSlides.Count > 0);
			}
		}

		public void OnClick()
		{
			ShowTutorial(Tween);
		}

		public void ShowTutorial(bool b)
		{
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial != null)
			{
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.TutorialSlides.Count > 0)
				{
					ShowTutorial tutorial = Tutorial;
					if ((object)tutorial != null)
					{
						tutorial.Show(b);
					}
				}
			}
			else if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				CampaignTutorialWorkshop campaignTutorial = CampaignTutorial;
				if ((object)campaignTutorial != null)
				{
					campaignTutorial.Show(b);
				}
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(Tween ? LocalizationManager.GetTermTranslation("DroneWorkshop/ShowTutorialTooltip") : null);
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
