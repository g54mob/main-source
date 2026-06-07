using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items
{
	public class ItemManager : SerializableMonobehaviour<ItemManager, ItemManagerSaveData>
	{
		public Weapon WeaponTemplate;

		public EnemyWeapon EnemyWeaponTemplate;

		public WeaponPreset DefaultWeapon;

		public DronePartStarterSet DefaultStarterSet;

		public Texture2D RandomWeaponIcon;

		public Dictionary<EWeaponRarity, Color> RarityColors;

		public Dictionary<EMultiPartType, Texture2D> MultiPartIcons;

		private bool _starterSetUnlocked;

		protected List<NimbatusItem> ItemPrefabs { get; private set; }

		protected List<Projectile> ProjectilePrefabs { get; private set; }

		public List<WeaponPreset> WeaponPresets { get; private set; }

		internal override string Filename
		{
			get
			{
				return "Items.xml";
			}
		}

		protected override void PreLoad()
		{
			if (ItemPrefabs != null)
			{
				foreach (NimbatusItem item in ItemPrefabs.Where((NimbatusItem i) => i.WasGenerated))
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			WeaponPresets = new List<WeaponPreset>();
			ProjectilePrefabs = Resources.LoadAll<Projectile>("Items").ToList();
			ResetAllItems();
			CheckDuplicateIds();
			WeaponTemplate.IsStackable = false;
		}

		protected override void PostLoad()
		{
			base.PostLoad();
			UpdateItems();
			if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk != null)
			{
				UnlockStarterSet(SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk.StarterSet);
			}
			else if (RuntimeGlobals.GameMode == EGameMode.Creative || RuntimeGlobals.GameMode == EGameMode.Demo)
			{
				if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
				{
					UnlockStarterSet(DefaultStarterSet);
				}
				GenerateAndAddWeapon(DefaultWeapon.Clone(), WeaponTemplate, true, true);
			}
		}

		public void UpdateItems()
		{
			NimbatusItem[] array = Resources.LoadAll<NimbatusItem>("Items");
			for (int i = 0; i < array.Length; i++)
			{
				array[i].InitDronePerkSettings(SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects);
			}
		}

		public void ResetAllItems()
		{
			ItemPrefabs = new List<NimbatusItem>();
			NimbatusItem[] array = Resources.LoadAll<NimbatusItem>("Items");
			foreach (NimbatusItem nimbatusItem in array)
			{
				nimbatusItem.InitStackSettings();
				if (SaveManager.LoadedSave.Settings.HasPartUnlocking)
				{
					nimbatusItem.Unlocked = true;
					if (nimbatusItem.DoNotImport || nimbatusItem.IsStackable)
					{
						nimbatusItem.Unlocked = false;
					}
					if (nimbatusItem is WeaponAttributeUpgrade)
					{
						nimbatusItem.Unlocked = nimbatusItem.AlwaysUnlocked;
					}
					nimbatusItem.UnlimitedStackSize = !nimbatusItem.IsStackable;
					nimbatusItem.CurrentStackSize = 0;
				}
				else if (nimbatusItem.DoNotImport)
				{
					nimbatusItem.Unlocked = false;
				}
				else
				{
					if (nimbatusItem is WeaponAttributeUpgrade)
					{
						nimbatusItem.Unlocked = RuntimeGlobals.GameModeSettings.AllTechnologyUnlocked;
					}
					else
					{
						nimbatusItem.Unlocked = true;
					}
					if (nimbatusItem.AlwaysUnlocked)
					{
						nimbatusItem.Unlocked = true;
					}
					nimbatusItem.UnlimitedStackSize = true;
				}
				ItemPrefabs.Add(nimbatusItem);
			}
			_starterSetUnlocked = false;
		}

		public void UnlockStarterSet(DronePartStarterSet starterSet)
		{
			if (_starterSetUnlocked || ItemPrefabs == null)
			{
				return;
			}
			if (starterSet.AllPartsUnlocked)
			{
				GenerateAndAddWeapon(DefaultWeapon.Clone(), WeaponTemplate, true, true);
			}
			else
			{
				foreach (DronePart dronePart in starterSet.GetDroneParts())
				{
					dronePart.Unlocked = true;
					if (dronePart.IsStackable)
					{
						dronePart.CurrentStackSize = starterSet.GetStackSize(dronePart);
					}
				}
				foreach (WeaponStack weapon in starterSet.Weapons)
				{
					GenerateAndAddWeapon(weapon.Weapon.Clone(), WeaponTemplate, true, true);
				}
			}
			_starterSetUnlocked = true;
		}

		public void EnforceTutorialItemRules(Subtutorial subtutorial)
		{
			foreach (NimbatusItem itemPrefab in ItemPrefabs)
			{
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.AllowedDroneParts.Contains(itemPrefab))
				{
					itemPrefab.Unlocked = true;
					itemPrefab.UnlimitedStackSize = true;
				}
				else
				{
					itemPrefab.Unlocked = false;
				}
			}
			foreach (WeaponPreset allowedWeapon in subtutorial.AllowedWeapons)
			{
				GenerateTutorialWeapon(allowedWeapon, SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponTemplate);
			}
		}

		private void CheckDuplicateIds()
		{
		}

		public NimbatusItem InstantiateItem(NimbatusItem item)
		{
			NimbatusItem nimbatusItem = UnityEngine.Object.Instantiate(item);
			nimbatusItem.gameObject.SetActive(true);
			return nimbatusItem;
		}

		public List<DronePart> GetUnlockedDroneParts(EDronePartType type)
		{
			List<DronePart> list = new List<DronePart>();
			foreach (DronePart item in from d in ItemPrefabs.OfType<DronePart>()
				where d.DronePartType == type || type == EDronePartType.None
				select d)
			{
				if (item.Unlocked && !(item is RootDronePart))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public List<T> GetItems<T>()
		{
			return ItemPrefabs.OfType<T>().ToList();
		}

		public NimbatusItem InstantiateItemFromData(NimbatusItemData data)
		{
			string id = data.PrefabId;
			if (ItemPrefabs != null)
			{
				NimbatusItem nimbatusItem = ItemPrefabs.FirstOrDefault((NimbatusItem wo) => wo.HasUniqueId(id));
				if (nimbatusItem != null)
				{
					NimbatusItem nimbatusItem2 = InstantiateItem(nimbatusItem);
					nimbatusItem2.PreLoad();
					nimbatusItem2.Load(data);
					nimbatusItem2.PostLoad();
					return nimbatusItem2;
				}
				if (data is WeaponData)
				{
					DronePart dronePart = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Weapon>().FirstOrDefault((Weapon w) => w.Unlocked);
					if (dronePart == null)
					{
						dronePart = ItemPrefabs.OfType<DroneComponent>().FirstOrDefault();
					}
					NimbatusItem nimbatusItem3 = InstantiateItem(dronePart);
					data.PrefabId = nimbatusItem3.UniqueId;
					nimbatusItem3.PreLoad();
					nimbatusItem3.Load(data);
					nimbatusItem3.PostLoad();
					return nimbatusItem3;
				}
			}
			return null;
		}

		public void UpdateWeaponPresets()
		{
			ItemPrefabs.RemoveAll((NimbatusItem i) => i is Weapon);
			foreach (WeaponPreset weaponPreset in WeaponPresets)
			{
				weaponPreset.RemoveIncompatibleUpgrades();
			}
			foreach (WeaponPreset weaponPreset2 in WeaponPresets)
			{
				NimbatusItem nimbatusItem = GenerateWeapon(weaponPreset2, WeaponTemplate);
				if (nimbatusItem != null)
				{
					nimbatusItem.Unlocked = true;
					UnityEngine.Object.DontDestroyOnLoad(nimbatusItem);
					ItemPrefabs.Add(nimbatusItem);
				}
			}
		}

		public DronePart GenerateTutorialWeapon(WeaponPreset preset, IWeapon weapontemplate, bool unlock = true)
		{
			preset.SetDefaultName();
			NimbatusItem nimbatusItem = GenerateWeapon(preset, weapontemplate);
			if (nimbatusItem != null)
			{
				if (unlock)
				{
					WeaponPresets.Add(preset);
				}
				nimbatusItem.Unlocked = unlock;
				UnityEngine.Object.DontDestroyOnLoad(nimbatusItem);
				ItemPrefabs.Add(nimbatusItem);
				return (DronePart)nimbatusItem;
			}
			return null;
		}

		public EnemyWeapon GetRandomEnemyWeapon(int seed, WeaponPreset preset)
		{
			return (EnemyWeapon)GenerateWeapon(WeaponPreset.Generate(seed, preset), EnemyWeaponTemplate);
		}

		public NimbatusItem GenerateAndAddWeapon(WeaponPreset preset)
		{
			if (!WeaponPresets.Exists((WeaponPreset wp) => wp.UniqueID == preset.UniqueID))
			{
				preset.RemoveIncompatibleUpgrades();
				NimbatusItem nimbatusItem = GenerateWeapon(preset, WeaponTemplate);
				if (nimbatusItem != null)
				{
					WeaponPresets.Add(preset);
					nimbatusItem.Unlocked = true;
					UnityEngine.Object.DontDestroyOnLoad(nimbatusItem.gameObject);
					ItemPrefabs.Add(nimbatusItem);
					return nimbatusItem;
				}
			}
			return null;
		}

		public NimbatusItem GenerateAndAddWeapon(WeaponPreset preset, IWeapon weapontemplate, bool unlock, bool randomName = false)
		{
			if (!WeaponPresets.Exists((WeaponPreset wp) => wp.UniqueID == preset.UniqueID))
			{
				preset.RemoveIncompatibleUpgrades();
				if (randomName)
				{
					preset.SetDefaultName();
				}
				NimbatusItem nimbatusItem = GenerateWeapon(preset, weapontemplate);
				if (nimbatusItem != null)
				{
					if (unlock)
					{
						WeaponPresets.Add(preset);
					}
					nimbatusItem.Unlocked = unlock;
					UnityEngine.Object.DontDestroyOnLoad(nimbatusItem.gameObject);
					ItemPrefabs.Add(nimbatusItem);
					return nimbatusItem;
				}
			}
			return null;
		}

		public NimbatusItem GenerateWeapon(WeaponPreset preset)
		{
			return GenerateWeapon(preset, WeaponTemplate);
		}

		private NimbatusItem GenerateWeapon(WeaponPreset preset, IWeapon weapontemplate)
		{
			if (preset.Emitter == null || preset.Ammunition == null)
			{
				return null;
			}
			NimbatusItem nimbatusItem = weapontemplate.Instantiate();
			nimbatusItem.gameObject.SetActive(true);
			nimbatusItem.Name = new TranslationTerm(preset.Name);
			nimbatusItem.UniqueId = preset.UniqueID;
			nimbatusItem.WasGenerated = true;
			nimbatusItem.PreLoad();
			if (SaveManager.LoadedSave.Settings.HasPartUnlocking)
			{
				nimbatusItem.IsStackable = true;
				nimbatusItem.CurrentStackSize = preset.StackSize;
			}
			else
			{
				nimbatusItem.IsStackable = false;
			}
			if (nimbatusItem is IWeapon)
			{
				(nimbatusItem as IWeapon).ApplyWeaponPreset(preset);
			}
			nimbatusItem.PostLoad();
			nimbatusItem.gameObject.SetActive(false);
			return nimbatusItem;
		}

		public T GetRandomItem<T>(int seed) where T : NimbatusItem
		{
			return ItemPrefabs.OfType<T>().ToList().RandomItemSeed(seed);
		}

		public T GetRandomItem<T>(System.Random rnd) where T : NimbatusItem
		{
			return ItemPrefabs.OfType<T>().ToList().RandomItem(rnd);
		}

		public T GetItemById<T>(string id) where T : NimbatusItem
		{
			return ItemPrefabs.FirstOrDefault((NimbatusItem i) => i.UniqueId == id) as T;
		}

		public void Lock(NimbatusItem item)
		{
			item.Unlocked = false;
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Save();
		}

		public void Unlock(NimbatusItem item)
		{
			item.Unlocked = true;
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Save();
		}

		public void RemovePreset(WeaponPreset preset)
		{
			ItemPrefabs.RemoveAll((NimbatusItem p) => p.UniqueId == preset.UniqueID);
			WeaponPresets.Remove(preset);
		}

		protected override void LoadFromFile(ItemManagerSaveData data)
		{
			foreach (string item in data.UnlockedItems)
			{
				NimbatusItem nimbatusItem = ItemPrefabs.FirstOrDefault((NimbatusItem x) => x.UniqueId == item);
				if (nimbatusItem != null)
				{
					nimbatusItem.Unlocked = true;
				}
			}
			foreach (ItemStack item2 in data.StackedItems)
			{
				NimbatusItem nimbatusItem2 = ItemPrefabs.FirstOrDefault((NimbatusItem x) => x.UniqueId == item2.ItemId);
				if (nimbatusItem2 != null)
				{
					nimbatusItem2.SetStackSize(item2.StackSize);
				}
			}
			foreach (WeaponPresetData weaponPreset2 in data.WeaponPresets)
			{
				WeaponPreset weaponPreset = new WeaponPreset();
				weaponPreset.Load(weaponPreset2);
				GenerateAndAddWeapon(weaponPreset, WeaponTemplate, true);
			}
			_starterSetUnlocked = data.StarterSetUnlocked;
		}

		protected override ItemManagerSaveData SaveToFile()
		{
			ItemManagerSaveData itemManagerSaveData = new ItemManagerSaveData();
			foreach (NimbatusItem item in ItemPrefabs.Where((NimbatusItem item) => item.Unlocked))
			{
				itemManagerSaveData.UnlockedItems.Add(item.UniqueId);
			}
			foreach (NimbatusItem item2 in ItemPrefabs.Where((NimbatusItem item) => item.IsStackable))
			{
				itemManagerSaveData.StackedItems.Add(new ItemStack
				{
					ItemId = item2.UniqueId,
					StackSize = item2.CurrentStackSize
				});
			}
			foreach (WeaponPreset weaponPreset in WeaponPresets)
			{
				itemManagerSaveData.WeaponPresets.Add(weaponPreset.Save());
			}
			itemManagerSaveData.StarterSetUnlocked = _starterSetUnlocked;
			return itemManagerSaveData;
		}

		public List<NimbatusItem> GetBuyableDroneParts(EDronePartType partType, int amount, System.Random rng)
		{
			List<DronePart> list = (from dp in ItemPrefabs.OfType<DronePart>()
				where (dp.DronePartType == partType || partType == EDronePartType.None) && !dp.DoNotImport && !dp.WasGenerated
				select dp).ToList();
			list.Shuffle(rng);
			return new List<NimbatusItem>(list.Take(amount).ToList());
		}
	}
}
