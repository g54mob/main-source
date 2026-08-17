using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextureData : UpdatableData
{
	[Serializable]
	public class Layer
	{
		public Texture2D texture;

		public Color tint;

		public float tintStrength;

		public float startHeight;

		public float blendStrength;

		public float textureScale;

		public TerrainType type;
	}

	public enum TerrainType
	{
		Water,
		Sand,
		Grass
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Layer, Color> _003C_003E9__5_0;

		public static Func<Layer, float> _003C_003E9__5_1;

		public static Func<Layer, float> _003C_003E9__5_2;

		public static Func<Layer, float> _003C_003E9__5_3;

		public static Func<Layer, float> _003C_003E9__5_4;

		public static Func<Layer, Texture2D> _003C_003E9__5_5;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe Color _003CApplyToMaterial_003Eb__5_0(Layer x)
		{
			//IL_002f: Expected F4, but got O
			//IL_002a: Expected native int or pointer, but got O
			if (x != null)
			{
				Color color = default(Color);
				((Color*)(nint)color)->r = (float)x.tint;
				return color;
			}
			return (Color)new NullReferenceException();
		}

		internal float _003CApplyToMaterial_003Eb__5_1(Layer x)
		{
			return x.startHeight;
		}

		internal float _003CApplyToMaterial_003Eb__5_2(Layer x)
		{
			return x.blendStrength;
		}

		internal float _003CApplyToMaterial_003Eb__5_3(Layer x)
		{
			return x.tintStrength;
		}

		internal float _003CApplyToMaterial_003Eb__5_4(Layer x)
		{
			return x.textureScale;
		}

		internal Texture2D _003CApplyToMaterial_003Eb__5_5(Layer x)
		{
			if (x != null)
			{
				return x.texture;
			}
			return (Texture2D)(object)new NullReferenceException();
		}
	}

	private const int textureSize = 512;

	private const TextureFormat textureFormat = TextureFormat.RGB565;

	public Layer[] layers;

	private float savedMinHeight;

	private float savedMaxHeight;

	public unsafe void ApplyToMaterial(Material material)
	{
		Layer[] array = layers;
		material.SetInt("layerCount", array.Length);
		Func<Layer, Color> selector = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__5_0 = delegate(Layer x)
			{
				//IL_002f: Expected F4, but got O
				//IL_002a: Expected native int or pointer, but got O
				if (x != null)
				{
					Color color = default(Color);
					((Color*)(nint)color)->r = (float)x.tint;
					return color;
				}
				return (Color)new NullReferenceException();
			});
		}
		IEnumerable<Color> source = Enumerable.Select(layers, selector);
		Color[] values = Enumerable.ToArray(source);
		material.SetColorArray("baseColours", values);
		Func<Layer, float> selector2 = _003C_003Ec._003C_003E9__5_1;
		if (_003C_003Ec._003C_003E9__5_1 == null)
		{
			selector2 = (_003C_003Ec._003C_003E9__5_1 = (Func<object, float>)((Layer x) => x.startHeight));
		}
		IEnumerable<float> source2 = Enumerable.Select(layers, selector2);
		float[] values2 = Enumerable.ToArray(source2);
		material.SetFloatArray("baseStartHeights", values2);
		Func<Layer, float> selector3 = _003C_003Ec._003C_003E9__5_2;
		if (_003C_003Ec._003C_003E9__5_2 == null)
		{
			selector3 = (_003C_003Ec._003C_003E9__5_2 = (Func<object, float>)((Layer x) => x.blendStrength));
		}
		IEnumerable<float> source3 = Enumerable.Select(layers, selector3);
		float[] values3 = Enumerable.ToArray(source3);
		material.SetFloatArray("baseBlends", values3);
		Func<Layer, float> selector4 = _003C_003Ec._003C_003E9__5_3;
		if (_003C_003Ec._003C_003E9__5_3 == null)
		{
			selector4 = (_003C_003Ec._003C_003E9__5_3 = (Func<object, float>)((Layer x) => x.tintStrength));
		}
		IEnumerable<float> source4 = Enumerable.Select(layers, selector4);
		float[] values4 = Enumerable.ToArray(source4);
		material.SetFloatArray("baseColourStrength", values4);
		Func<Layer, float> selector5 = _003C_003Ec._003C_003E9__5_4;
		if (_003C_003Ec._003C_003E9__5_4 == null)
		{
			selector5 = (_003C_003Ec._003C_003E9__5_4 = (Func<object, float>)((Layer x) => x.textureScale));
		}
		IEnumerable<float> source5 = Enumerable.Select(layers, selector5);
		float[] values5 = Enumerable.ToArray(source5);
		material.SetFloatArray("baseTextureScales", values5);
		Func<Layer, Texture2D> selector6 = _003C_003Ec._003C_003E9__5_5;
		if (_003C_003Ec._003C_003E9__5_5 == null)
		{
			selector6 = (_003C_003Ec._003C_003E9__5_5 = (Layer x) => (Texture2D)((x != null) ? ((object)x.texture) : ((object)new NullReferenceException())));
		}
		IEnumerable<Texture2D> source6 = Enumerable.Select(layers, selector6);
		object[] array2 = Enumerable.ToArray((IEnumerable<object>)source6);
		TextureFormat textureFormat = default(TextureFormat);
		bool mipChain = default(bool);
		Texture2DArray texture2DArray = new Texture2DArray(512, 512, array2.Length, textureFormat, mipChain);
		int num = 0;
		for (int num2 = 0; num2 < array2.Length; num2 = num)
		{
			if ((bool)(UnityEngine.Object)array2[num])
			{
				Color[] pixels = ((Texture2D)array2[num]).GetPixels();
				texture2DArray.SetPixels(pixels, num);
			}
			num++;
		}
		texture2DArray.Apply();
		material.SetTexture("baseTextures", texture2DArray);
	}

	public void UpdateMeshHeights(float minHeight, float maxHeight)
	{
		savedMinHeight = minHeight;
		savedMaxHeight = maxHeight;
	}

	private Texture2DArray GenerateTextureArray(Texture2D[] textures)
	{
		TextureFormat textureFormat = default(TextureFormat);
		bool mipChain = default(bool);
		Texture2DArray texture2DArray = new Texture2DArray(512, 512, textures.Length, textureFormat, mipChain);
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < textures.Length)
			{
				if (num >= textures.Length)
				{
					break;
				}
				if ((bool)textures[num])
				{
					if (num >= textures.Length)
					{
						break;
					}
					Color[] pixels = textures[num].GetPixels();
					texture2DArray.SetPixels(pixels, num);
				}
				num++;
				num2 = num;
				continue;
			}
			texture2DArray.Apply();
			return texture2DArray;
		}
		return (Texture2DArray)(object)new IndexOutOfRangeException();
	}
}
