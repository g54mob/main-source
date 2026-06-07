using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCreator.Runtime.Common.SaveSystem;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[DefaultExecutionOrder(51)]
	[AddComponentMenu("")]
	public class SaveLoadManager : Singleton<SaveLoadManager>
	{
		private struct Reference
		{
			public IGameSave reference;

			public int priority;
		}

		private struct Value
		{
			public object value;

			public bool isShared;
		}

		private const int SLOT_MIN = 1;

		private const int SLOT_MAX = 9999;

		private const string DB_KEY_FORMAT = "data-{0:D4}-{1}";

		[NonSerialized]
		private Scenes m_Scenes;

		[NonSerialized]
		private Slots m_Slots;

		[NonSerialized]
		private Dictionary<string, Reference> m_Subscriptions;

		[NonSerialized]
		private Dictionary<string, Value> m_Values;

		[NonSerialized]
		private Dictionary<string, Value> m_ResetGreed;

		[field: NonSerialized]
		public int SlotLoaded { get; private set; } = -1;

		public bool IsGameLoaded => SlotLoaded > 0;

		[field: NonSerialized]
		public bool IsSaving { get; private set; }

		[field: NonSerialized]
		public bool IsLoading { get; private set; }

		[field: NonSerialized]
		public bool IsDeleting { get; private set; }

		[field: NonSerialized]
		public IDataEncryption DataEncryption { get; private set; }

		[field: NonSerialized]
		public IDataStorage DataStorage { get; private set; }

		public float Progress => m_Scenes.Progress;

		public event Action<int> EventBeforeSave;

		public event Action<int> EventAfterSave;

		public event Action<int> EventBeforeLoad;

		public event Action<int> EventAfterLoad;

		public event Action<int> EventBeforeDelete;

		public event Action<int> EventAfterDelete;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		protected static void InitializeOnLoad()
		{
			Singleton<SaveLoadManager>.Instance.WakeUp();
		}

		protected override void OnCreate()
		{
			base.OnCreate();
			DataStorage = TRepository<GeneralRepository>.Get.Save?.Storage ?? new StoragePlayerPrefs();
			DataEncryption = TRepository<GeneralRepository>.Get.Save?.Encryption ?? new EncryptionNone();
			DataStorage.WithEncryption(DataEncryption);
			m_Subscriptions = new Dictionary<string, Reference>();
			m_Values = new Dictionary<string, Value>();
			m_ResetGreed = new Dictionary<string, Value>();
			m_Scenes = new Scenes();
			m_Slots = new Slots();
			Subscribe(m_Scenes, 100);
			Subscribe(m_Slots, 100);
		}

		public static async Task Subscribe(IGameSave reference, int priority = 0)
		{
			if (ApplicationManager.IsExiting)
			{
				return;
			}
			Singleton<SaveLoadManager>.Instance.m_Subscriptions[reference.SaveID] = new Reference
			{
				reference = reference,
				priority = priority
			};
			if (reference.LoadMode == LoadMode.Greedy && !reference.IsShared)
			{
				Singleton<SaveLoadManager>.Instance.m_ResetGreed[reference.SaveID] = new Value
				{
					value = reference.GetSaveData(includeNonSavable: true),
					isShared = false
				};
			}
			switch (reference.LoadMode)
			{
			case LoadMode.Lazy:
			{
				if (Singleton<SaveLoadManager>.Instance.m_Values.TryGetValue(reference.SaveID, out var value))
				{
					await reference.OnLoad(value.value);
				}
				else if (Singleton<SaveLoadManager>.Instance.IsGameLoaded)
				{
					await Singleton<SaveLoadManager>.Instance.LoadItem(reference, Singleton<SaveLoadManager>.Instance.SlotLoaded);
				}
				break;
			}
			case LoadMode.Greedy:
				if (reference.IsShared)
				{
					await Singleton<SaveLoadManager>.Instance.LoadItem(reference, 0);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public static void Unsubscribe(IGameSave reference)
		{
			if (!ApplicationManager.IsExiting)
			{
				Singleton<SaveLoadManager>.Instance.m_Subscriptions.Remove(reference.SaveID);
				if (!Singleton<SaveLoadManager>.Instance.IsLoading)
				{
					Singleton<SaveLoadManager>.Instance.m_Values[reference.SaveID] = new Value
					{
						value = reference.GetSaveData(includeNonSavable: false),
						isShared = reference.IsShared
					};
				}
			}
		}

		public bool HasSave()
		{
			return m_Slots.Count > 0;
		}

		public bool HasSaveAt(int slot)
		{
			return m_Slots.ContainsKey(slot);
		}

		public string GetSaveDate(int slot)
		{
			if (!m_Slots.TryGetValue(slot, out var value))
			{
				return string.Empty;
			}
			return value.date;
		}

		public async Task Save(int slot)
		{
			if (IsSaving || IsLoading || IsDeleting)
			{
				return;
			}
			this.EventBeforeSave?.Invoke(slot);
			IsSaving = true;
			foreach (KeyValuePair<string, Reference> subscription in m_Subscriptions)
			{
				if (subscription.Value.reference != null)
				{
					m_Values[subscription.Value.reference.SaveID] = new Value
					{
						value = subscription.Value.reference.GetSaveData(includeNonSavable: false),
						isShared = subscription.Value.reference.IsShared
					};
				}
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, Value> value in m_Values)
			{
				if (!value.Value.isShared)
				{
					list.Add(value.Key);
				}
			}
			m_Slots.Update(slot, list.ToArray());
			foreach (KeyValuePair<string, Value> value2 in m_Values)
			{
				string key = DatabaseKey(slot, value2.Value.isShared, value2.Key);
				await DataStorage.Set(key, value2.Value.value);
			}
			await DataStorage.Commit();
			IsSaving = false;
			this.EventAfterSave?.Invoke(slot);
		}

		public async Task Load(int slot, Action callback = null)
		{
			if (IsSaving || IsLoading || IsDeleting || !HasSaveAt(slot))
			{
				return;
			}
			this.EventBeforeLoad?.Invoke(slot);
			IsLoading = true;
			SlotLoaded = slot;
			m_Values.Clear();
			List<Reference> references = m_Subscriptions.Values.ToList();
			references.Sort((Reference a, Reference b) => b.priority.CompareTo(a.priority));
			int i = 0;
			while (i < references.Count)
			{
				IGameSave item = references[i].reference;
				if (item != null && !(item.SaveID == "scenes"))
				{
					if (item.LoadMode == LoadMode.Lazy)
					{
						await LoadItem(item, slot);
					}
					else
					{
						await ResetItem(item);
						await LoadItem(item, slot);
					}
				}
				int num = i + 1;
				i = num;
			}
			IsLoading = false;
			callback?.Invoke();
			this.EventAfterLoad?.Invoke(slot);
		}

		public async Task LoadLatest(Action callback = null)
		{
			int latestSlot = m_Slots.LatestSlot;
			if (latestSlot >= 0)
			{
				await Load(latestSlot, callback);
			}
		}

		public async Task Delete(int slot)
		{
			if (IsSaving || IsLoading || IsDeleting)
			{
				return;
			}
			this.EventBeforeDelete?.Invoke(slot);
			IsDeleting = true;
			if (m_Slots.TryGetValue(slot, out var data))
			{
				int i = data.keys.Length - 1;
				while (i >= 0)
				{
					string key = DatabaseKey(slot, isShared: false, data.keys[i]);
					await DataStorage.DeleteKey(key);
					int num = i - 1;
					i = num;
				}
				m_Slots.Remove(slot);
				string key2 = DatabaseKey(slot, m_Slots.IsShared, m_Slots.SaveID);
				await DataStorage.Set(key2, m_Slots.GetSaveData(includeNonSavable: false));
			}
			await DataStorage.Commit();
			IsDeleting = false;
			this.EventAfterDelete?.Invoke(slot);
		}

		public async Task Restart(int sceneIndex, Action callback = null)
		{
			if (IsSaving || IsLoading || IsDeleting)
			{
				return;
			}
			this.EventBeforeLoad?.Invoke(-1);
			IsLoading = true;
			SlotLoaded = -1;
			m_Values.Clear();
			List<Reference> references = m_Subscriptions.Values.ToList();
			references.Sort((Reference a, Reference b) => b.priority.CompareTo(a.priority));
			int i = 0;
			while (i < references.Count)
			{
				IGameSave reference = references[i].reference;
				if (reference != null && !(reference.SaveID == "scenes") && reference.LoadMode != LoadMode.Lazy && !reference.IsShared)
				{
					await ResetItem(references[i].reference);
				}
				int num = i + 1;
				i = num;
			}
			IsLoading = false;
			callback?.Invoke();
			this.EventAfterLoad?.Invoke(-1);
		}

		private async Task LoadItem(IGameSave reference, int slot)
		{
			string key = DatabaseKey(slot, reference.IsShared, reference.SaveID);
			await reference.OnLoad(await DataStorage.Get(key, reference.SaveType));
		}

		private async Task ResetItem(IGameSave reference)
		{
			if (m_ResetGreed.TryGetValue(reference.SaveID, out var value) && !(reference.SaveID == "scenes"))
			{
				await reference.OnLoad(value.value);
			}
		}

		private static string DatabaseKey(int slot, bool isShared, string key)
		{
			slot = ((!isShared) ? Mathf.Clamp(slot, 1, 9999) : 0);
			return $"data-{slot:D4}-{key}";
		}
	}
}
