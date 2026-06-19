using UnityEngine;

namespace TH20.ExtContent
{
	public class IconGenParams
	{
		public enum IconAspectRatioType
		{
			MainImagePreferred = 0,
			Specific = 1,
			CalulatedfromUVs = 2
		}

		public Texture2D _texture2DBG;

		public bool _bUseIconMaskMethod;

		public bool _bUseStreamingAssetsTexture;

		public string _streamingAssetsTextureFileSpec;

		public Vector2[] _UVs;

		public int _borderSize;

		public int _rotateUVsCount;

		public int _rotateIconImageCount;

		public Color _borderColor;

		public IconAspectRatioType _iconImageApsectRatioType;

		public float _iconImageSpecificWidth = 128f;

		public float _iconImageSpecificHeight = 128f;

		private bool _bStreamingAssetsTextureLoaded;

		public IconGenParams()
		{
			_texture2DBG = null;
			_UVs = new Vector2[4];
			_UVs[0] = new Vector2(0.2f, 0.15f);
			_UVs[1] = new Vector2(0.2f, 0.85f);
			_UVs[2] = new Vector2(0.85f, 0.75f);
			_UVs[3] = new Vector2(0.85f, 0.25f);
			_bUseIconMaskMethod = true;
			_bUseStreamingAssetsTexture = false;
			_rotateUVsCount = 0;
			_rotateIconImageCount = 0;
			_borderSize = 10;
			_borderColor = new Color(1f, 1f, 1f, 1f);
		}

		public Texture2D GetTexture2D()
		{
			Texture2D result = null;
			if (_bUseStreamingAssetsTexture && !_streamingAssetsTextureFileSpec.IsNullOrEmpty() && !_bStreamingAssetsTextureLoaded)
			{
				_bStreamingAssetsTextureLoaded = true;
				_texture2DBG = ExtContentTextureUtils.LoadTexture2D(ExtContentUtils.GetPathSpec(ExtContentTextureUtils.GetStreamingAssetsFolderSpec(), _streamingAssetsTextureFileSpec));
			}
			if (_texture2DBG != null)
			{
				result = _texture2DBG;
			}
			return result;
		}

		public float GetIconImageAspectRatio(float mainImagePreferredAsepctRatio)
		{
			float result = mainImagePreferredAsepctRatio;
			switch (_iconImageApsectRatioType)
			{
			case IconAspectRatioType.CalulatedfromUVs:
				if (_UVs != null && _UVs.Length == 4)
				{
					float num = Mathf.Max(_UVs[2].x - _UVs[1].x, _UVs[3].x - _UVs[0].x);
					float num2 = Mathf.Max(_UVs[1].y - _UVs[0].y, _UVs[2].y - _UVs[3].y);
					if (num2 != 0f)
					{
						result = num / num2;
					}
				}
				break;
			case IconAspectRatioType.Specific:
				result = _iconImageSpecificWidth / _iconImageSpecificHeight;
				break;
			}
			return result;
		}
	}
}
