using System;
using System.Collections.Generic;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Planet;
using ModApi.Planet.Modifiers.Material;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public abstract class CameraController
	{
		public delegate void IsSelectedChangedHandler(CameraController source, bool selected);

		private bool _enabled = true;

		private Camera _farCamera;

		private Vector3[] _frustumCornersTemp;

		private float _minHeightAboveSurface = 1f;

		private Camera _nearCamera;

		private IReferenceFrame _referenceFrame;

		private MSUnderWaterEffect _underwaterImageEffect;

		private bool _waterWavesEnabled;

		public abstract bool AllowDefault { get; }

		public virtual bool AllowPartSelection => true;

		public double AltitudeAsl { get; private set; }

		public virtual Vector3 AngularVelocity => Vector3.zero;

		public bool AutoSwitchWhenBelowWater { get; protected set; }

		public CameraManagerScript CameraManager { get; private set; }

		public List<CameraMode> CameraModes { get; private set; } = new List<CameraMode>();

		public Transform CameraTransform => CameraManager.CameraTransform;

		public virtual Vector2 CurrentRotation { get; set; }

		public virtual float CurrentTilt { get; set; }

		public virtual float CurrentZoom { get; set; }

		public string DefaultName => Type ?? "";

		public float DistanceToTarget { get; private set; }

		public bool Enabled => _enabled;

		public bool IsCustom { get; set; }

		public bool IsOffCenter { get; protected set; }

		public bool IsSelected { get; private set; }

		public bool KeepAboveWater { get; set; }

		public bool LockPosition { get; set; }

		public virtual float MinimumAgl => _minHeightAboveSurface + Mathf.Abs(CameraTransform.localPosition.z * 0.0001f);

		public string Name { get; set; }

		public Func<float> NearClipOverride { get; set; }

		public Vector3d PlanetPosition { get; protected set; }

		public bool RequiresPlaneCamera { get; protected set; }

		public ICameraTarget StaticTarget { get; set; }

		public ICameraTarget Target => StaticTarget ?? CameraManager.Target;

		public abstract string Type { get; }

		public virtual bool VaporTrailsVisible => true;

		protected IGameView GameView { get; }

		protected virtual string PlayerPrefKey => Game.Instance.Inputs.NextCameraMode.Id + Name;

		public event IsSelectedChangedHandler IsSelectedChanged;

		public CameraController(CameraManagerScript cameraManager)
		{
			Name = DefaultName;
			CameraManager = cameraManager;
			GameView = Game.Instance.FlightScene.ViewManager.GameView;
			_frustumCornersTemp = new Vector3[4];
			_referenceFrame = GameView.ReferenceFrame;
			_nearCamera = ((IGameCamera)cameraManager).NearCamera;
			_farCamera = ((IGameCamera)cameraManager).FarCamera;
			_underwaterImageEffect = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Transform.GetComponentInChildren<MSUnderWaterEffect>();
			_waterWavesEnabled = WaterMaterialModifier.AreWavesEnabled();
			Game.Instance.QualitySettings.Water.Waves.Changed += OnWaterWavesEnabledChanged;
		}

		public virtual void OnApplicaitionFocus(bool focus)
		{
		}

		public virtual bool OnBeginDrag(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnBeginPinch(PinchEventData eventData)
		{
			return false;
		}

		public virtual void OnDeselected()
		{
			IsSelected = false;
			this.IsSelectedChanged?.Invoke(this, IsSelected);
		}

		public virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Water.Waves.Changed -= OnWaterWavesEnabledChanged;
		}

		public virtual bool OnDrag(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnEndDrag(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnEndPinch(PinchEventData eventData)
		{
			return false;
		}

		public virtual bool OnPinch(PinchEventData eventData)
		{
			return false;
		}

		public virtual bool OnPointerClick(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnPointerDown(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnPointerUp(PointerEventData eventData)
		{
			return false;
		}

		public virtual void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
		}

		public virtual bool OnScroll(PointerEventData eventData)
		{
			return false;
		}

		public virtual void OnSelected(int subMode)
		{
			_minHeightAboveSurface = ((CameraManager.CurrentCameraController.Name == "FPS") ? 0.05f : 1f);
			PlanetPosition = GameView.ReferenceFrame.FrameToPlanetPosition(CameraTransform.position);
			IsSelected = true;
			this.IsSelectedChanged?.Invoke(this, IsSelected);
		}

		public virtual void Pan(Vector2 delta)
		{
		}

		public virtual void PostUpdate(bool recenteringReferenceFrame)
		{
			PlanetPosition = GameView.ReferenceFrame.FrameToPlanetPosition(CameraTransform.position);
			if (!recenteringReferenceFrame)
			{
				if (CheckCameraForTerrainIntersection(out var agl))
				{
					PlanetPosition = GameView.ReferenceFrame.FrameToPlanetPosition(CameraTransform.position);
				}
				DistanceToTarget = (Target.CameraTarget.position - CameraTransform.position).magnitude;
				AdjustCameraClipPlanes(agl, DistanceToTarget);
			}
		}

		public virtual void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
		}

		public virtual void Recenter(bool immediate = false)
		{
		}

		public virtual void Rotate(Vector2 delta)
		{
		}

		public void SetEnabled(bool enabled, bool notifyCameraManager)
		{
			bool num = _enabled != enabled;
			_enabled = enabled;
			if (num && notifyCameraManager)
			{
				CameraManager.OnControllerEnabledChanged(this);
			}
		}

		public virtual void Tilt(float delta)
		{
		}

		public virtual void Update(int frameCount)
		{
		}

		public virtual void Zoom(float zoomPercentage)
		{
		}

		protected virtual void OnCameraBelowTerrain(Vector3 suggestedCameraFramePos, double distanceRaised)
		{
			CameraTransform.position = suggestedCameraFramePos;
		}

		private void AdjustCameraClipPlanes(double agl, float distFromCraft)
		{
			float num;
			if (NearClipOverride == null)
			{
				num = Mathf.Abs(distFromCraft) * 0.1f;
				double num2 = Mathd.Min(agl, AltitudeAsl);
				if (num2 < 20.0)
				{
					num = Mathf.Min(num, (float)num2 * 0.5f);
				}
				if (num < 1f)
				{
					int num3 = (int)(num * 10f);
					num = (float)(num3 - num3 % 2) / 10f;
				}
				else
				{
					num = (int)num;
				}
				num = Mathf.Clamp(num, 0.1f, 6f);
			}
			else
			{
				num = NearClipOverride();
			}
			_nearCamera.nearClipPlane = num;
			float num4 = Mathf.Min(num, 1f);
			_nearCamera.farClipPlane = 10000f * num4;
			_farCamera.nearClipPlane = 9995f * num4;
			_underwaterImageEffect.UpdateWaterDropsSize();
		}

		private bool CheckCameraForTerrainIntersection(out double agl)
		{
			IPlanetNode planetNode = GameView.PlanetNode;
			double magnitude = PlanetPosition.magnitude;
			double num = magnitude - planetNode.PlanetData.Radius;
			AltitudeAsl = num - (double)planetNode.PlanetData.SeaLevel - (double)(_waterWavesEnabled ? _referenceFrame.GetWaterWaveOffset(CameraTransform.position, null) : 0f);
			agl = num;
			bool result = false;
			if (num < GameView.Planet.QuadSphere.TerrainMaxHeight + 20000.0)
			{
				Vector3d vector3d = PlanetPosition / magnitude;
				double num2 = MinimumAgl;
				PlanetVertexData terrainVertexData = planetNode.GetTerrainVertexData(VertexDataRequestType.AllData, PlanetPosition, PlanetPosition);
				double num3 = terrainVertexData.Height;
				int num4;
				if (KeepAboveWater)
				{
					num4 = (planetNode.PlanetData.HasWater ? 1 : 0);
					if (num4 != 0)
					{
						num3 = Mathd.Max(num3, planetNode.PlanetData.SeaLevel);
					}
				}
				else
				{
					num4 = 0;
				}
				agl -= num3;
				double num5 = num3 + num2 - num;
				Vector3 vector = GameView.ReferenceFrame.PlanetToFrameVector(vector3d);
				Vector3 vector2 = -vector;
				_nearCamera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), _nearCamera.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, _frustumCornersTemp);
				Vector3 vector3 = vector2 * 0.25f;
				Vector3 vector4 = CameraTransform.TransformPoint(_frustumCornersTemp[0]) + vector3;
				Vector3 vector5 = CameraTransform.TransformPoint(_frustumCornersTemp[3]) + vector3;
				float num6 = 10f;
				Vector3 vector6 = vector * num6;
				int layerMask = 536870912;
				float? num7 = null;
				if (Physics.Raycast(vector4 + vector6, vector2, out var hitInfo, num6, layerMask, QueryTriggerInteraction.Ignore))
				{
					num7 = hitInfo.distance;
				}
				if (Physics.Raycast(vector5 + vector6, vector2, out hitInfo, num6, layerMask, QueryTriggerInteraction.Ignore))
				{
					num7 = ((!num7.HasValue) ? hitInfo.distance : Math.Min(num7.Value, hitInfo.distance));
				}
				if (num7.HasValue)
				{
					num5 = Math.Max(num5, num6 - num7.Value);
				}
				if (num4 != 0 && num - (double)planetNode.PlanetData.SeaLevel < 10.0)
				{
					double num8 = planetNode.PlanetData.Radius + (double)planetNode.PlanetData.SeaLevel;
					double num9 = num8 * num8;
					Vector3 framePosition = (vector4 + vector5) * 0.5f;
					double sqrMagnitude = GameView.ReferenceFrame.FrameToPlanetPosition(framePosition).sqrMagnitude;
					if (sqrMagnitude < num9)
					{
						double val = num8 - Math.Sqrt(sqrMagnitude);
						num5 = Math.Max(num5, val);
					}
				}
				if (num5 > 0.0)
				{
					agl -= num5;
					result = true;
					Vector3d planetPosition = PlanetPosition + vector3d * num5;
					Vector3 suggestedCameraFramePos = GameView.ReferenceFrame.PlanetToFramePosition(planetPosition);
					OnCameraBelowTerrain(suggestedCameraFramePos, num5);
				}
				CameraManager.CameraBiomeData.UpdateCameraPositionData(terrainVertexData, planetNode.PlanetData.TerrainData);
			}
			else
			{
				CameraManager.CameraBiomeData.UpdateCameraPositionData(null, null);
			}
			return result;
		}

		private void OnWaterWavesEnabledChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			_waterWavesEnabled = WaterMaterialModifier.AreWavesEnabled();
		}
	}
}
