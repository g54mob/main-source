using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SteamIntegrations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteBody : MonoBehaviour, ISaveable
	{
		[NonSerialized]
		public NEATBrain brain;

		[NonSerialized]
		public BibiteGenes gene;

		[Header("Bibite Scripts")]
		private Rigidbody2D rb2d;

		[NonSerialized]
		public BibiteGrowth growth;

		[NonSerialized]
		public InternalClock clock;

		public BibiteID id;

		[FormerlySerializedAs("control")]
		public BibitePheromoneOrgan pheromoneOrgan;

		public BibiteProceduralSpriter bibiteProceduralSpriter;

		public BibiteMouth mouth;

		public BibiteStomach stomach;

		public BibiteEggLayingOrgan eggLayer;

		public BibiteFatOrgan fat;

		public BibiteArmor armor;

		public BibitePropulsion move;

		public FieldOfView fow;

		public List<BibitePart> bodyParts = new List<BibitePart>();

		private List<BibiteOrgan> organs;

		public CapsuleCollider2D bodyCollider;

		[NonSerialized]
		public Material Skin;

		[NonSerialized]
		[Header("Variables")]
		public UnityEvent<GameObject> onBodyCollided = new UnityEvent<GameObject>();

		public const float NormalBodyPointAtSize1 = 100f;

		private static readonly int HurtAmount = Shader.PropertyToID("_HurtAmount");

		public Matter Energy = new Matter
		{
			Material = MatterMaterialManager.Energy
		};

		public Matter Health = new Matter
		{
			Material = MatterMaterialManager.Health,
			MaxAmount = 1f
		};

		[SerializeField]
		public float d2Size;

		public float d1Size;

		public float baseMass;

		[SerializeField]
		public bool dying;

		[SerializeField]
		public bool dead;

		[NonSerialized]
		public bool born;

		[SerializeField]
		public float attackedDmg;

		[SerializeField]
		public int timesAttacked;

		[SerializeField]
		public float totalDamageSuffered;

		[SerializeField]
		public float brainTicksCount;

		[SerializeField]
		public float visionLookupCount;

		[SerializeField]
		public float visionSensingCount;

		private float damagedFlash;

		private float metabolicEfficiency;

		private float metabolicRate;

		public float metabolism;

		public float healingRateEnergyCost;

		private bool naturalBirth;

		[NonSerialized]
		public float inflateFactor;

		public float baseEnergyDensity;

		[NonSerialized]
		public UnityEvent<BibiteBody> onDeath = new UnityEvent<BibiteBody>();

		private static readonly FloatSetting BibiteMassDensity = ScenarioSettings.Instance.bibiteMassDensity;

		private static readonly FloatSetting AgingThreshold = ScenarioSettings.Instance.ageingThreshold;

		private static readonly FloatSetting AgeMetabolismPenalties = ScenarioSettings.Instance.ageMetabolismPenalties;

		private static readonly FloatSetting AgeStrengthPenalties = ScenarioSettings.Instance.ageStrengthPenalties;

		private static readonly FloatSetting MetabolismCost = ScenarioSettings.Instance.baseMetabolismCost;

		private static readonly IntSetting BrainTPS = ScenarioIndependentSettings.Instance.brainTPS;

		private static readonly IntSetting visionLookupFactor = ScenarioIndependentSettings.Instance.visionLookupUpdateFactor;

		private static readonly IntSetting VisionSensingFactor = ScenarioIndependentSettings.Instance.visionSenseUpdateFactor;

		private static readonly FloatSetting HealthPerArea = ScenarioSettings.Instance.healthPerArea;

		private static readonly FloatSetting HealthEnergyFactor = ScenarioSettings.Instance.healthEnergyFactor;

		private static readonly FloatSetting HealRate = ScenarioSettings.Instance.healRate;

		private static readonly FloatSetting HealEfficiency = ScenarioSettings.Instance.healEfficiency;

		private static readonly FloatSetting HealPowerFactor = ScenarioSettings.Instance.healPowerFactor;

		private static float healthPerArea = HealthPerArea.SubscribeTo<FloatSetting, float>(UpdateHealthPerArea);

		private static float healthEnergyFactor = HealthEnergyFactor.SubscribeTo<FloatSetting, float>(UpdateHealthEnergyFactor);

		private static float healRate = HealRate.SubscribeTo<FloatSetting, float>(UpdateHealRate);

		private static float healEfficiency = HealEfficiency.SubscribeTo<FloatSetting, float>(UpdateHealEfFiciency);

		private static float healPowerFactor = HealPowerFactor.SubscribeTo<FloatSetting, float>(UpdateHealPowerFactor);

		private static float bibiteMassDensity = BibiteMassDensity.SubscribeTo<FloatSetting, float>(UpdateBibiteMassDensity);

		private static float baseAgingThreshold = AgingThreshold.SubscribeTo<FloatSetting, float>(UpdateAgingThreshold);

		private static float ageStrengthPenalties = AgeStrengthPenalties.SubscribeTo<FloatSetting, float>(UpdateAgeStrengthPenalties);

		private static float ageMetabolismPenalties = AgeMetabolismPenalties.SubscribeTo<FloatSetting, float>(UpdateAgeMetabolismPenalties);

		private static float metabolismCost = MetabolismCost.SubscribeTo<FloatSetting, float>(UpdateMetabolismCost);

		private static float dragConstant = ScenarioSettings.Instance.dragCoefficient.SubscribeTo<FloatSetting, float>(UpdateDragCoefficient);

		private static int brainTickFactor = BrainTPS.SubscribeTo<IntSetting, int>(UpdateBrainTPS);

		private static int visionLookupPeriod = visionLookupFactor.SubscribeTo<IntSetting, int>(UpdateVisionLookupFactor);

		private static int visionSensingPeriod = VisionSensingFactor.SubscribeTo<IntSetting, int>(UpdateVisionSenseFactor);

		private static readonly int IsRainbow = Shader.PropertyToID("_IsRainbow");

		private static readonly int VirusColor = Shader.PropertyToID("_VirusColor");

		private static readonly int InfectedRatio = Shader.PropertyToID("_InfectedRatio");

		private static readonly int IsProducer = Shader.PropertyToID("_IsProducer");

		private static readonly int IsKiller = Shader.PropertyToID("_IsKiller");

		private static readonly int UPP = Shader.PropertyToID("_upp");

		private static readonly int Pos = Shader.PropertyToID("_RootPos");

		private static readonly int Dir = Shader.PropertyToID("_Dir");

		private static readonly FloatSetting EnergyUsageEfficiency = ScenarioSettings.Instance.energyUsageEfficiency;

		public float mass => baseMass + stomach.mass + eggLayer.mass + fat.mass + armor.mass;

		public float EnergyFlowRate => stomach.EnergyGainRate + fat.lastEnergyGainRate - (fat.lastEnergySustainRate + growth.growthCostRate + healingRateEnergyCost + metabolism + move.movementCost + brain.brainUpkeepCost + eggLayer.energyConsumption) / metabolicEfficiency;

		public float healMaxRate => Mathf.Pow(1f / d2Size, healPowerFactor) * healRate * metabolicRate;

		public float armorStrength => 2f * armor.armorStrength;

		public float armorThickness => armor.armorThickness;

		public float effectiveRadius => Mathf.Sqrt(realBodyArea / MathF.PI);

		public float internalsRadius => effectiveRadius - armorThickness;

		public float sideRadius => 4.5f * d1Size;

		public float totalEnergy
		{
			get
			{
				if (!(gene == null) && !dead)
				{
					return gene.SumBodyAndHealthEnergyRatio * baseBodyArea + Energy.Amount + eggLayer.storedEnergy + fat.fatReserves.energy;
				}
				return 0f;
			}
		}

		public float health
		{
			get
			{
				return Health.Amount;
			}
			private set
			{
				Health.Amount = value;
			}
		}

		public float maxHealth
		{
			get
			{
				return Health.MaxAmount;
			}
			private set
			{
				Health.MaxAmount = value;
			}
		}

		internal float healthRatio => Health.Amount / Health.MaxAmount;

		internal float energyRatio => Energy.Amount / Energy.MaxAmount;

		public float bodyLength => 12.5f * d1Size;

		public float baseBodyArea => 80f * d2Size;

		public float realBodyArea => baseBodyArea * (1f + inflateFactor);

		public float energyDensity => totalEnergy / realBodyArea;

		public float age => clock.timeAlive / 3600f;

		public float agingThreshold => baseAgingThreshold / metabolicRate;

		public float ageingFactor => Mathf.Max((age - agingThreshold) / agingThreshold, 0f);

		public float ageStrengthPenaltyFactor => Mathf.Pow(1f - ageStrengthPenalties, ageingFactor);

		public float ageMetabolismPenaltyFactor => ageingFactor * ageMetabolismPenalties;

		private static void UpdateHealthPerArea(float val)
		{
			healthPerArea = val;
		}

		private static void UpdateHealthEnergyFactor(float val)
		{
			healthEnergyFactor = val;
		}

		private static void UpdateDragCoefficient(float val)
		{
			dragConstant = val;
		}

		private static void UpdateBibiteMassDensity(float val)
		{
			bibiteMassDensity = val;
		}

		private static void UpdateAgingThreshold(float val)
		{
			baseAgingThreshold = val;
		}

		private static void UpdateAgeStrengthPenalties(float val)
		{
			ageStrengthPenalties = val;
		}

		private static void UpdateAgeMetabolismPenalties(float val)
		{
			ageMetabolismPenalties = val;
		}

		private static void UpdateMetabolismCost(float val)
		{
			metabolismCost = val;
		}

		private static void UpdateHealRate(float val)
		{
			healRate = val;
		}

		private static void UpdateHealEfFiciency(float val)
		{
			healEfficiency = val;
		}

		private static void UpdateHealPowerFactor(float val)
		{
			healPowerFactor = val;
		}

		private static void UpdateBrainTPS(int val)
		{
			brainTickFactor = val;
		}

		private static void UpdateVisionLookupFactor(int val)
		{
			visionLookupPeriod = val;
		}

		private static void UpdateVisionSenseFactor(int val)
		{
			visionSensingPeriod = val;
		}

		private void UpdateMetabolicEfficiency(float val)
		{
			metabolicEfficiency = gene.MetabolicEfficiency;
		}

		private void Awake()
		{
			rb2d = GetComponent<Rigidbody2D>();
			growth = GetComponent<BibiteGrowth>();
			clock = GetComponent<InternalClock>();
			gene = GetComponent<BibiteGenes>();
			brain = GetComponent<NEATBrain>();
			pheromoneOrgan = GetComponent<BibitePheromoneOrgan>();
			rb2d.angularDamping = ScenarioSettings.Instance.dragCoefficient.val / 2f;
		}

		private void Start()
		{
			if (dying)
			{
				Die();
			}
			if (dead)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public void StartBody()
		{
			d2Size = 0f;
			naturalBirth = true;
			metabolicEfficiency = gene.MetabolicEfficiency;
			metabolicRate = gene.metabolicRate;
			float newSize = gene.D2SizeAtBirth;
			float bodyEnergyAtBirth = gene.BodyEnergyAtBirth;
			baseEnergyDensity = gene.BodyEnergyDensity;
			if (Energy.Amount < bodyEnergyAtBirth)
			{
				newSize = Energy.Amount / bodyEnergyAtBirth;
			}
			float qtyE = Set2DSize(newSize, initialSet: true);
			health = maxHealth;
			UseEnergy(qtyE, useEfficiency: false);
			if (Energy.Amount > Energy.MaxAmount)
			{
				UseEnergy(Energy.overflow, useEfficiency: false);
			}
			growth.StartGrowth();
			clock.StartClock();
			GlobalLineageManager.Instance.CheckNewSpecies(this);
			brainTicksCount = UnityEngine.Random.Range(0, brainTickFactor);
			visionSensingCount = UnityEngine.Random.Range(0, visionSensingPeriod);
			visionLookupCount = UnityEngine.Random.Range(0, visionLookupPeriod);
			FinalizeBirth();
		}

		public void StartBodyAtGrowthAndNormalize(float targetGrowth)
		{
			float num = gene.Gene(BibiteGenes.Genes.SizeRatio);
			float newSize = targetGrowth * num * num;
			metabolicEfficiency = gene.MetabolicEfficiency;
			metabolicRate = gene.metabolicRate;
			baseEnergyDensity = gene.BodyEnergyDensity;
			Set2DSize(newSize);
			health = maxHealth;
			Energy.Amount = Energy.MaxAmount;
			growth.growth = targetGrowth;
			brainTicksCount = UnityEngine.Random.Range(0, brainTickFactor);
			visionSensingCount = UnityEngine.Random.Range(0, visionSensingPeriod);
			visionLookupCount = UnityEngine.Random.Range(0, visionLookupPeriod);
			ResumeBody();
		}

		public void ResumeBody()
		{
			baseEnergyDensity = gene.BodyEnergyDensity;
			metabolicEfficiency = gene.MetabolicEfficiency;
			metabolicRate = gene.metabolicRate;
			Set2DSize(d2Size, initialSet: true);
			Hurting(Health.overflow);
			growth.ResumeGrowth();
			clock.ResumeClock();
			if (gene.species == null)
			{
				GlobalLineageManager.Instance.CheckNewSpecies(this);
			}
			FinalizeBirth();
		}

		private void FinalizeBirth()
		{
			if (dying || dead)
			{
				return;
			}
			bibiteProceduralSpriter.InitSprites();
			bibiteProceduralSpriter.SpriteChangeFromGrowth(growth.growth);
			Skin = bibiteProceduralSpriter.RequestSkinMaterial();
			Skin.SetFloat(UPP, d1Size / bibiteProceduralSpriter.ppu);
			Skin.SetVector(Pos, base.transform.position);
			Skin.SetVector(Dir, base.transform.up);
			organs = new List<BibiteOrgan> { armor, stomach, eggLayer, fat, move, mouth, pheromoneOrgan };
			organs.ForEach(delegate(BibiteOrgan o)
			{
				o.InitOrgan(this);
			});
			clock.OnAging.AddListener(UpdateMetabolism);
			MetabolismCost.SubscribeTo<FloatSetting, float>(UpdateMetabolism, invokeNow: true);
			EnergyUsageEfficiency.Subscribe(UpdateMetabolicEfficiency);
			fow.viewAngle = gene.Gene(BibiteGenes.Genes.ViewAngle);
			fow.herdSeparationDistance = gene.Gene(BibiteGenes.Genes.HerdSeparationDistance);
			fow.separationWeight = gene.Gene(BibiteGenes.Genes.HerdSeparationWeight);
			fow.cohesionWeight = gene.Gene(BibiteGenes.Genes.HerdCohesionWeight);
			fow.alignmentWeight = gene.Gene(BibiteGenes.Genes.HerdAlignmentWeight);
			foreach (BibitePart bodyPart in bodyParts)
			{
				bodyPart.StartPart();
			}
			for (int num = 0; num < bodyParts.Count; num++)
			{
				for (int num2 = num + 1; num2 < bodyParts.Count; num2++)
				{
					Physics2D.IgnoreCollision(bodyParts[num].partCollider, bodyParts[num2].partCollider);
				}
			}
			id.CheckGetNew();
			if (gene.isRad)
			{
				Skin.SetFloat(InfectedRatio, 1.25f);
				Skin.SetColor(VirusColor, RadioZone.color);
				WorldObjectsSpawner.Instance.SpawnRadioZone(this);
			}
			if (gene.isRain)
			{
				Skin.SetInt(IsRainbow, 1);
			}
			if (gene.isSource)
			{
				Skin.SetInt(IsProducer, 1);
				base.gameObject.AddComponent<PelletProducer>();
			}
			if (gene.isKiller)
			{
				BecomeReaper();
			}
			born = true;
			if (naturalBirth && !dying && !dead && brain.Nodes.Length - NEATBrain.NInputs - NEATBrain.NOutputs >= 100)
			{
				AchievementManager.Trigger("ACH_BIBITE_EINSTEIN", base.gameObject);
			}
			gene.species.AddToSpecies(this);
			if (!string.IsNullOrEmpty(gene.speciesTag))
			{
				TagsManager.instance.AddToTag(this, gene.speciesTag);
			}
			BibiteTracker.instance.BibiteBirth(this);
		}

		private void Update()
		{
			if (born)
			{
				Skin.SetVector(Pos, base.transform.position);
				Skin.SetVector(Dir, base.transform.up);
				if (!(Time.deltaTime <= 0f) && damagedFlash > 0f)
				{
					damagedFlash -= Time.deltaTime / 0.5f;
					damagedFlash = Mathf.Max(damagedFlash, 0f);
					Skin.SetFloat(HurtAmount, damagedFlash);
				}
			}
		}

		private void FixedUpdate()
		{
			if (!born || !(Time.timeScale > 0f) || dying)
			{
				return;
			}
			UseEnergy((metabolism + brain.brainUpkeepCost) * Time.fixedDeltaTime);
			brainTicksCount += 1f;
			if (brainTicksCount >= (float)brainTickFactor)
			{
				visionLookupCount += 1f;
				if (visionLookupCount >= (float)visionLookupPeriod)
				{
					fow.FindSeenEntities();
					visionLookupCount -= visionLookupPeriod;
				}
				visionSensingCount += 1f;
				if (visionSensingCount >= (float)visionSensingPeriod)
				{
					fow.ComputeSenses();
					visionSensingCount -= visionSensingPeriod;
				}
				brain.Thinker();
				brainTicksCount -= brainTickFactor;
			}
			if (attackedDmg > 0f)
			{
				attackedDmg = Mathf.Max(0f, attackedDmg * Mathf.Pow(0.70716f, Time.fixedDeltaTime) - 0.003f * Time.fixedDeltaTime);
			}
			organs.ForEach(delegate(BibiteOrgan o)
			{
				o.UpdateOrgan();
			});
			if (float.IsNaN(health))
			{
				Die();
			}
			Heal();
			rb2d.mass = mass;
			rb2d.inertia = rb2d.mass / 2f * realBodyArea / MathF.PI;
			UpdateDrag();
		}

		public void OnJointBreak2D(Joint2D brokenJoint)
		{
			if (mouth != null)
			{
				mouth.OnLinkBroke(brokenJoint);
			}
		}

		internal void UseEnergy(float qtyE, bool useEfficiency = true)
		{
			float num = qtyE / (useEfficiency ? metabolicEfficiency : 1f);
			if (Energy.Amount > num)
			{
				Energy.Amount -= num;
				return;
			}
			num -= Energy.Amount;
			Energy.Amount = 0f;
			Hurting(Health.Material.AmountOfEnergy(num));
		}

		private void Heal()
		{
			if (health < maxHealth)
			{
				float num = Mathf.Min(maxHealth * healMaxRate * brain.Output(NEATBrain.Outputs.Want2Heal) * Time.fixedDeltaTime, maxHealth - health);
				float num2 = num * gene.HealthEnergyRatio / healEfficiency;
				healingRateEnergyCost = num2 / Time.fixedDeltaTime;
				UseEnergy(num2);
				health += num;
			}
			else
			{
				healingRateEnergyCost = 0f;
			}
		}

		internal float GainEnergy(float qtyE)
		{
			float available = Energy.available;
			if (available > qtyE)
			{
				Energy.Amount += qtyE;
				return qtyE;
			}
			Energy.Amount = Energy.MaxAmount;
			return available;
		}

		internal float Set2DSize(float newSize, bool initialSet = false, bool updateScale = true)
		{
			float num = newSize - d2Size;
			d2Size = newSize;
			d1Size = Mathf.Sqrt(d2Size);
			float num2 = num * 80f;
			if (updateScale)
			{
				rb2d.transform.localScale = Vector3.one * d1Size;
				if (born)
				{
					Skin.SetFloat(UPP, d1Size / bibiteProceduralSpriter.ppu);
				}
			}
			if (!initialSet)
			{
				health += healthPerArea * num2;
			}
			maxHealth = healthPerArea * baseBodyArea;
			Energy.MaxAmount = baseBodyArea * ScenarioSettings.Instance.storableEnergyPerArea.val;
			UpdateMetabolism();
			fow.herdSeparationDistance = gene.Gene(BibiteGenes.Genes.HerdSeparationDistance) * d1Size;
			fow.viewRadius = gene.Gene(BibiteGenes.Genes.ViewRadius) * d1Size;
			baseMass = bibiteMassDensity * baseBodyArea;
			return num2 * baseEnergyDensity * (1f + healthEnergyFactor);
		}

		public void UpdateInflateFactor(float newInflateFactor)
		{
			inflateFactor = newInflateFactor;
			bodyCollider.offset = new Vector2(0f, Mathf.Lerp(-4.7f, -5.5f, inflateFactor));
			bodyCollider.size = new Vector2(Mathf.Lerp(5f, 8.5f, inflateFactor), Mathf.Lerp(7f, 10.5f, inflateFactor));
			bibiteProceduralSpriter.SpriteChangeFromInflate(inflateFactor);
			armor.UpdateThickness();
		}

		public void UpdateDrag()
		{
			rb2d.linearDamping = dragConstant * d1Size / rb2d.mass;
			rb2d.angularDamping = rb2d.linearDamping;
		}

		public void UpdateMetabolism()
		{
			metabolism = metabolismCost * baseBodyArea * (1f + ageMetabolismPenaltyFactor);
		}

		public float Attack(float dmg, bool drain)
		{
			float num = Hurting(dmg);
			attackedDmg += num;
			totalDamageSuffered += num;
			if (!drain)
			{
				timesAttacked++;
			}
			return num * gene.HealthEnergyRatio;
		}

		public float Hurting(float dmg)
		{
			float num = Mathf.Min(dmg, health + 0.01f);
			damagedFlash = Mathf.Max(damagedFlash, Mathf.Min(2f * num / health, 1f));
			health -= num;
			if (health < 0f)
			{
				Die();
			}
			return num;
		}

		public void BecomeReaper()
		{
			gene.isKiller = true;
			Skin.SetFloat(IsKiller, 1f);
			mouth.instaKill = true;
		}

		public void Die(bool swallowed = false)
		{
			dying = true;
			if (dead)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			onDeath.Invoke(this);
			if (born)
			{
				BibiteTracker.instance.BibiteDeath(this);
				if (swallowed)
				{
					eggLayer.eggProgress = 0f;
				}
				foreach (BibiteOrgan organ in organs)
				{
					organ.OnDeath();
				}
				if (!swallowed)
				{
					WorldObjectsSpawner.Instance.SpawnMeatPile(totalEnergy, base.transform.position, bodyLength / 2f);
				}
				gene.species.RemoveFromSpecies(this);
				if (!string.IsNullOrEmpty(gene.speciesTag))
				{
					TagsManager.instance.RemoveFromTag(this, gene.speciesTag);
				}
			}
			dead = true;
			onDeath.RemoveAllListeners();
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnDestroy()
		{
			if (gene != null)
			{
				gene.species?.RemoveFromSpecies(this);
				if (!string.IsNullOrEmpty(gene.speciesTag))
				{
					TagsManager.instance.RemoveFromTag(this, gene.speciesTag);
				}
			}
			if (BibiteTracker.instance != null)
			{
				BibiteTracker.instance.BibiteDeath(this);
			}
			UnityEngine.Object.Destroy(brain);
			UnityEngine.Object.Destroy(fow);
			UnityEngine.Object.Destroy(pheromoneOrgan);
			brain = null;
			gene = null;
			growth = null;
			clock = null;
			pheromoneOrgan = null;
			bibiteProceduralSpriter = null;
			mouth = null;
			stomach = null;
			eggLayer = null;
			fat = null;
			fow = null;
			bodyParts = null;
			organs = null;
			Skin = null;
			move = null;
			armor = null;
			MetabolismCost.UnSubscribeTo<FloatSetting, float>(UpdateMetabolism);
			EnergyUsageEfficiency.UnSubscribe(UpdateMetabolicEfficiency);
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["mouth"] = mouth.SaveState();
			jObject["stomach"] = stomach.SaveState();
			jObject["phero"] = pheromoneOrgan.SaveState();
			jObject["health"] = Health.Amount;
			jObject["energy"] = Energy.Amount;
			jObject["eggLayer"] = eggLayer.SaveState();
			jObject["control"] = move.SaveState();
			jObject["fatReservesAmount"] = fat.fatReserves.Amount;
			jObject["id"] = id.id;
			foreach (FieldInfo item in from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where field.IsDefined(typeof(SerializeField), inherit: false)
				select field)
			{
				if (item.GetValue(this) != null)
				{
					jObject[item.Name] = JToken.FromObject(item.GetValue(this));
				}
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			foreach (KeyValuePair<string, JToken> item in state)
			{
				FieldInfo field = GetType().GetField(item.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (!(field == null) && field.IsDefined(typeof(SerializeField), inherit: false))
				{
					field.SetValue(this, item.Value.ToObject(field.FieldType));
				}
			}
			if (state["mouth"] != null)
			{
				mouth.LoadState((JObject)state["mouth"]);
			}
			if (state["stomach"] != null)
			{
				stomach.LoadState((JObject)state["stomach"]);
			}
			if (state["phero"] != null)
			{
				pheromoneOrgan.LoadState((JObject)state["phero"]);
			}
			if (state["eggLayer"] != null)
			{
				eggLayer.LoadState((JObject)state["eggLayer"]);
			}
			if (state["control"] != null)
			{
				move.LoadState((JObject)state["control"]);
			}
			if (state["fatReservesAmount"] != null)
			{
				fat.fatReserves.Amount = state["fatReservesAmount"].ToObject<float>();
			}
			if (state["id"] != null)
			{
				id.id = state["id"].ToObject<int>();
			}
			else if (state["bibiteID"] != null)
			{
				id.id = state["bibiteID"].ToObject<int>();
			}
			Health.Amount = state["health"].ToObject<float>();
			Energy.Amount = state["energy"].ToObject<float>();
			growth.growth = d2Size / (gene.Gene(BibiteGenes.Genes.SizeRatio) * gene.Gene(BibiteGenes.Genes.SizeRatio));
		}
	}
}
