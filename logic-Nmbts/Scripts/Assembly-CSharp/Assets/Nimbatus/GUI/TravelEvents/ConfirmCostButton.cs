using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelEvents
{
	public class ConfirmCostButton : MonoBehaviour
	{
		public UILabel TitleLabel;

		public UITexture ConfirmCostResource;

		public UILabel ConfirmCostLabel;

		public TravelEventUi TravelEventManager;

		public bool NegativeChoice;

		private List<UIButton> _buttons;

		private ItemPrice _cost;

		public void Init(string text, ItemPrice cost)
		{
			_cost = cost;
			bool flag = _cost != null;
			TitleLabel.text = text;
			Vector3 localPosition = TitleLabel.transform.localPosition;
			if (!flag)
			{
				localPosition.x = ConfirmCostResource.transform.localPosition.x;
			}
			TitleLabel.transform.localPosition = localPosition;
			ConfirmCostResource.gameObject.SetActive(flag);
			ConfirmCostLabel.gameObject.SetActive(flag);
			if (!flag)
			{
				return;
			}
			ResourceSetting resourceSetting = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings[_cost.Resource];
			ConfirmCostResource.mainTexture = resourceSetting.Icon;
			ConfirmCostLabel.text = _cost.Amount.ToString("###0", CultureInfo.InvariantCulture);
			if (!_cost.AffordsPrice())
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
					b.isEnabled = false;
				});
			}
		}

		public void Awake()
		{
			_buttons = GetComponents<UIButton>().ToList();
		}

		public void OnClick()
		{
			if (_cost != null)
			{
				if (_cost.AffordsPrice())
				{
					if (NegativeChoice)
					{
						TravelEventManager.NegativeChoice();
					}
					else
					{
						TravelEventManager.PositiveChoice();
					}
				}
			}
			else if (NegativeChoice)
			{
				TravelEventManager.NegativeChoice();
			}
			else
			{
				TravelEventManager.PositiveChoice();
			}
		}
	}
}
