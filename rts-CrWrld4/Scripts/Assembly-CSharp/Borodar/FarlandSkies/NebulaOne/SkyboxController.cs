using Borodar.FarlandSkies.Core.Helpers;
using UnityEngine;

namespace Borodar.FarlandSkies.NebulaOne
{
	[ExecuteInEditMode]
	public class SkyboxController : Singleton<SkyboxController>
	{
		public Material SkyboxMaterial;

		[SerializeField]
		private Cubemap _starfieldCubemap;

		[SerializeField]
		private Color _backgroundColor;

		[SerializeField]
		private Color _starsTint;

		[SerializeField]
		private float _starsBrightnessMin;

		[SerializeField]
		private float _starsBrightnessMax;

		[SerializeField]
		private Color _ambientTint;

		[SerializeField]
		private Color _basementTint;

		[SerializeField]
		private Color _ripplesTint1;

		[SerializeField]
		private Color _ripplesTint2;

		[SerializeField]
		private Cubemap _densityCubemap;

		[SerializeField]
		private Vector3 _densityRotation;

		private Matrix4x4 _densityRotationMatrix;

		[SerializeField]
		private float _densityThresholdLow;

		[SerializeField]
		private float _densityThresholdHigh;

		[SerializeField]
		private Cubemap _diffusionCubemap;

		[SerializeField]
		private Vector3 _ripplesDistortion;

		[SerializeField]
		private float _exposure;

		public Color BackgroundColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Cubemap StarfieldCubemap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color StarsTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float StarsBrightnessMin
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float StarsBrightnessMax
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color AmbientTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color BasementTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color RipplesTint1
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color RipplesTint2
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Cubemap DensityCubemap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 DensityRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float DensityThresholdLow
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DensityThresholdHigh
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Cubemap DiffusionCubemap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 RipplesDistortion
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Exposure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected void Awake()
		{
		}

		protected void OnValidate()
		{
		}

		private void UpdateSkyboxProperties()
		{
		}
	}
}
