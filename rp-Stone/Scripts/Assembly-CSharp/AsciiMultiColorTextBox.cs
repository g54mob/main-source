using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AsciiMultiColorTextBox : AsciiTextBox
{
	private string modifiedText;

	private AsciiString messageLabel = new AsciiString();

	private List<string> _lines = new List<string>();

	private List<Color> colorMask = new List<Color>();

	public override string Text => modifiedText;

	public List<string> Lines => _lines;

	public List<Color> ColorMask => colorMask;

	protected override void UpdateContentsIfNeeded()
	{
		if (modifiedText == null && text != null)
		{
			UpdateContents();
		}
		else
		{
			base.UpdateContentsIfNeeded();
		}
	}

	public override void UpdateContents()
	{
		modifiedText = base.text;
		if (autoLocalized)
		{
			modifiedText = Te.xt(base.text);
		}
		ParseColors();
		_lines.Clear();
		base.lineCount = 0;
		if (string.IsNullOrEmpty(modifiedText))
		{
			return;
		}
		language = Te.id;
		string text = Utils.InsertLineBreaks(modifiedText, width);
		string text2 = modifiedText;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<Color> list = colorMask;
		while (num < text2.Length && num2 < text.Length && num3 < list.Count)
		{
			char c = text2[num];
			char c2 = text[num2];
			if (c2 == '\n' && (c == '\n' || c == ' '))
			{
				list.RemoveAt(num3);
				num3--;
			}
			if (c != c2 && c != ' ')
			{
				num2++;
				continue;
			}
			num++;
			num2++;
			num3++;
		}
		string[] array = text.Split(new char[1] { '\n' });
		_lines = new List<string>(array);
		base.lineCount = array.Length;
	}

	protected override void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY, Color c)
	{
		UpdateContentsIfNeeded();
		offsetX += positionX;
		offsetY += positionY;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < _lines.Count; i++)
		{
			string text = _lines[i];
			int num3 = offsetX;
			if (alignment == AsciiString.Alignment.Center)
			{
				num3 += (width - text.Length) / 2;
			}
			else if (alignment == AsciiString.Alignment.Right)
			{
				num3 += width - text.Length;
			}
			messageLabel.color = c;
			messageLabel.SetValue(text);
			messageLabel.SetColorMask(colorMask, num);
			messageLabel.Draw(r, num3, offsetY + num2 + i);
			num += text.Length;
		}
	}

	private void ParseColors()
	{
		colorMask.Clear();
		if (modifiedText == null)
		{
			return;
		}
		modifiedText = modifiedText.Replace("\\n", char.ToString('\n'));
		int num = 0;
		while (true)
		{
			num = modifiedText.IndexOf("[color=", num);
			if (num >= 0)
			{
				int num2 = modifiedText.IndexOf("]", num);
				int num3 = modifiedText.IndexOf("[/color]", num2);
				if (num2 < 0 || num3 < 0)
				{
					num++;
					continue;
				}
				string colorStr = modifiedText.Substring(num + 7, num2 - num - 7);
				num2++;
				string text = modifiedText.Substring(0, num);
				string text2 = modifiedText.Substring(num2, num3 - num2);
				num3 += 8;
				string text3 = modifiedText.Substring(num3);
				modifiedText = text + text2 + text3;
				AddColorInRange(colorStr, num, text2.Length);
				continue;
			}
			break;
		}
	}

	private void AddColorInRange(string colorStr, int startIndex, int length)
	{
		Color color = Utils.ConvertColor(colorStr);
		if (color != ColorConstants.invalid)
		{
			AddColorInRange(color, startIndex, length);
		}
	}

	private void AddColorInRange(Color color, int startIndex, int length)
	{
		for (int i = 0; i < startIndex + length; i++)
		{
			if (i >= startIndex)
			{
				if (i < colorMask.Count)
				{
					colorMask[i] = color;
				}
				else
				{
					colorMask.Add(color);
				}
			}
			else if (i >= colorMask.Count)
			{
				colorMask.Add(base.color);
			}
		}
	}
}
