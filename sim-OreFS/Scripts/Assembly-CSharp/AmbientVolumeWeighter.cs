using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[DisallowMultipleComponent]
public class AmbientVolumeWeighter : MonoBehaviour
{
	public Volume targetVolume;

	[Header("Sampling")]
	[Min(0.02f)]
	public float sampleInterval = 0.5f;

	[Range(0f, 1f)]
	public float temporalSmoothing = 0.2f;

	[Range(0f, 10f)]
	public float weightLerpSpeed = 3f;

	[Header("Luminance Range")]
	public float darkLuminance = 0.03f;

	public float brightLuminance = 1f;

	[Header("Flashlight Control")]
	[Range(0f, 1f)]
	public float flashlightThreshold = 0.7f;

	public Light flashlightLight;

	public UnityEvent FlashlightOnEvent;

	public UnityEvent FlashlightOffEvent;

	[Header("Underground Settings")]
	public float undergroundYThreshold;

	public float undergroundYOffset = -2f;

	public bool instantResetAboveGround = true;

	[Header("Probe Mode")]
	[Tooltip("true = Cubemap probe (Digger mesh'lerde crash yapabilir), false = Raycast fallback")]
	public bool useCubemapProbe;

	[Header("Cubemap Probe Settings")]
	[Range(4f, 64f)]
	public int cubemapSize = 16;

	public LayerMask probeCullingMask = -1;

	public float probeFarClip = 50f;

	[Header("Raycast Fallback Settings")]
	[Tooltip("Ray mesafesi")]
	public float raycastMaxDistance = 50f;

	[Tooltip("Raycast layer mask (terrain + digger mesh)")]
	public LayerMask raycastLayerMask = -1;

	private float lastSampleTime;

	private float smoothedLum;

	private float currentWeight;

	private bool flashlightOn;

	private Camera probeCamera;

	private RenderTexture probeCubemap;

	private Texture2D readbackTex;

	private const float Lr = 0.2126f;

	private const float Lg = 0.7152f;

	private const float Lb = 0.0722f;

	private void Update()
	{
		if (!targetVolume)
		{
			return;
		}
		float num = undergroundYThreshold + undergroundYOffset;
		if (!(base.transform.position.y < num))
		{
			if (instantResetAboveGround)
			{
				currentWeight = 0f;
			}
			else
			{
				currentWeight = Mathf.Lerp(currentWeight, 0f, 1f - Mathf.Exp((0f - weightLerpSpeed) * Time.deltaTime));
			}
			targetVolume.weight = currentWeight;
			if (flashlightOn && currentWeight < flashlightThreshold)
			{
				flashlightOn = false;
				FlashlightOffEvent?.Invoke();
			}
			SampleLuminance();
			return;
		}
		SampleLuminance();
		float value = Mathf.InverseLerp(darkLuminance, brightLuminance, smoothedLum);
		float b = 1f - Mathf.Clamp01(value);
		currentWeight = Mathf.Lerp(currentWeight, b, 1f - Mathf.Exp((0f - weightLerpSpeed) * Time.deltaTime));
		targetVolume.weight = currentWeight;
		if (!flashlightOn && currentWeight >= flashlightThreshold)
		{
			flashlightOn = true;
			FlashlightOnEvent?.Invoke();
		}
		else if (flashlightOn && currentWeight < flashlightThreshold)
		{
			flashlightOn = false;
			FlashlightOffEvent?.Invoke();
		}
	}

	private void SampleLuminance()
	{
		if (!(Time.unscaledTime - lastSampleTime < sampleInterval))
		{
			lastSampleTime = Time.unscaledTime;
			if (useCubemapProbe)
			{
				SampleCubemapProbe();
			}
			else
			{
				SampleOcclusionRaycast();
			}
		}
	}

	private void SampleOcclusionRaycast()
	{
		float b = (Physics.Raycast(base.transform.position, Vector3.up, raycastMaxDistance, raycastLayerMask, QueryTriggerInteraction.Ignore) ? darkLuminance : brightLuminance);
		float t = 1f - Mathf.Pow(1f - temporalSmoothing, Time.unscaledDeltaTime * 60f);
		smoothedLum = Mathf.Lerp(smoothedLum, b, t);
	}

	private void SampleCubemapProbe()
	{
		EnsureProbeCameraAndCubemap();
		probeCamera.transform.position = base.transform.position;
		int num;
		if ((bool)flashlightLight)
		{
			num = (flashlightLight.enabled ? 1 : 0);
			if (num != 0)
			{
				flashlightLight.enabled = false;
			}
		}
		else
		{
			num = 0;
		}
		probeCamera.RenderToCubemap(probeCubemap);
		if (num != 0)
		{
			flashlightLight.enabled = true;
		}
		float num2 = SampleCubeAverageLuminance(probeCubemap);
		if (!float.IsNaN(num2) && !float.IsInfinity(num2))
		{
			float t = 1f - Mathf.Pow(1f - temporalSmoothing, Time.unscaledDeltaTime * 60f);
			smoothedLum = Mathf.Lerp(smoothedLum, num2, t);
		}
	}

	private void EnsureProbeCameraAndCubemap()
	{
		if (!useCubemapProbe)
		{
			return;
		}
		if (probeCubemap == null || probeCubemap.width != cubemapSize)
		{
			if ((bool)probeCubemap)
			{
				probeCubemap.Release();
			}
			probeCubemap = new RenderTexture(cubemapSize, cubemapSize, 16, RenderTextureFormat.ARGBHalf);
			probeCubemap.dimension = TextureDimension.Cube;
			probeCubemap.useMipMap = false;
			probeCubemap.Create();
		}
		if (probeCamera == null)
		{
			GameObject gameObject = new GameObject("_AmbientProbeCamera");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			probeCamera = gameObject.AddComponent<Camera>();
			probeCamera.enabled = false;
			probeCamera.nearClipPlane = 0.1f;
			probeCamera.clearFlags = CameraClearFlags.Skybox;
			probeCamera.allowHDR = true;
			UniversalAdditionalCameraData universalAdditionalCameraData = probeCamera.GetUniversalAdditionalCameraData();
			if ((bool)universalAdditionalCameraData)
			{
				universalAdditionalCameraData.SetRenderer(0);
				universalAdditionalCameraData.renderPostProcessing = false;
				universalAdditionalCameraData.renderShadows = false;
			}
		}
		probeCamera.farClipPlane = probeFarClip;
		probeCamera.cullingMask = probeCullingMask;
	}

	private float SampleCubeAverageLuminance(RenderTexture cube)
	{
		int width = cube.width;
		EnsureReadbackTex(width, width);
		RenderTexture active = RenderTexture.active;
		float num = 0f;
		for (int i = 0; i < 6; i++)
		{
			Graphics.SetRenderTarget(cube, 0, (CubemapFace)i);
			readbackTex.ReadPixels(new Rect(0f, 0f, width, width), 0, 0, recalculateMipMaps: false);
			readbackTex.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			Color[] pixels = readbackTex.GetPixels();
			double num2 = 0.0;
			int num3 = pixels.Length;
			for (int j = 0; j < num3; j++)
			{
				Color color = pixels[j];
				float num4 = color.r * 0.2126f + color.g * 0.7152f + color.b * 0.0722f;
				if (!float.IsNaN(num4) && !float.IsInfinity(num4))
				{
					num2 += (double)num4;
				}
			}
			num += (float)(num2 / (double)Math.Max(1, num3));
		}
		RenderTexture.active = active;
		return num / 6f;
	}

	private void EnsureReadbackTex(int w, int h)
	{
		if (readbackTex == null)
		{
			readbackTex = new Texture2D(w, h, TextureFormat.RGBAHalf, mipChain: false, linear: true);
		}
		else if (readbackTex.width != w || readbackTex.height != h)
		{
			readbackTex.Reinitialize(w, h, TextureFormat.RGBAHalf, hasMipMap: false);
		}
	}

	private void OnDestroy()
	{
		if ((bool)readbackTex)
		{
			UnityEngine.Object.Destroy(readbackTex);
		}
		if ((bool)probeCubemap)
		{
			probeCubemap.Release();
			UnityEngine.Object.Destroy(probeCubemap);
		}
		if ((bool)probeCamera)
		{
			UnityEngine.Object.Destroy(probeCamera.gameObject);
		}
	}
}
