using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Cameras;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.GameView.Planet;
using Assets.Scripts.Flight.GameView.UI;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Input;
using Assets.Scripts.Terrain;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Input.Events;
using ModApi.Planet;
using ModApi.Planet.Events;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView
{
	public class GameViewScript : MonoBehaviour, IGameView
	{
		private bool _asyncGpuReadback;

		private List<AudioSource> _audioSources = new List<AudioSource>();

		[SerializeField]
		private CameraManagerScript _cameraControllerManager;

		private CraftNode _craftNode;

		[SerializeField]
		private bool _drawPhysicsQuadGizmos;

		[SerializeField]
		private CameraManagerScript _gameCamera;

		[SerializeField]
		private GameViewInterfaceScript _gameViewInterface;

		private List<IGameViewObject> _gameViewObjects;

		private MouseInputSettingsFlight _mouseInputSettings;

		[SerializeField]
		private Transform _objectsContainer;

		private double _physicsLoadDistanceSquared;

		private double _physicsUnloadDistanceSquared;

		[SerializeField]
		private PlanetScript _planet;

		private PhysicsQuadManager _quadPhysics;

		[SerializeField]
		private QuadMeshRaycaster _raycaster;

		private ReferenceFrame _referenceFrame;

		private List<IGameViewObject> _removeList = new List<IGameViewObject>();

		private SceneCameraScript _sceneCameraNear;

		private IPartScript _selectedPart;

		[SerializeField]
		private Color _sunColor = Color.white;

		[SerializeField]
		private Light _sunLight;

		[SerializeField]
		private Transform _sunLightTransform;

		public CameraManagerScript CameraControllerManager => _cameraControllerManager;

		public Vector3d CameraSolarSystemPosition => GameCamera.PlanetPosition + PlanetNode.SolarPosition;

		public Quaterniond CameraSolarSystemRotation => ReferenceFrame.FrameToPlanetRotation(GameCamera.Transform.rotation);

		public IGameCamera GameCamera => _gameCamera;

		IGameCamera IGameView.GameCamera => _gameCamera;

		public GameViewInterfaceScript GameViewInterface => _gameViewInterface;

		IPlanet IGameView.Planet => _planet;

		public IPlanetNode PlanetNode => _planet.PlanetNode;

		public PlanetScript PlanetScript => _planet;

		public IReferenceFrame ReferenceFrame => _referenceFrame;

		public bool RenderView
		{
			get
			{
				return GameCamera.Transform.gameObject.activeSelf;
			}
			set
			{
				_gameViewInterface.gameObject.SetActive(value);
				GameCamera.Transform.gameObject.SetActive(value);
			}
		}

		public IPartScript SelectedPart
		{
			get
			{
				return _selectedPart;
			}
			set
			{
				if (_selectedPart != value)
				{
					if (_selectedPart != null)
					{
						_selectedPart.PartMaterialScript.IsSelected = false;
					}
					_selectedPart = value;
					if (_selectedPart != null)
					{
						_selectedPart.PartMaterialScript.IsSelected = true;
					}
					this.SelectedPartChanged?.Invoke(SelectedPart);
				}
			}
		}

		public Light SunLight => _sunLight;

		public event ReferenceFrameRecenteredDelegate ReferenceFrameRecentered;

		public event SelectedPartChanged SelectedPartChanged;

		public Transform AddGameViewObject(IGameViewObject gameViewObject)
		{
			Transform transform = null;
			try
			{
				transform = gameViewObject.LoadIntoGameView(this);
				if (transform != null)
				{
					transform.SetParent(_objectsContainer, worldPositionStays: true);
					_gameViewObjects.Add(gameViewObject);
				}
			}
			catch (Exception ex)
			{
				gameViewObject.Enabled = false;
				Debug.LogError("Failed to load game view object: " + gameViewObject.GameViewName + ":\n" + ex.Message);
				Debug.LogException(ex);
			}
			return transform;
		}

		public void DragCamera(InputButton inputButton, bool isTouch, Vector2 delta)
		{
			bool inverted = false;
			if (isTouch || _mouseInputSettings.CanRotateCamera(inputButton, out inverted))
			{
				_gameCamera.CurrentCameraController.Rotate(delta * ((!inverted) ? 1 : (-1)));
			}
			else if (_mouseInputSettings.CanPanCamera(inputButton, out inverted))
			{
				_gameCamera.CurrentCameraController.Pan(delta * ((!inverted) ? 1 : (-1)));
			}
			else if (_mouseInputSettings.CanZoomCamera(inputButton, out inverted))
			{
				float y = delta.y;
				float zoomPercentage = 1f - y * 0.005f;
				GameCamera.Zoom(zoomPercentage);
			}
			else if (_mouseInputSettings.CanSpinForwardAxis(inputButton, out inverted))
			{
				_gameCamera.CurrentCameraController.Tilt(delta.x * (float)((!inverted) ? 1 : (-1)));
			}
		}

		public void EndFrame()
		{
			bool flag = false;
			if (_craftNode != null && (IsRecenterRequired() || DebugInput.GetKeyDown(KeyCode.KeypadEnter)))
			{
				flag = true;
				RecenterReferenceFrame();
			}
			if (!flag)
			{
				_planet.UpdateTerrain(_craftNode.Position, synchronous: false);
			}
			_cameraControllerManager.UpdateCamera();
		}

		public IPartScript FindPartAtScreenPosition(Vector2? screenPosition = null)
		{
			if (!screenPosition.HasValue)
			{
				screenPosition = InputWrapper.MouseScreenPosition;
			}
			Ray ray = _gameCamera.ScreenPointToRay(screenPosition.Value);
			int layerMask = -1073741824;
			RaycastHit[] array = (from x in Physics.RaycastAll(ray, 10000f, layerMask)
				orderby x.distance
				select x).ToArray();
			IPartScript partScript = null;
			bool flag = false;
			RaycastHit[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				RaycastHit raycastHit = array2[num];
				PartColliderScript component = raycastHit.collider.GetComponent<PartColliderScript>();
				if (((object)component != null && !component.SelectionEnabledInFlight) || ((object)component != null && component.IgnoreFirstPersonCollisions && CameraControllerManager?.CurrentCameraController is FirstPersonCameraController))
				{
					continue;
				}
				IPartScript componentInParent = raycastHit.collider.transform.GetComponentInParent<IPartScript>();
				if (raycastHit.collider.transform.TryGetComponent<DepthMaskScript>(out var _))
				{
					flag = true;
					partScript = componentInParent;
					continue;
				}
				if (flag)
				{
					if (partScript != componentInParent && componentInParent != null && componentInParent.Data.Config.RenderQueue == PartMeshRenderQueue.BeforeDepthMask)
					{
						partScript = componentInParent;
						break;
					}
					continue;
				}
				partScript = componentInParent;
				break;
			}
			return partScript;
		}

		public void FlightEnd()
		{
			if (_gameViewObjects != null)
			{
				for (int num = _gameViewObjects.Count - 1; num >= 0; num--)
				{
					RemoveGameViewObject(_gameViewObjects[num], flightEnd: true);
				}
			}
		}

		public void Initialize(CraftNode craftNode)
		{
			_craftNode = craftNode;
			_gameCamera.Target = craftNode;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
			RecenterReferenceFrame();
			_raycaster = base.gameObject.AddComponent<QuadMeshRaycaster>();
			_raycaster.Initialize(GameCamera.NearCamera, GameCamera.FarCamera, identifyQuadInResult: false);
			_planet.PlanetNodeChanged += OnPlanetNodeChanged;
			_planet.Initialize(ReferenceFrame);
			_planet.SetPlanetNode(craftNode.Parent);
			Color.RGBToHSV(FlightSceneScript.Instance?.FlightState?.SolarSystemData?.FlareColor ?? Color.white, out var H, out var S, out var V);
			_sunColor = Color.HSVToRGB(H, 0.5f * S, V);
			try
			{
				AddGameViewObject(craftNode.GameViewObject);
				AddGameViewObject(_gameCamera);
				_planet.UpdateTerrain(_craftNode.Position, synchronous: true);
				FlightSceneScript.Instance.CraftChanged += OnPlayerCraftNodeChanged;
			}
			catch (Exception exception)
			{
				Debug.LogError("Failed to initialize game view");
				Debug.LogException(exception);
				Game.Instance.SceneManager.DeactivateCurrentScene();
				Game.Instance.SceneManager.LoadDesigner();
			}
		}

		public void OnPlayerChangedSoi()
		{
			_planet.SetPlanetNode(_craftNode.Parent);
			RecenterReferenceFrame();
		}

		public void OnPlayerCraftNodeChanged(ICraftNode craftNode)
		{
			_craftNode = (CraftNode)craftNode;
			_gameCamera.Target = _craftNode;
			_planet.UpdateTerrain(_craftNode.Position, synchronous: true);
		}

		public void RecenterReferenceFrame()
		{
			bool surfaceLock = RequiresSurfaceLock();
			_referenceFrame.Recenter(_craftNode.Position, _craftNode.Velocity, _craftNode.Parent, surfaceLock, out var positionDelta, out var velocityDelta);
			foreach (IGameViewObject gameViewObject in _gameViewObjects)
			{
				try
				{
					gameViewObject.OnReferenceFrameRecentered(_referenceFrame, positionDelta, velocityDelta);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					_removeList.Add(gameViewObject);
				}
			}
			try
			{
				_planet.OnReferenceFrameRecentered(_referenceFrame, positionDelta, velocityDelta);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			_planet.UpdateTerrain(_craftNode.Position, synchronous: false);
			this.ReferenceFrameRecentered?.Invoke(_referenceFrame, positionDelta, velocityDelta);
			if (!Physics.autoSyncTransforms)
			{
				Physics.SyncTransforms();
			}
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

		public void UpdateReferenceFrame(double elapsedTime, bool timeWarp)
		{
			_referenceFrame.Update(elapsedTime);
			if (!timeWarp)
			{
				UpdatePhysicsQuads();
			}
		}

		protected virtual void Awake()
		{
			_referenceFrame = new ReferenceFrame();
			_gameViewObjects = new List<IGameViewObject>();
			ShadowQualitySettings shadows = Game.Instance.QualitySettings.Shadows;
			shadows.Changed += OnShadowSettingsChanged;
			ApplyShadowQualitySettings(shadows);
			NumericSetting<int> physicsDistance = Game.Instance.QualitySettings.Physics.PhysicsDistance;
			physicsDistance.Changed += OnPhysicsDistanceChanged;
			UpdatePhysicsDistance(physicsDistance);
			_asyncGpuReadback = SystemInfo.supportsAsyncGPUReadback;
		}

		protected virtual void LateUpdate()
		{
			if (LoadDynamicNodes(_craftNode.Parent, _craftNode.Position))
			{
				UpdatePhysicsQuads();
				if (RequiresSurfaceLock() && !ReferenceFrame.IsSurfaceLocked)
				{
					RecenterReferenceFrame();
				}
			}
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Shadows.Changed -= OnShadowSettingsChanged;
			Game.Instance.QualitySettings.Physics.PhysicsDistance.Changed -= OnPhysicsDistanceChanged;
			this.SelectedPartChanged = null;
			if (_sceneCameraNear != null)
			{
				_sceneCameraNear.PreRender -= OnNearCamPreRender;
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (_drawPhysicsQuadGizmos)
			{
				IQuadSphere quadSphere = _planet.QuadSphere;
				_quadPhysics?.DrawGizmos(quadSphere.Transform, quadSphere.TerrainGenerator);
			}
		}

		protected virtual void Start()
		{
			_sceneCameraNear = _gameCamera.ImageEffects.GetComponent<SceneCameraScript>();
			_sceneCameraNear.PreRender += OnNearCamPreRender;
		}

		protected virtual void Update()
		{
			UpdateLight();
			if (!Device.IsDebugBuild || Game.Instance.UserInterface.IsTextInputFocused)
			{
				return;
			}
			if (DebugInput.GetKeyDown(KeyCode.L))
			{
				_gameCamera.CurrentCameraController.LockPosition = !_gameCamera.CurrentCameraController.LockPosition;
				Debug.Log("Camera Lock Position: " + _gameCamera.CurrentCameraController.LockPosition);
			}
			else if (DebugInput.GetKeyDown(KeyCode.H) && DebugInput.GetKey(KeyCode.LeftControl))
			{
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Flashlight", base.gameObject);
				if (gameObject != null)
				{
					gameObject.SetActive(!gameObject.activeSelf);
					Debug.Log("Toggled Flashlight: " + gameObject.activeSelf);
				}
			}
		}

		private void ApplyShadowQualitySettings(ShadowQualitySettings quality)
		{
			quality.ConfigureLight(_sunLight, ShadowQualitySettings.LightType.PrimaryLight);
		}

		private bool IsRecenterRequired()
		{
			if (ReferenceFrame.RecenterEnabled)
			{
				if (FlightSceneScript.Instance.TimeManager.CurrentMode.WarpMode)
				{
					return true;
				}
				if (RequiresSurfaceLock() && !_referenceFrame.IsSurfaceLocked)
				{
					return true;
				}
				if (!RequiresSurfaceLock() && _referenceFrame.IsSurfaceLocked)
				{
					return true;
				}
				if (_craftNode.FrameVelocity.sqrMagnitude > 1000000f && !_referenceFrame.IsSurfaceLocked)
				{
					return true;
				}
				if (_craftNode.FramePosition.sqrMagnitude > 25000000f)
				{
					return true;
				}
			}
			return false;
		}

		private bool LoadDynamicNodes(IPlanetNode parentNode, Vector3d position)
		{
			bool result = false;
			for (int num = parentNode.DynamicNodes.Count - 1; num >= 0; num--)
			{
				INode node = parentNode.DynamicNodes[num];
				if (node.GameViewObject != null)
				{
					double sqrMagnitude = (position - node.Position).sqrMagnitude;
					double num2 = Mathd.Max(node.GameViewLoadDistance * node.GameViewLoadDistance, _physicsLoadDistanceSquared);
					if (!node.IsDestroyed && !node.GameViewObject.IsLoadedInGameView && node.GameViewObject.Enabled && sqrMagnitude < num2)
					{
						AddGameViewObject(node.GameViewObject);
					}
					if (node.GameViewObject.IsLoadedInGameView)
					{
						node.GameViewObject.UpdateLevelOfDetail(sqrMagnitude);
						if (!node.GameViewObject.Enabled)
						{
							_removeList.Add(node.GameViewObject);
						}
						else if (sqrMagnitude < _physicsLoadDistanceSquared)
						{
							if (!node.GameViewObject.IsPhysicsEnabled && !FlightSceneScript.Instance.TimeManager.CurrentMode.WarpMode)
							{
								node.GameViewObject.SetPhysicsEnabled(enabled: true, PhysicsChangeReason.LoadPhysics);
								result = true;
							}
						}
						else if (sqrMagnitude > num2 * 1.0499999523162842)
						{
							_removeList.Add(node.GameViewObject);
						}
						else if (sqrMagnitude > _physicsUnloadDistanceSquared && node.GameViewObject.IsPhysicsEnabled)
						{
							node.GameViewObject.SetPhysicsEnabled(enabled: false, PhysicsChangeReason.UnloadPhysics);
						}
					}
				}
			}
			foreach (IGameViewObject remove in _removeList)
			{
				RemoveGameViewObject(remove, flightEnd: false);
			}
			_removeList.Clear();
			return result;
		}

		private void OnNearCamPreRender(object sender, EventArgs e)
		{
			UpdateSunTerrainOcclusion();
		}

		private void OnPhysicsDistanceChanged(object sender, SettingChangedEventArgs<int> e)
		{
			UpdatePhysicsDistance(e.Setting);
		}

		private void OnPlanetNodeChanged(object sender, PlanetNodeChangeEventArgs e)
		{
			Debug.Log("Planet Node Changed. New: " + e.NewPlanetNode?.Name + ", Old: " + e.PreviousPlanetNode?.Name);
			_raycaster.SetQuadSphere(_planet.QuadSphere as QuadSphereScript);
			_quadPhysics = (PhysicsQuadManager)_planet.QuadSphere.PhysicsManager;
		}

		private void OnShadowSettingsChanged(object sender, SettingsChangedEventArgs<ShadowQualitySettings> e)
		{
			ApplyShadowQualitySettings(e.Category);
		}

		private bool RequiresSurfaceLock()
		{
			PhysicsQuadManager quadPhysics = _quadPhysics;
			if (quadPhysics == null || !quadPhysics.QuadsLoaded)
			{
				return _craftNode.Altitude < 250.0;
			}
			return true;
		}

		private void UpdateLight()
		{
			Vector3d normalized = (PlanetNode.SolarPosition + _craftNode.Position).normalized;
			ICraftFlightData flightData = _craftNode.CraftScript.FlightData;
			Quaternion q = Quaternion.LookRotation(normalized.ToVector3());
			_sunLightTransform.localRotation = ReferenceFrame.PlanetToFrameRotation(Quaterniond.FromQuaternion(q));
			Color color = Color.Lerp(PlanetScript.PlanetData.TerrainShaderData.NoonColor, _sunColor, 1E-05f * (float)flightData.AltitudeAboveGroundLevel);
			color.a = flightData.ParentPlanetOcclusion;
			_sunLight.color = color;
			_sunLight.enabled = flightData.ParentPlanetOcclusion > 0f;
			Shader.SetGlobalVector("_sunLightColor", _sunLight.color);
		}

		private void UpdatePhysicsDistance(Setting<int> physicsDistance)
		{
			double num = (double)(int)physicsDistance * 1000.0;
			_physicsLoadDistanceSquared = num * num;
			_physicsUnloadDistanceSquared = (num + 100.0) * (num + 100.0);
		}

		private void UpdatePhysicsQuads()
		{
			if (!_planet.PlanetData.HasTerrainPhysics)
			{
				return;
			}
			IQuadSphere quadSphere = _planet.QuadSphere;
			int maxSubdivisionLevel = quadSphere.MaxSubdivisionLevel;
			IPlanetNode planetNode = _planet.PlanetNode;
			int num = 0;
			double estimatedMinimumQuadSize = quadSphere.EstimatedMinimumQuadSize;
			if (estimatedMinimumQuadSize < 100.0)
			{
				num = 4;
			}
			else if (estimatedMinimumQuadSize < 250.0)
			{
				num = 2;
			}
			IReadOnlyList<INode> dynamicNodes = planetNode.DynamicNodes;
			for (int i = 0; i < dynamicNodes.Count; i++)
			{
				INode node = dynamicNodes[i];
				CraftNode craftNode = node as CraftNode;
				bool flag = node.GameViewObject.IsPhysicsEnabled;
				if (craftNode != null)
				{
					flag |= craftNode.PhysicsEnabledBeforeWarp;
				}
				if (!flag)
				{
					continue;
				}
				Vector3d position = planetNode.PlanetVectorToSurfaceVector(node.Position);
				int num2 = 2;
				int num3 = 1;
				ICraftScript craftScript = craftNode?.CraftScript;
				if (craftScript != null)
				{
					double altitudeAboveTerrain = craftNode.AltitudeAboveTerrain;
					double verticalSurfaceVelocity = craftScript.FlightData.VerticalSurfaceVelocity;
					if (altitudeAboveTerrain > 2000.0)
					{
						num2 = 0;
						num3 = 0;
					}
					else if (altitudeAboveTerrain > 1000.0)
					{
						if (verticalSurfaceVelocity > -100.0)
						{
							num2 = 0;
							num3 = 0;
						}
						else if (verticalSurfaceVelocity > -250.0)
						{
							num2 = 0;
							num3 = 3 + num;
						}
						else
						{
							num2 = 2;
							num3 = 1 + num;
						}
					}
					else if (altitudeAboveTerrain > 500.0)
					{
						if (verticalSurfaceVelocity > -100.0)
						{
							num2 = 0;
							num3 = 3 + num;
						}
						else
						{
							num2 = 2;
							num3 = 1 + num;
						}
					}
					else
					{
						num2 = 2;
						num3 = 1 + num;
					}
				}
				if (num2 > 0 || num3 > 0)
				{
					_quadPhysics.RegisterPhysicsPosition(position, maxSubdivisionLevel, num2, num3);
				}
			}
			_quadPhysics.UpdateQuads();
		}

		private void UpdateSunTerrainOcclusion()
		{
			if (!_gameCamera.ImageEffects.SunFlaresEnabled || Time.frameCount % 10 != 0)
			{
				return;
			}
			Ray ray = new Ray(GameCamera.Transform.position, -_sunLightTransform.forward);
			if (_asyncGpuReadback)
			{
				_raycaster.RaycastAsync(ray, delegate(QuadMeshRaycastHit result)
				{
					if (result != null)
					{
						_gameCamera.ImageEffects.SunOccludedByTerrain = result.Hit;
					}
				});
			}
			else
			{
				_gameCamera.ImageEffects.SunOccludedByTerrain = _raycaster.Raycast(ray).Hit;
			}
		}
	}
}
