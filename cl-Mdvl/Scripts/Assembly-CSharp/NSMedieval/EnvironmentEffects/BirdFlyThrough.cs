using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class BirdFlyThrough : MonoBehaviour
	{
		[SerializeField]
		private float speed = 0.02f;

		[SerializeField]
		[Range(0f, 100f)]
		private int sendBirdsPercent;

		private const float FlockHeight = 50f;

		[NonSerialized]
		private VillageMap mapInstance;

		private bool subscribed;

		[NonSerialized]
		private List<BirdsFlock> liveBirds = new List<BirdsFlock>();

		[ContextMenu("SendBirds")]
		private void SendBirds()
		{
			if (!GlobalSaveController.CurrentVillageData.DateAndTime.IsNightTime && ChanceToSendBirds())
			{
				InstantiateBirds();
			}
		}

		private bool ChanceToSendBirds()
		{
			return UnityEngine.Random.Range(1, 100) <= sendBirdsPercent;
		}

		private void InstantiateBirds()
		{
			string id = GlobalSaveController.CurrentVillageData.DateAndTime.Season.Birds.PickRandom();
			GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(id, base.transform, autoStop: false);
			if (!(gameObject == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.StopParticles(gameObject);
				if (gameObject.TryGetComponent<BirdsFlock>(out var component))
				{
					liveBirds.Add(component);
					GetBirdsPath(component);
				}
			}
		}

		private void GetBirdsPath(BirdsFlock flock)
		{
			int num = GlobalSaveController.CurrentVillageData.DateAndTime.Season.Index;
			if (num == 1 || num == 3)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
			PathStartFinish(flock, num);
			flock.birdsGo.transform.rotation = Quaternion.LookRotation(flock.destination - flock.start, Vector3.up);
			CalculateTimeForFlyover(flock);
		}

		private void PathStartFinish(BirdsFlock flock, int direction)
		{
			Vec3Int size = mapInstance.Size;
			switch (direction)
			{
			case 0:
				flock.start = new Vector3(UnityEngine.Random.Range(0f, size.x), 50f, 0f);
				flock.destination = new Vector3(UnityEngine.Random.Range(0f, size.x), 50f, size.z);
				break;
			case 1:
				flock.start = new Vector3(0f, 50f, UnityEngine.Random.Range(0f, size.z));
				flock.destination = new Vector3(size.x, 50f, UnityEngine.Random.Range(0f, size.z));
				break;
			case 2:
				flock.start = new Vector3(UnityEngine.Random.Range(0f, size.x), 50f, size.z);
				flock.destination = new Vector3(UnityEngine.Random.Range(0f, size.x), 50f, 0f);
				break;
			case 3:
				flock.start = new Vector3(size.x, 50f, UnityEngine.Random.Range(0f, size.z));
				flock.destination = new Vector3(0f, 50f, UnityEngine.Random.Range(0f, size.z));
				break;
			}
		}

		private void CalculateTimeForFlyover(BirdsFlock flock)
		{
			float num = 2f;
			if (flock.birdOfPrey)
			{
				flock.SetupCircling();
				num = 12f * (float)flock.circlesNo;
			}
			flock.timeNeededForFlyOver = Vector3.Distance(flock.destination, flock.start) / speed / 100f + num;
			ParticleSystem[] birdsParticles = flock.birdsParticles;
			foreach (ParticleSystem obj in birdsParticles)
			{
				obj.Stop();
				ParticleSystem.MainModule main = obj.main;
				main.duration = flock.timeNeededForFlyOver;
				main.startLifetime = flock.timeNeededForFlyOver;
				main.loop = false;
				obj.Play();
			}
		}

		private void Update()
		{
			if (liveBirds.Count != 0)
			{
				MoveTheBirds();
			}
		}

		private void MoveTheBirds()
		{
			foreach (BirdsFlock item in liveBirds.IterateInReverseDynamic())
			{
				if (Math.Abs(item.GetCircleFractionPoint - item.fraction) < 0.01f && !item.CirclingStarted && item.birdOfPrey)
				{
					item.StartCircling();
				}
				if (item.CirclingStarted && !item.CirclingFinished)
				{
					float num = Time.deltaTime * -30f;
					item.birdsGo.transform.RotateAround(item.GetCirclingCenter, Vector3.up, num);
					item.Angle += num;
					if (Mathf.Abs(item.Angle) >= Mathf.Abs(360f * (float)item.circlesNo))
					{
						item.FinishCircling();
					}
				}
				else if (item.fraction < 1f)
				{
					item.fraction += Time.deltaTime * speed;
					item.birdsGo.transform.position = Vector3.Lerp(item.start, item.destination, item.fraction);
				}
				else
				{
					item.fraction = 0f;
					item.ResetCircling();
					MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(item.birdsGo);
					liveBirds.Remove(item);
				}
			}
		}

		private void OnMapLoaded(bool wasLoadedFromSave)
		{
			mapInstance = VillageManager.ActiveVillage.Map;
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate += SetupBirds;
			SetupBirds();
		}

		private void OnDestroy()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate -= SetupBirds;
			}
			ReturnLiveBirdsToPool();
			mapInstance = null;
			liveBirds.Clear();
		}

		private void SetupBirds()
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.BirdsEffect)
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= SendBirds;
				ReturnLiveBirdsToPool();
				subscribed = false;
			}
			else if (!subscribed)
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += SendBirds;
				subscribed = true;
			}
		}

		private void ReturnLiveBirdsToPool()
		{
			if (!MonoSingleton<ParticleSystemPool>.IsInstantiated())
			{
				return;
			}
			foreach (BirdsFlock item in liveBirds.IterateInReverseDynamic())
			{
				item.fraction = 0f;
				item.ResetCircling();
				MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(item.birdsGo);
				liveBirds.Remove(item);
			}
		}
	}
}
