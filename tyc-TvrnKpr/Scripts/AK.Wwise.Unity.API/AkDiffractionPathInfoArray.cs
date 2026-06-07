using System;

public class AkDiffractionPathInfoArray : AkBaseArray<AkDiffractionPathInfo>
{
	protected override int StructureSize => 0;

	public AkDiffractionPathInfoArray(int count)
		: base(0)
	{
	}

	protected override AkDiffractionPathInfo CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkDiffractionPathInfo other)
	{
	}
}
