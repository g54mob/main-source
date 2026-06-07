using Data.Shapes;

namespace Data.Notifications
{
	public class ModuleNotificationData : AbstractNotificationData
	{
		public ShapeData ShapeData;

		public ModuleNotificationData(ShapeData shapeData)
		{
			ShapeData = shapeData;
		}
	}
}
