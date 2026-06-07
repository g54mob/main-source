using System;
using System.Runtime.CompilerServices;

[Serializable]
public class Slicer2DEventHandling
{
	public delegate bool Slice2DEvent(Slice2D slice);

	public delegate void Slice2DResultEvent(Slice2D slice);

	public event Slice2DEvent sliceEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Slice2DResultEvent sliceResultEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Slice2DEvent anchorSliceEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Slice2DResultEvent anchorSliceResultEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Slice2DEvent globalSliceEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Slice2DResultEvent globalSliceResultEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Slice2DEvent anchorGlobalSliceEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Slice2DResultEvent anchorGlobalSliceResultEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void ClearEvents()
	{
	}

	public bool SliceEvent(Slice2D slice)
	{
		return false;
	}

	public bool AnchorSliceEvent(Slice2D slice)
	{
		return false;
	}

	public static bool GlobalSliceEvent(Slice2D slice)
	{
		return false;
	}

	public static bool AnchorGlobalSliceEvent(Slice2D slice)
	{
		return false;
	}

	public void Result(Slice2D slice)
	{
	}

	public void AnchorResult(Slice2D slice)
	{
	}
}
