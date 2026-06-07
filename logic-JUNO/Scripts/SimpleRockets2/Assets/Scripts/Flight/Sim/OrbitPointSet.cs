using System.Collections.Generic;
using System.Reflection;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public class OrbitPointSet : IOrbitPointSet
	{
		private double _period;

		private List<IOrbitPoint> _points = new List<IOrbitPoint>();

		public bool Closed { get; set; }

		public int Count => _points.Count;

		public bool IntersectsPlanet { get; set; }

		public double Period => _period;

		public void AddPoint(IOrbitPoint orbitPoint)
		{
			_points.Add(orbitPoint);
		}

		public IOrbitPoint GetPoint(int index)
		{
			return _points[index];
		}

		public void Initialize(double period)
		{
			IntersectsPlanet = false;
			_period = period;
			_points.Clear();
		}

		public IOrbitPoint Last(int indexFromEnd = 0)
		{
			return _points[_points.Count - indexFromEnd - 1];
		}
	}
}
