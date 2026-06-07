using System;
using System.Collections;
using DV.Utils;
using I2.Loc;
using PlaceholderSoftware.WetStuff;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DV.VFX
{
	public class CameraGraphicsUpdater : MonoBehaviour
	{
		private const int WETNESS_INDEX = 1;

		private const int RIPPLES_INDEX = 2;

		public bool isGameCam;

		private PostProcessLayer postProcessLayer;

		private Coroutine coro;

		private Camera cam;

		private WetStuff wetStuff;

		private RainRipples rainRipples;

		public bool ExpectedDisable { get; set; }

		private GraphicsOptions.AntiAliasingForward ForwardAntiAliasingLevel
		{
			get
			{
				int num = GamePreferences.Get<int>(Preferences.AntiAliasingForwardLevelsIndex);
				if (!Enum.IsDefined(typeof(GraphicsOptions.AntiAliasingForward), num))
				{
					return GraphicsOptions.AntiAliasingForward.OFF;
				}
				return (GraphicsOptions.AntiAliasingForward)num;
			}
		}

		public static GraphicsOptions.AntiAliasingDeferred DeferredAntiAliasingMode
		{
			get
			{
				int num = GamePreferences.Get<int>(Preferences.AntiAliasingDeferredLevelsIndex);
				if (!Enum.IsDefined(typeof(GraphicsOptions.AntiAliasingDeferred), num))
				{
					return GraphicsOptions.AntiAliasingDeferred.OFF;
				}
				return (GraphicsOptions.AntiAliasingDeferred)num;
			}
		}

		private void Awake()
		{
			cam = GetComponent<Camera>();
			wetStuff = GetComponent<WetStuff>();
			rainRipples = GetComponent<RainRipples>();
			postProcessLayer = GetComponent<PostProcessLayer>();
			SetupListeners(on: true);
			UpdateSettings();
			OnRainQualityChanged();
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (ExpectedDisable)
				{
					ExpectedDisable = false;
				}
				else
				{
					Debug.LogError("[!!!] Camera is getting disabled unexpectedly, this should not happen! Path: " + base.gameObject.transform.GetPath());
				}
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				Debug.LogError("[!!!] Camera is getting destroyed, this should not happen! Path: " + base.gameObject.transform.GetPath());
			}
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				GamePreferences.RegisterToPreferenceUpdated(Preferences.AntiAliasingDeferredLevelsIndex, OnPreferenceUpdated);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.AntiAliasingForwardLevelsIndex, OnPreferenceUpdated);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.RainQualityIndex, OnRainQualityChanged);
				if ((bool)SingletonBehaviour<WorldMover>.Instance)
				{
					SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld += OnWorldAboutToMove;
				}
				SingletonBehaviour<GraphicsOptions>.Instance.OnForwardRenderingChanged += OnPreferenceUpdated;
				return;
			}
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.AntiAliasingDeferredLevelsIndex, OnPreferenceUpdated);
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.AntiAliasingForwardLevelsIndex, OnPreferenceUpdated);
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RainQualityIndex, OnRainQualityChanged);
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld -= OnWorldAboutToMove;
			}
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<GraphicsOptions>.Instance.OnForwardRenderingChanged -= OnPreferenceUpdated;
			}
		}

		private void OnWorldAboutToMove(Vector3 newOffset, Vector3 moveVector)
		{
			if ((bool)postProcessLayer)
			{
				postProcessLayer.ResetHistory();
			}
		}

		private void OnPreferenceUpdated()
		{
			if (coro == null)
			{
				coro = StartCoroutine(UpdateAtEndOfFrame());
			}
		}

		private void OnRainQualityChanged()
		{
			int num = GamePreferences.Get<int>(Preferences.RainQualityIndex);
			if ((bool)wetStuff)
			{
				wetStuff.enabled = num > 1;
			}
			if ((bool)rainRipples)
			{
				rainRipples.enabled = num > 2;
			}
		}

		private IEnumerator UpdateAtEndOfFrame()
		{
			yield return WaitFor.EndOfFrame;
			coro = null;
			UpdateSettings();
		}

		private void UpdateSettings()
		{
			if (isGameCam)
			{
				bool isForwardRendering = SingletonBehaviour<GraphicsOptions>.Instance.IsForwardRendering;
				cam.allowHDR = isForwardRendering || !VRManager.IsVREnabled();
				cam.renderingPath = (isForwardRendering ? RenderingPath.Forward : RenderingPath.DeferredShading);
				UpdateAntiAliasing();
			}
			else
			{
				cam.allowHDR = false;
				cam.renderingPath = RenderingPath.Forward;
				cam.allowMSAA = false;
			}
			SingletonBehaviour<CoroutineManager>.Instance.Run(OnPostProcessingRelatedChangesUpdateAtEndOfFrameCoro());
		}

		private void UpdateAntiAliasing()
		{
			if (isGameCam)
			{
				if (SingletonBehaviour<GraphicsOptions>.Instance.IsForwardRendering)
				{
					QualitySettings.antiAliasing = (new int[4] { 0, 2, 4, 8 })[(int)ForwardAntiAliasingLevel];
					SetAADeferredMode(GraphicsOptions.AntiAliasingDeferred.OFF);
				}
				else
				{
					SetAADeferredMode(DeferredAntiAliasingMode);
					QualitySettings.antiAliasing = 0;
				}
			}
		}

		private IEnumerator OnPostProcessingRelatedChangesUpdateAtEndOfFrameCoro()
		{
			yield return WaitFor.EndOfFrame;
			if (SingletonBehaviour<GraphicsOptions>.Instance.IsForwardRendering)
			{
				cam.depthTextureMode = DepthTextureMode.None;
				yield break;
			}
			if (!SingletonBehaviour<GraphicsOptions>.Instance.IsSSAOOn)
			{
				cam.depthTextureMode &= ~DepthTextureMode.DepthNormals;
			}
			if (DeferredAntiAliasingMode != GraphicsOptions.AntiAliasingDeferred.TAA)
			{
				cam.depthTextureMode &= ~DepthTextureMode.MotionVectors;
			}
			bool wasEnabled = cam.enabled;
			cam.enabled = false;
			yield return null;
			cam.enabled = wasEnabled;
		}

		private void SetAADeferredMode(GraphicsOptions.AntiAliasingDeferred mode)
		{
			if (postProcessLayer == null)
			{
				Debug.LogError("PostProcessLayer not present on player camera, can't update antialiasing");
				return;
			}
			switch (mode)
			{
			case GraphicsOptions.AntiAliasingDeferred.OFF:
				postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
				break;
			case GraphicsOptions.AntiAliasingDeferred.TAA:
				postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
				break;
			case GraphicsOptions.AntiAliasingDeferred.FXAA:
				postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
				break;
			case GraphicsOptions.AntiAliasingDeferred.SMAA:
				postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
				break;
			default:
				Debug.LogError(string.Format("Unhandled {0} value {1}, using 'off'", "AntiAliasingDeferred", mode));
				postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
				break;
			}
		}
	}
}
