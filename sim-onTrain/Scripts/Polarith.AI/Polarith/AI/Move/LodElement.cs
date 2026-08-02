namespace Polarith.AI.Move
{
	public struct LodElement
	{
		public AIMSensor Sensor;

		public float Distance;

		public LodElement(AIMSensor sensor, float distance)
		{
			Sensor = sensor;
			Distance = distance;
		}
	}
}
