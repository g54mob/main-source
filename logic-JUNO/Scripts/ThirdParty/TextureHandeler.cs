using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class TextureHandeler
{
	[SerializeField]
	public Texture2D _texTargetTexture;

	protected Texture2D _texPreviousTexture;

	[SerializeField]
	protected List<List<Color>> _colTextureColours;

	private int _iLastIndexLookUp = int.MaxValue;

	private int _iLastX = int.MaxValue;

	private int _iLastY = int.MaxValue;

	public int Width
	{
		get
		{
			if (_colTextureColours != null)
			{
				return _colTextureColours.Count;
			}
			return 0;
		}
	}

	public int Height
	{
		get
		{
			if (_colTextureColours != null && _colTextureColours[0] != null)
			{
				return _colTextureColours[0].Count;
			}
			return 0;
		}
	}

	public bool Clamp
	{
		get
		{
			if (_texTargetTexture == null)
			{
				return false;
			}
			if (_texTargetTexture.wrapMode == TextureWrapMode.Clamp)
			{
				return true;
			}
			return false;
		}
	}

	public TextureHandeler()
	{
	}

	public TextureHandeler(Texture2D texTarget)
	{
		_texTargetTexture = texTarget;
		_texPreviousTexture = texTarget;
		Initalise();
	}

	public void Initalise()
	{
		FetchPixleColours();
	}

	public void Initalise(int iWidth, int iHeight, Color colColour)
	{
		_colTextureColours = new List<List<Color>>(iWidth);
		for (int i = 0; i < iWidth; i++)
		{
			List<Color> list = new List<Color>(iHeight);
			for (int j = 0; j < iHeight; j++)
			{
				list.Add(colColour);
			}
			_colTextureColours.Add(list);
		}
	}

	public void FetchPixleColours()
	{
		if (_texTargetTexture == null)
		{
			_colTextureColours = new List<List<Color>>();
			return;
		}
		Color[] pixels = _texTargetTexture.GetPixels();
		_colTextureColours = new List<List<Color>>(_texTargetTexture.width);
		for (int i = 0; i < _texTargetTexture.width; i++)
		{
			List<Color> list = new List<Color>(_texTargetTexture.height);
			for (int j = 0; j < _texTargetTexture.height; j++)
			{
				int num = _texTargetTexture.width * j + i;
				if (num < pixels.Length)
				{
					list.Add(pixels[num]);
				}
			}
			_colTextureColours.Add(list);
		}
	}

	public Color[] GetTextureColourArray()
	{
		List<Color> list = new List<Color>(_texTargetTexture.width * _texTargetTexture.height);
		if (_colTextureColours == null)
		{
			return null;
		}
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				if (_colTextureColours[j] != null)
				{
					list.Add(_colTextureColours[j][i]);
				}
			}
		}
		return list.ToArray();
	}

	public void SaveTexture(string strSaveAddress)
	{
		CheckForTextureChange();
		if (_colTextureColours != null)
		{
			_texTargetTexture.SetPixels(GetTextureColourArray());
			_texTargetTexture.Apply();
			byte[] bytes = _texTargetTexture.EncodeToPNG();
			Debug.Log("Saving");
			File.WriteAllBytes(Application.dataPath + "/" + strSaveAddress + ".png", bytes);
		}
	}

	public void Apply()
	{
		if (_texTargetTexture == null)
		{
			_texTargetTexture = new Texture2D(Width, Height);
		}
		else
		{
			_texTargetTexture.Reinitialize(Width, Height);
		}
		_texTargetTexture.SetPixels(GetTextureColourArray());
		_texTargetTexture.Apply();
	}

	public int GetLength()
	{
		CheckForTextureChange();
		if (_colTextureColours == null)
		{
			FetchPixleColours();
		}
		if (_colTextureColours == null)
		{
			return 0;
		}
		if (_colTextureColours.Count == 0)
		{
			FetchPixleColours();
		}
		return _colTextureColours.Count * _colTextureColours[0].Count;
	}

	public Color GetPixle(int iX, int iY)
	{
		if (iX == _iLastX && iY == _iLastY)
		{
			return _colTextureColours[iX][iY];
		}
		while (iX < 0)
		{
			iX += _texTargetTexture.width;
		}
		while (iY < 0)
		{
			iY += _texTargetTexture.height;
		}
		CheckForTextureChange();
		if (_texTargetTexture == null)
		{
			return Color.black;
		}
		if (_texTargetTexture.wrapMode == TextureWrapMode.Clamp)
		{
			iX = Mathf.Clamp(iX, 0, _texTargetTexture.width);
			iY = Mathf.Clamp(iY, 0, _texTargetTexture.height);
		}
		else
		{
			iX %= _texTargetTexture.width;
			iY %= _texTargetTexture.height;
		}
		_iLastX = iX;
		_iLastY = iY;
		return _colTextureColours[iX][iY];
	}

	public Color GetPixle(float fX, float fY)
	{
		int index = (int)((float)_colTextureColours.Count * fX);
		int index2 = (int)((float)_colTextureColours[0].Count * fY);
		return _colTextureColours[index][index2];
	}

	public Color GetPixle(int iPixleIndex)
	{
		if (iPixleIndex == _iLastIndexLookUp)
		{
			return _colTextureColours[_iLastX][_iLastY];
		}
		int num = iPixleIndex % _colTextureColours.Count;
		int num2 = (iPixleIndex - num) / _colTextureColours.Count;
		_iLastIndexLookUp = iPixleIndex;
		_iLastX = num;
		_iLastY = num2;
		return _colTextureColours[num][num2];
	}

	public void SetPixle(int iX, int iY, Color colColour)
	{
		_colTextureColours[iX][iY] = colColour;
	}

	public void SetPixle(float fX, float fY, Color colColour)
	{
		int index = (int)((float)_colTextureColours.Count * fX);
		int index2 = (int)((float)_colTextureColours[0].Count * fY);
		_colTextureColours[index][index2] = colColour;
	}

	public void SetPixle(int iPixleIndex, Color colColour)
	{
		int num = iPixleIndex % _colTextureColours.Count;
		int index = (iPixleIndex - num) / _colTextureColours.Count;
		_colTextureColours[num][index] = colColour;
	}

	public void SetPixles(int iSourceXStart, int iSourceYStart, int iSourceXEnd, int iSourceYEnd, int iDestinationXStart, int iDestinationYStart, TextureHandeler txhTextureHandeler)
	{
		if (txhTextureHandeler == null)
		{
			return;
		}
		if (iDestinationXStart < 0)
		{
			iSourceXStart -= iDestinationXStart;
			iDestinationXStart = 0;
		}
		if (iDestinationYStart < 0)
		{
			iSourceYStart -= iDestinationYStart;
			iDestinationYStart = 0;
		}
		int num = iSourceXEnd - iSourceXStart;
		int num2 = iSourceYEnd - iSourceYStart;
		if (num <= 0)
		{
			Debug.LogError("Texture Coordinate Error");
			return;
		}
		if (num2 <= 0)
		{
			Debug.LogError("Texture Coordinate Error");
			return;
		}
		int num3 = iDestinationXStart + num;
		int num4 = iDestinationYStart + num2;
		if (num3 >= Width)
		{
			num -= num3 - Width;
			if (num <= 0)
			{
				return;
			}
		}
		if (num4 >= Height)
		{
			num2 -= num4 - Height;
			if (num2 <= 0)
			{
				return;
			}
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int index = iDestinationXStart + i;
				int index2 = iDestinationYStart + j;
				int index3 = iSourceXStart + i;
				int index4 = iSourceYStart + j;
				_colTextureColours[index][index2] = txhTextureHandeler._colTextureColours[index3][index4];
			}
		}
	}

	public void ExpandUP(int iRowsToAdd, Color colExpansionColour)
	{
		Color[] array = new Color[iRowsToAdd];
		for (int i = 0; i < iRowsToAdd; i++)
		{
			array[i] = colExpansionColour;
		}
		for (int j = 0; j < Width; j++)
		{
			_colTextureColours[j].AddRange(array);
		}
	}

	public void ExpandDown(int iRowsToAdd, Color colExpansionColour)
	{
		List<List<Color>> list = new List<List<Color>>(Width);
		for (int i = 0; i < Width; i++)
		{
			List<Color> list2 = new List<Color>(iRowsToAdd + Height);
			for (int j = 0; j < iRowsToAdd; j++)
			{
				list2.Add(colExpansionColour);
			}
			list2.AddRange(_colTextureColours[i]);
			list.Add(list2);
		}
		_colTextureColours = list;
	}

	public void ExpandLeft(int iRowsToAdd, Color colExpansionColour)
	{
		List<List<Color>> list = new List<List<Color>>(Width + iRowsToAdd);
		Color[] array = new Color[Height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = colExpansionColour;
		}
		for (int j = 0; j < iRowsToAdd; j++)
		{
			List<Color> list2 = new List<Color>(array.Length);
			list2.AddRange(array);
			list.Add(list2);
		}
		list.AddRange(_colTextureColours);
		_colTextureColours = list;
	}

	public void ExpandRight(int iRowsToAdd, Color colExpansionColour)
	{
		Color[] array = new Color[Height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = colExpansionColour;
		}
		for (int j = 0; j < iRowsToAdd; j++)
		{
			List<Color> list = new List<Color>(array.Length);
			list.AddRange(array);
			_colTextureColours.Add(list);
		}
	}

	public void CheckForTextureChange()
	{
		if (_texPreviousTexture != _texTargetTexture)
		{
			_texPreviousTexture = _texTargetTexture;
			if (_texTargetTexture != null)
			{
				FetchPixleColours();
			}
		}
	}

	public List<Color> GetNeighbours(int iX, int iLayer)
	{
		int num = iX % _colTextureColours.Count;
		int iY = (iX - num) / _colTextureColours.Count;
		return GetNeighbours(num, iY, iLayer);
	}

	public List<Color> GetNeighbours(int iX, int iY, int iLayer)
	{
		List<Color> list = new List<Color>(4 + iLayer * 4);
		if (iLayer <= 0)
		{
			list.Add(GetPixle(iX, iY));
			return list;
		}
		for (int i = iX - iLayer; i < iX + iLayer; i++)
		{
			list.Add(GetPixle(i, iY - iLayer));
		}
		for (int j = iY - iLayer; j < iY + iLayer; j++)
		{
			list.Add(GetPixle(iX + iLayer, j));
		}
		for (int num = iX + iLayer; num > iX - iLayer; num--)
		{
			list.Add(GetPixle(num, iY + iLayer));
		}
		for (int num2 = iY + iLayer; num2 > iY - iLayer; num2--)
		{
			list.Add(GetPixle(iX - iLayer, num2));
		}
		return list;
	}

	public Texture2D GenerateTexture(Texture2D texTextureToOverride = null)
	{
		if (texTextureToOverride == null)
		{
			texTextureToOverride = new Texture2D(Width, Height, TextureFormat.RGBA32, mipChain: false);
		}
		else
		{
			texTextureToOverride.Reinitialize(Width, Height);
		}
		texTextureToOverride.SetPixels(GetTextureColourArray());
		texTextureToOverride.Apply(updateMipmaps: false);
		return texTextureToOverride;
	}
}
