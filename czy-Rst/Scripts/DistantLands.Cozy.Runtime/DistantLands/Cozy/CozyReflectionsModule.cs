using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyReflectionsModule : CozyModule
	{
		public enum UpdateFrequency
		{
			everyFrame = 0,
			onAwake = 1,
			onHour = 2,
			viaScripting = 3
		}

		[CozySearchable(new string[] { "Reflection" })]
		public UpdateFrequency updateFrequency;

		[CozySearchable(new string[] { })]
		public Cubemap reflectionCubemap;

		public Camera reflectionCamera;

		[Tooltip("How many frames should pass before the cubemap renders again? A value of 0 renders every frame and a value of 30 renders once every 30 frames.")]
		[Range(0f, 30f)]
		[CozySearchable(new string[] { })]
		public int framesBetweenRenders = 10;

		[Tooltip("What layers should be rendered into the skybox reflections?.")]
		[CozySearchable(new string[] { })]
		public LayerMask layerMask = 2;

		public bool automaticallySetLayer;

		private int framesLeft;

		public int minimumQualityLevel;

		[Tooltip("Refresh the skybox reflections when the scene loads or unloads.")]
		[CozySearchable(new string[] { })]
		public bool refreshOnSceneChange;

		public int rendererOverride;

		public override void InitializeModule()
		{
			base.InitializeModule();
			reflectionCubemap = Resources.Load("Materials/Reflection Cubemap") as Cubemap;
			RenderSettings.customReflectionTexture = reflectionCubemap;
			RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
			if (automaticallySetLayer)
			{
				base.weatherSphere.fogMesh.gameObject.layer = ToLayer(layerMask);
				base.weatherSphere.skyMesh.gameObject.layer = ToLayer(layerMask);
				base.weatherSphere.cloudMesh.gameObject.layer = ToLayer(layerMask);
			}
			if (updateFrequency == UpdateFrequency.onAwake || updateFrequency == UpdateFrequency.onHour)
			{
				RenderReflections();
			}
			if (updateFrequency == UpdateFrequency.onHour)
			{
				CozyWeather.Events.onNewHour += RenderReflections;
			}
		}

		public override void CozyUpdateLoop()
		{
			if (base.weatherSphere == null)
			{
				base.InitializeModule();
			}
			if ((!CozyWeather.FreezeUpdateInEditMode || Application.isPlaying) && updateFrequency == UpdateFrequency.everyFrame)
			{
				if (framesLeft < 0)
				{
					RenderReflections();
					framesLeft = framesBetweenRenders;
				}
				else
				{
					framesLeft--;
				}
			}
		}

		public override void OnSceneLoaded()
		{
			RefreshReflectionsOnSceneChange();
		}

		public override void OnSceneUnloaded()
		{
			RefreshReflectionsOnSceneChange();
		}

		protected void RefreshReflectionsOnSceneChange()
		{
			if (refreshOnSceneChange)
			{
				RenderReflections();
			}
		}

		public int ToLayer(LayerMask mask)
		{
			int value = mask.value;
			if (value == 0)
			{
				return 0;
			}
			for (int i = 1; i < 32; i++)
			{
				if ((value & (1 << i)) != 0)
				{
					return i;
				}
			}
			return -1;
		}

		public override void DeinitializeModule()
		{
			base.DeinitializeModule();
			if ((bool)reflectionCamera)
			{
				Object.DestroyImmediate(reflectionCamera.gameObject);
			}
			if (updateFrequency == UpdateFrequency.onHour)
			{
				CozyWeather.Events.onNewHour -= RenderReflections;
			}
			RenderSettings.customReflectionTexture = null;
		}

		public void RenderReflections()
		{
			if (QualitySettings.GetQualityLevel() < minimumQualityLevel || reflectionCubemap == null)
			{
				return;
			}
			if (!base.weatherSphere.cozyCamera)
			{
				Debug.LogError("COZY Reflections requires the cozy camera to be set in the settings tab!");
				return;
			}
			if (reflectionCamera == null)
			{
				SetupCamera();
			}
			reflectionCamera.enabled = true;
			reflectionCamera.transform.position = base.transform.position;
			reflectionCamera.nearClipPlane = base.weatherSphere.cozyCamera.nearClipPlane;
			reflectionCamera.farClipPlane = base.weatherSphere.cozyCamera.farClipPlane;
			reflectionCamera.cullingMask = layerMask;
			if ((bool)reflectionCamera.GetComponent<UniversalAdditionalCameraData>())
			{
				reflectionCamera.GetComponent<UniversalAdditionalCameraData>().SetRenderer(rendererOverride);
			}
			reflectionCamera.RenderToCubemap(reflectionCubemap);
			reflectionCamera.enabled = false;
		}

		public void SetupCamera()
		{
			GameObject gameObject = new GameObject
			{
				name = "COZY Reflection Camera",
				hideFlags = (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild)
			};
			reflectionCamera = gameObject.AddComponent<Camera>();
			reflectionCamera.depth = -50f;
			reflectionCamera.enabled = false;
		}
	}
}
