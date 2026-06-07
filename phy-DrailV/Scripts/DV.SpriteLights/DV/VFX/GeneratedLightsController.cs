using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DV.Utils;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace DV.VFX
{
	public class GeneratedLightsController : MonoBehaviour
	{
		[Serializable]
		public struct LightPair
		{
			public SpriteLight spriteLight;

			public Light realLight;

			[NonSerialized]
			public int index;

			public LightPair(SpriteLight spriteLight, Light realLight)
			{
				this.spriteLight = spriteLight;
				this.realLight = realLight;
				index = 0;
			}
		}

		public const float INTENSITY_TO_DENSITY_SCALE = 0.01f;

		public const float INTENSITY_GLOBAL_MULTIPLIER = 2f;

		private float range = 100f;

		private int updatesPerFrame = 256;

		[SerializeField]
		private bool followDayNightCycle = true;

		[SerializeField]
		private bool manualState = true;

		public LightPair[] lightPairs;

		private float[] baseIntensity;

		private List<LightPair>[] pairsPerType;

		private bool[] lightState;

		private SpriteLightsEvent spriteLights;

		private int updatesCount;

		private bool initialized;

		private int roundRobin;

		private bool finishedRoundRobin = true;

		private NativeArray<float4> dataNativeArray;

		private NativeArray<float> resultNativeArray;

		private LightsLODJob job;

		private JobHandle jobHandle;

		private WorldTimeBasedEventsProvider provider;

		private NativeArray<SpriteLight.SpriteLightData> localData;

		public NativeArray<SpriteLight.SpriteLightData> LocalData => localData;

		public int RealtimeEntryCount { get; private set; }

		public int Count => lightPairs.Length;

		public bool IsDirty { get; internal set; }

		private void Awake()
		{
			if (lightPairs != null)
			{
				Initialize();
			}
		}

		public void Initialize()
		{
			updatesCount = Mathf.Min(updatesPerFrame, lightPairs.Length);
			if (Application.isPlaying)
			{
				StartCoroutine(DelayedInitialize());
			}
		}

		private void GenerateLightData()
		{
			Vector3 worldShift = (provider ? provider.CurrentMove : Vector3.zero);
			int num = 0;
			if (localData.Length != lightPairs.Length)
			{
				localData = new NativeArray<SpriteLight.SpriteLightData>(lightPairs.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			}
			SpriteLight.SpriteLightData data = default(SpriteLight.SpriteLightData);
			lightState = new bool[lightPairs.Length];
			for (int i = 0; i < lightPairs.Length; i++)
			{
				if (lightPairs[i].spriteLight.RealtimeEffectsEntry)
				{
					lightState[num] = ShouldBeOn(lightPairs[i].spriteLight);
					lightPairs[i].spriteLight.FillInData(worldShift, ref data, lightState[num] ? 1f : 0f);
					localData[num] = data;
					lightPairs[i].index = num;
					num++;
				}
			}
			RealtimeEntryCount = num;
			IsDirty = true;
		}

		public void UpdateAllLights()
		{
			SpriteLight.SpriteLightData data = default(SpriteLight.SpriteLightData);
			Vector3 worldShift = (provider ? provider.CurrentMove : Vector3.zero);
			for (int i = 0; i < lightPairs.Length; i++)
			{
				if (lightPairs[i].spriteLight.RealtimeEffectsEntry)
				{
					lightPairs[i].spriteLight.FillInData(worldShift, ref data, lightState[lightPairs[i].index] ? 1f : 0f);
					localData[lightPairs[i].index] = data;
				}
			}
			IsDirty = true;
		}

		public void SetRange(float newRange)
		{
			range = newRange;
		}

		private IEnumerator DelayedInitialize()
		{
			while (!SingletonBehaviour<WorldTimeBasedEvents>.Instance)
			{
				yield return null;
			}
			provider = SingletonBehaviour<WorldTimeBasedEvents>.Instance.provider;
			while (!provider.IsWorldMoverReady)
			{
				yield return null;
			}
			while (!provider.IsWorldStreamingInitLoaded)
			{
				yield return null;
			}
			if (followDayNightCycle)
			{
				spriteLights = SingletonBehaviour<WorldTimeBasedEvents>.Instance.GetComponent<SpriteLightsEvent>();
				if (!spriteLights)
				{
					Debug.LogWarning("No SpriteLightsEvent found in WorldTimeBasedEvents, disabling day/night cycle for lights.");
					followDayNightCycle = false;
				}
			}
			yield return null;
			GenerateLightData();
			pairsPerType = new List<LightPair>[Enum.GetValues(typeof(SpriteLightType)).Length];
			for (int i = 0; i < pairsPerType.Length; i++)
			{
				pairsPerType[i] = new List<LightPair>();
			}
			baseIntensity = new float[lightPairs.Length];
			for (int j = 0; j < lightPairs.Length; j++)
			{
				if (lightPairs[j].spriteLight == null)
				{
					Debug.LogError($"Light at index [{j}] in '{base.transform.root.name}' doesn't have a SpriteLight assigned! Skipping over now, but lights should probably be regenerated in this area.", this);
					continue;
				}
				baseIntensity[j] = (lightPairs[j].realLight ? lightPairs[j].realLight.intensity : 0f);
				pairsPerType[(int)lightPairs[j].spriteLight.LightType].Add(lightPairs[j]);
			}
			dataNativeArray = new NativeArray<float4>(lightPairs.Length, Allocator.Persistent);
			resultNativeArray = new NativeArray<float>(lightPairs.Length, Allocator.Persistent);
			job = new LightsLODJob
			{
				dataNativeArray = dataNativeArray,
				resultNativeArray = resultNativeArray
			};
			Vector3 vector = (provider ? provider.CurrentMove : Vector3.zero);
			for (int k = 0; k < lightPairs.Length; k++)
			{
				LightPair lightPair = lightPairs[k];
				if (lightPair.realLight != null)
				{
					dataNativeArray[k] = new float4(lightPair.realLight.transform.position - vector, baseIntensity[k]);
				}
			}
			if (followDayNightCycle)
			{
				if (!spriteLights)
				{
					Debug.LogError("GeneratedLightsController needs a SpriteLightsEvent to be attached to WorldTimeBasedEvents prefab, destroying self.");
					UnityEngine.Object.Destroy(this);
					yield break;
				}
				spriteLights.MaterialUpdated += OnMaterialUpdated;
			}
			else
			{
				SetAllLightsState(manualState);
				for (int l = 0; l < pairsPerType.Length; l++)
				{
					UpdateLightType(l, manualState);
				}
			}
			SingletonBehaviour<SpriteLightsSystem>.Instance.RegisterLightsController(this);
			initialized = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldBeOn(SpriteLight spriteLight)
		{
			if (followDayNightCycle)
			{
				return spriteLights.LightTypeOn[(int)spriteLight.LightType];
			}
			return manualState;
		}

		public void SetAllLightsState(bool on)
		{
			manualState = on;
			if (initialized)
			{
				for (int i = 0; i < pairsPerType.Length; i++)
				{
					UpdateLightType(i, on);
				}
			}
		}

		private void OnMaterialUpdated(SpriteLightsEvent.SpriteLightMaterial material)
		{
			if (followDayNightCycle)
			{
				int lightType = (int)material.lightType;
				UpdateLightType(lightType, material.isOn);
			}
		}

		private void UpdateLightType(int typeID, bool on)
		{
			float num = (on ? 1f : 0f);
			bool flag = false;
			for (int i = 0; i < pairsPerType[typeID].Count; i++)
			{
				lightState[pairsPerType[typeID][i].index] = on;
				if (localData[pairsPerType[typeID][i].index].position.w != num)
				{
					SpriteLight.SpriteLightData value = localData[pairsPerType[typeID][i].index];
					Vector4 position = value.position;
					position.w = num;
					value.position = position;
					localData[pairsPerType[typeID][i].index] = value;
					if ((bool)pairsPerType[typeID][i].realLight)
					{
						pairsPerType[typeID][i].realLight.enabled = on;
					}
					flag = true;
				}
				if (!on && (bool)pairsPerType[typeID][i].realLight)
				{
					pairsPerType[typeID][i].realLight.enabled = false;
				}
			}
			if (flag)
			{
				IsDirty = true;
			}
		}

		private void OnDestroy()
		{
			if (localData.IsCreated)
			{
				localData.Dispose();
			}
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<SpriteLightsSystem>.Instance.UnregisterLightsController(this);
			}
			if (dataNativeArray.IsCreated)
			{
				dataNativeArray.Dispose();
			}
			if (resultNativeArray.IsCreated)
			{
				resultNativeArray.Dispose();
			}
			if ((bool)spriteLights)
			{
				spriteLights.MaterialUpdated -= OnMaterialUpdated;
			}
		}

		private void Update()
		{
			if (finishedRoundRobin && initialized && lightPairs.Length != 0 && (!followDayNightCycle || !(spriteLights == null)) && (followDayNightCycle || manualState))
			{
				Camera main = Camera.main;
				if (((bool)provider || !followDayNightCycle) && (bool)main)
				{
					Vector3 vector = (provider ? provider.CurrentMove : Vector3.zero);
					Vector3 position = main.transform.position;
					job.cameraPos = position - vector;
					job.range = range;
					jobHandle = job.Schedule(lightPairs.Length, 64);
					finishedRoundRobin = false;
				}
			}
		}

		private void LateUpdate()
		{
			if (!initialized || (!followDayNightCycle && !manualState))
			{
				return;
			}
			jobHandle.Complete();
			for (int i = 0; i < updatesCount; i++)
			{
				LightPair lightPair = lightPairs[roundRobin];
				float num = resultNativeArray[roundRobin];
				Light realLight = lightPair.realLight;
				if ((bool)realLight)
				{
					if ((bool)spriteLights && !lightState[lightPairs[roundRobin].index])
					{
						realLight.enabled = false;
					}
					else
					{
						bool flag = (realLight.enabled = lightState[lightPairs[roundRobin].index] && num > 0.0001f);
						if (flag && realLight.intensity != num)
						{
							realLight.intensity = num;
						}
					}
				}
				if (++roundRobin >= lightPairs.Length)
				{
					finishedRoundRobin = true;
					roundRobin -= lightPairs.Length;
				}
			}
		}
	}
}
