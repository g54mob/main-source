using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Fire;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Tools.Textures;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Water;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Village.Map
{
	public class TemperatureManager : ComputeDataProcessor<TemperatureOutputStruct>
	{
		private TemperatureSettings settings;

		private const float GradientMinValue = -50f;

		private const float GradientMaxValue = 50f;

		private const int BlurSize = 13;

		private static ComputeBuffer combinedBuffer;

		private static ComputeBuffer heatBuffer;

		private static ComputeBuffer indicesBuffer;

		private static ComputeBuffer isInIndicesBuffer;

		private static ComputeBuffer emissionIndicesBuffer;

		private static ComputeBuffer emissionRangeBuffer;

		private static ComputeBuffer fireComputeBuffer;

		private static NativeArray<int> combinedDataNative;

		private static NativeArray<int> isInIndices;

		private static readonly object CombinedDataLock = new object();

		private List<int> emissionIndices;

		private List<int> emissionRangePerIndex;

		private int kernelIndexHeatEmissionPass;

		private int kernelIndexDiffuseLightPass;

		private int kernelIndexDiffuseLightBlurPass;

		private uint emissionThreadGroupX;

		private uint emissionThreadGroupY;

		private uint emissionThreadGroupZ;

		private uint diffuseLightThreadGroupX;

		private uint diffuseLightThreadGroupY;

		private uint diffuseLightThreadGroupZ;

		private uint diffuseLightBlurThreadGroupX;

		private uint diffuseLightBlurThreadGroupY;

		private uint diffuseLightBlurThreadGroupZ;

		private float[] sunDirection;

		private VillageMap map;

		private WaterSimLogic waterSimLogic;

		private Texture2D gradientTexture;

		private RenderTexture effects3dTexture;

		private ComputeBuffer blurKernelBuffer;

		private ComputeBuffer raycastDirectionsBuffer;

		private List<float> blurKernelData;

		private List<float> raycastDirectionsData;

		private AirFloodfillManager airFloodfillManager;

		private int mapHeight;

		private List<int> nodeIndices;

		private HashSet<int> nodeIndicesSet;

		private bool walkableIndicesModified;

		private bool emissionIndicesModified;

		private BaseTimer dispatchDiffuseLightTimer;

		private bool diffusePassDispatchScheduled;

		private int temperatureDamageNodeIndex;

		private float temperatureDamageDeltaTime;

		private readonly Stopwatch stopwatchTemperatureDamageHealth = new Stopwatch();

		private float minBuildingHeatDamageThreshold;

		private List<int> nodeIndexesToCheckForTempDamage;

		private bool isTempDamageGatherThreadJobRunning;

		private float tempDamageJobLastRunTimestamp;

		protected override string ShaderPath => "Shaders/Compute/TemperatureComputeShader";

		protected override float DelayBeforeDispatch => 1f;

		public Texture2D GradientTexture => gradientTexture;

		public TemperatureSettings Settings => settings;

		public string GradientMinText
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return string.Empty;
				}
				return WorldDate.GetLocalizedTemperature(-50f);
			}
		}

		public string GradientMaxText
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return string.Empty;
				}
				return WorldDate.GetLocalizedTemperature(50f);
			}
		}

		public string GradientCenterText
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return string.Empty;
				}
				return WorldDate.GetLocalizedTemperature(0f);
			}
		}

		public RenderTexture Effects3dTexture => effects3dTexture;

		public ComputeBuffer OutputBuffer => ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer;

		public ComputeBuffer CombinedBuffer => combinedBuffer;

		public static void InitStaticArrays()
		{
			lock (CombinedDataLock)
			{
				combinedDataNative = ArrayStorage.GetNativeArray<int>("TemperatureManager.combinedDataNative", GridDataIndexTools.MaxDataLength);
			}
			isInIndices = ArrayStorage.GetNativeArray<int>("TemperatureManager.isInIndices", GridDataIndexTools.MaxDataLength);
			ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.outputBuffer", GridDataIndexTools.MaxDataLength, 12);
			combinedBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.combinedBuffer", GridDataIndexTools.MaxDataLength, 4);
			heatBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.heatBuffer", GridDataIndexTools.MaxDataLength, 4);
			indicesBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.indicesBuffer", GridDataIndexTools.MaxDataLength, 4);
			isInIndicesBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.isInIndicesBuffer", GridDataIndexTools.MaxDataLength, 4);
			emissionIndicesBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.emissionIndicesBuffer", GridDataIndexTools.MaxDataLength, 4);
			emissionRangeBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.emissionRangeBuffer", GridDataIndexTools.MaxDataLength, 4);
			fireComputeBuffer = ArrayStorage.GetComputeBuffer("TemperatureManager.fireComputeBuffer", GridDataIndexTools.MaxDataLength, 4);
			ComputeDataProcessor<TemperatureOutputStruct>.outputData = ArrayStorage.GetArray<TemperatureOutputStruct>("TemperatureManager.outputData", GridDataIndexTools.MaxDataLength);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(combinedDataNative, base.ArraySize, 128);
			ArrayStorage.ClearNativeArray(isInIndices, base.ArraySize);
			Array.Clear(ComputeDataProcessor<TemperatureOutputStruct>.outputData, 0, base.ArraySize);
		}

		public static void UnpackData(in int input, out byte heatingTemperature, out byte insulation, out byte verticalInsulation)
		{
			heatingTemperature = (byte)(input & 0xFF);
			insulation = (byte)((input >> 8) & 0xFF);
			verticalInsulation = (byte)((input >> 16) & 0xFF);
		}

		public void SetInputData(Vec3Int pos, byte heating, byte insulation, byte verticalInsulation, bool isWalkable, bool isGround, bool isWall, int emitterRange, byte lightTransmission)
		{
			if (isGround)
			{
				heating = 0;
			}
			int num = Get1DIndex(Math.Clamp(pos.x, 0, MapSizeX - 1), Math.Clamp(pos.y, 0, MapSizeY - 1), Math.Clamp(pos.z, 0, MapSizeZ - 1));
			int num2 = GetInputDataPacked(pos) & 0xFF;
			if (!isGround && !isWall && heating != num2)
			{
				emissionIndicesModified = true;
				if (heating == 128)
				{
					int num3 = emissionIndices.IndexOf(num);
					if (num3 != -1)
					{
						emissionIndices.RemoveAt(num3);
						emissionRangePerIndex.RemoveAt(num3);
					}
				}
				else
				{
					int num4 = emissionIndices.IndexOf(num);
					if (num4 == -1)
					{
						emissionIndices.Add(num);
						emissionRangePerIndex.Add(emitterRange);
					}
					else
					{
						emissionRangePerIndex[num4] = emitterRange;
					}
				}
			}
			int num5 = heating | (insulation << 8) | (verticalInsulation << 16) | ((isWalkable ? 1 : 0) << 24) | ((isGround ? 1 : 0) << 25) | ((isWall ? 1 : 0) << 26) | ((lightTransmission & 3) << 30);
			lock (CombinedDataLock)
			{
				int num6 = combinedDataNative[num];
				num5 = (num5 & -939524097) | (0x38000000 & num6);
				combinedDataNative[GetClampedIndex(pos.x, pos.y, pos.z)] = num5;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetOutsideAir(int index, bool isAir)
		{
			int num = (isAir ? 1 : 0) << 27;
			lock (CombinedDataLock)
			{
				combinedDataNative[index] = (combinedDataNative[index] & -134217729) | num;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetShadowCaster(Vec3Int position, bool isShadowCasterH, bool isShadowCasterV)
		{
			int index = Get1DIndex(position.x, position.y, position.z);
			int num = ((isShadowCasterH ? 1 : 0) << 28) | ((isShadowCasterV ? 1 : 0) << 29);
			lock (CombinedDataLock)
			{
				combinedDataNative[index] = (combinedDataNative[index] & -805306369) | num;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetTemperature(Vec3Int position)
		{
			if (!GridDataIndexTools.InRange(position.x, position.y, position.z))
			{
				return 0f;
			}
			return GetTemperature(GridDataIndexTools.FastTo1DIndex(position.x, position.y, position.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetTemperature(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return 0f;
			}
			return GetTemperature(GridDataIndexTools.FastTo1DIndex(x, y, z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetTemperature(int index3d)
		{
			if (waterSimLogic.IsWaterAt(index3d))
			{
				return WaterTemperature();
			}
			return GetOutputData(index3d).Temperature;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetShadow(Vec3Int position)
		{
			return GetOutputData(position.x, position.y, position.z).Shadow;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetShadow(int x, int y, int z)
		{
			return GetOutputData(x, y, z).Shadow;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetDiffuseLight(Vec3Int position)
		{
			return GetOutputData(position.x, position.y, position.z).Light;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetDiffuseLight(int x, int y, int z)
		{
			return GetOutputData(x, y, z).Light;
		}

		public int GetNodeTemperaturePriority(CreatureBase creature, MapNode node)
		{
			float temperature = GetTemperature(node.Position);
			if (temperature > creature.OptimalNodeTemperatureRangeMin && temperature < creature.OptimalNodeTemperatureRangeMax)
			{
				return 0;
			}
			if (!IsTemperatureOutOfRange(temperature))
			{
				return 1;
			}
			return 2;
		}

		public bool IsNodeTemperatureOptimal(CreatureBase creature, MapNode node)
		{
			float temperature = GetTemperature(node.Position);
			if (temperature > creature.OptimalNodeTemperatureRangeMin)
			{
				return temperature < creature.OptimalNodeTemperatureRangeMax;
			}
			return false;
		}

		public bool IsTemperatureOutOfRange(float temperature)
		{
			if (!(temperature < settings.SkipRoomIdleUnderTemperature))
			{
				return temperature > settings.SkipRoomIdleOverTemperature;
			}
			return true;
		}

		public bool IsNodeTemperatureOutOfRange(MapNode node)
		{
			float temperature = GetTemperature(node.Position);
			if (!(temperature < settings.SkipRoomIdleUnderTemperature))
			{
				return temperature > settings.SkipRoomIdleOverTemperature;
			}
			return true;
		}

		public float GetLightIntensity(Vec3Int gridDataPosition)
		{
			if (!MonoSingleton<WeatherManager>.IsInstantiated())
			{
				return 0f;
			}
			float shadow = GetShadow(gridDataPosition);
			float num = 1f - shadow;
			return Mathf.Clamp01(Mathf.Lerp(Mathf.Lerp(GetDiffuseLight(gridDataPosition), num, 0.17f), num, num) * MonoSingleton<WeatherManager>.Instance.SunIntensity);
		}

		public void SetSunDirection(Vector3 direction)
		{
			if (sunDirection == null)
			{
				sunDirection = new float[3];
			}
			sunDirection[0] = direction.x;
			sunDirection[1] = direction.y;
			sunDirection[2] = direction.z;
		}

		public bool IsInIndices(int nodeIndex)
		{
			return nodeIndicesSet.Contains(nodeIndex);
		}

		public byte[] GetBinaryDataToSerialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(memoryStream);
			SafeOutputDataOperation(delegate(TemperatureOutputStruct[] outputData)
			{
				for (int i = 0; i < base.ArraySize; i++)
				{
					bw.Write(outputData[i].Temperature);
				}
			});
			return memoryStream.GetBuffer();
		}

		public void ReadFromBinaryData(byte[] inputData)
		{
			if (inputData == null || inputData.Length == 0)
			{
				return;
			}
			MemoryStream ms = new MemoryStream(inputData);
			try
			{
				BinaryReader br = new BinaryReader(ms);
				try
				{
					SafeOutputDataOperation(delegate(TemperatureOutputStruct[] outputData)
					{
						if (ms.Length >= base.ArraySize)
						{
							for (int i = 0; i < base.ArraySize; i++)
							{
								float temperature = br.ReadSingle();
								outputData[i].Set(temperature, 0f, 0f);
							}
							ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer.SetData(outputData, 0, 0, base.ArraySize);
						}
					});
					OnOutputDataRetrieved();
				}
				finally
				{
					if (br != null)
					{
						((IDisposable)br).Dispose();
					}
				}
			}
			finally
			{
				if (ms != null)
				{
					((IDisposable)ms).Dispose();
				}
			}
		}

		protected override void LoadShader()
		{
			base.LoadShader();
			kernelIndexHeatEmissionPass = base.ComputeShader.FindKernel("CSMainEmission");
			base.ComputeShader.GetKernelThreadGroupSizes(kernelIndexHeatEmissionPass, out emissionThreadGroupX, out emissionThreadGroupY, out emissionThreadGroupZ);
			base.ComputeShader.SetBuffer(kernelIndexHeatEmissionPass, "outputBuffer", ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer);
			kernelIndexDiffuseLightPass = base.ComputeShader.FindKernel("CSMainDiffuseLight");
			base.ComputeShader.GetKernelThreadGroupSizes(kernelIndexDiffuseLightPass, out diffuseLightThreadGroupX, out diffuseLightThreadGroupY, out diffuseLightThreadGroupZ);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightPass, "outputBuffer", ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer);
			kernelIndexDiffuseLightBlurPass = base.ComputeShader.FindKernel("CSMainDiffuseLightBlur");
			base.ComputeShader.GetKernelThreadGroupSizes(kernelIndexDiffuseLightBlurPass, out diffuseLightBlurThreadGroupX, out diffuseLightBlurThreadGroupY, out diffuseLightBlurThreadGroupZ);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightBlurPass, "outputBuffer", ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer);
		}

		protected override void PrepareCommandBuffer(ref CommandBuffer commandBuffer)
		{
			if (!MonoSingleton<Heightmap>.IsInstantiated() || MonoSingleton<Heightmap>.IsApplicationIsQuitting())
			{
				return;
			}
			int num = Mathf.CeilToInt((float)nodeIndices.Count / (float)(ThreadGroupX * 2));
			int num2 = (int)ThreadGroupX * num;
			int num3 = CurrentIteration * num2;
			num = Math.Min(num, Mathf.CeilToInt((float)(nodeIndices.Count - num3) / (float)ThreadGroupX));
			if (num == 0)
			{
				return;
			}
			base.ComputeShader.SetInt("indexOffset", num3);
			base.ComputeShader.SetInt("nodeIndicesCount", nodeIndicesSet.Count);
			base.ComputeShader.SetBuffer(base.KernelIndex, "heightmapBuffer", MonoSingleton<Heightmap>.Instance.ComputeBuffer);
			fireComputeBuffer.SetData(map.FireSimLogic.FireTemperature, 0, 0, base.ArraySize);
			if (CurrentIteration == 0)
			{
				base.ComputeShader.SetFloat("outsideTemperature", OutsideTemperature());
				base.ComputeShader.SetFloat("soilTemperature", SoilTemperature());
				if (MonoSingleton<WeatherManager>.IsInstantiated())
				{
					WeatherManager instance = MonoSingleton<WeatherManager>.Instance;
					SetSunDirection(instance.GetSunDirection());
					base.ComputeShader.SetFloat("sunIntensity", instance.GetSunIntensityClamped(60f));
					base.ComputeShader.SetFloats("sunDirection", sunDirection);
					base.ComputeShader.SetFloat("rainEffectWeight", instance.RainEffectWeight);
					base.ComputeShader.SetFloat("snowEffectWeight", instance.SnowEffectWeight);
					base.ComputeShader.SetFloat("fogEffectWeight", instance.FogEffectWeight);
					base.ComputeShader.SetFloat("cloudEffectWeight", instance.CloudEffectWeight);
					base.ComputeShader.SetBool("isDay", instance.IsDay);
				}
				FillEmissionIndicesBuffer();
				base.ComputeShader.SetBuffer(kernelIndexHeatEmissionPass, "indicesBuffer", emissionIndicesBuffer);
				base.ComputeShader.SetBuffer(kernelIndexHeatEmissionPass, "emissionRangeForIndex", emissionRangeBuffer);
			}
			FillIndicesBuffer();
			base.ComputeShader.SetBuffer(base.KernelIndex, "indicesBuffer", indicesBuffer);
			base.ComputeShader.SetBuffer(base.KernelIndex, "isInIndicesBuffer", isInIndicesBuffer);
			commandBuffer.Clear();
			lock (CombinedDataLock)
			{
				commandBuffer.SetBufferData(combinedBuffer, combinedDataNative, 0, 0, base.ArraySize);
			}
			commandBuffer.BeginSample("*** CB Dispatch " + commandBuffer.name);
			if (CurrentIteration == 0)
			{
				int num4 = Mathf.CeilToInt((float)emissionIndices.Count / (float)emissionThreadGroupX);
				if (num4 > 0)
				{
					commandBuffer.DispatchCompute(base.ComputeShader, kernelIndexHeatEmissionPass, num4, 1, 1);
				}
			}
			commandBuffer.DispatchCompute(base.ComputeShader, base.KernelIndex, num, 1, 1);
			commandBuffer.RequestAsyncReadback(ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer, base.ComputeShaderCallback);
			commandBuffer.EndSample("*** CB Dispatch " + commandBuffer.name);
		}

		private void ScheduleDispatchDiffuse()
		{
			if (!diffusePassDispatchScheduled)
			{
				diffusePassDispatchScheduled = true;
				dispatchDiffuseLightTimer.RestartTimer();
				dispatchDiffuseLightTimer.Resume();
			}
		}

		private void DispatchDiffuseLightPass()
		{
			diffusePassDispatchScheduled = false;
			if (!MonoSingleton<Heightmap>.IsInstantiated() || MonoSingleton<Heightmap>.IsApplicationIsQuitting())
			{
				return;
			}
			int num = Mathf.CeilToInt((float)nodeIndices.Count / (float)diffuseLightThreadGroupX);
			if (num > 0)
			{
				FillIndicesBuffer();
				base.ComputeShader.SetInt("nodeIndicesCount", nodeIndicesSet.Count);
				base.ComputeShader.SetBuffer(kernelIndexDiffuseLightPass, "indicesBuffer", indicesBuffer);
				base.ComputeShader.SetBuffer(kernelIndexDiffuseLightBlurPass, "indicesBuffer", indicesBuffer);
				lock (CombinedDataLock)
				{
					combinedBuffer.SetData(combinedDataNative, 0, 0, base.ArraySize);
				}
				Shader.SetGlobalTexture("_effects3dTexture", effects3dTexture);
				base.ComputeShader.SetTexture(kernelIndexDiffuseLightPass, "diffuseLightTexture", effects3dTexture);
				base.ComputeShader.SetBuffer(kernelIndexDiffuseLightPass, "heightmapBuffer", MonoSingleton<Heightmap>.Instance.ComputeBuffer);
				base.ComputeShader.SetTexture(kernelIndexDiffuseLightBlurPass, "diffuseLightTexture", effects3dTexture);
				base.ComputeShader.SetBuffer(kernelIndexDiffuseLightBlurPass, "heightmapBuffer", MonoSingleton<Heightmap>.Instance.ComputeBuffer);
				base.ComputeShader.Dispatch(kernelIndexDiffuseLightPass, num, 1, 1);
				base.ComputeShader.Dispatch(kernelIndexDiffuseLightBlurPass, num, 1, 1);
			}
		}

		protected override void OnOutputDataRetrieved()
		{
			if (!MonoSingleton<LoadingController>.IsApplicationIsQuitting() && !LoadingController.IsLeavingMainScene && ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer != null && ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer.IsValid() && MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.DisplayHeatmap(HeatmapType.Temperature, ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer, isInputBuffer3D: true, -50f, 50f, gradientTexture);
			}
		}

		private void TickTemperatureDecreaseHealth(float dt)
		{
			using (ProfilerSampleJanitor.Begin("*** TickTemperatureDecreaseHealth"))
			{
				if (dt <= 0f)
				{
					if (stopwatchTemperatureDamageHealth.IsRunning)
					{
						stopwatchTemperatureDamageHealth.Stop();
					}
				}
				else
				{
					if (isTempDamageGatherThreadJobRunning)
					{
						return;
					}
					if (nodeIndexesToCheckForTempDamage.Count == 0)
					{
						if (!(Time.time - tempDamageJobLastRunTimestamp < 1f))
						{
							isTempDamageGatherThreadJobRunning = true;
							tempDamageJobLastRunTimestamp = Time.time;
							MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(GatherNodesToCheckForTempDamage, delegate
							{
								isTempDamageGatherThreadJobRunning = false;
							});
						}
						return;
					}
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Temperature\\TemperatureManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("TickTemperatureDecreaseHealth indexes ");
						messageBuilder.AppendFormatted(temperatureDamageNodeIndex);
						messageBuilder.AppendLiteral(" - ");
						messageBuilder.AppendFormatted(nodeIndexesToCheckForTempDamage.Count);
					}
					Log.Trace(messageBuilder);
					if (!stopwatchTemperatureDamageHealth.IsRunning)
					{
						stopwatchTemperatureDamageHealth.Start();
					}
					if (temperatureDamageNodeIndex == 0)
					{
						temperatureDamageDeltaTime = (float)stopwatchTemperatureDamageHealth.Elapsed.TotalMilliseconds;
						stopwatchTemperatureDamageHealth.Restart();
					}
					float num = temperatureDamageDeltaTime * Time.timeScale / 1000f;
					MapNode[] gridSpaceData = map.GridSpaceData;
					for (int num2 = temperatureDamageNodeIndex; num2 < nodeIndexesToCheckForTempDamage.Count; num2++)
					{
						int num3 = nodeIndexesToCheckForTempDamage[num2];
						MapNode mapNode = gridSpaceData[num3];
						if (mapNode.DataType == GridDataType.None || mapNode.VoxelTypeIdByte != 0)
						{
							continue;
						}
						bool flag = false;
						foreach (WorldObject item in mapNode.WorldObjects.IterateInReverseDynamic())
						{
							if (!item.HasDisposed && (item.GridDataType & (GridDataType.BuildingFinished | GridDataType.Furniture | GridDataType.BeamFinished | GridDataType.RugFinished)) != GridDataType.None && item is BaseBuildingInstance baseBuildingInstance && !(baseBuildingInstance.Blueprint.HeatDamage <= 0f) && !(map.TemperatureManager.GetTemperature(num3) <= baseBuildingInstance.Blueprint.HeatDamageThreshold))
							{
								StatInstance stat = baseBuildingInstance.Stats.GetStat(StatType.Health);
								bool disableShaker = stat.DisableShaker;
								stat.DisableShaker = true;
								stat.SetCurrent(stat.Current - baseBuildingInstance.Blueprint.HeatDamage * num);
								stat.DisableShaker = disableShaker;
								flag = true;
							}
						}
						bool flag2 = num2 == nodeIndexesToCheckForTempDamage.Count - 1;
						flag |= num2 % 200 == 0;
						temperatureDamageNodeIndex = num2 + 1;
						if ((flag || flag2) && (flag2 || stopwatchTemperatureDamageHealth.ElapsedMilliseconds >= 1))
						{
							temperatureDamageNodeIndex = ((!flag2) ? (num2 + 1) : 0);
							if (temperatureDamageNodeIndex == 0)
							{
								nodeIndexesToCheckForTempDamage.Clear();
							}
							return;
						}
					}
					temperatureDamageNodeIndex = 0;
					nodeIndexesToCheckForTempDamage.Clear();
				}
			}
		}

		private bool GatherNodesToCheckForTempDamage()
		{
			for (int i = 0; i < base.ArraySize; i++)
			{
				if (map.TemperatureManager.GetTemperature(i) >= minBuildingHeatDamageThreshold)
				{
					nodeIndexesToCheckForTempDamage.Add(i);
				}
			}
			return true;
		}

		protected override void OnTick()
		{
			DispatchScheduled = true;
			base.OnTick();
		}

		private void SetCommonBuffers(int kernelIndex)
		{
			base.ComputeShader.SetBuffer(kernelIndex, "combinedBuffer", combinedBuffer);
			base.ComputeShader.SetBuffer(kernelIndex, "blurKernel", blurKernelBuffer);
			base.ComputeShader.SetBuffer(kernelIndex, "raycastDirectionsBuffer", raycastDirectionsBuffer);
			base.ComputeShader.SetBuffer(kernelIndex, "heatBuffer", heatBuffer);
		}

		protected override void ReloadShader()
		{
			base.ReloadShader();
			SetCommonBuffers(base.KernelIndex);
			SetCommonBuffers(kernelIndexHeatEmissionPass);
			SetCommonBuffers(kernelIndexDiffuseLightPass);
			SetCommonBuffers(kernelIndexDiffuseLightBlurPass);
			base.ComputeShader.SetInt("blurKernelSize", blurKernelData.Count / 3);
			base.ComputeShader.SetInt("raycastDirectionsBufferLength", raycastDirectionsData.Count / 3);
		}

		public void Initialize(VillageMap villageMap)
		{
			settings = Repository<TemperatureSettingsData, TemperatureSettings>.Instance.GetData<TemperatureSettings>();
			emissionIndices = new List<int>();
			emissionRangePerIndex = new List<int>();
			nodeIndices = new List<int>();
			nodeIndicesSet = new HashSet<int>();
			map = villageMap;
			waterSimLogic = villageMap.WaterManager.WaterSimLogic;
			mapHeight = map.Size.y;
			TimerDispatch = new Timer(DelayBeforeDispatch, restartOnEnd: false);
			TickTimer = new Timer(0.05f, restartOnEnd: true);
			InitMapSize(villageMap.Size);
			InitStaticArrays();
			ClearStaticArrays();
			Initialize();
			SetHeatBufferDataAtStart();
			base.ComputeShader.SetBuffer(base.KernelIndex, "fireHeatBuffer", fireComputeBuffer);
			blurKernelData = ComputeDataProcessor<float>.CreateBlurKernel(13);
			blurKernelBuffer = new ComputeBuffer(blurKernelData.Count, 4);
			blurKernelBuffer.SetData(blurKernelData);
			base.ComputeShader.SetInt("blurKernelSize", blurKernelData.Count / 3);
			raycastDirectionsData = CreateRaycastDirections();
			raycastDirectionsBuffer = new ComputeBuffer(raycastDirectionsData.Count, 4);
			raycastDirectionsBuffer.SetData(raycastDirectionsData);
			base.ComputeShader.SetInt("raycastDirectionsBufferLength", raycastDirectionsData.Count / 3);
			MonoSingleton<VisualHeatmapManager>.Instance.OnShowHeatmap += OnShowHeatmap;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnMapLoaded;
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
			MonoSingleton<ConstructionController>.Instance.OnDoorLockStateChangedEvent += OnDoorLockStateChanged;
			MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent += OnLockStateChanged;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnAfterConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyedSingle;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			MonoSingleton<Heightmap>.Instance.HeightChangedAtEvent += OnHeightChangedAt;
			gradientTexture = UnityEngine.Resources.Load<Texture2D>("Textures/HeatmapGradientTemperature");
			base.ComputeShader.SetBuffer(base.KernelIndex, "indicesBuffer", indicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightPass, "indicesBuffer", indicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightBlurPass, "indicesBuffer", indicesBuffer);
			base.ComputeShader.SetBuffer(base.KernelIndex, "isInIndicesBuffer", isInIndicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightPass, "isInIndicesBuffer", isInIndicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexDiffuseLightBlurPass, "isInIndicesBuffer", isInIndicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexHeatEmissionPass, "indicesBuffer", emissionIndicesBuffer);
			base.ComputeShader.SetBuffer(kernelIndexHeatEmissionPass, "emissionRangeForIndex", emissionRangeBuffer);
			SetCommonBuffers(base.KernelIndex);
			SetCommonBuffers(kernelIndexHeatEmissionPass);
			SetCommonBuffers(kernelIndexDiffuseLightPass);
			SetCommonBuffers(kernelIndexDiffuseLightBlurPass);
			TextureUtils.Create3DTexture(ref effects3dTexture, new Vec3Int(MapSizeX, MapSizeY, MapSizeZ), RenderTextureFormat.ARGB32);
			effects3dTexture.name = "TemperatureManager.effects3dTexture";
			Shader.SetGlobalTexture("_effects3dTexture", effects3dTexture);
			airFloodfillManager = new AirFloodfillManager(map);
			DispatchScheduled = false;
			TimerDispatch.Pause();
			TickTimer.Pause();
			dispatchDiffuseLightTimer = new Timer(0.1f, restartOnEnd: false);
			dispatchDiffuseLightTimer.Pause();
			dispatchDiffuseLightTimer.AddCallback(DispatchDiffuseLightPass);
			SafeOutputDataOperation(delegate(TemperatureOutputStruct[] outputData)
			{
				for (int i = 0; i < base.ArraySize; i++)
				{
					outputData[i].Set(0f, 0f, 0f);
				}
				ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer.SetData(outputData, 0, 0, base.ArraySize);
			});
			using PooledList<BaseBuildingBlueprint> pooledList = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems().WherePooled((BaseBuildingBlueprint building) => building.HeatDamageThreshold > 0f);
			minBuildingHeatDamageThreshold = pooledList.MinItem((BaseBuildingBlueprint building) => building.HeatDamageThreshold).HeatDamageThreshold;
			nodeIndexesToCheckForTempDamage = new List<int>(500);
			isTempDamageGatherThreadJobRunning = false;
			tempDamageJobLastRunTimestamp = Time.time;
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
		}

		private void OnSceneSetup()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
				MonoSingleton<SceneController>.Instance.Tick += TickTemperatureDecreaseHealth;
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positionsList)
		{
			foreach (Vec3Int positions in positionsList)
			{
				OnGroundDestroyedSingle(positions);
			}
		}

		private void OnGroundDestroyedSingle(Vec3Int pos)
		{
			int num = GridDataIndexTools.FastTo1DIndex(pos);
			if (num < 0 || num >= base.ArraySize)
			{
				return;
			}
			MapNode mapNode = map.GridSpaceData[num];
			if (mapNode == null)
			{
				return;
			}
			if (!mapNode.IsWalkable && (mapNode.BuildingType & (BuildingType.Wall | BuildingType.Beam)) == 0)
			{
				if (nodeIndicesSet.Contains(num))
				{
					RemoveFromIndices(num);
				}
			}
			else if (!nodeIndicesSet.Contains(num))
			{
				AddToIndices(num);
			}
		}

		private void AddToIndices(int index)
		{
			if (nodeIndicesSet.Add(index))
			{
				nodeIndices.Add(index);
				isInIndices[index] = 1;
				if (!walkableIndicesModified)
				{
					walkableIndicesModified = true;
					ScheduleDispatchDiffuse();
				}
			}
		}

		private void RemoveFromIndices(int index)
		{
			if (nodeIndicesSet.Contains(index))
			{
				nodeIndicesSet.Remove(index);
				nodeIndices.Remove(index);
				isInIndices[index] = 0;
				if (!walkableIndicesModified)
				{
					walkableIndicesModified = true;
					ScheduleDispatchDiffuse();
				}
			}
		}

		private void OnHeightChangedAt(int x, int z, int newHeight)
		{
			for (int i = 0; i < mapHeight; i++)
			{
				MapNode node = map.GetNode(x, i, z);
				if (node == null)
				{
					continue;
				}
				bool flag = false;
				if (i <= newHeight)
				{
					if (node.VoxelType == null)
					{
						flag = true;
					}
				}
				else if (i > newHeight && ((node.Tag & MapNodeTags.FloorPassthrough) != MapNodeTags.None || (node.BuildingType & BuildingType.Beam) != 0) && node.VoxelType == null)
				{
					flag = true;
				}
				else
				{
					MapNode nodeBelow = node.GetNodeBelow();
					if (nodeBelow != null && (nodeBelow.DataType & GridDataType.SlopeOrStairs) != GridDataType.None)
					{
						flag = true;
					}
				}
				if (flag)
				{
					AddToIndices(node.Index);
				}
				else
				{
					RemoveFromIndices(node.Index);
				}
			}
		}

		private void SetHeatBufferDataAtStart()
		{
			NativeArray<int> data = new NativeArray<int>(base.ArraySize, Allocator.Temp);
			for (int i = 0; i < base.ArraySize; i++)
			{
				data[i] = 2147450879;
			}
			heatBuffer.SetData(data, 0, 0, base.ArraySize);
			data.Dispose();
		}

		private static float OutsideTemperature()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting() || GlobalSaveController.CurrentVillageData == null)
			{
				return 0f;
			}
			return GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius;
		}

		private static float SoilTemperature()
		{
			if (!MonoSingleton<WeatherManager>.IsInstantiated() || MonoSingleton<WeatherManager>.IsApplicationIsQuitting())
			{
				return 0f;
			}
			return MonoSingleton<WeatherManager>.Instance.SoilTemperature;
		}

		private float WaterTemperature()
		{
			if (!MonoSingleton<WeatherManager>.IsInstantiated() || MonoSingleton<WeatherManager>.IsApplicationIsQuitting())
			{
				return 0f;
			}
			return MonoSingleton<WeatherManager>.Instance.WaterTemperature;
		}

		private void OnRoomRemoved(Room room)
		{
			airFloodfillManager.ScheduleFloodfill();
			RefreshRoomNodes(room);
		}

		private void OnRoomAdded(Room room, RoomType type)
		{
			airFloodfillManager.ScheduleFloodfill();
			RefreshRoomNodes(room);
		}

		private void OnDoorLockStateChanged(BaseBuildingInstance door)
		{
			if (door.BuildingType == BuildingType.Door)
			{
				Room roomForDoor = map.RoomDetection.GetRoomForDoor(door);
				if (roomForDoor != null)
				{
					airFloodfillManager.ScheduleFloodfill();
					ForceRefreshTemperatureInput(roomForDoor);
				}
			}
			ScheduleDispatchDiffuse();
		}

		private void OnLockStateChanged(BaseBuildingInstance building)
		{
			ScheduleDispatchDiffuse();
		}

		private void OnAfterConstructionCompleted(BaseBuildingInstance building)
		{
			ScheduleDispatchDiffuse();
		}

		private void OnDestroyBuilding(BaseBuildingInstance building)
		{
			if (LoadingController.IsLeavingMainScene)
			{
				return;
			}
			foreach (MapNode item in building.Nodes())
			{
				OnGroundDestroyedSingle(item.Position);
			}
			ScheduleDispatchDiffuse();
		}

		private void ForceRefreshTemperatureInput(Room room)
		{
			foreach (MapNode allNode in room.AllNodes)
			{
				allNode?.ForceRefreshTemperatureInput();
			}
		}

		private void RefreshRoomNodes(Room room)
		{
			ForceRefreshTemperatureInput(room);
		}

		public override void Dispose()
		{
			if (effects3dTexture != null)
			{
				effects3dTexture.Release();
				UnityEngine.Object.DestroyImmediate(effects3dTexture);
				effects3dTexture = null;
			}
			base.Dispose();
			TimerDispatch?.Dispose();
			TimerDispatch = null;
			TickTimer?.Dispose();
			TickTimer = null;
			dispatchDiffuseLightTimer?.Dispose();
			dispatchDiffuseLightTimer = null;
			blurKernelBuffer?.Dispose();
			raycastDirectionsBuffer?.Dispose();
			airFloodfillManager?.Dispose();
			airFloodfillManager = null;
			blurKernelBuffer = null;
			raycastDirectionsBuffer = null;
			settings = null;
			emissionIndices = null;
			emissionRangePerIndex = null;
			sunDirection = null;
			gradientTexture = null;
			blurKernelData = null;
			raycastDirectionsData = null;
			airFloodfillManager = null;
			nodeIndices = null;
			nodeIndicesSet = null;
			stopwatchTemperatureDamageHealth.Stop();
			nodeIndexesToCheckForTempDamage = null;
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnMapLoaded;
			}
			if (MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.OnShowHeatmap -= OnShowHeatmap;
			}
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.OnDoorLockStateChangedEvent -= OnDoorLockStateChanged;
				MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent -= OnLockStateChanged;
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnAfterConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
			if (MonoSingleton<Heightmap>.IsInstantiated())
			{
				MonoSingleton<Heightmap>.Instance.HeightChangedAtEvent -= OnHeightChangedAt;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= TickTemperatureDecreaseHealth;
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
			}
			map = null;
			waterSimLogic = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldBeInNodesList(MapNode node)
		{
			if (node != null)
			{
				if (!node.IsWalkable && (node.Tag & MapNodeTags.Wall) == 0)
				{
					return (node.DataType & GridDataType.Roof) != 0;
				}
				return true;
			}
			return false;
		}

		private void InitWalkability()
		{
			Heightmap instance = MonoSingleton<Heightmap>.Instance;
			for (int i = 0; i < map.Size.x; i++)
			{
				for (int j = 0; j < map.Size.z; j++)
				{
					OnHeightChangedAt(i, j, instance.GetHeightAt(i, j));
				}
			}
		}

		private void OnMapLoaded()
		{
			InitWalkability();
			lock (CombinedDataLock)
			{
				combinedBuffer.SetData(combinedDataNative, 0, 0, base.ArraySize);
			}
			TextureUtils.Fill3dTextureWhereNoGround(Effects3dTexture, combinedBuffer);
			airFloodfillManager.ScheduleFloodfill();
			ScheduleDispatchDiffuse();
			TickTimer.Resume();
		}

		public void FillIndicesBuffer()
		{
			if (walkableIndicesModified)
			{
				walkableIndicesModified = false;
				indicesBuffer.SetData(nodeIndices, 0, 0, nodeIndices.Count);
				isInIndicesBuffer.SetData(isInIndices, 0, 0, base.ArraySize);
			}
		}

		private void FillEmissionIndicesBuffer()
		{
			if (emissionIndicesModified)
			{
				emissionIndicesModified = false;
				emissionIndicesBuffer.SetData(emissionIndices, 0, 0, emissionIndices.Count);
				emissionRangeBuffer.SetData(emissionRangePerIndex, 0, 0, emissionRangePerIndex.Count);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetInputDataPacked(int x, int y, int z)
		{
			lock (CombinedDataLock)
			{
				return combinedDataNative[GetClampedIndex(x, y, z)];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetInputDataPacked(Vec3Int pos)
		{
			lock (CombinedDataLock)
			{
				return combinedDataNative[GetClampedIndex(pos.x, pos.y, pos.z)];
			}
		}

		private void OnShowHeatmap(HeatmapType obj)
		{
			if (ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer != null && ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer.IsValid() && MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.DisplayHeatmap(HeatmapType.Temperature, ComputeDataProcessor<TemperatureOutputStruct>.outputBuffer, isInputBuffer3D: true, -50f, 50f, gradientTexture);
			}
		}

		public static List<float> CreateRaycastDirections()
		{
			List<float> list = new List<float>();
			float num = 0f;
			bool flag = true;
			for (int i = 1; (float)i <= 5f; i++)
			{
				int num2 = (int)((float)i / 5f * 28f);
				for (int j = 0; j < num2; j++)
				{
					float f = MathF.PI * 2f * (float)j / (float)num2;
					num = Mathf.Sin(MathF.PI / 2f * (float)i / 5f) * 10f;
					float num3 = Mathf.Sin(f) * num;
					float num4 = Mathf.Cos(f) * num;
					float num5 = Mathf.Cos(MathF.PI / 2f * (float)i / 5f) * 10f;
					list.Add(num3);
					list.Add(num5);
					list.Add(num4);
					if (flag && Mathf.Approximately(num3, 0f) && Mathf.Approximately(num4, 0f) && Mathf.Approximately(num5, 1f))
					{
						flag = false;
					}
				}
			}
			if (!flag)
			{
				list.Add(0f);
				list.Add(1f);
				list.Add(0f);
			}
			return list;
		}
	}
}
