using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.RP;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

[BurstCompile]
public class LightManager : ManagerBase
{
	private struct LightFlickerData
	{
		public int Id;

		public float FlickerDuration;

		public float NormalizedTimeElapsed;

		public float CurrentIntensity;

		public float IntensityTarget;

		public float PreviousIntensity;

		public float MinIntensity;

		public float MaxIntensity;

		public float3 CurrentPosition;

		public float3 PositionTarget;

		public float3 PreviousPosition;

		public float3 CenterPosition;

		public float PositionRange;
	}

	public struct BoundsAndCounter
	{
		public int counter;

		public Bounds bounds;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void RecomputeFlickeringLightIntensity_00004C3A_0024PostfixBurstDelegate(ref NativeList<LightFlickerData> data);

	internal static class RecomputeFlickeringLightIntensity_00004C3A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<RecomputeFlickeringLightIntensity_00004C3A_0024PostfixBurstDelegate>(RecomputeFlickeringLightIntensity).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(ref NativeList<LightFlickerData> data)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeList<LightFlickerData>, void>)functionPointer)(ref data);
					return;
				}
			}
			RecomputeFlickeringLightIntensity_0024BurstManaged(ref data);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ResetLightFlickerData_00004C3B_0024PostfixBurstDelegate(ref NativeList<LightFlickerData> data);

	internal static class ResetLightFlickerData_00004C3B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ResetLightFlickerData_00004C3B_0024PostfixBurstDelegate>(ResetLightFlickerData).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(ref NativeList<LightFlickerData> data)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeList<LightFlickerData>, void>)functionPointer)(ref data);
					return;
				}
			}
			ResetLightFlickerData_0024BurstManaged(ref data);
		}
	}

	public static readonly string SceneLighting = "SCENE_LIGHTING";

	private static readonly ProfilerMarker RecomputeFlickeringLightIntensityMarker = new ProfilerMarker("RecomputeFlickeringLightIntensity");

	private PugLightQuality _lightQualityAtLastFlickerUpdate = PugLightQuality.Undefined;

	private List<BoundsAndCounter> shadowBounds = new List<BoundsAndCounter>();

	private int currentLightGroupToBeUpdated;

	public static int amountOfLightGroups = 5;

	public float optimizedLightsWeight = 1f;

	[Range(0f, 1f)]
	public float lightsQuality = 1f;

	[Range(0f, 1f)]
	public float optimizedLightsQuality = 0.25f;

	private NativeList<LightFlickerData> _lightFlickerData;

	private List<Light> _flickeringLights;

	private Dictionary<int, int> _lightFlickerDataIndex;

	private int _nextLightFlickerID;

	private const int maxDistanceToMergeBounds = 8;

	[Header("Flickering")]
	[Min(0f)]
	public float lightFlickerFrequency = 4f;

	public bool debugLightFlickering;

	private Vector3 halfScreenWidth;

	private Vector3 halfScreenHeight;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("LightManager.Init");

	public bool overridePugRPParameters = true;

	public float LIGHT_FLICKER_MOVEMENT_RANGE => 0.05f;

	protected void OnDestroy()
	{
		_lightFlickerData.Dispose();
		_flickeringLights.Clear();
		_lightFlickerDataIndex.Clear();
	}

	public override bool Setup()
	{
		halfScreenWidth = new Vector3(14f, 0f, 0f);
		halfScreenHeight = new Vector3(0f, 0f, 7.4375f);
		_lightFlickerData = new NativeList<LightFlickerData>(128, Allocator.Persistent);
		_flickeringLights = new List<Light>(128);
		_lightFlickerDataIndex = new Dictionary<int, int>(128);
		return true;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			Shader.EnableKeyword(SceneLighting);
			return true;
		}
	}

	public void UpdateShadowsAtTilePosition(float2 pos)
	{
		Vector3 vector = new Vector3(pos.x, 0f, pos.y);
		Vector3 vector2 = EntityMonoBehaviour.ToRenderFromWorld(Manager.camera.GetCameraTargetPosition());
		if (Mathf.Abs(vector.x - vector2.x) > halfScreenWidth.x + 10f || Mathf.Abs(vector.z - vector2.z) > halfScreenHeight.z + 10f)
		{
			return;
		}
		Bounds bounds = new Bounds(vector, Vector3.one);
		int num = -1;
		float num2 = float.MaxValue;
		for (int i = 0; i < shadowBounds.Count; i++)
		{
			BoundsAndCounter boundsAndCounter = shadowBounds[i];
			if (boundsAndCounter.bounds.Contains(vector))
			{
				return;
			}
			float sqrMagnitude = (boundsAndCounter.bounds.center - vector).sqrMagnitude;
			if (sqrMagnitude < num2)
			{
				num2 = sqrMagnitude;
				num = i;
			}
		}
		if (num == -1 || Mathf.Sqrt(num2) > 8f)
		{
			shadowBounds.Add(new BoundsAndCounter
			{
				bounds = bounds,
				counter = 0
			});
		}
		else
		{
			BoundsAndCounter value = shadowBounds[num];
			value.bounds.Encapsulate(bounds);
			shadowBounds[num] = value;
		}
	}

	public int AddLightFlicker(Light flickeringLight, float minIntensity, float maxIntensity, float3 center, bool enableMovement)
	{
		int num = _nextLightFlickerID++;
		if (flickeringLight == null)
		{
			return num;
		}
		if (lightFlickerFrequency < float.Epsilon)
		{
			Debug.LogError("Cannot have a flicker frequency of 0 or less.");
			return num;
		}
		float num2 = (enableMovement ? LIGHT_FLICKER_MOVEMENT_RANGE : 0f);
		_lightFlickerDataIndex.Add(num, _lightFlickerData.Length);
		_lightFlickerData.Add(new LightFlickerData
		{
			Id = num,
			FlickerDuration = 1f / lightFlickerFrequency,
			NormalizedTimeElapsed = 0f,
			IntensityTarget = UnityEngine.Random.Range(minIntensity, maxIntensity),
			PreviousIntensity = flickeringLight.intensity,
			CurrentIntensity = flickeringLight.intensity,
			MinIntensity = minIntensity,
			MaxIntensity = maxIntensity,
			PositionTarget = (float3)UnityEngine.Random.insideUnitSphere * num2 + center,
			PreviousPosition = flickeringLight.transform.localPosition,
			CurrentPosition = flickeringLight.transform.localPosition,
			CenterPosition = center,
			PositionRange = num2
		});
		_flickeringLights.Add(flickeringLight);
		return num;
	}

	public void RemoveLightFlicker(int id)
	{
		if (_lightFlickerDataIndex.TryGetValue(id, out var value))
		{
			_lightFlickerData.RemoveAtSwapBack(value);
			_flickeringLights.RemoveAtSwapBack(value);
			_lightFlickerDataIndex.Remove(id);
			if (value != _lightFlickerData.Length)
			{
				_lightFlickerDataIndex[_lightFlickerData[value].Id] = value;
			}
		}
	}

	public void UpdateLightFlickerParameters(int id, float min, float max, bool enableMovement)
	{
		if (_lightFlickerDataIndex.TryGetValue(id, out var value))
		{
			float num = (enableMovement ? LIGHT_FLICKER_MOVEMENT_RANGE : 0f);
			LightFlickerData value2 = _lightFlickerData[value];
			value2.FlickerDuration = 1f / lightFlickerFrequency;
			value2.MinIntensity = min;
			value2.MaxIntensity = max;
			value2.PositionRange = num;
			if (num < float.Epsilon)
			{
				_flickeringLights[value].transform.localPosition = Vector3.zero;
			}
			_lightFlickerData[value] = value2;
		}
	}

	public void UpdateLightFlickerEffect()
	{
		PugLightQuality lightQuality = (PugLightQuality)Manager.prefs.lightQuality;
		if (lightQuality >= PugLightQuality.Medium)
		{
			RecomputeFlickeringLightIntensity(ref _lightFlickerData);
			UpdateLightsFromFlickerData(_flickeringLights, _lightFlickerData);
		}
		else if (lightQuality != _lightQualityAtLastFlickerUpdate)
		{
			ResetLightFlickerData(ref _lightFlickerData);
			UpdateLightsFromFlickerData(_flickeringLights, _lightFlickerData);
		}
		_lightQualityAtLastFlickerUpdate = lightQuality;
	}

	private void Update()
	{
		switch (Manager.prefs.lightQuality)
		{
		case 0:
			ManagedLight.optimizationBucketSize = 3.25f;
			break;
		case 1:
			ManagedLight.optimizationBucketSize = 2.25f;
			break;
		default:
			ManagedLight.optimizationBucketSize = 2.25f;
			break;
		case 3:
			ManagedLight.optimizationBucketSize = 1.25f;
			break;
		}
		if (!Manager.sceneHandler.isInGame)
		{
			ManagedLight.UpdateOptimization();
			UpdateLightFlickerEffect();
		}
	}

	private void LateUpdate()
	{
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame)
		{
			shadowBounds.Clear();
		}
		else
		{
			if (shadowBounds.Count <= 0)
			{
				return;
			}
			for (int num = shadowBounds.Count - 1; num >= 0; num--)
			{
				Bounds bounds = shadowBounds[num].bounds;
				BoundsAndCounter value = shadowBounds[num];
				value.counter++;
				shadowBounds[num] = value;
				Shadows.MarkAreaDirty(bounds, allowAmortization: false);
				if (shadowBounds[num].counter >= amountOfLightGroups)
				{
					shadowBounds.RemoveAt(num);
				}
			}
		}
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(RecomputeFlickeringLightIntensity_00004C3A_0024PostfixBurstDelegate))]
	private static void RecomputeFlickeringLightIntensity(ref NativeList<LightFlickerData> data)
	{
		RecomputeFlickeringLightIntensity_00004C3A_0024BurstDirectCall.Invoke(ref data);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ResetLightFlickerData_00004C3B_0024PostfixBurstDelegate))]
	private static void ResetLightFlickerData(ref NativeList<LightFlickerData> data)
	{
		ResetLightFlickerData_00004C3B_0024BurstDirectCall.Invoke(ref data);
	}

	private static void UpdateLightsFromFlickerData(List<Light> flickeringLights, NativeList<LightFlickerData> data)
	{
		bool flag = PugRP.asset.punctualShadowsType == ShadowsType.Raymarching;
		for (int i = 0; i < flickeringLights.Count; i++)
		{
			LightFlickerData lightFlickerData = data[i];
			flickeringLights[i].intensity = lightFlickerData.CurrentIntensity;
			flickeringLights[i].transform.localPosition = (flag ? lightFlickerData.CurrentPosition : lightFlickerData.CenterPosition);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void RecomputeFlickeringLightIntensity_0024BurstManaged(ref NativeList<LightFlickerData> data)
	{
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < data.Length; i++)
		{
			LightFlickerData value = data[i];
			value.NormalizedTimeElapsed += deltaTime / value.FlickerDuration;
			if (value.NormalizedTimeElapsed >= 1f)
			{
				value.PreviousIntensity = value.IntensityTarget;
				value.IntensityTarget = UnityEngine.Random.Range(value.MinIntensity, value.MaxIntensity);
				value.PreviousPosition = value.PositionTarget;
				value.PositionTarget = (float3)UnityEngine.Random.insideUnitSphere * value.PositionRange + value.CenterPosition;
				value.NormalizedTimeElapsed = 0f;
			}
			float normalizedTimeElapsed = value.NormalizedTimeElapsed;
			normalizedTimeElapsed = normalizedTimeElapsed * normalizedTimeElapsed * (3f - 2f * normalizedTimeElapsed);
			value.CurrentIntensity = math.lerp(value.PreviousIntensity, value.IntensityTarget, normalizedTimeElapsed);
			value.CurrentPosition = math.lerp(value.PreviousPosition, value.PositionTarget, normalizedTimeElapsed);
			data[i] = value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ResetLightFlickerData_0024BurstManaged(ref NativeList<LightFlickerData> data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			LightFlickerData value = data[i];
			value.CurrentIntensity = (value.IntensityTarget = (value.PreviousIntensity = (value.MinIntensity + value.MaxIntensity) / 2f));
			value.PreviousPosition = value.CenterPosition;
			value.PositionTarget = value.CenterPosition;
			value.CurrentPosition = value.CenterPosition;
			value.NormalizedTimeElapsed = 1f;
			data[i] = value;
		}
	}
}
