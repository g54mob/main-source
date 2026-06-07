using System;

[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
public class AkVertexArray : AkBaseArray<AkVertex>
{
	protected override int StructureSize => 0;

	public AkVertexArray(int count)
		: base(0)
	{
	}

	protected override AkVertex CreateNewReferenceFromIntPtr(IntPtr address)
	{
		return null;
	}

	protected override void CloneIntoReferenceFromIntPtr(IntPtr address, AkVertex other)
	{
	}
}
