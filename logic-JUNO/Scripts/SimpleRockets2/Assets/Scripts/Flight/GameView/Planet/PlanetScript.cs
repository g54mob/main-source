using System;
using Assets.Scripts.Flight.GameView.Planet.Events;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Social.Achievements;
using Assets.Scripts.Terrain;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Planet.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Planet
{
	public class PlanetScript : MonoBehaviour, IPlanet
	{
		private const double QuadSphereActivationRadiusFactor = 2.0;

		private bool _isHidden;

		private QuadSphereScript _quadSphere;

		private bool _quadSphereEnabled;

		private IReferenceFrame _referenceFrame;

		public bool IsHidden
		{
			get
			{
				return _isHidden;
			}
			set
			{
				_isHidden = value;
				UpdateQuadSphereActivationState();
			}
		}

		public IPlanetData PlanetData => PlanetNode.PlanetData;

		public IPlanetNode PlanetNode { get; private set; }

		public IQuadSphere QuadSphere => _quadSphere;

		public double QuadSphereActivationDistance { get; private set; }

		public bool QuadSphereEnabled
		{
			get
			{
				return _quadSphereEnabled;
			}
			private set
			{
				_quadSphereEnabled = value;
				UpdateQuadSphereActivationState();
			}
		}

		public bool QuadSphereScaledSpaceTransitionEnabled { get; set; }

		public double QuadSphereTransitionDistance { get; private set; }

		public float QuadSphereTransitionStrength { get; private set; }

		public static event EventHandler<PlanetScriptEventArgs> Initialized;

		public event EventHandler<PlanetNodeChangeEventArgs> PlanetNodeChanged;

		public event EventHandler<PlanetNodeChangeEventArgs> PlanetNodeChanging;

		public event EventHandler<PlanetQuadSphereEventArgs> QuadSphereEnabledStateChanged;

		public event EventHandler<PlanetQuadSphereEventArgs> QuadSphereLoaded;

		public event EventHandler<PlanetQuadSphereEventArgs> QuadSphereLoading;

		public event EventHandler<PlanetQuadSphereEventArgs> QuadSphereUnloaded;

		public event EventHandler<PlanetQuadSphereEventArgs> QuadSphereUnloading;

		public void Initialize(IReferenceFrame referenceFrame)
		{
			_referenceFrame = referenceFrame;
			PlanetScript.Initialized?.Invoke(this, new PlanetScriptEventArgs(this));
		}

		public void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			RecalculateFrameState(referenceFrame);
		}

		public void SetPlanetNode(IPlanetNode planetNode)
		{
			IPlanetNode planetNode2 = PlanetNode;
			if (planetNode2 != planetNode)
			{
				RaiseEvent(this.PlanetNodeChanging, planetNode2, planetNode);
				bool flag = _quadSphere != null;
				if (flag)
				{
					UnloadQuadSphere();
				}
				if (PlanetNode != null)
				{
					PlanetNode.UnloadTerrainData();
				}
				PlanetNode = planetNode;
				if (planetNode != null)
				{
					PlanetNode.LoadTerrainData();
					RaiseEvent(this.QuadSphereLoading, null);
					_quadSphere = CreateQuadSphere(flag);
					RaiseEvent(this.QuadSphereLoaded, _quadSphere);
					base.transform.localRotation = _referenceFrame.PlanetToFrameRotation(PlanetNode.Rotation);
					RecalculateFrameState(_referenceFrame);
					AchievementHelper.EnterSoi(PlanetNode.PlanetData);
				}
				RaiseEvent(this.PlanetNodeChanged, planetNode2, planetNode);
			}
		}

		public void UpdateTerrain(Vector3d focalPointPlanetPosition, bool synchronous)
		{
			if (PlanetNode == null || _quadSphere == null)
			{
				return;
			}
			if (!_referenceFrame.IsSurfaceLocked)
			{
				RecalculateFrameState(_referenceFrame);
				base.transform.localRotation = _referenceFrame.PlanetToFrameRotation(PlanetNode.Rotation);
			}
			if (synchronous)
			{
				CheckQuadSphereActivation(focalPointPlanetPosition.magnitude);
				_quadSphere.FullLodUpdate();
				return;
			}
			double magnitude = focalPointPlanetPosition.magnitude;
			if (CheckQuadSphereActivation(magnitude))
			{
				_quadSphere.UpdateLod(updateCulling: true);
				return;
			}
			_quadSphere.UpdateLod(updateCulling: false);
			int quadCreationThrottleRateForInactivePlanet = GetQuadCreationThrottleRateForInactivePlanet(magnitude);
			_quadSphere.ProcessAsynchronousJobs(quadCreationThrottleRateForInactivePlanet);
		}

		protected virtual void Awake()
		{
			QuadSphereScaledSpaceTransitionEnabled = true;
		}

		protected virtual void OnDestroy()
		{
			UnloadQuadSphere();
		}

		private bool CheckQuadSphereActivation(double distanceFromCenterOfPlanet)
		{
			bool quadSphereEnabled = QuadSphereEnabled;
			bool flag = quadSphereEnabled;
			if (QuadSphereScaledSpaceTransitionEnabled)
			{
				QuadSphereTransitionStrength = (float)Mathd.Clamp01(1.0 - (distanceFromCenterOfPlanet - QuadSphereActivationDistance) / QuadSphereTransitionDistance);
			}
			else
			{
				QuadSphereTransitionStrength = 1f;
			}
			bool num = QuadSphereTransitionStrength > 0f && QuadSphereTransitionStrength < 1f;
			bool flag2 = Shader.IsKeywordEnabled("BLEND_SCALED_SPACE");
			if (num)
			{
				if (!flag2)
				{
					Shader.EnableKeyword("BLEND_SCALED_SPACE");
				}
			}
			else if (flag2)
			{
				Shader.DisableKeyword("BLEND_SCALED_SPACE");
			}
			double num2 = QuadSphereActivationDistance + QuadSphereTransitionDistance;
			if (distanceFromCenterOfPlanet > num2 && QuadSphereScaledSpaceTransitionEnabled)
			{
				if (quadSphereEnabled)
				{
					flag = false;
				}
			}
			else if (!quadSphereEnabled)
			{
				flag = true;
			}
			if (flag != quadSphereEnabled)
			{
				QuadSphereEnabled = flag;
				RaiseEvent(this.QuadSphereEnabledStateChanged, _quadSphere);
			}
			return flag;
		}

		private QuadSphereScript CreateQuadSphere(bool soiTransition)
		{
			GameObject obj = new GameObject("QuadSphere");
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			Light sunLight;
			Camera nearCamera;
			if (Game.InFlightScene)
			{
				GameViewScript gameView = FlightSceneScript.Instance.ViewManager.GameView;
				sunLight = gameView.SunLight;
				nearCamera = gameView.GameCamera.NearCamera;
			}
			else
			{
				if (!Game.InPlanetStudioScene)
				{
					throw new NotSupportedException();
				}
				CelestialBodyDesignerScript obj2 = PlanetStudioScript.Instance?.CelestialBodyDesigner as CelestialBodyDesignerScript;
				sunLight = obj2.CelestialBodyViewer.SunLight;
				nearCamera = obj2.CelestialBodyViewer.NearCamera;
			}
			QuadSphereScript quadSphereScript = obj.AddComponent<QuadSphereScript>();
			quadSphereScript.Initialize(PlanetNode.PlanetData, PlanetNode.TerrainGenerator, sunLight.transform, nearCamera, soiTransition, _referenceFrame);
			float cubemapTransitionScale = Game.Instance.Settings.Quality.Terrain.CubemapSettings.CubemapTransitionScale;
			cubemapTransitionScale *= 0.1f * (float)Game.Instance.Settings.Quality.Terrain.LodDistance;
			double num = PlanetData.Radius + PlanetData.MaxEstimatedTerrainElevation;
			double num2 = Math.Max(20000.0, Math.Max(PlanetData.AtmosphereData.Height, 2 * (int)Game.Instance.Settings.Quality.Physics.PhysicsDistance));
			if (PlanetData.QuadSphereActivationDistance > 0.0)
			{
				QuadSphereActivationDistance = PlanetData.QuadSphereActivationDistance;
			}
			else
			{
				QuadSphereActivationDistance = Math.Max(num + num2, (1.0 + 1.0 * (double)cubemapTransitionScale) * num);
			}
			if (PlanetData.QuadSphereTransitionDistance > 0.0)
			{
				QuadSphereTransitionDistance = PlanetData.QuadSphereTransitionDistance;
			}
			else
			{
				QuadSphereTransitionDistance = Math.Max(num2, 2.0 * (double)cubemapTransitionScale * num);
			}
			QuadSphereEnabled = true;
			IsHidden = false;
			return quadSphereScript;
		}

		private int GetQuadCreationThrottleRateForInactivePlanet(double distanceFromCenterOfPlanet)
		{
			if (distanceFromCenterOfPlanet < QuadSphereActivationDistance + 100000.0)
			{
				return 4;
			}
			return 2;
		}

		private void RaiseEvent(EventHandler<PlanetNodeChangeEventArgs> eventHandler, IPlanetNode previousNode, IPlanetNode newNode)
		{
			eventHandler?.Invoke(this, new PlanetNodeChangeEventArgs(this, previousNode, newNode));
		}

		private void RaiseEvent(EventHandler<PlanetQuadSphereEventArgs> eventHandler, IQuadSphere quadsphere)
		{
			eventHandler?.Invoke(this, new PlanetQuadSphereEventArgs(this, quadsphere));
		}

		private void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			Vector3d framePosition = referenceFrame.PlanetToFramePositiond(Vector3d.zero);
			base.transform.localPosition = framePosition.ToVector3();
			if (_quadSphere != null)
			{
				_quadSphere.FramePosition = framePosition;
				_quadSphere.RecalculateFrameState(referenceFrame);
			}
		}

		private void UnloadQuadSphere()
		{
			if (_quadSphere != null)
			{
				RaiseEvent(this.QuadSphereUnloading, _quadSphere);
				_quadSphere.Unload();
				_quadSphere = null;
				RaiseEvent(this.QuadSphereUnloaded, null);
			}
		}

		private void UpdateQuadSphereActivationState()
		{
			if (_quadSphere != null)
			{
				_quadSphere.gameObject.SetActive(QuadSphereEnabled && !IsHidden);
			}
		}
	}
}
