using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using I2.Loc;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class BuyUpgradeButton : MonoBehaviour
	{
		public EMothershipUpgradeType Type;

		public UILabel CostLabel;

		private MothershipUpgrade _upgrade;

		private ItemPrice _cost;

		private bool _hover;

		private UIButton[] _buttons;

		public UIButtonScale ButtonScale;

		public void Awake()
		{
			_buttons = GetComponents<UIButton>();
		}

		public void Start()
		{
			base.gameObject.SetActive(!RuntimeGlobals.GameModeSettings.FreeUpgrades && ReceivableHelper.UpgradeAllowed(Type));
			_upgrade = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradePrefab(Type);
			UpdateButton();
		}

		public void OnClick()
		{
			if (_cost != null && _cost.AffordsPrice())
			{
				int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type);
				SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeUpgradeLevel(Type, upgradeLevel + 1);
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(_cost.Resource, _cost.Amount);
				UpdateButton();
			}
		}

		public void UpdateButton()
		{
			int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(Type);
			if (upgradeLevel >= _upgrade.MaxLevel)
			{
				base.gameObject.SetActive(false);
				return;
			}
			_cost = _upgrade.GetPrice(upgradeLevel + 1);
			CostLabel.text = ((_cost != null) ? _cost.Amount.ToString("D") : "0");
		}

		public void Update()
		{
			if (_cost != null && _cost.AffordsPrice())
			{
				ButtonScale.enabled = true;
				if (_hover)
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Hover, true);
					});
				}
				else
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Normal, true);
					});
				}
			}
			else
			{
				ButtonScale.enabled = false;
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (_cost != null && !_cost.AffordsPrice())
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NotEnoughResources"));
				}
				else
				{
					NimbatusToolTip.Show(null);
				}
			}
		}
	}
}
