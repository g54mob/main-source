using System;
using UnityEngine;

namespace JetFistGames.RetroTVFX
{
	[ExecuteInEditMode]
	public class CRTEffect : MonoBehaviour
	{
		private const int PASS_COMPOSITE_ENCODE = 0;

		private const int PASS_COMPOSITE_DECODE = 1;

		private const int PASS_COMPOSITE_FINAL = 2;

		private const int PASS_VGA = 4;

		private const int PASS_COMPONENT = 5;

		private const int PASS_SVIDEO_ENCODE = 6;

		private const int PASS_SVIDEO_DECODE = 7;

		private const int PASS_TV_OVERLAY = 3;

		[Header("Shader Properties")]
		[HideInInspector]
		public Shader shader;

		[Tooltip("Which style of video to use")]
		public VideoType VideoMode = VideoType.Composite;

		public bool AutomaticDisplaySize;

		public float AutomaticScaleFactor = 2f;

		public int DisplaySizeX = 960;

		public int DisplaySizeY = 480;

		public bool StretchToDisplay = true;

		public float AspectRatio = 1.33f;

		[Tooltip("Apply curvature to display")]
		public bool EnableTVCurvature;

		[Range(0f, 1f)]
		public float Curvature;

		[Tooltip("Overlay image applied (before curvature)")]
		public Texture2D TVOverlay;

		public bool EnablePixelMask = true;

		public Texture2D PixelMaskTexture;

		public int MaskRepeatX = 160;

		public int MaskRepeatY = 90;

		[Range(1f, 2f)]
		public float PixelMaskBrightness = 1f;

		public Vector2 IQOffset = Vector2.zero;

		public Vector2 IQScale = Vector2.one;

		[Range(0f, 2f)]
		public float RFNoise = 0.25f;

		[Range(0f, 4f)]
		public float LumaSharpen;

		public bool QuantizeRGB;

		[Range(2f, 8f)]
		public int RBits = 8;

		[Range(2f, 8f)]
		public int GBits = 8;

		[Range(2f, 8f)]
		public int BBits = 8;

		public bool EnableBurstCountAnimation = true;

		public bool AntiFlicker;

		public bool EnableRollingFlicker;

		[Range(0f, 1f)]
		public float RollingFlickerFactor = 0.25f;

		[Range(0f, 2f)]
		public float RollingVSyncTime = 1f;

		private Material material;

		private RenderTexture compositeTemp;

		private int frameCount;

		private float flickerOffset;

		private bool antiFlickerEnabled;

		private bool rollingFlickerEnabled;

		private bool pixelMaskEnabled;

		private bool tvCurvatureEnabled;

		private bool quantizeRGBEnabled;

		private bool rfEnabled;

		private float[] lumaFilter = new float[9] { -0.002f, -0.0009f, 0.0038f, 0.0178f, 0.0445f, 0.0817f, 0.1214f, 0.1519f, 0.1634f };

		private float[] chromaFilter = new float[9] { 0.0046f, 0.0082f, 0.0182f, 0.0353f, 0.0501f, 0.0832f, 0.1062f, 0.1222f, 0.128f };

		private Matrix4x4 rgb2yiq_mat = Matrix4x4.identity;

		private Matrix4x4 yiq2rgb_mat = Matrix4x4.identity;

		private void Start()
		{
		}

		private void OnDisable()
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(material);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(material);
			}
			antiFlickerEnabled = false;
			rollingFlickerEnabled = false;
			pixelMaskEnabled = false;
			tvCurvatureEnabled = false;
			quantizeRGBEnabled = false;
			rfEnabled = false;
			if (compositeTemp != null)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(compositeTemp);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(compositeTemp);
				}
			}
		}

		private void Update()
		{
			if (AutomaticDisplaySize)
			{
				DisplaySizeX = Convert.ToInt32(Mathf.Ceil((float)Screen.width * 1f / AutomaticScaleFactor));
				DisplaySizeY = Convert.ToInt32(Mathf.Ceil((float)Screen.height * 1f / AutomaticScaleFactor));
			}
			ensureResources();
		}

		private void LateUpdate()
		{
			if (EnableBurstCountAnimation)
			{
				frameCount++;
				frameCount %= 3;
			}
			if (EnableRollingFlicker)
			{
				flickerOffset += RollingVSyncTime;
			}
		}

		private void ensureResources()
		{
			if (rgb2yiq_mat == Matrix4x4.identity)
			{
				rgb2yiq_mat.SetRow(0, new Vector4(0.299f, 0.587f, 0.114f, 0f));
				rgb2yiq_mat.SetRow(1, new Vector4(0.596f, -0.275f, -0.321f, 0f));
				rgb2yiq_mat.SetRow(2, new Vector4(0.221f, -0.523f, 0.311f, 0f));
			}
			if (yiq2rgb_mat == Matrix4x4.identity)
			{
				yiq2rgb_mat.SetRow(0, new Vector4(1f, 0.956f, 0.621f, 0f));
				yiq2rgb_mat.SetRow(1, new Vector4(1f, -0.272f, -0.647f, 0f));
				yiq2rgb_mat.SetRow(2, new Vector4(1f, -1.106f, 1.703f, 0f));
			}
			if (material == null)
			{
				material = new Material(shader);
			}
			material.SetMatrix("_RGB2YIQ_MAT", rgb2yiq_mat);
			material.SetMatrix("_YIQ2RGB_MAT", yiq2rgb_mat);
			material.SetTexture("_OverlayImg", TVOverlay);
			material.SetFloatArray("_LumaFilter", lumaFilter);
			material.SetFloatArray("_ChromaFilter", chromaFilter);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			ensureResources();
			setKeyword("ANTI_FLICKER", AntiFlicker, ref antiFlickerEnabled);
			setKeyword("ROLLING_FLICKER", EnableRollingFlicker, ref rollingFlickerEnabled);
			setKeyword("PIXEL_MASK", EnablePixelMask, ref pixelMaskEnabled);
			setKeyword("USE_TV_CURVATURE", EnableTVCurvature, ref tvCurvatureEnabled);
			setKeyword("QUANTIZE_RGB", QuantizeRGB, ref quantizeRGBEnabled);
			setKeyword("RF_SIGNAL", VideoMode == VideoType.RF, ref rfEnabled);
			if (compositeTemp == null || compositeTemp.width != DisplaySizeX || compositeTemp.height != DisplaySizeY)
			{
				if (compositeTemp != null)
				{
					RenderTexture.ReleaseTemporary(compositeTemp);
				}
				compositeTemp = RenderTexture.GetTemporary(DisplaySizeX, DisplaySizeY, src.depth, RenderTextureFormat.ARGBHalf);
			}
			if (QuantizeRGB)
			{
				Vector4 value = new Vector4(Mathf.Pow(2f, RBits), Mathf.Pow(2f, GBits), Mathf.Pow(2f, BBits), 1f);
				Vector4 value2 = new Vector4(1f / value.x, 1f / value.y, 1f / value.z, 1f);
				material.SetVector("_QuantizeRGB", value);
				material.SetVector("_OneOverQuantizeRGB", value2);
			}
			material.SetFloat("_Realtime", Time.realtimeSinceStartup);
			material.SetVector("_IQOffset", new Vector4(IQScale.x, IQScale.y, IQOffset.x, IQOffset.y));
			material.SetMatrix("_RGB2YIQ_MAT", rgb2yiq_mat);
			material.SetMatrix("_YIQ2RGB_MAT", yiq2rgb_mat);
			material.SetFloat("_RFNoise", RFNoise);
			material.SetFloat("_LumaSharpen", LumaSharpen);
			material.SetInt("_Framecount", -frameCount);
			material.SetVector("_ScreenSize", new Vector4(DisplaySizeX, DisplaySizeY, 1f / (float)DisplaySizeX, 1f / (float)DisplaySizeY));
			material.SetFloat("_RollingFlickerAmount", RollingFlickerFactor);
			material.SetVector("_FlickerOffs", new Vector4(flickerOffset, flickerOffset + RollingVSyncTime, 0f, 0f));
			material.SetVector("_PixelMaskScale", new Vector4(MaskRepeatX, MaskRepeatY));
			material.SetTexture("_PixelMask", PixelMaskTexture);
			material.SetFloat("_Brightness", PixelMaskBrightness);
			material.SetFloat("_TVCurvature", Curvature);
			RenderTexture temporary = RenderTexture.GetTemporary(DisplaySizeX, DisplaySizeY, src.depth, RenderTextureFormat.ARGBHalf);
			RenderTexture temporary2 = RenderTexture.GetTemporary(DisplaySizeX, DisplaySizeY, src.depth, RenderTextureFormat.ARGBHalf);
			RenderTexture temporary3 = RenderTexture.GetTemporary(DisplaySizeX, DisplaySizeY, src.depth, RenderTextureFormat.ARGBHalf);
			RenderTexture src2 = temporary;
			if (VideoMode == VideoType.Composite || VideoMode == VideoType.RF)
			{
				Graphics.Blit(src, temporary);
				Graphics.Blit(temporary, temporary2, material, 0);
				Graphics.Blit(compositeTemp, temporary3);
				Graphics.Blit(temporary2, compositeTemp);
				material.SetTexture("_LastCompositeTex", temporary3);
				Graphics.Blit(temporary2, temporary, material, 1);
				Graphics.Blit(temporary, temporary2, material, 2);
				src2 = temporary2;
			}
			else if (VideoMode == VideoType.SVideo)
			{
				Graphics.Blit(src, temporary);
				Graphics.Blit(temporary, temporary2, material, 6);
				Graphics.Blit(compositeTemp, temporary3);
				Graphics.Blit(temporary2, compositeTemp);
				material.SetTexture("_LastCompositeTex", temporary3);
				Graphics.Blit(temporary2, temporary, material, 7);
			}
			else if (VideoMode == VideoType.VGA)
			{
				Graphics.Blit(src, temporary, material, 4);
			}
			else if (VideoMode == VideoType.VGAFast)
			{
				src2 = src;
			}
			else if (VideoMode == VideoType.Component)
			{
				Graphics.Blit(src, temporary, material, 5);
			}
			if (StretchToDisplay)
			{
				blitQuad(src2, dest, material, 3);
			}
			else
			{
				float num = (float)Screen.width / (float)Screen.height;
				if (num < AspectRatio)
				{
					float width = 1f;
					float num2 = num / AspectRatio;
					float num3 = 1f - num2;
					blitQuad(new Rect(0f, num3 * 0.5f, width, num2), src2, dest, material, 3);
				}
				else
				{
					float height = 1f;
					float num4 = 1f / num * AspectRatio;
					float num5 = 1f - num4;
					blitQuad(new Rect(num5 * 0.5f, 0f, num4, height), src2, dest, material, 3);
				}
			}
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
		}

		private void setKeyword(string keyword, bool enabled, ref bool keywordEnabled)
		{
			if (enabled != keywordEnabled)
			{
				if (enabled)
				{
					material.EnableKeyword(keyword);
				}
				else
				{
					material.DisableKeyword(keyword);
				}
			}
			keywordEnabled = enabled;
		}

		private void blitQuad(RenderTexture src, RenderTexture dest, Material material, int pass)
		{
			blitQuad(new Rect(0f, 0f, 1f, 1f), src, dest, material, pass);
		}

		private void blitQuad(Rect rect, RenderTexture src, RenderTexture dest, Material material, int pass)
		{
			GL.PushMatrix();
			GL.LoadOrtho();
			RenderTexture.active = dest;
			GL.Clear(clearDepth: true, clearColor: true, Color.black);
			material.SetTexture("_MainTex", src);
			material.SetPass(pass);
			GL.Begin(7);
			GL.Color(Color.white);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(rect.x, rect.y, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(rect.xMax, rect.y, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(rect.xMax, rect.yMax, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(rect.x, rect.yMax, 0.1f);
			GL.End();
			GL.PopMatrix();
		}
	}
}
