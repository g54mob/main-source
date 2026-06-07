using System;

public class AkTriangleArray : AkBaseArray<AkTriangle>
{
	protected override int StructureSize => 0;

	public AkTriangleArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override AkTriangle CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkTriangle other)
	{
	}
}
