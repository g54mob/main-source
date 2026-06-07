using System;
using System.Collections;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ScrapyardManager : BaseSingleton<ScrapyardManager>
	{
		public ScrapableItem ItemPrefab;

		public ScrapableItem Slot1;

		public ScrapableItem Slot2;

		public UILabel DescriptionLabel;

		public DisplayWeaponDetails WeaponDetails;

		public AddScrappableWeapon AddButton;

		public GameObject Background;

		public ScrappableItemChestSlot ResultSlot;

		public SkeletonAnimation PlayerLootbox;

		public ParticleSystem PunchEffect;

		public string RewardSound;

		public LoadAllScrapableParts PartsList;

		[HideInInspector]
		public ScrapableItem SelectedItem;

		private TweenAlpha _backgroundTween;

		private bool _inReward;

		private bool _animPlaying;

		public void AddItemToScrapper(ScrapableItem item)
		{
			if (Slot1.Item == null)
			{
				Slot1.Init(null, item.Item, true);
				item.UpdateStackReduction(1);
			}
			else if (Slot2.Item == null)
			{
				Slot2.Init(null, item.Item, true);
				item.UpdateStackReduction(1);
			}
		}

		public void ScrapableItemClicked(ScrapableItem scrapableItem)
		{
			if (scrapableItem == null || scrapableItem.Item == null)
			{
				return;
			}
			if (scrapableItem == Slot1 || scrapableItem == Slot2)
			{
				ScrapableItem scrapableItem2 = PartsList.GetComponentsInChildren<ScrapableItem>().FirstOrDefault((ScrapableItem s) => s.Item.UniqueId == scrapableItem.Item.UniqueId);
				scrapableItem.Init(null, null, true);
				if (scrapableItem2 != null)
				{
					scrapableItem2.UpdateStackReduction(-1);
				}
			}
			else if (scrapableItem.Item.CurrentStackSize > 0)
			{
				SelectedItem = scrapableItem;
				DescriptionLabel.gameObject.SetActive(false);
				WeaponDetails.gameObject.SetActive(true);
				WeaponDetails.Init(scrapableItem.Item);
				AddButton.Init(SelectedItem);
			}
		}

		public bool CanAssemble()
		{
			if (Slot1.Item != null)
			{
				return Slot2.Item != null;
			}
			return false;
		}

		public void AssembleNewItem()
		{
			if (!(Slot1.Item != null) || !(Slot2.Item != null))
			{
				return;
			}
			int num = Mathf.Max(Slot1.Item.UpgradeSlots, Slot2.Item.UpgradeSlots);
			num = Mathf.Min(3, num + 1);
			WeaponPreset newWeapon = WeaponPreset.GenerateRandomPreset(new System.Random(), num, !RuntimeGlobals.HasWeaponWorkshop);
			newWeapon.StackSize = 1;
			NimbatusItem nimbatusItem = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateAndAddWeapon(newWeapon);
			Slot1.Item.ChangeStackSize(-1);
			WeaponPreset weaponPreset = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.FirstOrDefault((WeaponPreset p) => p.UniqueID == Slot1.Item.Preset.UniqueID);
			if (weaponPreset != null)
			{
				weaponPreset.StackSize--;
			}
			ScrapableItem scrapableItem = PartsList.GetComponentsInChildren<ScrapableItem>().FirstOrDefault((ScrapableItem s) => s.Item.UniqueId == Slot1.Item.UniqueId);
			if (scrapableItem != null)
			{
				scrapableItem.UpdateStackReduction(-1);
			}
			Slot2.Item.ChangeStackSize(-1);
			WeaponPreset weaponPreset2 = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.FirstOrDefault((WeaponPreset p) => p.UniqueID == Slot2.Item.Preset.UniqueID);
			if (weaponPreset2 != null)
			{
				weaponPreset2.StackSize--;
			}
			scrapableItem = PartsList.GetComponentsInChildren<ScrapableItem>().FirstOrDefault((ScrapableItem s) => s.Item.UniqueId == Slot2.Item.UniqueId);
			if (scrapableItem != null)
			{
				scrapableItem.UpdateStackReduction(-1);
			}
			if (Slot1.Item.CurrentStackSize == 0)
			{
				Slot1.Item.Unlocked = false;
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RemovePreset(Slot1.Item.Preset);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.ForEach(delegate(DroneData d)
				{
					d.ReplaceWeapons(Slot1.Item.UniqueId, newWeapon.UniqueID);
				});
			}
			if (Slot2.Item.CurrentStackSize == 0)
			{
				Slot2.Item.Unlocked = false;
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RemovePreset(Slot2.Item.Preset);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.ForEach(delegate(DroneData d)
				{
					d.ReplaceWeapons(Slot2.Item.UniqueId, newWeapon.UniqueID);
				});
			}
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Save();
			Slot2.Init(null, null, true);
			Slot1.Init(null, null, true);
			ScrapableItem scrapableItem2 = UnityEngine.Object.Instantiate(ItemPrefab);
			scrapableItem2.Clickable = false;
			scrapableItem2.Init(null, nimbatusItem as Weapon);
			ResultSlot.Init(scrapableItem2);
			scrapableItem2.transform.localScale = Vector3.one;
			ResetSelectedItem();
			StartCoroutine(StartLootboxAnimation());
		}

		private void ResetSelectedItem()
		{
			SelectedItem = null;
			DescriptionLabel.gameObject.SetActive(true);
			WeaponDetails.gameObject.SetActive(false);
			WeaponDetails.Init(null);
			AddButton.Init(null);
		}

		public void OnEnable()
		{
			DescriptionLabel.gameObject.SetActive(true);
			WeaponDetails.gameObject.SetActive(false);
			PlayerLootbox.AnimationState.Event += AnimationState_Event;
			PlayerLootbox.transform.parent.gameObject.SetActive(false);
			Background.SetActive(false);
			_backgroundTween = Background.GetComponent<TweenAlpha>();
		}

		public void OnDisable()
		{
			PlayerLootbox.AnimationState.Event -= AnimationState_Event;
		}

		public void Update()
		{
			if (Input.GetMouseButtonDown(0) && _inReward)
			{
				if (_animPlaying)
				{
					SkipAnimation();
				}
				else
				{
					Return();
				}
			}
		}

		private void AnimationState_Event(TrackEntry trackEntry, Spine.Event e)
		{
			if (e.Data.Name == "Punch")
			{
				if (PunchEffect != null)
				{
					PunchEffect.Play();
				}
			}
			else if (e.Data.Name == "ShowRewards")
			{
				RewardChestSlotsSetActive(true);
				_animPlaying = false;
			}
		}

		private IEnumerator StartLootboxAnimation()
		{
			_inReward = true;
			_animPlaying = true;
			Background.SetActive(true);
			_backgroundTween.PlayForward();
			yield return new WaitForSeconds(_backgroundTween.duration);
			PlayerLootbox.transform.parent.gameObject.SetActive(true);
			AudioController.Play(RewardSound);
			RewardChestSlotsSetActive(false);
			if (PlayerLootbox != null && PlayerLootbox.AnimationState != null)
			{
				PlayerLootbox.AnimationState.ClearTracks();
				PlayerLootbox.AnimationState.Data.DefaultMix = 0f;
				PlayerLootbox.AnimationState.SetAnimation(0, "closed_shaking", false);
				PlayerLootbox.AnimationState.AddAnimation(0, "open1", false, 0f);
				PlayerLootbox.AnimationState.AddAnimation(0, "open_idle", true, 0f);
			}
		}

		private void SkipAnimation()
		{
			AudioController.Stop(RewardSound);
			PlayerLootbox.AnimationState.SetAnimation(0, "open_idle", true);
			RewardChestSlotsSetActive(true);
			_animPlaying = false;
		}

		private void Return()
		{
			ResultSlot.Reset();
			PlayerLootbox.transform.parent.gameObject.SetActive(false);
			Background.SetActive(false);
			_backgroundTween.PlayReverse();
			_inReward = false;
			PartsList.FillUp();
		}

		private void RewardChestSlotsSetActive(bool active)
		{
			if (ResultSlot.Initiated)
			{
				ResultSlot.transform.GetChild(0).gameObject.SetActive(active);
			}
		}
	}
}
