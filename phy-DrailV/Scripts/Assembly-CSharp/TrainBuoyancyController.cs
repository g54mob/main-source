using System;
using DV.Utils;
using UnityEngine;

public class TrainBuoyancyController : MonoBehaviour
{
	private const float TRAIN_BUOYANCY_MULT = 390f;

	private const float CORNERS_TIMES_TWO = 16f;

	private const float SPLASH_PARTICLE_SPEED_TOGGLE = 7f;

	private const string SPLASH_PARTICLE_HEAVY = "WaterSplashVehicleHeavy";

	private const string SPLASH_PARTICLE_LIGHT = "WaterSplashVehicleLight";

	public Rigidbody rb;

	public TrainCar trainCar;

	public float underwaterDrag = 0.14f;

	public float buoyancy = 1f;

	public float waterFill;

	public float secondsToFillUp = 3f;

	private Vector3[] localPoints;

	private float waterHeight;

	private float volume;

	private bool previouslyUnderwater;

	private bool prevEndA;

	private bool prevEndB;

	public event Action OnEnterWater;

	public event Action OnExitWater;

	private void Awake()
	{
		waterHeight = LevelInfo.WaterLevel;
		if (!rb)
		{
			rb = GetComponent<Rigidbody>();
		}
		if (!trainCar)
		{
			trainCar = GetComponent<TrainCar>();
		}
		ResetCorners();
	}

	public void ResetCorners()
	{
		localPoints = new Vector3[8];
		Vector3 min = trainCar.Bounds.min;
		Vector3 max = trainCar.Bounds.max;
		localPoints[0] = new Vector3(min.x, min.y, min.z);
		localPoints[1] = new Vector3(max.x, min.y, min.z);
		localPoints[2] = new Vector3(min.x, max.y, min.z);
		localPoints[3] = new Vector3(max.x, max.y, min.z);
		localPoints[4] = new Vector3(min.x, min.y, max.z);
		localPoints[5] = new Vector3(max.x, max.y, max.z);
		localPoints[6] = new Vector3(min.x, max.y, max.z);
		localPoints[7] = new Vector3(max.x, min.y, max.z);
		volume = trainCar.Bounds.size.x * trainCar.Bounds.size.y * trainCar.Bounds.size.z;
	}

	private void OnDisable()
	{
		waterFill = 0f;
	}

	private void FixedUpdate()
	{
		if (trainCar.isEligibleForSleep)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < localPoints.Length; i++)
		{
			Vector3 position = localPoints[i];
			Vector3 vector = base.transform.TransformPoint(position);
			if (vector.y < waterHeight)
			{
				flag = true;
				if (i < 4)
				{
					flag2 = true;
				}
				else
				{
					flag3 = true;
				}
				Vector3 pointVelocity = rb.GetPointVelocity(vector);
				float num = waterHeight - vector.y;
				rb.AddForceAtPosition(Vector3.up * num * buoyancy * (1f - waterFill) * 390f * volume, vector, ForceMode.Force);
				rb.AddForceAtPosition(-pointVelocity / 16f * underwaterDrag, vector, ForceMode.VelocityChange);
			}
		}
		float magnitude = trainCar.GetVelocity().magnitude;
		if (flag2 && !prevEndA)
		{
			Vector3 min = trainCar.Bounds.min;
			Vector3 max = trainCar.Bounds.max;
			if (flag3 && Mathf.Abs(Vector3.Dot(Vector3.up, base.transform.forward)) < 0.4f)
			{
				SpawnLineSplash(magnitude, base.transform.TransformPoint(new Vector3(0f, (max.y - min.y) * 0.5f, min.z + 0.4f)), base.transform.TransformPoint(new Vector3(0f, (max.y - min.y) * 0.5f, max.z - 0.4f)));
			}
			else
			{
				SpawnSplash(magnitude, base.transform.TransformPoint(new Vector3(0f, (max.y - min.y) * 0.5f, min.z + 0.4f)));
			}
		}
		else if (flag3 && !prevEndB)
		{
			Vector3 min2 = trainCar.Bounds.min;
			Vector3 max2 = trainCar.Bounds.max;
			if (flag2 && Mathf.Abs(Vector3.Dot(Vector3.up, base.transform.forward)) < 0.4f)
			{
				SpawnLineSplash(magnitude, base.transform.TransformPoint(new Vector3(0f, (max2.y - min2.y) * 0.5f, min2.z + 0.4f)), base.transform.TransformPoint(new Vector3(0f, (max2.y - min2.y) * 0.5f, max2.z - 0.4f)));
			}
			else
			{
				SpawnSplash(magnitude, base.transform.TransformPoint(new Vector3(0f, (max2.y - min2.y) * 0.5f, max2.z - 0.4f)));
			}
		}
		if (flag)
		{
			waterFill += Time.fixedDeltaTime / secondsToFillUp;
			waterFill = Mathf.Clamp01(waterFill);
			if (!previouslyUnderwater)
			{
				previouslyUnderwater = true;
				this.OnEnterWater?.Invoke();
			}
		}
		else
		{
			waterFill -= Time.fixedDeltaTime / secondsToFillUp;
			waterFill = Mathf.Clamp01(waterFill);
			if (previouslyUnderwater)
			{
				previouslyUnderwater = false;
				this.OnExitWater?.Invoke();
			}
		}
		prevEndA = flag2;
		prevEndB = flag3;
	}

	private void SpawnLineSplash(float speed, Vector3 from, Vector3 to)
	{
		int num = (int)(Vector3.Distance(from, to) * 0.3f + 1f);
		for (int i = 0; i < num; i++)
		{
			float t = (float)i / (float)(num - 1);
			SpawnSplash(speed, Vector3.Lerp(from, to, t), playsound: false);
		}
		PlaySplash(speed, Vector3.Lerp(from, to, 0.5f));
	}

	private void SpawnSplash(float speed, Vector3 position, bool playsound = true)
	{
		if (playsound)
		{
			PlaySplash(speed, position);
		}
		if ((bool)SingletonBehaviour<ParticlePool>.Instance)
		{
			GameObject gameObject = SingletonBehaviour<ParticlePool>.Instance?.SpawnParticleOnWater((speed > 7f) ? "WaterSplashVehicleHeavy" : "WaterSplashVehicleLight", position);
			if ((bool)gameObject)
			{
				gameObject.transform.localScale = Vector3.one * Mathf.Clamp(speed * 0.05f, 0.8f, 4f);
			}
		}
	}

	private void PlaySplash(float speed, Vector3 position)
	{
		((speed > 7f) ? SingletonBehaviour<AudioManager>.Instance.waterSplashHeavyClip : SingletonBehaviour<AudioManager>.Instance.waterSplashLightClip).Play(position, 1f, UnityEngine.Random.Range(0.89f, 1.1f));
	}
}
