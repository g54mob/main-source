using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts;
using UnityEngine;
using Utility;

namespace SimulationScripts
{
	public class ZoneManager : MonoBehaviour, ISaveable, ISaveableBin
	{
		public List<Zone> zones = new List<Zone>();

		private System.Random r = new System.Random();

		public static ZoneManager instance;

		public Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo> { 
		{
			"Untagged",
			new TagInfo
			{
				count = 0,
				totalEnergy = 0f
			}
		} };

		private float bibiteBiomass;

		public float simSize;

		private static readonly BoolSetting ShadeEnabled = ScenarioSettings.Instance.shadeOutsideOfBounds;

		public static bool shadeEnabled = ShadeEnabled.SubscribeTo<BoolSetting, bool>(UpdateShadeEnabled);

		public float freeBiomass => zones.Sum((Zone z) => z.freeBiomass);

		private float totalMaxBiomass => zones.Sum((Zone z) => z.maxBiomass);

		private static void UpdateShadeEnabled(bool val)
		{
			shadeEnabled = val;
		}

		public void UpdateSimSize(float val)
		{
			simSize = val;
			RefreshPelletBiomassCounter();
		}

		public void Awake()
		{
			instance = this;
		}

		public void InitializeSpawner()
		{
			if (zones.Count < 1)
			{
				GenerateSpawnPoints();
			}
			ScenarioSettings.onZoneAdded.AddListener(ZoneAdded);
			ScenarioSettings.onZoneRemoved.AddListener(ZoneRemoved);
			ScenarioSettings.onZoneFromGroupAdded.AddListener(ZoneAdded);
			ScenarioSettings.onZoneFromGroupRemoved.AddListener(ZoneRemoved);
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(UpdateSimSize);
			UpdateSimSize(ScenarioIndependentSettings.Instance.SimulationSize.val);
		}

		public void StartSpawner()
		{
			zones.ForEach(delegate(Zone z)
			{
				z.InitialSeeding();
			});
			ResumeSpawner();
		}

		public void ResumeSpawner()
		{
			StartCoroutine("CountBiomass", 1f);
			StartCoroutine("CleanUnusedAssets");
		}

		private void GenerateSpawnPoints()
		{
			zones.ForEach(delegate(Zone s)
			{
				UnityEngine.Object.Destroy(s.gameObject);
			});
			zones.Clear();
			ScenarioSettings.Instance.allZones.ForEach(delegate(ZoneSettings z)
			{
				Zone item = WorldObjectsSpawner.Instance.GenerateNewZone(z);
				zones.Add(item);
			});
			zones.ForEach(delegate(Zone z)
			{
				z.UpdateTarget(z.settings.target.val);
			});
		}

		private void ZoneAdded(ZoneSettings newZone)
		{
			Zone item = WorldObjectsSpawner.Instance.GenerateNewZone(newZone);
			zones.Add(item);
		}

		private void ZoneRemoved(ZoneSettings removedZone)
		{
			if (removedZone != null)
			{
				Zone zone = zones.FirstOrDefault((Zone z) => z.settings == removedZone);
				if (!(zone == null))
				{
					zones.Remove(zone);
					UnityEngine.Object.Destroy(zone.gameObject);
				}
			}
			else
			{
				zones.ForEach(delegate(Zone z)
				{
					UnityEngine.Object.Destroy(z.gameObject);
				});
				zones.Clear();
			}
		}

		private IEnumerator CountBiomass(float delay)
		{
			WaitForSecondsRealtime delayWS = new WaitForSecondsRealtime(delay);
			while (true)
			{
				UpdateBiomass();
				yield return delayWS;
			}
		}

		public int RandomSpawnPointIndex()
		{
			return UnityEngine.Random.Range(0, zones.Count);
		}

		public Vector2 GetRandomPositionInZone(int? spawnPointIndex = null)
		{
			if (zones.Count < 1)
			{
				return Vector2.zero;
			}
			int index = spawnPointIndex ?? RandomSpawnPointIndex();
			return zones[index].GetSpawnLocation();
		}

		public void UpdateBiomass()
		{
			float num = 0f;
			bibiteBiomass = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			tags = new Dictionary<string, TagInfo> { 
			{
				"Untagged",
				new TagInfo
				{
					count = 0,
					totalEnergy = 0f
				}
			} };
			num6 = PlantCounter.Count;
			num3 = (float)PlantCounter.Biomass;
			num7 = MeatCounter.Count;
			num4 = (float)MeatCounter.Biomass;
			num = num4 + num3;
			foreach (BibiteBody bibite in BibiteTracker.instance.bibites)
			{
				BibiteGenes gene = bibite.gene;
				num8++;
				bibiteBiomass += bibite.totalEnergy;
				string speciesTag = gene.speciesTag;
				if (speciesTag == "")
				{
					TagInfo value = tags["Untagged"];
					value.count++;
					value.totalEnergy += bibite.totalEnergy;
					tags["Untagged"] = value;
				}
				else if (tags.ContainsKey(speciesTag))
				{
					TagInfo value = tags[speciesTag];
					value.count++;
					value.totalEnergy += bibite.totalEnergy;
					tags[speciesTag] = value;
				}
				else
				{
					tags.Add(speciesTag, new TagInfo
					{
						count = 1,
						totalEnergy = bibite.totalEnergy
					});
				}
			}
			foreach (EggHatching egg in BibiteTracker.instance.eggs)
			{
				string speciesTag = egg.eggGene.speciesTag;
				if (speciesTag == "")
				{
					TagInfo value2 = tags["Untagged"];
					value2.count++;
					value2.totalEnergy += egg.energy;
					tags["Untagged"] = value2;
				}
				else if (tags.ContainsKey(speciesTag))
				{
					TagInfo value2 = tags[speciesTag];
					value2.count++;
					value2.totalEnergy += egg.energy;
					tags[speciesTag] = value2;
				}
				else
				{
					tags.Add(speciesTag, new TagInfo
					{
						count = 1,
						totalEnergy = egg.energy
					});
				}
				num5++;
				num2 += egg.energy;
			}
			InformationPanel.Instance?.UpdateInformation(num6, num7, num8, num5, freeBiomass, num, bibiteBiomass, num2, num3, num4, tags);
		}

		private IEnumerator CleanUnusedAssets()
		{
			WaitForSeconds delayWS = new WaitForSeconds(600f);
			while (true)
			{
				Resources.UnloadUnusedAssets();
				yield return delayWS;
			}
		}

		public void LogAllZonesData()
		{
			zones.ForEach(delegate(Zone z)
			{
				z.LogData();
			});
		}

		private void OnDrawGizmos()
		{
			float val = ScenarioIndependentSettings.Instance.SimulationSize.val;
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(2f * val, 2f * val, 1f));
			foreach (Zone zone in zones)
			{
				Gizmos.DrawWireSphere(zone.pos, zone.radius);
			}
		}

		public void RefreshPelletBiomassCounter()
		{
			PlantCounter.ResetCount();
			MeatCounter.ResetCount();
			List<GameObject> pelletsOutOfBounds = new List<GameObject>();
			foreach (Transform item in WorldObjectsSpawner.Instance.freePelletHolder)
			{
				(item.GetComponent(typeof(IEntityCounter)) as IEntityCounter)?.AddToGlobalCount();
				if (shadeEnabled && item.transform.position.magnitude > 1.5f * simSize + 500f)
				{
					pelletsOutOfBounds.Add(item.gameObject);
				}
			}
			foreach (GameObject item2 in pelletsOutOfBounds)
			{
				UnityEngine.Object.Destroy(item2);
			}
			pelletsOutOfBounds.Clear();
			foreach (Zone zone in zones)
			{
				pelletsOutOfBounds = new List<GameObject>();
				zone.pellets.ForEach(delegate(GameObject pellet)
				{
					(pellet.GetComponent(typeof(IEntityCounter)) as IEntityCounter)?.AddToGlobalCount();
					if (shadeEnabled && pellet.transform.position.magnitude > 1.5f * simSize + 500f)
					{
						pelletsOutOfBounds.Add(pellet);
					}
				});
				foreach (GameObject item3 in pelletsOutOfBounds)
				{
					UnityEngine.Object.Destroy(item3);
				}
				pelletsOutOfBounds.Clear();
				zone.RecountBiomass();
			}
		}

		private void OnDestroy()
		{
			foreach (Zone zone in zones)
			{
				UnityEngine.Object.Destroy(zone.gameObject);
			}
			PlantCounter.ResetCount();
			MeatCounter.ResetCount();
			ScenarioSettings.onZoneAdded.RemoveListener(ZoneAdded);
			ScenarioSettings.onZoneRemoved.RemoveListener(ZoneRemoved);
			ScenarioSettings.onZoneFromGroupAdded.RemoveListener(ZoneAdded);
			ScenarioSettings.onZoneFromGroupRemoved.RemoveListener(ZoneRemoved);
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(UpdateSimSize);
		}

		public JObject SaveState()
		{
			return SerializationHelper.SerializeGeneralObject(this);
		}

		public void LoadState(JObject state)
		{
			SerializationHelper.DeserializeGeneralObject(this, state);
			GenerateSpawnPoints();
		}

		public int BytesSpace()
		{
			int num = 0;
			foreach (Zone zone in zones)
			{
				num += 8 + zone.zoneData.BytesSpace();
			}
			return num;
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			foreach (Zone zone in zones)
			{
				int num = zone.zoneData.BytesSpace();
				Buffer.BlockCopy(BitConverter.GetBytes(zone.settings.zoneID), 0, bytes, offset, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset + 4, 4);
				zone.zoneData.SaveStateBin(bytes, offset + 8);
				offset += 8 + num;
			}
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Utility.Version version, int offset = 0, int nBytes = -1)
		{
			int num = offset + nBytes;
			while (offset < num)
			{
				int id = BitConverter.ToInt32(bytes, offset);
				int num2 = BitConverter.ToInt32(bytes, offset + 4);
				Zone zone = zones.FirstOrDefault((Zone z) => z.settings.zoneID == id);
				if (zone != null)
				{
					zone.zoneData.LoadStateBin(bytes, version, offset + 8, num2);
				}
				offset += 8 + num2;
			}
		}
	}
}
