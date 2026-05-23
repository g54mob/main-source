using Data.FactoryFloor.Resources;
using Data.Shapes;
using Data.Variables.Resources;

namespace Events.UI
{
	public class ResourceInfoPanelDto : InfoPanelDto
	{
		public NonShapeResourceDataSO ResourceData;

		public ShapeData ShapeData;

		public bool HideOrigin;

		public ResourceAmountInfo ResourceAmountInfo;

		public bool IsShapeData;

		public ResourceInfoPanelDto(NonShapeResourceDataSO resourceData, bool hideOrigin, ResourceAmountInfo resourceAmountInfo = null)
		{
			IsShapeData = false;
			ResourceData = resourceData;
			HideOrigin = hideOrigin;
			ResourceAmountInfo = resourceAmountInfo;
		}

		public ResourceInfoPanelDto(ShapeData shapeData, bool hideOrigin, ResourceAmountInfo resourceAmountInfo = null)
		{
			IsShapeData = true;
			ShapeData = shapeData;
			HideOrigin = hideOrigin;
			ResourceAmountInfo = resourceAmountInfo;
		}
	}
}
