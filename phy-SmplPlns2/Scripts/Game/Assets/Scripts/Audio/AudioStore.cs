using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public static class AudioStore
	{
		public static readonly AudioMixer AudioMixer = Resources.Load<AudioMixer>("Sound/DefaultAudioMixer");

		public static readonly AudioMixerGroup Master = AudioMixer.FindMatchingGroups("Master")[0];

		public static readonly AudioMixerGroup Environments = AudioMixer.FindMatchingGroups("Master/Environments")[0];

		public static readonly AudioMixerGroup Weapons = AudioMixer.FindMatchingGroups("Master/Parts/Weapons")[0];

		public static readonly AudioMixerGroup Explosions = AudioMixer.FindMatchingGroups("Master/Explosions")[0];

		public static readonly AudioMixerGroup Parts = AudioMixer.FindMatchingGroups("Master/Parts")[0];

		public static readonly AudioMixerGroup Internals = AudioMixer.FindMatchingGroups("Master/Internals")[0];

		public static readonly AudioMixerGroup Rumble = AudioMixer.FindMatchingGroups("Master/Rumble")[0];

		public static readonly AudioFile BladeEngineAudio = new AudioFile
		{
			Id = "BladeEngineAudio",
			DefaultVolume = 0.5f,
			MinDistance = 20f,
			MaxDistance = 500f,
			Doppler = 0.5f,
			Spread = 90f,
			MixerGroup = Parts,
			Resource = (Resources.Load("Sound/Propulsion/EngineProp") as AudioClip)
		};

		public static readonly AudioFile HangarDoorAudio = new AudioFile
		{
			Id = "HangarDoorAudio",
			DefaultVolume = 0.3f,
			MinDistance = 20f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 30f,
			MixerGroup = Environments
		};

		public static readonly AudioFile HeliBladesAudio = new AudioFile
		{
			Id = "HeliBladesAudio",
			DefaultVolume = 0f,
			MinDistance = 100f,
			MaxDistance = 3000f,
			Doppler = 0.5f,
			Spread = 120f,
			MixerGroup = Parts,
			Resource = (Resources.Load("Sound/Propulsion/HeliBladesNoEngine") as AudioClip)
		};

		public static readonly AudioFile HeliMainAudio = new AudioFile
		{
			Id = "HeliMainAudio",
			DefaultVolume = 0f,
			MinDistance = 100f,
			MaxDistance = 3000f,
			Doppler = 0.5f,
			Spread = 120f,
			MixerGroup = Parts,
			Resource = (Resources.Load("Sound/Propulsion/HeliCyclic") as AudioClip)
		};

		public static readonly AudioFile CarHornHonk = new AudioFile
		{
			Id = "CarHornHonk",
			DefaultVolume = 0.8f,
			MinDistance = 2f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			MixerGroup = Environments,
			Resource = (Resources.Load("Sound/CarHornHonk") as AudioClip)
		};

		public static readonly AudioFile KnobAudio = new AudioFile
		{
			Id = "KnobAudio",
			DefaultVolume = 0.5f,
			MinDistance = 0.5f,
			MaxDistance = 10f,
			Doppler = 0.5f,
			Spread = 0f,
			MixerGroup = Internals
		};

		public static readonly AudioFile ParachuteAudio = new AudioFile
		{
			Id = "ParachuteAudio",
			DefaultVolume = 1f,
			MinDistance = 10f,
			MaxDistance = 200f,
			Doppler = 0.5f,
			Resource = (Resources.Load("Sound/Parachute") as AudioClip),
			MixerGroup = Parts
		};

		public static readonly AudioFile RattleAudio = new AudioFile
		{
			Id = "RattleAudio",
			DefaultVolume = 1f,
			Resource = (Resources.Load("Sound/GroundRoll") as AudioClip),
			MixerGroup = Internals
		};

		public static readonly AudioFile WindAudio = new AudioFile
		{
			Id = "WindAudio",
			DefaultVolume = 1f,
			MinDistance = 10f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 120f,
			Resource = (Resources.Load("Sound/Environments/WindNew") as AudioClip),
			MixerGroup = Rumble
		};

		public static readonly AudioClip Boxer = Resources.Load("Sound/Propulsion/EngineCarBoxer") as AudioClip;

		public static readonly AudioClip Cyl6 = Resources.Load("Sound/Propulsion/EngineCar6") as AudioClip;

		public static readonly AudioClip Cyl8 = Resources.Load("Sound/Propulsion/EngineCar8") as AudioClip;

		public static readonly AudioClip Cyl10 = Resources.Load("Sound/Propulsion/EngineCar10") as AudioClip;

		public static readonly AudioClip Cyl12 = Resources.Load("Sound/Propulsion/EngineCar12") as AudioClip;

		public static readonly string SkidAudio = "Sound/Wheels/tireSkid";

		public static readonly string SkidDust = "Sound/Wheels/SandWheelNoise";

		public static readonly string SkidGravel = "Sound/Wheels/GravelSkidNoise";

		public static readonly string SkidSolid = "Sound/Wheels/AsphaltSkidNoise";

		public static readonly string RollDust = "Sound/Wheels/SandWheelNoise";

		public static readonly string RollGravel = "Sound/Wheels/GravelWheelNoise";

		public static readonly string RollSolid = "Sound/Wheels/AsphaltWheelNoise";

		public static readonly AudioFile BulletHitPartAudio = new AudioFile
		{
			Id = "BulletHitPartAudio",
			DefaultVolume = 0.5f,
			MinDistance = 10f,
			MaxDistance = 50f,
			Doppler = 0.5f,
			Spread = 90f,
			Resource = (Resources.Load("Sound/Collisions/BulletPartImpact") as AudioClip),
			MixerGroup = Rumble
		};

		public static readonly AudioFile FireLoopAudio = new AudioFile
		{
			Id = "FireLoopAudio",
			DefaultVolume = 1f,
			MinDistance = 5f,
			MaxDistance = 50f,
			Doppler = 0.5f,
			Spread = 90f,
			Resource = (Resources.Load("Sound/FireLoop") as AudioClip),
			MixerGroup = Explosions
		};

		public static readonly AudioFile GlassShatterAudio = new AudioFile
		{
			Id = "GlassShatterAudio",
			DefaultVolume = 1f,
			MinDistance = 5f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 90f,
			Resource = (Resources.Load("Sound/Collisions/GlassShatter") as AudioClip),
			MixerGroup = Parts
		};

		public static readonly AudioFile PartBreakOffAudio = new AudioFile
		{
			Id = "PartBreakOffAudio",
			DefaultVolume = 1f,
			MinDistance = 10f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 45f,
			Resource = (Resources.Load("Sound/Collisions/PartBreakOff") as AudioClip),
			MixerGroup = Rumble
		};

		public static readonly AudioFile PartBreakOffAlternate = new AudioFile
		{
			Id = "PartBreakOffAlternate",
			DefaultVolume = 1f,
			MinDistance = 10f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 45f,
			Resource = (Resources.Load("Sound/Collisions/PartBreakOffAlternate") as AudioClip),
			MixerGroup = Rumble
		};

		public static readonly AudioFile ThudAudio = new AudioFile
		{
			Id = "ThudAudio",
			DefaultVolume = 1f,
			MinDistance = 10f,
			MaxDistance = 100f,
			Doppler = 0.5f,
			Spread = 45f,
			Resource = (Resources.Load("Sound/Collisions/thud") as AudioClip),
			MixerGroup = Rumble
		};

		public static readonly AudioFile ExplosionAudio = new AudioFile
		{
			Id = "ExplosionAudio",
			DefaultVolume = 5f,
			Resource = (Resources.Load("Sound/explosion") as AudioClip),
			MixerGroup = Explosions
		};

		public static readonly AudioFile GroundRoll = new AudioFile
		{
			Id = "GroundRoll",
			DefaultVolume = 0.5f,
			Resource = Resources.Load<AudioClip>("Sound/GroundRoll"),
			MinDistance = 1f,
			MaxDistance = 25f,
			Doppler = 0.5f,
			MixerGroup = Rumble
		};

		public static readonly AudioFile GroundWheelSounds = new AudioFile
		{
			Id = "GroundWheelSounds",
			DefaultVolume = 0.5f,
			MinDistance = 10f,
			MaxDistance = 200f,
			Doppler = 0.5f,
			Spread = 90f,
			MixerGroup = Rumble
		};

		public static readonly AudioFile ShoreAmbience = new AudioFile
		{
			DefaultVolume = 1f,
			Resource = Resources.Load<AudioClip>("Sound/Environments/WaterShore"),
			MixerGroup = Environments
		};

		public static readonly AudioFile UnderwaterAmbience = new AudioFile
		{
			DefaultVolume = 1f,
			Resource = Resources.Load<AudioClip>("Sound/Environments/WaterDeep"),
			MixerGroup = Environments
		};

		public static readonly AudioFile WaterAmbience = new AudioFile
		{
			Id = "WaterAmbience",
			DefaultVolume = 1f,
			Resource = Resources.Load<AudioClip>("Sound/Environments/WaterSound"),
			MixerGroup = Environments
		};

		public static void SetupAudioSource(AudioSource source, AudioFile reference, AudioClip clip = null, bool loop = true, bool autoPlay = false, float spacial = 1f)
		{
			source.outputAudioMixerGroup = reference.MixerGroup;
			source.clip = clip;
			source.volume = reference.DefaultVolume;
			source.playOnAwake = autoPlay;
			source.loop = loop;
			source.spatialBlend = spacial;
			if (spacial > 0f)
			{
				source.spread = reference.Spread;
				source.dopplerLevel = reference.Doppler;
				source.minDistance = reference.MinDistance;
				source.maxDistance = reference.MaxDistance;
				source.rolloffMode = AudioRolloffMode.Custom;
				Keyframe keyframe = new Keyframe(0f, 1f, -1f, -1f);
				keyframe.weightedMode = WeightedMode.None;
				Keyframe keyframe2 = keyframe;
				keyframe = new Keyframe(1f, 0f, 0f, 0f);
				keyframe.weightedMode = WeightedMode.None;
				Keyframe keyframe3 = keyframe;
				source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, new AnimationCurve(keyframe2, keyframe3));
			}
		}
	}
}
