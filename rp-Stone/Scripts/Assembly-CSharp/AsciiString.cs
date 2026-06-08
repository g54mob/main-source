using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AsciiString
{
	public enum Alignment
	{
		Left = 0,
		Center = 1,
		Right = 2
	}

	public string initialString;

	public char transparentSymbol = '#';

	public bool autoLocalized;

	[SerializeField]
	private int positionX;

	[SerializeField]
	private int positionY;

	public Alignment alignment;

	public Color color = Color.white;

	public bool isRainbow;

	private Color _bgColor = Color.white;

	private string _value = "";

	private List<int> _symbols = new List<int>();

	private List<char> _unicodeSymbols = new List<char>();

	private bool valueEverSet;

	private string language = "";

	private List<Color> colorMask;

	private int colorMaskStartIndex;

	private static float rainbowSize = 2f;

	private static float velocity = -0.4f;

	private static float luminance = 0.5f;

	public int PositionX
	{
		get
		{
			return positionX;
		}
		set
		{
			positionX = value;
		}
	}

	public int PositionY
	{
		get
		{
			return positionY;
		}
		set
		{
			positionY = value;
		}
	}

	public Color backgroundColor
	{
		get
		{
			return _bgColor;
		}
		set
		{
			_bgColor = value;
		}
	}

	public string Value => _value;

	public List<int> Symbols => _symbols;

	public int Length => _symbols.Count;

	public void Init()
	{
		SetValue(initialString);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color colorOverride)
	{
		DoDraw(r, offsetX, offsetY, colorOverride);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		DoDraw(r, offsetX, offsetY, color);
	}

	private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY, Color c)
	{
		if (autoLocalized && language != Te.id)
		{
			SetValue(Te.xt(initialString));
		}
		else if (!valueEverSet)
		{
			Init();
		}
		offsetX += PositionX;
		offsetY += PositionY;
		if (alignment == Alignment.Right)
		{
			offsetX -= _symbols.Count - 1;
		}
		else if (alignment == Alignment.Center)
		{
			offsetX -= _symbols.Count / 2;
		}
		int num = SpecialSymbols.Map(transparentSymbol);
		for (int i = 0; i < _symbols.Count; i++)
		{
			int num2 = _symbols[i];
			if (num2 == num && (i >= _unicodeSymbols.Count || _unicodeSymbols[i] == '\0'))
			{
				continue;
			}
			Color color = c;
			if (isRainbow)
			{
				color = GetRainbowColor(i, _symbols.Count) * c.grayscale;
			}
			else if (num2 == 21)
			{
				color = ColorConstants.legendQuest;
			}
			else if (color == this.color)
			{
				color = GetColorFromMask(i);
			}
			if (i < _unicodeSymbols.Count && _unicodeSymbols[i] != 0)
			{
				if (backgroundColor != Color.white)
				{
					r.SetCell(i + offsetX, offsetY, _unicodeSymbols[i], color, backgroundColor);
				}
				else
				{
					r.SetCell(i + offsetX, offsetY, _unicodeSymbols[i], color);
				}
			}
			else if (backgroundColor != Color.white)
			{
				r.SetCell(i + offsetX, offsetY, num2, color, backgroundColor);
			}
			else
			{
				r.SetCell(i + offsetX, offsetY, num2, color);
			}
		}
	}

	public void Clear()
	{
		valueEverSet = true;
		_value = "";
		_symbols.Clear();
		_unicodeSymbols.Clear();
	}

	public void SetValue(string str)
	{
		valueEverSet = true;
		if (_value == str || (_value == "" && str == null))
		{
			return;
		}
		if (str == null)
		{
			str = "";
		}
		language = Te.id;
		_value = str;
		_symbols.Clear();
		_unicodeSymbols.Clear();
		foreach (char c in str)
		{
			int num = SpecialSymbols.Map(c);
			if (num >= 0)
			{
				_symbols.Add(num);
				_unicodeSymbols.Add('\0');
			}
			else
			{
				_symbols.Add(32);
				_unicodeSymbols.Add(c);
			}
		}
	}

	public void SetValue(List<int> symbols)
	{
		string text = "";
		_symbols.Clear();
		_unicodeSymbols.Clear();
		for (int i = 0; i < symbols.Count; i++)
		{
			_symbols.Add(symbols[i]);
			string text2 = char.ToString((char)symbols[i]);
			text += text2;
		}
		_value = text;
	}

	public void SetColorMask(List<Color> colorMask, int colorMaskStartIndex = 0)
	{
		this.colorMask = colorMask;
		this.colorMaskStartIndex = colorMaskStartIndex;
	}

	public void ClearColorMask()
	{
		colorMask = null;
		colorMaskStartIndex = 0;
	}

	private Color GetColorFromMask(int index)
	{
		index += colorMaskStartIndex;
		if (colorMask == null || index < 0 || index >= colorMask.Count)
		{
			return color;
		}
		return colorMask[index];
	}

	public static Color GetRainbowColor(int index, int width)
	{
		return GetRainbowHue(Time.realtimeSinceStartup * velocity + (float)index / (rainbowSize * (float)(Mathf.Max(1, width) + 1)));
	}

	private static Color GetRainbowHue(float t)
	{
		Color a = Color.HSVToRGB(Mathf.Repeat(t, 1f), 1f, 1f);
		if (luminance < 0f)
		{
			return Color.Lerp(a, Color.black, 0f - luminance);
		}
		return Color.Lerp(a, Color.white, luminance);
	}
}
