using System;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class CarCollisionAudioModule : CarAudioModule
	{
		private const float OLD_VELOCITY_TO_IMPULSE = 277777.78f;

		private const float TERRAIN_SOFTENING_POW = 2f;

		private static readonly float[] COLLISION_FORCE_THRESHOLDS = new float[9]
		{
			27777.78f,
			555555.56f,
			1388888.9f,
			2777777.8f,
			15101565f / (float)Math.E,
			26179940f / (float)Math.PI,
			11111111f,
			13888889f,
			16666667f
		};

		private static readonly int[] COLLISION_MAX_DISTANCES = new int[9] { 100, 125, 150, 200, 400, 750, 1250, 2000, 3000 };

		private static int TerrainLayer = -1;

		[Header("Expecting 0 or 9 clips")]
		public AudioClip[] impactClips;

		private TrainCar car;

		public override bool ExternalUpdate => false;

		private void Awake()
		{
			if (TerrainLayer == -1)
			{
				TerrainLayer = LayerMask.NameToLayer("Terrain");
			}
			if (impactClips == null || impactClips.Length == 0)
			{
				if (!SingletonBehaviour<AudioManager>.Instance)
				{
					Debug.LogError("Unexpected state: CarCollisionAudioModule doesn't have impactClips assigned and couldn't find an AudioManager instance. Won't function properly", base.gameObject);
				}
				else
				{
					if (SingletonBehaviour<AudioManager>.Instance.collisionClips.Length < 9)
					{
						Debug.LogWarning("AudioManager does not have enough collision clips to play for every different collision level, so some collision levels will have same sound", SingletonBehaviour<AudioManager>.Instance.gameObject);
					}
					impactClips = SingletonBehaviour<AudioManager>.Instance.collisionClips;
				}
			}
			if (impactClips != null && impactClips.Length != 9)
			{
				impactClips = null;
				Debug.LogError("Unexpected state: impactClips number different than 9", base.gameObject);
			}
		}

		public override void Initialize(TrainCar trainCar)
		{
			if (impactClips != null)
			{
				car = trainCar;
				car.CollisionInfoDispenser.CollisionEnterInfo += OnCollidedEnter;
			}
		}

		public override void Deinitialize()
		{
			if (impactClips != null)
			{
				car.CollisionInfoDispenser.CollisionEnterInfo -= OnCollidedEnter;
				car = null;
			}
		}

		private void OnCollidedEnter(Collision collision, bool becausePause)
		{
			if (becausePause || (bool)collision.transform.GetComponentInParent<ItemBase>())
			{
				return;
			}
			float num = collision.impulse.magnitude / Time.fixedDeltaTime;
			float num2 = COLLISION_FORCE_THRESHOLDS[COLLISION_FORCE_THRESHOLDS.Length - 1];
			if (num < num2 && base.gameObject.layer == TerrainLayer)
			{
				num /= num2;
				num = Mathf.Pow(num, 2f);
				num *= num2;
			}
			AudioClip audioClip = null;
			int num3 = 0;
			for (int num4 = COLLISION_FORCE_THRESHOLDS.Length - 1; num4 >= 0; num4--)
			{
				if (num > COLLISION_FORCE_THRESHOLDS[num4])
				{
					audioClip = impactClips[num4];
					num3 = COLLISION_MAX_DISTANCES[num4];
					break;
				}
			}
			if (!(audioClip == null))
			{
				audioClip.Play(collision.GetContact(0).point, num * SingletonBehaviour<AudioManager>.Instance.collisionVolumePerSpeed, UnityEngine.Random.Range(0.8f, 1.2f), 90f, 1f, num3, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.collisionGroup);
			}
		}
	}
}
