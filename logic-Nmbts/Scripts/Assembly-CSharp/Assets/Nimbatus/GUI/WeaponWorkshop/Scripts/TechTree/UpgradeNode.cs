using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class UpgradeNode : SerializedMonoBehaviour
	{
		public UITexture Icon;

		public UITexture Background;

		public UpgradeNodeConnection LinePrefab;

		public GameObject ChosenObject;

		public Color UnlockedColor;

		public Color LockedColor;

		public Color SelectedColor;

		public Color HoverColor;

		public List<UpgradeNode> ChildrenNodes = new List<UpgradeNode>();

		public List<UpgradeNode> ParentNodes = new List<UpgradeNode>();

		public List<UpgradeNodeConnection> Lines = new List<UpgradeNodeConnection>();

		private bool _hover;

		[HideInInspector]
		public WeaponAttributeUpgrade Upgrade;

		private TechTreeDisplay _techTree;

		private bool _compatible;

		public bool IsPressed;

		private Vector3 _deltaPos;

		private bool _hasChosen;

		private bool _notChoosable;

		public void Init(WeaponAttributeUpgrade upgrade, TechTreeDisplay techTree)
		{
			_techTree = techTree;
			Upgrade = upgrade;
		}

		public void AddChild(UpgradeNode upgradeNode)
		{
			if (!ParentNodes.Contains(upgradeNode) && !ChildrenNodes.Contains(upgradeNode))
			{
				ChildrenNodes.Add(upgradeNode);
				Upgrade.AddChild(upgradeNode.Upgrade);
			}
		}

		public void AddParent(UpgradeNode upgradeNode)
		{
			if (!ParentNodes.Contains(upgradeNode) && !ChildrenNodes.Contains(upgradeNode))
			{
				ParentNodes.Add(upgradeNode);
				UpgradeNodeConnection upgradeNodeConnection = Object.Instantiate(LinePrefab, base.transform);
				upgradeNodeConnection.Init(upgradeNode.transform, base.transform);
				Lines.Add(upgradeNodeConnection);
			}
		}

		public string GetDescription()
		{
			if (Upgrade == null)
			{
				return "";
			}
			return Upgrade.GetDetailedTooltip();
		}

		public void OnTooltip(bool show)
		{
			if (_compatible)
			{
				if (Upgrade != null)
				{
					string text = Upgrade.GetTooltip();
					if (!Upgrade.Unlocked)
					{
						text = text + LabelHelper.Orange + "\n" + LocalizationManager.GetTermTranslation("DroneWorkshop/ResearchToUnlock");
					}
					NimbatusToolTip.Show(text);
				}
				else
				{
					NimbatusToolTip.Show(null);
				}
				if (!show)
				{
					NimbatusToolTip.Show(null);
				}
			}
			else
			{
				NimbatusToolTip.Show(LabelHelper.Red + LocalizationManager.GetTermTranslation("DroneWorkshop/Incompatible"));
			}
		}

		public void OnClick()
		{
			if (_compatible)
			{
				_techTree.SelectedNode = this;
				if (!_notChoosable && WeaponUpgradeSlot.SelectedSlot != null)
				{
					WeaponUpgradeSlot.SelectedSlot.SetUpgrade(Upgrade);
				}
			}
		}

		public void OnPress(bool isPressed)
		{
			IsPressed = isPressed;
			if (IsPressed)
			{
				_deltaPos = base.transform.position - UICamera.lastWorldPosition;
			}
		}

		public void Update()
		{
			if (IsPressed && ParentNodes.Count > 0)
			{
				base.transform.position = UICamera.lastWorldPosition + _deltaPos;
			}
			if (Upgrade.Unlocked)
			{
				Background.color = UnlockedColor;
				Color transparentUnlockedColor = UnlockedColor;
				transparentUnlockedColor.a = 0.75f;
				Lines.ForEach(delegate(UpgradeNodeConnection l)
				{
					l.SetLineColor(transparentUnlockedColor);
				});
			}
			else
			{
				Background.color = LockedColor;
				Color transparentLineColor = LockedColor;
				transparentLineColor.a = 0.75f;
				Lines.ForEach(delegate(UpgradeNodeConnection l)
				{
					l.SetLineColor(transparentLineColor);
				});
				if (_compatible)
				{
					Color white = Color.white;
					white.a = 0.65f;
					Icon.color = white;
				}
			}
			if (_compatible)
			{
				Color bgColor = Background.color;
				bgColor.a = 1f;
				Background.color = bgColor;
				if (ParentNodes.TrueForAll((UpgradeNode p) => p._compatible))
				{
					Lines.ForEach(delegate(UpgradeNodeConnection l)
					{
						l.SetLineColor(bgColor);
					});
				}
				else
				{
					bgColor.a = 0.01f;
				}
			}
			else
			{
				Color bgColor2 = Background.color;
				bgColor2.a = 0.01f;
				Background.color = bgColor2;
				Lines.ForEach(delegate(UpgradeNodeConnection l)
				{
					l.SetLineColor(bgColor2);
				});
			}
			if (_techTree.SelectedNode == this)
			{
				Background.color = SelectedColor;
				Lines.ForEach(delegate(UpgradeNodeConnection l)
				{
					l.SetLineColor(SelectedColor);
				});
			}
			ChosenObject.SetActive(_hasChosen);
			if (_hover)
			{
				Background.color = HoverColor;
			}
			if (Upgrade != null)
			{
				Icon.mainTexture = Upgrade.Icon;
				Icon.enabled = true;
			}
			else
			{
				Icon.enabled = false;
			}
		}

		public void UpgradeCompatibility(WeaponPreset selectedItem)
		{
			if (selectedItem == null)
			{
				Icon.color = new Color(1f, 1f, 1f, 1f);
				_compatible = true;
				_hasChosen = false;
				return;
			}
			_notChoosable = selectedItem.HasUpgrade(Upgrade);
			if (selectedItem.HasUpgrade(Upgrade))
			{
				_hasChosen = true;
			}
			else
			{
				_hasChosen = false;
			}
			if (selectedItem.IsCompatible(Upgrade))
			{
				Icon.color = new Color(1f, 1f, 1f, 1f);
				_compatible = true;
			}
			else
			{
				Icon.color = new Color(1f, 1f, 1f, 0.2f);
				_compatible = false;
			}
		}

		public void OnHover(bool isOver)
		{
			if (_compatible)
			{
				_hover = isOver;
			}
			else
			{
				_hover = false;
			}
		}
	}
}
