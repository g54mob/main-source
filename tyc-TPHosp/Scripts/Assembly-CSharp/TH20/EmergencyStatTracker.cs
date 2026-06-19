using System.Collections.Generic;

namespace TH20
{
	public class EmergencyStatTracker
	{
		private int _initialPatientCount;

		private int _sceneDeaths;

		private bool _isRescue;

		private bool _didRespond;

		private AmbulanceDepartmentStatsContainer _statsContainer;

		private List<Patient> _patients;

		private bool _isActive;

		public int InitialPatientCount => _initialPatientCount;

		public bool IsRescue => _isRescue;

		public AmbulanceDepartmentStatsContainer StatsContainer => _statsContainer;

		public int SceneDeaths
		{
			get
			{
				return _sceneDeaths;
			}
			set
			{
				_sceneDeaths = value;
			}
		}

		public bool DidRespond
		{
			get
			{
				return _didRespond;
			}
			set
			{
				_didRespond = value;
			}
		}

		public List<Patient> Patients => _patients;

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
			}
		}

		public EmergencyStatTracker(int initialPatientCount, bool isRescue)
		{
			_initialPatientCount = initialPatientCount;
			_isRescue = isRescue;
			_sceneDeaths = 0;
			_didRespond = false;
			_statsContainer = new AmbulanceDepartmentStatsContainer();
			_patients = new List<Patient>();
			_isActive = true;
		}
	}
}
