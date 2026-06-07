using System;

public class AkAcousticSurfaceArray : AkBaseArray<AkAcousticSurface>
{
	protected override int StructureSize => 0;

	public AkAcousticSurfaceArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override AkAcousticSurface CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkAcousticSurface other)
	{
	}
}
