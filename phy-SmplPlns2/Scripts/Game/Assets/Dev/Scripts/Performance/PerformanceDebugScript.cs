using System;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Environment.Roads;
using Assets.Scripts.Environment.Vegetation;
using Assets.Scripts.Flight;
using Assets.Scripts.Rendering;
using Enviro;
using GPUInstancerPro.TerrainModule;
using JBooth.MicroSplat;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest;

namespace Assets.Dev.Scripts.Performance
{
	public class PerformanceDebugScript : MonoBehaviour
	{
		private class CarSettings
		{
			private CarSpawnerScript _carSpawner;

			public void Draw()
			{
				_carSpawner = ((_carSpawner != null) ? _carSpawner : UnityEngine.Object.FindAnyObjectByType<CarSpawnerScript>(FindObjectsInactive.Include));
				if (_carSpawner == null)
				{
					return;
				}
				GUILayout.Label("Car Settings");
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Enabled:", GUILayout.Width(120f));
					_carSpawner.gameObject.SetActive(GUILayout.Toggle(_carSpawner.gameObject.activeSelf, string.Empty));
				}
			}
		}

		private class CrestSettings
		{
			private WaterRenderer _waterRenderer;

			public void Draw()
			{
				_waterRenderer = ((_waterRenderer != null) ? _waterRenderer : UnityEngine.Object.FindAnyObjectByType<WaterRenderer>(FindObjectsInactive.Include));
				if (_waterRenderer == null)
				{
					return;
				}
				GUILayout.Label("Crest Settings");
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Enabled:", GUILayout.Width(120f));
					_waterRenderer.enabled = GUILayout.Toggle(_waterRenderer.enabled, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Animated Waves:", GUILayout.Width(120f));
					_waterRenderer.AnimatedWavesLod.Enabled = GUILayout.Toggle(_waterRenderer.AnimatedWavesLod.Enabled, string.Empty);
				}
				ShapeFFT componentInChildren = _waterRenderer.GetComponentInChildren<ShapeFFT>(includeInactive: true);
				if (componentInChildren != null)
				{
					using (new GUILayout.HorizontalScope())
					{
						GUILayout.Space(15f);
						GUILayout.Label("ShapeFFT:", GUILayout.Width(120f));
						componentInChildren.enabled = GUILayout.Toggle(componentInChildren.enabled, string.Empty);
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Caustics:", GUILayout.Width(120f));
					_waterRenderer.Surface.Material.SetFloat("_Crest_CausticsEnabled", GUILayout.Toggle(_waterRenderer.Surface.Material.GetFloat("_Crest_CausticsEnabled") == 1f, string.Empty) ? 1 : 0);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Normal Maps:", GUILayout.Width(120f));
					_waterRenderer.Surface.Material.SetFloat("_Crest_NormalMapEnabled", GUILayout.Toggle(_waterRenderer.Surface.Material.GetFloat("_Crest_NormalMapEnabled") == 1f, string.Empty) ? 1 : 0);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Foam:", GUILayout.Width(120f));
					_waterRenderer.FoamLod.Enabled = GUILayout.Toggle(_waterRenderer.FoamLod.Enabled, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Dynamic Waves:", GUILayout.Width(120f));
					_waterRenderer.DynamicWavesLod.Enabled = GUILayout.Toggle(_waterRenderer.DynamicWavesLod.Enabled, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Flow:", GUILayout.Width(120f));
					_waterRenderer.FlowLod.Enabled = GUILayout.Toggle(_waterRenderer.FlowLod.Enabled, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Depth:", GUILayout.Width(120f));
					_waterRenderer.DepthLod.Enabled = GUILayout.Toggle(_waterRenderer.DepthLod.Enabled, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("LOD Levels:", GUILayout.Width(120f));
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						_waterRenderer.LodLevels = (int)GUILayout.HorizontalSlider(_waterRenderer.LodLevels, 2f, 9f, GUILayout.Width(120f));
					}
					GUILayout.Label($"   {_waterRenderer.LodLevels}", GUILayout.Width(20f));
					GUILayout.FlexibleSpace();
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Disable Shader", GUILayout.Width(120f));
					string text = "Crest/WaterEnviro";
					bool flag = _waterRenderer.Surface.Material.shader?.name != text;
					bool flag2 = GUILayout.Toggle(flag, string.Empty);
					if (flag2 != flag)
					{
						_waterRenderer.Surface.Material.shader = (flag2 ? null : Shader.Find(text));
					}
				}
			}
		}

		private class EnviroSettings
		{
			private GUIStyle _noWordWrapLabel;

			public void Draw()
			{
				EnviroManager instance = EnviroManager.instance;
				if (instance == null)
				{
					return;
				}
				if (_noWordWrapLabel == null)
				{
					_noWordWrapLabel = new GUIStyle(GUI.skin.label);
					_noWordWrapLabel.wordWrap = false;
				}
				GUILayout.Label("Enviro Settings");
				EnviroQualities settings = instance.Quality.Settings;
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Quality Level:", GUILayout.Width(120f));
					int num = settings.Qualities.IndexOf(settings.defaultQuality);
					if (num < 0)
					{
						num = 0;
					}
					int num2 = num;
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						num = (int)GUILayout.HorizontalSlider(num, 0f, settings.Qualities.Count - 1, GUILayout.Width(100f));
					}
					if (num != num2)
					{
						settings.defaultQuality = settings.Qualities[num];
					}
					GUILayout.Label("   " + settings.defaultQuality.name, _noWordWrapLabel, GUILayout.Width(80f));
					GUILayout.FlexibleSpace();
				}
				EnviroVolumetricCloudsQualitySettings volumetricCloudsOverride = settings.defaultQuality.volumetricCloudsOverride;
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Volumetric Clouds:", GUILayout.Width(120f));
					volumetricCloudsOverride.volumetricClouds = GUILayout.Toggle(volumetricCloudsOverride.volumetricClouds, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Downsampling:", GUILayout.Width(120f));
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						volumetricCloudsOverride.downsampling = (int)GUILayout.HorizontalSlider(volumetricCloudsOverride.downsampling, 1f, 6f, GUILayout.Width(100f));
					}
					GUILayout.Label($"   {volumetricCloudsOverride.downsampling}", _noWordWrapLabel, GUILayout.Width(80f));
					GUILayout.FlexibleSpace();
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Steps (L1):", GUILayout.Width(120f));
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						volumetricCloudsOverride.stepsLayer1 = (int)GUILayout.HorizontalSlider(volumetricCloudsOverride.stepsLayer1, 32f, 256f, GUILayout.Width(100f));
					}
					GUILayout.Label($"   {volumetricCloudsOverride.stepsLayer1}", _noWordWrapLabel, GUILayout.Width(80f));
					GUILayout.FlexibleSpace();
				}
				EnviroFogQualitySettings fogOverride = settings.defaultQuality.fogOverride;
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Fog Volumetrics:", GUILayout.Width(120f));
					fogOverride.volumetrics = GUILayout.Toggle(fogOverride.volumetrics, string.Empty);
				}
				EnviroFlatCloudsQualitySettings flatCloudsOverride = settings.defaultQuality.flatCloudsOverride;
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Flat Clouds:", GUILayout.Width(120f));
					flatCloudsOverride.flatClouds = GUILayout.Toggle(flatCloudsOverride.flatClouds, string.Empty);
				}
				if (!flatCloudsOverride.flatClouds)
				{
					return;
				}
				EnviroWeatherTypeFlatCloudsOverride flatCloudsOverride2 = instance.Weather.targetWeatherType.flatCloudsOverride;
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Flat Cloud Coverage:", GUILayout.Width(120f));
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						flatCloudsOverride2.flatCloudsCoverage = GUILayout.HorizontalSlider(flatCloudsOverride2.flatCloudsCoverage, 0f, 2f, GUILayout.Width(100f));
					}
					GUILayout.Label($"   {flatCloudsOverride2.flatCloudsCoverage}", _noWordWrapLabel, GUILayout.Width(80f));
					GUILayout.FlexibleSpace();
				}
			}
		}

		private class MaterialSettings
		{
			private Dictionary<string, bool> _states = new Dictionary<string, bool>();

			public void Draw()
			{
				GUILayout.Label("Material Settings");
				DrawToggle("_NORMALMAP", new(string, int)[9]
				{
					("RunwayCochran", 1),
					("RunwayCochran", 2),
					("RunwayCochran", 3),
					("RunwayCochraneHangarMaintenanceRight", 0),
					("Motorway 2x2 0018 1", 0),
					("Building Extension", 0),
					("Building Extension", 1),
					("Building Extension", 2),
					("Building Extension", 3)
				});
				DrawToggle("_METALLICSPECGLOSSMAP", new(string, int)[5]
				{
					("RunwayCochraneHangarMaintenanceRight", 0),
					("Building Extension", 0),
					("Building Extension", 1),
					("Building Extension", 2),
					("Building Extension", 3)
				});
				DrawToggle("_OCCLUSIONMAP", new(string, int)[8]
				{
					("RunwayCochran", 1),
					("RunwayCochran", 2),
					("RunwayCochran", 3),
					("Motorway 2x2 0018 1", 0),
					("Building Extension", 0),
					("Building Extension", 1),
					("Building Extension", 2),
					("Building Extension", 3)
				});
				DrawToggle("_EMISSION", new(string, int)[8]
				{
					("RunwayCochran", 1),
					("RunwayCochran", 2),
					("RunwayCochran", 3),
					("RunwayCochraneHangarMaintenanceRight", 0),
					("Building Extension", 0),
					("Building Extension", 1),
					("Building Extension", 2),
					("Building Extension", 3)
				});
				DrawToggle("_ENVIRONMENTREFLECTIONS_OFF", new(string, int)[8]
				{
					("RunwayCochran", 1),
					("RunwayCochran", 2),
					("RunwayCochran", 3),
					("RunwayCochraneHangarMaintenanceRight", 0),
					("Building Extension", 0),
					("Building Extension", 1),
					("Building Extension", 2),
					("Building Extension", 3)
				}, defaultValue: false);
			}

			private void DrawToggle(string keyword, (string ObjectName, int MaterialIndex)[] objects, bool defaultValue = true)
			{
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label(keyword, GUILayout.Width(120f));
					bool flag = (_states.TryGetValue(keyword, out var value) ? value : defaultValue);
					bool flag2 = flag;
					flag = GUILayout.Toggle(flag, string.Empty);
					if (flag != flag2)
					{
						_states[keyword] = flag;
						for (int i = 0; i < objects.Length; i++)
						{
							(string, int) tuple = objects[i];
							ToggleKeyword(keyword, tuple.Item1, tuple.Item2, flag);
						}
					}
				}
			}

			private void ToggleKeyword(string keyword, string objectName, int materialIndex, bool value)
			{
				GameObject gameObject = GameObject.Find(objectName);
				if (gameObject != null)
				{
					Material material = gameObject.GetComponent<MeshRenderer>().sharedMaterials[materialIndex];
					if (value)
					{
						material.EnableKeyword(keyword);
					}
					else
					{
						material.DisableKeyword(keyword);
					}
				}
			}
		}

		private class PhysicsSettings
		{
			private bool _limitMaxTimeStep;

			public void Draw()
			{
				GUILayout.Label("Physics Settings");
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Limit Max Timestep:", GUILayout.Width(120f));
					bool limitMaxTimeStep = _limitMaxTimeStep;
					_limitMaxTimeStep = GUILayout.Toggle(_limitMaxTimeStep, string.Empty);
					if (_limitMaxTimeStep != limitMaxTimeStep)
					{
						Time.maximumDeltaTime = (_limitMaxTimeStep ? Time.fixedDeltaTime : 1f);
					}
				}
			}
		}

		private class PostProcessingSettings
		{
			private PostProcessingSettingsScript _script;

			public void Draw()
			{
				_script = ((_script != null) ? _script : UnityEngine.Object.FindAnyObjectByType<PostProcessingSettingsScript>(FindObjectsInactive.Include));
				if (_script == null)
				{
					return;
				}
				GUILayout.Label("Post Processing Settings");
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Beautify:", GUILayout.Width(120f));
					_script.Beautify.active = GUILayout.Toggle(_script.Beautify.active, string.Empty);
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("HBAO:", GUILayout.Width(120f));
					_script.AmbientOcclusion.active = GUILayout.Toggle(_script.AmbientOcclusion.active, string.Empty);
				}
			}
		}

		private class ProximityLoadedObjectSettings
		{
			private Transform _proximityLoadedObjectsRoot;

			public void Draw()
			{
				_proximityLoadedObjectsRoot = ((_proximityLoadedObjectsRoot != null) ? _proximityLoadedObjectsRoot : FindProximityLoadedObjectsRoot());
				if (_proximityLoadedObjectsRoot == null)
				{
					return;
				}
				GUILayout.Label("ProximityLoadedObjects");
				foreach (Transform item in _proximityLoadedObjectsRoot)
				{
					using (new GUILayout.HorizontalScope())
					{
						GUILayout.Space(15f);
						GUILayout.Label(item.name + ":", GUILayout.Width(120f));
						item.gameObject.SetActive(GUILayout.Toggle(item.gameObject.activeSelf, string.Empty));
					}
				}
			}

			private Transform FindProximityLoadedObjectsRoot()
			{
				Transform transform = FlightSceneScript.Instance?.transform;
				if (transform == null)
				{
					return null;
				}
				return transform.Find("ProximityLoadedObjects");
			}
		}

		private class TerrainSettings
		{
			private bool _castShadowsTerrain = true;

			private bool _drawTerrain = true;

			private bool _drawTrees = true;

			private Camera _mainCamera;

			private PerformanceDebugScript _performanceDebugScript;

			private int _pixelError = 10;

			private int _terrainShaderIndex;

			private GPUITreeManager _treeManager;

			public TerrainSettings(PerformanceDebugScript performanceDebugScript)
			{
				_performanceDebugScript = performanceDebugScript;
			}

			public void Draw()
			{
				_treeManager = ((_treeManager != null) ? _treeManager : UnityEngine.Object.FindAnyObjectByType<GPUITreeManager>(FindObjectsInactive.Include));
				_mainCamera = ((_mainCamera != null) ? _mainCamera : Camera.main);
				if (_treeManager == null)
				{
					return;
				}
				GUILayout.Label("Terrain Settings");
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Draw Trees:", GUILayout.Width(120f));
					bool drawTrees = _drawTrees;
					_drawTrees = GUILayout.Toggle(_drawTrees, string.Empty);
					if (_drawTrees != drawTrees)
					{
						_treeManager.enabled = _drawTrees;
						if (_drawTrees)
						{
							for (int num = _treeManager.GetTerrainCount() - 1; num >= 0; num--)
							{
								TerrainVegetationScript component = _treeManager.GetTerrain(num).GetComponent<TerrainVegetationScript>();
								component.TreeInstances = component.TreeInstances;
							}
						}
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Draw Terrain:", GUILayout.Width(120f));
					bool drawTerrain = _drawTerrain;
					_drawTerrain = GUILayout.Toggle(_drawTerrain, string.Empty);
					if (_drawTerrain != drawTerrain)
					{
						ForeachTerrain(delegate(MicroSplatTerrain t)
						{
							t.terrain.drawHeightmap = _drawTerrain;
						});
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Cast Shadows:", GUILayout.Width(120f));
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(35f);
					GUILayout.Label("Terrain:", GUILayout.Width(100f));
					bool castShadowsTerrain = _castShadowsTerrain;
					_castShadowsTerrain = GUILayout.Toggle(_castShadowsTerrain, string.Empty);
					if (_castShadowsTerrain != castShadowsTerrain)
					{
						ForeachTerrain(delegate(MicroSplatTerrain t)
						{
							t.terrain.shadowCastingMode = (_castShadowsTerrain ? ShadowCastingMode.On : ShadowCastingMode.Off);
						});
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(35f);
					GUILayout.Label("Trees:", GUILayout.Width(100f));
					bool value = Assets.Scripts.Game.Instance.Settings.Quality.Shadow.TreeShadows.Value;
					bool flag = GUILayout.Toggle(value, string.Empty);
					if (flag != value)
					{
						Assets.Scripts.Game.Instance.Settings.Quality.Shadow.TreeShadows.Value = flag;
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Pixel Error:", GUILayout.Width(120f));
					int pixelError = _pixelError;
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						_pixelError = (int)GUILayout.HorizontalSlider(_pixelError, 1f, 200f, GUILayout.Width(120f));
					}
					GUILayout.Label($"   {_pixelError}", GUILayout.Width(40f));
					GUILayout.FlexibleSpace();
					if (_pixelError != pixelError)
					{
						ForeachTerrain(delegate(MicroSplatTerrain t)
						{
							t.terrain.heightmapPixelError = _pixelError;
						});
					}
				}
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Space(15f);
					GUILayout.Label("Shader", GUILayout.Width(120f));
					int terrainShaderIndex = _terrainShaderIndex;
					using (new GUILayout.VerticalScope(GUILayout.Height(20f)))
					{
						GUILayout.FlexibleSpace();
						_terrainShaderIndex = (int)GUILayout.HorizontalSlider(_terrainShaderIndex, 0f, 3f, GUILayout.Width(80f));
					}
					switch (_terrainShaderIndex)
					{
					case 0:
						GUILayout.Label("   MS Default", GUILayout.Width(80f));
						break;
					case 1:
						GUILayout.Label("   MS Lite", GUILayout.Width(80f));
						break;
					case 2:
						GUILayout.Label("   Unity Lit", GUILayout.Width(80f));
						break;
					case 3:
						GUILayout.Label("   None", GUILayout.Width(80f));
						break;
					}
					GUILayout.FlexibleSpace();
					if (_terrainShaderIndex == terrainShaderIndex)
					{
						return;
					}
					PerformanceDebugResources.MicroSplatMaterialData matData = _terrainShaderIndex switch
					{
						0 => (_performanceDebugScript._debugResources ?? throw new Exception("Debug resources not found. Assets->Create->SimplePlanes 2->PerformanceDebugResources")).TerrainSpn.Default, 
						1 => (_performanceDebugScript._debugResources ?? throw new Exception("Debug resources not found. Assets->Create->SimplePlanes 2->PerformanceDebugResources")).TerrainSpn.Lite, 
						2 => new PerformanceDebugResources.MicroSplatMaterialData
						{
							Material = Resources.Load<Material>("Environment/Terrain/Materials/TerrainDefault")
						}, 
						_ => default(PerformanceDebugResources.MicroSplatMaterialData), 
					};
					ForeachTerrain(delegate(MicroSplatTerrain t)
					{
						if (_terrainShaderIndex >= 2)
						{
							t.terrain.materialTemplate = matData.Material;
						}
						else
						{
							t.terrain.materialTemplate = null;
							t.templateMaterial = matData.Material;
							t.keywordSO = matData.Keywords;
							t.propData = matData.PropData;
							t.Sync();
						}
					});
				}
			}

			private void ForeachTerrain(Action<MicroSplatTerrain> action)
			{
				MicroSplatTerrain[] array = UnityEngine.Object.FindObjectsByType<MicroSplatTerrain>(FindObjectsSortMode.None);
				foreach (MicroSplatTerrain obj in array)
				{
					action(obj);
				}
			}
		}

		private CarSettings _carSettings;

		private CrestSettings _crestSettings;

		private PerformanceDebugResources _debugResources;

		private EnviroSettings _enviroSettings;

		private MaterialSettings _materialSettings;

		private PhysicsSettings _physicsSettings;

		private PostProcessingSettings _postProcessingSettings;

		private ProximityLoadedObjectSettings _proximityLoadedObjectSettings;

		private Vector2 _scrollPosition;

		private TerrainSettings _terrainSettings;

		private Rect _windowRect = new Rect(Screen.width - 400, 25f, 375f, 425f);

		protected virtual void OnGUI()
		{
			_windowRect = GUI.Window(0, _windowRect, DrawDebugWindow, "Performance Debug");
		}

		protected virtual void Start()
		{
			_debugResources = Resources.Load<PerformanceDebugResources>("PerformanceDebugResources");
			if (_debugResources == null)
			{
				Debug.LogError("Unable to find the PerformanceDebugResources asset");
			}
			_crestSettings = new CrestSettings();
			_carSettings = new CarSettings();
			_enviroSettings = new EnviroSettings();
			_terrainSettings = new TerrainSettings(this);
			_postProcessingSettings = new PostProcessingSettings();
			_proximityLoadedObjectSettings = new ProximityLoadedObjectSettings();
			_physicsSettings = new PhysicsSettings();
			_materialSettings = new MaterialSettings();
		}

		private void DrawDebugWindow(int id)
		{
			using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(_scrollPosition, false, false))
			{
				_scrollPosition = scrollViewScope.scrollPosition;
				_crestSettings.Draw();
				GUILayout.Space(15f);
				_carSettings.Draw();
				GUILayout.Space(15f);
				_enviroSettings.Draw();
				GUILayout.Space(15f);
				_terrainSettings.Draw();
				GUILayout.Space(15f);
				_postProcessingSettings.Draw();
				GUILayout.Space(15f);
				_proximityLoadedObjectSettings.Draw();
				GUILayout.Space(15f);
				_physicsSettings.Draw();
				GUILayout.Space(15f);
				_materialSettings.Draw();
				GUILayout.Space(15f);
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
		}
	}
}
