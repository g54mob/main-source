using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DV.Common;
using DV.JObjectExtstensions;
using DV.Scenarios.Common;
using DV.UserManagement.Storage;
using DV.Util;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public class ScenarioCRUD : IScenarioCRUD
	{
		private IStorageProvider storage;

		private CollectionManager manager;

		private ThingCollection<ITrain> trainCollection;

		private ThingCollection<IScenario> scenarioCollection;

		private ThingCollection<IDifficulty> difficultyCollection;

		private List<ITrain> predefinedTrains;

		private List<IScenario> predefinedScenarios;

		private List<IDifficulty> predefinedDifficulties;

		private AJSONDataUpgrader[] trainUpgraders;

		private AJSONDataUpgrader[] scenarioUpgraders;

		private AJSONDataUpgrader[] difficultyUpgraders;

		private Dictionary<string, string> difficultyPresetRemappings;

		private readonly Dictionary<string, string> defaultDifficultyPresetRemappings = new Dictionary<string, string>();

		public ObservableCollectionExt<ITrain> Trains => trainCollection.C;

		public ObservableCollectionExt<IScenario> Scenarios => scenarioCollection.C;

		public ObservableCollectionExt<IDifficulty> Difficulties => difficultyCollection.C;

		public string BaseStoragePath { get; private set; }

		public ScenarioCRUD(IStorageProvider storage, AJSONDataUpgrader[] scenarioUpgraders = null, AJSONDataUpgrader[] trainUpgraders = null, AJSONDataUpgrader[] difficultyUpgraders = null, Dictionary<string, string> difficultyPresetRemappings = null, List<IScenario> predefinedScenarios = null, List<ITrain> predefinedTrains = null, List<IDifficulty> predefinedDifficulties = null, Dictionary<string, string> scenarioLocalization = null, Dictionary<string, string> trainLocalization = null, Dictionary<string, string> difficultyLocalization = null)
		{
			this.storage = storage;
			this.scenarioUpgraders = scenarioUpgraders ?? Array.Empty<AJSONDataUpgrader>();
			this.trainUpgraders = trainUpgraders ?? Array.Empty<AJSONDataUpgrader>();
			this.difficultyUpgraders = difficultyUpgraders ?? Array.Empty<AJSONDataUpgrader>();
			this.difficultyPresetRemappings = difficultyPresetRemappings ?? defaultDifficultyPresetRemappings;
			BaseStoragePath = storage.GetFilesystemPath("");
			manager = new CollectionManager();
			trainCollection = new TrainCollection("Train", manager, trainLocalization);
			scenarioCollection = new ScenarioCollection("Scenario", manager, scenarioLocalization);
			difficultyCollection = new DifficultyCollection("Difficulty", manager, difficultyLocalization);
			manager.AddCollection(trainCollection);
			manager.AddCollection(scenarioCollection);
			manager.AddCollection(difficultyCollection);
			this.predefinedTrains = predefinedTrains ?? new List<ITrain>();
			this.predefinedScenarios = predefinedScenarios ?? new List<IScenario>();
			this.predefinedDifficulties = predefinedDifficulties ?? new List<IDifficulty>();
			int num = this.predefinedTrains.Count((ITrain t) => t == null);
			int num2 = this.predefinedScenarios.Count((IScenario s) => s == null);
			int num3 = this.predefinedDifficulties.Count((IDifficulty d) => d == null);
			if (num2 > 0 || num > 0 || num3 > 0)
			{
				Debug.LogError($"Predefined scenarios, trains or difficulties contain null values, those will be filtered out ({num2} null Scenarios, {num} null Trains, {num3} null Difficulties)");
				this.predefinedScenarios.RemoveAll((IScenario s) => s == null);
				this.predefinedTrains.RemoveAll((ITrain t) => t == null);
				this.predefinedDifficulties.RemoveAll((IDifficulty d) => d == null);
			}
			int num4 = this.predefinedTrains.Distinct().Count();
			int num5 = this.predefinedScenarios.Distinct().Count();
			int num6 = this.predefinedDifficulties.Distinct().Count();
			if (num5 != this.predefinedScenarios.Count || num4 != this.predefinedTrains.Count || num6 != this.predefinedDifficulties.Count)
			{
				Debug.LogError($"Predefined scenarios, trains or difficulties contain duplicate values, those will be filtered out ({this.predefinedScenarios.Count - num5} duplicate Scenarios, {this.predefinedTrains.Count - num4} duplicate Trains, {this.predefinedDifficulties.Count - num6} duplicate Difficulties)");
				this.predefinedScenarios = this.predefinedScenarios.Distinct().ToList();
				this.predefinedTrains = this.predefinedTrains.Distinct().ToList();
				this.predefinedDifficulties = this.predefinedDifficulties.Distinct().ToList();
			}
			List<string> list = (from t in this.predefinedTrains
				group t by t.Name into g
				where g.Count() > 1
				select g.Key).ToList();
			List<string> list2 = (from s in this.predefinedScenarios
				group s by s.Name into g
				where g.Count() > 1
				select g.Key).ToList();
			List<string> list3 = (from d in this.predefinedDifficulties
				group d by d.Name into g
				where g.Count() > 1
				select g.Key).ToList();
			if (list2.Count > 0 || list.Count > 0 || list3.Count > 0)
			{
				List<string> values = list2.Concat(list).Concat(list3).ToList();
				Debug.LogError("There are multiple scenarios/trains/difficulties with same name, those will NOT be filtered out (" + string.Join(", ", values) + ")");
			}
			Reload();
		}

		public static string GetUniqueName(string name, IEnumerable<string> existingNames)
		{
			if (!existingNames.Contains(name))
			{
				return name;
			}
			Match match = Regex.Match(name, "\\(([0-9]{1,6})\\)$");
			int num = 1;
			if (match.Success)
			{
				name = name.Substring(0, name.Length - match.Value.Length).TrimEnd();
				num = int.Parse(match.Groups[1].Value);
			}
			string text;
			while (true)
			{
				text = name + " (" + num + ")";
				if (!existingNames.Contains(text))
				{
					break;
				}
				num++;
			}
			return text;
		}

		private IList<T> EnsureNameUniqueness<T>(IList<T> newItems, IList<T> baseItems) where T : class, IScenariosThing
		{
			IList<T> list = new List<T>();
			HashSet<string> hashSet = new HashSet<string>(baseItems.Select((T i) => i.Name));
			List<T> list2 = new List<T>();
			foreach (T newItem in newItems)
			{
				if (!string.IsNullOrEmpty(newItem.Name) && !hashSet.Add(newItem.Name))
				{
					list2.Add(newItem);
				}
			}
			foreach (T item in list2)
			{
				string uniqueName = GetUniqueName(item.Name, hashSet);
				Debug.Log("[CRUD] Duplicate name detected: " + item.Name + ", renaming to " + uniqueName + " (" + typeof(T).Name + ")");
				item.Name = uniqueName;
				item.SyncState = SyncState.Modified;
				hashSet.Add(uniqueName);
				list.Add(item);
			}
			return list;
		}

		public static int GetCurrentDataVersion(AJSONDataUpgrader[] upgraders)
		{
			if (upgraders == null || upgraders.Length == 0)
			{
				return 1;
			}
			return upgraders.Last().InputVersion + 1;
		}

		public int GetCurrentDifficultyDataVersion()
		{
			return GetCurrentDataVersion(difficultyUpgraders);
		}

		public int GetCurrentScenarioDataVersion()
		{
			return GetCurrentDataVersion(scenarioUpgraders);
		}

		public int GetCurrentTrainDataVersion()
		{
			return GetCurrentDataVersion(trainUpgraders);
		}

		public int GetCurrentThingDataVersion<T>() where T : IScenariosThing
		{
			return GetCurrentThingDataVersion(typeof(T));
		}

		public int GetCurrentThingDataVersion(IThing thing)
		{
			if (thing != null)
			{
				return GetCurrentThingDataVersion(thing.GetType());
			}
			return 0;
		}

		public int GetCurrentThingDataVersion(Type thingType)
		{
			if (thingType == null)
			{
				return 0;
			}
			if (typeof(IDifficulty).IsAssignableFrom(thingType))
			{
				return GetCurrentDifficultyDataVersion();
			}
			if (typeof(IScenario).IsAssignableFrom(thingType))
			{
				return GetCurrentScenarioDataVersion();
			}
			if (typeof(ITrain).IsAssignableFrom(thingType))
			{
				return GetCurrentTrainDataVersion();
			}
			return 0;
		}

		public void Reload()
		{
			manager.ClearAll();
			Trains.AddRange(predefinedTrains);
			Scenarios.AddRange(predefinedScenarios);
			Difficulties.AddRange(predefinedDifficulties);
			List<string> predefinedThingNames = predefinedTrains.Select((ITrain t) => t.Name).ToList();
			List<string> predefinedThingNames2 = predefinedScenarios.Select((IScenario s) => s.Name).ToList();
			List<string> predefinedThingNames3 = predefinedDifficulties.Select((IDifficulty d) => d.Name).ToList();
			manager.FixData();
			foreach (Thing train in Trains)
			{
				train.IsReadOnly = true;
			}
			foreach (Thing scenario2 in Scenarios)
			{
				scenario2.IsReadOnly = true;
			}
			foreach (Thing difficulty in Difficulties)
			{
				difficulty.IsReadOnly = true;
			}
			List<IScenario> list = (from s in storage.ListFiles("", "*.dvscenario").Select(ScenarioFromFilename)
				where s != null
				select s).ToList();
			List<ITrain> list2 = (from t in storage.ListFiles("", "*.dvtrain").Select(TrainFromFilename)
				where t != null
				select t).ToList();
			List<IDifficulty> list3 = (from d in storage.ListFiles("", "*.dvdifficulty").Select(DifficultyFromFilename)
				where d != null
				select d).ToList();
			RemoveClashingWithPredefined(list2, predefinedThingNames);
			RemoveClashingWithPredefined(list, predefinedThingNames2);
			RemoveClashingWithPredefined(list3, predefinedThingNames3);
			List<IThing> list4 = new List<IThing>();
			list4.AddRange(EnsureNameUniqueness(list, Scenarios));
			list4.AddRange(EnsureNameUniqueness(list2, Trains));
			list4.AddRange(EnsureNameUniqueness(list3, Difficulties));
			foreach (IThing item2 in list4)
			{
				if (item2 is IScenariosThing ithing)
				{
					Flush(ithing);
				}
			}
			Trains.AddRange(list2);
			Scenarios.AddRange(list);
			Difficulties.AddRange(list3);
			manager.FixData();
			int count = Scenarios.Count;
			while (true)
			{
				IScenario scenario = Scenarios.FirstOrDefault((IScenario s) => !Trains.Any((ITrain t) => t == s.Train));
				if (scenario == null)
				{
					break;
				}
				ITrain item = FindMatch(scenario.Train, Trains).matchedThing;
				if (item != null)
				{
					scenario.Train = item;
					scenario.SyncState = SyncState.Synced;
				}
				else
				{
					Debug.Log($"Unmatched s:'{scenario.Name}', t: '{scenario.Train.Name}', sss: {scenario.SyncState}, tss: {scenario.Train.SyncState}");
					scenario.Train.SyncState = SyncState.Fresh;
					scenario.SyncState = SyncState.Synced;
					Trains.Add(scenario.Train);
				}
				if (count-- < 0)
				{
					throw new Exception("Potential infinite loop while matching trains");
				}
			}
			manager.SortByName();
			manager.SaveOriginalValues();
		}

		private void RemoveClashingWithPredefined<T>(List<T> userThings, List<string> predefinedThingNames) where T : IScenariosThing
		{
			foreach (T item in userThings.Where((T t) => predefinedThingNames.Contains(t.Name)).ToList())
			{
				Debug.LogWarning(typeof(T).Name + " '" + item.Name + "' (file: '" + item.FileName + "') clashes with predefined " + typeof(T).Name + " of the same name so it won't be loaded");
				userThings.Remove(item);
			}
		}

		private (int matchScore, T matchedThing) FindMatch<T>(T thingToReplaceIfMatchFound, ObservableCollectionExt<T> Things) where T : class, IScenariosThing
		{
			int num = 0;
			T item = null;
			foreach (T Thing in Things)
			{
				int matchScore = DV.Scenarios.Thing.GetMatchScore(Thing as Thing, thingToReplaceIfMatchFound as Thing);
				if (matchScore > num)
				{
					num = matchScore;
					item = Thing;
				}
			}
			_ = 0;
			return (matchScore: num, matchedThing: item);
		}

		public IScenario ScenarioFromJson(JObject json, string fileName = "")
		{
			return FromJson<Scenario>(json, scenarioUpgraders, fileName);
		}

		public ITrain TrainFromJson(JObject json, string fileName = "")
		{
			return FromJson<Train>(json, trainUpgraders, fileName);
		}

		public IDifficulty DifficultyFromJson(JObject json, string fileName = "")
		{
			return FromJson<Difficulty>(json, difficultyUpgraders, fileName);
		}

		private IScenario ScenarioFromFilename(string fileName)
		{
			return FromFilename<Scenario>(fileName, scenarioUpgraders);
		}

		private ITrain TrainFromFilename(string fileName)
		{
			return FromFilename<Train>(fileName, trainUpgraders);
		}

		private IDifficulty DifficultyFromFilename(string fileName)
		{
			return FromFilename<Difficulty>(fileName, difficultyUpgraders);
		}

		private T FromJson<T>(JObject json, AJSONDataUpgrader[] upgraders, string originalFilename = "") where T : Thing
		{
			json = Upgrade(json, originalFilename, storage, upgraders);
			T val = Thing.FromJson<T>(json, Util.JsonSerializer);
			val.FileName = originalFilename;
			val.SyncState = ((!string.IsNullOrEmpty(originalFilename)) ? SyncState.Synced : SyncState.Fresh);
			val.pendingFileRename = false;
			return val;
		}

		private T FromFilename<T>(string fileName, AJSONDataUpgrader[] upgraders) where T : Thing
		{
			if (!storage.FileExists(fileName))
			{
				return null;
			}
			try
			{
				JObject json = JObject.Parse(storage.ReadFileToString(fileName));
				json = ((!typeof(IDifficulty).IsAssignableFrom(typeof(T))) ? Upgrade(json, fileName, storage, upgraders) : UpgradeDifficulty(json, fileName, storage, upgraders, difficultyPresetRemappings));
				T val = Thing.FromJson<T>(json, Util.JsonSerializer);
				val.FileName = fileName;
				val.SyncState = SyncState.Synced;
				val.pendingFileRename = false;
				return val;
			}
			catch (Exception exception)
			{
				Debug.LogWarning("The following error was encountered while parsing the " + typeof(T).Name + " at '" + fileName + "':");
				Debug.LogException(exception);
				return null;
			}
		}

		public ICar CreateCar(string liveryName, bool reversed, string cargoType = null)
		{
			return new Car
			{
				_name = liveryName,
				Reversed = reversed,
				CargoType = cargoType
			};
		}

		public ITrain CreateTrain()
		{
			return trainCollection.Create();
		}

		public IScenario CreateScenario()
		{
			return scenarioCollection.Create();
		}

		public IDifficulty CreateDifficulty()
		{
			return difficultyCollection.Create();
		}

		public ITrain CreateCopyOf(ITrain train)
		{
			return trainCollection.CreateCopyOf(train);
		}

		public IScenario CreateCopyOf(IScenario scenario)
		{
			return scenarioCollection.CreateCopyOf(scenario);
		}

		public IDifficulty CreateCopyOf(IDifficulty difficulty)
		{
			return difficultyCollection.CreateCopyOf(difficulty);
		}

		public void Flush()
		{
			foreach (IScenario scenario in Scenarios)
			{
				Flush(scenario);
			}
			foreach (ITrain train in Trains)
			{
				Flush(train);
			}
			foreach (IDifficulty difficulty in Difficulties)
			{
				Flush(difficulty);
			}
		}

		public string GetAutoIncrementName(IScenariosThing thing)
		{
			if (thing is ITrain existingThing)
			{
				return trainCollection.GetAutoIncrementName(existingThing);
			}
			if (thing is IScenario existingThing2)
			{
				return scenarioCollection.GetAutoIncrementName(existingThing2);
			}
			if (thing is IDifficulty existingThing3)
			{
				return difficultyCollection.GetAutoIncrementName(existingThing3);
			}
			throw new ArgumentException("Unknown type of thing: " + thing.GetType().Name);
		}

		public JObject SerializeThing(IThing thing)
		{
			JObject jObject = JObject.FromObject(thing, Util.JsonSerializer);
			int currentThingDataVersion = GetCurrentThingDataVersion(thing);
			if (currentThingDataVersion >= 1)
			{
				jObject.SetInt(Thing.DATA_VERSION_KEY, currentThingDataVersion);
			}
			return jObject;
		}

		private void Flush(IScenariosThing ithing)
		{
			if (!(ithing is Thing thing) || thing.SyncState == SyncState.Synced)
			{
				return;
			}
			if (ithing.IsReadOnly)
			{
				Debug.LogError($"'{thing.Name}' is read-only but its sync state is '{thing.SyncState}'");
			}
			else
			{
				if (thing.FileName == null)
				{
					thing.FileName = Util.GetSuggestedFileName(thing, storage);
				}
				else if (thing.pendingFileRename)
				{
					string suggestedFileName = Util.GetSuggestedFileName(thing, storage);
					storage.DeleteFile(thing.FileName);
					thing.FileName = suggestedFileName;
				}
				JObject jObject = SerializeThing(thing);
				storage.WriteFile(thing.FileName, jObject.ToString());
			}
			thing.pendingFileRename = false;
			thing._syncState = SyncState.Synced;
			ithing.SaveSnapshot();
		}

		public void DeleteScenario(IScenario scenarioToDelete)
		{
			if (scenarioToDelete != null && Scenarios.Contains(scenarioToDelete))
			{
				scenarioCollection.Delete(scenarioToDelete);
				DeleteThing(scenarioToDelete);
			}
		}

		public void DeleteTrain(ITrain trainToDelete)
		{
			if (trainToDelete == null || !Trains.Contains(trainToDelete))
			{
				return;
			}
			List<Scenario> list = Scenarios.Where((IScenario s) => trainToDelete == s.Train).Cast<Scenario>().ToList();
			if (list.Count > 0)
			{
				ITrain train = Trains.FirstOrDefault((ITrain t) => t != trainToDelete) ?? CreateTrain();
				foreach (Scenario item in list)
				{
					item.Train = train;
				}
			}
			trainCollection.Delete(trainToDelete);
			DeleteThing(trainToDelete);
		}

		public void DeleteDifficulty(IDifficulty difficultyToDelete)
		{
			if (difficultyToDelete != null && Difficulties.Contains(difficultyToDelete))
			{
				difficultyCollection.Delete(difficultyToDelete);
				DeleteThing(difficultyToDelete);
			}
		}

		private void DeleteThing(IScenariosThing thing)
		{
			if (thing.SyncState != SyncState.Deleted)
			{
				thing.SyncState = SyncState.Deleted;
				if (!string.IsNullOrWhiteSpace(thing.FileName))
				{
					storage.DeleteFile(thing.FileName);
				}
			}
		}

		public static JObject UpgradeDifficulty(JObject json, string fileName, IStorageProvider storage, AJSONDataUpgrader[] upgraders, Dictionary<string, string> remappings)
		{
			if (json["_Difficulty_preset"] == null || string.IsNullOrEmpty(json["_Difficulty_preset"].Value<string>()))
			{
				return Upgrade(json, fileName, storage, upgraders);
			}
			if (remappings != null && json["_Difficulty_preset"] != null && remappings.TryGetValue(json.GetString("_Difficulty_preset"), out var value))
			{
				json.SetString("_Difficulty_preset", value);
			}
			return json;
		}

		public static JObject Upgrade(JObject json, string fileName, IStorageProvider storage, AJSONDataUpgrader[] upgraders)
		{
			int num = 1;
			if (json.ContainsKey("DataVersion"))
			{
				num = json["DataVersion"].Value<int>();
			}
			bool flag;
			do
			{
				flag = false;
				for (int i = 0; i < upgraders.Length; i++)
				{
					if (upgraders[i].InputVersion == num)
					{
						flag = true;
						upgraders[i].Upgrade(json, fileName, storage, num + 1);
						break;
					}
				}
				num++;
			}
			while (flag);
			return json;
		}
	}
}
