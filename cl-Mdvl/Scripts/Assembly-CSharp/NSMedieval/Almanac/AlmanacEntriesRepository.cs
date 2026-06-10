using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI;
using NSMedieval.UI.Utils;

namespace NSMedieval.Almanac
{
	public class AlmanacEntriesRepository : DynamicJsonRepository<AlmanacEntriesRepository, AlmanacEntry>
	{
		private const bool GenerateEntriesOnThread = true;

		private Thread generateEntriesThread;

		private bool initFinished;

		private object padlock = new object();

		[NonSerialized]
		private Dictionary<string, AlmanacEntry> allEntries;

		public bool InitFinished
		{
			get
			{
				lock (padlock)
				{
					return initFinished;
				}
			}
			private set
			{
				lock (padlock)
				{
					initFinished = value;
				}
			}
		}

		public Dictionary<string, AlmanacEntry> AllEntries
		{
			get
			{
				if (allEntries.Count == 0)
				{
					Log.Error("AllEntries getter called before initialization thread finished.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacEntriesRepository.cs");
				}
				return allEntries;
			}
		}

		protected override void Initialize()
		{
			base.Initialize();
			TryInitEntries();
			MonoSingleton<OptionsController>.Instance.LanguageChangedEvent += OnLanguageChanged;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.LanguageChangedEvent -= OnLanguageChanged;
			}
		}

		private void OnLanguageChanged()
		{
			if (GlobalSaveController.CurrentVillageData == null)
			{
				Log.Debug("No Village Data loaded. Skipping initialization on Home scene.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacEntriesRepository.cs");
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingHome;
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnLeavingHome;
			}
			else
			{
				ReInitEntries();
			}
		}

		private void OnLeavingHome()
		{
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingHome;
			ReInitEntries();
		}

		private void ReInitEntries()
		{
			ClearEntries();
			TryInitEntries();
		}

		public void ClearEntries()
		{
			allEntries = null;
		}

		public void OnTemperatureUnitsChange()
		{
			ClearEntries();
			TryInitEntries();
		}

		protected override string JsonFile()
		{
			return "Almanac/AlmanacEntries.json";
		}

		public AlmanacEntry GetByName(string name)
		{
			if (AllEntries.ContainsKey(name))
			{
				return AllEntries[name];
			}
			return GetAllItems().FirstOrDefault((AlmanacEntry ae) => ae.Name.Equals(name));
		}

		public AlmanacEntry GetTutorialEntry(string entryId)
		{
			if (!AllEntries.ContainsKey(entryId))
			{
				return null;
			}
			AlmanacEntry almanacEntry = allEntries[entryId];
			if (almanacEntry.GroupId != "Gameplaytips")
			{
				return null;
			}
			return almanacEntry;
		}

		private void TryInitEntries()
		{
			if (allEntries == null)
			{
				InitFinished = false;
				allEntries = new Dictionary<string, AlmanacEntry>();
				if (generateEntriesThread != null)
				{
					Log.Debug("Aborting the almanac thread", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacEntriesRepository.cs");
					generateEntriesThread.Abort();
					generateEntriesThread = null;
				}
				generateEntriesThread = new Thread((ThreadStart)delegate
				{
					Log.Debug("*** *** Starting almanac entries init thread.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacEntriesRepository.cs");
					GenerateEntries();
					Log.Debug("*** *** Finished almanac entries init thread.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Almanac\\AlmanacEntriesRepository.cs");
				});
				generateEntriesThread.Start();
			}
		}

		private void GenerateEntries()
		{
			while (!CanStartThread())
			{
				if (MonoSingleton<LoadingController>.IsApplicationIsQuitting())
				{
					return;
				}
			}
			foreach (AlmanacEntry entry in AlmanacUtils.GetEntries())
			{
				if (entry != null)
				{
					allEntries[entry.Name] = entry;
				}
			}
			foreach (AlmanacEntry allItem in GetAllItems())
			{
				if (allItem != null)
				{
					allEntries[allItem.GetID()] = allItem;
				}
			}
			InitFinished = true;
		}

		private bool CanStartThread()
		{
			if (!MonoRepository<TextureRepository, KeyTexturePair>.InstanceInit || !MonoRepository<PrefabRepository, KeyGameObjectPair>.InstanceInit || !MonoSingleton<RepositoryManager>.IsInstantiated() || !MonoSingleton<RepositoryManager>.Instance.IsInitialized() || !Repository<AlmanacRepository, Almanac>.IsInstantiated() || !MonoRepository<SpriteRepository, KeySpritePair>.InstanceInit || !MonoRepository<SpriteAssetRepository, KeySpriteAssetPair>.InstanceInit)
			{
				return false;
			}
			return true;
		}
	}
}
