using System;

public class AkReflectionPathInfoArray : AkBaseArray<AkReflectionPathInfo>
{
	protected override int StructureSize => 0;

	public AkReflectionPathInfoArray(int count)
		: base(0)
	{
	}

	protected override AkReflectionPathInfo CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkReflectionPathInfo other)
	{
	}
}
