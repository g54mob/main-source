using System;
using System.Collections.Generic;
using System.Linq;
using OneUseScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace SimulationScripts.Events
{
	public class RedDeathBloomManager : MonoBehaviour
	{
		public SpriteRenderer bloomSR;

		public ParticleSystem redPheromones;

		private Material mat;

		private Dictionary<BibiteBody, float> bibiteDamages = new Dictionary<BibiteBody, float>();

		private Dictionary<MatterPellet, float> pelletDecays = new Dictionary<MatterPellet, float>();

		private static readonly FloatSetting SimulationSize = ScenarioIndependentSettings.Instance.SimulationSize;

		private static float simulationSize = SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimulationSize);

		private static readonly BoolSetting EnableRedDeath = ScenarioSettings.Instance.enableRedDeath;

		private static bool enableRedDeath = EnableRedDeath.SubscribeTo<BoolSetting, bool>(UpdateEnableRedDeath);

		private static readonly FloatSetting RedDeathFill = ScenarioSettings.Instance.redDeathFill;

		private static float redDeathFill = RedDeathFill.SubscribeTo<FloatSetting, float>(UpdateRedDeathFill);

		private float tRadius;

		public static float safeRadius = float.PositiveInfinity;

		private static readonly FloatSetting RedDeathBaseDamages = ScenarioSettings.Instance.redDeathBaseDamages;

		private static float redDeathBaseDamages = RedDeathBaseDamages.SubscribeTo<FloatSetting, float>(UpdateRedDeathBaseDamages);

		private static readonly FloatSetting RedDeathDamageVelocity = ScenarioSettings.Instance.redDeathDamageVelocity;

		private static float redDeathDamageVelocity = RedDeathDamageVelocity.SubscribeTo<FloatSetting, float>(UpdateRedDeathDamageVelocity);

		private static readonly FloatUserSetting PheromonesStrength = UserSettings.pheromonesStrength;

		private static float pheromonesStrength;

		private int N = 32;

		private const float period = 0.5f;

		[SerializeField]
		public float progress;

		private float pheroProgress;

		private float pheroCountPerSecond;

		private float pheroRingArea;

		private float pheroRingOutsideRadius;

		private float pheroRingInsideRadiusRelative;

		private const float pheromonesDensityPerSecond = 0.0001f;

		private List<OnRedDeathEnterExitTrigger> triggers = new List<OnRedDeathEnterExitTrigger>();

		private static readonly int Fill = Shader.PropertyToID("_Fill");

		private bool hasInit;

		private static void UpdateSimulationSize(float val)
		{
			simulationSize = val;
		}

		private static void UpdateEnableRedDeath(bool val)
		{
			enableRedDeath = val;
			if (!val)
			{
				safeRadius = float.PositiveInfinity;
			}
		}

		private static void UpdateRedDeathFill(float val)
		{
			redDeathFill = Mathf.Clamp01(val);
		}

		private static void UpdateRedDeathBaseDamages(float val)
		{
			redDeathBaseDamages = val;
		}

		private static void UpdateRedDeathDamageVelocity(float val)
		{
			redDeathDamageVelocity = val;
		}

		private void Awake()
		{
			EnableRedDeath.Subscribe(OnEnableChange);
			RedDeathFill.Subscribe(UpdateRadius);
			PheromonesStrength.Subscribe(UpdatePheromoneProduction);
		}

		private void Start()
		{
			if (!enableRedDeath)
			{
				base.gameObject.SetActive(value: false);
				redPheromones.gameObject.SetActive(value: false);
			}
			else if (!hasInit)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			redPheromones.gameObject.SetActive(value: true);
			mat = UnityEngine.Object.Instantiate(bloomSR.material);
			bloomSR.material = mat;
			ParticleSystem.MainModule main = redPheromones.main;
			main.scalingMode = ParticleSystemScalingMode.Shape;
			base.transform.localScale = 2f * BackgroundManager.shadeEnd * Vector3.one;
			float num = MathF.PI * 2f / (float)N;
			for (int i = 0; i < N; i++)
			{
				GameObject obj = new GameObject($"DamageSegment_{i}");
				obj.transform.parent = base.transform;
				obj.layer = 7;
				BoxCollider2D boxCollider2D = obj.AddComponent<BoxCollider2D>();
				boxCollider2D.isTrigger = true;
				boxCollider2D.size = new Vector2(0.5f, 0.2f);
				obj.transform.localScale = Vector3.one;
				OnRedDeathEnterExitTrigger onRedDeathEnterExitTrigger = obj.AddComponent<OnRedDeathEnterExitTrigger>();
				onRedDeathEnterExitTrigger.InitializeTrigger(this, num * (float)i, 0.5f);
				triggers.Add(onRedDeathEnterExitTrigger);
			}
			pheromonesStrength = UserSettings.pheromonesStrength.val;
			hasInit = true;
			UpdateRadius();
		}

		private void OnEnableChange()
		{
			base.gameObject.SetActive(enableRedDeath);
			redPheromones.gameObject.SetActive(enableRedDeath);
			if (enableRedDeath)
			{
				if (!hasInit)
				{
					Initialize();
				}
				else
				{
					UpdateRadius();
				}
			}
		}

		private void UpdateRadius()
		{
			if (!hasInit)
			{
				return;
			}
			tRadius = 1f - Mathf.Sqrt(1f - redDeathFill);
			float shadeEnd = BackgroundManager.shadeEnd;
			safeRadius = shadeEnd * (1f - tRadius);
			float shadeFadeLength = BackgroundManager.shadeFadeLength;
			pheroRingArea = MathF.PI * shadeEnd * shadeEnd * redDeathFill;
			float num = (shadeEnd - (safeRadius - shadeFadeLength / 4f)) / 2f;
			ParticleSystem.ShapeModule shape = redPheromones.shape;
			shape.radius = safeRadius + num;
			shape.donutRadius = num;
			mat.SetFloat(Fill, tRadius);
			foreach (OnRedDeathEnterExitTrigger trigger in triggers)
			{
				trigger.UpdatePosition(tRadius);
			}
			UpdatePheromoneProduction(pheromonesStrength);
		}

		private void UpdatePheromoneProduction(float val)
		{
			if (hasInit)
			{
				pheromonesStrength = val;
				pheroCountPerSecond = 0.0001f * pheroRingArea * pheromonesStrength;
				ParticleSystem.EmissionModule emission = redPheromones.emission;
				emission.rateOverTime = pheroCountPerSecond;
			}
		}

		private void FixedUpdate()
		{
			progress += Time.fixedDeltaTime;
			if (progress < 0.5f)
			{
				return;
			}
			progress -= 0.5f;
			foreach (BibiteBody item in bibiteDamages.Keys.ToList())
			{
				if (item == null)
				{
					bibiteDamages.Remove(item);
					continue;
				}
				bibiteDamages[item] += redDeathDamageVelocity * 0.5f;
				item.Hurting(bibiteDamages[item] * 0.5f);
				if (item.dying)
				{
					bibiteDamages.Remove(item);
				}
			}
			foreach (MatterPellet item2 in pelletDecays.Keys.ToList())
			{
				if (item2 == null)
				{
					pelletDecays.Remove(item2);
					continue;
				}
				pelletDecays[item2] += redDeathDamageVelocity * 0.5f;
				item2.RemoveAmount(pelletDecays[item2] * 0.5f);
				if (item2.amount <= 0f)
				{
					pelletDecays.Remove(item2);
				}
			}
		}

		public void OnBibiteEnter(BibiteBody bibite)
		{
			bibiteDamages.TryAdd(bibite, redDeathBaseDamages);
		}

		public void OnPelletEnter(MatterPellet pellet)
		{
			pelletDecays.TryAdd(pellet, redDeathBaseDamages);
		}

		public void OnBibiteExit(BibiteBody bibite)
		{
			if (bibite.transform.position.magnitude < safeRadius)
			{
				bibiteDamages.Remove(bibite);
			}
		}

		public void OnPelletExit(MatterPellet pellet)
		{
			if (pellet.transform.position.magnitude < safeRadius)
			{
				pelletDecays.Remove(pellet);
			}
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(mat);
			EnableRedDeath.UnSubscribe(OnEnableChange);
			RedDeathFill.UnSubscribe(UpdateRadius);
			PheromonesStrength.UnSubscribe(UpdatePheromoneProduction);
		}
	}
}
