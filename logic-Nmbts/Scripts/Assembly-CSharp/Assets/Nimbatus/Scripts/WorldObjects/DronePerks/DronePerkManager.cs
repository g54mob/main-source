using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks
{
	public class DronePerkManager : SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>
	{
		private string _selectedPerkId;

		public List<DroneEffectSetting> AllEffectSettings = new List<DroneEffectSetting>();

		private List<DronePerk> _perks = new List<DronePerk>();

		public DronePerk ActivePerk { get; private set; }

		public List<DroneEffect> ActiveEffects { get; private set; }

		internal override string Filename
		{
			get
			{
				return "Perks.xml";
			}
		}

		protected override void Awake()
		{
			base.Awake();
			AllEffectSettings = Resources.LoadAll("DroneEffects", typeof(DroneEffectSetting)).OfType<DroneEffectSetting>().ToList();
			_perks = Resources.LoadAll("Captains", typeof(DronePerk)).OfType<DronePerk>().ToList();
		}

		public void PreparePerk(string id)
		{
			_selectedPerkId = id;
		}

		public void ActivatePerk(string id)
		{
			if (ActiveEffects == null)
			{
				ActiveEffects = new List<DroneEffect>();
			}
			ActivePerk = _perks.FirstOrDefault((DronePerk p) => p.UniqueId == id);
			if (ActivePerk != null && ActivePerk.Effects != null && ActiveEffects.Count < 1)
			{
				foreach (DroneEffectSetting effect in ActivePerk.Effects)
				{
					AddEffect(effect.Effect);
				}
			}
			RuntimeGlobals.InitDronePerkSettings();
			if (ActivePerk != null)
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UnlockStarterSet(ActivePerk.StarterSet);
			}
		}

		public void OverwritePerk()
		{
			RuntimeGlobals.GameModeSettings.DronePerkId = _selectedPerkId;
			if (GetPerk(_selectedPerkId).StarterSet.AllPartsUnlocked)
			{
				RuntimeGlobals.GameModeSettings.ShowAllDroneParts = true;
				RuntimeGlobals.GameModeSettings.HasPartUnlocking = false;
				RuntimeGlobals.GameModeSettings.DeployCost = false;
			}
			ResetPerk();
			ActivatePerk(_selectedPerkId);
		}

		public void ResetPerk()
		{
			ActivePerk = null;
			ActiveEffects = null;
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.ResetAllItems();
		}

		public DronePerk GetPerk(string id)
		{
			return _perks.FirstOrDefault((DronePerk p) => p.UniqueId == id);
		}

		public IEnumerable<DronePerk> GetAllPerks(bool includeHidden = false)
		{
			return _perks.Where((DronePerk p) => !p.Hidden);
		}

		public IEnumerable<DronePerk> GetHiddenPerks()
		{
			return _perks.Where((DronePerk p) => p.Hidden);
		}

		public bool HasEffect(EEffectType type)
		{
			return ActiveEffects.Any((DroneEffect e) => e.EffectType == type);
		}

		public void AddEffect(EEffectType type)
		{
			DroneEffectSetting droneEffectSetting = AllEffectSettings.FirstOrDefault((DroneEffectSetting e) => e.Effect.EffectType == type);
			if (!(droneEffectSetting == null))
			{
				AddEffect(droneEffectSetting.Effect);
			}
		}

		public void AddEffect(DroneEffect effect)
		{
			ActiveEffects.Add(effect);
			RuntimeGlobals.InitDronePerkSettings();
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UpdateItems();
		}

		public void RemoveEffectOfType(EEffectType type)
		{
			DroneEffect droneEffect = ActiveEffects.FirstOrDefault((DroneEffect e) => e.EffectType == type);
			if (droneEffect != null)
			{
				ActiveEffects.Remove(droneEffect);
				RuntimeGlobals.InitDronePerkSettings();
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UpdateItems();
			}
		}

		protected override void PreLoad()
		{
			ActivePerk = null;
			ActiveEffects = null;
			if (_selectedPerkId != null)
			{
				ActivatePerk(_selectedPerkId);
				_selectedPerkId = null;
			}
			else
			{
				ActivatePerk("");
			}
		}

		protected override void LoadFromFile(DronePerkManagerData data)
		{
			ActiveEffects = data.ActiveEffects;
			ActivatePerk(data.ActivePerkId);
		}

		protected override DronePerkManagerData SaveToFile()
		{
			return new DronePerkManagerData
			{
				ActivePerkId = ((ActivePerk != null) ? ActivePerk.UniqueId : ""),
				ActiveEffects = ActiveEffects
			};
		}
	}
}
