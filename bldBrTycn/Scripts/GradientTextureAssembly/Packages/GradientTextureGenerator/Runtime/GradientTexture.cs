using System;
using System.Diagnostics;
using UnityEngine;

namespace Packages.GradientTextureGenerator.Runtime
{
	[CreateAssetMenu(fileName = "NewGradientName", menuName = "Texture/Gradient")]
	public class GradientTexture : ScriptableObject, IEquatable<Texture2D>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private Vector2Int _resolution = new Vector2Int(256, 256);

		[Range(0f, 1f)]
		[SerializeField]
		private float _dithering;

		[SerializeField]
		private AnimationCurve _verticalLerp = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[GradientUsage(true)]
		private Gradient _horizontalTop = GetDefaultGradient();

		[SerializeField]
		[GradientUsage(true)]
		private Gradient _horizontalBottom = GetDefaultGradient();

		[HideInInspector]
		[SerializeField]
		private Texture2D _texture;

		private int _width => _resolution.x;

		private int _height => _resolution.y;

		private string _textureName => "T_" + base.name;

		public Texture2D GetTexture()
		{
			return _texture;
		}

		private static Gradient GetDefaultGradient()
		{
			Gradient gradient = new Gradient();
			gradient.alphaKeys = new GradientAlphaKey[1]
			{
				new GradientAlphaKey(1f, 1f)
			};
			gradient.colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(Color.black, 0f),
				new GradientColorKey(Color.white, 1f)
			};
			return gradient;
		}

		public void FillColors()
		{
			float num = 0f;
			for (int i = 0; i < _height; i++)
			{
				num = _verticalLerp.Evaluate((float)i / (float)_height);
				for (int j = 0; j < _width; j++)
				{
					float time = (float)j / (float)_width;
					Color color = Color.Lerp(_horizontalBottom.Evaluate(time), _horizontalTop.Evaluate(time), num);
					if (_dithering > 0f)
					{
						bool num2 = j % 2 == 0 && i % 2 != 0;
						bool flag = j % 2 != 0 && i % 2 == 0;
						if (num2 || flag)
						{
							color.r *= 1f - _dithering;
							color.g *= 1f - _dithering;
							color.b *= 1f - _dithering;
						}
					}
					_texture.SetPixel(j, i, color);
				}
			}
			_texture.Apply();
		}

		public bool Equals(Texture2D other)
		{
			return _texture.Equals(other);
		}

		private void OnValidate()
		{
		}

		[Conditional("UNITY_EDITOR")]
		private void SetDirtyTexture()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
