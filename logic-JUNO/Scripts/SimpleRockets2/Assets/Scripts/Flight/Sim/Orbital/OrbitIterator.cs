using Assets.Scripts.Flight.Sim.Orbital.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital
{
	public class OrbitIterator : IOrbitIterator
	{
		private double _currentEa;

		private bool _done;

		private double _eccentricity;

		private double _endEa;

		private bool _enforceConsistentStepBases = true;

		private double _nextEaStep;

		private IOrbit _orbit;

		private double _startEa;

		public bool EnforceConsistentStepBase
		{
			get
			{
				return _enforceConsistentStepBases;
			}
			set
			{
				_enforceConsistentStepBases = value;
			}
		}

		public double NextEaStep
		{
			get
			{
				return _nextEaStep;
			}
			set
			{
				_nextEaStep = value;
			}
		}

		public IOrbitPoint GetAt(double eccentricAnomaly)
		{
			return OrbitMath.GetPointAtEccentricAnomaly(_orbit, eccentricAnomaly);
		}

		public void Prepare(IOrbit orbit, double startEa, double endEa, double eaStep)
		{
			_eccentricity = orbit.Eccentricity;
			_startEa = startEa;
			_currentEa = double.NaN;
			_endEa = endEa;
			_orbit = orbit;
			_done = false;
			_nextEaStep = eaStep;
			_enforceConsistentStepBases = true;
		}

		public bool TryGetNext(out IOrbitPoint point)
		{
			double startEa = _startEa;
			double endEa = _endEa;
			double nextEaStep = _nextEaStep;
			bool flag = true;
			if (!_done)
			{
				if (double.IsNaN(_currentEa))
				{
					_currentEa = startEa;
				}
				else if (_currentEa == startEa)
				{
					if (_enforceConsistentStepBases)
					{
						_currentEa = (double)(long)((_currentEa - 0.0) / nextEaStep + 1.0) * nextEaStep + 0.0;
					}
					else
					{
						_currentEa += nextEaStep;
					}
				}
				else
				{
					_currentEa += _nextEaStep;
				}
				if (_currentEa >= endEa)
				{
					_done = true;
					if (Orbit.Equality.CompareOrbitalAngles(startEa, endEa, _eccentricity))
					{
						flag = false;
					}
					else
					{
						_currentEa = endEa;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				point = OrbitMath.GetPointAtEccentricAnomaly(_orbit, _currentEa);
			}
			else
			{
				point = null;
			}
			return flag;
		}
	}
}
