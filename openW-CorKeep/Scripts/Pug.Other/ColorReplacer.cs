using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class ColorReplacer : MonoBehaviour
{
	private static readonly int ColorReplaceTextureShaderID = Shader.PropertyToID("_colorReplaceTexture");

	public bool autoSetSrcColors;

	private MaterialPropertyBlock _materialPropertyBlock;

	private SpriteRenderer _sprite;

	private List<Color> _sourceColors = new List<Color>();

	private List<Color> _targetColors = new List<Color>();

	[ClearOnReload(true)]
	private static Dictionary<int, Texture2D> s_cache = new Dictionary<int, Texture2D>();

	private int ComputeColorHash()
	{
		return ComputeHash(_sourceColors, 17) ^ ComputeHash(_targetColors, 19);
	}

	private static int ComputeHash(List<Color> colors, int coefficient)
	{
		int num = colors.Count;
		for (int i = 0; i < colors.Count; i++)
		{
			num = num * coefficient + colors[i].GetHashCode();
		}
		return num;
	}

	private void OnValidate()
	{
		if (_sourceColors == null)
		{
			_sourceColors = new List<Color>();
		}
		if (_targetColors == null)
		{
			_targetColors = new List<Color>();
		}
		if (autoSetSrcColors)
		{
			autoSetSrcColors = false;
			SetSrcColorsToSpriteColors();
		}
	}

	private void SetSrcColorsToSpriteColors()
	{
		if (_sprite == null)
		{
			_sprite = GetComponent<SpriteRenderer>();
		}
		if (_sprite == null)
		{
			Debug.LogError($"Failed to auto set src colors on {base.gameObject}, no SpriteRenderer found.", this);
			return;
		}
		Texture2D texture2D = _sprite.sprite?.texture;
		if (texture2D == null)
		{
			Debug.LogError($"Failed to auto set src colors on {base.gameObject}, SpriteRenderer has no sprite or texture.", this);
			return;
		}
		if (!texture2D.isReadable)
		{
			Debug.LogError($"Failed to auto set src colors on {base.gameObject}, sprite texture is not readable.", this);
			return;
		}
		HashSet<Color> hashSet = new HashSet<Color>();
		_sourceColors.Clear();
		int num = Mathf.RoundToInt(_sprite.sprite.textureRect.min.x);
		int num2 = Mathf.RoundToInt(_sprite.sprite.textureRect.max.x);
		int num3 = Mathf.RoundToInt(_sprite.sprite.textureRect.min.y);
		int num4 = Mathf.RoundToInt(_sprite.sprite.textureRect.max.y);
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				Color pixel = texture2D.GetPixel(i, j);
				if (pixel.a > 0f && !hashSet.Contains(pixel))
				{
					hashSet.Add(pixel);
					_sourceColors.Add(pixel);
				}
			}
		}
	}

	private void Awake()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (!Application.isPlaying)
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
		}
		_sprite = GetComponent<SpriteRenderer>();
	}

	private void OnEnable()
	{
		Apply();
	}

	private Texture2D GetFromCache()
	{
		int key = ComputeColorHash();
		if (s_cache.TryGetValue(key, out var value))
		{
			return value;
		}
		int num = math.max(_sourceColors.Count, 1);
		value = new Texture2D(num, 2, TextureFormat.RGBA32, mipChain: false, linear: false)
		{
			name = "ColorReplacerTexture"
		};
		using NativeArray<Color> data = new NativeArray<Color>(num * 2, Allocator.Temp);
		value.SetPixelData(data, 0);
		for (int i = 0; i < _sourceColors.Count; i++)
		{
			value.SetPixel(i, 0, _sourceColors[i]);
			value.SetPixel(i, 1, (i < _targetColors.Count) ? _targetColors[i] : _sourceColors[i]);
		}
		value.Apply();
		s_cache.Add(key, value);
		return value;
	}

	public void SetColorReplacement(IReadOnlyList<Color> sourceColors, IReadOnlyList<Color> targetColors)
	{
		_sourceColors.Clear();
		_targetColors.Clear();
		if (sourceColors != null)
		{
			_sourceColors.AddRange(sourceColors);
		}
		if (targetColors != null)
		{
			_targetColors.AddRange(targetColors);
		}
		Apply();
	}

	public void Reset()
	{
		SetColorReplacement(null, null);
	}

	private void Apply()
	{
		if (_sourceColors.Count != _targetColors.Count)
		{
			Debug.LogWarning($"ColorReplacer on {base.gameObject} has different number of source and target colors ({_sourceColors.Count} vs {_targetColors.Count}). Colors beyond the source color count will not be replaced.", this);
		}
		bool flag = !Application.isPlaying;
		if (_sprite == null || (flag && _materialPropertyBlock == null))
		{
			Initialize();
		}
		Texture2D fromCache = GetFromCache();
		if (flag)
		{
			if (!(fromCache == null))
			{
				_sprite.GetPropertyBlock(_materialPropertyBlock);
				_materialPropertyBlock?.SetTexture(ColorReplaceTextureShaderID, fromCache);
				_sprite.SetPropertyBlock(_materialPropertyBlock);
			}
		}
		else if (_sprite.material != null)
		{
			_sprite.material.SetTexture(ColorReplaceTextureShaderID, fromCache);
		}
		else
		{
			Debug.LogError("Unable to set color replacement texture, sprite material was null!");
		}
	}

	public void UpdateColorReplacerFromObjectData(ContainedObjectsBuffer containedObject)
	{
		if (containedObject.objectID == ObjectID.None || !PugDatabase.TryGetComponent<CookedFoodCD>(containedObject.objectData, out var component))
		{
			Reset();
			return;
		}
		_sourceColors.Clear();
		_targetColors.Clear();
		_sourceColors.Add(component.ingredient1BrightestColor);
		_sourceColors.Add(component.ingredient1BrightColor);
		_sourceColors.Add(component.ingredient1DarkColor);
		_sourceColors.Add(component.ingredient1DarkestColor);
		_sourceColors.Add(component.ingredient2BrightestColor);
		_sourceColors.Add(component.ingredient2BrightColor);
		_sourceColors.Add(component.ingredient2DarkColor);
		_sourceColors.Add(component.ingredient2DarkestColor);
		ObjectDataCD objectData = new ObjectDataCD
		{
			objectID = CookedFoodCD.GetPrimaryIngredientFromVariation(containedObject.variation),
			amount = 1
		};
		ObjectDataCD objectData2 = new ObjectDataCD
		{
			objectID = CookedFoodCD.GetSecondaryIngredientFromVariation(containedObject.variation),
			amount = 1
		};
		if (PugDatabase.TryGetComponent<CookingIngredientCD>(objectData, out var component2) && PugDatabase.TryGetComponent<CookingIngredientCD>(objectData2, out var component3))
		{
			_targetColors.Add(component2.brightestColor);
			_targetColors.Add(component2.brightColor);
			_targetColors.Add(component2.darkColor);
			_targetColors.Add(component2.darkestColor);
			_targetColors.Add(component3.brightestColor);
			_targetColors.Add(component3.brightColor);
			_targetColors.Add(component3.darkColor);
			_targetColors.Add(component3.darkestColor);
		}
		else
		{
			Debug.LogError("One of the 2 ingredients in " + containedObject.objectID.ToString() + " does not have the CookingIngredientCD.");
		}
		Apply();
	}
}
