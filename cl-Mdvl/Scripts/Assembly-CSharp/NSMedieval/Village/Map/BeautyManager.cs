using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Fire;
using NSMedieval.RoomDetection;
using NSMedieval.State.Timers;
using NSMedieval.Tools;
using NSMedieval.Types;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Village.Map
{
	public class BeautyManager : ComputeDataProcessor<float>
	{
		private const float GradientMinValue = -2f;

		private const float GradientMaxValue = 2f;

		private const int BlurSize = 19;

		private static ComputeBuffer combinedBuffer;

		private static ComputeBuffer indicesBuffer;

		private static NativeArray<int> combinedDataNative;

		private VillageMap map;

		private Texture2D gradientTexture;

		private ComputeBuffer blurKernelBuffer;

		private List<float> blurKernelData;

		private HashSet<int> walkableNodeIndices;

		private readonly object walkableNodeIndicesLock = new object();

		private bool walkableIndicesModified;

		private List<int> walkableNodeIndicesList;

		private bool isMapLoaded;

		protected override string ShaderPath => "Shaders/Compute/BeautyComputeShader";

		public Texture2D GradientTexture => gradientTexture;

		public string GradientMinText => (-2f).ToString(CultureInfo.InvariantCulture);

		public string GradientMaxText => 2f.ToString(CultureInfo.InvariantCulture);

		public string GradientCenterText => string.Empty;

		public ComputeBuffer IndicesBuffer => indicesBuffer;

		public int WalkableNodeIndicesCount
		{
			get
			{
				lock (walkableNodeIndicesLock)
				{
					return walkableNodeIndices.Count;
				}
			}
		}

		public static void InitStaticArrays()
		{
			combinedDataNative = ArrayStorage.GetNativeArray<int>("BeautyManager.combinedDataNative", GridDataIndexTools.MaxDataLength);
			ComputeDataProcessor<float>.outputBuffer = ArrayStorage.GetComputeBuffer("BeautyManager.outputBuffer", GridDataIndexTools.MaxDataLength, 4);
			combinedBuffer = ArrayStorage.GetComputeBuffer("BeautyManager.combinedBuffer", GridDataIndexTools.MaxDataLength, 4);
			indicesBuffer = ArrayStorage.GetComputeBuffer("BeautyManager.indicesBuffer", GridDataIndexTools.MaxDataLength, 4);
			ComputeDataProcessor<float>.outputData = ArrayStorage.GetArray<float>("BeautyManager.outputData", GridDataIndexTools.MaxDataLength);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(combinedDataNative);
			Array.Clear(ComputeDataProcessor<float>.outputData, 0, base.ArraySize);
		}

		public void WalkableIndicesSafeOperation(Action<IEnumerable<int>> operation)
		{
			lock (walkableNodeIndicesLock)
			{
				operation?.Invoke(walkableNodeIndices);
			}
		}

		public void Initialize(VillageMap villageMap)
		{
			walkableNodeIndices = new HashSet<int>();
			walkableNodeIndicesList = new List<int>();
			map = villageMap;
			TimerDispatch = new UnscaledTimer(DelayBeforeDispatch, restartOnEnd: false);
			TickTimer = new UnscaledTimer(0.05f, restartOnEnd: true);
			InitMapSize(villageMap.Size);
			InitStaticArrays();
			ClearStaticArrays();
			Initialize();
			combinedBuffer.SetData(combinedDataNative, 0, 0, base.ArraySize);
			base.ComputeShader.SetBuffer(base.KernelIndex, "combinedBuffer", combinedBuffer);
			base.ComputeShader.SetBuffer(base.KernelIndex, "indicesBuffer", indicesBuffer);
			blurKernelData = ComputeDataProcessor<float>.CreateBlurKernel(19);
			blurKernelBuffer = new ComputeBuffer(blurKernelData.Count, 4);
			blurKernelBuffer.SetData(blurKernelData);
			base.ComputeShader.SetBuffer(base.KernelIndex, "blurKernel", blurKernelBuffer);
			base.ComputeShader.SetInt("blurKernelSize", blurKernelData.Count / 3);
			gradientTexture = UnityEngine.Resources.Load<Texture2D>("Textures/HeatmapGradient");
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
			MonoSingleton<VisualHeatmapManager>.Instance.OnShowHeatmap += OnShowHeatmap;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
			DispatchScheduled = false;
			TimerDispatch.Pause();
			TickTimer.Pause();
		}

		protected override void ReloadShader()
		{
			base.ReloadShader();
			base.ComputeShader.SetBuffer(base.KernelIndex, "combinedBuffer", combinedBuffer);
			base.ComputeShader.SetBuffer(base.KernelIndex, "indicesBuffer", indicesBuffer);
			base.ComputeShader.SetBuffer(base.KernelIndex, "blurKernel", blurKernelBuffer);
			base.ComputeShader.SetInt("blurKernelSize", blurKernelData.Count / 3);
		}

		public void FillIndicesBuffer()
		{
			if (!walkableIndicesModified)
			{
				return;
			}
			walkableIndicesModified = false;
			lock (walkableNodeIndicesLock)
			{
				indicesBuffer.SetData(walkableNodeIndicesList, 0, 0, walkableNodeIndices.Count);
			}
		}

		private void OnLoadingComplete()
		{
			InitWalkability();
			isMapLoaded = true;
			DispatchScheduled = true;
			map.NodeWalkabilityChangedEvent += OnNodeWalkabilityChanged;
			map.ObjectPlacedEvent += ObjectPlacedRemoved;
			map.ObjectRemovedEvent += ObjectPlacedRemoved;
			map.NodeGridDataTypeChangedEvent += OnNodeDataTypeChanged;
			TickTimer.Resume();
			TimerDispatch.Resume();
		}

		private void ObjectPlacedRemoved(WorldObject obj)
		{
			if (obj.Positions == null)
			{
				OnNodeWalkabilityChanged(obj.GetNode());
				return;
			}
			VillageMap villageMap = obj.Map;
			foreach (Vec3Int position in obj.Positions)
			{
				MapNode node = villageMap.GetNode(position);
				OnNodeWalkabilityChanged(node);
			}
		}

		private void InitWalkability()
		{
			lock (walkableNodeIndicesLock)
			{
				walkableNodeIndices.Clear();
				walkableNodeIndicesList.Clear();
				MapNode[] gridSpaceData = map.GridSpaceData;
				foreach (MapNode mapNode in gridSpaceData)
				{
					if (ShouldBeInNodesList(mapNode) && walkableNodeIndices.Add(mapNode.Index))
					{
						walkableNodeIndicesList.Add(mapNode.Index);
					}
				}
			}
			walkableIndicesModified = true;
			FillIndicesBuffer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldBeInNodesList(MapNode node)
		{
			if (node != null)
			{
				if (!node.IsWalkable && (node.Tag & MapNodeTags.Wall) == 0)
				{
					return (node.DataType & (GridDataType.SlopeOrStairs | GridDataType.Roof)) != 0;
				}
				return true;
			}
			return false;
		}

		private void OnNodeWalkabilityChanged(MapNode node)
		{
			if (node == null)
			{
				return;
			}
			bool flag = ShouldBeInNodesList(node);
			lock (walkableNodeIndicesLock)
			{
				if (flag && walkableNodeIndices.Add(node.Index))
				{
					walkableIndicesModified = true;
					walkableNodeIndicesList.Add(node.Index);
				}
				else if (!flag && walkableNodeIndices.Remove(node.Index))
				{
					walkableIndicesModified = true;
					walkableNodeIndicesList.Remove(node.Index);
				}
			}
		}

		public void SetCombinedBufferData(MapNode node, bool isBlocker, float beauty)
		{
			if (node == null)
			{
				return;
			}
			if (node.Index < 0 || node.Index >= base.ArraySize)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\BeautyManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Node index ");
					messageBuilder.AppendFormatted(node.Index);
					messageBuilder.AppendLiteral(" is out of range (");
					messageBuilder.AppendFormatted(base.ArraySize);
					messageBuilder.AppendLiteral(" max)");
				}
				Log.Warning(messageBuilder);
				return;
			}
			int num = combinedDataNative[node.Index];
			int num2 = (isBlocker ? 1 : 0);
			if (!isBlocker)
			{
				num2 = (int)(beauty * 100f) + (int)(Mathf.Sign(beauty) * 2f);
			}
			if (num == num2)
			{
				return;
			}
			combinedDataNative[node.Index] = num2;
			if (isMapLoaded)
			{
				DispatchScheduled = true;
				if (isBlocker || num == 1)
				{
					OnNodeWalkabilityChanged(node);
				}
			}
		}

		private int GetCombinedBufferData(Vec3Int gridPosition)
		{
			return GetData(ref combinedDataNative, gridPosition.x, gridPosition.y, gridPosition.z);
		}

		public float GetBeautyInput(Vec3Int gridPosition)
		{
			int combinedBufferData = GetCombinedBufferData(gridPosition);
			if (combinedBufferData == 1)
			{
				return 0f;
			}
			return ((float)combinedBufferData - Mathf.Sign(combinedBufferData) * 2f) / 100f;
		}

		public override void Dispose()
		{
			base.Dispose();
			blurKernelBuffer?.Dispose();
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
			}
			if (MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.OnShowHeatmap -= OnShowHeatmap;
			}
			if (map != null)
			{
				map.NodeWalkabilityChangedEvent -= OnNodeWalkabilityChanged;
				map.ObjectPlacedEvent -= ObjectPlacedRemoved;
				map.ObjectRemovedEvent -= ObjectPlacedRemoved;
				map.NodeGridDataTypeChangedEvent -= OnNodeDataTypeChanged;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			map = null;
			gradientTexture = null;
			blurKernelData?.Clear();
			blurKernelData = null;
			walkableNodeIndices?.Clear();
			walkableNodeIndices = null;
			blurKernelBuffer = null;
		}

		private void OnNodeDataTypeChanged(MapNode node, GridDataType oldDataType)
		{
			OnNodeWalkabilityChanged(node);
		}

		public override void DrawGizmos()
		{
		}

		public float GetBeauty(Vec3Int position)
		{
			return GetOutputData(position.x, position.y, position.z);
		}

		public float GetBeauty(int x, int y, int z)
		{
			return GetOutputData(x, y, z);
		}

		protected override void PrepareCommandBuffer(ref CommandBuffer commandBuffer)
		{
			int num = 0;
			lock (walkableNodeIndicesLock)
			{
				num = Mathf.CeilToInt((float)walkableNodeIndices.Count / (float)(ThreadGroupX * 2));
				int num2 = (int)ThreadGroupX * num;
				int num3 = CurrentIteration * num2;
				num = Math.Min(num, Mathf.CeilToInt((float)(walkableNodeIndices.Count - num3) / (float)ThreadGroupX));
				if (num == 0)
				{
					return;
				}
				base.ComputeShader.SetInt("indexOffset", CurrentIteration * (walkableNodeIndices.Count / 2));
			}
			FillIndicesBuffer();
			base.ComputeShader.SetBuffer(base.KernelIndex, "indicesBuffer", indicesBuffer);
			commandBuffer.Clear();
			commandBuffer.SetBufferData(combinedBuffer, combinedDataNative, 0, 0, base.ArraySize);
			commandBuffer.BeginSample("*** CB Dispatch " + commandBuffer.name);
			commandBuffer.DispatchCompute(base.ComputeShader, base.KernelIndex, num, 1, 1);
			commandBuffer.RequestAsyncReadback(ComputeDataProcessor<float>.outputBuffer, base.ComputeShaderCallback);
			commandBuffer.EndSample("*** CB Dispatch " + commandBuffer.name);
		}

		protected override void OnOutputDataRetrieved()
		{
			if (!MonoSingleton<LoadingController>.IsApplicationIsQuitting() && !LoadingController.IsLeavingMainScene && ComputeDataProcessor<float>.outputBuffer != null && ComputeDataProcessor<float>.outputBuffer.IsValid() && MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.DisplayHeatmap(HeatmapType.Beauty, ComputeDataProcessor<float>.outputBuffer, isInputBuffer3D: false, -2f, 2f, gradientTexture);
			}
		}

		private void OnShowHeatmap(HeatmapType obj)
		{
			if (ComputeDataProcessor<float>.outputBuffer != null && ComputeDataProcessor<float>.outputBuffer.IsValid() && MonoSingleton<VisualHeatmapManager>.IsInstantiated())
			{
				MonoSingleton<VisualHeatmapManager>.Instance.DisplayHeatmap(HeatmapType.Beauty, ComputeDataProcessor<float>.outputBuffer, isInputBuffer3D: false, -2f, 2f, gradientTexture);
			}
		}

		private static void RefreshRoomBeautyInput(Room room)
		{
			foreach (MapNode allNode in room.AllNodes)
			{
				if (allNode != null && (allNode.DataType & (GridDataType.ResourcePile | GridDataType.Furniture)) != GridDataType.None)
				{
					allNode.ForceRefreshBeautyInput();
				}
			}
		}

		private void OnRoomAdded(Room room, RoomType previousType)
		{
			RefreshRoomBeautyInput(room);
		}

		private void OnRoomRemoved(Room room)
		{
			RefreshRoomBeautyInput(room);
		}
	}
}
