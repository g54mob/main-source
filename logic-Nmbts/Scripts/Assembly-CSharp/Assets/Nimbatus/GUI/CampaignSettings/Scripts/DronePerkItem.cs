using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class DronePerkItem : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		private DronePerk _perk;

		private CampaignModeSettingsManager _manager;

		private bool _wasInitialized;

		private bool _hover;

		public void Init(CampaignModeSettingsManager manager, DronePerk perk)
		{
			_manager = manager;
			_perk = perk;
			Icon.mainTexture = perk.Icon;
			_wasInitialized = true;
		}

		public void OnClick()
		{
			_manager.SelectPerk(_perk);
		}

		public void Update()
		{
			if (_wasInitialized)
			{
				if (_manager.SelectedPerk == _perk)
				{
					Background.color = SelectedColor;
				}
				else
				{
					Background.color = (_hover ? HoverColor : NormalColor);
				}
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
