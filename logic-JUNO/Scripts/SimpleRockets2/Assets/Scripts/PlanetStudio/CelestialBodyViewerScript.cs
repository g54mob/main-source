using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Cameras;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Planet;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.PlanetStudio.Brush;
using Assets.Scripts.Terrain;
using Assets.Scripts.Terrain.Rendering;
using ModApi.CelestialData;
using ModApi.Craft.Parts;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Planet.Events;
using ModApi.Planet.Modifiers.Profiling;
using ModApi.PlanetStudio;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class CelestialBodyViewerScript : MonoBehaviour, ICelestialBodyViewer
	{
		private class StudioGameView : IGameView
		{
			public Vector3d CameraSolarSystemPosition => Viewer.CameraSolarPosition;

			public Quaterniond CameraSolarSystemRotation => Viewer.CameraSolarRotation;

			public IGameCamera GameCamera => Viewer._cameraManager;

			public IPlanet Planet => Viewer.PlanetScript;

			public IPlanetNode PlanetNode => Viewer.PlanetScript.PlanetNode;

			public IReferenceFrame ReferenceFrame => Viewer.ReferenceFrame;

			public bool RenderView { get; set; }

			public IPartScript SelectedPart { get; set; }

			public Light SunLight => SunLight;

			public CelestialBodyViewerScript Viewer { get; }

			public event ReferenceFrameRecenteredDelegate ReferenceFrameRecentered;

			public event SelectedPartChanged SelectedPartChanged;

			public StudioGameView(CelestialBodyViewerScript viewer)
			{
				Viewer = viewer;
			}

			public Transform AddGameViewObject(IGameViewObject gameViewObject)
			{
				return Viewer.AddGameViewObject(gameViewObject);
			}

			public void RaiseReferenceFrameRecentered(ReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
			{
				this.ReferenceFrameRecentered?.Invoke(referenceFrame, positionDelta, velocityDelta);
			}

			public void RaiseSelectedPartChanged(IPartScript part)
			{
				this.SelectedPartChanged?.Invoke(part);
			}

			public void RecenterReferenceFrame()
			{
				Viewer.RecenterReferenceFrame();
			}

			public void RemoveGameViewObject(IGameViewObject gameViewObject, bool flightEnd)
			{
				Viewer.RemoveGameViewObject(gameViewObject, flightEnd);
			}
		}

		private bool _asyncGpuReadback;

		[SerializeField]
		private PlanetStudioCameraManagerScript _cameraManager;

		[SerializeField]
		private Camera _farCamera;

		private bool _firstFrame = true;

		private double _flightStateTime;

		[SerializeField]
		private QuadMeshRaycaster _fullRaycaster;

		private StudioGameView _gameView;

		private List<IGameViewObject> _gameViewObjects;

		[SerializeField]
		private Camera _gizmoCamera;

		[SerializeField]
		private ImageEffectsScript _imageEffects;

		private bool _initialized;

		[SerializeField]
		private MovementScript _movementScript;

		[SerializeField]
		private Camera _nearCamera;

		private Transform _objectsContainer;

		[SerializeField]
		private PlanetScript _planetScript;

		[SerializeField]
		private QuadMeshRaycaster _raycaster;

		[SerializeField]
		private GameObject _scaledSpacePrefab;

		private SceneCameraScript _sceneCameraNear;

		[SerializeField]
		private Light _sunLight;

		public double AltitudeGroundLevel { get; private set; }

		public double AltitudeSeaLevel { get; private set; }

		public BrushSphereScript BrushSphere { get; private set; }

		public Vector3d CameraPlanetPosition
		{
			get
			{
				return ReferenceFrame.FrameToPlanetPosition(NearCamera.transform.position);
			}
			set
			{
				SetCameraPosition(ReferenceFrame.PlanetToFramePosition(value));
			}
		}

		public Vector3d CameraSolarPosition => PlanetScript.PlanetNode.SolarPosition + ReferenceFrame.FrameToPlanetPosition(NearCamera.transform.position);

		public Quaterniond CameraSolarRotation => ReferenceFrame.FrameToPlanetRotation(NearCamera.transform.rotation);

		public Vector3d CameraSurfacePosition
		{
			get
			{
				return PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(ReferenceFrame.FrameToPlanetPosition(NearCamera.transform.position));
			}
			set
			{
				SetCameraPosition(ReferenceFrame.PlanetToFramePosition(PlanetScript.PlanetNode.SurfaceVectorToPlanetVector(value)));
			}
		}

		public PlanetDataScript CelestialBodyData { get; private set; }

		public Camera FarCamera => _farCamera;

		public IGameView GameView => _gameView;

		public IEnumerable<IGameViewObject> GameViewObjects => _gameViewObjects;

		public Camera GizmoCamera => _gizmoCamera;

		public double Latitude { get; private set; }

		public double Longitude { get; private set; }

		public MovementScript MovementScript => _movementScript;

		public Camera NearCamera => _nearCamera;

		public PlanetScript PlanetScript => _planetScript;

		public bool QuadSphereScaledSpaceTransitionEnabled
		{
			get
			{
				return PlanetScript.QuadSphereScaledSpaceTransitionEnabled;
			}
			set
			{
				Game.Instance.Settings.UserPrefs.SetBool("PlanetStudio.QuadSphereScaledSpaceTransitionEnabled", value);
				PlanetScript.QuadSphereScaledSpaceTransitionEnabled = value;
			}
		}

		public ReferenceFrame ReferenceFrame { get; private set; }

		IReferenceFrame ICelestialBodyViewer.ReferenceFrame => ReferenceFrame;

		public ScaledSpaceScript ScaledSpaceScript { get; private set; }

		public PlanetDataScript SunBodyData { get; private set; }

		public Light SunLight => _sunLight;

		public PlanetNode SunNode { get; private set; }

		public TerrainRendererManagerScript TerrainRendererManager { get; private set; }

		public bool UnderwaterEffectsEnabled { get; set; }

		public event EventHandler ReferenceFrameRecentered;

		public void HideBrushSphere()
		{
			PlanetScript.IsHidden = false;
			_imageEffects.enabled = true;
			BrushSphere.HideBrushSphere();
		}

		public void OnBrushPanelClosed()
		{
			HideBrushSphere();
			BrushSphere.EndBrushEditing();
		}

		public void OnBrushPanelOpened()
		{
			ShowBrushSphere();
			BrushSphere.BeginBrushEditing();
		}

		public RaycastHit? PhysicsRaycast(Vector2 screenPosition, float maxDistance)
		{
			if (Physics.Raycast(NearCamera.ScreenPointToRay(screenPosition), out var hitInfo, maxDistance))
			{
				return hitInfo;
			}
			return null;
		}

		public Vector3d? RaycastTerrain(Vector2 screenPosition, bool useGraphicsRaycaster = false)
		{
			Ray3d ray = new Ray3d(NearCamera.ScreenPointToRay(screenPosition));
			Vector3d result;
			if (useGraphicsRaycaster)
			{
				QuadMeshRaycastHit quadMeshRaycastHit = _fullRaycaster.Raycast(ray.ToRay());
				if (quadMeshRaycastHit.Hit)
				{
					return ReferenceFrame.FrameToPlanetPosition(quadMeshRaycastHit.FramePosition);
				}
			}
			else if (MathUtils.GetFirstExternalRayIntersectionWithSphere(PlanetScript.transform.position, PlanetScript.PlanetData.Radius, ray, out result))
			{
				return (PlanetScript.PlanetNode.RotationInverse * (result - PlanetScript.transform.position)).normalized;
			}
			return null;
		}

		public void RecenterReferenceFrame(bool surfaceLock = false)
		{
			ReferenceFrame.Recenter(ReferenceFrame.FrameToPlanetPosition(_movementScript.transform.position), Vector3d.zero, _planetScript.PlanetNode, surfaceLock, out var positionDelta, out var velocityDelta);
			foreach (IGameViewObject gameViewObject in _gameViewObjects)
			{
				gameViewObject.OnReferenceFrameRecentered(ReferenceFrame, positionDelta, velocityDelta);
			}
			_gameView.RaiseReferenceFrameRecentered(ReferenceFrame, positionDelta, velocityDelta);
			_planetScript.OnReferenceFrameRecentered(ReferenceFrame, positionDelta, velocityDelta);
			_movementScript.transform.position = Vector3.zero;
			this.ReferenceFrameRecentered?.Invoke(this, new EventArgs());
		}

		public void RemoveGameViewObject(IGameViewObject gameViewObject, bool flightEnd)
		{
			try
			{
				if (_gameViewObjects.Contains(gameViewObject))
				{
					_gameViewObjects.Remove(gameViewObject);
					gameViewObject.UnloadFromGameView(flightEnd);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void ResetView(Vector3d? viewPosition = null)
		{
			IPlanetNode planetNode = PlanetScript.PlanetNode;
			if (planetNode != null)
			{
				_flightStateTime = 0.0;
				SunNode.RotationAngle = 0.0;
				PlanetScript.PlanetNode.RotationAngle = 0.0;
				Vector3d center = (viewPosition.HasValue ? viewPosition.Value : new Vector3d(planetNode.PlanetData.Radius * -1.5, 0.0, 0.0));
				ReferenceFrame.Recenter(center, Vector3d.zero, planetNode, surfaceLock: false, out var _, out var _);
				_movementScript.OnViewReset();
			}
		}

		public void ShowBrushSphere()
		{
			PlanetScript.IsHidden = true;
			_imageEffects.enabled = false;
			BrushSphere.ShowBrushSphere();
		}

		public void UnloadCelestialBody()
		{
			_raycaster?.SetQuadSphere(null);
			_fullRaycaster?.SetQuadSphere(null);
			_movementScript.OnQuadSphereUnloaded();
			_planetScript.SetPlanetNode(null);
			if (ScaledSpaceScript != null)
			{
				UnityEngine.Object.DestroyImmediate(ScaledSpaceScript.gameObject);
				ScaledSpaceScript = null;
			}
			if (TerrainRendererManager != null)
			{
				UnityEngine.Object.DestroyImmediate(TerrainRendererManager);
				TerrainRendererManager = null;
			}
			if (CelestialBodyData != null)
			{
				UnityEngine.Object.DestroyImmediate(CelestialBodyData.gameObject);
				CelestialBodyData = null;
			}
			foreach (IGameViewObject item in new List<IGameViewObject>(_gameViewObjects ?? new List<IGameViewObject>(0)))
			{
				item.UnloadFromGameView(flightEnd: true);
			}
			_gameViewObjects?.Clear();
			_gameView = null;
		}

		public void ViewCelestialBody(CelestialFile celestialBodyFile, bool resetView)
		{
			if (!_initialized)
			{
				Initialize();
			}
			UnloadCelestialBody();
			_gameView = new StudioGameView(this);
			_gameViewObjects = new List<IGameViewObject>();
			_objectsContainer = base.transform;
			CelestialBodyPlanetarySystemDefinedData celestialBodyPlanetarySystemDefinedData = new CelestialBodyPlanetarySystemDefinedData();
			celestialBodyPlanetarySystemDefinedData.Orbit = new OrbitData
			{
				SemiMajorAxis = 500000000000.0,
				Eccentricity = 0.001
			};
			Orbit orbit = new Orbit(celestialBodyPlanetarySystemDefinedData.Orbit, SunBodyData.Mass);
			CelestialBodyData = PlanetDataScript.CreateFromFile(celestialBodyFile, celestialBodyPlanetarySystemDefinedData, SunBodyData, null, createTerrainData: true, applyScaleAndOverrides: true);
			CelestialBodyData.transform.SetParent(PlanetScript.transform);
			PlanetNodeData data = new PlanetNodeData(XElement.Parse("<PlanetNode name=\"Sun\"/>"));
			SunNode = new PlanetNode(data, SunBodyData, null);
			PlanetNode planetNode = new PlanetNode(new PlanetNodeData(XElement.Parse("<PlanetNode name=\"" + CelestialBodyData.Name + "\"/>")), CelestialBodyData, orbit);
			SunNode.AddChildNode(planetNode);
			TerrainRendererManager = _planetScript.gameObject.AddComponent<TerrainRendererManagerScript>();
			PlanetScript.Initialize(ReferenceFrame);
			PlanetScript.SetPlanetNode(planetNode);
			QuadSphereScript quadSphereScript = (QuadSphereScript)_planetScript.QuadSphere;
			ScaledSpaceScript = UnityEngine.Object.Instantiate(_scaledSpacePrefab, base.transform).GetComponent<ScaledSpaceScript>();
			foreach (INode dynamicNode in planetNode.DynamicNodes)
			{
				dynamicNode.Initialize();
			}
			if (resetView)
			{
				ResetView();
				_movementScript.SpeedMultiplier = (float)(CelestialBodyData.Radius / 500000.0);
				_movementScript.SpeedMultiplierRotations = 1f;
			}
			UpdatePlanetRotation(_flightStateTime);
			_raycaster.SetQuadSphere(quadSphereScript);
			_fullRaycaster.SetQuadSphere(quadSphereScript);
			Vector3d cameraSurfacePosition = CameraSurfacePosition;
			Vector3d normalized = cameraSurfacePosition.normalized;
			double magnitude = cameraSurfacePosition.magnitude;
			PlanetVertexData vertexData = _planetScript.QuadSphere.TerrainGenerator.GetVertexData(VertexDataRequestType.AllData, normalized);
			AltitudeGroundLevel = magnitude - _planetScript.PlanetData.Radius - vertexData.Height;
			AltitudeSeaLevel = magnitude - _planetScript.PlanetData.Radius;
			HideBrushSphere();
			PlanetModifierProfiler planetModifierProfiler = (quadSphereScript.ModifierProfiler = new PlanetModifierProfiler(planetNode.TerrainGenerator.TerrainData));
			PlanetScript.UpdateTerrain(CameraPlanetPosition, synchronous: true);
			quadSphereScript.ModifierProfiler = null;
			planetModifierProfiler.GenerateReport(PlanetStudioScript.Instance.CelestialBodyDesignerScript.CurrentCelestialBody.TerrainData);
		}

		protected virtual void Awake()
		{
			UnderwaterEffectsEnabled = false;
			ReferenceFrame = new ReferenceFrame();
			BrushSphere = Game.Instance.ResourceLoader.InstantiatePrefab<BrushSphereScript>("PlanetStudio/Prefabs/BrushSphere");
			BrushSphere.transform.SetParent(PlanetScript.transform, worldPositionStays: false);
			BrushSphere.gameObject.SetActive(value: false);
			_movementScript.Initialize(this);
			_planetScript.QuadSphereLoaded += OnQuadSphereLoaded;
			_planetScript.QuadSphereUnloaded += OnQuadSphereUnloaded;
			_asyncGpuReadback = SystemInfo.supportsAsyncGPUReadback;
			_sceneCameraNear = _nearCamera.GetComponent<SceneCameraScript>();
			_sceneCameraNear.PreRender += OnNearCamPreRender;
		}

		protected virtual void LateUpdate()
		{
			ScaledSpaceScript?.OnLateUpdate();
			TerrainRendererManager?.UpdateQuadSphereRenderers();
		}

		protected virtual void OnDestroy()
		{
			if (_planetScript != null)
			{
				_planetScript.QuadSphereLoaded -= OnQuadSphereLoaded;
				_planetScript.QuadSphereUnloaded -= OnQuadSphereUnloaded;
			}
			if (_sceneCameraNear != null)
			{
				_sceneCameraNear.PreRender -= OnNearCamPreRender;
			}
		}

		protected virtual void Update()
		{
			if (PlanetScript?.PlanetNode != null)
			{
				_movementScript.UpdateMovement();
				Vector3d cameraSurfacePosition = CameraSurfacePosition;
				Vector3d normalized = cameraSurfacePosition.normalized;
				double magnitude = cameraSurfacePosition.magnitude;
				PlanetVertexData vertexData = _planetScript.QuadSphere.TerrainGenerator.GetVertexData(VertexDataRequestType.AllData, normalized);
				double height = vertexData.Height;
				_cameraManager.CameraBiomeData.UpdateCameraPositionData(vertexData, _planetScript.PlanetData.TerrainData);
				AltitudeGroundLevel = magnitude - _planetScript.PlanetData.Radius - height;
				AltitudeSeaLevel = magnitude - _planetScript.PlanetData.Radius - (double)_planetScript.PlanetData.SeaLevel;
				_planetScript.PlanetNode.GetSurfaceCoordinates(cameraSurfacePosition, out var latitude, out var longitude);
				Latitude = latitude * 57.29578;
				Longitude = longitude * 57.29578;
				double num = _planetScript.PlanetData.Radius + height + 2.0;
				if (_movementScript.SnapToGround || magnitude < num)
				{
					magnitude = (CameraSurfacePosition = normalized * num).magnitude;
					AltitudeGroundLevel = magnitude - _planetScript.PlanetData.Radius - height;
					AltitudeSeaLevel = magnitude - _planetScript.PlanetData.Radius - (double)_planetScript.PlanetData.SeaLevel;
				}
				double planetRotation = _movementScript.PlanetRotation;
				_flightStateTime += planetRotation;
				if (_firstFrame)
				{
					_firstFrame = false;
					PlanetScript.PlanetNode.RotationAngle = CelestialBodyDesignerScript.InitialBodyRotation;
					CelestialBodyDesignerScript.InitialBodyRotation = 0.0;
				}
				_ = PlanetScript.PlanetNode.RotationAngle;
				Quaternion q = Quaternion.LookRotation(CameraSolarPosition.normalized.ToVector3());
				_sunLight.transform.localRotation = ReferenceFrame.PlanetToFrameRotation(Quaterniond.FromQuaternion(q));
				_sunLight.transform.Rotate(_movementScript.SunTiltAngle, 0f, 0f);
				if (_movementScript.RotateCameraWithPlanet)
				{
					RecenterReferenceFrame(surfaceLock: true);
				}
				UpdatePlanetRotation(planetRotation);
				if (ReferenceFrame.IsSurfaceLocked)
				{
					ReferenceFrame.Update(0.0);
					RecenterReferenceFrame();
				}
				else if (_movementScript.transform.position.magnitude > 5000f)
				{
					RecenterReferenceFrame();
				}
				PlanetScript.UpdateTerrain(CameraPlanetPosition, synchronous: false);
				UpdateStructureNodes(planetRotation);
			}
		}

		private Transform AddGameViewObject(IGameViewObject gameViewObject)
		{
			Transform transform = gameViewObject.LoadIntoGameView(_gameView);
			if (transform != null)
			{
				transform.SetParent(_objectsContainer, worldPositionStays: true);
				_gameViewObjects.Add(gameViewObject);
			}
			return transform;
		}

		private void Initialize()
		{
			_initialized = true;
			_raycaster = base.gameObject.AddComponent<QuadMeshRaycaster>();
			_raycaster.Initialize(_nearCamera, _farCamera, identifyQuadInResult: false);
			_fullRaycaster = base.gameObject.AddComponent<QuadMeshRaycaster>();
			_fullRaycaster.Initialize(_nearCamera, _farCamera);
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFile file = celestialDatabase.GetFile(celestialDatabase.DefaultSunId);
			SunBodyData = PlanetDataScript.CreateFromFile(file, null, null, null, createTerrainData: true, applyScaleAndOverrides: true);
			SunBodyData.transform.SetParent(_sunLight.transform.parent);
			BrushSphere = Game.Instance.ResourceLoader.InstantiatePrefab<BrushSphereScript>("PlanetStudio/Prefabs/BrushSphere");
			BrushSphere.transform.SetParent(PlanetScript.transform, worldPositionStays: false);
			BrushSphere.Initialize(this);
			BrushSphere.gameObject.SetActive(value: false);
			PlanetScript.QuadSphereScaledSpaceTransitionEnabled = Game.Instance.Settings.UserPrefs.GetBool("PlanetStudio.QuadSphereScaledSpaceTransitionEnabled");
		}

		private void OnNearCamPreRender(object sender, EventArgs e)
		{
			UpdateSunTerrainOcclusion();
		}

		private void OnQuadSphereLoaded(object sender, PlanetQuadSphereEventArgs e)
		{
			_movementScript.OnQuadSphereLoaded(e.QuadSphere);
		}

		private void OnQuadSphereUnloaded(object sender, PlanetQuadSphereEventArgs e)
		{
			_movementScript.OnQuadSphereUnloaded();
		}

		private void SetCameraPosition(Vector3 position)
		{
			Transform transform = NearCamera.transform;
			Vector3 localPosition = transform.localPosition;
			_movementScript.transform.position = position + transform.forward * localPosition.magnitude;
			transform.localPosition = localPosition;
		}

		private void UpdatePlanetRotation(double elapsedTime)
		{
			SunNode.UpdateRotation(elapsedTime);
			if (PlanetScript.PlanetNode.PlanetData.AngularVelocity == 0.0)
			{
				PlanetScript.PlanetNode.RotationAngle += 0.0001 * elapsedTime;
			}
		}

		private void UpdateStructureNodes(double elapsedTime)
		{
			foreach (INode dynamicNode in _planetScript.PlanetNode.DynamicNodes)
			{
				dynamicNode.FlightUpdate(elapsedTime, _flightStateTime);
				if (dynamicNode.GameViewObject != null)
				{
					bool isLoadedInGameView = dynamicNode.GameViewObject.IsLoadedInGameView;
					double sqrMagnitude = (CameraPlanetPosition - dynamicNode.Position).sqrMagnitude;
					float num = dynamicNode.GameViewLoadDistance * dynamicNode.GameViewLoadDistance;
					if (isLoadedInGameView)
					{
						dynamicNode.GameViewObject.UpdateLevelOfDetail(sqrMagnitude);
					}
					if (isLoadedInGameView && sqrMagnitude > (double)num * 1.05)
					{
						_gameView.RemoveGameViewObject(dynamicNode.GameViewObject, flightEnd: false);
					}
					else if (!isLoadedInGameView && sqrMagnitude < (double)num)
					{
						_gameView.AddGameViewObject(dynamicNode.GameViewObject);
					}
				}
			}
		}

		private void UpdateSunTerrainOcclusion()
		{
			if (!_imageEffects.SunFlaresEnabled || Time.frameCount % 10 != 0)
			{
				return;
			}
			if (_asyncGpuReadback && _raycaster != null)
			{
				Ray ray = new Ray(NearCamera.transform.position, -_sunLight.transform.forward);
				_raycaster.RaycastAsync(ray, delegate(QuadMeshRaycastHit result)
				{
					if (result != null)
					{
						_imageEffects.SunOccludedByTerrain = result.Hit;
					}
				});
			}
			else
			{
				_imageEffects.SunOccludedByTerrain = false;
			}
		}
	}
}
