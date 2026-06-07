using System;
using Assets.Scripts.Flight.ScaledSpace;
using ModApi.Planet;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Terrain.Rendering
{
	[Serializable]
	public class PlanetRenderingData
	{
		[SerializeField]
		private float _atmosphereHeight;

		[SerializeField]
		private Transform _camera;

		[SerializeField]
		private Vector3 _center = Vector3.zero;

		private PlanetShaderData _defaultShaderDataAtmosphere;

		private PlanetShaderData _defaultShaderDataTerrain;

		[SerializeField]
		private bool _hasAtmosphere;

		[SerializeField]
		private Transform _light;

		[SerializeField]
		private float _radius;

		[SerializeField]
		private float _radiusScaledSpace;

		[SerializeField]
		private float _seaLevel;

		[SerializeField]
		[FormerlySerializedAs("_shaderDataAtmosphere")]
		private PlanetShaderData _shaderDataSky;

		[SerializeField]
		private PlanetShaderData _shaderDataTerrain;

		[SerializeField]
		private bool _syncShaderData;

		[SerializeField]
		private Transform _transform;

		public float AtmosphereHeight
		{
			get
			{
				return _atmosphereHeight;
			}
			private set
			{
				_atmosphereHeight = value;
			}
		}

		public Transform Camera
		{
			get
			{
				return _camera;
			}
			private set
			{
				_camera = value;
			}
		}

		public Vector3 Center
		{
			get
			{
				if (!(_transform != null))
				{
					return _center;
				}
				return _transform.position;
			}
			set
			{
				_transform = null;
				_center = value;
			}
		}

		public bool HasAtmosphere
		{
			get
			{
				return _hasAtmosphere;
			}
			private set
			{
				_hasAtmosphere = value;
			}
		}

		public Transform Light
		{
			get
			{
				return _light;
			}
			private set
			{
				_light = value;
			}
		}

		public float Radius
		{
			get
			{
				return _radius;
			}
			private set
			{
				_radius = value;
			}
		}

		public float RadiusScaledSpace
		{
			get
			{
				return _radiusScaledSpace;
			}
			private set
			{
				_radiusScaledSpace = value;
			}
		}

		public float SeaLevel
		{
			get
			{
				return _seaLevel;
			}
			private set
			{
				_seaLevel = value;
			}
		}

		public PlanetShaderData ShaderDataSky
		{
			get
			{
				return _shaderDataSky;
			}
			private set
			{
				_shaderDataSky = value;
			}
		}

		public PlanetShaderData ShaderDataTerrain
		{
			get
			{
				return _shaderDataTerrain;
			}
			private set
			{
				_shaderDataTerrain = value;
			}
		}

		public bool SyncShaderData
		{
			get
			{
				return _syncShaderData;
			}
			set
			{
				_syncShaderData = value;
			}
		}

		public Transform Transform
		{
			get
			{
				return _transform;
			}
			private set
			{
				_transform = value;
			}
		}

		public PlanetRenderingData(QuadSphereScript quadSphere)
			: this(quadSphere.PlanetData, quadSphere.Transform, quadSphere.Camera, quadSphere.DirectionalLight)
		{
		}

		public PlanetRenderingData(ScaledSpacePlanetScript planet, Transform camera, Transform sun)
			: this(planet.PlanetNode.PlanetData, planet.transform, camera, sun)
		{
		}

		public PlanetRenderingData(IPlanetData planetData, Transform planet, Transform camera, Transform light)
		{
			if (planetData == null)
			{
				throw new ArgumentNullException("planetData");
			}
			Transform = planet;
			Camera = camera;
			Light = light;
			Radius = (float)planetData.Radius;
			RadiusScaledSpace = (float)planetData.RadiusScaledSpace;
			SeaLevel = (planetData.HasWater ? planetData.SeaLevel : 0f);
			AtmosphereHeight = (float)planetData.AtmosphereData.Height;
			HasAtmosphere = planetData.SkyShaderEnabled;
			SyncShaderData = planetData.SyncPropertiesFromTerrain;
			_defaultShaderDataTerrain = planetData.TerrainShaderData;
			ShaderDataTerrain = PlanetShaderData.Clone(_defaultShaderDataTerrain);
			_defaultShaderDataAtmosphere = planetData.SkyShaderData;
			ShaderDataSky = PlanetShaderData.Clone(_defaultShaderDataAtmosphere);
			if (SyncShaderData)
			{
				ShaderDataSky.CopyFrom(ShaderDataTerrain);
			}
		}

		public PlanetRenderingData(Vector3 surfacePosition, Transform camera, Transform light)
		{
			if (camera == null)
			{
				throw new ArgumentNullException("camera");
			}
			if (light == null)
			{
				throw new ArgumentNullException("light");
			}
			Camera = camera;
			Light = light;
			Radius = 637100f;
			RadiusScaledSpace = Radius * 0.0001f;
			SeaLevel = 0f;
			AtmosphereHeight = 60000f;
			HasAtmosphere = false;
			Center = new Vector3(surfacePosition.x, surfacePosition.y - Radius + 5000f, surfacePosition.z);
			_defaultShaderDataTerrain = new PlanetShaderData().SetDefaults(PlanetShaderData.Type.Surface);
			ShaderDataTerrain = PlanetShaderData.Clone(_defaultShaderDataTerrain);
			_defaultShaderDataAtmosphere = new PlanetShaderData().SetDefaults(PlanetShaderData.Type.Sky);
			ShaderDataSky = PlanetShaderData.Clone(_defaultShaderDataAtmosphere);
		}

		public void ResetToDefaults()
		{
			ShaderDataTerrain = PlanetShaderData.Clone(_defaultShaderDataTerrain);
			ShaderDataSky = PlanetShaderData.Clone(ShaderDataSky);
			if (SyncShaderData)
			{
				ShaderDataSky.CopyFrom(ShaderDataTerrain);
			}
		}
	}
}
