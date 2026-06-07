using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OneBit : MonoBehaviour
{
	public enum Mode
	{
		Basic = 0,
		Lined = 1
	}

	private enum DebugLinedRenderMode
	{
		None = 0,
		Main = 1,
		BlurMap = 2,
		Diffuse = 3,
		Sections = 4,
		Wires = 5,
		Depth = 6,
		FlagSky = 7,
		FlagWatchHand = 8,
		FlagDust = 9,
		FlagDitherError = 10,
		FlagDitherBayer = 11,
		ForMomentPhoto = 12
	}

	public enum StyleId
	{
		None = 0,
		Default = 1,
		Upscale = 2,
		Default_ForTexture = 3,
		Upscale_ForTexture = 4,
		Debug = 5,
		COUNT = 6
	}

	[Serializable]
	public class BasicSettings
	{
		public bool debugMain;

		public bool allowOverlay = true;

		[HideInInspector]
		public Vector2 ditherOffset = new Vector2(0f, 0f);
	}

	public class CurtainSettings
	{
		public float t;

		public Vector3 worldCenter;

		public bool useWorldCenter;

		public bool reverse;

		public bool behindWatchHand;

		public Vector4 GetParams0(Camera camera)
		{
			Vector3 vector = Vector3.zero;
			if (useWorldCenter)
			{
				vector = camera.WorldToViewportPoint(worldCenter);
				vector.x = Util.LerpScale(vector.x, 0f, 1f, -1f, 1f);
				vector.y = Util.LerpScale(vector.y, 0f, 1f, -1f, 1f);
				vector.x = Mathf.Min(1f, Mathf.Max(-1f, vector.x));
				vector.y = Mathf.Min(1f, Mathf.Max(-1f, vector.y));
			}
			float num = 0f;
			return new Vector4(z: (!reverse) ? (0.6f * Mathf.Pow(t, 2f)) : (1f - Mathf.Pow(0.75f * (1f - t), 2f)), x: vector.x, y: vector.y, w: reverse ? 1 : 0);
		}

		public float GetParams1()
		{
			return (!behindWatchHand) ? 0f : 1f;
		}
	}

	[Serializable]
	public class LinedSettings
	{
		public bool distortFringe;

		public bool clearingColorBlack;

		public float brightenClothes;

		public bool applyHumanGlow = true;

		public float ditherPoleRotation;

		public bool inOffice;

		public bool translucentOverlay;

		[HideInInspector]
		public bool nether;

		[HideInInspector]
		public Vector3 netherCenter;

		[HideInInspector]
		public Vector4 netherRingEdges;

		[HideInInspector]
		public float netherPulseDist;

		[HideInInspector]
		public bool watchHandOnly;

		[HideInInspector]
		public bool examine;

		[HideInInspector]
		public Vector2 examineDitherOffset;

		[HideInInspector]
		public Vector3 examineReveal;

		[HideInInspector]
		public bool sparkle;

		[HideInInspector]
		public float sparkleScreenRadius;

		[HideInInspector]
		public float sparkleSpinTime;

		[HideInInspector]
		public int sparkleBeamCount;

		[HideInInspector]
		public int sparkleHoleCount;

		[HideInInspector]
		public Vector2 sparkleScreenPos;

		[HideInInspector]
		public float sparkleDepth01;

		[HideInInspector]
		public bool sparkleTestDepth;

		[HideInInspector]
		public float shipEnderT;

		[HideInInspector]
		public Camera preOverlayCamera;

		[HideInInspector]
		public int soloLayerBits;

		[HideInInspector]
		public CurtainSettings curtainSettings = new CurtainSettings();

		public Vector4 sparkleParams0
		{
			get
			{
				return new Vector4(sparkleScreenPos.x, sparkleScreenPos.y, sparkleScreenRadius, 0f);
			}
		}

		public Vector4 sparkleParams1
		{
			get
			{
				return new Vector4(sparkleSpinTime, sparkleBeamCount, sparkleHoleCount, sparkleDepth01);
			}
		}
	}

	private class Style
	{
		public class Rt
		{
			public RenderTexture scene;

			public RenderTexture temp0;

			public RenderTexture blurMap;

			public RenderTexture final;
		}

		public delegate void ApplyFunc(Rt rt);

		public StyleId id;

		public ApplyFunc applyFunc;

		public float dustScale = 1f;

		public float sceneScale = 1f;

		public float finalScale = 1f;

		public bool ditherShiftEnabled;

		public bool defaultLinedProcessing = true;

		public bool warpUseSphereMapping;

		public Style(StyleId id_, ApplyFunc applyFunc_)
		{
			id = id_;
			applyFunc = applyFunc_;
		}

		public Style SetDustScale(float dustScale_)
		{
			dustScale = dustScale_;
			return this;
		}

		public Style SetFinalScale(float finalScale_)
		{
			finalScale = finalScale_;
			return this;
		}

		public Style SetSceneScale(float sceneScale_)
		{
			sceneScale = sceneScale_;
			return this;
		}

		public Style DisableDefaultLinedProcessing()
		{
			defaultLinedProcessing = false;
			return this;
		}

		public Style EnableDitherShift()
		{
			ditherShiftEnabled = true;
			return this;
		}

		public Style EnableWarpUseSphereMapping()
		{
			warpUseSphereMapping = true;
			return this;
		}

		public void Apply(Rt rt)
		{
			applyFunc(rt);
		}
	}

	private class Styles
	{
		private List<Style> styles = new List<Style>();

		public Styles()
		{
			for (int i = 0; i < 6; i++)
			{
				styles.Add(null);
			}
		}

		public Style Find(StyleId id)
		{
			return styles[(int)id];
		}

		public Style Add(StyleId id, Style.ApplyFunc applyFunc)
		{
			Style style = new Style(id, applyFunc);
			styles[(int)id] = style;
			return style;
		}
	}

	private class Materials
	{
		public const int kPassPostDecode = 0;

		public const int kPassPostResolve = 1;

		public const int kPassPostLinedAddOverlay = 2;

		public const int kPassPostLinedDebug = 3;

		public const int kPassLineScale2xDetectLines = 0;

		public const int kPassLineScale2xStitchSubpixels = 1;

		public const int kPassLineScale2xFixFlags = 2;

		public const int kPassWernessPrep = 0;

		public const int kPassWernessDiffuse = 1;

		public const int kPassWernessBypass = 1;

		public const int kPassGlowExtract = 0;

		public const int kPassGlowCombine = 1;

		public Material post;

		public Material wernessClassic;

		public Material lineScale2x;

		public Material thicken;

		public Material distortVignette;

		public Material warpDefault;

		public Material warpNether;

		public Material curtain;

		public Material sharpenOverlay;

		public Material watchHandOnly;

		public Material ditherSphere;

		public Material dither;

		public Material downscale;

		public Material examinerPost;

		public Material glow;

		public Material sparkle;

		public Material shipEnder;

		public GaussianBlur.Params examineBlurParams;

		public Materials(Mode mode, OneBitAssets assets, Clearing clearing, LinedSettings linedSettings)
		{
			post = new Material((mode != Mode.Lined) ? assets.finalizeBasicShader : assets.finalizeLinedShader);
			if (clearing != null)
			{
				post.EnableKeyword((!linedSettings.clearingColorBlack) ? "FINALIZELINED_CLEARING_WHITE" : "FINALIZELINED_CLEARING_BLACK");
				post.SetTexture("_ClearingTex", clearing.texture);
				post.SetMatrix("_ClearingUvTransform", clearing.uvTransform);
				post.SetVector("_ClearingVerticalEdges", clearing.verticalEdges);
			}
			wernessClassic = new Material(assets.wernessClassicShader);
			wernessClassic.SetTexture("_DitherTex", assets.ditherTexture);
			lineScale2x = new Material(assets.lineScale2xShader);
			thicken = new Material(assets.thickenShader);
			distortVignette = new Material(assets.distortVignetteShader);
			distortVignette.SetTexture("_WarpTex", assets.warpDefaultTexture);
			warpDefault = new Material(assets.warpDefaultShader);
			warpDefault.SetTexture("_WarpTex", assets.warpDefaultTexture);
			warpNether = new Material(assets.warpNetherShader);
			warpNether.SetTexture("_WarpTex", assets.warpNetherTexture);
			curtain = new Material(assets.curtainShader);
			curtain.SetTexture("_CurtainTex", assets.curtainTexture);
			sharpenOverlay = new Material(assets.sharpenOverlayShader);
			watchHandOnly = new Material(assets.watchHandOnlyShader);
			ditherSphere = new Material(assets.ditherSphereMaterial);
			dither = new Material(assets.ditherShader);
			downscale = new Material(assets.downscaleShader);
			examinerPost = new Material(assets.examinerPostShader);
			glow = new Material(assets.glowShader);
			sparkle = new Material(assets.sparkleShader);
			shipEnder = new Material(assets.shipEnder);
			if (linedSettings.inOffice)
			{
				examineBlurParams = new GaussianBlur.Params(0.5f, 2f);
				examinerPost.EnableKeyword("EXAMINERPOST_INOFFICE");
			}
			else
			{
				examineBlurParams = new GaussianBlur.Params(0.25f, 2f, 4);
				examinerPost.DisableKeyword("EXAMINERPOST_INOFFICE");
			}
		}
	}

	private enum SourceChannel
	{
		R = 0,
		G = 1,
		B = 2
	}

	public Mode mode;

	public Camera sourceCamera;

	public Clearing clearing;

	public OneBitAssets assets;

	public GaussianBlur gaussianBlur;

	private RenderTarget ditherWarpTarget;

	private GaussianBlur.Params examineBlurParams;

	private Styles styles = new Styles();

	private Materials materials;

	private Style.Rt styleRt = new Style.Rt();

	private StyleId testStyleId;

	private CommandBuffer ditherSphereCommandBuffer;

	public BasicSettings basicSettings;

	public LinedSettings linedSettings;

	private RenderLayer blurMapRenderLayer;

	private RenderLayer examinerMaskRenderLayer;

	private RenderLayer skyRenderLayer;

	private RenderLayer defaultRenderLayer;

	private static int showOverlayUntilFrame;

	private Matrix4x4 prevViewProjMatrix;

	private Matrix4x4 prevCameraMatrix;

	private DebugLinedRenderMode debugLinedRenderMode;

	private bool wantDiffusion
	{
		get
		{
			return mode == Mode.Basic || clearing != null;
		}
	}

	private bool overlayIsVisible
	{
		get
		{
			return GetOverlayIsVisible();
		}
	}

	private StyleId defaultStyleId
	{
		get
		{
			if ((mode == Mode.Lined && debugLinedRenderMode != DebugLinedRenderMode.None) || (mode == Mode.Basic && basicSettings.debugMain))
			{
				return StyleId.Debug;
			}
			if (testStyleId != StyleId.None)
			{
				return testStyleId;
			}
			return (!Settings.outputModeIsUpscaled) ? StyleId.Default : StyleId.Upscale;
		}
	}

	public bool debugging
	{
		get
		{
			return basicSettings.debugMain || debugLinedRenderMode != DebugLinedRenderMode.None;
		}
	}

	public static void ShowOverlayForFrames(int numFrames = 1)
	{
		if (numFrames < 0)
		{
			showOverlayUntilFrame = 0;
		}
		else
		{
			showOverlayUntilFrame = Mathf.Max(showOverlayUntilFrame, Time.frameCount + numFrames);
		}
	}

	public static bool GetOverlayIsVisible()
	{
		return showOverlayUntilFrame > Time.frameCount;
	}

	private void Start()
	{
		DebugMenu.Add("Post", KeyCode.P);
		if (materials == null)
		{
			RefreshMaterials();
		}
		sourceCamera.depthTextureMode = DepthTextureMode.Depth;
		sourceCamera.enabled = false;
		GetComponent<Camera>().renderingPath = RenderingPath.DeferredLighting;
		Monitor.BlackOut(3);
		if (mode == Mode.Basic)
		{
			styles.Add(StyleId.Default, delegate(Style.Rt rt)
			{
				RenderTarget.Blit(rt.scene, rt.final, materials.post, 0);
				RunErrorDiffusionAndResolve(rt.final, rt.scene);
				RenderTarget.Blit(rt.scene, rt.final);
			});
			styles.Add(StyleId.Upscale, delegate(Style.Rt rt)
			{
				materials.post.EnableKeyword("FINALIZEBASIC_DECODE_UPSCALE");
				RenderTarget.Blit(rt.scene, rt.final, materials.post, 0);
				RunErrorDiffusionAndResolve(rt.final, rt.scene);
				RenderTarget.Blit(rt.scene, rt.final);
				materials.post.DisableKeyword("FINALIZEBASIC_DECODE_UPSCALE");
			});
			styles.Add(StyleId.Debug, delegate(Style.Rt rt)
			{
				RenderTarget.Blit(rt.scene, rt.final);
			});
			styles.Add(StyleId.Default_ForTexture, delegate(Style.Rt rt)
			{
				RenderTarget.Blit(rt.scene, rt.final);
			});
			styles.Add(StyleId.Upscale_ForTexture, styles.Find(StyleId.Default_ForTexture).applyFunc);
			return;
		}
		blurMapRenderLayer = new RenderLayer
		{
			layerBits = 1 << LayerMask.NameToLayer("BlurMap"),
			clearFlags = CameraClearFlags.Color,
			clearColor = new Color(0f, 1f, 1f, 0f),
			renderingPath = RenderingPath.Forward,
			farClipPlane = 50f,
			occlusionCulling = true
		};
		examinerMaskRenderLayer = new RenderLayer
		{
			layerBits = 1 << LayerMask.NameToLayer("ExaminerMask"),
			clearFlags = CameraClearFlags.Color,
			clearColor = new Color(0f, 0f, 0f, 1f),
			renderingPath = RenderingPath.VertexLit,
			farClipPlane = 50f,
			occlusionCulling = false
		};
		skyRenderLayer = new RenderLayer
		{
			layerBits = 1 << LayerMask.NameToLayer("Sky"),
			clearFlags = CameraClearFlags.Color,
			clearColor = new Color(0f, 0f, 0f, 0.03137255f),
			renderingPath = RenderingPath.VertexLit,
			occlusionCulling = false,
			farClipPlane = 100f,
			forceCameraPos = new Vector3(0.05f, 0.1f, 0.05f)
		};
		int num = 1 << LayerMask.NameToLayer("UI");
		defaultRenderLayer = new RenderLayer
		{
			layerBits = ~(blurMapRenderLayer.layerBits | examinerMaskRenderLayer.layerBits | skyRenderLayer.layerBits | num),
			clearFlags = CameraClearFlags.Depth,
			renderingPath = RenderingPath.DeferredLighting,
			occlusionCulling = true,
			farClipPlane = 50f
		};
		string[] names = Enum.GetNames(typeof(DebugLinedRenderMode));
		for (int num2 = 0; num2 < names.Length - 1; num2++)
		{
			DebugLinedRenderMode d = (DebugLinedRenderMode)num2;
			DebugMenu.Add(string.Format("Post/{0:00} {1}", num2, names[num2]), KeyCode.None, delegate
			{
				SetDebugLinedRenderMode(d);
			});
		}
		styles.Add(StyleId.Default, delegate(Style.Rt rt)
		{
			RunErrorDiffusionAndResolve(rt.scene, rt.temp0);
			RenderTarget.Blit(rt.temp0, rt.final);
		}).EnableDitherShift();
		styles.Add(StyleId.Upscale, delegate(Style.Rt rt)
		{
			materials.post.EnableKeyword("FINALIZELINED_RESOLVE_UPSCALE");
			using (RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(rt.scene, 2.0))
			{
				RenderTargetPool.Temp temp2 = temp;
				RenderTexture final = rt.final;
				RenderTarget.Blit(rt.scene, temp2, materials.lineScale2x, 0);
				RenderTarget.Blit((RenderTexture)temp2, final, materials.lineScale2x, 1);
				materials.lineScale2x.SetTexture("_SceneLoTex", rt.scene);
				RenderTarget.Blit(final, temp2, materials.lineScale2x, 2);
				materials.lineScale2x.SetTexture("_SceneLoTex", null);
				RenderTarget.Blit((RenderTexture)temp2, final, materials.post, 1);
			}
			materials.post.DisableKeyword("FINALIZELINED_RESOLVE_UPSCALE");
		}).SetFinalScale(2f).EnableWarpUseSphereMapping();
		styles.Add(StyleId.Debug, delegate(Style.Rt rt)
		{
			RenderTarget.Blit(rt.scene, rt.temp0, materials.post, 0);
			materials.post.SetTexture("_SceneTex", rt.scene);
			materials.post.SetTexture("_BlurMapTex", rt.blurMap);
			materials.post.SetInt("_DebugMode", (int)debugLinedRenderMode);
			RenderTarget.Blit(rt.temp0, rt.scene, materials.post, 3);
			RenderTarget.Blit(rt.scene, rt.final);
		}).DisableDefaultLinedProcessing();
		styles.Add(StyleId.Default_ForTexture, delegate(Style.Rt rt)
		{
			RenderTarget.Blit(rt.scene, rt.temp0, materials.post, 0);
			materials.post.SetTexture("_SceneTex", rt.scene);
			materials.post.SetInt("_DebugMode", 12);
			RenderTarget.Blit(rt.temp0, rt.scene, materials.post, 3);
			RenderTarget.Blit(rt.scene, rt.final);
		}).DisableDefaultLinedProcessing();
		styles.Add(StyleId.Upscale_ForTexture, styles.Find(StyleId.Default_ForTexture).applyFunc).DisableDefaultLinedProcessing();
	}

	private void SetDebugLinedRenderMode(DebugLinedRenderMode d)
	{
		if (debugLinedRenderMode == d)
		{
			debugLinedRenderMode = DebugLinedRenderMode.None;
		}
		else
		{
			debugLinedRenderMode = d;
		}
	}

	private void RefreshMaterials()
	{
		materials = new Materials(mode, assets, clearing, linedSettings);
	}

	private void OnEnable()
	{
		if (materials == null)
		{
			RefreshMaterials();
		}
		Util.ClearRenderTexture(assets.overlayTexture, new Color(0f, 0f, 0f, 0f));
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown((!Application.isEditor) ? KeyCode.P : KeyCode.O))
		{
			ScreenCap.TakeScreenshot();
		}
	}

	public void RenderForMonitor(RenderTarget final)
	{
		Style style = styles.Find(defaultStyleId);
		final.SetSize(Mathf.RoundToInt(style.finalScale * (float)Resolution.bufferW), Mathf.RoundToInt(style.finalScale * (float)Resolution.bufferH));
		Render(final, style.id);
	}

	public void RenderForTarget(RenderTarget final)
	{
		StyleId id = ((!Settings.outputModeIsUpscaled) ? StyleId.Default_ForTexture : StyleId.Upscale_ForTexture);
		Style style = styles.Find(id);
		final.SetSize(Mathf.RoundToInt(style.finalScale * (float)Resolution.bufferW), Mathf.RoundToInt(style.finalScale * (float)Resolution.bufferH));
		Render(final, style.id);
	}

	public void RenderForTexture(RenderTexture final)
	{
		Render(final, StyleId.Default_ForTexture);
	}

	private static Vector3 GetViewportCorner(Camera cam, Matrix4x4 rot, Vector2 viewportPos)
	{
		Vector3 direction = cam.ViewportPointToRay(viewportPos.ToVector3XY(0f)).direction;
		Vector3 vector = direction / Vector3.Dot(direction, cam.transform.forward);
		return rot.MultiplyVector(vector);
	}

	private static Vector2 Lerp(Vector2 a, Vector2 b, float ta, float tb)
	{
		return new Vector2(Mathf.Lerp(a.x, b.x, ta), Mathf.Lerp(a.y, b.y, tb));
	}

	private Matrix4x4 GetViewportCornersAsMatrix(Camera cam)
	{
		return GetViewportCornersAsMatrix(cam, Vector2.zero, Vector2.one);
	}

	private Matrix4x4 GetViewportCornersAsMatrix(Camera cam, Vector2 viewport0, Vector2 viewport1)
	{
		Matrix4x4 result = default(Matrix4x4);
		Matrix4x4 rot = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(linedSettings.ditherPoleRotation + 36f, 0f, 0f), Vector3.one);
		result.SetRow(0, GetViewportCorner(cam, rot, Lerp(viewport0, viewport1, 0f, 0f)));
		result.SetRow(1, GetViewportCorner(cam, rot, Lerp(viewport0, viewport1, 1f, 0f)));
		result.SetRow(2, GetViewportCorner(cam, rot, Lerp(viewport0, viewport1, 0f, 1f)));
		result.SetRow(3, GetViewportCorner(cam, rot, Lerp(viewport0, viewport1, 1f, 1f)));
		return result;
	}

	private static Vector2 GetDitherOffset(Camera cam)
	{
		Vector2 vector = new Vector2(cam.fieldOfView * 1.7777778f * (float)Math.PI / 180f, cam.fieldOfView * (float)Math.PI / 180f);
		Vector3 forward = cam.transform.forward;
		float num = Mathf.Atan2(forward.z, forward.x);
		float num2 = Mathf.Acos(forward.y);
		return new Vector2((0f - num) / vector.x, (0f - num2) / vector.y);
	}

	private void Render(RenderTexture final, StyleId styleId)
	{
		Style style = styles.Find(styleId);
		if (style == null)
		{
			throw new UnityException(string.Format("Style not found: {0}", styleId));
		}
		sourceCamera.enabled = false;
		Vector2 vector = new Vector2(sourceCamera.fieldOfView * 1.7777778f * (float)Math.PI / 180f, sourceCamera.fieldOfView * (float)Math.PI / 180f);
		Shader.SetGlobalVector("Global_OneBit_CameraDir", sourceCamera.transform.localToWorldMatrix.GetZ());
		Shader.SetGlobalVector("Global_OneBit_CameraPos", sourceCamera.transform.position);
		Shader.SetGlobalVector("Global_OneBit_CameraFov", vector);
		Shader.SetGlobalFloat("Global_OneBit_Time", (!Game.isInMoment) ? Clock.play.time : 20f);
		Shader.SetGlobalVector("Global_BufferSize", new Vector4(style.sceneScale * (float)Resolution.bufferW, style.sceneScale * (float)Resolution.bufferH, style.finalScale * (float)Resolution.bufferW, style.finalScale * (float)Resolution.bufferH));
		Shader.SetGlobalVector("Global_BufferSize_Dust", style.sceneScale / style.dustScale * new Vector2(Resolution.bufferW, Resolution.bufferH));
		Shader.SetGlobalVector("_RealTime", new Vector4(Time.realtimeSinceStartup / 20f, Time.realtimeSinceStartup, Time.realtimeSinceStartup * 2f, Time.realtimeSinceStartup * 3f));
		Shader.SetGlobalTexture("_DitherTex", assets.ditherTexture);
		Shader.SetGlobalVector("_HumanAmbientLight", new Vector4(0.5f, 0.5f * linedSettings.brightenClothes, 0f, 0f));
		if (mode == Mode.Basic)
		{
			Shader.SetGlobalVector("_DitherOffset", basicSettings.ditherOffset);
			bool flag = basicSettings.allowOverlay && overlayIsVisible;
			using (RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(style.sceneScale, true))
			{
				materials.post.SetFloat("_OverlayOn", (!flag) ? 0f : 1f);
				if (flag)
				{
					materials.post.SetTexture("_OverlayTex", assets.overlayTexture);
				}
				sourceCamera.targetTexture = temp;
				sourceCamera.Render();
				styleRt.scene = temp;
				styleRt.final = final;
				style.Apply(styleRt);
				sourceCamera.targetTexture = null;
				materials.post.SetTexture("_OverlayTex", null);
				return;
			}
		}
		Vector2 vector2 = ((!style.ditherShiftEnabled) ? Vector2.zero : GetDitherOffset(sourceCamera));
		Shader.SetGlobalVector("_DitherOffset", vector2);
		bool flag2 = (linedSettings.examine || overlayIsVisible || linedSettings.preOverlayCamera != null) && !linedSettings.nether && linedSettings.soloLayerBits == 0;
		using (RenderTargetPool.Temp temp2 = RenderTargetPool.CreateTemp(style.sceneScale, true))
		{
			using (RenderTargetPool.Temp temp3 = RenderTargetPool.CreateTemp(0.3f * style.sceneScale, true))
			{
				using (RenderTargetPool.Temp temp4 = ((!flag2) ? null : RenderTargetPool.CreateTemp(assets.overlayTexture)))
				{
					using (RenderTargetPool.Temp temp5 = ((!linedSettings.examine) ? null : RenderTargetPool.CreateTemp(style.sceneScale)))
					{
						if (Player.instance != null)
						{
							Player.instance.UpdateMainCameraFrustumPlanes();
							Plane[] mainCameraFrustumPlanes = Player.instance.mainCameraFrustumPlanes;
							Shader.SetGlobalVector("_CameraFrustumPlane0", mainCameraFrustumPlanes[0].normal.ToVector4(mainCameraFrustumPlanes[0].distance));
							Shader.SetGlobalVector("_CameraFrustumPlane1", mainCameraFrustumPlanes[1].normal.ToVector4(mainCameraFrustumPlanes[1].distance));
							Shader.SetGlobalVector("_CameraFrustumPlane2", mainCameraFrustumPlanes[2].normal.ToVector4(mainCameraFrustumPlanes[2].distance));
							Shader.SetGlobalVector("_CameraFrustumPlane3", mainCameraFrustumPlanes[3].normal.ToVector4(mainCameraFrustumPlanes[3].distance));
							Shader.SetGlobalVector("_CameraFrustumPlane4", mainCameraFrustumPlanes[4].normal.ToVector4(mainCameraFrustumPlanes[4].distance));
							Shader.SetGlobalVector("_CameraFrustumPlane5", mainCameraFrustumPlanes[5].normal.ToVector4(mainCameraFrustumPlanes[5].distance));
						}
						if (linedSettings.soloLayerBits != 0)
						{
							defaultRenderLayer.Render(sourceCamera, temp2, false, linedSettings.soloLayerBits);
						}
						else
						{
							blurMapRenderLayer.Render(sourceCamera, temp3, linedSettings.nether);
							if (temp5 != null)
							{
								examinerMaskRenderLayer.Render(sourceCamera, temp5);
							}
							skyRenderLayer.Render(sourceCamera, temp2);
							defaultRenderLayer.Render(sourceCamera, temp2);
						}
						Vector4 clipPlanes = defaultRenderLayer.GetClipPlanes(sourceCamera);
						float x = clipPlanes.x;
						float y = clipPlanes.y;
						Shader.SetGlobalVector("_CustomZBufferParams", new Vector4(1f - y / x, y / x, (1f - y / x) / y, y / x / y));
						Shader.SetGlobalMatrix("_ViewProjInv", defaultRenderLayer.GetViewProj(sourceCamera).inverse);
						Shader.SetGlobalVector("_CustomWorldCameraPos", sourceCamera.transform.position);
						Shader.SetGlobalMatrix("_DitherSphereCorners", GetViewportCornersAsMatrix(sourceCamera));
						if (style.defaultLinedProcessing)
						{
							using (RenderTargetPool.Temp temp6 = RenderTargetPool.CreateTemp(temp2))
							{
								RenderTargetPool.Temp a = temp2;
								RenderTargetPool.Temp b = temp6;
								RenderTarget.Blit((RenderTexture)a, b, materials.post, 0);
								Util.Swap(ref a, ref b);
								if (linedSettings.distortFringe)
								{
									RenderTarget.Blit((RenderTexture)a, b, materials.distortVignette);
									Util.Swap(ref a, ref b);
								}
								if (linedSettings.sparkle)
								{
									if (linedSettings.sparkleTestDepth)
									{
										materials.sparkle.EnableKeyword("SPARKLE_TESTDEPTH");
									}
									else
									{
										materials.sparkle.DisableKeyword("SPARKLE_TESTDEPTH");
									}
									materials.sparkle.SetVector("_SparkleParams0", linedSettings.sparkleParams0);
									materials.sparkle.SetVector("_SparkleParams1", linedSettings.sparkleParams1);
									RenderTarget.Blit((RenderTexture)a, b);
									RenderTarget.Blit((RenderTexture)a, b, materials.sparkle);
									Util.Swap(ref a, ref b);
								}
								if (linedSettings.applyHumanGlow && !linedSettings.nether)
								{
									using (RenderTargetPool.Temp temp7 = RenderTargetPool.CreateTemp(temp2))
									{
										RenderTarget.Blit((RenderTexture)a, temp7, materials.glow, 0);
										using (RenderTargetPool.Temp temp8 = gaussianBlur.BlurToTemp(temp7, 0.25f, 1.5f, 2))
										{
											materials.glow.SetTexture("_GlowMaskTex", (RenderTexture)temp7);
											materials.glow.SetTexture("_GlowBlurTex", (RenderTexture)temp8);
											RenderTarget.Blit((RenderTexture)a, b, materials.glow, 1);
											Util.Swap(ref a, ref b);
										}
									}
								}
								if (flag2)
								{
									if (linedSettings.examine && !overlayIsVisible && linedSettings.soloLayerBits == 0)
									{
										using (RenderTargetPool.Temp temp9 = gaussianBlur.BlurToTemp(temp5, materials.examineBlurParams))
										{
											materials.examinerPost.SetTexture("_ExaminerMaskTex", (RenderTexture)temp5);
											materials.examinerPost.SetTexture("_ExaminerMaskBlurTex", (RenderTexture)temp9);
											materials.examinerPost.SetVector("_Reveal", linedSettings.examineReveal);
											RenderTarget.Blit(assets.overlayTexture, temp4, materials.examinerPost, 0);
										}
									}
									else
									{
										RenderTarget.Blit(assets.overlayTexture, temp4);
									}
									if (linedSettings.preOverlayCamera != null && linedSettings.soloLayerBits == 0)
									{
										if (!linedSettings.examine)
										{
											Util.ClearRenderTexture(temp4, Color.clear);
										}
										RenderTexture targetTexture = linedSettings.preOverlayCamera.targetTexture;
										linedSettings.preOverlayCamera.targetTexture = temp4;
										linedSettings.preOverlayCamera.Render();
										linedSettings.preOverlayCamera.targetTexture = targetTexture;
									}
									Shader.SetGlobalVector("_DitherOffset", linedSettings.examineDitherOffset);
									using (RenderTargetPool.Temp temp10 = RenderTargetPool.CreateTemp(temp4))
									{
										using (RenderTargetPool.Temp temp11 = RenderTargetPool.CreateTemp(temp4))
										{
											RenderTarget.Blit((RenderTexture)temp4, temp10, materials.sharpenOverlay);
											RunErrorDiffusion(temp10, temp11, SourceChannel.B);
											RenderTarget.Blit((RenderTexture)temp11, temp10);
										}
										materials.post.SetTexture("_OverlayTex", (RenderTexture)temp4);
										materials.post.SetTexture("_OverlayDiffusionDitheredTex", (RenderTexture)temp10);
										bool flag3 = linedSettings.preOverlayCamera != null || (linedSettings.examine && !overlayIsVisible) || linedSettings.translucentOverlay;
										materials.post.SetFloat("_OverlayEnableTranslucent", (!flag3) ? 0f : 1f);
										RenderTarget.Blit((RenderTexture)a, b, materials.post, 2);
										Util.Swap(ref a, ref b);
										materials.post.SetTexture("_OverlayTex", null);
									}
									Shader.SetGlobalVector("_DitherOffset", vector2);
								}
								if (!overlayIsVisible && linedSettings.shipEnderT > 0f)
								{
									materials.shipEnder.SetFloat("_ShipEnderT", linedSettings.shipEnderT);
									Graphics.Blit(Texture2D.whiteTexture, a, materials.shipEnder);
								}
								styleRt.scene = a;
								styleRt.temp0 = b;
								styleRt.blurMap = temp3;
								styleRt.final = final;
								style.Apply(styleRt);
							}
							using (RenderTargetPool.Temp temp12 = RenderTargetPool.CreateTemp(final))
							{
								if (linedSettings.watchHandOnly)
								{
									RenderTarget.Blit(final, temp12, materials.watchHandOnly);
								}
								else if (linedSettings.nether)
								{
									materials.warpNether.SetVector("_NetherCenter", linedSettings.netherCenter);
									materials.warpNether.SetVector("_NetherRingEdges", linedSettings.netherRingEdges);
									materials.warpNether.SetFloat("_NetherPulseDist", linedSettings.netherPulseDist);
									materials.warpNether.SetTexture("_BlurMapTex", (RenderTexture)temp3);
									RenderTarget.Blit(final, temp12, materials.warpNether);
								}
								else
								{
									if (style.warpUseSphereMapping)
									{
										materials.warpDefault.EnableKeyword("WARPDEFAULT_SPHEREMAPPING");
									}
									else
									{
										materials.warpDefault.DisableKeyword("WARPDEFAULT_SPHEREMAPPING");
									}
									materials.warpDefault.SetTexture("_BlurMapTex", (RenderTexture)temp3);
									RenderTarget.Blit(final, temp12, materials.warpDefault);
								}
								if (linedSettings.curtainSettings.t > 0f)
								{
									using (RenderTargetPool.Temp temp13 = gaussianBlur.BlurToTemp(temp12, 0.25f))
									{
										materials.curtain.SetTexture("_MainBlurTex", (RenderTexture)temp13);
										materials.curtain.SetVector("_CurtainParams0", linedSettings.curtainSettings.GetParams0(sourceCamera));
										materials.curtain.SetFloat("_CurtainParams1", linedSettings.curtainSettings.GetParams1());
										RenderTarget.Blit((RenderTexture)temp12, final, materials.curtain);
										materials.curtain.SetTexture("_MainBlurTex", null);
										return;
									}
								}
								RenderTarget.Blit((RenderTexture)temp12, final);
								return;
							}
						}
						using (RenderTargetPool.Temp temp14 = RenderTargetPool.CreateTemp(temp2))
						{
							styleRt.scene = temp2;
							styleRt.temp0 = temp14;
							styleRt.blurMap = temp3;
							styleRt.final = final;
							style.Apply(styleRt);
						}
					}
				}
			}
		}
	}

	private static Vector4 GetSourceChannelAsVector(SourceChannel sourceChannel)
	{
		switch (sourceChannel)
		{
		case SourceChannel.R:
			return Vector3.right;
		case SourceChannel.G:
			return Vector3.up;
		default:
			return Vector3.forward;
		}
	}

	private void RunErrorDiffusionAndResolve(RenderTexture scene, RenderTexture target, SourceChannel sourceChannel = SourceChannel.R)
	{
		if (wantDiffusion)
		{
			using (RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(scene))
			{
				RunErrorDiffusion(scene, temp, sourceChannel);
				materials.post.EnableKeyword("FINALIZELINED_RESOLVE_DIFFUSION");
				materials.post.SetTexture("_DiffusionResultTex", (RenderTexture)temp);
				RenderTarget.Blit(scene, target, materials.post, 1);
				materials.post.SetTexture("_DiffusionResultTex", null);
				return;
			}
		}
		materials.post.DisableKeyword("FINALIZELINED_RESOLVE_DIFFUSION");
		RenderTarget.Blit(scene, target, materials.post, 1);
	}

	private void RunErrorDiffusion(RenderTexture src, RenderTexture dst, SourceChannel sourceChannel = SourceChannel.R)
	{
		materials.wernessClassic.SetVector("_SourceMask", GetSourceChannelAsVector(sourceChannel));
		using (RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(src))
		{
			RenderTarget.Blit(src, dst, materials.wernessClassic, 0);
			for (int i = 0; i < 11; i++)
			{
				materials.wernessClassic.SetInt("_Step", i % 5);
				if ((i & 1) == 0)
				{
					RenderTarget.Blit(dst, temp, materials.wernessClassic, 1);
				}
				else
				{
					RenderTarget.Blit((RenderTexture)temp, dst, materials.wernessClassic, 1);
				}
			}
		}
	}
}
