using System;

public class AkSourceSettingsArray : AkBaseArray<AkSourceSettings>
{
	protected override int StructureSize => 0;

	public AkSourceSettingsArray(int count)
		: base(0)
	{
	}

	protected override void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected override AkSourceSettings CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkSourceSettings other)
	{
	}
}
