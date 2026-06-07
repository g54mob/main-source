using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class DisplayDronePerkDetails : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel DescriptionLabel;

		public UILabel EffectLabel;

		public UITexture Image;

		public DroneStarterSetDisplay StarterSetDisplay;

		public SelectPerkButton SelectButton;

		public void Init(DronePerk perk, CampaignModeSettingsManager manager)
		{
			NameLabel.text = perk.Name.GetTranslation();
			DescriptionLabel.text = perk.Description.GetTranslation();
			EffectLabel.text = perk.GetEffectDescription();
			Image.mainTexture = perk.Image;
			StarterSetDisplay.Init(perk.StarterSet, perk);
			SelectButton.Init(manager);
		}
	}
}
