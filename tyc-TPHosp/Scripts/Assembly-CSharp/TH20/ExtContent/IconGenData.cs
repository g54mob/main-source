using UnityEngine;

namespace TH20.ExtContent
{
	public class IconGenData
	{
		public Color _imageBGColour = new Color(0.9f, 0.9f, 0.9f, 1f);

		public IconGenParams[] _iconGenParamVariations;

		public int GetNumVariations()
		{
			return _iconGenParamVariations.Length;
		}

		public bool IsVariationIndexValid(int index)
		{
			bool result = false;
			if (_iconGenParamVariations != null && index >= 0 && index < _iconGenParamVariations.Length)
			{
				result = true;
			}
			return result;
		}

		public IconGenParams GetVariation(int index)
		{
			IconGenParams result = null;
			if (_iconGenParamVariations != null && index >= 0 && index < _iconGenParamVariations.Length)
			{
				result = _iconGenParamVariations[index];
			}
			return result;
		}

		public int GetRandomVariationIndex()
		{
			int result = -1;
			if (_iconGenParamVariations != null && _iconGenParamVariations.Length != 0)
			{
				result = ((_iconGenParamVariations.Length > 1) ? Random.Range(0, _iconGenParamVariations.Length) : 0);
			}
			return result;
		}

		public static IconGenParams GetVariationIconGenParams(IconGenData iconGenData, int index)
		{
			IconGenParams iconGenParams = null;
			if (iconGenData != null)
			{
				return iconGenData.GetVariationIconGenParams(index);
			}
			return ExtContentUtils.TexturesConfig.DefaultIconGenParams;
		}

		public static Color GetImageBGColour(IconGenData iconGenData)
		{
			Color white = Color.white;
			return iconGenData?._imageBGColour ?? Color.white;
		}

		public IconGenParams GetVariationIconGenParams(int index)
		{
			IconGenParams iconGenParams = GetVariation(index);
			if (iconGenParams == null)
			{
				iconGenParams = GetVariation(0);
			}
			if (iconGenParams == null)
			{
				iconGenParams = ExtContentUtils.TexturesConfig.DefaultIconGenParams;
			}
			return iconGenParams;
		}

		public Texture2D GetVariationTextureCopy(int index)
		{
			Texture2D result = null;
			IconGenParams variationIconGenParams = GetVariationIconGenParams(index);
			if (variationIconGenParams != null)
			{
				result = variationIconGenParams._texture2DBG;
			}
			return result;
		}
	}
}
