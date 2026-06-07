using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class ExhaustSystemScript : MonoBehaviour, IExhaustSystem
	{
		private static class ShaderPropertyIds
		{
			public static readonly int Color = Shader.PropertyToID("_Color");

			public static readonly int ColorExpanded = Shader.PropertyToID("_ExpandedColor");

			public static readonly int ColorTip = Shader.PropertyToID("_TipColor");

			public static readonly int ColorShock = Shader.PropertyToID("_ShockColor");

			public static readonly int ColorFlame = Shader.PropertyToID("_FlameColor");

			public static readonly int ColorSoot = Shader.PropertyToID("_SootColor");

			public static readonly int Alpha = Shader.PropertyToID("_Alpha");

			public static readonly int Emission = Shader.PropertyToID("_Emission");

			public static readonly int EmissionShock = Shader.PropertyToID("_EmissionShock");

			public static readonly int Expansion = Shader.PropertyToID("_Expansion");

			public static readonly int ExpansionInv = Shader.PropertyToID("_ExpansionInv");

			public static readonly int RimShade = Shader.PropertyToID("_RimShade");

			public static readonly int ShockDiamonds = Shader.PropertyToID("_ShockDiamonds");

			public static readonly int ShockDir = Shader.PropertyToID("_ShockDirection");

			public static readonly int SootLength = Shader.PropertyToID("_SootLength");

			public static readonly int SootStrength = Shader.PropertyToID("_SootStrength");

			public static readonly int SpikeLength = Shader.PropertyToID("_SpikeLength");

			public static readonly int SpikeCurve = Shader.PropertyToID("_SpikeCurve");

			public static readonly int Stretch = Shader.PropertyToID("_Stretch");

			public static readonly int Shift = Shader.PropertyToID("_TextShift");

			public static readonly int Texture = Shader.PropertyToID("_TextStrength");

			public static readonly int Throttle = Shader.PropertyToID("_Throttle");
		}

		private const float MinExpansionRatio = 0.5f;

		[SerializeField]
		private Transform _exhaustCollider;

		private CapsuleCollider _exhaustTrigger;

		[SerializeField]
		private float _alpha = 1f;

		[SerializeField]
		private Color _color = new Color(255f, 168f, 81f, 255f);

		[SerializeField]
		private Color _colorExpanded = new Color(255f, 168f, 81f, 255f);

		[SerializeField]
		private Color _colorTip = new Color(1f, 0.4f, 0.1f, 0.2f);

		[SerializeField]
		private Color _colorShock = new Color(0.5f, 0.5f, 1f, 0.8f);

		[SerializeField]
		private Color _colorFlame = new Color(1f, 0.4f, 0f, 0.5f);

		[SerializeField]
		private Color _colorSoot = new Color(0f, 0f, 0f, 1f);

		[SerializeField]
		private float _exhaustLength = 3f;

		[SerializeField]
		private float _exhaustBend;

		[SerializeField]
		private float _exhaustBendLength;

		[SerializeField]
		private float _exhaustOffset;

		private Material _exhaustMaterial;

		[SerializeField]
		private MeshRenderer _exhaustMesh;

		private Transform _exhaustTransform;

		[SerializeField]
		private float _expansionRatio = 2.5f;

		[SerializeField]
		private float _globalIntensity = 1f;

		private float _intensity;

		[SerializeField]
		private MeshRenderer _nozzleEmission;

		private Material _nozzleEmissionMaterial;

		[SerializeField]
		private float _nozzleRadius = 0.45f;

		[SerializeField]
		private float _nozzleShine = 5f;

		[SerializeField]
		private float _rimShade = 1f;

		[SerializeField]
		private float _shockDirection = 0.5f;

		[SerializeField]
		private float _shockIntensity = 1f;

		[SerializeField]
		private float _sootLength;

		[SerializeField]
		private float _sootIntensity;

		[SerializeField]
		private float _textureShiftSpeed = -1f;

		[SerializeField]
		private float _textureStrength = 1f;

		[SerializeField]
		private float _throttle = 1f;

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

		public Color ColorExpanded
		{
			get
			{
				return _colorExpanded;
			}
			set
			{
				_colorExpanded = value;
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

		public Color ColorShock
		{
			get
			{
				return _colorShock;
			}
			set
			{
				_colorShock = value;
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

		public Color ColorSoot
		{
			get
			{
				return _colorSoot;
			}
			set
			{
				_colorSoot = value;
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

		public float ExhaustBend
		{
			get
			{
				return _exhaustBend;
			}
			set
			{
				_exhaustBend = value;
			}
		}

		public float ExhaustBendLength
		{
			get
			{
				return _exhaustBendLength;
			}
			set
			{
				_exhaustBendLength = value;
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

		public float ExpansionRatio
		{
			get
			{
				return _expansionRatio;
			}
			set
			{
				_expansionRatio = Mathf.Clamp(value, 0.5f, MaxExpansionRatio);
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

		public float MaxExpansionRatio { get; set; }

		public float NozzleRadius
		{
			get
			{
				return _nozzleRadius;
			}
			set
			{
				_nozzleRadius = value;
				float num = value * 2f;
				_nozzleEmission.transform.localScale = new Vector3(num, num, num);
			}
		}

		public float NozzleShine
		{
			get
			{
				return _nozzleShine;
			}
			set
			{
				_nozzleShine = value;
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

		public float ShockDirection
		{
			get
			{
				return _shockDirection;
			}
			set
			{
				_shockDirection = value;
			}
		}

		public float ShockIntensity
		{
			get
			{
				return _shockIntensity;
			}
			set
			{
				_shockIntensity = value;
			}
		}

		public float SootLength
		{
			get
			{
				return _sootLength;
			}
			set
			{
				_sootLength = value;
			}
		}

		public float SootIntensity
		{
			get
			{
				return _sootIntensity;
			}
			set
			{
				_sootIntensity = value;
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
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorExpanded, _colorExpanded);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorTip, _colorTip);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorShock, _colorShock);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorFlame, _colorFlame);
			_exhaustMaterial.SetColor(ShaderPropertyIds.ColorSoot, _colorSoot);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.EmissionShock, _globalIntensity * _shockIntensity * 5f);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Emission, _globalIntensity);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.RimShade, _rimShade);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.ShockDir, _shockDirection);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.SootLength, _sootLength);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.SootStrength, _sootIntensity);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.SpikeLength, (_exhaustBend == 0f) ? 0f : _exhaustBendLength);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.SpikeCurve, _exhaustBend);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Texture, _textureStrength);
		}

		public void UpdateExhaust(float throttle)
		{
			if (Game.InFlightScene && _exhaustTrigger != null && _exhaustCollider != null && (!_exhaustCollider.gameObject.activeSelf || Mathf.Abs(_expansionRatio * _nozzleRadius - _exhaustTrigger.radius) > 2f))
			{
				_exhaustTrigger.radius = _expansionRatio * _nozzleRadius;
				_exhaustTrigger.height = Mathf.Max(1.5f * ExhaustLength, 2f * _exhaustTrigger.radius);
				_exhaustCollider.localPosition = new Vector3(0f, -0.5f * _exhaustCollider.GetComponent<CapsuleCollider>().height - 0.1f, 0f);
				if (!_exhaustCollider.gameObject.activeSelf)
				{
					_exhaustCollider.localScale = Vector3.one;
					_exhaustCollider.gameObject.SetActive(value: true);
				}
			}
			_throttle = throttle;
			_intensity = Mathf.Clamp01(throttle * throttle * (4f - 3f * throttle));
			_intensity = 0.2f + 0.8f * _intensity * _intensity;
			if (throttle < 0.001f)
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
			if (_exhaustTransform != null && _exhaustMaterial != null && _nozzleEmissionMaterial != null)
			{
				UpdateProperties(_intensity, Mathf.Clamp(_expansionRatio * _intensity, 0.5f, MaxExpansionRatio), _exhaustLength * _intensity);
			}
		}

		protected virtual void Start()
		{
			_exhaustTransform = _exhaustMesh.transform;
			_exhaustMaterial = _exhaustMesh.material;
			_nozzleEmissionMaterial = _nozzleEmission.material;
			_exhaustTrigger = _exhaustCollider.GetComponent<CapsuleCollider>();
			MeshFilter component = _exhaustMesh.GetComponent<MeshFilter>();
			if (component.sharedMesh.bounds.size.z < 2f)
			{
				component.sharedMesh.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 2f));
			}
			base.gameObject.SetActive(value: false);
		}

		private void UpdateProperties(float intensity, float expansionRatio, float exhaustLength)
		{
			if (_textureShiftSpeed < 0f)
			{
				_textureShiftSpeed = Random.value;
			}
			else
			{
				_textureShiftSpeed += (1f + _throttle) * Time.deltaTime;
			}
			_exhaustTransform.localPosition = new Vector3(0f, 0f - _exhaustOffset, 0f);
			_exhaustTransform.localScale = new Vector3(_nozzleRadius, _nozzleRadius, exhaustLength);
			_nozzleEmissionMaterial.SetFloat(ShaderPropertyIds.Emission, Mathf.Clamp01(intensity - 0.25f) * NozzleShine);
			float num = Mathf.Max(1f, expansionRatio);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Alpha, _alpha * intensity / num);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Expansion, num);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.ExpansionInv, 1f / num);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Stretch, (1f - num) * exhaustLength * 0.03f);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.ShockDiamonds, Mathf.InverseLerp(1f, 0.5f, expansionRatio) * Mathf.Clamp01(3f * _throttle - 2f));
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Shift, _textureShiftSpeed);
			_exhaustMaterial.SetFloat(ShaderPropertyIds.Throttle, _throttle);
		}
	}
}
