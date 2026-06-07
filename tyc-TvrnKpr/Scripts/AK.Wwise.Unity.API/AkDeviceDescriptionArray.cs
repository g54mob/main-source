using System;

public class AkDeviceDescriptionArray : AkBaseArray<AkDeviceDescription>
{
	protected override int StructureSize => 0;

	public AkDeviceDescriptionArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override AkDeviceDescription CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkDeviceDescription other)
	{
	}
}
