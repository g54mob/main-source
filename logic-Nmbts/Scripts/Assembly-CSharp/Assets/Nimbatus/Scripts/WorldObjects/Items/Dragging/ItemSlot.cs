using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging
{
	public class ItemSlot : MonoBehaviour
	{
		public bool AllowDragAndDrop;

		public bool DisableToolTip;

		public UITexture Icon;

		public UITexture ColoredIcon;

		public UITexture LockedIcon;

		public UILabel StackSizeLabel;

		[HideInInspector]
		public NimbatusItem Item;

		private UIDragScrollView _uiDragPanelContents;

		private bool _noStacks;

		public bool HideStackSize;

		public bool DisableScaling;

		public bool HasCustomStackSize;

		[ShowIf("HasCustomStackSize", true)]
		public int CustomStackSize;

		public void Awake()
		{
			_uiDragPanelContents = GetComponent<UIDragScrollView>();
			_noStacks = false;
			StackSizeLabel.text = "";
			Init();
		}

		public void Init(UIScrollView panel)
		{
			_uiDragPanelContents.scrollView = panel;
			Init();
		}

		public void Init()
		{
			UIButtonScale component = GetComponent<UIButtonScale>();
			if (component != null)
			{
				component.enabled = !DisableScaling;
			}
			if (Icon != null)
			{
				if (Item == null)
				{
					Icon.enabled = false;
				}
				else
				{
					Texture2D icon = Item.GetIcon();
					Icon.mainTexture = icon;
					Icon.enabled = true;
				}
			}
			Weapon weapon;
			Emitter emitter;
			if ((object)(weapon = Item as Weapon) != null)
			{
				if (ColoredIcon != null)
				{
					ColoredIcon.mainTexture = weapon.Emitter.AmmunitionTexture;
					ColoredIcon.color = weapon.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
			}
			else if ((object)(emitter = Item as Emitter) != null)
			{
				if (ColoredIcon != null)
				{
					ColoredIcon.mainTexture = emitter.AmmunitionTexture;
					ColoredIcon.color = emitter.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
			}
			else if (ColoredIcon != null)
			{
				ColoredIcon.enabled = false;
			}
			LockedIcon.gameObject.SetActive(false);
			if (Item is WeaponAttributeUpgrade && RuntimeGlobals.HasWeaponWorkshop && !Item.Unlocked)
			{
				LockedIcon.gameObject.SetActive(true);
			}
			UpdateStackSizeLabel();
		}

		public void Update()
		{
			UpdateStackSizeLabel();
		}

		private void UpdateStackSizeLabel()
		{
			if (!(Item != null))
			{
				return;
			}
			if ((HasCustomStackSize || (Item.IsStackable && !Item.UnlimitedStackSize)) && !HideStackSize)
			{
				int num = Item.CurrentStackSize - Item.TemporaryUsageCount;
				_noStacks = num <= 0;
				if (HasCustomStackSize)
				{
					num = CustomStackSize;
					_noStacks = CustomStackSize <= 0;
				}
				StackSizeLabel.text = (_noStacks ? LabelHelper.DarkOrange : LabelHelper.White) + num.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				StackSizeLabel.text = "";
			}
		}

		public void OnTooltip(bool show)
		{
			if (DisableToolTip)
			{
				return;
			}
			if (Item != null)
			{
				Weapon weapon;
				if ((object)(weapon = Item as Weapon) != null)
				{
					NimbatusToolTip.ShowWeapon(weapon, true);
				}
				else
				{
					NimbatusToolTip.Show(Item.GetTooltip());
				}
			}
			else
			{
				NimbatusToolTip.Show("", false);
			}
			if (!show)
			{
				NimbatusToolTip.Show("", false);
			}
		}

		public void OnClick()
		{
			if (!AllowDragAndDrop)
			{
				return;
			}
			if (DragAndDropHelper.DraggedItem != null)
			{
				DragAndDropHelper.DeleteDraggedItem();
			}
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			NimbatusItem nimbatusItem = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItem(Item);
			nimbatusItem.PostLoad();
			DronePart dronePart;
			if ((object)(dronePart = nimbatusItem as DronePart) != null)
			{
				dronePart.DeleteOnDrop = true;
				dronePart.IgnoreOffset = true;
				if (DronePartManager.Instance != null)
				{
					dronePart.SetDrone(DronePartManager.Instance.ActiveDrone);
				}
			}
			DragAndDropHelper.DraggedItem = nimbatusItem;
		}

		public virtual void OnDrag(Vector2 delta)
		{
			if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && AllowDragAndDrop && DragAndDropHelper.DraggedItem == null)
			{
				UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
				OnClick();
			}
		}
	}
}
