using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI.Navball
{
	[ExecuteInEditMode]
	public class NavballRendererControllerScript : MonoBehaviour
	{
		private static class ShaderPropertyIds
		{
			public static readonly int BottomColour = Shader.PropertyToID("_BottomColour");

			public static readonly int Cube = Shader.PropertyToID("_Cube");

			public static readonly int CubeST = Shader.PropertyToID("_Cube_ST");

			public static readonly int MainColour = Shader.PropertyToID("_MainColour");

			public static readonly int MapEnable = Shader.PropertyToID("_MapEnable");

			public static readonly int MapRotation = Shader.PropertyToID("_MapRotation");

			public static readonly int MarkerRotations = Shader.PropertyToID("_MarkerRotations");

			public static readonly int MarkersIndices = Shader.PropertyToID("_MarkersIndices");

			public static readonly int NavRotation = Shader.PropertyToID("_NavRotation");

			public static readonly int TopColour = Shader.PropertyToID("_TopColour");
		}

		private const int NumMarkers = 10;

		private static string[] _markerKeywords;

		private static bool _shadersWarmedUp;

		[SerializeField]
		private Texture _backgroundTexture;

		[SerializeField]
		private Color _defaultBottomColour = Color.black;

		[SerializeField]
		private Color _defaultTopColour = Color.white;

		[SerializeField]
		private float[] _enables = new float[10];

		private Image _image;

		[SerializeField]
		private float[] _indices = new float[10];

		[SerializeField]
		private bool _mapEnabled;

		private Material _mapMaterial;

		private float _mapZoom = 1f;

		[SerializeField]
		[Range(1f, 5f)]
		private float _mapZoomTarget = 1f;

		[SerializeField]
		private float _markersScale = 0.15f;

		[SerializeField]
		private Texture _markerTexture;

		[SerializeField]
		private Shader _navballMapShader;

		private Material _navballMaterial;

		[SerializeField]
		private float _navballScale = 0.85f;

		[SerializeField]
		private Shader _navballShader;

		private Matrix4x4[] _rotationMatrices = new Matrix4x4[10];

		[SerializeField]
		private Vector3[] _vectors = new Vector3[10];

		public Color BottomColor
		{
			get
			{
				Initialise();
				return _navballMaterial.GetColor(ShaderPropertyIds.BottomColour);
			}
			set
			{
				Initialise();
				_navballMaterial.SetColor(ShaderPropertyIds.BottomColour, value);
			}
		}

		public Vector3[] FlightVectors => _vectors;

		public bool MapEnabled
		{
			get
			{
				return _mapEnabled;
			}
			set
			{
				_mapEnabled = value;
			}
		}

		public Quaternion MapRotation { get; set; }

		public float MapZoom
		{
			get
			{
				return _mapZoomTarget;
			}
			set
			{
				_mapZoomTarget = value;
			}
		}

		public Color MainColor
		{
			get
			{
				Initialise();
				return _navballMaterial.GetColor(ShaderPropertyIds.MainColour);
			}
			set
			{
				Initialise();
				_navballMaterial.SetColor(ShaderPropertyIds.MainColour, value);
			}
		}

		public Quaternion NavRotation { get; set; }

		public int StencilValue { get; set; }

		public Color TopColor
		{
			get
			{
				Initialise();
				return _navballMaterial.GetColor(ShaderPropertyIds.TopColour);
			}
			set
			{
				Initialise();
				_navballMaterial.SetColor(ShaderPropertyIds.TopColour, value);
			}
		}

		public Material Material
		{
			get
			{
				if (!MapEnabled)
				{
					return _navballMaterial;
				}
				return _mapMaterial;
			}
		}

		static NavballRendererControllerScript()
		{
			_markerKeywords = new string[11];
			for (int i = 0; i <= 10; i++)
			{
				_markerKeywords[i] = $"MARKER_COUNT_{i}";
			}
		}

		public void SetCubemap(Texture cubemap)
		{
			Initialise();
			_mapMaterial.SetTexture(ShaderPropertyIds.Cube, cubemap);
		}

		public void SetEnabled(int vector, bool enabled)
		{
			_enables[vector] = (enabled ? 1f : 0f);
		}

		protected virtual void OnDestroy()
		{
			if (_navballMaterial != null)
			{
				Object.Destroy(_navballMaterial);
				_navballMaterial = null;
			}
			if (_mapMaterial != null)
			{
				Object.Destroy(_mapMaterial);
				_mapMaterial = null;
			}
		}

		private void Initialise()
		{
			if (_navballMaterial == null)
			{
				WarmUpShaders();
				_mapMaterial = new Material(_navballMapShader);
				_navballMaterial = new Material(_navballShader);
				_navballMaterial.SetTexture("_Markers", _markerTexture);
				_navballMaterial.SetVector("_Markers_ST", new Vector4(_markersScale, _markersScale));
				_navballMaterial.SetTexture("_MainTex", _backgroundTexture);
				_navballMaterial.SetColor(ShaderPropertyIds.TopColour, _defaultTopColour);
				_navballMaterial.SetColor(ShaderPropertyIds.BottomColour, _defaultBottomColour);
				_navballMaterial.SetFloat("_Scale", _navballScale);
				if (StencilValue > 0)
				{
					_navballMaterial.SetFloat("_Stencil", StencilValue);
					_mapMaterial.SetFloat("_Stencil", StencilValue);
					_navballMaterial.SetFloat("_StencilComp", 3f);
					_mapMaterial.SetFloat("_StencilComp", 3f);
					_navballMaterial.renderQueue = 2999;
					_mapMaterial.renderQueue = 2999;
				}
				_image = GetComponent<Image>();
				_image.material = _navballMaterial;
			}
		}

		private void LateUpdate()
		{
			Initialise();
			if (_mapEnabled)
			{
				Material mapMaterial = _mapMaterial;
				_mapZoom = Mathf.Lerp(_mapZoom, _mapZoomTarget, Time.unscaledDeltaTime * 6f);
				mapMaterial.SetMatrix(ShaderPropertyIds.MapRotation, Matrix4x4.Rotate(MapRotation));
				mapMaterial.SetVector(ShaderPropertyIds.CubeST, new Vector4(1f / _mapZoom, 1f / _mapZoom));
				_image.material = mapMaterial;
				return;
			}
			Material navballMaterial = _navballMaterial;
			Matrix4x4 value = Matrix4x4.Rotate(NavRotation);
			navballMaterial.SetMatrix(ShaderPropertyIds.NavRotation, value);
			Vector3 upwards = NavRotation * Vector3.up;
			int num = 0;
			for (int i = 0; i < 10; i++)
			{
				if (_enables[i] != 0f)
				{
					_rotationMatrices[num] = Matrix4x4.Rotate(Quaternion.Inverse(Quaternion.LookRotation(_vectors[i], upwards)));
					_indices[num] = i;
					num++;
				}
			}
			string keyword = _markerKeywords[num];
			if (!navballMaterial.IsKeywordEnabled(keyword))
			{
				for (int j = 0; j <= 10; j++)
				{
					navballMaterial.DisableKeyword(_markerKeywords[j]);
				}
				navballMaterial.EnableKeyword(keyword);
			}
			navballMaterial.SetMatrixArray(ShaderPropertyIds.MarkerRotations, _rotationMatrices);
			navballMaterial.SetFloatArray(ShaderPropertyIds.MarkersIndices, _indices);
			_image.material = navballMaterial;
		}

		private void WarmUpShaders()
		{
			if (!_shadersWarmedUp)
			{
				_shadersWarmedUp = true;
				ShaderVariantCollection shaderVariantCollection = new ShaderVariantCollection();
				shaderVariantCollection.Add(new ShaderVariantCollection.ShaderVariant(_navballMapShader, PassType.Normal));
				for (int i = 0; i < 10; i++)
				{
					shaderVariantCollection.Add(new ShaderVariantCollection.ShaderVariant(_navballShader, PassType.Normal, $"MARKER_COUNT_{i}"));
				}
				shaderVariantCollection.WarmUp();
			}
		}
	}
}
