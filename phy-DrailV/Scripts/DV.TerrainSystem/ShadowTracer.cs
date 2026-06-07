using System;
using DV.Utils;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class ShadowTracer : SingletonBehaviour<ShadowTracer>
{
	private enum UpdateMode
	{
		Full = 0,
		RoundRobinPartial = 1,
		AroundCamera = 2
	}

	public const string DV_LONG_SHADOWS = "DV_LONG_SHADOWS";

	public Vector3 worldSize = new Vector3(16384f, 16384f, 1000f);

	public Texture2D worldHeightmap;

	public Texture2D worldHeightmapDS128;

	public Texture3D worldDistanceField;

	public Vector4 worldDistanceFieldParams;

	public RenderTexture output;

	public RenderTexture backBuffer;

	public RenderTexture intermediate;

	public Light sunLight;

	public Material renderingMaterial;

	public Material aoMaterial;

	public ComputeShader raymarchShader;

	private Camera lastCamera;

	private CommandBuffer shadowBuff;

	private CommandBuffer aoBuff;

	private Camera aoAttached;

	private CommandBuffer asyncBuffer;

	private int[] offsetArray = new int[2];

	private const int CHUNKS = 4;

	private int chunkRobin;

	private bool shadowTracingEnabled;

	private bool worldAOEnabled;

	private const LightEvent SHADOWS_EVENT = LightEvent.AfterScreenspaceMask;

	private const CameraEvent AO_EVENT = CameraEvent.BeforeReflections;

	private static readonly RenderTargetIdentifier[] GBufferTargetsNonVR = new RenderTargetIdentifier[2]
	{
		BuiltinRenderTextureType.GBuffer0,
		BuiltinRenderTextureType.CameraTarget
	};

	private static readonly RenderTargetIdentifier[] GBufferTargetsVR = new RenderTargetIdentifier[2]
	{
		BuiltinRenderTextureType.GBuffer0,
		BuiltinRenderTextureType.GBuffer3
	};

	protected virtual Vector3 WorldOffset => Vector3.zero;

	protected virtual Camera CurrentlyActiveCamera => Camera.main;

	public bool ShadowTracing
	{
		get
		{
			return shadowTracingEnabled;
		}
		set
		{
			if (value && !shadowTracingEnabled)
			{
				AttachShadowRendererTo(CurrentlyActiveCamera);
			}
			else if (!value && shadowTracingEnabled)
			{
				RemoveShadowRendererFrom(CurrentlyActiveCamera);
			}
		}
	}

	public bool AORenderer
	{
		get
		{
			return worldAOEnabled;
		}
		set
		{
			if (value && !worldAOEnabled)
			{
				AttachAORendererTo(CurrentlyActiveCamera);
			}
			else if (!value && worldAOEnabled)
			{
				RemoveAORendererFrom(CurrentlyActiveCamera);
			}
		}
	}

	public new static string AllowAutoCreate()
	{
		return null;
	}

	[ContextMenu("Async render now!")]
	public void RenderAsync()
	{
		DispatchRaymarch(UpdateMode.Full);
	}

	private void OnEnable()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(PreRender));
	}

	private void PreRender(Camera camera)
	{
		if (camera.enabled && camera.actualRenderingPath == RenderingPath.DeferredShading && camera.cameraType == CameraType.Game)
		{
			if (camera != lastCamera)
			{
				ChangeCameraTo(camera);
			}
			if (worldAOEnabled)
			{
				aoBuff.Clear();
				aoBuff.SetRenderTarget((XRSettings.enabled && camera.stereoEnabled) ? GBufferTargetsVR : GBufferTargetsNonVR, BuiltinRenderTextureType.CameraTarget);
				StereoPostProcUtility.RenderFullscreenEffect(aoBuff, camera, aoMaterial, null, (!camera.allowHDR) ? 1 : 0);
			}
			if (shadowTracingEnabled)
			{
				shadowBuff.Clear();
				shadowBuff.SetRenderTarget(BuiltinRenderTextureType.CurrentActive);
				shadowBuff.SetGlobalVector("_WorldSize", worldSize);
				StereoPostProcUtility.RenderFullscreenEffect(shadowBuff, camera, renderingMaterial, sunLight);
			}
		}
	}

	private void DispatchRaymarch(UpdateMode mode)
	{
		if (worldHeightmap == null)
		{
			Debug.LogError("No heightmap assigned! Aborting!");
			return;
		}
		if (sunLight == null)
		{
			Debug.LogError("Sun light not attached! Aborting!");
			return;
		}
		if (output == null)
		{
			Debug.Log("Auto-creating output render texture...");
			output = new RenderTexture(worldHeightmap.width, worldHeightmap.height, 0, GraphicsFormat.R32G32_SFloat);
			output.enableRandomWrite = true;
			output.Create();
		}
		if (SystemInfo.supportsAsyncCompute && backBuffer == null)
		{
			Debug.Log("Auto-creating output back buffer texture...");
			backBuffer = new RenderTexture(worldHeightmap.width, worldHeightmap.height, 0, GraphicsFormat.R32G32_SFloat);
			backBuffer.enableRandomWrite = true;
			backBuffer.Create();
		}
		if (asyncBuffer == null)
		{
			asyncBuffer = new CommandBuffer();
		}
		else
		{
			asyncBuffer.Clear();
		}
		asyncBuffer.name = "Terrain shadow raymarcher";
		if (mode != UpdateMode.AroundCamera || !(Camera.main == null))
		{
			switch (mode)
			{
			case UpdateMode.RoundRobinPartial:
			{
				int num5 = output.width / 4;
				int num6 = output.height / 4;
				offsetArray[0] = chunkRobin % 4 * num5;
				offsetArray[1] = chunkRobin / 4 * num6;
				asyncBuffer.SetComputeIntParams(raymarchShader, "StartOffset", offsetArray);
				chunkRobin = (chunkRobin + 1) % 16;
				break;
			}
			case UpdateMode.AroundCamera:
			{
				int num = output.width / 4;
				int num2 = output.height / 4;
				Vector3 vector = Camera.main.transform.position - WorldOffset;
				int num3 = Mathf.FloorToInt(vector.x / worldSize.x * (float)output.width);
				int num4 = Mathf.FloorToInt(vector.z / worldSize.y * (float)output.height);
				offsetArray[0] = Mathf.Clamp(num3 - num / 2, 0, output.width - num - 1);
				offsetArray[1] = Mathf.Clamp(num4 - num2 / 2, 0, output.height - num2 - 1);
				asyncBuffer.SetComputeIntParams(raymarchShader, "StartOffset", offsetArray);
				break;
			}
			default:
				offsetArray[0] = (offsetArray[1] = 0);
				asyncBuffer.SetComputeIntParams(raymarchShader, "StartOffset", offsetArray);
				break;
			}
			asyncBuffer.SetComputeVectorParam(raymarchShader, "TextureSize", new Vector4(worldHeightmap.width, worldHeightmap.height, 0f, 0f));
			asyncBuffer.SetComputeVectorParam(raymarchShader, "WorldSize", worldSize);
			asyncBuffer.SetComputeVectorParam(raymarchShader, "LightVector", sunLight.transform.forward);
			asyncBuffer.SetComputeTextureParam(raymarchShader, 0, "Heightmap", worldHeightmap, 0);
			asyncBuffer.SetComputeTextureParam(raymarchShader, 0, "HeightmapDS128", worldHeightmapDS128, 0);
			asyncBuffer.SetComputeTextureParam(raymarchShader, 0, "DistanceField", worldDistanceField, 0);
			asyncBuffer.SetComputeVectorParam(raymarchShader, "DistanceFieldParams", worldDistanceFieldParams);
			if (SystemInfo.supportsAsyncCompute)
			{
				asyncBuffer.SetComputeTextureParam(raymarchShader, 0, "Result", backBuffer, 0);
			}
			else
			{
				asyncBuffer.SetComputeTextureParam(raymarchShader, 0, "Result", output, 0);
			}
			asyncBuffer.BeginSample("Terrain shadow raymarching");
			if (mode != UpdateMode.Full)
			{
				asyncBuffer.DispatchCompute(raymarchShader, 0, worldHeightmap.width / 8 / 4, worldHeightmap.height / 8 / 4, 1);
			}
			else
			{
				asyncBuffer.DispatchCompute(raymarchShader, 0, worldHeightmap.width / 8, worldHeightmap.height / 8, 1);
			}
			asyncBuffer.EndSample("Terrain shadow raymarching");
			if (SystemInfo.supportsAsyncCompute)
			{
				asyncBuffer.CopyTexture(backBuffer, output);
			}
			asyncBuffer.SetGlobalTexture("_WorldHeightmap", worldHeightmap);
			asyncBuffer.SetGlobalTexture("_ShadowHeightmap", output);
			asyncBuffer.SetGlobalVector("_WorldSize", worldSize);
			if (SystemInfo.supportsAsyncCompute)
			{
				Graphics.ExecuteCommandBufferAsync(asyncBuffer, ComputeQueueType.Background);
			}
			else
			{
				Graphics.ExecuteCommandBuffer(asyncBuffer);
			}
		}
	}

	private void Update()
	{
		if (shadowTracingEnabled)
		{
			DispatchRaymarch(UpdateMode.RoundRobinPartial);
			DispatchRaymarch(UpdateMode.AroundCamera);
		}
		if (shadowTracingEnabled || worldAOEnabled)
		{
			Camera main = Camera.main;
			if (main != null && main != lastCamera && main.cameraType == CameraType.Game)
			{
				ChangeCameraTo(main);
			}
		}
		else
		{
			ChangeCameraTo(null);
		}
	}

	protected void ChangeCameraTo(Camera newCamera)
	{
		if (newCamera != null && newCamera != lastCamera && newCamera.cameraType == CameraType.Game)
		{
			bool num = worldAOEnabled;
			bool flag = shadowTracingEnabled;
			if ((bool)aoAttached)
			{
				RemoveAORendererFrom(aoAttached);
				aoAttached = null;
			}
			if (shadowTracingEnabled)
			{
				RemoveShadowRendererFrom(lastCamera);
			}
			lastCamera = newCamera;
			if (num)
			{
				AttachAORendererTo(newCamera);
			}
			if (flag)
			{
				AttachShadowRendererTo(newCamera);
			}
		}
		else if (newCamera == null && lastCamera != null)
		{
			lastCamera = null;
		}
	}

	private void AttachAORendererTo(Camera cam)
	{
		if ((bool)aoAttached)
		{
			RemoveAORendererFrom(aoAttached);
			aoAttached = null;
		}
		if (aoMaterial == null)
		{
			Debug.LogError("No rendering material is attached, aborting");
			return;
		}
		StereoPostProcUtility.InitializeAssets();
		if (lastCamera == null || lastCamera != cam)
		{
			ChangeCameraTo(cam);
		}
		aoBuff = new CommandBuffer();
		aoBuff.name = "AOPass";
		cam.AddCommandBuffer(CameraEvent.BeforeReflections, aoBuff);
		aoAttached = cam;
		worldAOEnabled = true;
	}

	private void RemoveAORendererFrom(Camera cam)
	{
		if (aoBuff != null && aoAttached == cam)
		{
			if (cam != null)
			{
				cam.RemoveCommandBuffer(CameraEvent.BeforeReflections, aoBuff);
			}
			aoBuff.Release();
			aoBuff = null;
			aoAttached = null;
			worldAOEnabled = false;
		}
	}

	private void AttachShadowRendererTo(Camera cam)
	{
		if (shadowBuff != null)
		{
			sunLight.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, shadowBuff);
			shadowBuff.Release();
			shadowBuff = null;
		}
		if (renderingMaterial == null)
		{
			Debug.LogError("No rendering material is attached, aborting");
			return;
		}
		if (sunLight == null)
		{
			Debug.LogError("No primary light is attached, aborting");
			return;
		}
		StereoPostProcUtility.InitializeAssets();
		renderingMaterial.mainTexture = output;
		shadowBuff = new CommandBuffer();
		shadowBuff.name = "TerrainShadow";
		sunLight.AddCommandBuffer(LightEvent.AfterScreenspaceMask, shadowBuff);
		Shader.EnableKeyword("DV_LONG_SHADOWS");
		shadowTracingEnabled = true;
		if (lastCamera == null || lastCamera != cam)
		{
			ChangeCameraTo(cam);
		}
	}

	private void RemoveShadowRendererFrom(Camera cam)
	{
		if (shadowBuff != null)
		{
			if (sunLight != null)
			{
				sunLight.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, shadowBuff);
			}
			shadowTracingEnabled = false;
			shadowBuff.Release();
			shadowBuff = null;
			Shader.DisableKeyword("DV_LONG_SHADOWS");
		}
	}

	private void OnDisable()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(PreRender));
		ShadowTracing = false;
		AORenderer = false;
		if ((bool)output)
		{
			output.Release();
			UnityEngine.Object.Destroy(output);
		}
		if ((bool)intermediate)
		{
			intermediate.Release();
			UnityEngine.Object.Destroy(intermediate);
		}
		output = null;
		intermediate = null;
	}
}
