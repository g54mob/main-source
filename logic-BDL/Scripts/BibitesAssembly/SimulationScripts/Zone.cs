using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.Events;
using UnityEngine;
using Utility.DataLogging;

namespace SimulationScripts
{
	public class Zone : MonoBehaviour
	{
		[NonSerialized]
		public LogLikeZoneDataArray zoneData = new LogLikeZoneDataArray();

		public ZoneSettings settings;

		public Transform pelletHolder;

		public SpriteRenderer sr;

		public Material zoneMaterial;

		private Material mat;

		private static readonly int Opacity = Shader.PropertyToID("_Opacity");

		private static readonly int PelletSpawnCoefficient = Shader.PropertyToID("_PelletSpawnCoefficient");

		private static readonly int InsideRadius = Shader.PropertyToID("_insideRadius");

		private static readonly int Ring = Shader.PropertyToID("_Ring");

		private static readonly int Rect = Shader.PropertyToID("_Rect");

		private float maxD;

		private Rect rect;

		private MatterMaterial spawnMaterial;

		private float speed;

		private Vector2 vel;

		private static readonly BoolSetting EnableRedDeath = ScenarioSettings.Instance.enableRedDeath;

		private static bool enableRedDeath = EnableRedDeath.SubscribeTo<BoolSetting, bool>(UpdateEnableRedDeath);

		private static WaitForSeconds wait = new WaitForSeconds(10f);

		private static readonly FloatSetting SimulationSize = ScenarioIndependentSettings.Instance.SimulationSize;

		private static float simulationSize = SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimulationSize);

		private static readonly FloatSetting AvgPelletEnergy = ScenarioSettings.Instance.pelletEnergy;

		private System.Random r = new System.Random();

		public float radius;

		public float pelletProgress;

		public float pelletProduction;

		public float pelletBiomass;

		public float maxBiomass;

		private float avgPelletEnergy;

		private float insideRadius;

		private MovementType movement;

		public List<MatterPellet> zonePellets = new List<MatterPellet>();

		public const float RadiusExpandFactor = 1f;

		public Vector2 pos => base.transform.position;

		public float freeBiomass => maxBiomass - pelletBiomass;

		public List<GameObject> pellets => pelletHolder.gameObject.GetAllChilds();

		private static void UpdateEnableRedDeath(bool val)
		{
			enableRedDeath = val;
		}

		private static void UpdateSimulationSize(float val)
		{
			simulationSize = val;
		}

		private void UpdateSpawnMaterial(MatterMaterial val)
		{
			spawnMaterial = val;
		}

		private void UpdateMovement(MovementType val)
		{
			movement = val;
		}

		public void InitializeZone(ZoneSettings fromSettings)
		{
			settings = fromSettings;
			mat = UnityEngine.Object.Instantiate(zoneMaterial);
			sr.material = mat;
			settings.spawnMaterial.Subscribe(UpdateSpawnMaterial);
			settings.spawnMaterial.Subscribe(UpdateBiomass);
			settings.distribution.Subscribe(UpdateBiomass);
			settings.biomassDensity.Subscribe(UpdateBiomass);
			settings.insideRadius.Subscribe(UpdateBiomass);
			settings.spawnMaterial.Subscribe(UpdateFertility);
			settings.distribution.Subscribe(UpdateFertility);
			settings.fertility.Subscribe(UpdateFertility);
			settings.pelletSize.Subscribe(UpdateAvgPelletEnergy);
			settings.movement.Subscribe(UpdateMovement);
			settings.target.Subscribe(UpdateTarget);
			settings.speed.Subscribe(UpdateSpeed);
			settings.onSizeChange.AddListener(UpdateSize);
			settings.insideRadius.Subscribe(UpdateInsideRadius);
			settings.posX.Subscribe(UpdatePosition);
			settings.posY.Subscribe(UpdatePosition);
			AvgPelletEnergy.Subscribe(UpdateAvgPelletEnergy);
			SimulationSize.Subscribe(OnSimulationSizeChange);
			ScenarioIndependentSettings.Instance.biomassDensity.Subscribe(UpdateBiomass);
			ScenarioIndependentSettings.Instance.pelletGrowth.Subscribe(UpdateFertility);
			ScenarioSettings.Instance.globalZoneSpeed.Subscribe(UpdateSpeed);
			UserSettings.ShowFertility.SubscribeTo<BoolUserSetting, bool>(ToggleVisibility);
			pelletHolder = WorldObjectsSpawner.Instance.GenerateObjectHolder();
			UpdateSpawnMaterial(settings.spawnMaterial.val);
			OnSimulationSizeChange();
			UpdateAvgPelletEnergy();
			UpdateMaterial();
			UpdateInsideRadius();
			ToggleVisibility(UserSettings.ShowFertility.val);
			vel = UnityEngine.Random.insideUnitCircle * speed;
			zonePellets = new List<MatterPellet>();
			StartCoroutine(UpdateBiomassCount());
		}

		private void FixedUpdate()
		{
			if (Time.timeScale <= 0f)
			{
				return;
			}
			if (movement != MovementType.None)
			{
				Move();
			}
			if (pelletBiomass > maxBiomass)
			{
				RecyclePellets(pelletBiomass - maxBiomass);
			}
			else if ((settings.renewBiomass.val || !(pelletBiomass >= maxBiomass)) && settings.spawnMaterial != null)
			{
				pelletProgress += pelletProduction * Time.fixedDeltaTime;
				if (!settings.renewBiomass.val)
				{
					pelletProgress = Mathf.Min(pelletProgress, Mathf.Max(freeBiomass, 0f));
				}
				while (pelletProgress > 1.5f * avgPelletEnergy)
				{
					pelletProgress -= SpawnAPellet();
				}
			}
		}

		public void Move()
		{
			Vector3 position = base.transform.position;
			if (movement == MovementType.Free)
			{
				vel += UnityEngine.Random.insideUnitCircle * Time.fixedDeltaTime * speed / 10f;
				if (vel.magnitude > speed)
				{
					vel = vel.normalized * speed;
				}
				position = base.transform.position + (Vector3)vel * Time.fixedDeltaTime;
			}
			float num;
			float num2;
			if (settings.isRect)
			{
				num = simulationSize - rect.width;
				num2 = simulationSize - rect.height;
			}
			else
			{
				num = (num2 = maxD);
			}
			if (Mathf.Abs(position.x) > num)
			{
				position.x = Mathf.Sign(position.x) * num;
				vel.x *= -1f;
			}
			if (Mathf.Abs(position.y) > num2)
			{
				position.y = Mathf.Sign(position.y) * num2;
				vel.y *= -1f;
			}
			settings.posX.SetValue(position.x / simulationSize);
			settings.posY.SetValue(position.y / simulationSize);
			base.transform.position = position;
		}

		public void UpdateBiomass()
		{
			maxBiomass = settings.maxBiomass;
			UpdateMaterial();
		}

		public void UpdateFertility()
		{
			pelletProduction = settings.totalGrowth;
			UpdateMaterial();
		}

		public void UpdateMaterial()
		{
			mat.SetInt(Ring, settings.isRing ? 1 : 0);
			mat.SetInt(Rect, settings.isRect ? 1 : 0);
			mat.SetFloat(InsideRadius, settings.insideRadius.val);
			float value = Mathf.Log10(settings.fertility.val);
			float a = Mathf.Log10(settings.fertility.minValue);
			float b = Mathf.Log10(settings.fertility.maxValue);
			float value2 = Mathf.Log10(settings.biomassDensity.val);
			float a2 = Mathf.Log10(settings.biomassDensity.minValue);
			float b2 = Mathf.Log10(settings.biomassDensity.maxValue);
			float num = 1f - 0.9f * Mathf.Pow(Mathf.InverseLerp(a, b, value) - 1f, 2f);
			float num2 = 1f - 0.9f * Mathf.Pow(Mathf.InverseLerp(a2, b2, value2) - 1f, 2f);
			mat.SetFloat(Opacity, (num + num2) / 2f);
			Material material = mat;
			material.SetFloat(value: settings.distribution.val switch
			{
				SpawnDistribution.Flat => 0f, 
				SpawnDistribution.FlatRing => 0f, 
				SpawnDistribution.Rect => 0f, 
				SpawnDistribution.ExteriorGradual => -1f, 
				_ => 1f, 
			}, nameID: PelletSpawnCoefficient);
		}

		public float SpawnAPellet()
		{
			Vector2 spawnLocation = GetSpawnLocation();
			float num = avgPelletEnergy * Mathf.Clamp(r.NextPowerGaussian(1.5f), 0.1f, 5f);
			if (enableRedDeath && spawnLocation.magnitude > RedDeathBloomManager.safeRadius)
			{
				return num;
			}
			WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
			MatterMaterial matterMaterial = spawnMaterial;
			Vector3? vector = spawnLocation;
			float? energy = num;
			Transform holder = pelletHolder;
			MatterPellet matterPellet = instance.SpawnPelletOfMatter(matterMaterial, vector, energy, null, holder);
			if (matterPellet == null)
			{
				return 0f;
			}
			zonePellets.Add(matterPellet);
			matterPellet.onPelletGone.AddListener(RemovePelletFromList);
			pelletBiomass += num;
			return num;
		}

		public void RemovePelletFromList(MatterPellet pellet)
		{
			zonePellets.Remove(pellet);
			pellet.onPelletGone.RemoveListener(RemovePelletFromList);
		}

		public Vector2 GetSpawnLocation()
		{
			Vector2 vector = settings.distribution.val switch
			{
				SpawnDistribution.Ring => RandomExtension.RandomPointInRing(radius, insideRadius, 3f), 
				SpawnDistribution.FlatRing => RandomExtension.RandomPointInRing(radius, insideRadius), 
				SpawnDistribution.Rect => new Vector2(UnityEngine.Random.Range(-1f, 1f) * settings.absoluteWidth / 2f, UnityEngine.Random.Range(-1f, 1f) * settings.absoluteHeight / 2f), 
				_ => radius * InsideUnitCircleWarped(), 
			};
			return pos + vector;
		}

		public Vector2 InsideUnitCircleWarped()
		{
			Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
			float magnitude = insideUnitCircle.magnitude;
			float p = settings.distribution.val switch
			{
				SpawnDistribution.Flat => 1f, 
				SpawnDistribution.CentricGradual => 0.5f, 
				SpawnDistribution.ExteriorGradual => 2f, 
				_ => 1f, 
			};
			return insideUnitCircle.normalized * (1f - Mathf.Pow(1f - magnitude, p));
		}

		public Vector2 InsideRing(float warp)
		{
			Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
			float num = insideRadius * insideRadius;
			float num2 = (Mathf.Sqrt(UnityEngine.Random.value * (1f - num) + num) - insideRadius) / (1f - insideRadius);
			float num3 = (1f + Mathf.Pow(num2, 1f / warp) - Mathf.Pow(1f - num2, 1f / warp)) / 2f * (1f - insideRadius) + insideRadius;
			return normalized * num3;
		}

		public IEnumerator UpdateBiomassCount()
		{
			while (true)
			{
				yield return wait;
				RecountBiomass();
			}
		}

		public void ResetList()
		{
			foreach (MatterPellet zonePellet in zonePellets)
			{
				zonePellet.onPelletGone.RemoveListener(RemovePelletFromList);
			}
			zonePellets.Clear();
			foreach (Transform item in pelletHolder)
			{
				MatterPellet component = item.GetComponent<MatterPellet>();
				zonePellets.Add(component);
				component.onPelletGone.AddListener(RemovePelletFromList);
			}
			RecountBiomass();
		}

		public void RecountBiomass()
		{
			pelletBiomass = zonePellets.Sum((MatterPellet p) => p.energy);
		}

		public void RecyclePellets(float amount)
		{
			if (float.IsNaN(amount))
			{
				Debug.Log("something wrong");
			}
			foreach (Transform item in pelletHolder)
			{
				if (amount <= 0f)
				{
					break;
				}
				MatterPellet component = item.gameObject.GetComponent<MatterPellet>();
				float num = component.RemoveEnergy(Mathf.Min(amount, component.energy + 1f));
				pelletBiomass -= num;
				amount -= num;
			}
		}

		public void InitialSeeding()
		{
			float num = ScenarioSettings.Instance.initialSeeding.val * maxBiomass;
			while (pelletBiomass < num)
			{
				SpawnAPellet();
			}
		}

		public void ToggleVisibility(bool view)
		{
			sr.enabled = view;
		}

		private void OnSimulationSizeChange()
		{
			UpdateSize();
			UpdateSpeed();
		}

		private void UpdateSize()
		{
			if (settings.isRect)
			{
				rect.width = settings.absoluteWidth / 2f;
				rect.height = settings.absoluteHeight / 2f;
				if (settings.target.val != null)
				{
					base.transform.localScale = rect.size / 1f / base.transform.parent.lossyScale;
				}
				else
				{
					base.transform.localScale = rect.size / 1f;
				}
			}
			else
			{
				radius = settings.absoluteRadius;
				if (settings.target.val != null)
				{
					base.transform.localScale = Vector3.one * radius / 1f / base.transform.parent.lossyScale.x;
				}
				else
				{
					base.transform.localScale = Vector3.one * radius / 1f;
				}
				maxD = simulationSize - radius;
			}
			UpdateProduction();
			UpdatePosition();
		}

		private void UpdateProduction()
		{
			maxBiomass = settings.maxBiomass;
			pelletProduction = settings.totalGrowth;
			UpdateMaterial();
		}

		private void UpdateAvgPelletEnergy()
		{
			avgPelletEnergy = ScenarioSettings.Instance.pelletEnergy.val * settings.sizeFactor;
		}

		private void UpdateInsideRadius()
		{
			insideRadius = settings.insideRadius.val;
		}

		private void UpdatePosition()
		{
			float b;
			float b2;
			if (settings.isRect)
			{
				b = simulationSize - rect.width;
				b2 = simulationSize - rect.height;
			}
			else
			{
				b = (b2 = simulationSize - radius);
			}
			float val = settings.posX.val;
			float val2 = settings.posY.val;
			val = Mathf.Min(Mathf.Abs(val), b) * Mathf.Sign(val);
			val2 = Mathf.Min(Mathf.Abs(val2), b2) * Mathf.Sign(val2);
			base.transform.position = simulationSize * new Vector2(val, val2);
		}

		public void UpdateTarget(ZoneSettings target)
		{
			if (target == null)
			{
				base.transform.SetParent(ZoneManager.instance.transform);
				return;
			}
			Zone zone = ZoneManager.instance.zones.FirstOrDefault((Zone z) => z.settings == target);
			if (zone == null || zone == this)
			{
				base.transform.SetParent(ZoneManager.instance.transform);
			}
			else
			{
				base.transform.SetParent(zone.transform);
			}
		}

		private void UpdateSpeed()
		{
			speed = simulationSize * ScenarioSettings.Instance.globalZoneSpeed.val * settings.speed.val / 3600f;
		}

		public void LogData()
		{
			zoneData.Push(new ZoneDataPoint(this));
		}

		private void OnDestroy()
		{
			if (pelletHolder != null)
			{
				UnityEngine.Object.DestroyImmediate(pelletHolder.gameObject);
			}
			UnityEngine.Object.Destroy(mat);
			AvgPelletEnergy.UnSubscribe(UpdateAvgPelletEnergy);
			SimulationSize.UnSubscribe(OnSimulationSizeChange);
			ScenarioSettings.Instance.globalZoneSpeed.UnSubscribe(UpdateSpeed);
			ScenarioIndependentSettings.Instance.biomassDensity.UnSubscribe(UpdateBiomass);
			ScenarioIndependentSettings.Instance.pelletGrowth.UnSubscribe(UpdateFertility);
			UserSettings.ShowFertility.UnSubscribe(ToggleVisibility);
			settings.spawnMaterial.UnSubscribe(UpdateSpawnMaterial);
			settings.spawnMaterial.UnSubscribe(UpdateBiomass);
			settings.distribution.UnSubscribe(UpdateBiomass);
			settings.insideRadius.UnSubscribe(UpdateBiomass);
			settings.biomassDensity.UnSubscribe(UpdateBiomass);
			settings.spawnMaterial.UnSubscribe(UpdateFertility);
			settings.distribution.UnSubscribe(UpdateFertility);
			settings.fertility.UnSubscribe(UpdateFertility);
			settings.pelletSize.UnSubscribe(UpdateAvgPelletEnergy);
			settings.movement.UnSubscribe(UpdateMovement);
			settings.target.UnSubscribe(UpdateTarget);
			settings.speed.UnSubscribe(UpdateSpeed);
			settings.onSizeChange.RemoveListener(UpdateSize);
			settings.insideRadius.UnSubscribe(UpdateInsideRadius);
			settings.posX.UnSubscribe(UpdatePosition);
			settings.posY.UnSubscribe(UpdatePosition);
		}

		public override string ToString()
		{
			return settings.zoneName.val;
		}
	}
}
