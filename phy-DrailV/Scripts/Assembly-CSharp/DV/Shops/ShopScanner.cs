using DV.CabControls;
using DV.InventorySystem;
using DV.UI;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.Shops
{
	public class ShopScanner : MonoBehaviour
	{
		public LaserBeamLineRenderer laserBeam;

		public TextMeshPro nameText;

		public TextMeshPro amountText;

		public TextMeshPro priceText;

		public AudioClip scanSound;

		public AudioClip errorSound;

		public AudioClip hoverSound;

		private Transform signalOrigin;

		private ItemBase scannerItem;

		private LayerMask shopScanItemsLayerMask;

		private ScanItemCashRegisterModule lastHoveredScanItem;

		private ScanItemCashRegisterModule currentlyHoveredScanItem;

		private GameObject notification;

		private GlobalShopController gsc;

		private void Awake()
		{
			if (scanSound == null || errorSound == null || hoverSound == null)
			{
				Debug.LogError("Not all sounds are set!");
			}
			ClearText();
			shopScanItemsLayerMask = LayerMask.GetMask("Laser_Pointer_Target", "Default");
		}

		private void Start()
		{
			scannerItem = GetComponent<ItemBase>();
			if (scannerItem == null)
			{
				Debug.LogError("Can't get ItemBase attached to ShopScanner, so it can't function properly!", this);
				return;
			}
			gsc = SingletonBehaviour<GlobalShopController>.Instance;
			SetupListeners(set: true);
			base.enabled = false;
		}

		private void SetupListeners(bool set)
		{
			if (set)
			{
				scannerItem.Grabbed += OnGrab;
				scannerItem.Ungrabbed += OnUngrab;
			}
			else
			{
				scannerItem.Grabbed -= OnGrab;
				scannerItem.Ungrabbed -= OnUngrab;
			}
		}

		private void Update()
		{
			if (signalOrigin == null)
			{
				signalOrigin = (VRManager.IsVREnabled() ? laserBeam.transform : PlayerManager.PlayerCamera.transform);
			}
			if (PhysicsQueryBuilder.Raycast(signalOrigin.position, signalOrigin.forward, 4f, shopScanItemsLayerMask).TryGetFirst(out var hit))
			{
				ScanItemCashRegisterModule componentInParent = hit.collider.GetComponentInParent<ScanItemCashRegisterModule>();
				if (componentInParent != null)
				{
					if (currentlyHoveredScanItem != componentInParent)
					{
						if (hoverSound != null)
						{
							hoverSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
						}
						currentlyHoveredScanItem = componentInParent;
						UpdateText();
					}
					return;
				}
			}
			if (currentlyHoveredScanItem != null)
			{
				currentlyHoveredScanItem = null;
				UpdateText();
			}
		}

		private void UpdateText()
		{
			if (currentlyHoveredScanItem != null)
			{
				InventoryItemSpec sellingItemSpec = currentlyHoveredScanItem.sellingItemSpec;
				float unitsToBuy = currentlyHoveredScanItem.Data.unitsToBuy;
				nameText.enabled = true;
				amountText.enabled = true;
				priceText.enabled = true;
				nameText.text = sellingItemSpec.LocalizedName + ":";
				amountText.text = $"{unitsToBuy}/{gsc.GetShopItemData(sellingItemSpec).ItemsInStock}";
				priceText.text = $"${unitsToBuy * currentlyHoveredScanItem.Data.pricePerUnit}";
				if (lastHoveredScanItem != currentlyHoveredScanItem)
				{
					lastHoveredScanItem = currentlyHoveredScanItem;
					string descriptionText = lastHoveredScanItem.descriptionText;
					string itemName = lastHoveredScanItem.ItemName;
					if (notification != null)
					{
						SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(notification);
					}
					if (scannerItem.IsGrabbed())
					{
						notification = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ShowNotification(GetFormattedNotificationText(descriptionText, itemName), null, float.MaxValue, clearExisting: true, null, localize: false);
					}
				}
				return;
			}
			if (lastHoveredScanItem != null)
			{
				lastHoveredScanItem = null;
				if (notification != null)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(notification);
				}
			}
			ClearText();
		}

		private string GetFormattedNotificationText(string description, string title)
		{
			return "<line-height=0><color=#ffff00><align=\"right\"></align>\n<align=\"left\"><margin-right=70><line-height=1.1em>" + title + "</color>\n<margin-right=70></align><line-height=1.4em>\n<line-height=1em>\n<margin-right=0><align=\"left\"><size=75%>" + description + "</size></align>\n";
		}

		private void ClearText()
		{
			nameText.enabled = false;
			amountText.enabled = false;
			priceText.enabled = false;
		}

		private void OnUse()
		{
			if (!(currentlyHoveredScanItem != null))
			{
				return;
			}
			if (currentlyHoveredScanItem.AddItemsToBuy())
			{
				if (scanSound != null)
				{
					scanSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
			}
			else if (errorSound != null)
			{
				errorSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
			}
			UpdateText();
		}

		private void OnGrab(ControlImplBase obj)
		{
			SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpenChanged += BigInventoryToggled;
			CheckState();
			base.enabled = true;
			scannerItem.Used += OnUse;
		}

		private void OnUngrab(ControlImplBase obj)
		{
			SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpenChanged -= BigInventoryToggled;
			CheckState();
			base.enabled = false;
			scannerItem.Used -= OnUse;
			currentlyHoveredScanItem = null;
			UpdateText();
		}

		private void BigInventoryToggled()
		{
			CheckState();
		}

		private void CheckState()
		{
			bool enableBeam = scannerItem.IsGrabbed() && !SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpen;
			laserBeam.EnableBeam(enableBeam);
		}
	}
}
