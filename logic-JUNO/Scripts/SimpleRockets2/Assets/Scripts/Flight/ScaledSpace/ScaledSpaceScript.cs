using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Planet;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Terrain.Rendering;
using BeautifyEffect;
using ModApi;
using ModApi.Flight.Sim;
using ModApi.Planet.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight.ScaledSpace
{
	public class ScaledSpaceScript : MonoBehaviour
	{
		public delegate void RenderTextureChangedHandler(ScaledSpaceScript source);

		private static ScaledSpaceScript _instance;

		[SerializeField]
		private Camera _camera;

		private Vector3d _cameraPosition;

		private Quaterniond _cameraRotation;

		private CommandBuffer _commandBuffer;

		[SerializeField]
		private GameViewScript _gameView;

		private ImageEffectsScript _imageEffects;

		private List<ScaledSpacePlanetScript> _planets = new List<ScaledSpacePlanetScript>();

		private PlanetScript _planetScript;

		private ScaledSpacePlanetScript _sun;

		public static ScaledSpaceScript Instance => _instance;

		public Camera Camera => _camera;

		public ReadOnlyCollection<ScaledSpacePlanetScript> Planets => _planets.AsReadOnly();

		public ScaledSpacePlanetScript Sun => _sun;

		public virtual void OnLateUpdate()
		{
			if (Game.InFlightScene)
			{
				_cameraPosition = _gameView.CameraSolarSystemPosition;
				_cameraRotation = _gameView.CameraSolarSystemRotation;
			}
			else if (Game.InPlanetStudioScene)
			{
				CelestialBodyViewerScript celestialBodyViewerScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CelestialBodyViewer;
				_cameraPosition = celestialBodyViewerScript.CameraSolarPosition;
				_cameraRotation = celestialBodyViewerScript.CameraSolarRotation;
			}
			TerrainRendererManagerScript.Instance.UpdateScaledSpaceRenderers(_camera, _cameraPosition);
			Transform transform = _camera.transform;
			transform.SetLocalPositionAndRotation(Vector3.zero, _cameraRotation.ToQuaternion());
			Beautify beautify = _imageEffects.Beautify;
			if (beautify != null && beautify.isActiveAndEnabled && beautify.sunFlares)
			{
				Vector3 position = transform.position;
				Vector3 vector = Sun.transform.position - position;
				float magnitude = vector.magnitude;
				bool flag = Physics.Raycast(position, vector / magnitude, magnitude, 256);
				beautify.SunFlareOcclusion = ((!flag) ? 1 : 0);
			}
		}

		protected virtual void Awake()
		{
			_instance = this;
			if (Game.InFlightScene)
			{
				CreatePlanets(FlightSceneScript.Instance.FlightState.RootNode);
			}
			else if (Game.InPlanetStudioScene)
			{
				CelestialBodyViewerScript celestialBodyViewerScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CelestialBodyViewer;
				if (_imageEffects == null)
				{
					_imageEffects = celestialBodyViewerScript.NearCamera.GetComponent<ImageEffectsScript>();
				}
				CreatePlanets(celestialBodyViewerScript.SunNode);
			}
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
			TerrainRendererManagerScript instance = TerrainRendererManagerScript.Instance;
			if (instance != null)
			{
				instance.ScaledSpacePlanetEnabledChanged -= OnScaledSpacePlanetEnabledChanged;
			}
			if (_planetScript != null)
			{
				_planetScript.QuadSphereEnabledStateChanged -= OnPlanetScriptQuadSphereEnabledChanged;
			}
		}

		protected virtual void Start()
		{
			TerrainRendererManagerScript.Instance.ScaledSpacePlanetEnabledChanged += OnScaledSpacePlanetEnabledChanged;
			if (Game.InFlightScene)
			{
				_planetScript = _gameView.PlanetScript;
				_imageEffects = _gameView.GameCamera.Transform.GetComponent<ImageEffectsScript>();
			}
			else if (Game.InPlanetStudioScene)
			{
				CelestialBodyViewerScript celestialBodyViewerScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CelestialBodyViewer;
				_planetScript = celestialBodyViewerScript.PlanetScript;
				_imageEffects = celestialBodyViewerScript.NearCamera.GetComponent<ImageEffectsScript>();
			}
			_planetScript.QuadSphereEnabledStateChanged += OnPlanetScriptQuadSphereEnabledChanged;
			if (_planetScript.QuadSphereEnabled && _planetScript.QuadSphereTransitionStrength < 1f)
			{
				EnableCommandBuffer();
			}
		}

		private void CreatePlanets(IPlanetNode root)
		{
			ScaledSpacePlanetScript scaledSpacePlanetScript = ScaledSpacePlanetScript.Create(root, base.transform);
			_planets.Add(scaledSpacePlanetScript);
			if (root.Parent == null)
			{
				if (_sun == null)
				{
					_sun = scaledSpacePlanetScript;
				}
				else
				{
					Debug.LogError("Adding another planet with no root node when a \"Sun\" already exists");
				}
			}
			foreach (IPlanetNode childPlanet in root.ChildPlanets)
			{
				CreatePlanets(childPlanet);
			}
		}

		private void DisableCommandBuffer()
		{
			if (_commandBuffer != null)
			{
				_camera.RemoveCommandBuffer(CameraEvent.AfterEverything, _commandBuffer);
			}
			_commandBuffer = null;
		}

		private void EnableCommandBuffer()
		{
			CommandBuffer commandBuffer = new CommandBuffer();
			commandBuffer.name = "Quad/Scaled Transition Grab Pass";
			int num = Shader.PropertyToID("_ScaledSpaceTerrainTexture");
			commandBuffer.GetTemporaryRT(num, -1, -1, 0, FilterMode.Bilinear, Utilities.Texture.GetDefaultRenderTextureFormat());
			commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, num);
			commandBuffer.SetGlobalTexture("_ScaledSpaceTerrainTexture", num);
			_camera.AddCommandBuffer(CameraEvent.AfterEverything, commandBuffer);
			_commandBuffer = commandBuffer;
		}

		private void OnPlanetScriptQuadSphereEnabledChanged(object sender, PlanetQuadSphereEventArgs e)
		{
			if (_planetScript.QuadSphereEnabled)
			{
				EnableCommandBuffer();
			}
			else
			{
				DisableCommandBuffer();
			}
		}

		private void OnScaledSpacePlanetEnabledChanged(TerrainRendererManagerScript source, ScaledSpacePlanetScript planetScript, bool enabled)
		{
			if (enabled)
			{
				EnableCommandBuffer();
			}
			else
			{
				DisableCommandBuffer();
			}
		}
	}
}
