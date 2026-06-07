using System;
using System.Runtime.InteropServices;
using OVR.OpenVR;
using UnityEngine;
using UnityEngine.XR;

[ExecuteInEditMode]
public class OVROverlay : MonoBehaviour
{
	public enum OverlayShape
	{
		Quad = 0,
		Cylinder = 1,
		Cubemap = 2,
		OffcenterCubemap = 4,
		Equirect = 5,
		ReconstructionPassthrough = 7,
		SurfaceProjectedPassthrough = 8,
		Fisheye = 9,
		KeyboardHandsPassthrough = 10
	}

	public enum OverlayType
	{
		None = 0,
		Underlay = 1,
		Overlay = 2
	}

	public delegate void ExternalSurfaceObjectCreated();

	private struct LayerTexture
	{
		public Texture appTexture;

		public IntPtr appTexturePtr;

		public Texture[] swapChain;

		public IntPtr[] swapChainPtr;
	}

	[Tooltip("Specify overlay's type")]
	public OverlayType currentOverlayType = OverlayType.Overlay;

	[Tooltip("If true, the texture's content is copied to the compositor each frame.")]
	public bool isDynamic;

	[Tooltip("If true, the layer would be used to present protected content (e.g. HDCP). The flag is effective only on PC.")]
	public bool isProtectedContent;

	public Rect srcRectLeft;

	public Rect srcRectRight;

	public Rect destRectLeft;

	public Rect destRectRight;

	public bool invertTextureRects;

	private OVRPlugin.TextureRectMatrixf textureRectMatrix = OVRPlugin.TextureRectMatrixf.zero;

	public bool overrideTextureRectMatrix;

	public bool overridePerLayerColorScaleAndOffset;

	public Vector4 colorScale = Vector4.one;

	public Vector4 colorOffset = Vector4.zero;

	public bool useExpensiveSuperSample;

	public bool hidden;

	[Tooltip("If true, the layer will be created as an external surface. externalSurfaceObject contains the Surface object. It's effective only on Android.")]
	public bool isExternalSurface;

	[Tooltip("The width which will be used to create the external surface. It's effective only on Android.")]
	public int externalSurfaceWidth;

	[Tooltip("The height which will be used to create the external surface. It's effective only on Android.")]
	public int externalSurfaceHeight;

	[Tooltip("The compositionDepth defines the order of the OVROverlays in composition. The overlay/underlay with smaller compositionDepth would be composited in the front of the overlay/underlay with larger compositionDepth.")]
	public int compositionDepth;

	private int layerCompositionDepth;

	[Tooltip("The noDepthBufferTesting will stop layer's depth buffer compositing even if the engine has \"Shared Depth Buffer\" enabled. The layer's ordering will be used instead which is determined by it's composition depth and overlay/underlay type.")]
	public bool noDepthBufferTesting = true;

	public OVRPlugin.EyeTextureFormat layerTextureFormat;

	[Tooltip("Specify overlay's shape")]
	public OverlayShape currentOverlayShape;

	private OverlayShape prevOverlayShape;

	[Tooltip("The left- and right-eye Textures to show in the layer.")]
	public Texture[] textures = new Texture[2];

	[Tooltip("When checked, the texture is treated as if the alpha was already premultiplied")]
	public bool isAlphaPremultiplied;

	[Tooltip("When checked, the layer will use bicubic filtering")]
	public bool useBicubicFiltering;

	[SerializeField]
	private bool _previewInEditor;

	protected IntPtr[] texturePtrs = new IntPtr[2]
	{
		IntPtr.Zero,
		IntPtr.Zero
	};

	public IntPtr externalSurfaceObject;

	public ExternalSurfaceObjectCreated externalSurfaceObjectCreated;

	protected bool isOverridePending;

	internal const int maxInstances = 15;

	public static OVROverlay[] instances = new OVROverlay[15];

	private static Material tex2DMaterial;

	private static Material cubeMaterial;

	private LayerTexture[] layerTextures;

	private OVRPlugin.LayerDesc layerDesc;

	private int stageCount = -1;

	private int layerIndex = -1;

	private GCHandle layerIdHandle;

	private IntPtr layerIdPtr = IntPtr.Zero;

	private int frameIndex;

	private int prevFrameIndex = -1;

	private Renderer rend;

	private ulong OpenVROverlayHandle;

	private Vector4 OpenVRUVOffsetAndScale = new Vector4(0f, 0f, 1f, 1f);

	private Vector2 OpenVRMouseScale = new Vector2(1f, 1f);

	private OVRManager.XRDevice constructedOverlayXRDevice;

	private bool xrDeviceConstructed;

	public bool previewInEditor
	{
		get
		{
			return _previewInEditor;
		}
		set
		{
			if (_previewInEditor != value)
			{
				_previewInEditor = value;
				SetupEditorPreview();
			}
		}
	}

	public int layerId { get; private set; }

	private OVRPlugin.LayerLayout layout => OVRPlugin.LayerLayout.Mono;

	private int texturesPerStage
	{
		get
		{
			if (layout != OVRPlugin.LayerLayout.Stereo)
			{
				return 1;
			}
			return 2;
		}
	}

	public static string OpenVROverlayKey => "unity:" + Application.companyName + "." + Application.productName;

	public void OverrideOverlayTextureInfo(Texture srcTexture, IntPtr nativePtr, XRNode node)
	{
		int num = ((node == XRNode.RightEye) ? 1 : 0);
		if (textures.Length > num)
		{
			textures[num] = srcTexture;
			texturePtrs[num] = nativePtr;
			isOverridePending = true;
		}
	}

	private static bool NeedsTexturesForShape(OverlayShape shape)
	{
		return !IsPassthroughShape(shape);
	}

	private bool CreateLayer(int mipLevels, int sampleCount, OVRPlugin.EyeTextureFormat etFormat, int flags, OVRPlugin.Sizei size, OVRPlugin.OverlayShape shape)
	{
		if (!layerIdHandle.IsAllocated || layerIdPtr == IntPtr.Zero)
		{
			layerIdHandle = GCHandle.Alloc(layerId, GCHandleType.Pinned);
			layerIdPtr = layerIdHandle.AddrOfPinnedObject();
		}
		if (layerIndex == -1)
		{
			for (int i = 0; i < 15; i++)
			{
				if (instances[i] == null || instances[i] == this)
				{
					layerIndex = i;
					instances[i] = this;
					break;
				}
			}
		}
		if (!isOverridePending && layerDesc.MipLevels == mipLevels && layerDesc.SampleCount == sampleCount && layerDesc.Format == etFormat && layerDesc.Layout == layout && layerDesc.LayerFlags == flags && layerDesc.TextureSize.Equals(size) && layerDesc.Shape == shape && layerCompositionDepth == compositionDepth)
		{
			return false;
		}
		OVRPlugin.LayerDesc desc = OVRPlugin.CalculateLayerDesc(shape, layout, size, mipLevels, sampleCount, etFormat, flags);
		OVRPlugin.EnqueueSetupLayer(desc, compositionDepth, layerIdPtr);
		layerId = (int)layerIdHandle.Target;
		if (layerId > 0)
		{
			layerDesc = desc;
			layerCompositionDepth = compositionDepth;
			if (isExternalSurface)
			{
				stageCount = 1;
			}
			else
			{
				stageCount = OVRPlugin.GetLayerTextureStageCount(layerId);
			}
		}
		isOverridePending = false;
		return true;
	}

	private bool CreateLayerTextures(bool useMipmaps, OVRPlugin.Sizei size, bool isHdr)
	{
		if (isExternalSurface)
		{
			if (externalSurfaceObject == IntPtr.Zero)
			{
				externalSurfaceObject = OVRPlugin.GetLayerAndroidSurfaceObject(layerId);
				if (externalSurfaceObject != IntPtr.Zero)
				{
					Debug.LogFormat("GetLayerAndroidSurfaceObject returns {0}", externalSurfaceObject);
					if (externalSurfaceObjectCreated != null)
					{
						externalSurfaceObjectCreated();
					}
				}
			}
			return false;
		}
		bool result = false;
		if (stageCount <= 0)
		{
			return false;
		}
		if (layerTextures == null)
		{
			layerTextures = new LayerTexture[texturesPerStage];
		}
		for (int i = 0; i < texturesPerStage; i++)
		{
			if (layerTextures[i].swapChain == null)
			{
				layerTextures[i].swapChain = new Texture[stageCount];
			}
			if (layerTextures[i].swapChainPtr == null)
			{
				layerTextures[i].swapChainPtr = new IntPtr[stageCount];
			}
			for (int j = 0; j < stageCount; j++)
			{
				Texture texture = layerTextures[i].swapChain[j];
				IntPtr intPtr = layerTextures[i].swapChainPtr[j];
				if (!(texture != null) || !(intPtr != IntPtr.Zero) || size.w != texture.width || size.h != texture.height)
				{
					if (intPtr == IntPtr.Zero)
					{
						intPtr = OVRPlugin.GetLayerTexture(layerId, j, (OVRPlugin.Eye)i);
					}
					if (!(intPtr == IntPtr.Zero))
					{
						TextureFormat format = (isHdr ? TextureFormat.RGBAHalf : TextureFormat.RGBA32);
						texture = ((currentOverlayShape == OverlayShape.Cubemap || currentOverlayShape == OverlayShape.OffcenterCubemap) ? ((Texture)Cubemap.CreateExternalTexture(size.w, format, useMipmaps, intPtr)) : ((Texture)Texture2D.CreateExternalTexture(size.w, size.h, format, useMipmaps, linear: true, intPtr)));
						layerTextures[i].swapChain[j] = texture;
						layerTextures[i].swapChainPtr[j] = intPtr;
						result = true;
					}
				}
			}
		}
		return result;
	}

	private void DestroyLayerTextures()
	{
		if (isExternalSurface)
		{
			return;
		}
		int num = 0;
		while (layerTextures != null && num < texturesPerStage)
		{
			if (layerTextures[num].swapChain != null)
			{
				for (int i = 0; i < stageCount; i++)
				{
					UnityEngine.Object.DestroyImmediate(layerTextures[num].swapChain[i]);
				}
			}
			num++;
		}
		layerTextures = null;
	}

	private void DestroyLayer()
	{
		if (layerIndex != -1)
		{
			OVRPlugin.EnqueueSubmitLayer(onTop: true, headLocked: false, noDepthBufferTesting: false, IntPtr.Zero, IntPtr.Zero, -1, 0, OVRPose.identity.ToPosef_Legacy(), Vector3.one.ToVector3f(), layerIndex, (OVRPlugin.OverlayShape)prevOverlayShape);
			instances[layerIndex] = null;
			layerIndex = -1;
		}
		if (layerIdPtr != IntPtr.Zero)
		{
			OVRPlugin.EnqueueDestroyLayer(layerIdPtr);
			layerIdPtr = IntPtr.Zero;
			layerIdHandle.Free();
			layerId = 0;
		}
		layerDesc = default(OVRPlugin.LayerDesc);
		frameIndex = 0;
		prevFrameIndex = -1;
	}

	public void SetSrcDestRects(Rect srcLeft, Rect srcRight, Rect destLeft, Rect destRight)
	{
		srcRectLeft = srcLeft;
		srcRectRight = srcRight;
		destRectLeft = destLeft;
		destRectRight = destRight;
	}

	public void UpdateTextureRectMatrix()
	{
		Rect leftRect = new Rect(srcRectLeft.x, (isExternalSurface ^ invertTextureRects) ? (1f - srcRectLeft.y - srcRectLeft.height) : srcRectLeft.y, srcRectLeft.width, srcRectLeft.height);
		Rect rightRect = new Rect(srcRectRight.x, (isExternalSurface ^ invertTextureRects) ? (1f - srcRectRight.y - srcRectRight.height) : srcRectRight.y, srcRectRight.width, srcRectRight.height);
		Rect rect = new Rect(destRectLeft.x, (isExternalSurface ^ invertTextureRects) ? (1f - destRectLeft.y - destRectLeft.height) : destRectLeft.y, destRectLeft.width, destRectLeft.height);
		Rect rect2 = new Rect(destRectRight.x, (isExternalSurface ^ invertTextureRects) ? (1f - destRectRight.y - destRectRight.height) : destRectRight.y, destRectRight.width, destRectRight.height);
		textureRectMatrix.leftRect = leftRect;
		textureRectMatrix.rightRect = rightRect;
		if (currentOverlayShape == OverlayShape.Fisheye)
		{
			rect.x -= 0.5f;
			rect.y -= 0.5f;
			rect2.x -= 0.5f;
			rect2.y -= 0.5f;
		}
		float num = srcRectLeft.width / destRectLeft.width;
		float num2 = srcRectLeft.height / destRectLeft.height;
		textureRectMatrix.leftScaleBias = new Vector4(num, num2, leftRect.x - rect.x * num, leftRect.y - rect.y * num2);
		float num3 = srcRectRight.width / destRectRight.width;
		float num4 = srcRectRight.height / destRectRight.height;
		textureRectMatrix.rightScaleBias = new Vector4(num3, num4, rightRect.x - rect2.x * num3, rightRect.y - rect2.y * num4);
	}

	public void SetPerLayerColorScaleAndOffset(Vector4 scale, Vector4 offset)
	{
		colorScale = scale;
		colorOffset = offset;
	}

	private bool LatchLayerTextures()
	{
		if (isExternalSurface)
		{
			return true;
		}
		for (int i = 0; i < texturesPerStage; i++)
		{
			if ((textures[i] != layerTextures[i].appTexture || layerTextures[i].appTexturePtr == IntPtr.Zero) && textures[i] != null)
			{
				RenderTexture renderTexture = textures[i] as RenderTexture;
				if ((bool)renderTexture && !renderTexture.IsCreated())
				{
					renderTexture.Create();
				}
				layerTextures[i].appTexturePtr = ((texturePtrs[i] != IntPtr.Zero) ? texturePtrs[i] : textures[i].GetNativeTexturePtr());
				if (layerTextures[i].appTexturePtr != IntPtr.Zero)
				{
					layerTextures[i].appTexture = textures[i];
				}
			}
			if (currentOverlayShape == OverlayShape.Cubemap && textures[i] as Cubemap == null)
			{
				Debug.LogError("Need Cubemap texture for cube map overlay");
				return false;
			}
		}
		if (currentOverlayShape == OverlayShape.OffcenterCubemap)
		{
			Debug.LogWarning(string.Concat("Overlay shape ", currentOverlayShape, " is not supported on current platform"));
			return false;
		}
		if (layerTextures[0].appTexture == null || layerTextures[0].appTexturePtr == IntPtr.Zero)
		{
			return false;
		}
		return true;
	}

	private OVRPlugin.LayerDesc GetCurrentLayerDesc()
	{
		OVRPlugin.Sizei textureSize = new OVRPlugin.Sizei
		{
			w = 0,
			h = 0
		};
		if (isExternalSurface)
		{
			textureSize.w = externalSurfaceWidth;
			textureSize.h = externalSurfaceHeight;
		}
		else if (NeedsTexturesForShape(currentOverlayShape))
		{
			if (textures[0] == null)
			{
				Debug.LogWarning("textures[0] hasn't been set");
			}
			textureSize.w = (textures[0] ? textures[0].width : 0);
			textureSize.h = (textures[0] ? textures[0].height : 0);
		}
		OVRPlugin.LayerDesc result = new OVRPlugin.LayerDesc
		{
			Format = layerTextureFormat,
			LayerFlags = ((!isExternalSurface) ? 8 : 0),
			Layout = layout,
			MipLevels = 1,
			SampleCount = 1,
			Shape = (OVRPlugin.OverlayShape)currentOverlayShape,
			TextureSize = textureSize
		};
		Texture2D texture2D = textures[0] as Texture2D;
		if (texture2D != null)
		{
			if (texture2D.format == TextureFormat.RGBAHalf || texture2D.format == TextureFormat.RGBAFloat)
			{
				result.Format = OVRPlugin.EyeTextureFormat.R16G16B16A16_FP;
			}
			result.MipLevels = texture2D.mipmapCount;
		}
		Cubemap cubemap = textures[0] as Cubemap;
		if (cubemap != null)
		{
			if (cubemap.format == TextureFormat.RGBAHalf || cubemap.format == TextureFormat.RGBAFloat)
			{
				result.Format = OVRPlugin.EyeTextureFormat.R16G16B16A16_FP;
			}
			result.MipLevels = cubemap.mipmapCount;
		}
		RenderTexture renderTexture = textures[0] as RenderTexture;
		if (renderTexture != null)
		{
			result.SampleCount = renderTexture.antiAliasing;
			if (renderTexture.format == RenderTextureFormat.ARGBHalf || renderTexture.format == RenderTextureFormat.ARGBFloat || renderTexture.format == RenderTextureFormat.RGB111110Float)
			{
				result.Format = OVRPlugin.EyeTextureFormat.R16G16B16A16_FP;
			}
		}
		if (isProtectedContent)
		{
			result.LayerFlags |= 64;
		}
		if (isExternalSurface)
		{
			result.LayerFlags |= 128;
		}
		if (useBicubicFiltering)
		{
			result.LayerFlags |= 16384;
		}
		return result;
	}

	private Rect GetBlitRect(int eyeId)
	{
		if (texturesPerStage == 2)
		{
			if (eyeId != 0)
			{
				return srcRectRight;
			}
			return srcRectLeft;
		}
		float num = Mathf.Min(srcRectLeft.x, srcRectRight.x);
		float num2 = Mathf.Min(srcRectLeft.y, srcRectRight.y);
		float num3 = Mathf.Max(srcRectLeft.x + srcRectLeft.width, srcRectRight.x + srcRectRight.width);
		float num4 = Mathf.Max(srcRectLeft.y + srcRectLeft.height, srcRectRight.y + srcRectRight.height);
		return new Rect(num, num2, num3 - num, num4 - num2);
	}

	private void BlitSubImage(Texture src, RenderTexture dst, Material mat, Rect rect)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = dst;
		rect.y = 1f - rect.y - rect.height;
		Rect pixelRect = new Rect((float)dst.width * rect.x, (float)dst.height * rect.y, (float)dst.width * rect.width, (float)dst.height * rect.height);
		GL.PushMatrix();
		GL.Viewport(pixelRect);
		GL.LoadPixelMatrix(pixelRect.x, pixelRect.x + pixelRect.width, pixelRect.y, pixelRect.y + pixelRect.height);
		tex2DMaterial.mainTexture = src;
		tex2DMaterial.SetPass(0);
		GL.Begin(4);
		GL.TexCoord(new Vector2(rect.x, rect.y));
		GL.Vertex3(pixelRect.x, pixelRect.y, 0f);
		GL.TexCoord(new Vector2(rect.x, rect.y + rect.height * 2f));
		GL.Vertex3(pixelRect.x, pixelRect.y + pixelRect.height * 2f, 0f);
		GL.TexCoord(new Vector2(rect.x + rect.width * 2f, rect.y));
		GL.Vertex3(pixelRect.x + pixelRect.width * 2f, pixelRect.y, 0f);
		GL.End();
		GL.Flush();
		GL.PopMatrix();
		RenderTexture.active = active;
	}

	private bool PopulateLayer(int mipLevels, bool isHdr, OVRPlugin.Sizei size, int sampleCount, int stage)
	{
		if (isExternalSurface)
		{
			return true;
		}
		bool result = false;
		RenderTextureFormat renderTextureFormat = (isHdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32);
		for (int i = 0; i < texturesPerStage; i++)
		{
			Texture texture = layerTextures[i].swapChain[stage];
			if (texture == null)
			{
				continue;
			}
			for (int j = 0; j < mipLevels; j++)
			{
				bool flag = isHdr || QualitySettings.activeColorSpace == ColorSpace.Linear;
				RenderTexture renderTexture = textures[i] as RenderTexture;
				bool num = !Application.isMobilePlatform;
				bool flag2 = !isHdr && flag;
				bool flag3 = num && !isAlphaPremultiplied;
				bool flag4 = !flag2 && !flag3 && renderTexture != null && renderTexture.format == renderTextureFormat;
				RenderTexture renderTexture2 = null;
				if (!flag4)
				{
					int num2 = size.w >> j;
					if (num2 < 1)
					{
						num2 = 1;
					}
					int num3 = size.h >> j;
					if (num3 < 1)
					{
						num3 = 1;
					}
					RenderTextureDescriptor desc = new RenderTextureDescriptor(num2, num3, renderTextureFormat, 0);
					desc.msaaSamples = sampleCount;
					desc.useMipMap = true;
					desc.autoGenerateMips = false;
					desc.sRGB = false;
					renderTexture2 = RenderTexture.GetTemporary(desc);
					if (!renderTexture2.IsCreated())
					{
						renderTexture2.Create();
					}
					renderTexture2.DiscardContents();
					Material material = null;
					material = ((currentOverlayShape == OverlayShape.Cubemap || currentOverlayShape == OverlayShape.OffcenterCubemap) ? cubeMaterial : tex2DMaterial);
					material.SetInt("_linearToSrgb", flag2 ? 1 : 0);
					material.SetInt("_premultiply", flag3 ? 1 : 0);
					material.SetInt("_flip", (OVRPlugin.nativeXrApi == OVRPlugin.XrApi.OpenXR) ? 1 : 0);
				}
				if (currentOverlayShape != OverlayShape.Cubemap && currentOverlayShape != OverlayShape.OffcenterCubemap)
				{
					if (flag4)
					{
						Graphics.CopyTexture(textures[i], 0, j, texture, 0, j);
					}
					else
					{
						if (overrideTextureRectMatrix)
						{
							BlitSubImage(textures[i], renderTexture2, tex2DMaterial, GetBlitRect(i));
						}
						else
						{
							Graphics.Blit(textures[i], renderTexture2, tex2DMaterial);
						}
						Graphics.CopyTexture(renderTexture2, 0, 0, texture, 0, j);
					}
				}
				else
				{
					for (int k = 0; k < 6; k++)
					{
						cubeMaterial.SetInt("_face", k);
						if (flag4)
						{
							Graphics.CopyTexture(textures[i], k, j, texture, k, j);
							continue;
						}
						Graphics.Blit(textures[i], renderTexture2, cubeMaterial);
						Graphics.CopyTexture(renderTexture2, 0, 0, texture, k, j);
					}
				}
				if (renderTexture2 != null)
				{
					RenderTexture.ReleaseTemporary(renderTexture2);
				}
				result = true;
			}
		}
		return result;
	}

	private bool SubmitLayer(bool overlay, bool headLocked, bool noDepthBufferTesting, OVRPose pose, Vector3 scale, int frameIndex)
	{
		int num = ((texturesPerStage >= 2) ? 1 : 0);
		if (overrideTextureRectMatrix)
		{
			UpdateTextureRectMatrix();
		}
		bool flag = isExternalSurface || !NeedsTexturesForShape(currentOverlayShape);
		bool result = OVRPlugin.EnqueueSubmitLayer(overlay, headLocked, noDepthBufferTesting, flag ? IntPtr.Zero : layerTextures[0].appTexturePtr, flag ? IntPtr.Zero : layerTextures[num].appTexturePtr, layerId, frameIndex, pose.flipZ().ToPosef_Legacy(), scale.ToVector3f(), layerIndex, (OVRPlugin.OverlayShape)currentOverlayShape, overrideTextureRectMatrix, textureRectMatrix, overridePerLayerColorScaleAndOffset, colorScale, colorOffset, useExpensiveSuperSample, hidden);
		prevOverlayShape = currentOverlayShape;
		return result;
	}

	private void SetupEditorPreview()
	{
	}

	public static bool IsPassthroughShape(OverlayShape shape)
	{
		if (shape != OverlayShape.ReconstructionPassthrough && shape != OverlayShape.KeyboardHandsPassthrough)
		{
			return shape == OverlayShape.SurfaceProjectedPassthrough;
		}
		return true;
	}

	private void Awake()
	{
		Debug.Log("Overlay Awake");
		if (Application.isPlaying)
		{
			if (tex2DMaterial == null)
			{
				tex2DMaterial = new Material(Shader.Find("Oculus/Texture2D Blit"));
			}
			if (cubeMaterial == null)
			{
				cubeMaterial = new Material(Shader.Find("Oculus/Cubemap Blit"));
			}
		}
		rend = GetComponent<Renderer>();
		if (textures.Length == 0)
		{
			textures = new Texture[1];
		}
		if (rend != null && textures[0] == null)
		{
			textures[0] = rend.sharedMaterial.mainTexture;
		}
		SetupEditorPreview();
	}

	private void OnEnable()
	{
		if (OVRManager.OVRManagerinitialized)
		{
			InitOVROverlay();
		}
	}

	private void InitOVROverlay()
	{
		if (!OVRManager.isHmdPresent)
		{
			base.enabled = false;
			return;
		}
		constructedOverlayXRDevice = OVRManager.XRDevice.Unknown;
		if (OVRManager.loadedXRDevice == OVRManager.XRDevice.OpenVR)
		{
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay == null)
			{
				base.enabled = false;
				return;
			}
			if (overlay.CreateOverlay(OpenVROverlayKey + base.transform.name, base.gameObject.name, ref OpenVROverlayHandle) != EVROverlayError.None)
			{
				base.enabled = false;
				return;
			}
		}
		constructedOverlayXRDevice = OVRManager.loadedXRDevice;
		xrDeviceConstructed = true;
	}

	private void OnDisable()
	{
		if ((base.gameObject.hideFlags & HideFlags.DontSaveInBuild) == 0 && OVRManager.OVRManagerinitialized && OVRManager.loadedXRDevice == constructedOverlayXRDevice)
		{
			if (OVRManager.loadedXRDevice == OVRManager.XRDevice.Oculus)
			{
				DestroyLayerTextures();
				DestroyLayer();
			}
			else if (OVRManager.loadedXRDevice == OVRManager.XRDevice.OpenVR && OpenVROverlayHandle != 0L)
			{
				OpenVR.Overlay?.DestroyOverlay(OpenVROverlayHandle);
				OpenVROverlayHandle = 0uL;
			}
			constructedOverlayXRDevice = OVRManager.XRDevice.Unknown;
			xrDeviceConstructed = false;
		}
	}

	private void OnDestroy()
	{
		DestroyLayerTextures();
		DestroyLayer();
	}

	private bool ComputeSubmit(ref OVRPose pose, ref Vector3 scale, ref bool overlay, ref bool headLocked)
	{
		Camera main = Camera.main;
		overlay = currentOverlayType == OverlayType.Overlay;
		headLocked = false;
		Transform parent = base.transform;
		while (parent != null && !headLocked)
		{
			headLocked |= parent == main.transform;
			parent = parent.parent;
		}
		pose = (headLocked ? base.transform.ToHeadSpacePose(main) : base.transform.ToTrackingSpacePose(main));
		scale = base.transform.lossyScale;
		for (int i = 0; i < 3; i++)
		{
			scale[i] /= main.transform.lossyScale[i];
		}
		if (currentOverlayShape == OverlayShape.Cubemap)
		{
			pose.position = main.transform.position;
		}
		if (currentOverlayShape == OverlayShape.OffcenterCubemap)
		{
			pose.position = base.transform.position;
			if (pose.position.magnitude > 1f)
			{
				Debug.LogWarning("Your cube map center offset's magnitude is greater than 1, which will cause some cube map pixel always invisible .");
				return false;
			}
		}
		if (OVRPlugin.nativeXrApi != OVRPlugin.XrApi.OpenXR && currentOverlayShape == OverlayShape.Cylinder)
		{
			float num = scale.x / scale.z / (float)Math.PI * 180f;
			if (num > 180f)
			{
				Debug.LogWarning("Cylinder overlay's arc angle has to be below 180 degree, current arc angle is " + num + " degree.");
				return false;
			}
		}
		if (OVRPlugin.nativeXrApi == OVRPlugin.XrApi.OpenXR && currentOverlayShape == OverlayShape.Fisheye)
		{
			Debug.LogWarning("Fisheye overlay shape is not support on OpenXR");
			return false;
		}
		return true;
	}

	private void OpenVROverlayUpdate(Vector3 scale, OVRPose pose)
	{
		CVROverlay overlay = OpenVR.Overlay;
		if (overlay == null)
		{
			return;
		}
		Texture texture = textures[0];
		if (texture != null)
		{
			EVROverlayError eVROverlayError = overlay.ShowOverlay(OpenVROverlayHandle);
			if ((eVROverlayError != EVROverlayError.InvalidHandle && eVROverlayError != EVROverlayError.UnknownOverlay) || overlay.FindOverlay(OpenVROverlayKey + base.transform.name, ref OpenVROverlayHandle) == EVROverlayError.None)
			{
				Texture_t pTexture = new Texture_t
				{
					handle = texture.GetNativeTexturePtr(),
					eType = (SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL") ? ETextureType.OpenGL : ETextureType.DirectX),
					eColorSpace = EColorSpace.Auto
				};
				overlay.SetOverlayTexture(OpenVROverlayHandle, ref pTexture);
				VRTextureBounds_t pOverlayTextureBounds = new VRTextureBounds_t
				{
					uMin = (0f + OpenVRUVOffsetAndScale.x) * OpenVRUVOffsetAndScale.z,
					vMin = (1f + OpenVRUVOffsetAndScale.y) * OpenVRUVOffsetAndScale.w,
					uMax = (1f + OpenVRUVOffsetAndScale.x) * OpenVRUVOffsetAndScale.z,
					vMax = (0f + OpenVRUVOffsetAndScale.y) * OpenVRUVOffsetAndScale.w
				};
				overlay.SetOverlayTextureBounds(OpenVROverlayHandle, ref pOverlayTextureBounds);
				HmdVector2_t pvecMouseScale = new HmdVector2_t
				{
					v0 = OpenVRMouseScale.x,
					v1 = OpenVRMouseScale.y
				};
				overlay.SetOverlayMouseScale(OpenVROverlayHandle, ref pvecMouseScale);
				overlay.SetOverlayWidthInMeters(OpenVROverlayHandle, scale.x);
				HmdMatrix34_t pmatTrackingOriginToOverlayTransform = Matrix4x4.TRS(pose.position, pose.orientation, Vector3.one).ConvertToHMDMatrix34();
				overlay.SetOverlayTransformAbsolute(OpenVROverlayHandle, ETrackingUniverseOrigin.TrackingUniverseStanding, ref pmatTrackingOriginToOverlayTransform);
			}
		}
	}

	private void LateUpdate()
	{
		if (!OVRManager.OVRManagerinitialized)
		{
			return;
		}
		if (!xrDeviceConstructed)
		{
			InitOVROverlay();
		}
		if (OVRManager.loadedXRDevice != constructedOverlayXRDevice)
		{
			Debug.LogError("Warning-XR Device was switched during runtime with overlays still enabled. When doing so, all overlays constructed with the previous XR device must first be disabled.");
			return;
		}
		bool flag = !isExternalSurface && NeedsTexturesForShape(currentOverlayShape);
		if (currentOverlayType == OverlayType.None || (flag && (textures.Length < texturesPerStage || textures[0] == null)))
		{
			return;
		}
		OVRPose pose = OVRPose.identity;
		Vector3 scale = Vector3.one;
		bool overlay = false;
		bool headLocked = false;
		if (!ComputeSubmit(ref pose, ref scale, ref overlay, ref headLocked))
		{
			return;
		}
		if (OVRManager.loadedXRDevice == OVRManager.XRDevice.OpenVR)
		{
			if (currentOverlayShape == OverlayShape.Quad)
			{
				OpenVROverlayUpdate(scale, pose);
			}
			return;
		}
		OVRPlugin.LayerDesc currentLayerDesc = GetCurrentLayerDesc();
		bool isHdr = currentLayerDesc.Format == OVRPlugin.EyeTextureFormat.R16G16B16A16_FP;
		bool num = !layerDesc.TextureSize.Equals(currentLayerDesc.TextureSize) && layerId > 0;
		bool flag2 = NeedsTexturesForShape(currentOverlayShape);
		bool flag3 = NeedsTexturesForShape(prevOverlayShape) != flag2;
		if (num || flag3)
		{
			DestroyLayerTextures();
			DestroyLayer();
		}
		bool flag4 = CreateLayer(currentLayerDesc.MipLevels, currentLayerDesc.SampleCount, currentLayerDesc.Format, currentLayerDesc.LayerFlags, currentLayerDesc.TextureSize, currentLayerDesc.Shape);
		if (layerIndex == -1 || layerId <= 0)
		{
			if (flag4)
			{
				prevOverlayShape = currentOverlayShape;
			}
			return;
		}
		if (flag2)
		{
			bool useMipmaps = currentLayerDesc.MipLevels > 1;
			flag4 |= CreateLayerTextures(useMipmaps, currentLayerDesc.TextureSize, isHdr);
			if (!isExternalSurface && layerTextures[0].appTexture as RenderTexture != null)
			{
				isDynamic = true;
			}
			if (!LatchLayerTextures())
			{
				return;
			}
			if (frameIndex > prevFrameIndex)
			{
				int stage = frameIndex % stageCount;
				if (!PopulateLayer(currentLayerDesc.MipLevels, isHdr, currentLayerDesc.TextureSize, currentLayerDesc.SampleCount, stage))
				{
					return;
				}
			}
		}
		bool flag5 = SubmitLayer(overlay, headLocked, noDepthBufferTesting, pose, scale, frameIndex);
		prevFrameIndex = frameIndex;
		if (isDynamic)
		{
			frameIndex++;
		}
		if ((bool)rend)
		{
			rend.enabled = !flag5;
		}
	}
}
