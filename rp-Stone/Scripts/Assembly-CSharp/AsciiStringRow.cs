public class AsciiStringRow : AsciiObject
{
	public AsciiString asciiString;

	public string text
	{
		get
		{
			return asciiString.Value;
		}
		set
		{
			asciiString.SetValue(value);
		}
	}

	public void Clear()
	{
		if (asciiString != null)
		{
			asciiString.Clear();
		}
	}

	public override void UpdateTic()
	{
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (asciiString != null)
		{
			asciiString.Draw(r, offsetX, offsetY);
		}
	}
}
