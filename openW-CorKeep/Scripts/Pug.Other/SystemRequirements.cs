using System.Collections.Generic;
using UnityEngine;

public static class SystemRequirements
{
	public enum Status
	{
		Unknown = -1,
		Failed = 0,
		Passed = 1
	}

	private const int REQ_GRAPHICS_SHADER_LEVEL = 50;

	private const bool REQ_COMPUTE_SHADERS = true;

	private const bool REQ_CUBEMAP_ARRAY_TEXTURES = true;

	private const bool REQ_INSTANCING = true;

	private const bool REQ_3D_RENDER_TEXTURES = true;

	private const bool REQ_ASYNC_GPU_READBACK = true;

	private const int REQ_RANDOM_WRITE_TARGET_COUNT = 1;

	public static readonly List<string> errors = new List<string>();

	public static Status gpuStatus { get; private set; } = Status.Unknown;

	public static bool Check()
	{
		errors.Clear();
		int num = (int)(1u & (Check(SystemInfo.graphicsShaderLevel, 50, "Shader capability level") ? 1u : 0u) & (Check(SystemInfo.supportsComputeShaders, reqValue: true, "Compute shader support") ? 1u : 0u) & (Check(SystemInfo.supportsCubemapArrayTextures, reqValue: true, "Cubemap array textures support") ? 1u : 0u) & (Check(SystemInfo.supportsInstancing, reqValue: true, "Instancing") ? 1u : 0u) & (Check(SystemInfo.supports3DRenderTextures, reqValue: true, "3D render textures") ? 1u : 0u) & (Check(SystemInfo.supportsAsyncGPUReadback, reqValue: true, "Async GPU readback") ? 1u : 0u)) & (Check(SystemInfo.supportedRandomWriteTargetCount, 1, "Random write target count") ? 1 : 0);
		gpuStatus = ((num != 0) ? Status.Passed : Status.Failed);
		return (byte)num != 0;
	}

	private static bool Check(int value, int reqValue, string failType)
	{
		bool flag = value >= reqValue;
		if (!flag)
		{
			errors.Add("(" + failType + ") System value: " + value + ", Required: " + reqValue);
		}
		return flag;
	}

	private static bool Check(bool value, bool reqValue, string failType)
	{
		bool flag = value == reqValue;
		if (!flag)
		{
			errors.Add("(" + failType + ") System value: " + value + ", Required: " + reqValue);
		}
		return flag;
	}
}
