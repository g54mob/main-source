using System.Collections;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Manager;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval
{
	public class Shaker : MonoBehaviour
	{
		[SerializeField]
		private GameObject whatToShake;

		[SerializeField]
		private bool translationShake = true;

		[SerializeField]
		private bool rotationShake = true;

		[SerializeField]
		private string additionalParticles;

		[SerializeField]
		private string deadParticles;

		[SerializeField]
		private Transform addParticlesPosition;

		[SerializeField]
		private PlantMapResourceView pmri;

		[SerializeField]
		private Transform prefab;

		public bool startShake;

		private float shakeSpeed = 40f;

		private float shakeAmount = 0.02f;

		private float shakeDuration = 0.3f;

		private Vector3 startLocation;

		private Vector3 startLocationLocal;

		private Vector3 startRotation;

		private Vector3 particleEmiterSize = Vector3.zero;

		private float xSign;

		private float ySign;

		private float beginTime;

		private float? previousHealth;

		private float rotMult = 1f;

		private float transMult = 1f;

		private float camDistance;

		private float damage;

		private float maxHp;

		private float currentHp;

		private Transform transformToShake;

		private GameObject addParticle;

		private float phase;

		private ParticleSystemRenderer[] psr;

		private BirdsScare birds;

		private IEnumerator shakeCoroutineRunning;

		public void Initialize()
		{
			transformToShake = ((whatToShake != null) ? whatToShake.transform : base.transform);
			startLocation = transformToShake.position;
			startLocationLocal = transformToShake.localPosition;
			if (TryGetComponent<BoxCollider>(out var component))
			{
				particleEmiterSize = component.size;
			}
			if (TryGetComponent<BirdsScare>(out var component2))
			{
				birds = component2;
			}
		}

		public void Shake(StatInstance instance, BaseBuildingInstance bo)
		{
			if (bo == null || instance == null)
			{
				return;
			}
			maxHp = instance.Max;
			currentHp = instance.Current;
			if (!CheckIfLosingHealth())
			{
				bool num = startShake;
				TriggerParticles(bo.GetPosition(), bo.Size);
				if (!num)
				{
					SetParameters(100f, 1f, 40f, 0.02f, 0.6f, calculateDamage: true);
					shakeCoroutineRunning = DoShake(instance);
					StartCoroutine(shakeCoroutineRunning);
				}
			}
		}

		public void Stop()
		{
			if (shakeCoroutineRunning != null)
			{
				StopCoroutine(shakeCoroutineRunning);
				shakeCoroutineRunning = null;
			}
			if (startShake)
			{
				ResetShake();
			}
		}

		public void Shake(Transform tsfm)
		{
			if (!(tsfm == null))
			{
				SetParameters(100f, 1f, 40f, 0.005f, 0.3f, calculateDamage: false);
				bool num = startShake;
				startShake = true;
				beginTime = Time.time;
				if (!num)
				{
					shakeCoroutineRunning = DoShake(transformToShake);
					StartCoroutine(shakeCoroutineRunning);
				}
			}
		}

		public void Shake(StatsInstance instance, PlantMapResourceView pl)
		{
			if (pl == null || instance == null)
			{
				return;
			}
			maxHp = instance.GetStat(StatType.Health).Max;
			currentHp = instance.GetStat(StatType.Health).Current;
			if (!CheckIfLosingHealth())
			{
				SetParameters(100f, 1f, 40f, 0.02f, 0.6f, calculateDamage: true);
				bool num = startShake;
				TriggerParticles(pl.ResourceInstance.GetPosition(), pl.ResourceInstance.Size);
				previousHealth = instance.GetStat(StatType.Health).Current;
				if (!num)
				{
					shakeCoroutineRunning = DoShake(instance);
					StartCoroutine(shakeCoroutineRunning);
				}
			}
		}

		public void Shake(MapResourceInstance mri)
		{
			SetParameters(25f, 1f, 40f, 0.02f, 0.3f, calculateDamage: false);
			bool num = startShake;
			TriggerParticles(mri.GetPosition(), mri.Size);
			if (!num)
			{
				shakeCoroutineRunning = DoShake(mri);
				StartCoroutine(shakeCoroutineRunning);
			}
		}

		private bool CheckIfLosingHealth()
		{
			if (!previousHealth.HasValue)
			{
				previousHealth = maxHp;
			}
			if (previousHealth < currentHp)
			{
				previousHealth = currentHp;
			}
			if (!(previousHealth > currentHp))
			{
				return true;
			}
			return false;
		}

		private void SetParameters(float rotationMultiplier, float translationMultiplier, float shakeSpeed, float shakeAmount, float shakeDuration, bool calculateDamage)
		{
			rotMult = rotationMultiplier;
			transMult = translationMultiplier;
			this.shakeSpeed = shakeSpeed;
			this.shakeAmount = ShakeAmountFromCameraDistance() * shakeAmount;
			this.shakeDuration = shakeDuration;
			if (calculateDamage && previousHealth.HasValue)
			{
				damage = ((previousHealth - currentHp) / maxHp).Value;
				this.shakeDuration *= damage;
			}
		}

		private float ShakeAmountFromCameraDistance()
		{
			return (MonoSingleton<CameraManager>.Instance.GameplayCamera.transform.position - base.transform.position).magnitude / 90f + 8f / 9f;
		}

		private void TriggerParticles(Vector3 pos, Vec3Int val)
		{
			startShake = true;
			beginTime = Time.time;
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.EnvironmentParticles)
			{
				return;
			}
			GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("building_hit", pos);
			if (additionalParticles != string.Empty && pmri != null && addParticlesPosition != null)
			{
				if (pmri.ResourceInstance.CurrentPhase < 4)
				{
					addParticle = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(additionalParticles, addParticlesPosition);
				}
				else if (deadParticles != string.Empty)
				{
					addParticle = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(deadParticles, addParticlesPosition);
				}
			}
			if (gameObject == null)
			{
				return;
			}
			Collider[] componentsInChildren = base.transform.GetComponentsInChildren<Collider>();
			foreach (Collider coll in componentsInChildren)
			{
				MonoSingleton<ParticleSystemPool>.Instance.SetEmitterSize("building_hit", gameObject, coll, 0.8f);
			}
			if (!(addParticle == null) && !(pmri == null) && !(addParticlesPosition == null))
			{
				psr = addParticle.GetComponentsInChildren<ParticleSystemRenderer>();
				Vector3 localScale = addParticlesPosition.localScale;
				Vector3 localScale2 = pmri.GetComponentInParent<Transform>().localScale;
				Vector3 scale = new Vector3(localScale.x * localScale2.x, localScale.y * localScale2.y, localScale.z * localScale2.z);
				ParticleSystem[] componentsInChildren2 = addParticle.GetComponentsInChildren<ParticleSystem>();
				foreach (ParticleSystem obj in componentsInChildren2)
				{
					ParticleSystem.ShapeModule shape = obj.shape;
					ParticleSystem.MainModule main = obj.main;
					shape.scale = scale;
					shape.position = Vector3.zero;
					float min = localScale2.x * main.startSize.constantMin;
					float max = localScale2.x * main.startSize.constantMax;
					main.startSize = new ParticleSystem.MinMaxCurve(min, max);
				}
			}
		}

		private IEnumerator DoShake(object ob)
		{
			if (transformToShake == null)
			{
				ResetShake();
				yield break;
			}
			startRotation = transformToShake.eulerAngles;
			while (startShake)
			{
				if (this == null || ob == null)
				{
					shakeCoroutineRunning = null;
					break;
				}
				if (MonoSingleton<GameSpeedManager>.Instance.CurrentSpeedIndex == GameSpeedIndex.Pause)
				{
					ResetShake();
					shakeCoroutineRunning = null;
					break;
				}
				if (translationShake)
				{
					Vector3 vector = new Vector3(CalculateRandomPoint("x") * transMult, 0f, CalculateRandomPoint("z") * transMult);
					if (transformToShake != null)
					{
						transformToShake.localPosition += vector;
					}
				}
				if (rotationShake)
				{
					Vector3 euler = new Vector3(CalculateRandomPoint("x") * rotMult, startRotation.y, CalculateRandomPoint("z") * rotMult);
					if ((bool)transformToShake)
					{
						transformToShake.rotation = Quaternion.Euler(euler);
					}
				}
				if (!(Time.time - beginTime >= shakeDuration))
				{
					yield return new WaitForEndOfFrame();
					continue;
				}
				ResetShake();
				shakeCoroutineRunning = null;
				break;
			}
		}

		private void ResetShake()
		{
			startShake = false;
			if (!(transformToShake == null))
			{
				transformToShake.position = startLocation;
				transformToShake.localPosition = startLocationLocal;
				transformToShake.rotation = Quaternion.Euler(startRotation);
			}
		}

		private float CalculateRandomPoint(string coordinate)
		{
			float num = (Time.time - beginTime) * shakeAmount / shakeDuration;
			float f = Time.time * shakeSpeed;
			if (xSign == 0f)
			{
				xSign = RandomSign();
			}
			if (ySign == 0f)
			{
				ySign = RandomSign();
			}
			float num2 = ((!(coordinate == "x")) ? (ySign * Mathf.Cos(f)) : (xSign * Mathf.Sin(f)));
			return num2 * (shakeAmount - num) * Random.Range(0.8f, 1.2f);
		}

		private static float RandomSign()
		{
			if (Random.Range(0f, 1f) < 0.5f)
			{
				return -1f;
			}
			return 1f;
		}

		private void Start()
		{
			Initialize();
		}
	}
}
