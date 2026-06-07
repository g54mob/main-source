using System;
using DV.Utils;
using Unity.Profiling;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class CarRollingAudioModule : CarAudioModule
	{
		private static ProfilerMarker PROFILE_MARKER = new ProfilerMarker("CarRollingAudioModule");

		public const float AUDIO_LOD_CHECK_PERIOD = 1f;

		public const float WHEEL_AUDIO_ON_SPEED_THRESHOLD = 0.1f;

		private const int USUAL_BOGIE_COUNT = 2;

		[Header("optional - prefab reference")]
		public LayeredAudio rollingAudioDetailedOverride;

		public LayeredAudio rollingAudioSimpleOverride;

		public LayeredAudio squealAudioDetailedOverride;

		public LayeredAudio squealAudioSimpleOverride;

		[NonSerialized]
		public TrainCar car;

		private AudioLOD currentLOD = AudioLOD.NONE;

		private BogieAudioController[] bogieAudioControllers;

		private int[][] lastJointStep;

		private AudioManager am;

		private bool isAddedToManager;

		public override bool ExternalUpdate => currentLOD != AudioLOD.NONE;

		private void Awake()
		{
			am = SingletonBehaviour<AudioManager>.Instance;
			if (!am)
			{
				Debug.LogError("Unexpected state: AudioManager instance is missing! CarRollingAudioModule won't function properly, destroying self!");
				UnityEngine.Object.Destroy(this);
				return;
			}
			bogieAudioControllers = new BogieAudioController[2];
			if ((bool)am.rollingAudioDetailed && (bool)am.rollingAudioSimple && (bool)am.squealAudioDetailed && (bool)am.squealAudioSimple)
			{
				for (int i = 0; i < 2; i++)
				{
					LayeredAudio rollingAudioDetailed = AudioManager.InstantiateLayeredAudio((rollingAudioDetailedOverride != null) ? rollingAudioDetailedOverride : am.rollingAudioDetailed, base.transform, randomizeTime: true, am.rollingRandomPitchMin, am.rollingRandomPitchMax);
					LayeredAudio rollingAudioSimple = AudioManager.InstantiateLayeredAudio((rollingAudioSimpleOverride != null) ? rollingAudioSimpleOverride : am.rollingAudioSimple, base.transform, randomizeTime: true, am.rollingRandomPitchMin, am.rollingRandomPitchMax);
					LayeredAudio squealAudioDetailed = AudioManager.InstantiateLayeredAudio((squealAudioDetailedOverride != null) ? squealAudioDetailedOverride : am.squealAudioDetailed, base.transform, randomizeTime: true, am.squealRandomPitchMin, am.squealRandomPitchMax);
					LayeredAudio squealAudioSimple = AudioManager.InstantiateLayeredAudio((squealAudioSimpleOverride != null) ? squealAudioSimpleOverride : am.squealAudioSimple, base.transform, randomizeTime: true, am.squealRandomPitchMin, am.squealRandomPitchMax);
					bogieAudioControllers[i] = new BogieAudioController(rollingAudioDetailed, rollingAudioSimple, squealAudioDetailed, squealAudioSimple);
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Rolling related references on AudioManager missing! CarRollingAudioModule won't function properly!");
			}
		}

		public override void Initialize(TrainCar trainCar)
		{
			car = trainCar;
			PlayerManager.CarChanged += OnCarChanged;
			car.OnDerailed += OnCarDerailed;
			car.OnRerailed += OnCarRerailed;
			ResetJointSoundValues();
			Bogie[] bogies = car.Bogies;
			for (int i = 0; i < bogies.Length; i++)
			{
				bogieAudioControllers[i].SetAudioLocalPosition(bogies[i].transform.localPosition);
				bogieAudioControllers[i].ResetAudio();
				bogies[i].TrackChanged += ResetJointSoundForASingleBogie;
			}
			CheckDesiredState();
		}

		public override void Deinitialize()
		{
			SingletonBehaviour<CarAudioManager>.Instance.carRollingAudioModules.Remove(this);
			isAddedToManager = false;
			PlayerManager.CarChanged -= OnCarChanged;
			car.OnDerailed -= OnCarDerailed;
			car.OnRerailed -= OnCarRerailed;
			SetBogiesAudioLOD(AudioLOD.NONE);
			Bogie[] bogies = car.Bogies;
			for (int i = 0; i < bogies.Length; i++)
			{
				bogies[i].TrackChanged -= ResetJointSoundForASingleBogie;
			}
			car = null;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			PlayerManager.CarChanged -= OnCarChanged;
		}

		private void OnCarChanged(TrainCar obj)
		{
			CheckDesiredState();
		}

		private void OnCarRerailed()
		{
			CheckDesiredState();
		}

		private void OnCarDerailed(TrainCar derailedcar)
		{
			CheckDesiredState();
		}

		public override void UpdateModule(float deltaTime)
		{
			float slowBuildUpStress = car.stress.slowBuildUpStress;
			Bogie[] bogies = car.Bogies;
			for (int i = 0; i < bogies.Length; i++)
			{
				Bogie bogie = bogies[i];
				float magnitude = bogie.rb.velocity.magnitude;
				BogieAudioController obj = bogieAudioControllers[i];
				obj.currentRollingAudio.Set(magnitude * am.rollingSpeedMult);
				obj.currentSquealingAudio.Set(slowBuildUpStress);
				if (bogie.track.JointsSpan <= 0f)
				{
					continue;
				}
				for (int j = 0; j < bogie.Axles.Length; j++)
				{
					Bogie.AxleInfo axleInfo = bogie.Axles[j];
					float num = (float)bogie.traveller.Span + bogie.TrackDirectionSign * axleInfo.distanceFromBogiePivot;
					int num2 = Mathf.FloorToInt(num / bogie.track.JointsSpan);
					if (lastJointStep[i][j] != num2 && !((double)(Mathf.Round(num / bogie.track.jointsSpan) * bogie.track.jointsSpan) > bogie.track.GetKinkedPointSet().span))
					{
						PlayJointAtBogie(magnitude, axleInfo.transform.position, bogie.track.isJunctionTrack);
						lastJointStep[i][j] = num2;
					}
				}
			}
		}

		private void CheckDesiredState()
		{
			bool num = car != null;
			bool flag = num && PlayerManager.Car == car;
			bool flag2 = num && !car.derailed && !flag;
			if (flag2 != isAddedToManager)
			{
				if (flag2)
				{
					SingletonBehaviour<CarAudioManager>.Instance.carRollingAudioModules.Add(this);
				}
				else
				{
					SingletonBehaviour<CarAudioManager>.Instance.carRollingAudioModules.Remove(this);
				}
				isAddedToManager = flag2;
			}
			if (!flag2)
			{
				SetBogiesAudioLOD((!flag || car.derailed) ? AudioLOD.NONE : AudioLOD.DETAILED);
			}
		}

		public void SetBogiesAudioLOD(AudioLOD lod)
		{
			if (currentLOD != lod)
			{
				currentLOD = lod;
				BogieAudioController[] array = bogieAudioControllers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetLOD(lod);
				}
			}
		}

		private void PlayJointAtBogie(float speed, Vector3 position, bool isJunctionJoint)
		{
			if (isJunctionJoint && am.junctionJointClips != null)
			{
				float volume = am.junctionSpeedToVolumeCurve.Evaluate(speed);
				am.junctionJointClips.Play(position, volume, 1f, 0f, 1f, 500f, default(AudioSourceCurves), am.railJointGroup, base.transform);
			}
			else if ((bool)am.jointAudio)
			{
				float value = speed * am.jointSpeedMult;
				am.jointAudio.PlayOnce(position, value, base.transform);
			}
		}

		private void ResetJointSoundValues()
		{
			Bogie[] bogies = car.Bogies;
			lastJointStep = new int[bogies.Length][];
			for (int i = 0; i < bogies.Length; i++)
			{
				int num = bogies[i].Axles.Length;
				lastJointStep[i] = new int[num];
				for (int j = 0; j < num; j++)
				{
					lastJointStep[i][j] = -1;
				}
			}
		}

		private void ResetJointSoundForASingleBogie(RailTrack _, Bogie bogie)
		{
			int num = Array.IndexOf(car.Bogies, bogie);
			for (int i = 0; i < lastJointStep[num].Length; i++)
			{
				lastJointStep[num][i] = -1;
			}
		}
	}
}
