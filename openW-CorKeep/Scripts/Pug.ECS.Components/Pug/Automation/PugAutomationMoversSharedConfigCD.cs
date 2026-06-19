using Unity.Entities;

namespace Pug.Automation
{
	public struct PugAutomationMoversSharedConfigCD : IComponentData, IQueryTypeParameter
	{
		public BlobAssetReference<PugAutomationMoversSharedConfigData> SharedConfig;

		public BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> DefaultMovers;

		public BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> MoveAndPlanters;

		public BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> HarvestAndMovers;
	}
}
