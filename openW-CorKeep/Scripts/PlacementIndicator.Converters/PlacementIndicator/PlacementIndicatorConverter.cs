using Pug.Conversion;
using Unity.Entities;

namespace PlacementIndicator
{
	public class PlacementIndicatorConverter : SingleAuthoringComponentConverter<PlacementIndicatorAuthoring>
	{
		protected override void Convert(PlacementIndicatorAuthoring authoring)
		{
			BlobAssetReference<BlobCurve> blobAsset = BlobCurve.Create(authoring.axisToSpeed);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			AddComponentData(new PlacementIndicatorCD
			{
				joystickAxisToSpeed = blobAsset
			});
			EnsureHasComponent<PlacementIndicatorInterpolatedValueCD>();
			EnsureHasComponent<PlacementIndicatorInterpolatedStateCD>();
			EnsureHasComponent<PlacementIndicatorCurrentStateCD>();
		}
	}
}
