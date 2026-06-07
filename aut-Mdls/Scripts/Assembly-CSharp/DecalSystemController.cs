using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DecalSystemController : MonoBehaviour
{
	[Header("Decal param")]
	[SerializeField]
	private GameObject _decal;

	[SerializeField]
	private float _decalSize = 5f;

	[Space(10f)]
	[Header("Type Of Texture")]
	public bool _isLeaf;

	[SerializeField]
	private Noise _eNoise;

	[SerializeField]
	private DisturbNoise _eDisturbNoise;

	[HideInInspector]
	public WhichTexture _eWhichTextures;

	[HideInInspector]
	[SerializeField]
	public List<Texture2D> _Albedo;

	[HideInInspector]
	[SerializeField]
	private List<Texture2D> _NormalTex;

	[HideInInspector]
	[SerializeField]
	private List<Texture2D> _NormalAlpha;

	[HideInInspector]
	[SerializeField]
	private Texture2D _AlphaLeafTex;

	private const string _materialTex = "_MaterialTex";

	private const string _normalTex = "_NormalTex";

	private const string _useAlpha = "_UseAlphaInsteadOfTex";

	[Space(10f)]
	[Header("Noise Control")]
	[SerializeField]
	private float _tiling;

	[SerializeField]
	private Vector2 _offset;

	[SerializeField]
	private float _fallOff;

	private const string _cloudNoise = "_UseCloudNoise";

	private const string _perlinNoise = "_UsePerlinNoise";

	private const string _FractalNoise = "_UseFractalSumNoise";

	private const string _noiseTiling = "_Tiling";

	private const string _noiseOffset = "_Offset";

	private const string _noiseFallOff = "_FallOff";

	[Space(10f)]
	[Header("Disturb Noise Control")]
	[SerializeField]
	private float _disturbTiling;

	[SerializeField]
	private Vector2 _disturbOffset;

	[SerializeField]
	private float _disturbIntensity;

	[SerializeField]
	private float _disturbThreshold;

	private const string _perlinDNoise = "_UseDPerlin";

	private const string _noiseDNoise = "_UseDNoise";

	private const string _dissolveDNoise = "_UseDDissolve";

	private const string _dTiling = "_DisturbTiling";

	private const string _dOffset = "_DisturbOffset";

	private const string _dIntensity = "_DistrurbIntensity";

	private const string _dThreshold = "_DisturbThreshold";

	[Space(10f)]
	[Header("Global Control")]
	[SerializeField]
	private float _visualBoosting;

	[HideInInspector]
	public Color _colorCorrection;

	private const string _colorCorr = "_ColorCorrection";

	private const string _visualBoost = "_VisibilityBoost";

	[Space(10f)]
	[Header("Tex Control")]
	[SerializeField]
	private float _tilingAlbedoAndNormal;

	private const string _tilingTex = "_TilingTex";

	[Space(10f)]
	[Header("Use Alpha Leaf")]
	[HideInInspector]
	public TypeOfLeaf _eTypeOfLeaf;

	[HideInInspector]
	public Color _colorOfLeaf;

	[HideInInspector]
	public Color _secondColorOfLeaf;

	private const string _firstColorLeaf = "_FirstColorOfAlpha";

	private const string _secondColorLeaf = "_SecondColorOfAlpha";

	private const string _isGreenLeaf = "_IsGreenLeaf";

	private const string _isYellowLeaf = "_IsYellowLeaf";

	private const string _isBush = "_IsBushLeaf";

	[Space(10f)]
	[Header("Mat")]
	public string _materialName;

	public Material _mat;

	public Shader _shader;

	private void Update()
	{
		if (_mat != null)
		{
			base.gameObject.GetComponentInChildren<MeshRenderer>().material = _mat;
			NoiseChange();
			DisturbNoiseChange();
			NoiseControl();
			DisturbNoiseControl();
			GlobalControl();
			TextureControl();
			UseLeafAlpha();
			LeafChange();
			ChangeDecalSize();
		}
	}

	private void NoiseChange()
	{
		if (_eNoise == Noise.Cloud)
		{
			_mat.SetFloat("_UseCloudNoise", 1f);
			_mat.SetFloat("_UsePerlinNoise", 0f);
			_mat.SetFloat("_UseFractalSumNoise", 0f);
		}
		if (_eNoise == Noise.FractalSum)
		{
			_mat.SetFloat("_UseCloudNoise", 0f);
			_mat.SetFloat("_UsePerlinNoise", 0f);
			_mat.SetFloat("_UseFractalSumNoise", 1f);
		}
		if (_eNoise == Noise.Perlin)
		{
			_mat.SetFloat("_UseCloudNoise", 0f);
			_mat.SetFloat("_UsePerlinNoise", 1f);
			_mat.SetFloat("_UseFractalSumNoise", 0f);
		}
		if (_eNoise == Noise.Voronoi)
		{
			_mat.SetFloat("_UseCloudNoise", 0f);
			_mat.SetFloat("_UsePerlinNoise", 0f);
			_mat.SetFloat("_UseFractalSumNoise", 0f);
		}
	}

	private void DisturbNoiseChange()
	{
		if (_eDisturbNoise == DisturbNoise.Perlin)
		{
			_mat.SetFloat("_UseDPerlin", 1f);
			_mat.SetFloat("_UseDNoise", 0f);
			_mat.SetFloat("_UseDDissolve", 0f);
		}
		if (_eDisturbNoise == DisturbNoise.Disolve)
		{
			_mat.SetFloat("_UseDPerlin", 0f);
			_mat.SetFloat("_UseDNoise", 0f);
			_mat.SetFloat("_UseDDissolve", 1f);
		}
		if (_eDisturbNoise == DisturbNoise.Noise)
		{
			_mat.SetFloat("_UseDPerlin", 0f);
			_mat.SetFloat("_UseDNoise", 1f);
			_mat.SetFloat("_UseDDissolve", 0f);
		}
		if (_eDisturbNoise == DisturbNoise.Inv_Voronoi)
		{
			_mat.SetFloat("_UseDPerlin", 0f);
			_mat.SetFloat("_UseDNoise", 0f);
			_mat.SetFloat("_UseDDissolve", 0f);
		}
	}

	private void NoiseControl()
	{
		_mat.SetFloat("_Tiling", _tiling);
		_mat.SetVector("_Offset", _offset);
		_mat.SetFloat("_FallOff", _fallOff);
	}

	private void DisturbNoiseControl()
	{
		_mat.SetFloat("_DisturbTiling", _disturbTiling);
		_mat.SetFloat("_DistrurbIntensity", _disturbIntensity);
		_mat.SetFloat("_DisturbThreshold", _disturbThreshold);
		_mat.SetVector("_DisturbOffset", _disturbOffset);
	}

	private void GlobalControl()
	{
		_mat.SetFloat("_VisibilityBoost", _visualBoosting);
		_mat.SetColor("_ColorCorrection", _colorCorrection);
	}

	private void TextureControl()
	{
		_mat.SetFloat("_TilingTex", _tilingAlbedoAndNormal);
		if (_eWhichTextures == WhichTexture.dirtAndPeebles && !_isLeaf)
		{
			_mat.SetTexture("_MaterialTex", _Albedo[0]);
			_mat.SetTexture("_NormalTex", _NormalTex[0]);
		}
	}

	private void UseLeafAlpha()
	{
		if (_isLeaf)
		{
			_mat.SetFloat("_UseAlphaInsteadOfTex", 1f);
			_mat.SetColor("_FirstColorOfAlpha", _colorOfLeaf);
			_mat.SetColor("_SecondColorOfAlpha", _secondColorOfLeaf);
			_mat.SetTexture("_MaterialTex", _AlphaLeafTex);
		}
		else
		{
			_mat.SetFloat("_UseAlphaInsteadOfTex", 0f);
			_mat.SetColor("_FirstColorOfAlpha", _colorOfLeaf);
			_mat.SetColor("_SecondColorOfAlpha", _secondColorOfLeaf);
		}
	}

	private void LeafChange()
	{
		if (_eTypeOfLeaf == TypeOfLeaf.GreenTree)
		{
			_mat.SetFloat("_IsGreenLeaf", 1f);
			_mat.SetFloat("_IsYellowLeaf", 0f);
			_mat.SetFloat("_IsBushLeaf", 0f);
			if (_isLeaf)
			{
				_mat.SetTexture("_NormalTex", _NormalAlpha[0]);
			}
		}
		if (_eTypeOfLeaf == TypeOfLeaf.YellowTree)
		{
			_mat.SetFloat("_IsGreenLeaf", 0f);
			_mat.SetFloat("_IsBushLeaf", 0f);
			_mat.SetFloat("_IsYellowLeaf", 1f);
			if (_isLeaf)
			{
				_mat.SetTexture("_NormalTex", _NormalAlpha[1]);
			}
		}
		if (_eTypeOfLeaf == TypeOfLeaf.Bush)
		{
			_mat.SetFloat("_IsGreenLeaf", 0f);
			_mat.SetFloat("_IsBushLeaf", 1f);
			_mat.SetFloat("_IsYellowLeaf", 0f);
			if (_isLeaf)
			{
				_mat.SetTexture("_NormalTex", _NormalAlpha[2]);
			}
		}
		if (_eTypeOfLeaf == TypeOfLeaf.Mixed)
		{
			_mat.SetFloat("_IsGreenLeaf", 0f);
			_mat.SetFloat("_IsYellowLeaf", 0f);
			_mat.SetFloat("_IsBushLeaf", 0f);
			if (_isLeaf)
			{
				_mat.SetTexture("_NormalTex", _NormalAlpha[3]);
			}
		}
	}

	private void ChangeDecalSize()
	{
		_decal.transform.localScale = new Vector3(_decalSize, _decalSize, _decalSize);
	}
}
