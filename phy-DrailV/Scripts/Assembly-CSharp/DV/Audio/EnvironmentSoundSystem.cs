using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DV.DopplerEffects;
using DV.TerrainSystem;
using DV.Utils;
using DV.WeatherSystem;
using DV.WorldTools;
using UnityEngine;
using UnityEngine.Audio;

namespace DV.Audio
{
	public class EnvironmentSoundSystem : SingletonBehaviour<EnvironmentSoundSystem>, ISerializationCallbackReceiver
	{
		[Serializable]
		private struct SoundsPerBiome
		{
			[HideInInspector]
			public string name;

			public EnvironmentSoundDescriptor[] sounds;
		}

		public struct DetailPlayback
		{
			public AudioSource source;

			public EnvironmentSoundDescriptor sound;

			public int remainingRepeats;

			public float wait;

			private float spatialBlend;

			private float volumeMultiplier;

			private AudioMixerGroup fallbackMixer;

			public bool IsBusy
			{
				get
				{
					if (!(wait > 0f) && !source.isPlaying)
					{
						return remainingRepeats > 0;
					}
					return true;
				}
			}

			public void Update(float deltaTime)
			{
				if (IsBusy && !source.isPlaying)
				{
					wait -= deltaTime;
					if (wait <= 0f && remainingRepeats > 0)
					{
						sound.Play(source, spatialBlend, fallbackMixer, forceMixerGroup: false, volumeMultiplier);
						wait = UnityEngine.Random.Range(sound.repeatGap.x, sound.repeatGap.y);
						remainingRepeats--;
					}
				}
			}

			public AudioClip Play(EnvironmentSoundDescriptor sound, Vector3 position, float spatialBlend = 1f, AudioMixerGroup fallbackMixer = null, float volumeMultiplier = 1f)
			{
				this.sound = sound;
				this.spatialBlend = spatialBlend;
				this.fallbackMixer = fallbackMixer;
				this.volumeMultiplier = volumeMultiplier;
				remainingRepeats = UnityEngine.Random.Range(sound.repeats.x - 1, sound.repeats.y);
				wait = UnityEngine.Random.Range(sound.repeatGap.x, sound.repeatGap.y);
				source.transform.position = position;
				return sound.Play(source, spatialBlend, fallbackMixer, forceMixerGroup: false, volumeMultiplier);
			}
		}

		private struct BiomeVolume
		{
			public int index;

			public float volume;
		}

		private const float DAYLIGHT_START_A = 1f / 6f;

		private const float DAYLIGHT_START_B = 5f / 24f;

		private const float DAYLIGHT_END_A = 5f / 6f;

		private const float DAYLIGHT_END_B = 0.75f;

		internal const float BIOME_SPATIAL_DISTANCE_MIN = 8f;

		internal const float BIOME_SPATIAL_DISTANCE_MAX = 20f;

		internal const float DETAIL_SPATIAL_DISTANCE_MIN = 2f;

		internal const float DETAIL_SPATIAL_DISTANCE_MAX = 5f;

		private const float HIGH_ALTITUDE_BIOME_ATTENUATION = 1.5f;

		private const float RELATIVE_ALTITUDE_FACTOR_SCALE = 0.25f;

		private const float TIME_TRANSITION_SCALING = 0.025f;

		private const float TRANSITION_CAMERA_SPEED_MIN = 0f;

		private const float TRANSITION_CAMERA_SPEED_MAX = 10f;

		private const float TRANSITION_MULTIPLIER_MIN = 0.001f;

		private const float TRANSITION_MULTIPLIER_MAX = 0.5f;

		private const float SPATIAL_BLENDING_TRANSITION_BOOST = 2f;

		private const float TUNNEL_DISTANCE = 40f;

		private const float TUNNEL_DIRECTIONALITY_MULTIPLIER = 3f;

		[Header("Biome sound index")]
		[SerializeField]
		private SoundsPerBiome[] biomeSounds;

		[SerializeField]
		private int maxActiveBiomes = 3;

		[SerializeField]
		[Header("Detail sound parameters")]
		private int detailSources = 8;

		[SerializeField]
		private AudioMixerGroup defaultDetailMixer;

		[SerializeField]
		private Vector2 detailDistance = new Vector2(5f, 50f);

		[SerializeField]
		[Header("High altitude")]
		private AudioSource highAltitudeSource;

		[SerializeField]
		private float highAltitudeVolumeMax = 1f;

		[SerializeField]
		private Vector2 relativeHighAltitudeRange = new Vector2(10f, 150f);

		[SerializeField]
		private Vector2 absoluteHighAltitudeRange = new Vector2(300f, 1000f);

		[SerializeField]
		[Header("Tunnel")]
		private AudioSource tunnelSource;

		[SerializeField]
		private float tunnelVolumeMax = 1f;

		[Header("Debug")]
		public bool enableLogging;

		public bool showStats;

		private const string BIOME_AMBIENT_OBJECT = "BiomeAmbient";

		private const string BIOME_DETAILS_OBJECT = "BiomeDetails";

		private static readonly Biome[] Biomes = (Biome[])Enum.GetValues(typeof(Biome));

		private Transform ambiancesRoot;

		private Transform[] ambianceBiomeRoots;

		private AudioSource[][] ambianceLoops;

		private bool[] singleLoopBiome;

		private float[][] ambianceCurrentVolumes;

		private float[][] ambianceCurrentBlends;

		private Vector3[] ambianceCurrentPosition;

		private float[][] ambianceTargetVolumes;

		private float[][] ambianceTargetBlends;

		private Vector3[] ambianceTargetPosition;

		private Transform detailsRoot;

		private DetailPlayback[] details;

		private int detailRobin;

		private Dictionary<EnvironmentSoundDescriptor, int> soundIndices = new Dictionary<EnvironmentSoundDescriptor, int>();

		private List<float> cooldowns = new List<float>();

		private List<EnvironmentSoundZone> zones = new List<EnvironmentSoundZone>();

		private List<float> zoneDeltaTime = new List<float>();

		private int zoneRobin;

		private Vector3 lastCameraPos = Vector3.zero;

		private bool moverRegistered;

		private bool weatherRegistered;

		private bool snapToTargetValues;

		private float tunnelFactor;

		private float tunnelDirectionality;

		private Vector3 tunnelHolePosition = Vector3.zero;

		private Vector3 tunnelHoleDelta = Vector3.zero;

		private Vector3 tunnelOutsideDirection = Vector3.forward;

		private float[] intraBiomeBlends = new float[4];

		private int[] intraBiomeIndices = new int[4];

		private BiomeVolume[] biomeVolumes = new BiomeVolume[Enum.GetValues(typeof(Biome)).Length];

		private StringBuilder sb = new StringBuilder();

		private static Comparison<BiomeVolume> compareVolume => (BiomeVolume a, BiomeVolume b) => b.volume.CompareTo(a.volume);

		private Comparison<int> compareIntraBiomeIndices => (int a, int b) => intraBiomeBlends[b].CompareTo(intraBiomeBlends[a]);

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Initialize()
		{
			base.Initialize();
			ambiancesRoot = base.transform.Find("BiomeAmbient");
			if (!ambiancesRoot)
			{
				Debug.LogError("There's no expected 'BiomeAmbient' object under '" + base.gameObject.name + "', so no biome sounds can be found, env sounds will be broken.", this);
			}
			if (ambiancesRoot.childCount != Biomes.Length)
			{
				Debug.LogError($"Expected to find {Biomes.Length} child objects under '{ambiancesRoot.name}', but got {ambiancesRoot.childCount}, env sounds will probably be broken", ambiancesRoot);
			}
			ambianceLoops = new AudioSource[ambiancesRoot.childCount][];
			ambianceBiomeRoots = new Transform[ambiancesRoot.childCount];
			singleLoopBiome = new bool[ambiancesRoot.childCount];
			ambianceCurrentPosition = new Vector3[ambiancesRoot.childCount];
			ambianceTargetPosition = new Vector3[ambiancesRoot.childCount];
			ambianceCurrentVolumes = new float[ambiancesRoot.childCount][];
			ambianceCurrentBlends = new float[ambiancesRoot.childCount][];
			ambianceTargetVolumes = new float[ambiancesRoot.childCount][];
			ambianceTargetBlends = new float[ambiancesRoot.childCount][];
			for (int i = 0; i < ambianceLoops.Length; i++)
			{
				ambianceBiomeRoots[i] = ambiancesRoot.GetChild(i);
				ambianceLoops[i] = ambianceBiomeRoots[i].GetComponentsInChildren<AudioSource>();
				singleLoopBiome[i] = ambianceLoops[i].Length == 1;
				ambianceCurrentVolumes[i] = new float[ambianceLoops[i].Length];
				ambianceCurrentBlends[i] = new float[ambianceLoops[i].Length];
				ambianceTargetVolumes[i] = new float[ambianceLoops[i].Length];
				ambianceTargetBlends[i] = new float[ambianceLoops[i].Length];
				if (ambianceLoops[i].Length != 1 && ambianceLoops[i].Length != 4)
				{
					Debug.LogError($"Expected either 1 or 4 child AudioSource objects under '{ambianceBiomeRoots[i]}' but found {ambianceLoops[i]}, this will probably break sounds for {Biomes[i]}", ambianceBiomeRoots[i]);
				}
			}
			detailsRoot = base.transform.Find("BiomeDetails");
			if (!ambiancesRoot)
			{
				Debug.LogError("There's no expected 'BiomeDetails' object under '" + base.gameObject.name + "', so no biome detail sources can be found, biome details sounds will be broken.", this);
			}
			details = new DetailPlayback[detailSources];
			InitializeSources(detailsRoot, details);
			for (int j = 0; j < biomeSounds.Length; j++)
			{
				for (int k = 0; k < biomeSounds[j].sounds.Length; k++)
				{
					if (!soundIndices.ContainsKey(biomeSounds[j].sounds[k]))
					{
						soundIndices.Add(biomeSounds[j].sounds[k], cooldowns.Count);
						cooldowns.Add(UnityEngine.Random.Range(0f, biomeSounds[j].sounds[k].cooldown.y));
					}
				}
			}
			StartCoroutine(WaitForWorldMover());
			StartCoroutine(WaitForWeather());
		}

		private IEnumerator WaitForWorldMover()
		{
			while (!SingletonBehaviour<WorldMover>.Instance)
			{
				yield return null;
			}
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
			moverRegistered = true;
		}

		private IEnumerator WaitForWeather()
		{
			while (!SingletonBehaviour<WeatherDriver>.Instance || !SingletonBehaviour<WeatherDriver>.Instance.manager)
			{
				yield return null;
			}
			SingletonBehaviour<WeatherDriver>.Instance.manager.TimeJump += OnTimeJump;
			weatherRegistered = true;
		}

		private void OnWorldMoved(WorldMover mover, Vector3 shift)
		{
			lastCameraPos -= shift;
		}

		private void OnTimeJump()
		{
			snapToTargetValues = true;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (moverRegistered)
			{
				moverRegistered = false;
				if ((bool)SingletonBehaviour<WorldMover>.Instance)
				{
					SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
				}
			}
			if (weatherRegistered)
			{
				weatherRegistered = false;
				if ((bool)SingletonBehaviour<WeatherDriver>.Instance && (bool)SingletonBehaviour<WeatherDriver>.Instance.manager)
				{
					SingletonBehaviour<WeatherDriver>.Instance.manager.TimeJump -= OnTimeJump;
				}
			}
		}

		public static void InitializeSources(Transform root, DetailPlayback[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = new GameObject("Source_" + i);
				gameObject.transform.SetParent(root, worldPositionStays: false);
				array[i].source = gameObject.AddComponent<AudioSource>();
				array[i].source.playOnAwake = false;
				array[i].source.loop = false;
				array[i].source.dopplerLevel = 0f;
				gameObject.AddComponent<Doppler>().useSpatialBlend = true;
			}
		}

		public void Register(EnvironmentSoundZone zone)
		{
			zones.Add(zone);
			zoneDeltaTime.Add(0f);
		}

		public void Unregister(EnvironmentSoundZone zone)
		{
			int num = zones.IndexOf(zone);
			if (num >= 0)
			{
				zones.RemoveAt(num);
				zoneDeltaTime.RemoveAt(num);
			}
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			for (int i = 0; i < cooldowns.Count; i++)
			{
				if (cooldowns[i] > 0f)
				{
					cooldowns[i] -= deltaTime;
				}
			}
			for (int j = 0; j < details.Length; j++)
			{
				details[j].Update(deltaTime);
			}
			if (PlayerManager.ActiveCamera != null)
			{
				for (int k = 0; k < details.Length; k++)
				{
					if (!details[detailRobin].IsBusy)
					{
						break;
					}
					detailRobin = (detailRobin + 1) % details.Length;
				}
				if (!details[detailRobin].IsBusy)
				{
					Vector3 position = PlayerManager.ActiveCamera.transform.position;
					Vector3 vector = position;
					float f = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
					float num = UnityEngine.Random.Range(detailDistance.x, detailDistance.y);
					vector.x += Mathf.Cos(f) * num;
					vector.z += Mathf.Sin(f) * num;
					float relativeAltitudeFactor = GetRelativeAltitudeFactor(position);
					float volumeMultiplier = Mathf.Clamp01(1f - relativeAltitudeFactor * 1.5f);
					float pointSample = HeightMapProvider.GetPointSample(vector);
					vector.y = Mathf.Clamp(pointSample, position.y - 50f, position.y + 50f);
					bool flag = true;
					if (tunnelFactor > 0f)
					{
						flag = tunnelFactor < 1f && Vector3.Dot((vector - tunnelHolePosition).normalized, tunnelOutsideDirection) > tunnelFactor;
					}
					if (flag)
					{
						Biome pointSample2 = SingletonBehaviour<BiomeProvider>.Instance.GetPointSample(vector);
						EnvironmentSoundDescriptor[] sounds = biomeSounds[(uint)pointSample2].sounds;
						if (sounds.Length != 0)
						{
							WeatherDriver instance = SingletonBehaviour<WeatherDriver>.Instance;
							WeatherPresetManager manager = instance.manager;
							int hour = manager.DateTime.Hour;
							int minute = manager.DateTime.Minute;
							float sunlight = Mathf.Clamp01(instance.GlobalSunIntensityFactor);
							float rain = instance.RainValue;
							float wetness = instance.WetnessValue;
							float thunder = instance.ThunderValue;
							int num2 = UnityEngine.Random.Range(0, sounds.Length);
							for (int l = 0; l < sounds.Length; l++)
							{
								int num3 = (l + num2) % sounds.Length;
								EnvironmentSoundDescriptor environmentSoundDescriptor = sounds[num3];
								int index = soundIndices[environmentSoundDescriptor];
								if (!(cooldowns[index] > 0f) && !(UnityEngine.Random.value > environmentSoundDescriptor.chanceWeight) && environmentSoundDescriptor.Check(hour, minute, num, pointSample, vector.y, position.y, sunlight, rain, wetness, thunder))
								{
									Vector3 vector2 = vector;
									float a = 0f;
									if (environmentSoundDescriptor.is3D)
									{
										a = Mathf.Clamp01(Mathf.InverseLerp(2f, 5f, num));
										vector2.y = pointSample + UnityEngine.Random.Range(environmentSoundDescriptor.relativeAltitudeRange.x, environmentSoundDescriptor.relativeAltitudeRange.y);
									}
									a = Mathf.Lerp(a, 1f, tunnelDirectionality);
									Vector3 vector3 = tunnelHoleDelta.normalized * Mathf.Max(tunnelHoleDelta.magnitude, (vector2 - position).magnitude);
									vector2 = Vector3.Lerp(vector2, position + vector3, tunnelDirectionality);
									AudioClip audioClip = details[detailRobin].Play(environmentSoundDescriptor, vector2, a, defaultDetailMixer, volumeMultiplier);
									cooldowns[index] = UnityEngine.Random.Range(environmentSoundDescriptor.cooldown.x, environmentSoundDescriptor.cooldown.y);
									if (enableLogging && (bool)audioClip)
									{
										Debug.Log(string.Concat("ENV PLAY [", environmentSoundDescriptor.name, " / ", audioClip.name, "] @ ", pointSample2, " ", vector2));
									}
									break;
								}
							}
						}
					}
				}
			}
			if (zones.Count > 0)
			{
				float deltaTime2 = Time.deltaTime;
				for (int m = 0; m < zoneDeltaTime.Count; m++)
				{
					zoneDeltaTime[m] += deltaTime2;
				}
				if (zoneRobin >= zones.Count)
				{
					zoneRobin = 0;
				}
				if (zones[zoneRobin].enabled)
				{
					zones[zoneRobin].Tick(zoneDeltaTime[zoneRobin]);
				}
				zoneDeltaTime[zoneRobin] = 0f;
				zoneRobin++;
			}
		}

		private float GetRelativeAltitudeFactor(Vector3 position)
		{
			float num = Mathf.Max(LevelInfo.WaterLevel, HeightMapProvider.GetPointSample(position));
			return Mathf.Max(0f, MathUtils.InverseLerpUnclamped(relativeHighAltitudeRange.x, relativeHighAltitudeRange.y, position.y - num));
		}

		private void LateUpdate()
		{
			if (!(PlayerManager.ActiveCamera != null))
			{
				return;
			}
			Vector3 position = PlayerManager.ActiveCamera.transform.position;
			ambiancesRoot.transform.position = position;
			BiomeProvider instance = SingletonBehaviour<BiomeProvider>.Instance;
			float value = Vector3.Distance(position, lastCameraPos);
			lastCameraPos = position;
			tunnelFactor = 0f;
			tunnelDirectionality = 0f;
			tunnelHolePosition = position;
			tunnelHoleDelta = Vector3.zero;
			tunnelOutsideDirection = Vector3.forward;
			if ((bool)SingletonBehaviour<TerrainHoleManager>.Instance && (bool)SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility)
			{
				TerrainHole closestHoleIgnoringVisibility = SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility;
				tunnelHolePosition = closestHoleIgnoringVisibility.transform.position;
				float value2 = 0f;
				if (ZoneDetector.GetValue(ZoneDetector.ZoneType.Tunnel, out value2))
				{
					tunnelHoleDelta = tunnelHolePosition - position;
					tunnelFactor = value2 * Mathf.InverseLerp(0f, 40f, tunnelHoleDelta.magnitude);
					tunnelDirectionality = Mathf.Clamp01(tunnelFactor * 3f);
					tunnelOutsideDirection = closestHoleIgnoringVisibility.transform.forward;
				}
			}
			float relativeAltitudeFactor = GetRelativeAltitudeFactor(position);
			for (int i = 0; i < instance.BiomeVolume.Length; i++)
			{
				biomeVolumes[i].index = i;
				biomeVolumes[i].volume = instance.BiomeVolume[i] * Mathf.Clamp01(1f - relativeAltitudeFactor * 1.5f);
			}
			QuickSort.Sort(biomeVolumes, compareVolume);
			float num = ((SingletonBehaviour<WeatherDriver>.Instance.manager.timeOfDay < 0.5f) ? Mathf.Clamp01(Mathf.InverseLerp(1f / 6f, 5f / 24f, SingletonBehaviour<WeatherDriver>.Instance.manager.timeOfDay)) : Mathf.Clamp01(Mathf.InverseLerp(5f / 6f, 0.75f, SingletonBehaviour<WeatherDriver>.Instance.manager.timeOfDay)));
			float num2 = Mathf.Clamp01(Mathf.InverseLerp(0.1f, 0.3f, SingletonBehaviour<WeatherDriver>.Instance.RainValue));
			intraBiomeBlends[0] = num * (1f - num2);
			intraBiomeBlends[1] = num * num2;
			intraBiomeBlends[2] = (1f - num) * (1f - num2);
			intraBiomeBlends[3] = (1f - num) * num2;
			for (int j = 0; j < intraBiomeBlends.Length; j++)
			{
				intraBiomeIndices[j] = j;
			}
			QuickSort.Sort(intraBiomeIndices, compareIntraBiomeIndices);
			for (int k = 2; k < intraBiomeBlends.Length; k++)
			{
				intraBiomeBlends[intraBiomeIndices[k]] = 0f;
			}
			for (int l = 0; l < ambianceLoops.Length; l++)
			{
				int index = biomeVolumes[l].index;
				float volume = biomeVolumes[l].volume;
				for (int m = 0; m < (singleLoopBiome[index] ? 1 : intraBiomeBlends.Length); m++)
				{
					float num3 = Mathf.Clamp01(volume * (singleLoopBiome[index] ? 1f : intraBiomeBlends[m]));
					if (l < maxActiveBiomes && num3 > 0f)
					{
						ambianceTargetVolumes[index][m] = num3 * (1f - tunnelFactor);
						Vector3 vector = instance.BiomeDirection[index];
						vector.y = 0f;
						float magnitude = vector.magnitude;
						float num4 = Mathf.Clamp01(Mathf.InverseLerp(8f, 20f, magnitude));
						ambianceTargetBlends[index][m] = num4;
					}
					else
					{
						ambianceTargetVolumes[index][m] = 0f;
					}
				}
				Vector3 vector2 = instance.BiomeDirection[index];
				float a = Mathf.Min(0f, LevelInfo.WaterLevel - position.y);
				vector2.y = Mathf.Max(a, vector2.y);
				ambianceTargetPosition[index] = vector2;
			}
			if ((bool)highAltitudeSource)
			{
				float b = Mathf.Clamp01(Mathf.InverseLerp(absoluteHighAltitudeRange.x, absoluteHighAltitudeRange.y, position.y));
				float num5 = Mathf.Clamp01(Mathf.Max(relativeAltitudeFactor * 0.25f, b)) * highAltitudeVolumeMax;
				if (num5 > 0f)
				{
					if (!highAltitudeSource.enabled)
					{
						highAltitudeSource.time = UnityEngine.Random.Range(0f, highAltitudeSource.clip.length);
						highAltitudeSource.enabled = true;
					}
					highAltitudeSource.volume = num5;
				}
				else
				{
					highAltitudeSource.enabled = false;
				}
			}
			if ((bool)tunnelSource)
			{
				float num6 = tunnelFactor * tunnelVolumeMax;
				if (num6 > 0f)
				{
					if (!tunnelSource.enabled)
					{
						tunnelSource.time = UnityEngine.Random.Range(0f, tunnelSource.clip.length);
						tunnelSource.enabled = true;
					}
					tunnelSource.volume = num6;
				}
				else
				{
					tunnelSource.enabled = false;
				}
			}
			if (snapToTargetValues)
			{
				snapToTargetValues = false;
				for (int n = 0; n < ambianceLoops.Length; n++)
				{
					for (int num7 = 0; num7 < (singleLoopBiome[n] ? 1 : intraBiomeBlends.Length); num7++)
					{
						ambianceCurrentVolumes[n][num7] = ambianceTargetVolumes[n][num7];
						ambianceCurrentBlends[n][num7] = ambianceTargetBlends[n][num7];
					}
					ambianceCurrentPosition[n] = ambianceTargetPosition[n];
				}
			}
			else
			{
				float num8 = Time.deltaTime * 0.025f;
				float num9 = Mathf.InverseLerp(0f, 10f, value);
				float num10 = Mathf.Lerp(0.001f, 0.5f, num8 + num9);
				for (int num11 = 0; num11 < ambianceLoops.Length; num11++)
				{
					for (int num12 = 0; num12 < (singleLoopBiome[num11] ? 1 : intraBiomeBlends.Length); num12++)
					{
						if (ambianceCurrentVolumes[num11][num12] < ambianceTargetVolumes[num11][num12])
						{
							ambianceCurrentVolumes[num11][num12] = Mathf.Min(ambianceCurrentVolumes[num11][num12] + num10, ambianceTargetVolumes[num11][num12]);
						}
						else if (ambianceCurrentVolumes[num11][num12] > ambianceTargetVolumes[num11][num12])
						{
							ambianceCurrentVolumes[num11][num12] = Mathf.Max(ambianceCurrentVolumes[num11][num12] - num10, ambianceTargetVolumes[num11][num12]);
						}
						if (ambianceCurrentBlends[num11][num12] < ambianceTargetBlends[num11][num12])
						{
							ambianceCurrentBlends[num11][num12] = Mathf.Min(ambianceCurrentBlends[num11][num12] + num10 * 2f, ambianceTargetBlends[num11][num12]);
						}
						else if (ambianceCurrentBlends[num11][num12] > ambianceTargetBlends[num11][num12])
						{
							ambianceCurrentBlends[num11][num12] = Mathf.Max(ambianceCurrentBlends[num11][num12] - num10 * 2f, ambianceTargetBlends[num11][num12]);
						}
					}
					if (num10 >= 0.5f || ambianceCurrentPosition[num11] == Vector3.zero)
					{
						ambianceCurrentPosition[num11] = ambianceTargetPosition[num11];
					}
					else
					{
						ambianceCurrentPosition[num11] = Vector3.Lerp(ambianceCurrentPosition[num11], ambianceTargetPosition[num11], num10 * Time.deltaTime);
					}
				}
			}
			for (int num13 = 0; num13 < ambianceLoops.Length; num13++)
			{
				if (num13 == 7)
				{
					Vector3 zero = Vector3.zero;
					zero.y = LevelInfo.WaterLevel - position.y;
					ambianceBiomeRoots[num13].transform.localPosition = Vector3.Lerp(zero, tunnelHoleDelta, tunnelDirectionality);
				}
				else
				{
					ambianceBiomeRoots[num13].transform.localPosition = Vector3.Lerp(ambianceCurrentPosition[num13], tunnelHoleDelta, tunnelDirectionality);
				}
				for (int num14 = 0; num14 < (singleLoopBiome[num13] ? 1 : intraBiomeBlends.Length); num14++)
				{
					if (ambianceCurrentVolumes[num13][num14] > 0f)
					{
						if (!ambianceLoops[num13][num14].enabled)
						{
							ambianceLoops[num13][num14].enabled = true;
							if (!ambianceLoops[num13][num14].gameObject.activeInHierarchy)
							{
								Debug.LogWarning("[EnvironmentSoundSystem] AudioSource is not active in hierarchy and it should play: " + ambianceLoops[num13][num14].gameObject.GetPath(), ambianceLoops[num13][num14]);
							}
							ambianceLoops[num13][num14].Play();
							ambianceLoops[num13][num14].time = UnityEngine.Random.Range(0f, ambianceLoops[num13][num14].clip.length);
						}
						ambianceLoops[num13][num14].volume = ambianceCurrentVolumes[num13][num14];
						if (num13 == 7)
						{
							ambianceLoops[num13][num14].spatialBlend = 1f;
						}
						else
						{
							ambianceLoops[num13][num14].spatialBlend = Mathf.Lerp(ambianceCurrentBlends[num13][num14], 1f, tunnelDirectionality);
						}
					}
					else if (ambianceLoops[num13][num14].enabled)
					{
						ambianceLoops[num13][num14].enabled = false;
					}
				}
			}
		}

		private void CheckArray()
		{
			if (biomeSounds == null)
			{
				biomeSounds = new SoundsPerBiome[Biomes.Length];
			}
			if (biomeSounds.Length != Biomes.Length)
			{
				Array.Resize(ref biomeSounds, Biomes.Length);
			}
			for (int i = 0; i < Biomes.Length; i++)
			{
				biomeSounds[i].name = Biomes[i].ToString();
			}
		}

		public void OnBeforeSerialize()
		{
			CheckArray();
		}

		public void OnAfterDeserialize()
		{
			CheckArray();
		}

		private void OnGUI()
		{
			if (!showStats)
			{
				return;
			}
			sb.Clear();
			int num = 0;
			for (int i = 0; i < ambianceLoops.Length; i++)
			{
				for (int j = 0; j < ambianceLoops[i].Length; j++)
				{
					if (ambianceLoops[i][j].enabled && ambianceLoops[i][j].isPlaying)
					{
						num++;
					}
				}
			}
			int num2 = 0;
			for (int k = 0; k < details.Length; k++)
			{
				if (details[k].source.enabled && details[k].source.isPlaying)
				{
					num2++;
				}
			}
			int num3 = 0;
			int num4 = 0;
			for (int l = 0; l < zones.Count; l++)
			{
				num3 += zones[l].CountPlayingSources();
				if (zones[l].InRange)
				{
					num4++;
				}
			}
			sb.AppendLine($"Active biome audio sources: {num + num2} ({num} biomes + {num2} details)");
			sb.AppendLine($"Active zone audio sources: {num3} (from {zones.Count} loaded zones, {num4} in range)");
			sb.AppendLine("Tunnel factor: " + tunnelFactor.ToString("0.00"));
			sb.AppendLine();
			sb.AppendLine("Day + Dry: " + intraBiomeBlends[0].ToString("0.00"));
			sb.AppendLine("Day + Wet: " + intraBiomeBlends[1].ToString("0.00"));
			sb.AppendLine("Night + Dry: " + intraBiomeBlends[2].ToString("0.00"));
			sb.AppendLine("Night + Wet: " + intraBiomeBlends[3].ToString("0.00"));
			sb.AppendLine();
			for (int m = 0; m < biomeVolumes.Length; m++)
			{
				if (biomeVolumes[m].volume > 0f)
				{
					sb.AppendLine(string.Format("{0}: {1}", Biomes[biomeVolumes[m].index], biomeVolumes[m].volume.ToString("0.00")));
				}
			}
			GUI.Label(new Rect(10f, 10f, 500f, 500f), sb.ToString());
		}
	}
}
