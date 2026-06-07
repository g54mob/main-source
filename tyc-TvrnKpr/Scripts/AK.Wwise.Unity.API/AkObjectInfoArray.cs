using System;

public class AkObjectInfoArray : AkBaseArray<AkObjectInfo>
{
	protected override int StructureSize => 0;

	public AkObjectInfoArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override AkObjectInfo CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkObjectInfo other)
	{
	}
}
