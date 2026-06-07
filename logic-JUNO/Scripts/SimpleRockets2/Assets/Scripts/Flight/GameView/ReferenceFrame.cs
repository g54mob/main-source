using System;
using ModApi;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView
{
	public class ReferenceFrame : IReferenceFrame
	{
		private Vector3d _center;

		private IGameTime _gameTime;

		private Vector3d _planetLocalPosition;

		private double _planetLocalRotation;

		private Vector3d _planetLocalSurfaceVelocity;

		private IPlanetNode _planetNode;

		private Quaternion _rotation;

		private double _rotationAngle;

		private Quaternion _rotationInverse;

		private Vector3d _waterWaveOffset;

		public Vector3d Center
		{
			get
			{
				return _center;
			}
			private set
			{
				_center = value;
			}
		}

		public double DeltaRotation { get; private set; }

		public Vector3 FrameSurfaceVelocity { get; private set; }

		public bool IsSurfaceLocked { get; private set; }

		public bool RecenterEnabled { get; set; } = true;

		public double RotationAngle
		{
			get
			{
				return _rotationAngle;
			}
			private set
			{
				_rotationAngle = value;
				float num = (float)(_rotationAngle * 57.295780181884766);
				_rotation = Quaternion.Euler(0f, num, 0f);
				_rotationInverse = Quaternion.Euler(0f, 0f - num, 0f);
			}
		}

		public Vector3d SurfaceVelocity { get; private set; }

		public Vector3d Velocity { get; private set; }

		public Vector3d WaterWaveOffset => _waterWaveOffset;

		public ReferenceFrame()
		{
			RotationAngle = 0.0;
			if (Game.InFlightScene)
			{
				_gameTime = Game.Instance.FlightScene.IocContainer.Resolve<IGameTime>();
			}
		}

		public Vector3d FrameToPlanetPosition(Vector3 framePosition)
		{
			Vector3d vector3d = FrameToPlanetVector(framePosition);
			return new Vector3d(Center.x + vector3d.x, Center.y + vector3d.y, Center.z + vector3d.z);
		}

		public Quaterniond FrameToPlanetRotation(Quaternion frameRotation)
		{
			return Quaterniond.FromQuaternion(_rotation * frameRotation);
		}

		public Vector3d FrameToPlanetVector(Vector3 frameVector)
		{
			return Utilities.RotateVectorAroundYAxis(frameVector, RotationAngle);
		}

		public Vector3d FrameToPlanetVelocity(Vector3 frameVelocity)
		{
			Vector3d vector3d = FrameToPlanetVector(frameVelocity);
			return new Vector3d(Velocity.x + vector3d.x, Velocity.y + vector3d.y, Velocity.z + vector3d.z);
		}

		public double GetAltitudeAsl(Vector3 framePos, bool includeWaves, ICraftScript craft)
		{
			Vector3d vector3d = FrameToPlanetPosition(framePos);
			double num = _planetNode.PlanetData.Radius + (double)_planetNode.PlanetData.SeaLevel;
			if (includeWaves)
			{
				num += (double)GetWaterWaveOffset(framePos, craft);
			}
			return vector3d.magnitude - num;
		}

		public Vector3 GetWaterPosBelowPoint(Vector3 framePos, bool includeWaves, ICraftScript craft)
		{
			Vector3d vector3d = FrameToPlanetPosition(framePos);
			double num = _planetNode.PlanetData.Radius + (double)_planetNode.PlanetData.SeaLevel;
			if (includeWaves)
			{
				num += (double)GetWaterWaveOffset(framePos, craft);
			}
			Vector3d planetPosition = vector3d.normalized * num;
			return PlanetToFramePosition(planetPosition);
		}

		public float GetWaterWaveOffset(Vector3 framePosition, ICraftScript craft)
		{
			if (craft != null)
			{
				return GetWaterWaveOffset(framePosition, (float)craft.CraftNode.AltitudeAboveTerrain);
			}
			float agl = 200f;
			if (Physics.Raycast(framePosition, Physics.gravity, out var hitInfo, 200f, 603979776))
			{
				agl = hitInfo.distance;
			}
			return GetWaterWaveOffset(framePosition, agl);
		}

		public float GetWaterWaveOffset(Vector3 framePosition, float agl)
		{
			PlanetWaterConfig waterConfigDefault = _planetNode.PlanetData.TerrainData.WaterConfigDefault;
			float num = 1f;
			if (Game.InFlightScene)
			{
				num = (float)FlightSceneScript.Instance.CraftBiomeData.WaterConfig.WaveAmplitudeScale / 100f;
			}
			float num2 = MathF.PI * 2f / ((waterConfigDefault.WaveLength > 0f) ? waterConfigDefault.WaveLength : 1f);
			float num3 = waterConfigDefault.WaveSpeed * (float)_gameTime.WaveTime;
			Vector3 vector = GetWaterPosBelowPoint(framePosition, includeWaves: false, null) - (Vector3)_waterWaveOffset;
			float num4 = Mathf.Sin(num2 * (vector.x - num3));
			float num5 = Mathf.Sin(num2 * (vector.y - num3));
			float num6 = Mathf.Sin(num2 * (vector.z - num3));
			float num7 = Mathf.Clamp01(agl / 20f);
			return num * waterConfigDefault.WaveAmplitude * num7 * (num4 + num5 + num6);
		}

		public Vector3 PlanetToFramePosition(Vector3d planetPosition)
		{
			Vector3d planetVector = planetPosition - Center;
			return PlanetToFrameVector(planetVector);
		}

		public Vector3 PlanetToFramePositionAtTime(Vector3d planetPosition, double time)
		{
			Vector3d vector3d = Center + Velocity * (time - FlightSceneScript.Instance.FlightState.Time);
			Vector3d planetVector = planetPosition - vector3d;
			return PlanetToFrameVector(planetVector);
		}

		public Vector3d PlanetToFramePositiond(Vector3d planetPosition)
		{
			Vector3d planetVector = planetPosition - Center;
			return PlanetToFrameVectord(planetVector);
		}

		public Quaternion PlanetToFrameRotation(Quaterniond planetRotation)
		{
			return _rotationInverse * planetRotation.ToQuaternion();
		}

		public Vector3 PlanetToFrameVector(Vector3d planetVector)
		{
			return Utilities.RotateVectorAroundYAxis(planetVector, 0.0 - RotationAngle).ToVector3();
		}

		public Vector3 PlanetToFrameVelocity(Vector3d planetVelocity)
		{
			Vector3d planetVector = planetVelocity - Velocity;
			return PlanetToFrameVector(planetVector);
		}

		public void Recenter(Vector3d center, Vector3d velocity, IPlanetNode planetNode, bool surfaceLock, out Vector3d positionDelta, out Vector3d velocityDelta)
		{
			Vector3d center2 = Center;
			Vector3d velocity2 = Velocity;
			Center = center;
			Velocity = velocity;
			_planetNode = planetNode;
			IsSurfaceLocked = surfaceLock;
			positionDelta = center2 - Center;
			velocityDelta = velocity2 - Velocity;
			if (surfaceLock)
			{
				CalculateLocalSurfaceVelocity();
				_planetLocalRotation = RotationAngle - planetNode.RotationAngle;
				_planetLocalPosition = planetNode.PlanetVectorToSurfaceVector(Center);
				Velocity = _planetNode.SurfaceVectorToPlanetVector(_planetLocalSurfaceVelocity);
				FrameSurfaceVelocity = Vector3.zero;
				SurfaceVelocity = Vector3d.zero;
			}
			else
			{
				UpdateSurfaceVelocity();
			}
			float num = (planetNode.PlanetData.TerrainData?.WaterConfigDefault)?.WaveLength ?? 0f;
			if (num > 0f)
			{
				_waterWaveOffset += (Vector3d)PlanetToFrameVector(positionDelta);
				_waterWaveOffset = MathUtils.FmodComponents(_waterWaveOffset, num);
			}
		}

		public void Update(double elapsedTime)
		{
			if (IsSurfaceLocked)
			{
				double num = _planetNode.RotationAngle + _planetLocalRotation;
				DeltaRotation = num - RotationAngle;
				RotationAngle = num;
				Center = _planetNode.SurfaceVectorToPlanetVector(_planetLocalPosition);
				Velocity = _planetNode.SurfaceVectorToPlanetVector(_planetLocalSurfaceVelocity);
			}
			else
			{
				DeltaRotation = 0.0;
				Center += Velocity * elapsedTime;
				UpdateSurfaceVelocity();
			}
		}

		private void CalculateLocalSurfaceVelocity()
		{
			if (_planetNode != null)
			{
				Vector3d surfacePoint = _planetNode.PlanetVectorToSurfaceVector(Center.normalized * _planetNode.PlanetData.Radius);
				_planetLocalSurfaceVelocity = _planetNode.CalculateSurfaceVelocity(surfacePoint);
			}
			else
			{
				_planetLocalSurfaceVelocity = Vector3d.zero;
			}
		}

		private Vector3d PlanetToFrameVectord(Vector3d planetVector)
		{
			return Utilities.RotateVectorAroundYAxis(planetVector, 0.0 - RotationAngle);
		}

		private void UpdateSurfaceVelocity()
		{
			CalculateLocalSurfaceVelocity();
			Vector3d vector3d = _planetNode.SurfaceVectorToPlanetVector(_planetLocalSurfaceVelocity);
			SurfaceVelocity = Velocity - vector3d;
			FrameSurfaceVelocity = PlanetToFrameVector(SurfaceVelocity);
		}
	}
}
