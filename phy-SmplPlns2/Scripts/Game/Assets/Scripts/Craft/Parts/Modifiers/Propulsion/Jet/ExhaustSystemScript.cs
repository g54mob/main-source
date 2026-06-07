using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class ExhaustSystemScript : MonoBehaviour, IExhaustSystem
	{
		private static class ShaderPropertyIds
		{
			public static readonly int Alpha = Shader.PropertyToID("_Alpha");

			public static readonly int Color = Shader.PropertyToID("_Color");

			public static readonly int ColorFlame = Shader.PropertyToID("_FlameColor");

			public static readonly int ColorTip = Shader.PropertyToID("_TipColor");

			public static readonly int Emission = Shader.PropertyToID("_Emission");

			public static readonly int RimShade = Shader.PropertyToID("_RimShade");

			public static readonly int Shift = Shader.PropertyToID("_TextShift");

			public static readonly int ShockDiamonds = Shader.PropertyToID("_ShockDiamonds");

			public static readonly int Texture = Shader.PropertyToID("_TextStrength");

			public static readonly int Throttle = Shader.PropertyToID("_Throttle");
		}

		[SerializeField]
		private float _alpha = 1f;

		[SerializeField]
		private Color _color = new Color(117f, 176f, 255f, 255f);

		[SerializeField]
		private Color _colorFlame = new Color(255f, 128f, 0f, 128f);

		[SerializeField]
		private Color _colorTip = new Color(255f, 128f, 0f, 128f);

		[SerializeField]
		private float _exhaustLength = 12f;

		private Material _exhaustMaterial;

		[SerializeField]
		private MeshRenderer _exhaustMesh;

		[SerializeField]
		private float _exhaustOffset;

		private Transform _exhaustTransform;

		[SerializeField]
		private float _globalIntensity = 20f;

		private float _intensity;

		[SerializeField]
		private float _nozzleRadius = 1f;

		[SerializeField]
		private float _rimShade = 0.95f;

		[SerializeField]
		private float _textureShiftSpeed = -1f;

		[SerializeField]
		private float _textureStrength = 1f;

		private float _throttle;

		public float Alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = value;
			}
		}

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public Color ColorFlame
		{
			get
			{
				return _colorFlame;
			}
			set
			{
				_colorFlame = value;
			}
		}

		public Color ColorTip
		{
			get
			{
				return _colorTip;
			}
			set
			{
				_colorTip = value;
			}
		}

		public float ExhaustLength
		{
			get
			{
				return _exhaustLength;
			}
			set
			{
				_exhaustLength = value;
			}
		}

		public float ExhaustOffset
		{
			get
			{
				return _exhaustOffset;
			}
			set
			{
				_exhaustOffset = value;
			}
		}

		public GameObject GameObject => base.gameObject;

		public float GlobalIntensity
		{
			get
			{
				return _globalIntensity;
			}
			set
			{
				_globalIntensity = value;
			}
		}

		public float Intensity => _intensity;

		public float NozzleRadius
		{
			get
			{
				return _nozzleRadius;
			}
			set
			{
				_nozzleRadius = value;
			}
		}

		public float RimShade
		{
			get
			{
				return _rimShade;
			}
			set
			{
				_rimShade = value;
			}
		}

		public float TextureIntensity
		{
			get
			{
				return _textureStrength;
			}
			set
			{
				_textureStrength = value;
			}
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void SetUp()
		{
			if (_exhaustMaterial == null)
			{
				_exhaustMaterial = _exhaustMesh.material;
			}
			_exhaustMaterial.SetColor(ShaderPropertyIds.Color, _color);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorTip, _colorTip);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorFlame, _colorFlame);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Emission, _globalIntensity);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.RimShade, _rimShade);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Texture, _textureStrength);
		}

		public void UpdateExhaust(float throttle, float afterburnerThrottle)
		{
			throttle = ((!(afterburnerThrottle > 0f)) ? 0f : (0.4f + 0.6f * afterburnerThrottle));
			_throttle = Utilities.StepTowards(_throttle, Time.deltaTime, throttle);
			_intensity = Mathf.Clamp01(_throttle * _throttle * (4f - 3f * _throttle));
			_intensity = 0.3f + 0.7f * _intensity * _intensity;
			if (_throttle < 0.001f)
			{
				_intensity = 0f;
				if (base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: false);
				}
			}
			else if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (_exhaustTransform != null && _exhaustMaterial != null)
			{
				UpdateProperties(_intensity, _exhaustLength * _intensity);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_exhaustMaterial != null)
			{
				Object.Destroy(_exhaustMaterial);
				_exhaustMaterial = null;
			}
		}

		protected virtual void Start()
		{
			_exhaustTransform = _exhaustMesh.transform;
			_exhaustMaterial = _exhaustMesh.material;
			MeshFilter component = _exhaustMesh.GetComponent<MeshFilter>();
			if (component.sharedMesh.bounds.size.z < 2f)
			{
				component.sharedMesh.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 2f));
			}
			base.gameObject.SetActive(value: false);
		}

		private void UpdateProperties(float intensity, float exhaustLength)
		{
			if (_textureShiftSpeed < 0f)
			{
				_textureShiftSpeed = Random.value;
			}
			else
			{
				_textureShiftSpeed += (1.5f + 0.5f * _throttle) * Time.deltaTime;
			}
			_exhaustTransform.localPosition = new Vector3(0f, 0f - _exhaustOffset, 0f);
			_exhaustTransform.localScale = new Vector3(_nozzleRadius, _nozzleRadius, exhaustLength);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Alpha, _alpha * intensity);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.ShockDiamonds, Mathf.Clamp01(3f * _throttle - 2f));
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Shift, _textureShiftSpeed);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Throttle, _throttle);
		}
	}
}
