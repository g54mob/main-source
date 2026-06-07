using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePartTemplates
{
	public class DronePartTemplateItem : MonoBehaviour
	{
		public UITexture Icon;

		[HideInInspector]
		public DronePartTemplateData Item;

		private UIDragScrollView _uiDragPanelContents;

		private UIScrollView _panel;

		private UIGrid _grid;

		public void Awake()
		{
			_uiDragPanelContents = GetComponent<UIDragScrollView>();
			Init();
		}

		public void DeleteItem()
		{
			if (Item != null)
			{
				BaseSingleton<DronePartTemplateManager>.Instance.DeleteTemplate(Item);
				Object.Destroy(base.gameObject);
				_grid.Reposition();
				_panel.ResetPosition();
				_panel.UpdateScrollbars(true);
			}
		}

		public void Init(UIScrollView panel, UIGrid grid)
		{
			_uiDragPanelContents.scrollView = panel;
			_panel = panel;
			_grid = grid;
			Init();
		}

		public void Init()
		{
			if (Icon != null)
			{
				if (Item == null)
				{
					Icon.enabled = false;
					return;
				}
				Texture2D image = Item.Image;
				Icon.mainTexture = image;
				Icon.enabled = true;
			}
		}

		public void OnTooltip(bool show)
		{
			if (Item != null)
			{
				string text = LabelHelper.Orange + Item.Name;
				if (!string.IsNullOrEmpty(Item.Description))
				{
					text = text + LabelHelper.NewLine + LabelHelper.LightGrey + Item.Description;
				}
				foreach (KeyValuePair<string, int> allUsedPart in Item.GetAllUsedParts())
				{
					string id = allUsedPart.Key;
					int value = allUsedPart.Value;
					DronePart itemById = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<DronePart>(id);
					if (itemById != null)
					{
						if (itemById.IsStackable && !itemById.UnlimitedStackSize)
						{
							int num = itemById.CurrentStackSize - value;
							text = string.Concat(text, LabelHelper.NewLine, LabelHelper.Blue, itemById.Name, LabelHelper.White, ": ", (num < 0) ? LabelHelper.Red : LabelHelper.White, value, "/", itemById.CurrentStackSize);
						}
						else
						{
							text = string.Concat(text, LabelHelper.NewLine, LabelHelper.Blue, itemById.Name, LabelHelper.White, ": ", value);
						}
					}
					else
					{
						WeaponPresetData weaponPresetData = Item.WeaponPresets.FirstOrDefault((WeaponPresetData w) => w.UniqueId == id);
						if (weaponPresetData != null)
						{
							text = text + LabelHelper.NewLine + LabelHelper.Blue + weaponPresetData.Name + LabelHelper.White + ": " + value;
						}
					}
				}
				NimbatusToolTip.Show(text);
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
			if (DragAndDropHelper.DraggedItem != null)
			{
				DragAndDropHelper.DeleteDraggedItem();
			}
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			DronePart dronePart = Item.InstantiateDronePart();
			dronePart.PostLoad();
			dronePart.DeleteOnDrop = true;
			dronePart.IgnoreOffset = true;
			if (DronePartManager.Instance != null)
			{
				dronePart.SetDrone(DronePartManager.Instance.ActiveDrone);
			}
			DragAndDropHelper.DraggedItem = dronePart;
		}

		public virtual void OnDrag(Vector2 delta)
		{
			if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && DragAndDropHelper.DraggedItem == null)
			{
				UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
				OnClick();
			}
		}
	}
}
