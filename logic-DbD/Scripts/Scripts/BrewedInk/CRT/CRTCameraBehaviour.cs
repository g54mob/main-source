using System;
using UnityEngine;

namespace BrewedInk.CRT
{
	[RequireComponent(typeof(Camera))]
	[ExecuteAlways]
	public class CRTCameraBehaviour : MonoBehaviour
	{
		[Header("Configuration")]
		public CRTDataObject startConfig;

		public CRTRenderSettingsObject crtRenderSettings;

		[Header("Runtime Data (edit with care!)")]
		public Material _runtimeMaterial;

		public CRTData data;

		private string lastValidationId;

		private static readonly int PropMaxColorsRed = Shader.PropertyToID("_MaxColorsRed");

		private static readonly int PropMaxColorsGreen = Shader.PropertyToID("_MaxColorsGreen");

		private static readonly int PropMaxColorsBlue = Shader.PropertyToID("_MaxColorsBlue");

		private static readonly int PropDitheringAmount = Shader.PropertyToID("_Spread");

		private static readonly int PropDitheringAmount8 = Shader.PropertyToID("_Spread8");

		private static readonly int PropVignette = Shader.PropertyToID("_VigSize");

		private static readonly int PropMonitorRoundness = Shader.PropertyToID("_BorderOutterRound");

		private static readonly int PropMonitorTexture = Shader.PropertyToID("_BorderTex");

		private static readonly int PropMonitorColor = Shader.PropertyToID("_BorderTint");

		private static readonly int PropInnerDarkness = Shader.PropertyToID("_BorderInnerDarkerAmount");

		private static readonly int PropInnerGlow = Shader.PropertyToID("_CrtGlowAmount");

		private static readonly int PropInnerReflectionRadius = Shader.PropertyToID("_CrtReflectionRadius");

		private static readonly int PropInnerReflectionCurve = Shader.PropertyToID("_CrtReflectionCurve");

		private static readonly int PropMonitorCurve = Shader.PropertyToID("_Curvature2");

		private static readonly int PropInnerCurve = Shader.PropertyToID("_Curvature");

		private static readonly int PropZoom = Shader.PropertyToID("_BorderZoom");

		private static readonly int PropInnerSizeX = Shader.PropertyToID("_BorderInnerSizeX");

		private static readonly int PropInnerSizeY = Shader.PropertyToID("_BorderInnerSizeY");

		private static readonly int PropOutterSizeX = Shader.PropertyToID("_BorderOutterSizeX");

		private static readonly int PropOutterSizeY = Shader.PropertyToID("_BorderOutterSizeY");

		private static readonly int PropColorScans = Shader.PropertyToID("_ColorScans");

		private static readonly int PropDesaturation = Shader.PropertyToID("_Desaturation");

		private static readonly int PropBrewedInkBayer4 = Shader.PropertyToID("_BrewedInk_Bayer4");

		private static readonly int PropBrewedInkBayer8 = Shader.PropertyToID("_BrewedInk_Bayer8");

		private static readonly int ChromaticAbberation = Shader.PropertyToID("_ChromaticAberration");

		private static readonly float[] bayer4 = new float[16]
		{
			0f, 8f, 2f, 10f, 12f, 4f, 14f, 6f, 3f, 11f,
			1f, 9f, 15f, 7f, 13f, 5f
		};

		private static readonly float[] bayer8 = new float[64]
		{
			0f, 32f, 8f, 40f, 2f, 34f, 10f, 42f, 48f, 16f,
			56f, 24f, 50f, 18f, 58f, 26f, 12f, 44f, 4f, 36f,
			14f, 46f, 6f, 38f, 60f, 28f, 52f, 20f, 62f, 30f,
			54f, 22f, 3f, 35f, 11f, 43f, 1f, 33f, 9f, 41f,
			51f, 19f, 59f, 27f, 49f, 17f, 57f, 25f, 15f, 47f,
			7f, 39f, 13f, 45f, 5f, 37f, 63f, 31f, 55f, 23f,
			61f, 29f, 53f, 21f
		};

		[ContextMenu("Reset Material")]
		public void ResetMaterial()
		{
			DestroyMaterial();
			CreateMaterial();
		}

		private void OnDestroy()
		{
			DestroyMaterial();
		}

		private void DestroyMaterial()
		{
			if (_runtimeMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(_runtimeMaterial);
				_runtimeMaterial = null;
			}
		}

		private void CreateMaterial()
		{
			if (crtRenderSettings != null && crtRenderSettings.crtMaterial != null && _runtimeMaterial == null)
			{
				_runtimeMaterial = new Material(crtRenderSettings.crtMaterial);
			}
			if (startConfig != null && !string.Equals(lastValidationId, startConfig.validationId))
			{
				lastValidationId = startConfig.validationId;
				data = startConfig.data.Clone();
			}
		}

		private void Update()
		{
			CreateMaterial();
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			if (_runtimeMaterial != null && data != null)
			{
				Shader.SetGlobalFloatArray(PropBrewedInkBayer4, bayer4);
				Shader.SetGlobalFloatArray(PropBrewedInkBayer8, bayer8);
				_runtimeMaterial.SetFloat(ChromaticAbberation, data.chromaticAbberation);
				_runtimeMaterial.SetFloat(PropMaxColorsRed, data.maxColorChannels.red);
				_runtimeMaterial.SetFloat(PropMaxColorsGreen, data.maxColorChannels.green);
				_runtimeMaterial.SetFloat(PropMaxColorsBlue, data.maxColorChannels.blue);
				_runtimeMaterial.SetFloat(PropDitheringAmount, data.dithering4);
				_runtimeMaterial.SetFloat(PropDitheringAmount8, data.dithering8);
				_runtimeMaterial.SetFloat(PropVignette, data.vignette);
				_runtimeMaterial.SetFloat(PropMonitorRoundness, data.monitorRoundness);
				_runtimeMaterial.SetFloat(PropInnerDarkness, 1f - data.innerMonitorDarkness);
				_runtimeMaterial.SetFloat(PropInnerGlow, data.innerMonitorShine);
				_runtimeMaterial.SetFloat(PropInnerReflectionRadius, data.innerMonitorShineRadius);
				_runtimeMaterial.SetFloat(PropInnerReflectionCurve, data.innerMonitorShineCurve);
				_runtimeMaterial.SetFloat(PropMonitorCurve, data.monitorCurve);
				_runtimeMaterial.SetFloat(PropInnerCurve, data.innerCurve);
				_runtimeMaterial.SetFloat(PropZoom, data.zoom);
				_runtimeMaterial.SetFloat(PropInnerSizeX, data.monitorInnerSize.width);
				_runtimeMaterial.SetFloat(PropInnerSizeY, data.monitorInnerSize.height);
				_runtimeMaterial.SetFloat(PropDesaturation, data.maxColorChannels.greyScale);
				_runtimeMaterial.SetFloat(PropOutterSizeX, data.monitorOutterSize.width);
				_runtimeMaterial.SetFloat(PropOutterSizeY, data.monitorOutterSize.height);
				_runtimeMaterial.SetVector(PropColorScans, new Vector4
				{
					x = data.colorScans.greenChannelMultiplier,
					y = data.colorScans.redBlueChannelMultiplier,
					z = data.colorScans.sizeMultiplier
				});
				_runtimeMaterial.SetTexture(PropMonitorTexture, data.monitorTexture);
				_runtimeMaterial.SetColor(PropMonitorColor, data.monitorColor);
				if (data.pixelationAmount > 1)
				{
					int num = Math.Min(300, data.pixelationAmount);
					RenderTextureDescriptor descriptor = src.descriptor;
					descriptor.width /= num;
					descriptor.height /= num;
					RenderTexture temporary = RenderTexture.GetTemporary(descriptor);
					temporary.filterMode = FilterMode.Point;
					Graphics.Blit(src, temporary);
					Graphics.Blit(temporary, dest, _runtimeMaterial);
					temporary.Release();
				}
				else
				{
					Graphics.Blit(src, dest, _runtimeMaterial);
				}
			}
			else
			{
				Graphics.Blit(src, dest);
			}
		}
	}
}
