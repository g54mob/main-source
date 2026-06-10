using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State.Timers;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Village.Map
{
	public class ComputeDataProcessor<TD> : IDisposable where TD : struct
	{
		protected const int DivideIntoIterations = 2;

		protected static ComputeBuffer outputBuffer;

		protected int CurrentIteration;

		protected bool DispatchScheduled;

		private ComputeShader computeShader;

		protected static TD[] outputData;

		private object outputDataLock = new object();

		protected int MapSizeX;

		protected int MapSizeY;

		protected int MapSizeZ;

		private int arraySize;

		private bool outputRetrieved = true;

		private CommandBuffer commandBuffer;

		private int kernelIndex;

		protected uint ThreadGroupX;

		protected uint ThreadGroupY;

		protected uint ThreadGroupZ;

		protected BaseTimer TimerDispatch;

		protected BaseTimer TickTimer;

		protected virtual string ShaderPath => "";

		protected virtual float DelayBeforeDispatch => 0.1f;

		protected ComputeShader ComputeShader => computeShader;

		protected int KernelIndex => kernelIndex;

		protected bool OutputRetrieved => outputRetrieved;

		protected int ArraySize => arraySize;

		public event Action OnOutputRetrieved;

		public virtual void Dispose()
		{
			TickTimer?.Dispose();
			TickTimer = null;
			TimerDispatch?.Dispose();
			TimerDispatch = null;
			commandBuffer.Clear();
			commandBuffer?.Dispose();
			commandBuffer = null;
			computeShader = null;
			this.OnOutputRetrieved = null;
		}

		public virtual void DrawGizmos()
		{
		}

		protected virtual void LoadShader()
		{
			computeShader = UnityEngine.Resources.Load<ComputeShader>(ShaderPath);
			kernelIndex = computeShader.FindKernel("CSMain");
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ComputeDataProcessor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("'");
				messageBuilder.AppendFormatted(ShaderPath);
				messageBuilder.AppendLiteral("' shader supported: ");
				messageBuilder.AppendFormatted(computeShader.IsSupported(kernelIndex));
			}
			Log.Info(messageBuilder);
			computeShader.GetKernelThreadGroupSizes(kernelIndex, out ThreadGroupX, out ThreadGroupY, out ThreadGroupZ);
			computeShader.SetInts("resolution", MapSizeX, MapSizeY, MapSizeZ);
			computeShader.SetBuffer(kernelIndex, "outputBuffer", outputBuffer);
		}

		protected virtual void ReloadShader()
		{
			LoadShader();
		}

		protected void InitMapSize(Vec3Int mapSize)
		{
			MapSizeX = mapSize.x;
			MapSizeY = mapSize.y;
			MapSizeZ = mapSize.z;
			arraySize = MapSizeX * MapSizeY * MapSizeZ;
		}

		protected void Initialize()
		{
			LoadShader();
			TimerDispatch.AddCallback(DispatchComputeShader);
			TimerDispatch.Pause();
			TickTimer.AddCallback(OnTick);
			commandBuffer = CreateCommandBuffer("CmdBuf-" + GetType().Name);
			outputRetrieved = true;
		}

		private CommandBuffer CreateCommandBuffer(string name)
		{
			return new CommandBuffer
			{
				name = name
			};
		}

		protected virtual void PrepareCommandBuffer(ref CommandBuffer commandBuffer)
		{
		}

		protected virtual void OnOutputDataRetrieved()
		{
			Log.Info("*** Retrieved Output data from shader.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ComputeDataProcessor.cs");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected TD GetOutputData(int x, int y, int z)
		{
			lock (outputDataLock)
			{
				return outputData[GetClampedIndex(x, y, z)];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected TD GetOutputData(int index3d)
		{
			lock (outputDataLock)
			{
				return outputData[index3d];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected T GetData<T>(ref T[] array, int x, int y, int z)
		{
			return array[GetClampedIndex(x, y, z)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected T GetData<T>(ref NativeArray<T> array, int x, int y, int z) where T : struct
		{
			return array[GetClampedIndex(x, y, z)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected T GetData<T>(ref T[] array, int index)
		{
			return array[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void SetData<T>(ref T[] array, int x, int y, int z, T value)
		{
			array[GetClampedIndex(x, y, z)] = value;
		}

		protected int GetClampedIndex(int x, int y, int z)
		{
			return Get1DIndex(Math.Clamp(x, 0, MapSizeX - 1), Math.Clamp(y, 0, MapSizeY - 1), Math.Clamp(z, 0, MapSizeZ - 1));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void SetDataNoClamp<T>(ref T[] array, int x, int y, int z, T value)
		{
			array[Get1DIndex(x, y, z)] = value;
		}

		protected void SafeOutputDataOperation(Action<TD[]> action)
		{
			lock (outputDataLock)
			{
				action?.Invoke(outputData);
			}
		}

		private void DispatchComputeShader()
		{
			if (computeShader == null)
			{
				Log.Info("*** Dispatch: Compute shader is null.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ComputeDataProcessor.cs");
				return;
			}
			CurrentIteration = 0;
			PrepareCommandBuffer(ref commandBuffer);
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		protected void ComputeShaderCallback(AsyncGPUReadbackRequest readbackRequest)
		{
			if (commandBuffer == null || !MonoSingleton<LoadingController>.IsInstantiated() || LoadingController.IsSceneTransition)
			{
				return;
			}
			if (CurrentIteration + 1 < 2)
			{
				CurrentIteration++;
				PrepareCommandBuffer(ref commandBuffer);
				Graphics.ExecuteCommandBuffer(commandBuffer);
				return;
			}
			lock (outputDataLock)
			{
				if (!readbackRequest.hasError)
				{
					NativeArray<TD> data = readbackRequest.GetData<TD>();
					if (outputData != null)
					{
						NativeArray<TD>.Copy(data, outputData, arraySize);
					}
				}
			}
			this.OnOutputRetrieved?.Invoke();
			outputRetrieved = true;
			OnOutputDataRetrieved();
		}

		private void ScheduleDispatch()
		{
			outputRetrieved = false;
			TimerDispatch.RestartTimer();
			if (TimerDispatch.Paused)
			{
				TimerDispatch.Resume();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected int Get1DIndex(int x, int y, int z)
		{
			return x + y * MapSizeX + z * MapSizeX * MapSizeY;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Get3DIndex(int index, out int x, out int y, out int z)
		{
			x = index % MapSizeX;
			y = index / MapSizeX % MapSizeY;
			z = index / (MapSizeX * MapSizeY);
		}

		protected virtual void OnTick()
		{
			if (DispatchScheduled && outputRetrieved)
			{
				DispatchScheduled = false;
				ScheduleDispatch();
			}
		}

		protected static List<float> CreateBlurKernel(int size)
		{
			List<float> list = new List<float>();
			float num = (float)(size - 1) / 2f;
			for (float num2 = 0f - num; num2 <= num; num2 += 1f)
			{
				for (float num3 = 0f - num; num3 <= num; num3 += 1f)
				{
					float num4 = Mathf.Cos(MathF.PI / 2f * Mathf.Clamp01(Mathf.Sqrt(num3 * num3 + num2 * num2) / num));
					if (num4 >= 0.05f)
					{
						list.Add(num3);
						list.Add(num2);
						list.Add(num4);
					}
				}
			}
			return list;
		}

		public static List<float> CreateBlurKernelDithered(int size, float dither1RadiusStart, float dither2RadiusStart)
		{
			List<float> list = new List<float>();
			int num = (int)((float)(size - 1) / 2f);
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					float num2 = Mathf.Clamp01(Mathf.Sqrt(j * j + i * i) / (float)num);
					if ((!(num2 >= dither2RadiusStart) || (j % 2 != 0 && i % 2 != 0)) && (!(num2 > dither1RadiusStart) || !(num2 < dither2RadiusStart) || (j + i) % 2 != 0))
					{
						float num3 = Mathf.Cos(MathF.PI / 2f * num2);
						if (num3 >= 0.05f)
						{
							list.Add(j);
							list.Add(i);
							list.Add(num3);
						}
					}
				}
			}
			return list;
		}
	}
}
