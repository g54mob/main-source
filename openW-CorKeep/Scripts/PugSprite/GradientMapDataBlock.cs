using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class GradientMapDataBlock : ScriptableDataBlock
{
	public enum Mode
	{
		Texture = 0,
		Array = 1
	}

	public DataBlockRef<GradientMapDataBlock> recolorTarget;

	public Mode mode;

	public Texture2D texture;

	public Color32[] array = new Color32[1];

	private bool m_hasEditorTexture;

	public bool hasData
	{
		get
		{
			if (!m_useTexture)
			{
				if (array != null)
				{
					return array.Length != 0;
				}
				return false;
			}
			return texture != null;
		}
	}

	public int textureWidth
	{
		get
		{
			if (!m_useTexture)
			{
				return 256;
			}
			return texture.width;
		}
	}

	public bool isReadable
	{
		get
		{
			if (!m_useTexture)
			{
				return true;
			}
			return texture.isReadable;
		}
	}

	private bool m_useTexture => mode == Mode.Texture;

	public Color32[] GetPixels32()
	{
		if (!m_useTexture)
		{
			return array;
		}
		return texture.GetPixels32();
	}

	public Color GetPixel(int x)
	{
		if (!m_useTexture)
		{
			return GetArrayColor(x);
		}
		return texture.GetPixel(x, 0);
	}

	private void OnValidate()
	{
		m_hasEditorTexture = false;
		if (Application.isPlaying)
		{
			SpriteAssetManager.CreateGradientMapAtlas();
		}
	}

	public void SetAsArray(List<Color32> colors)
	{
		array = colors.ToArray();
		mode = Mode.Array;
	}

	public Color32 GetArrayColor(int x)
	{
		int num = Mathf.FloorToInt((float)x / 256f * (float)array.Length);
		return array[num];
	}
}
