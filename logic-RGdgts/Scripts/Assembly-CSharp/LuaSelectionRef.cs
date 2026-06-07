using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class LuaSelectionRef
{
	public LuaSelection value;

	public LuaSelectionRef()
	{
	}

	public LuaSelectionRef(LuaSelection value)
	{
	}

	public static implicit operator LuaSelectionRef(KnobMode_DataSelectionEnum value)
	{
		return null;
	}

	public static implicit operator LuaSelectionRef(SerialParity_DataSelectionEnum value)
	{
		return null;
	}

	public static implicit operator LuaSelectionRef(SerialReceiveMode_DataSelectionEnum value)
	{
		return null;
	}

	public static implicit operator LuaSelectionRef(SerialStopBits_DataSelectionEnum value)
	{
		return null;
	}

	public static implicit operator LuaSelectionRef(Symbol_DataSelectionEnum value)
	{
		return null;
	}

	public static implicit operator LuaSelectionRef(VideoChipMode_DataSelectionEnum value)
	{
		return null;
	}
}
