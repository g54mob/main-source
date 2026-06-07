namespace ModApi.Flight.Sim
{
	public interface IOrbitPointSet
	{
		bool Closed { get; set; }

		int Count { get; }

		bool IntersectsPlanet { get; set; }

		void AddPoint(IOrbitPoint orbitPoint);

		IOrbitPoint GetPoint(int index);

		void Initialize(double period);

		IOrbitPoint Last(int indexFromEnd = 0);
	}
}
