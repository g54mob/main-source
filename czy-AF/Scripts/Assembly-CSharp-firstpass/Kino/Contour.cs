using UnityEngine;

namespace Kino
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Kino Image Effects/Contour")]
	public class Contour : MonoBehaviour
	{
		[SerializeField]
		private Color _lineColor = Color.black;

		[SerializeField]
		private Color _backgroundColor = new Color(1f, 1f, 1f, 0f);

		[SerializeField]
		[Range(0f, 1f)]
		private float _lowerThreshold = 0.05f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _upperThreshold = 0.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _colorSensitivity;

		[SerializeField]
		[Range(0f, 1f)]
		private float _depthSensitivity = 0.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _normalSensitivity;

		[SerializeField]
		private float _fallOffDepth = 40f;

		[SerializeField]
		[HideInInspector]
		private Shader _shader;

		private Material _material;

		public Color lineColor
		{
			get
			{
				return _lineColor;
			}
			set
			{
				_lineColor = value;
			}
		}

		public Color backgroundColor
		{
			get
			{
				return _backgroundColor;
			}
			set
			{
				_backgroundColor = value;
			}
		}

		public float lowerThreshold
		{
			get
			{
				return _lowerThreshold;
			}
			set
			{
				_lowerThreshold = value;
			}
		}

		public float upperThreshold
		{
			get
			{
				return _upperThreshold;
			}
			set
			{
				_upperThreshold = value;
			}
		}

		public float colorSensitivity
		{
			get
			{
				return _colorSensitivity;
			}
			set
			{
				_colorSensitivity = value;
			}
		}

		public float depthSensitivity
		{
			get
			{
				return _depthSensitivity;
			}
			set
			{
				_depthSensitivity = value;
			}
		}

		public float normalSensitivity
		{
			get
			{
				return _normalSensitivity;
			}
			set
			{
				_normalSensitivity = value;
			}
		}

		public float fallOffDepth
		{
			get
			{
				return _fallOffDepth;
			}
			set
			{
				_fallOffDepth = value;
			}
		}

		private void OnValidate()
		{
			_lowerThreshold = Mathf.Min(_lowerThreshold, _upperThreshold);
		}

		private void OnDestroy()
		{
			if (_material != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(_material);
				}
				else
				{
					Object.DestroyImmediate(_material);
				}
			}
		}

		private void Update()
		{
			if (_depthSensitivity > 0f)
			{
				GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (_material == null)
			{
				_material = new Material(_shader);
				_material.hideFlags = HideFlags.DontSave;
			}
			_material.SetColor("_Color", _lineColor);
			_material.SetColor("_Background", _backgroundColor);
			_material.SetFloat("_Threshold", _lowerThreshold);
			_material.SetFloat("_InvRange", 1f / (_upperThreshold - _lowerThreshold));
			_material.SetFloat("_ColorSensitivity", _colorSensitivity);
			_material.SetFloat("_DepthSensitivity", _depthSensitivity * 2f);
			_material.SetFloat("_NormalSensitivity", _normalSensitivity);
			_material.SetFloat("_InvFallOff", 1f / _fallOffDepth);
			if (_colorSensitivity > 0f)
			{
				_material.EnableKeyword("_CONTOUR_COLOR");
			}
			else
			{
				_material.DisableKeyword("_CONTOUR_COLOR");
			}
			if (_depthSensitivity > 0f)
			{
				_material.EnableKeyword("_CONTOUR_DEPTH");
			}
			else
			{
				_material.DisableKeyword("_CONTOUR_DEPTH");
			}
			if (_normalSensitivity > 0f)
			{
				_material.EnableKeyword("_CONTOUR_NORMAL");
			}
			else
			{
				_material.DisableKeyword("_CONTOUR_NORMAL");
			}
			Graphics.Blit(source, destination, _material);
		}
	}
}
