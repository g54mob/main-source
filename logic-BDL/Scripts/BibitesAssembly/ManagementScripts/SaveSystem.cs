using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;
using Utility;
using Utility.DataLogging;

namespace ManagementScripts
{
	public class SaveSystem : MonoBehaviour
	{
		private WorldObjectsSpawner spawner;

		public static SaveSystem instance;

		public static bool includeTemplates;

		public static Utility.Version fromVersion;

		[NonSerialized]
		public readonly UnityEvent onSavingDone = new UnityEvent();

		[NonSerialized]
		public readonly UnityEvent onLoadingDone = new UnityEvent();

		private SaveableBinStack dataSaveStack;

		public static string savedBibitePath => Path.Combine(Application.persistentDataPath, "Bibites/");

		public static string bibiteTemplatePath => Path.Combine(savedBibitePath, "Templates/");

		private void Awake()
		{
			spawner = GetComponent<WorldObjectsSpawner>();
			instance = this;
		}

		private void Start()
		{
			dataSaveStack = new SaveableBinStack
			{
				stack = new List<ISaveableBin>
				{
					DataLogger.Instance,
					BibiteTracker.instance,
					new SaveableBinElement(GlobalLineageManager.Instance, new Utility.Version(0, 6, 0, 15)),
					new SaveableBinElement(ZoneManager.instance, new Utility.Version(0, 6, 0, 10))
				}
			};
		}

		public GameObject LoadBibiteOrEggFromData(string json, bool resume = true, DialogGroupHandle problems = null, float? birthAtMaturity = null)
		{
			try
			{
				JObject jObject = JObject.Parse(json);
				if (jObject["egg"] == null)
				{
					return LoadBibite(jObject, resume, problems, Utility.Version.Present, birthAtMaturity);
				}
				return LoadEgg(jObject, resume, problems, Utility.Version.Present);
			}
			catch
			{
				return null;
			}
		}

		public void ResumeBibiteOrEgg(GameObject entity)
		{
			if (entity.CompareTag("bibite"))
			{
				BibiteBody component = entity.GetComponent<BibiteBody>();
				entity.GetComponent<NEATBrain>().ResumeBrain();
				component.ResumeBody();
			}
			if (entity.CompareTag("egg"))
			{
				NEATBrain component2 = entity.GetComponent<NEATBrain>();
				EggHatching component3 = entity.GetComponent<EggHatching>();
				component2.ResumeBrain();
				component3.ResumeHatch();
			}
		}

		public void SaveBibiteOrEgg(GameObject target, string path, string desc)
		{
			if (target.CompareTag("bibite"))
			{
				SaveBibite(target, path, desc);
				return;
			}
			if (target.CompareTag("egg"))
			{
				SaveEgg(target, path, desc);
				return;
			}
			PopupManager.DisplayError("Save System", "Invalid object type provided to SaveBibiteOrEggg Function");
			throw new InvalidOperationException("Invalid object provided to SaveBibite.");
		}

		public void SaveBibiteAsTemplate(GameObject bibite, string path, string bibiteName, string description)
		{
			SaveTemplate(new BibiteTemplate(bibite)
			{
				name = bibiteName,
				description = description
			}, path);
		}

		public static void SaveTemplate(BibiteTemplate template, string path = null)
		{
			JObject jObject = template.SaveState();
			if (path == null)
			{
				path = Path.Combine(bibiteTemplatePath, template.name + ".bb8template");
			}
			using StreamWriter streamWriter = File.CreateText(path);
			streamWriter.Write(jObject.ToString(UserSettings.FormatBibiteJSON.val ? Formatting.Indented : Formatting.None));
		}

		public void SaveBibite(GameObject bibite, string path, string desc)
		{
			if (!bibite.CompareTag("bibite"))
			{
				PopupManager.DisplayError("Save System", "Invalid object type provided to SaveBibite Function");
				throw new InvalidOperationException("Invalid object provided to SaveBibite.");
			}
			if (path == null)
			{
				path = Path.Combine(Application.persistentDataPath, "bibite_quick_save.bb8");
			}
			JObject jObject = SerializeBibite(bibite);
			jObject.Add("version", Application.version);
			jObject.Add("desc", desc);
			using StreamWriter streamWriter = File.CreateText(path);
			streamWriter.Write(jObject.ToString(UserSettings.FormatBibiteJSON.val ? Formatting.Indented : Formatting.None));
		}

		public void SaveEgg(GameObject egg, string path, string desc)
		{
			if (!egg.CompareTag("egg"))
			{
				PopupManager.DisplayError("Save System", "Invalid object type provided to SaveEgg Function");
				throw new InvalidOperationException("Invalid object provided to SaveEgg.");
			}
			if (path == null)
			{
				path = Path.Combine(Application.persistentDataPath, "egg_quick_save.bb8");
			}
			JObject jObject = SerializeEgg(egg);
			jObject.Add("version", Application.version);
			jObject.Add("desc", desc);
			using StreamWriter streamWriter = File.CreateText(path);
			streamWriter.Write(jObject.ToString(Formatting.None));
		}

		public void SaveGame(string saveFileName)
		{
			StartCoroutine(CreateSave(saveFileName));
		}

		private IEnumerator CreateSave(string saveFileName)
		{
			JObject sceneSaveObject = new JObject();
			JObject pelletsSaveObject = new JObject();
			JObject pheromonesSaveObject = new JObject();
			yield return null;
			sceneSaveObject["version"] = Application.version;
			JObject obj = SerializationHelper.SerializeSettings();
			JObject obj2 = GlobalLineageManager.Instance.SaveState();
			List<GameObject> allChilds = WorldObjectsSpawner.Instance.bibiteHolder.GetAllChilds();
			List<JObject> bibitesJson = new List<JObject>();
			List<JObject> eggsJson = new List<JObject>();
			foreach (GameObject item in allChilds)
			{
				if (item.CompareTag("bibite"))
				{
					bibitesJson.Add(SerializeBibite(item));
				}
				else
				{
					eggsJson.Add(SerializeEgg(item));
				}
			}
			JArray jArray = new JArray();
			int num = 0;
			JObject jObject = new JObject();
			jObject["zone"] = "free pellets";
			JArray jArray2 = new JArray();
			foreach (Transform item2 in WorldObjectsSpawner.Instance.freePelletHolder)
			{
				jArray2.Add(SerializePellet(item2.gameObject));
			}
			num += jArray2.Count;
			jObject["pellets"] = jArray2;
			jArray.Add(jObject);
			foreach (Zone zone in ZoneManager.instance.zones)
			{
				jObject = new JObject();
				jObject["zone"] = zone.settings.zoneName.val;
				jArray2 = new JArray();
				List<GameObject> pellets = zone.pellets;
				num += pellets.Count;
				foreach (GameObject item3 in pellets)
				{
					jArray2.Add(SerializePellet(item3));
				}
				jObject["pellets"] = jArray2;
				jArray.Add(jObject);
			}
			pelletsSaveObject["pellets"] = jArray;
			sceneSaveObject["nPellets"] = num;
			sceneSaveObject["nBibites"] = bibitesJson.Count + eggsJson.Count;
			List<GameObject> allChilds2 = WorldObjectsSpawner.Instance.pheromoneHolder.GetAllChilds();
			JArray jArray3 = new JArray();
			for (int i = 0; i < allChilds2.Count; i++)
			{
				jArray3.Add(SerializePheromones(allChilds2[i]));
			}
			pheromonesSaveObject["pheromones"] = jArray3;
			List<GameObject> allChilds3 = WorldObjectsSpawner.Instance.colorKillerHolder.GetAllChilds();
			JArray jArray4 = new JArray();
			foreach (GameObject item4 in allChilds3)
			{
				ColorKiller component = item4.GetComponent<ColorKiller>();
				if (component.placed)
				{
					jArray4.Add(SerializationHelper.SerializeObject(component));
				}
			}
			sceneSaveObject["colorSelectors"] = jArray4;
			sceneSaveObject["simulatedTime"] = TimeKeeper.simulatedTime;
			byte[] file = dataSaveStack.SaveStateBin();
			if (File.Exists(saveFileName))
			{
				File.Delete(saveFileName);
			}
			using (ZipArchive zip = ZipFile.Open(saveFileName, ZipArchiveMode.Create))
			{
				WriteJObjectToArchive(zip, "settings.bb8settings", obj);
				WriteJObjectToArchive(zip, "speciesData.json", obj2);
				WriteJObjectToArchive(zip, "scene.bb8scene", sceneSaveObject);
				WriteJObjectToArchive(zip, "pellets.bb8scene", pelletsSaveObject);
				WriteJObjectToArchive(zip, "pheromones.bb8scene", pheromonesSaveObject);
				WriteFileToArchive(zip, "data.bin", file);
				SceneScreenShotHandler.instance.SaveScreenshotToZip(zip);
				yield return null;
				for (int j = 0; j < bibitesJson.Count; j++)
				{
					if (bibitesJson[j] != null)
					{
						WriteJObjectToArchive(zip, Path.Combine("bibites", $"bibite_{j}.bb8"), bibitesJson[j]);
					}
				}
				for (int k = 0; k < eggsJson.Count; k++)
				{
					if (eggsJson[k] != null)
					{
						WriteJObjectToArchive(zip, Path.Combine("eggs", $"egg_{k}.bb8"), eggsJson[k]);
					}
				}
				AddTemplatesToArchive(zip);
			}
			onSavingDone.Invoke();
		}

		public static void WriteJObjectToArchive(ZipArchive zip, string fileName, JObject obj)
		{
			using StreamWriter streamWriter = new StreamWriter(zip.CreateEntry(fileName).Open(), Encoding.UTF8);
			streamWriter.Write(obj.ToString(Formatting.None));
		}

		public static void WriteFileToArchive(ZipArchive zip, string fileName, byte[] file)
		{
			Stream stream = zip.CreateEntry(fileName).Open();
			stream.Write(file, 0, file.Length);
			stream.Close();
		}

		private static JObject SerializeConnections(GameObject[] bibites, GameObject[] pellets)
		{
			JObject jObject = new JObject();
			JObject jObject2 = new JObject();
			JObject jObject3 = new JObject();
			Dictionary<Rigidbody2D, int> dictionary = new Dictionary<Rigidbody2D, int>();
			Dictionary<Rigidbody2D, int> dictionary2 = new Dictionary<Rigidbody2D, int>();
			for (int i = 0; i < bibites.Length; i++)
			{
				dictionary2.Add(bibites[i].GetComponent<Rigidbody2D>(), i);
			}
			for (int j = 0; j < pellets.Length; j++)
			{
				dictionary.Add(pellets[j].GetComponent<Rigidbody2D>(), j);
			}
			for (int k = 0; k < bibites.Length; k++)
			{
				JArray jArray = new JArray();
				JArray jArray2 = new JArray();
				FixedJoint2D[] components = bibites[k].GetComponents<FixedJoint2D>();
				foreach (FixedJoint2D fixedJoint2D in components)
				{
					if (fixedJoint2D.connectedBody == null)
					{
						continue;
					}
					int value2;
					if (fixedJoint2D.connectedBody.CompareTag("bibite"))
					{
						if (dictionary2.TryGetValue(fixedJoint2D.connectedBody, out var value) && k < value)
						{
							jArray.Add(value);
						}
					}
					else if (fixedJoint2D.connectedBody.CompareTag("pellet") && dictionary.TryGetValue(fixedJoint2D.connectedBody, out value2))
					{
						jArray2.Add(value2);
					}
				}
				if (jArray.Count > 0)
				{
					jObject2[k.ToString()] = jArray;
				}
				if (jArray2.Count > 0)
				{
					jObject3[k.ToString()] = jArray2;
				}
			}
			jObject["bibites"] = jObject2;
			jObject["pellets"] = jObject3;
			return jObject;
		}

		private static JObject SerializePheromones(GameObject pheromones)
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, pheromones);
			PheromoneSpot component = pheromones.GetComponent<PheromoneSpot>();
			jObject["phero"] = SerializationHelper.SerializeObject(component);
			return jObject;
		}

		private static JObject SerializePellet(GameObject pellet)
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, pellet);
			MatterPellet component = pellet.GetComponent<MatterPellet>();
			jObject["pellet"] = SerializationHelper.SerializeObject(component);
			JToken jToken = MatterDecayProcessor.I.TryGetState(component);
			if (jToken != null)
			{
				jObject["matterDecay"] = jToken;
			}
			return jObject;
		}

		private static JObject SerializePellet(MatterPellet pellet)
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, pellet.gameObject);
			jObject["pellet"] = SerializationHelper.SerializeObject(pellet);
			JToken jToken = MatterDecayProcessor.I.TryGetState(pellet);
			if (jToken != null)
			{
				jObject["matterDecay"] = jToken;
			}
			return jObject;
		}

		private static JObject SerializeBibite(GameObject bibite)
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, bibite);
			BibiteGenes component = bibite.GetComponent<BibiteGenes>();
			BibiteBody component2 = bibite.GetComponent<BibiteBody>();
			InternalClock component3 = bibite.GetComponent<InternalClock>();
			NEATBrain component4 = bibite.GetComponent<NEATBrain>();
			if (component == null)
			{
				return null;
			}
			jObject["genes"] = component.SaveState();
			jObject["body"] = component2.SaveState();
			jObject["clock"] = SerializationHelper.SerializeObject(component3);
			jObject["brain"] = SerializationHelper.SerializeObject(component4);
			return jObject;
		}

		private static JObject SerializeEgg(GameObject egg)
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, egg);
			BibiteGenes component = egg.GetComponent<BibiteGenes>();
			NEATBrain component2 = egg.GetComponent<NEATBrain>();
			EggHatching component3 = egg.GetComponent<EggHatching>();
			jObject["genes"] = SerializationHelper.SerializeObject(component);
			jObject["egg"] = SerializationHelper.SerializeObject(component3);
			jObject["brain"] = SerializationHelper.SerializeObject(component2);
			return jObject;
		}

		private GameObject LoadBibite(JObject state, bool resume = true, DialogGroupHandle problems = null, Utility.Version fromVersion = default(Utility.Version), float? birthAtMaturity = null)
		{
			GameObject gameObject = spawner.GenerateNewBibite();
			BibiteGenes component = gameObject.GetComponent<BibiteGenes>();
			BibiteBody component2 = gameObject.GetComponent<BibiteBody>();
			gameObject.GetComponent<BibiteGrowth>();
			InternalClock component3 = gameObject.GetComponent<InternalClock>();
			NEATBrain component4 = gameObject.GetComponent<NEATBrain>();
			SerializationHelper.DeserializePosition(state, gameObject, problems);
			SerializationHelper.DeserializeObject(component, (JObject)state["genes"]);
			bool geneRemapingNecessary = false;
			component.genes = BibiteUpdater.UpdateGenesToPresentVersion(component.genes, fromVersion, state["genes"]["genes"], geneRemapingNecessary);
			SerializationHelper.DeserializeObject(component2, (JObject)state["body"]);
			SerializationHelper.DeserializeObject(component3, (JObject)state["clock"]);
			SerializationHelper.DeserializeObject(component4, (JObject)state["brain"]);
			BrainUpdater.UpdateBrainFromVersion(component4, fromVersion);
			if (!resume)
			{
				return gameObject;
			}
			component4.ResumeBrain();
			if (birthAtMaturity.HasValue)
			{
				component2.StartBodyAtGrowthAndNormalize(birthAtMaturity.Value);
			}
			else
			{
				component2.ResumeBody();
			}
			return gameObject;
		}

		private GameObject LoadEgg(JObject state, bool resume = true, DialogGroupHandle problems = null, Utility.Version fromVersion = default(Utility.Version))
		{
			GameObject gameObject = spawner.GenerateNewEgg();
			SerializationHelper.DeserializePosition(state, gameObject, problems);
			BibiteGenes component = gameObject.GetComponent<BibiteGenes>();
			EggHatching component2 = gameObject.GetComponent<EggHatching>();
			NEATBrain component3 = gameObject.GetComponent<NEATBrain>();
			component.InitGenesFromGameSettings();
			SerializationHelper.DeserializeObject(component, (JObject)state["genes"]);
			SerializationHelper.DeserializeObject(component3, (JObject)state["brain"]);
			BrainUpdater.UpdateBrainFromVersion(component3, fromVersion);
			SerializationHelper.DeserializeObject(component2, (JObject)state["egg"]);
			if (!resume)
			{
				return gameObject;
			}
			component3.ResumeBrain();
			component2.ResumeHatch();
			return gameObject;
		}

		private MatterPellet LoadPellet(JObject state, Zone zone)
		{
			bool num = state["matterDecay"] != null || state["meatRot"] != null;
			Transform transform = ((zone != null) ? zone.pelletHolder : null);
			MatterMaterial mat = MatterMaterialManager.FindMaterial(state["pellet"]["material"].ToString());
			Vector3 value = SerializationHelper.DeserializePos(state);
			float value2 = state["pellet"]["amount"].ToObject<float>();
			WorldObjectsSpawner worldObjectsSpawner = spawner;
			Vector3? pos = value;
			float? amount = value2;
			Transform holder = transform;
			MatterPellet matterPellet = worldObjectsSpawner.SpawnPelletOfMatter(mat, pos, null, amount, holder);
			if (num)
			{
				MatterDecayProcessor.I.TrySetState(matterPellet, (JObject)(state["matterDecay"] ?? state["meatRot"]));
			}
			return matterPellet;
		}

		private GameObject LoadPheromone(JObject state)
		{
			GameObject gameObject = spawner.GenerateNewPheromonesSource();
			SerializationHelper.DeserializePosition(state, gameObject);
			SerializationHelper.DeserializeObject(gameObject.GetComponent<PheromoneSpot>(), (JObject)state["phero"]);
			return gameObject;
		}

		private GameObject LoadColorSelector(JObject state)
		{
			ColorKiller colorKiller = spawner.GenerateColorKiller();
			SerializationHelper.DeserializeObject(colorKiller, state);
			return colorKiller.gameObject;
		}

		private void LoadScene(JObject scene, JArray pellets, JArray pheromones)
		{
			if (scene["colorSelectors"] is JArray jArray)
			{
				foreach (JToken item in jArray)
				{
					LoadColorSelector((JObject)item);
				}
			}
			if (pellets == null)
			{
				pellets = scene["pellets"] as JArray;
				if (pellets != null)
				{
					foreach (JToken pellet in pellets)
					{
						LoadPellet((JObject)pellet, ZoneManager.instance.zones[0]);
					}
				}
			}
			else
			{
				foreach (JToken zonePellets in pellets)
				{
					Zone zone = null;
					if (zonePellets["zone"] != null)
					{
						zone = ZoneManager.instance.zones.FirstOrDefault((Zone z) => z.settings.zoneName.val == zonePellets["zone"].ToString());
						foreach (JToken item2 in (JArray)zonePellets["pellets"])
						{
							LoadPellet((JObject)item2, zone);
						}
						if (zone != null)
						{
							zone.ResetList();
						}
					}
					else
					{
						LoadPellet((JObject)zonePellets, null);
					}
				}
			}
			if (pheromones == null)
			{
				pheromones = scene["pheromones"] as JArray;
			}
			if (pheromones != null)
			{
				foreach (JToken pheromone in pheromones)
				{
					LoadPheromone((JObject)pheromone);
				}
			}
			if (scene["simulatedTime"] != null)
			{
				TimeKeeper.simulatedTime = (float)scene["simulatedTime"];
			}
		}

		public void LoadGame(string zipFileName)
		{
			if (!File.Exists(zipFileName))
			{
				return;
			}
			SimulationManager simulationManager = SimulationManager.Instance;
			using (ZipArchive zipArchive = ZipFile.Open(zipFileName, ZipArchiveMode.Read))
			{
				JObject settingsOfSave = GetSettingsOfSave(zipArchive);
				JObject jObject = null;
				if (zipArchive.GetEntry("speciesData.json") != null)
				{
					jObject = ReadJObjectFromArchive(zipArchive.GetEntry("speciesData.json"));
				}
				JObject sceneOfSave = GetSceneOfSave(zipArchive);
				JArray pelletsOfSave = GetPelletsOfSave(zipArchive);
				JArray pheromonesOfSave = GetPheromonesOfSave(zipArchive);
				byte[] array = null;
				if (zipArchive.GetEntry("data.bin") != null)
				{
					array = ReadFileFromArchive(zipArchive.GetEntry("data.bin"));
				}
				Utility.Version versionOfFile = GetVersionOfFile(sceneOfSave, generateError: true);
				if (sceneOfSave["gameName"] != null)
				{
					SimulationManager.gameName = sceneOfSave["gameName"].ToString();
				}
				if (!VersionTracker.CanUpdateFromVersion(versionOfFile))
				{
					string[] obj = new string[5] { "This save file is from an earlier version. (", null, null, null, null };
					Utility.Version version = versionOfFile;
					obj[1] = version.ToString();
					obj[2] = ") that is incompatible with the present version (";
					obj[3] = Application.version;
					obj[4] = ").";
					PopupManager.DisplayError("Save System", string.Concat(obj));
					return;
				}
				if (VersionTracker.ChangesSinceVersion(versionOfFile))
				{
					string[] obj2 = new string[5] { "This save file is from an earlier version. (", null, null, null, null };
					Utility.Version version = versionOfFile;
					obj2[1] = version.ToString();
					obj2[2] = ") and changes were made to the save files structure since this version.\nHowever it seems like it might be compatible with the present version (";
					obj2[3] = Application.version;
					obj2[4] = "), so we tried updating it, but you might still run into issues.";
					PopupManager.DisplayDialog("Save System", string.Concat(obj2));
				}
				ResetWorld();
				fromVersion = versionOfFile;
				SerializationHelper.DeserializeSettings(settingsOfSave, versionOfFile);
				if (versionOfFile < new Utility.Version(0, 6, 0, 5))
				{
					ScenarioIndependentSettings.Instance.speciesGeneticSpan.ResetValue();
				}
				if (versionOfFile >= new Utility.Version(0, 6, 0, 5) && jObject != null)
				{
					GlobalLineageManager.Instance.LoadState(jObject);
				}
				CheckTemplatesOfArchive(zipArchive);
				if (versionOfFile < Utility.Version.Parse("0.5a4"))
				{
					float val = ScenarioIndependentSettings.Instance.SimulationSize.val;
					float value = sceneOfSave["pelletSpawner"]["spawnRadius"].ToObject<float>() / val;
					ScenarioSettings.Instance.zones.Clear();
					if (((JArray)sceneOfSave["pelletSpawner"]["spawnCenters"]).Count > 1)
					{
						ZoneSettings zoneSettings = ZoneSettings.DefaultZone();
						zoneSettings.radiusRelative.SetValue(1f);
						zoneSettings.fertility.SetValue(-1.5f);
						ScenarioSettings.Instance.AddNewZone(zoneSettings);
					}
					int num = 1;
					foreach (JToken item in (IEnumerable<JToken>)sceneOfSave["pelletSpawner"]["spawnCenters"])
					{
						ZoneSettings zoneSettings2 = ZoneSettings.DefaultZone();
						zoneSettings2.radiusRelative.SetValue(value);
						zoneSettings2.posX.SetValue(item["x"].ToObject<float>() / val);
						zoneSettings2.posY.SetValue(item["y"].ToObject<float>() / val);
						zoneSettings2.zoneName.SetValue($"Zone {num++}");
						ScenarioSettings.Instance.AddNewZone(zoneSettings2);
					}
				}
				simulationManager.BuildSpawners();
				LoadScene(sceneOfSave, pelletsOfSave, pheromonesOfSave);
				if (versionOfFile < LineageVersionUpdater.toSpeciesData)
				{
					try
					{
						LineageVersionUpdater.ImportFromPre06a10(GlobalLineageManager.Instance.recordedSpecies);
					}
					catch (Exception exception)
					{
						PopupManager.DisplayError("Species Data Importer", "We tried our best, but there was an error loading the species data from the earlier version.");
						Debug.LogException(exception);
					}
				}
				List<ZipArchiveEntry> list = new List<ZipArchiveEntry>();
				List<ZipArchiveEntry> list2 = new List<ZipArchiveEntry>();
				foreach (ZipArchiveEntry entry in zipArchive.Entries)
				{
					if (entry.FullName.StartsWith("bibites"))
					{
						list.Add(entry);
					}
					else if (entry.FullName.StartsWith("egg"))
					{
						list2.Add(entry);
					}
				}
				foreach (ZipArchiveEntry item2 in list)
				{
					LoadBibite(ReadJObjectFromArchive(item2), resume: true, null, versionOfFile);
				}
				foreach (ZipArchiveEntry item3 in list2)
				{
					LoadEgg(ReadJObjectFromArchive(item3), resume: true, null, versionOfFile);
				}
				List<BibiteBody> list3 = WorldObjectsSpawner.Instance.allBibites.Select((GameObject b) => b.GetComponent<BibiteBody>()).ToList();
				List<EggHatching> list4 = WorldObjectsSpawner.Instance.allEggs.Select((GameObject b) => b.GetComponent<EggHatching>()).ToList();
				List<BibiteID> source = list3.Select((BibiteBody b) => b.id).Union(list4.Select((EggHatching e) => e.id)).ToList();
				foreach (BibiteBody item4 in list3)
				{
					BibiteGenes genes = item4.gene;
					BibiteEggLayingOrgan eggLayer = item4.eggLayer;
					if (eggLayer.childIDs != null)
					{
						foreach (int id in eggLayer.childIDs)
						{
							if (id != 0)
							{
								BibiteID bibiteID = source.FirstOrDefault((BibiteID b) => b.id == id);
								if (bibiteID != null)
								{
									eggLayer.children.Add(bibiteID);
								}
							}
						}
					}
					if (genes.parent1ID == 0)
					{
						continue;
					}
					genes.parent1 = list3.FirstOrDefault((BibiteBody b) => b.id.id == genes.parent1ID)?.gameObject;
					if (!(genes.parent1 == null))
					{
						genes.parent2 = list3.FirstOrDefault((BibiteBody b) => b.id.id == genes.parent2ID)?.gameObject;
					}
				}
				foreach (EggHatching item5 in list4)
				{
					BibiteGenes genes2 = item5.eggGene;
					if (genes2.parent1ID == 0)
					{
						continue;
					}
					genes2.parent1 = list3.FirstOrDefault((BibiteBody b) => b.id.id == genes2.parent1ID)?.gameObject;
					if (!(genes2.parent1 == null))
					{
						genes2.parent2 = list3.FirstOrDefault((BibiteBody b) => b.id.id == genes2.parent2ID)?.gameObject;
					}
				}
				if (array != null)
				{
					try
					{
						dataSaveStack.LoadStateBin(array, versionOfFile);
					}
					catch (Exception ex)
					{
						Console.WriteLine("There was an error loading the data.bin statistics files:\n" + ex);
						throw;
					}
				}
			}
			ZoneManager.instance.UpdateBiomass();
			simulationManager.ResumeSpawners();
			onLoadingDone.Invoke();
		}

		public static void AddTemplatesToArchive(ZipArchive zip)
		{
			foreach (BibiteSettings bibite in ScenarioSettings.Instance.bibites)
			{
				bool isExternal = bibite.isExternal;
				string text = (isExternal ? Path.GetFileName(bibite.filePath) : bibite.filePath);
				string extension = Path.GetExtension(text);
				string path;
				if (isExternal)
				{
					path = bibite.filePath;
				}
				else if (extension == ".bb8template")
				{
					if (GameManager.defaultBibites.Contains(Path.GetFileNameWithoutExtension(text).ToLower()))
					{
						continue;
					}
					path = Path.Combine(bibiteTemplatePath, text);
				}
				else
				{
					path = Path.Combine(savedBibitePath, text);
				}
				JObject obj = JObject.Parse(File.ReadAllText(path));
				WriteJObjectToArchive(zip, "templates/" + text, obj);
			}
		}

		public static void CheckTemplatesOfArchive(ZipArchive zip)
		{
			bool flag = false;
			foreach (ZipArchiveEntry entry in zip.Entries)
			{
				if (!entry.FullName.StartsWith("templates"))
				{
					continue;
				}
				string extension = Path.GetExtension(entry.Name);
				if ((!(extension != ".bb8") || !(extension != ".bb8template")) && !BibiteTemplate.Exists(entry.Name, external: false))
				{
					flag = true;
					JObject jObject = ReadJObjectFromArchive(entry);
					using StreamWriter streamWriter = File.CreateText(Path.Combine((Path.GetExtension(entry.Name) == ".bb8") ? savedBibitePath : bibiteTemplatePath, entry.Name));
					streamWriter.Write(jObject.ToString());
				}
			}
			if (flag)
			{
				PopupManager.DisplayDialog("Save System", "This file contained one or more bibite templates that you did not posses.\n\rAll the missing templates were added to your bibites folder.");
			}
		}

		public static void MoveTemplatesOfArchive(ZipArchive zip, string path)
		{
			List<ZipArchiveEntry> list = new List<ZipArchiveEntry>();
			foreach (ZipArchiveEntry entry in zip.Entries)
			{
				if (!entry.FullName.StartsWith("templates"))
				{
					continue;
				}
				string extension = Path.GetExtension(entry.Name);
				if ((!(extension != ".bb8") || !(extension != ".bb8template")) && !GameManager.defaultBibites.Contains(Path.GetFileNameWithoutExtension(entry.Name).ToLower()))
				{
					JObject jObject = ReadJObjectFromArchive(entry);
					string path2 = Path.Combine(path, entry.Name);
					if (File.Exists(path2))
					{
						File.Delete(path2);
					}
					using StreamWriter streamWriter = File.CreateText(path2);
					streamWriter.Write(jObject.ToString());
					list.Add(entry);
				}
			}
			if (list.Count <= 1)
			{
				return;
			}
			JObject settingsOfSave = GetSettingsOfSave(zip);
			if (settingsOfSave != null && settingsOfSave["bibites"] != null)
			{
				foreach (JToken bibite in (IEnumerable<JToken>)settingsOfSave["bibites"])
				{
					if (bibite["path"] != null && !string.IsNullOrEmpty(bibite["path"].ToString()))
					{
						ZipArchiveEntry zipArchiveEntry = list.FirstOrDefault((ZipArchiveEntry r) => bibite["path"].ToString().Contains(r.Name));
						if (zipArchiveEntry != null)
						{
							bibite["path"] = zipArchiveEntry.Name;
							bibite["isExternal"] = true;
						}
					}
				}
				WriteJObjectToArchive(zip, "settings.bb8settings", settingsOfSave);
			}
			foreach (ZipArchiveEntry item in list)
			{
				item.Delete();
			}
		}

		public static JObject GetSettingsOfSave(ZipArchive zip)
		{
			return ReadJObjectFromArchive(zip.GetEntry("settings.bb8settings") ?? zip.GetEntry("settings.json"));
		}

		public static JObject GetSceneOfSave(ZipArchive zip)
		{
			return ReadJObjectFromArchive(zip.GetEntry("scene.bb8scene") ?? zip.GetEntry("scene.json"));
		}

		public static JArray GetPelletsOfSave(ZipArchive zip)
		{
			ZipArchiveEntry entry = zip.GetEntry("pellets.bb8scene");
			if (entry != null)
			{
				return ReadJObjectFromArchive(entry)["pellets"] as JArray;
			}
			return null;
		}

		public static JArray GetPheromonesOfSave(ZipArchive zip)
		{
			ZipArchiveEntry entry = zip.GetEntry("pheromones.bb8scene");
			if (entry != null)
			{
				return ReadJObjectFromArchive(entry)["pheromones"] as JArray;
			}
			return null;
		}

		public static JObject GetDataOfSave(ZipArchive zip)
		{
			ZipArchiveEntry entry = zip.GetEntry("data.json");
			if (entry != null)
			{
				return ReadJObjectFromArchive(entry);
			}
			return null;
		}

		public static JObject GetInfoOfScenario(ZipArchive zip)
		{
			ZipArchiveEntry entry = zip.GetEntry("scenario.info");
			if (entry != null)
			{
				return ReadJObjectFromArchive(entry);
			}
			return null;
		}

		public static Utility.Version GetVersionOfFile(JObject JSONfile, bool generateError = false)
		{
			if (JSONfile.TryGetValue("version", out JToken value) && Utility.Version.CanParse(value.ToString()))
			{
				return Utility.Version.Parse(value.ToString());
			}
			if (generateError)
			{
				PopupManager.DisplayError("Save System", "This save file is from an unknown earlier version and is incompatible with the present version (" + Application.version + ").");
			}
			return Utility.Version.Null;
		}

		public static float GetTimeOfScene(JObject sceneJSON)
		{
			if (sceneJSON.TryGetValue("simulatedTime", out JToken value) && float.TryParse(value.ToString(), out var result))
			{
				return result;
			}
			return 0f;
		}

		public static JObject ReadJObjectFromArchive(ZipArchiveEntry entry)
		{
			using StreamReader streamReader = new StreamReader(entry.Open(), Encoding.UTF8);
			return JObject.Parse(streamReader.ReadToEnd());
		}

		public static byte[] ReadFileFromArchive(ZipArchiveEntry entry)
		{
			byte[] array = new byte[entry.Length];
			using Stream stream = entry.Open();
			stream.Read(array, 0, (int)entry.Length);
			return array;
		}

		private void ResetWorld()
		{
			List<GameObject> allChilds = WorldObjectsSpawner.Instance.colorKillerHolder.GetAllChilds();
			KillObjects(allChilds);
			List<GameObject> allChilds2 = WorldObjectsSpawner.Instance.bibiteHolder.GetAllChilds();
			KillObjects(allChilds2);
			List<GameObject> allChilds3 = WorldObjectsSpawner.Instance.pheromoneHolder.GetAllChilds();
			KillObjects(allChilds3);
			PlantCounter.ResetCount();
			MeatCounter.ResetCount();
			if (SimulationManager.Instance.bibiteSpawner != null)
			{
				UnityEngine.Object.DestroyImmediate(SimulationManager.Instance.bibiteSpawner.gameObject);
			}
		}

		private void KillObjects(IEnumerable<GameObject> objects)
		{
			foreach (GameObject @object in objects)
			{
				UnityEngine.Object.DestroyImmediate(@object);
			}
		}
	}
}
