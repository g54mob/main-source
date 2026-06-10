using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class Effects3dTextureManager : IDisposable
	{
		private const string ShaderPath = "Shaders/Compute/GrassToTexture";

		private const int MaxModifiedIndicesCount = 512;

		private readonly List<int> modifiedIndices = new List<int>();

		private VillageMap map;

		private ComputeShader computeShader;

		private ComputeBuffer modifiedIndicesBuffer;

		private BaseTimer dispatchGrassShaderTimer;

		private bool refreshOnlyModifiedGrassNodes;

		private int kernelIndex;

		private uint threadGroupX;

		private uint threadGroupY;

		private uint threadGroupZ;

		public event Action<int, ComputeShader> BeforeDispatch;

		public void Initialize(VillageMap villageMap)
		{
			map = villageMap;
			computeShader = UnityEngine.Resources.Load<ComputeShader>("Shaders/Compute/GrassToTexture");
			kernelIndex = computeShader.FindKernel("CSMain");
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Effects3dTextureManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted("Shaders/Compute/GrassToTexture");
				messageBuilder.AppendLiteral(" shader supported: ");
				messageBuilder.AppendFormatted(computeShader.IsSupported(kernelIndex));
			}
			Log.Info(messageBuilder);
			computeShader.GetKernelThreadGroupSizes(kernelIndex, out threadGroupX, out threadGroupY, out threadGroupZ);
			computeShader.SetInts("resolution", map.Size.x, map.Size.y, map.Size.z);
			dispatchGrassShaderTimer = new UnscaledTimer(0.3f, restartOnEnd: false);
			dispatchGrassShaderTimer.AddCallback(DispatchComputeShader);
			dispatchGrassShaderTimer.Pause();
			modifiedIndicesBuffer = new ComputeBuffer(512, 4);
			modifiedIndicesBuffer.SetData(new int[512]);
			modifiedIndices.Clear();
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
		}

		public void Dispose()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			modifiedIndicesBuffer?.Dispose();
			modifiedIndicesBuffer = null;
			dispatchGrassShaderTimer?.Dispose();
			dispatchGrassShaderTimer = null;
			computeShader = null;
			this.BeforeDispatch = null;
			map = null;
			modifiedIndices.Clear();
		}

		public void AddToModifiedIndices(int index, bool scheduleDispatch)
		{
			modifiedIndices.Add(index);
			if (scheduleDispatch)
			{
				ScheduleDispatchComputeShader(onlyModifiedNodes: true);
			}
		}

		public void ScheduleDispatchComputeShader(bool onlyModifiedNodes = false)
		{
			refreshOnlyModifiedGrassNodes = onlyModifiedNodes;
			if (dispatchGrassShaderTimer.Completed)
			{
				dispatchGrassShaderTimer.RestartTimer();
			}
			if (dispatchGrassShaderTimer.Paused)
			{
				dispatchGrassShaderTimer.Resume();
			}
		}

		private void OnLoadingComplete()
		{
			ScheduleDispatchComputeShader();
		}

		private void DispatchComputeShader()
		{
			int num = (refreshOnlyModifiedGrassNodes ? 512 : map.BeautyManager.WalkableNodeIndicesCount);
			ComputeBuffer buffer = (refreshOnlyModifiedGrassNodes ? modifiedIndicesBuffer : map.BeautyManager.IndicesBuffer);
			if (refreshOnlyModifiedGrassNodes)
			{
				if (modifiedIndices.Count > 512)
				{
					modifiedIndicesBuffer.SetData(modifiedIndices, 0, 0, 512);
					modifiedIndices.RemoveRange(0, 512);
					ScheduleDispatchComputeShader(onlyModifiedNodes: true);
				}
				else
				{
					modifiedIndicesBuffer.SetData(modifiedIndices);
					modifiedIndices.Clear();
				}
			}
			this.BeforeDispatch?.Invoke(kernelIndex, computeShader);
			computeShader.SetBuffer(kernelIndex, "indicesBuffer", buffer);
			computeShader.SetBuffer(kernelIndex, "inputBuffer", map.TemperatureManager.OutputBuffer);
			computeShader.SetTexture(kernelIndex, "outputTexture3D", map.TemperatureManager.Effects3dTexture);
			int threadGroupsX = Mathf.CeilToInt((float)num / (float)threadGroupX);
			computeShader.Dispatch(kernelIndex, threadGroupsX, 1, 1);
		}
	}
}
