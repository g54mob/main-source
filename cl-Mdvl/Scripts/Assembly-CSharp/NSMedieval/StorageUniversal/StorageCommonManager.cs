using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	public class StorageCommonManager : MonoSingleton<StorageCommonManager>
	{
		private readonly Dictionary<ZonePriority, HashSet<IStorage>> storages = new Dictionary<ZonePriority, HashSet<IStorage>>();

		private readonly HashSet<IStorage> allStorages = new HashSet<IStorage>();

		private readonly Dictionary<UnityEngine.Resources, List<IStorage>> storageByResource = new Dictionary<UnityEngine.Resources, List<IStorage>>();

		public IStorage CopiedStorage { get; private set; }

		public HashSet<IStorage> AllStorages => allStorages;

		public void OnCopyStorage(IStorage storage)
		{
			CopiedStorage = storage;
		}

		public void ClearCopiedStorage()
		{
			CopiedStorage = null;
		}

		public void PasteStorageSettingsTo(IStorage storage)
		{
			if (CopiedStorage?.ResourcesFilter != null && storage != CopiedStorage)
			{
				storage.PasteStorageSettings(CopiedStorage);
				storage.SetPriority(CopiedStorage.Priority);
			}
		}

		public void PasteStorageSettingsTo(IEnumerable<IStorage> storages)
		{
			if (CopiedStorage?.ResourcesFilter == null)
			{
				return;
			}
			foreach (IStorage storage in storages)
			{
				if (storage != CopiedStorage)
				{
					storage.PasteStorageSettings(CopiedStorage);
					storage.SetPriority(CopiedStorage.Priority);
				}
			}
		}

		public void RegisterStorage(IStorage storage, bool autoRemove = true)
		{
			if (storage == null)
			{
				Log.Warning("Tried to register null storage! This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\StorageCommonManager.cs");
				return;
			}
			bool isEnabled;
			if (storage.HasDisposed)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\StorageCommonManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to register disposed storage @ ");
					messageBuilder.AppendFormatted(storage.GetGridPosition());
				}
				Log.Warning(messageBuilder);
				return;
			}
			if (storage.Priority == ZonePriority.None || storage.Priority == ZonePriority.Last)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\StorageCommonManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Found storage with invalid priority ");
					messageBuilder.AppendFormatted(storage.Priority);
					messageBuilder.AppendLiteral(" storage:");
					messageBuilder.AppendFormatted(storage);
					messageBuilder.AppendLiteral(". Resetting to Priority LOW ");
				}
				Log.Warning(messageBuilder);
				storage.SetPriority(ZonePriority.Low);
			}
			if (storages[storage.Priority].Add(storage) && autoRemove)
			{
				storage.OnDisposedEvent += delegate(IGameDisposable disposable)
				{
					RemoveStorage((IStorage)disposable);
				};
			}
			if (storage.ResourcesFilter != null)
			{
				storage.ResourcesFilter.OnParamsChangedEvent += OnStorageChanged;
			}
			else
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\StorageCommonManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Registered storage without filter! Check this! ");
					messageBuilder2.AppendFormatted(storage);
				}
				Log.Error(messageBuilder2);
			}
			allStorages.Add(storage);
			MonoSingleton<ResourcePileHaulingManager>.Instance.TriggerLazyReProcessAll();
		}

		public void OnPriorityChanged(IStorage storage, ZonePriority oldPriority)
		{
			if (storages.ContainsKey(oldPriority))
			{
				storages[oldPriority].Remove(storage);
			}
			storages[storage.Priority].Add(storage);
			OnStorageChanged();
		}

		public void RemoveStorage(IStorage storage)
		{
			if (storage.ResourcesFilter != null)
			{
				storage.ResourcesFilter.OnParamsChangedEvent -= OnStorageChanged;
			}
			storages[storage.Priority].Remove(storage);
			allStorages.Remove(storage);
			MonoSingleton<ResourcePileHaulingManager>.Instance.TriggerLazyReProcessAll();
		}

		public IStorage FindViableStorage(ResourceInstance resource, ZonePriority minPriority, Func<IStorage, bool> condition)
		{
			for (int num = 4; num > (int)minPriority; num--)
			{
				foreach (IStorage item in storages[(ZonePriority)num])
				{
					if (item.CanStore(resource) && (condition == null || condition(item)))
					{
						return item;
					}
				}
			}
			return null;
		}

		public IStorage FindViableStorage(ResourceInstance resource, Func<IStorage, bool> condition)
		{
			return FindViableStorage(resource, ZonePriority.None, condition);
		}

		public bool FindViableStorages(ResourceInstance resource, Func<IStorage, bool> condition, Action<IStorage> onFound)
		{
			bool flag = false;
			for (int num = 4; num > 0; num--)
			{
				foreach (IStorage item in storages[(ZonePriority)num])
				{
					if (item.CanStore(resource) && (condition == null || condition(item)))
					{
						flag = true;
						onFound(item);
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public bool CanStoreAnywhere(ResourceInstance resource)
		{
			foreach (KeyValuePair<ZonePriority, HashSet<IStorage>> storage in storages)
			{
				foreach (IStorage item in storage.Value)
				{
					if (item.CanStore(resource))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void ReleaseAllStorageReservations(CreatureBase agent)
		{
			foreach (KeyValuePair<ZonePriority, HashSet<IStorage>> storage in storages)
			{
				foreach (IStorage item in storage.Value)
				{
					item.ReleaseReservations(agent);
				}
			}
		}

		private void OnStorageChanged()
		{
			MonoSingleton<ResourcePileHaulingManager>.Instance.TriggerLazyReProcessAll();
		}

		private void Start()
		{
			for (int i = 1; i < 5; i++)
			{
				storages[(ZonePriority)i] = new HashSet<IStorage>();
			}
		}

		protected override void OnDestroy()
		{
			allStorages.Clear();
			storages.Clear();
			base.OnDestroy();
		}
	}
}
