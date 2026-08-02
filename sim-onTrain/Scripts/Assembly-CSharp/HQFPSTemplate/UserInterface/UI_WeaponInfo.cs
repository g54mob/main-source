using System;
using System.Collections.Generic;
using HQFPSTemplate.Equipment;
using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_WeaponInfo : UserInterfaceBehaviour
	{
		[Serializable]
		public struct FireModeDisplayer
		{
			[BHeader("GENERAL", true)]
			public Image FireModeImage;

			[DatabaseProperty]
			public string FireModeProperty;

			[Space]
			[BHeader("Fire Mode Sprites...", order = 100)]
			public Sprite SafetyModeSprite;

			public Sprite SemiAutoModeSprite;

			public Sprite FullAutoModeSprite;

			public Sprite BurstModeSprite;
		}

		[Serializable]
		public class AmmoAmountDisplayer
		{
			[Serializable]
			public struct BulletDisplayer
			{
				[DatabaseItem]
				public string BulletItem;

				public Vector2 BulletSpriteSize;

				public Vector2 LayoutGroupSpacing;

				public int XOffset;

				public float BulletLineWidth;
			}

			[BHeader("General", true)]
			public Text StorageTxt;

			[Range(1f, 100f)]
			public int MaxMagSize = 30;

			[Range(1f, 100f)]
			[Tooltip("At what percent the ammo in the magazine is considered low (e.g. reload message will appear)")]
			public float LowAmmoPercent = 30f;

			[DatabaseProperty]
			public string AmmoTypeProperty = "Ammo Type";

			[Space]
			public GridLayoutGroup BulletsLayoutGroup;

			public Image BulletTemplateImg;

			[Space]
			public Color NormalBulletColor = Color.white;

			public Color LowAmmoBulletColor = Color.red;

			public Color BulletConsumedColor = Color.black;

			[Space]
			[Group]
			public BulletDisplayer[] BulletDisplayers;

			[BHeader("Reload Message...", order = 100)]
			public Image ReloadMessage;

			public readonly List<Image> BulletImages = new List<Image>(35);
		}

		private readonly int animHash_FireModeChanged = Animator.StringToHash("Fire Mode Changed");

		private readonly int animHash_ammoConsumed = Animator.StringToHash("Ammo Consumed");

		private readonly int animHash_Show = Animator.StringToHash("Show");

		[SerializeField]
		private Animator m_Animator;

		[SerializeField]
		private Image m_WeaponIconImg;

		[Space]
		[SerializeField]
		[Group]
		private AmmoAmountDisplayer m_AmmoDisplayer;

		[SerializeField]
		[Group]
		private FireModeDisplayer m_FireModeDisplayer;

		private bool m_IsNewWeapon;

		private ProjectileWeapon m_Weapon;

		private RectTransform m_BulletsLayoutGroupRct;

		public override void OnPostAttachment()
		{
			base.Player.ActiveEquipmentItem.AddChangeListener(OnChangeItem);
			base.Player.ChangeUseMode.AddListener(UpdateFireModeUI);
			if (m_AmmoDisplayer.BulletTemplateImg != null)
			{
				for (int i = 0; i < m_AmmoDisplayer.MaxMagSize; i++)
				{
					m_AmmoDisplayer.BulletImages.Add(UnityEngine.Object.Instantiate(m_AmmoDisplayer.BulletTemplateImg, m_AmmoDisplayer.BulletTemplateImg.rectTransform.position, m_AmmoDisplayer.BulletTemplateImg.rectTransform.rotation, m_AmmoDisplayer.BulletsLayoutGroup.transform));
				}
				m_AmmoDisplayer.BulletTemplateImg.enabled = false;
				m_BulletsLayoutGroupRct = m_AmmoDisplayer.BulletsLayoutGroup.GetComponent<RectTransform>();
			}
		}

		private void OnChangeItem(EquipmentItem eItem)
		{
			m_Weapon = base.Player.ActiveEquipmentItem.Get() as ProjectileWeapon;
			ProjectileWeapon projectileWeapon = base.Player.ActiveEquipmentItem.GetPreviousValue() as ProjectileWeapon;
			if (projectileWeapon != null)
			{
				projectileWeapon.CurrentAmmoInfo.RemoveChangeListener(UpdateAmmoAmountUI);
			}
			m_IsNewWeapon = true;
			if (m_Weapon == null || !m_Weapon.AmmoEnabled)
			{
				m_Animator.SetBool(animHash_Show, value: false);
				return;
			}
			m_Animator.SetBool(animHash_Show, value: true);
			m_WeaponIconImg.sprite = m_Weapon.EHandler.Item.Info.Icon;
			m_Weapon.CurrentAmmoInfo.AddChangeListener(UpdateAmmoAmountUI);
			UpdateAmmoAmountUI(m_Weapon.CurrentAmmoInfo.Get());
			UpdateAmmoTypeUI();
			UpdateFireModeUI();
			m_IsNewWeapon = false;
		}

		private void UpdateAmmoTypeUI()
		{
			string text = ItemDatabase.GetItemById(m_Weapon.EHandler.Item.GetProperty(m_AmmoDisplayer.AmmoTypeProperty).ItemId).Name;
			AmmoAmountDisplayer.BulletDisplayer[] bulletDisplayers = m_AmmoDisplayer.BulletDisplayers;
			for (int i = 0; i < bulletDisplayers.Length; i++)
			{
				AmmoAmountDisplayer.BulletDisplayer bulletDisplayer = bulletDisplayers[i];
				if (!(bulletDisplayer.BulletItem == text))
				{
					continue;
				}
				for (int j = 0; j < m_AmmoDisplayer.BulletImages.Count; j++)
				{
					m_AmmoDisplayer.BulletImages[j].gameObject.SetActive(value: false);
				}
				for (int k = 0; k < m_Weapon.MagazineSize; k++)
				{
					if (ItemDatabase.TryGetItemByName(bulletDisplayer.BulletItem, out var itemInfo))
					{
						if (itemInfo.Icon == m_AmmoDisplayer.BulletImages[k])
						{
							break;
						}
						m_AmmoDisplayer.BulletImages[k].sprite = itemInfo.Icon;
						m_AmmoDisplayer.BulletImages[k].gameObject.SetActive(value: true);
						m_AmmoDisplayer.BulletImages[k].transform.localScale = bulletDisplayer.BulletSpriteSize;
					}
				}
				m_BulletsLayoutGroupRct.sizeDelta = new Vector2(bulletDisplayer.BulletLineWidth, m_BulletsLayoutGroupRct.sizeDelta.y);
				m_AmmoDisplayer.BulletsLayoutGroup.spacing = bulletDisplayer.LayoutGroupSpacing;
				m_AmmoDisplayer.BulletsLayoutGroup.padding.right = bulletDisplayer.XOffset;
				break;
			}
		}

		public void UpdateAmmoAmountUI(ProjectileWeapon.AmmoInfo ammoInfo)
		{
			if (m_Weapon == null)
			{
				return;
			}
			int currentInMagazine = ammoInfo.CurrentInMagazine;
			int currentInMagazine2 = m_Weapon.CurrentAmmoInfo.GetPreviousValue().CurrentInMagazine;
			int magazineSize = m_Weapon.MagazineSize;
			if (!m_IsNewWeapon)
			{
				if (m_Animator != null && currentInMagazine2 > currentInMagazine)
				{
					m_Animator.SetTrigger(animHash_ammoConsumed);
					m_AmmoDisplayer.BulletImages[magazineSize - ammoInfo.CurrentInMagazine - 1].color = m_AmmoDisplayer.BulletConsumedColor;
				}
				else if (currentInMagazine2 < currentInMagazine)
				{
					for (int i = magazineSize - ammoInfo.CurrentInMagazine; i < m_AmmoDisplayer.BulletImages.Count; i++)
					{
						m_AmmoDisplayer.BulletImages[i].color = m_AmmoDisplayer.NormalBulletColor;
					}
				}
			}
			for (int j = 0; j < magazineSize; j++)
			{
				m_AmmoDisplayer.BulletImages[j].color = m_AmmoDisplayer.BulletConsumedColor;
			}
			for (int k = magazineSize - currentInMagazine; k < magazineSize; k++)
			{
				m_AmmoDisplayer.BulletImages[k].color = m_AmmoDisplayer.NormalBulletColor;
			}
			if ((float)currentInMagazine <= (float)magazineSize * (m_AmmoDisplayer.LowAmmoPercent / 100f))
			{
				for (int l = 0; l < m_AmmoDisplayer.BulletImages.Count; l++)
				{
					if (m_AmmoDisplayer.BulletImages[l].color == m_AmmoDisplayer.NormalBulletColor)
					{
						m_AmmoDisplayer.BulletImages[l].color = m_AmmoDisplayer.LowAmmoBulletColor;
					}
				}
			}
			else
			{
				for (int m = 0; m < m_AmmoDisplayer.BulletImages.Count; m++)
				{
					if (m_AmmoDisplayer.BulletImages[m].color == m_AmmoDisplayer.LowAmmoBulletColor)
					{
						m_AmmoDisplayer.BulletImages[m].color = m_AmmoDisplayer.NormalBulletColor;
					}
				}
			}
			int currentMagazine = m_Weapon.currentMagazine;
			int num = m_Weapon.CurrentAmmoInfo.Get().CurrentInStorage + m_Weapon.lastAmmoChargedSize - currentMagazine;
			m_AmmoDisplayer.StorageTxt.text = currentMagazine + "/" + num;
			UpdateReloadMessage(currentInMagazine);
		}

		private void UpdateReloadMessage(int newCountInMagazine)
		{
			if ((float)newCountInMagazine <= (float)m_Weapon.MagazineSize * (m_AmmoDisplayer.LowAmmoPercent / 100f))
			{
				m_AmmoDisplayer.ReloadMessage.gameObject.SetActive(value: true);
			}
			else
			{
				m_AmmoDisplayer.ReloadMessage.gameObject.SetActive(value: false);
			}
		}

		private void UpdateFireModeUI()
		{
			if (!(m_Weapon != null))
			{
				return;
			}
			if (m_IsNewWeapon && !m_Weapon.EHandler.Item.HasProperty(m_FireModeDisplayer.FireModeProperty))
			{
				m_FireModeDisplayer.FireModeImage.color = Color.clear;
				return;
			}
			m_FireModeDisplayer.FireModeImage.color = Color.white;
			m_Animator.SetTrigger(animHash_FireModeChanged);
			switch (m_Weapon.EHandler.Item.GetProperty(m_FireModeDisplayer.FireModeProperty).Integer)
			{
			case 4:
				m_FireModeDisplayer.FireModeImage.sprite = m_FireModeDisplayer.BurstModeSprite;
				break;
			case 8:
				m_FireModeDisplayer.FireModeImage.sprite = m_FireModeDisplayer.FullAutoModeSprite;
				break;
			case 2:
				m_FireModeDisplayer.FireModeImage.sprite = m_FireModeDisplayer.SemiAutoModeSprite;
				break;
			case 1:
				m_FireModeDisplayer.FireModeImage.sprite = m_FireModeDisplayer.SafetyModeSprite;
				break;
			}
		}
	}
}
