using JUTPS.ItemSystem;
using JUTPS.WeaponSystem;
using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.InventorySystem.UI
{
	public class UIItemInformation : MonoBehaviour
	{
		private HoldableItem CurrentItem;

		private JUCharacterController Player;

		[Header("Essentials")]
		public Sprite EmptySprite;

		public Image Icon;

		public Text ItemName;

		public Text ItemQuantity;

		public GameObject BulletLabel;

		public Text BulletQuantity;

		public Image ItemHealth;

		private void Start()
		{
		}

		private void Update()
		{
			if (Player == null)
			{
				Player = JUGameManager.InstancedPlayer;
			}
			else
			{
				if (Player.Inventory == null)
				{
					return;
				}
				CurrentItem = Player.HoldableItemInUseRightHand;
				if (CurrentItem == null)
				{
					Icon.sprite = EmptySprite;
					BulletLabel.SetActive(value: false);
					ItemName.text = "Hand";
					ItemQuantity.text = "";
					ItemHealth.fillAmount = 1f;
					return;
				}
				if (CurrentItem is Weapon)
				{
					Icon.sprite = CurrentItem.ItemIcon;
					ItemName.text = CurrentItem.ItemName;
					ItemQuantity.text = CurrentItem.ItemQuantity + "/" + CurrentItem.MaxItemQuantity;
					BulletLabel.SetActive(value: true);
					BulletQuantity.text = ((Weapon)CurrentItem).BulletsAmounts + "/" + ((Weapon)CurrentItem).TotalBullets;
					ItemHealth.fillAmount = (float)((Weapon)CurrentItem).BulletsAmounts / (float)((Weapon)CurrentItem).BulletsPerMagazine;
					return;
				}
				if ((object)CurrentItem != null || CurrentItem is ThrowableItem)
				{
					Icon.sprite = CurrentItem.ItemIcon;
					ItemName.text = CurrentItem.ItemName;
					ItemQuantity.text = CurrentItem.ItemQuantity + "/" + CurrentItem.MaxItemQuantity;
					BulletLabel.SetActive(value: false);
					ItemHealth.fillAmount = (float)CurrentItem.ItemQuantity / (float)CurrentItem.MaxItemQuantity;
				}
				if (CurrentItem is MeleeWeapon)
				{
					Icon.sprite = CurrentItem.ItemIcon;
					ItemName.text = CurrentItem.ItemName;
					ItemQuantity.text = CurrentItem.ItemQuantity + "/" + CurrentItem.MaxItemQuantity;
					BulletLabel.SetActive(value: false);
					ItemHealth.fillAmount = ((MeleeWeapon)CurrentItem).MeleeWeaponHealth / 100f;
				}
			}
		}
	}
}
