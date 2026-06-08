using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AsciiTextBox : IAsciiObject
{
	[SerializeField]
	protected string text;

	public char transparentSymbol = '#';

	public bool autoLocalized;

	public int positionX;

	public int positionY;

	public int width;

	public int height = 20;

	public AsciiString.Alignment alignment;

	public Color color = Color.white;

	public Color backgroundColor = Color.black;

	private int _lineCount;

	private List<List<char>> _symbols = new List<List<char>>();

	private string _lastText;

	private int _lastWidth;

	protected string language = "";

	public virtual string Text
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
		}
	}

	public string[] lines { get; private set; }

	public int lineCount
	{
		get
		{
			UpdateContentsIfNeeded();
			return _lineCount;
		}
		protected set
		{
			_lineCount = value;
		}
	}

	public int lastSymbolDrawX { get; private set; }

	public int lastSymbolDrawY { get; private set; }

	public void UpdateTic()
	{
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color colorOverride)
	{
		DoDraw(r, offsetX, offsetY, colorOverride);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		DoDraw(r, offsetX, offsetY, color);
	}

	protected virtual void UpdateContentsIfNeeded()
	{
		if (_lastText != text || _lastWidth != width || (autoLocalized && language != Te.id))
		{
			_lastText = text;
			_lastWidth = width;
			UpdateContents();
		}
	}

	public virtual void UpdateContents()
	{
		string text = Text;
		_symbols.Clear();
		lineCount = 0;
		if (!string.IsNullOrEmpty(text))
		{
			language = Te.id;
			string message = text;
			if (autoLocalized)
			{
				message = Te.xt(text);
			}
			_SetLines(Utils.BreakIntoLines(message, width));
		}
	}

	public void SetLines(string[] lines)
	{
		text = string.Join("\n", lines);
		_lastText = text;
		_lastWidth = width;
		_lineCount = lines.Length;
		_symbols.Clear();
		_SetLines(lines);
	}

	private void _SetLines(string[] lines)
	{
		this.lines = lines;
		for (int i = 0; i < lines.Length; i++)
		{
			List<char> list = new List<char>();
			_symbols.Add(list);
			string text = lines[i];
			for (int j = 0; j < text.Length; j++)
			{
				list.Add(text[j]);
			}
		}
		lineCount = Mathf.Min(lines.Length, height);
	}

	protected virtual void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY, Color c)
	{
		UpdateContentsIfNeeded();
		offsetX += positionX;
		offsetY += positionY;
		int num = SpecialSymbols.Map(transparentSymbol);
		int num2 = offsetY;
		for (int i = 0; i < _symbols.Count && i < height; i++)
		{
			List<char> list = _symbols[i];
			int num3 = offsetX;
			if (alignment == AsciiString.Alignment.Center)
			{
				num3 += (width - list.Count) / 2;
			}
			else if (alignment == AsciiString.Alignment.Right)
			{
				num3 += width - list.Count;
			}
			r.SetCell(num3 - 1, num2, ' ', backgroundColor, backgroundColor);
			r.SetCell(num3 + list.Count, num2, ' ', backgroundColor, backgroundColor);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] != num)
				{
					char c2 = list[j];
					int num4 = SpecialSymbols.Map(c2);
					if (num4 >= 0)
					{
						if (num4 == 21)
						{
							c = ColorConstants.legendQuest;
						}
						if (backgroundColor != Color.white)
						{
							r.SetCell(num3, num2, num4, c, backgroundColor);
						}
						else
						{
							r.SetCell(num3, num2, num4, c);
						}
					}
					else if (backgroundColor != Color.white)
					{
						r.SetCell(num3, num2, c2, c, backgroundColor);
					}
					else
					{
						r.SetCell(num3, num2, c2, c);
					}
				}
				lastSymbolDrawX = num3;
				lastSymbolDrawY = num2;
				num3++;
			}
			num2++;
		}
	}
}
