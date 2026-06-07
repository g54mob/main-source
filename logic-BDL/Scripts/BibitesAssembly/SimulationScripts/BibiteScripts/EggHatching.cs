using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts.BibiteScripts
{
	public class EggHatching : MonoBehaviour, ISaveable
	{
		public BibiteGenes eggGene;

		public NEATBrain eggBrain;

		public BibiteID id;

		private BibiteGenes newBornGene;

		private NEATBrain newBornBrain;

		public BibiteBody newBornBody;

		private Rigidbody2D rb;

		public UnityEvent<EggHatching, BibiteBody> onHatch = new UnityEvent<EggHatching, BibiteBody>();

		public float energy;

		public float totalRequiredEnergy;

		public bool isHatching;

		public float hatchProgress;

		public float startTime;

		public float hatchTime;

		public bool aborting;

		[SerializeField]
		public int bibiteID;

		public Vector2 birthOrientation = Vector2.zero;

		public float sizeGene;

		public float eggMass;

		private SpriteRenderer spriteRenderer;

		private Material mat;

		private BibitePheromoneOrgan parent1;

		private BibitePheromoneOrgan parent2;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly FloatSetting BibiteMassDensity = ScenarioSettings.Instance.bibiteMassDensity;

		private static float bibiteMassDensity = BibiteMassDensity.SubscribeTo<FloatSetting, float>(UpdateBibiteMassDensity);

		private static float dragConstant = ScenarioSettings.Instance.dragCoefficient.SubscribeTo<FloatSetting, float>(UpdateDragCoefficient);

		public float freeEnergy => energy - totalRequiredEnergy * hatchProgress / hatchTime;

		public float eggArea => 5f * sizeGene * sizeGene;

		private static void UpdateDragCoefficient(float val)
		{
			dragConstant = val;
		}

		private static void UpdateBibiteMassDensity(float val)
		{
			bibiteMassDensity = val;
		}

		private void InitEgg()
		{
			eggGene = GetComponent<BibiteGenes>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			eggBrain = GetComponent<NEATBrain>();
			mat = spriteRenderer.material;
			rb = GetComponent<Rigidbody2D>();
			id = GetComponent<BibiteID>();
			hatchTime = eggGene.Gene(BibiteGenes.Genes.HatchTime);
			totalRequiredEnergy = eggGene.BodyEnergyAtBirth + eggBrain.brainUpkeepCost * eggGene.genes[3];
			sizeGene = eggGene.D1SizeAtBirth;
			int sizeIndex = ProceduralSpriteManager.Instance.ClosestSizeIndex(sizeGene, ProceduralSpriteManager.SizeTypes.EggSizes);
			spriteRenderer.sprite = ProceduralSpriteManager.Instance.RequestEggSprite(sizeIndex);
			mat.SetColor(Color1, eggGene.GetBodyColor());
			_ = eggGene.D1SizeAtBirth;
			Collider2D component = GetComponent<Collider2D>();
			bool val = ScenarioSettings.Instance.eggCollision.val;
			component.isTrigger = !val;
			eggMass = eggGene.areaAtBirth * bibiteMassDensity;
			rb.transform.localScale = Vector3.one * sizeGene;
			rb.mass = eggMass;
			UpdateDrag();
		}

		public void StartHatch(float? hatchEnergy = null)
		{
			InitEgg();
			if (hatchEnergy.HasValue)
			{
				energy = hatchEnergy ?? eggGene.LayBodyEnergy;
			}
			if (hatchTime <= 0f)
			{
				Abort();
				return;
			}
			if (totalRequiredEnergy > 2f * energy)
			{
				Abort();
				return;
			}
			bibiteID = Random.Range(1, int.MaxValue);
			eggGene.species.AddToSpecies(this);
			if (!string.IsNullOrEmpty(eggGene.speciesTag))
			{
				TagsManager.instance.AddToTag(this, eggGene.speciesTag);
			}
			BibiteTracker.instance.eggs.Add(this);
			hatchProgress = 0f;
			isHatching = true;
		}

		public void ResumeHatch()
		{
			InitEgg();
			if (!eggGene.IsReady || !eggBrain.isReady)
			{
				Abort();
				return;
			}
			GlobalLineageManager.Instance.CheckSpeciesOfEgg(this);
			eggGene.species?.AddToSpecies(this);
			if (!string.IsNullOrEmpty(eggGene.speciesTag))
			{
				TagsManager.instance.AddToTag(this, eggGene.speciesTag);
			}
			BibiteTracker.instance.eggs.Add(this);
			isHatching = true;
		}

		public void UpdateDrag()
		{
			rb.linearDamping = dragConstant * sizeGene / rb.mass;
		}

		private void FixedUpdate()
		{
			if (isHatching)
			{
				hatchProgress += Time.fixedDeltaTime;
				if (HatchRatio() * totalRequiredEnergy > energy)
				{
					Abort();
				}
				else if (hatchProgress >= hatchTime)
				{
					Hatch();
				}
			}
		}

		private void Hatch()
		{
			if (totalRequiredEnergy > energy)
			{
				Abort();
				return;
			}
			GameObject gameObject = WorldObjectsSpawner.Instance.GenerateNewBibite();
			gameObject.transform.position = base.transform.position;
			if (birthOrientation.magnitude > 0.01f)
			{
				gameObject.transform.up = birthOrientation.normalized;
			}
			else
			{
				gameObject.transform.Rotate(0f, 0f, Random.Range(1, 360));
			}
			newBornGene = gameObject.GetComponent<BibiteGenes>();
			newBornBrain = gameObject.GetComponent<NEATBrain>();
			newBornBody = gameObject.GetComponent<BibiteBody>();
			newBornGene.CopyGene(eggGene);
			newBornGene.SetParents(eggGene.parent1, eggGene.parent2);
			newBornBrain.CopyBrain(eggBrain.Nodes, eggBrain.Synapses, mutate: false);
			newBornBody.Energy.Amount = energy;
			newBornBody.id.Set(id);
			newBornBody.StartBody();
			energy = 0f;
			onHatch.Invoke(this, newBornBody);
			Object.Destroy(base.gameObject);
		}

		public void Abort()
		{
			aborting = true;
			onHatch.Invoke(this, null);
			if (energy > 0f)
			{
				WorldObjectsSpawner.Instance.SpawnMeatPile(energy, base.transform.position, base.transform.localScale.x / 2f);
			}
			if (eggGene.species != null && eggGene.species.eggs.Contains(this))
			{
				eggGene.species.RemoveFromSpecies(this);
			}
			if (!string.IsNullOrEmpty(eggGene.speciesTag))
			{
				TagsManager.instance.RemoveFromTag(this, eggGene.speciesTag);
			}
			Object.Destroy(base.gameObject);
		}

		public float HatchRatio()
		{
			return Mathf.Min(hatchProgress / hatchTime, 1f);
		}

		public JObject SaveState()
		{
			return new JObject
			{
				["hatchProgress"] = hatchProgress,
				["energy"] = energy,
				["id"] = id.id
			};
		}

		public void LoadState(JObject state)
		{
			if (state["hatchProgress"] != null)
			{
				hatchProgress = (float)state["hatchProgress"];
			}
			if (state["energy"] != null)
			{
				energy = (float)state["energy"];
			}
			if (state["id"] != null)
			{
				id.id = state["id"].ToObject<int>();
			}
		}

		private void OnDestroy()
		{
			if (eggGene != null)
			{
				eggGene.species?.RemoveFromSpecies(this);
				if (!string.IsNullOrEmpty(eggGene.speciesTag))
				{
					TagsManager.instance.RemoveFromTag(this, eggGene.speciesTag);
				}
			}
			BibiteTracker.instance.eggs.Remove(this);
			Object.Destroy(mat);
			onHatch.RemoveAllListeners();
		}
	}
}
