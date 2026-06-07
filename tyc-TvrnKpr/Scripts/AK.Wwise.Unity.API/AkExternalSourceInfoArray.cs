using System;

public class AkExternalSourceInfoArray : AkBaseArray<AkExternalSourceInfo>
{
	protected override int StructureSize => 0;

	public AkExternalSourceInfoArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override void ReleaseAllocatedMemoryFromReferenceAtIntPtr(IntPtr address)
	{
	}

	protected override AkExternalSourceInfo CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkExternalSourceInfo other)
	{
	}
}
