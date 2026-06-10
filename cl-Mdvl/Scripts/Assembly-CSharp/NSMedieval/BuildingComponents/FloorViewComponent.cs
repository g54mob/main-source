namespace NSMedieval.BuildingComponents
{
	public class FloorViewComponent : BasicBuildingBlockViewComponent
	{
		protected override void OnDisposedInternal()
		{
			base.OnDisposedInternal();
			base.BaseBuildingViewComponent.SetUnplaceableMaterial();
			base.BaseBuildingViewComponent.OnAfterDisposedInternalEvent();
		}
	}
}
