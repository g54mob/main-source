namespace GRP
{
	public interface IGear
	{
		GearType gearType { get; }

		SimShape gearShape { get; }

		GearController gearController { get; }

		GearModule gearModule { get; }
	}
}
