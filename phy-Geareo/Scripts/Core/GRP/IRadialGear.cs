namespace GRP
{
	public interface IRadialGear : IGear
	{
		int gearTeeth { get; }

		int gearSkip { get; }

		float gearRadius { get; }
	}
}
