using System;
using System.Collections.Generic;
using System.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace ManagementScripts
{
	public class WorldObjectsSpawner : MonoBehaviour
	{
		public static WorldObjectsSpawner Instance;

		[Header("World prefabs")]
		[SerializeField]
		private GameObject bibiteEntry;

		[SerializeField]
		private GameObject plantEntry;

		[SerializeField]
		private GameObject meatEntry;

		[SerializeField]
		private GameObject eggEntry;

		[SerializeField]
		private GameObject pelletSpawner;

		[SerializeField]
		public GameObject objectHolder;

		[SerializeField]
		private GameObject pelletSpawnPoint;

		[SerializeField]
		private GameObject bibiteSpawner;

		[SerializeField]
		private GameObject pheromonesSource;

		[SerializeField]
		private GameObject colorKiller;

		[SerializeField]
		private GameObject radioZone;

		[Header("UI Object Prefabs")]
		[SerializeField]
		private GameObject stomachUIPellet;

		[NonSerialized]
		[Header("Object References")]
		public Transform freePelletHolder;

		[SerializeField]
		public GameObject bibiteHolder;

		[SerializeField]
		public GameObject pheromoneHolder;

		[SerializeField]
		public GameObject colorKillerHolder;

		public List<MatterPellet> allPellets = new List<MatterPellet>();

		public Dictionary<MatterMaterial, List<MatterPellet>> pelletsOfMaterial = new Dictionary<MatterMaterial, List<MatterPellet>>();

		private readonly Vector3 posZero = new Vector3(0f, 0f, 0f);

		private readonly Vector3 pelletOffset = new Vector3(0f, 0f, 0.1f);

		private static readonly FloatSetting MinPelletSize = ScenarioSettings.Instance.minPelletSize;

		private static float minPelletSize = MinPelletSize.SubscribeTo<FloatSetting, float>(UpdateMinPelletSize);

		public int nBibite
		{
			get
			{
				if (!(bibiteHolder != null))
				{
					return 0;
				}
				return bibiteHolder.transform.childCount;
			}
		}

		public List<GameObject> allBibites => (from g in bibiteHolder.GetAllChilds()
			where g.CompareTag("bibite")
			select g).ToList();

		public List<GameObject> allEggs => (from g in bibiteHolder.GetAllChilds()
			where g.CompareTag("egg")
			select g).ToList();

		private static void UpdateMinPelletSize(float val)
		{
			minPelletSize = val;
		}

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			Instance = this;
			if (freePelletHolder == null)
			{
				freePelletHolder = GenerateObjectHolder();
			}
		}

		private void Start()
		{
			plantEntry.GetComponent<MatterPellet>().material = MatterMaterialManager.Plant;
			meatEntry.GetComponent<MatterPellet>().material = MatterMaterialManager.Meat;
			MatterMaterialManager.PhysicalMaterials.ForEach(delegate(MatterMaterial m)
			{
				pelletsOfMaterial.Add(m, new List<MatterPellet>());
			});
		}

		public GameObject GenerateNewBibite(Vector3? pos = null)
		{
			return UnityEngine.Object.Instantiate(bibiteEntry, pos ?? Vector3.zero, Quaternion.identity, bibiteHolder.transform);
		}

		public GameObject SpawnBibiteFromTemplate(BibiteTemplate template, RandomizeGenes randomizeGenes = RandomizeGenes.No, Tagging taggingChoice = Tagging.NoTagging, GrowthAtSpawn targetGrowth = GrowthAtSpawn.Egg, Vector3? pos = null, float? angle = null, string customTag = "")
		{
			Quaternion rotation = Quaternion.Euler(0f, 0f, angle ?? ((float)UnityEngine.Random.Range(0, 360)));
			if (targetGrowth == GrowthAtSpawn.Egg)
			{
				return SpawnEggFromTemplate(template, randomizeGenes, taggingChoice, pos, customTag);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(bibiteEntry, pos ?? Vector3.zero, rotation, bibiteHolder.transform);
			BibiteGenes component = gameObject.GetComponent<BibiteGenes>();
			NEATBrain component2 = gameObject.GetComponent<NEATBrain>();
			BibiteBody component3 = gameObject.GetComponent<BibiteBody>();
			if (randomizeGenes == RandomizeGenes.AllGenes)
			{
				component.generation = template.generation;
				component.RandomGenes();
			}
			else
			{
				component.StartGenesFromTemplate(template, taggingChoice, customTag);
				switch (randomizeGenes)
				{
				case RandomizeGenes.NormalMutations:
					component.Mutate();
					break;
				case RandomizeGenes.Color:
					component.RandomColor();
					break;
				}
			}
			component2.CopyBrain(template.nodes, template.synapses, mutate: false);
			component3.StartBodyAtGrowthAndNormalize(targetGrowth switch
			{
				GrowthAtSpawn.Baby => BibiteGenes.GrowthAtBirth(template.genes), 
				GrowthAtSpawn.Adult => BibiteGenes.GrowthAtMature(template.genes), 
				GrowthAtSpawn.Elder => 2f * BibiteGenes.GrowthAtMature(template.genes), 
				_ => 1f, 
			});
			return gameObject;
		}

		public GameObject SpawnEggFromTemplate(BibiteTemplate template, RandomizeGenes randomizeGenes = RandomizeGenes.No, Tagging taggingChoice = Tagging.NoTagging, Vector3? position = null, string customTag = "")
		{
			ZoneManager instance = ZoneManager.instance;
			Vector3 value = position ?? ((Vector3)instance.GetRandomPositionInZone() + pelletOffset);
			GameObject obj = Instance.GenerateNewEgg(value);
			BibiteGenes component = obj.GetComponent<BibiteGenes>();
			EggHatching component2 = obj.GetComponent<EggHatching>();
			NEATBrain component3 = obj.GetComponent<NEATBrain>();
			component.StartGenesFromTemplate(template, taggingChoice, customTag);
			if (randomizeGenes == RandomizeGenes.AllGenes)
			{
				component.RandomGenes();
			}
			else
			{
				component.Mutate((int)component.genes[9]);
				if (randomizeGenes == RandomizeGenes.Color)
				{
					component.RandomColor();
				}
			}
			component2.energy = component.LayBodyEnergy;
			component3.CopyBrain(template.nodes, template.synapses, mutate: true);
			component2.StartHatch();
			return obj;
		}

		public GameObject GenerateNewEgg(Vector3? pos = null)
		{
			pos += pelletOffset;
			return UnityEngine.Object.Instantiate(eggEntry, pos ?? pelletOffset, Quaternion.identity, bibiteHolder.transform);
		}

		public Transform GenerateObjectHolder()
		{
			return UnityEngine.Object.Instantiate(objectHolder).transform;
		}

		public RadioZone SpawnRadioZone(BibiteBody source)
		{
			RadioZone component = UnityEngine.Object.Instantiate(radioZone, source.transform.position, Quaternion.identity).GetComponent<RadioZone>();
			component.SetAttachedBibite(source);
			return component;
		}

		public void OnPelletDestroy(MatterPellet pellet)
		{
			allPellets.Remove(pellet);
			pelletsOfMaterial[pellet.material].Remove(pellet);
		}

		public MatterPellet SpawnPelletOfMatter(MatterMaterial mat, Vector3? pos = null, float? energy = null, float? amount = null, Transform holder = null)
		{
			if (pos.HasValue)
			{
				pos += pelletOffset;
			}
			MatterPellet component = GeneratePelletOfMatter(mat, pos, holder).GetComponent<MatterPellet>();
			pelletsOfMaterial[component.material].Add(component);
			allPellets.Add(component);
			if (amount.HasValue)
			{
				component.InitializePelletWithAmount(amount.Value);
			}
			else
			{
				float newEnergy = energy ?? ScenarioSettings.Instance.pelletEnergy.val;
				component.InitializePelletWithEnergy(newEnergy);
			}
			return component;
		}

		public MatterPellet SpawnPlantPellet(Vector3? pos = null, float? energy = null, float? amount = null, Transform holder = null)
		{
			return SpawnPelletOfMatter(MatterMaterialManager.Plant, pos, energy, amount, holder);
		}

		public MatterPellet SpawnMeatPellet(Vector3? pos = null, float? energy = null, float? amount = null, Transform holder = null)
		{
			return SpawnPelletOfMatter(MatterMaterialManager.Meat, pos, energy, amount, holder);
		}

		public void SpawnMeatPile(float totalEnergy, Vector3 pos, float radius)
		{
			int num = 1;
			if ((float)num >= 2f)
			{
				float num2 = Mathf.Max(MatterMaterialManager.Meat.NormalEnergyAtScale1, totalEnergy / (float)num);
				while (totalEnergy > 0f)
				{
					float num3;
					if (totalEnergy / num2 < 1.5f)
					{
						num3 = totalEnergy;
						totalEnergy = 0f;
					}
					else
					{
						num3 = UnityEngine.Random.Range(0.75f * num2, 1.25f * num2);
						totalEnergy -= num3;
					}
					if (!(num3 < MatterMaterialManager.Meat.EnergyDensity * minPelletSize))
					{
						pos.x += UnityEngine.Random.Range(0f - radius, radius);
						pos.y += UnityEngine.Random.Range(0f - radius, radius);
						SpawnMeatPellet(pos, num3);
					}
				}
			}
			else if (!(totalEnergy < MatterMaterialManager.Meat.EnergyDensity * minPelletSize))
			{
				radius *= 0.1f;
				pos.x += UnityEngine.Random.Range(0f - radius, radius);
				pos.y += UnityEngine.Random.Range(0f - radius, radius);
				SpawnMeatPellet(pos, totalEnergy);
			}
		}

		private GameObject GeneratePelletOfMatter(MatterMaterial material, Vector3? pos = null, Transform holder = null)
		{
			if (material == MatterMaterialManager.Plant)
			{
				return GenerateNewPlantPellet(pos, holder);
			}
			if (material == MatterMaterialManager.Meat)
			{
				return GenerateNewMeatPellet(pos, holder);
			}
			return null;
		}

		private GameObject GenerateNewPlantPellet(Vector3? pos = null, Transform holder = null)
		{
			return UnityEngine.Object.Instantiate(plantEntry, pos ?? Vector3.zero, Quaternion.identity, (holder != null) ? holder : freePelletHolder);
		}

		private GameObject GenerateNewMeatPellet(Vector3? pos = null, Transform holder = null)
		{
			return UnityEngine.Object.Instantiate(meatEntry, pos ?? Vector3.zero, Quaternion.identity, (holder != null) ? holder : freePelletHolder);
		}

		public void GenerateNewPelletSpawnerManager(Vector3? pos = null)
		{
			if (ZoneManager.instance != null)
			{
				UnityEngine.Object.DestroyImmediate(ZoneManager.instance.gameObject);
			}
			UnityEngine.Object.Instantiate(pelletSpawner, pos ?? Vector3.zero, Quaternion.identity).GetComponent<ZoneManager>().InitializeSpawner();
		}

		public Zone GenerateNewZone(ZoneSettings settings)
		{
			Zone component = UnityEngine.Object.Instantiate(pelletSpawnPoint, ZoneManager.instance.transform).GetComponent<Zone>();
			component.InitializeZone(settings);
			return component;
		}

		public void GenerateColorSelector()
		{
			GenerateColorKiller();
		}

		public ColorKiller GenerateColorKiller()
		{
			return UnityEngine.Object.Instantiate(colorKiller, -1000000f * Vector3.one, Quaternion.identity, colorKillerHolder.transform).GetComponent<ColorKiller>();
		}

		public GameObject GenerateNewBibiteSpawner(Vector3? pos = null)
		{
			return UnityEngine.Object.Instantiate(bibiteSpawner, pos ?? Vector3.zero, Quaternion.identity);
		}

		public GameObject GenerateNewPheromonesSource(Vector3? pos = null)
		{
			return UnityEngine.Object.Instantiate(pheromonesSource, pos ?? Vector3.zero, Quaternion.identity, pheromoneHolder.transform);
		}
	}
}
