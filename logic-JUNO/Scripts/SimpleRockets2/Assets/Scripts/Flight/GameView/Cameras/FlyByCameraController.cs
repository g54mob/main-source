using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public class FlyByCameraController : CameraController
	{
		private enum FlyByModeType
		{
			FullVelocity = 0,
			Cinematic = 1
		}

		private Vector3 _cameraFramePosition;

		private Vector3 _cameraOffset;

		private IOrbit _cameraOrbit;

		private Vector3d _cameraPlanetPosition;

		private Vector3d _cameraSurfacePosition;

		private CameraControllerDebug _debugScript;

		private double _flyByVantageEndTime;

		private float _flyByVantageStartDistance;

		private FlyByModeType _mode;

		private bool _newVantageHasBegun;

		private double _relativeCameraSpeed = 50.0;

		private double _secondsAheadToPlaceVantagePoint = 5.0;

		public override bool AllowDefault => false;

		public override float MinimumAgl => 50f;

		public override string Type => "Fly-by";

		private bool DisabledDueToTerrain { get; set; }

		public FlyByCameraController(CameraManagerScript cameraManager)
			: base(cameraManager)
		{
			_mode = FlyByModeType.FullVelocity;
		}

		public void DebugScriptSettingsChanged()
		{
			if (_debugScript != null)
			{
				_secondsAheadToPlaceVantagePoint = _debugScript.FlybySecondsAhead;
				_relativeCameraSpeed = _debugScript.RelativeCameraSpeed;
			}
			StartNewFlyByVantage();
		}

		public override void OnSelected(int subMode)
		{
			base.OnSelected(subMode);
			switch (subMode)
			{
			case 0:
				_mode = FlyByModeType.FullVelocity;
				break;
			case 1:
				_mode = FlyByModeType.Cinematic;
				break;
			default:
				throw new Exception($"Unknown submode: {subMode}");
			}
			if (Game.Instance.Device.IsDebugBuild && _debugScript == null)
			{
				_debugScript = base.CameraManager.gameObject.AddComponent<CameraControllerDebug>();
				_debugScript.FlybySecondsAhead = (float)_secondsAheadToPlaceVantagePoint;
				_debugScript.RelativeCameraSpeed = (float)_relativeCameraSpeed;
				_debugScript.Initialize(this);
			}
			StartNewFlyByVantage();
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			float currentCameraDistance = GetCurrentCameraDistance();
			float num = _flyByVantageStartDistance * 2f;
			bool num2 = currentCameraDistance > num;
			bool flag = base.Target.OrbitNode.Orbit.Time > _flyByVantageEndTime;
			if (num2 && flag)
			{
				StartNewFlyByVantage();
			}
			if (!DisabledDueToTerrain)
			{
				if (_mode == FlyByModeType.FullVelocity)
				{
					Vector3d planetPosition = ((!base.GameView.ReferenceFrame.IsSurfaceLocked) ? _cameraPlanetPosition : base.Target.OrbitNode.Parent.SurfaceVectorToPlanetVector(_cameraSurfacePosition));
					Vector3 vector = base.GameView.ReferenceFrame.PlanetToFramePosition(planetPosition);
					SetCameraPosition(vector + _cameraOffset);
				}
				else if (_mode == FlyByModeType.Cinematic && !base.Target.OrbitNode.IsDestroyed)
				{
					IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(_cameraOrbit, base.Target.OrbitNode.Orbit.Time);
					Vector3 vector2 = base.GameView.ReferenceFrame.PlanetToFramePosition(pointAtTime.Position);
					SetCameraPosition(vector2 + _cameraOffset);
				}
			}
			base.CameraTransform.LookAt(base.Target.CameraTarget, -Physics.gravity);
			if (_newVantageHasBegun)
			{
				_newVantageHasBegun = false;
				_flyByVantageStartDistance = GetCurrentCameraDistance() * 1.02f;
				_flyByVantageEndTime = base.Target.OrbitNode.Orbit.Time + _secondsAheadToPlaceVantagePoint * 2.0;
			}
			base.PlanetPosition = base.GameView.ReferenceFrame.FrameToPlanetPosition(base.CameraTransform.position);
		}

		protected override void OnCameraBelowTerrain(Vector3 suggestedCameraFramePos, double distanceRaised)
		{
			SetCameraPosition(suggestedCameraFramePos);
			DisabledDueToTerrain = true;
		}

		private List<AudioSource> GetAudioSources()
		{
			List<AudioSource> list = new List<AudioSource>();
			foreach (CraftNode craftNode in FlightSceneScript.Instance.FlightState.CraftNodes)
			{
				if (craftNode.IsLoadedInGameView)
				{
					list.AddRange(craftNode.CraftScript.Transform.GetComponentsInChildren<AudioSource>());
				}
			}
			return list;
		}

		private float GetCurrentCameraDistance()
		{
			return (base.Target.CameraTarget.position - base.CameraTransform.position).magnitude;
		}

		private float GetDopplarLevel(float velocity)
		{
			if (_mode == FlyByModeType.Cinematic)
			{
				return 0.1f;
			}
			return Mathf.Clamp(1f / (velocity / 100f), 1E-06f, 0.1f);
		}

		private void SetCameraPosition(Vector3 position)
		{
			if (!double.IsNaN(position.x) && !double.IsNaN(position.y) && !double.IsNaN(position.z))
			{
				base.CameraTransform.parent.position = position;
				base.CameraTransform.localPosition = Vector3.zero;
			}
		}

		private void StartNewFlyByVantage()
		{
			DisabledDueToTerrain = false;
			IOrbitPoint orbitPoint = null;
			float num = 0f;
			IOrbit orbit = base.Target.OrbitNode.Orbit;
			double timeOfPoint = orbit.Time + _secondsAheadToPlaceVantagePoint;
			orbitPoint = OrbitMath.GetPointAtTime(orbit, timeOfPoint);
			if (_mode == FlyByModeType.FullVelocity)
			{
				_cameraPlanetPosition = orbitPoint.Position;
				_cameraSurfacePosition = base.Target.OrbitNode.Parent.PlanetVectorToSurfaceVectorAtTime(_cameraPlanetPosition, orbitPoint.Time);
				num = Mathf.Clamp((float)base.Target.OrbitNode.Orbit.Velocity.magnitude / 4f, 20f, 1000f);
			}
			else if (_mode == FlyByModeType.Cinematic)
			{
				double num2 = orbitPoint.Velocity.magnitude - _relativeCameraSpeed;
				_cameraOrbit = new Orbit(orbitPoint.Position, orbitPoint.Velocity.normalized * num2, orbitPoint.Time, orbit.PrimaryMass);
				num = 20f;
			}
			else
			{
				Debug.LogError("Unsupported fly-by mode");
			}
			Vector3 vector = base.Target.CameraTarget.forward + base.Target.CameraTarget.right + base.Target.CameraTarget.up;
			_cameraOffset = vector * num;
			_newVantageHasBegun = true;
		}
	}
}
