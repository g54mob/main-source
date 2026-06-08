using System;
using UnityEngine;

public class UITextBox : UIControl
{
	public AsciiMultiColorTextBox textBox;

	public override void ResetControl()
	{
		base.ResetControl();
		textBox.alignment = AsciiString.Alignment.Left;
		textBox.color = ColorConstants.white;
		textBox.backgroundColor = ColorConstants.black;
		textBox.Text = "";
	}

	public override void UpdateTic()
	{
		textBox.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (IsVisibleInHierarchy())
		{
			textBox.positionX = PositionX;
			textBox.positionY = PositionY;
			textBox.width = Width;
			textBox.height = Height;
			textBox.Draw(r, offsetX, offsetY);
		}
	}

	[StonescriptNativeGetter("align")]
	public object Property_GetAlign()
	{
		return textBox.alignment.ToString();
	}

	[StonescriptNativeSetter("align")]
	public void Property_SetAlign(object value)
	{
		textBox.alignment = (AsciiString.Alignment)Enum.Parse(typeof(AsciiString.Alignment), value.ToString(), ignoreCase: true);
	}

	[StonescriptNativeGetter("color")]
	public object Property_GetColor()
	{
		string text = ColorUtility.ToHtmlStringRGB(textBox.color);
		return "#" + text;
	}

	[StonescriptNativeSetter("color")]
	public void Property_SetColor(object value)
	{
		string colorStr = value as string;
		textBox.color = Utils.ConvertColor(colorStr);
	}

	[StonescriptNativeGetter("lines")]
	public object Property_GetLines()
	{
		return new StonescriptArray(textBox.Lines);
	}

	[StonescriptNativeGetter("text")]
	public object Property_GetText()
	{
		return textBox.Text;
	}

	[StonescriptNativeSetter("text")]
	public void Property_SetText(object value)
	{
		string text = value as string;
		text = text.Replace('［', '[');
		text = text.Replace('］', ']');
		textBox.Text = text;
	}
}
