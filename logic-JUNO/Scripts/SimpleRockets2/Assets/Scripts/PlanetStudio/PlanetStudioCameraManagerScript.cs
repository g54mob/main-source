using System;
using Assets.Scripts.Flight.GameView;
using ModApi.Flight.GameView;
using ModApi.Flight.GameView.Events;
using ModApi.Flight.Sim;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioCameraManagerScript : MonoBehaviour, IGameCamera
	{
		private bool _cameraSubmerged;

		[SerializeField]
		private ImageEffectsScript _imageEffects;

		[SerializeField]
		private CelestialBodyViewerScript _viewer;

		public double AltitudeAboveSeaLevel => _viewer.AltitudeSeaLevel;

		public PositionBiomeData CameraBiomeData { get; } = new PositionBiomeData();

		public ICameraShake CameraShake => null;

		public Vector3d CameraTargetPlanetPosition => _viewer.CameraPlanetPosition;

		public Camera FarCamera => _viewer.FarCamera;

		public Vector3 FramePosition => base.transform.position;

		public bool IsOffCenter => false;

		public Camera NearCamera => _viewer.NearCamera;

		public Vector3d PlanetPosition => _viewer.CameraPlanetPosition;

		public ICameraTarget Target => null;

		public Transform Transform => base.transform;

		public float FieldOfView
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public float FieldOfViewDefault
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public event EventHandler<CameraUnderwaterStateChangedEventArgs> CameraUnderWaterStateChanged;

		public void Recenter(bool immediate = false)
		{
			_viewer.RecenterReferenceFrame();
		}

		public void RegisterPositionOffset(CameraOffset offset)
		{
		}

		public void RegisterRotationOffset(CameraOffset offset)
		{
		}

		public void Rotate(Vector2 delta)
		{
		}

		public void UnregisterPositionOffset(CameraOffset offset)
		{
		}

		public void UnregisterRotationOffset(CameraOffset offset)
		{
		}

		public void Zoom(float zoomPercentage)
		{
		}

		protected virtual void LateUpdate()
		{
			UpdateUnderWaterEffects();
		}

		protected virtual void OnDestroy()
		{
			Shader.DisableKeyword("UNDERWATER");
		}

		protected virtual void Start()
		{
			Shader.DisableKeyword("UNDERWATER");
		}

		private void UpdateUnderWaterEffects()
		{
			IPlanetNode planetNode = _viewer.PlanetScript.PlanetNode;
			if (planetNode == null)
			{
				return;
			}
			bool flag = planetNode.PlanetData.HasWater && _viewer.AltitudeSeaLevel <= 0.05000000074505806 && _viewer.UnderwaterEffectsEnabled;
			if (_cameraSubmerged != flag)
			{
				_cameraSubmerged = flag;
				if (_cameraSubmerged)
				{
					Shader.EnableKeyword("UNDERWATER");
				}
				else
				{
					Shader.DisableKeyword("UNDERWATER");
				}
				this.CameraUnderWaterStateChanged?.Invoke(this, new CameraUnderwaterStateChangedEventArgs(_cameraSubmerged));
			}
			if (_imageEffects.Underwater.UnderWater != flag)
			{
				_imageEffects.Underwater.EnableWater(flag, 0);
			}
		}
	}
}
