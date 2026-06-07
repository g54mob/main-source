using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SceneLookAndFeel : Settings
	{
		[SerializeField]
		private bool _drawLightIcons = true;

		[SerializeField]
		private bool _drawParticleSystemIcons = true;

		[SerializeField]
		private bool _drawCameraIcons = true;

		[SerializeField]
		private float _lightIconAlpha = 0.7f;

		[SerializeField]
		private float _particleSystemIconAlpha = 0.7f;

		[SerializeField]
		private float _cameraIconAlpha = 0.7f;

		[SerializeField]
		private Texture2D _lightIcon;

		[SerializeField]
		private Texture2D _particleSystemIcon;

		[SerializeField]
		private Texture2D _cameraIcon;

		public bool DrawLightIcons
		{
			get
			{
				return _drawLightIcons;
			}
			set
			{
				_drawLightIcons = value;
			}
		}

		public bool DrawParticleSystemIcons
		{
			get
			{
				return _drawParticleSystemIcons;
			}
			set
			{
				_drawParticleSystemIcons = value;
			}
		}

		public bool DrawCameraIcons
		{
			get
			{
				return _drawCameraIcons;
			}
			set
			{
				_drawCameraIcons = value;
			}
		}

		public float LightIconAlpha
		{
			get
			{
				return _lightIconAlpha;
			}
			set
			{
				_lightIconAlpha = Mathf.Clamp(value, 0f, 1f);
			}
		}

		public float ParticleSystemIconAlpha
		{
			get
			{
				return _particleSystemIconAlpha;
			}
			set
			{
				_particleSystemIconAlpha = Mathf.Clamp(value, 0f, 1f);
			}
		}

		public float CameraIconAlpha
		{
			get
			{
				return _cameraIconAlpha;
			}
			set
			{
				_cameraIconAlpha = Mathf.Clamp(value, 0f, 1f);
			}
		}

		public Texture2D LightIcon
		{
			get
			{
				return _lightIcon;
			}
			set
			{
				_lightIcon = value;
			}
		}

		public Texture2D ParticleSystemIcon
		{
			get
			{
				return _particleSystemIcon;
			}
			set
			{
				_particleSystemIcon = value;
			}
		}

		public Texture2D CameraIcon
		{
			get
			{
				return _cameraIcon;
			}
			set
			{
				_cameraIcon = value;
			}
		}
	}
}
