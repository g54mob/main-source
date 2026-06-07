public class TwoPointBlockOneBody : TwoPointBlockBase
{
	public TwoPointBlockOneBody(TwoPointBlock twoPointBlock)
		: base(twoPointBlock)
	{
	}

	protected override void InternalMakeMesh()
	{
		if (twoPointBlock.Place == TwoPointBlock.PlaceEnum.Rigid)
		{
			twoPointBlock.ParentBlockBodyView.ShouldIncludeChildrenInAllHighlights = true;
		}
		CreateMeshFilterAndColliders();
	}

	protected override void InternalResetMesh()
	{
		RemoveExtraMeshesColliders();
	}
}
