using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class AmbulanceDepartmentStatsContainer
	{
		public int PatientsCollected;

		public int PatientsCured;

		public int PatientsDied;

		public int PatientsCureFailed;

		public List<int> DepartmentReputation;

		private float _totalPatientsProcessed;

		public AmbulanceDepartmentStatsContainer()
		{
			ResetStats();
		}

		public AmbulanceDepartmentStatsContainer(int patientsCollected, int patientsCured, int patientsDied, int patientsCureFailed, List<int> departmentReputation)
		{
			PatientsCollected = patientsCollected;
			PatientsCured = patientsCured;
			PatientsDied = patientsDied;
			PatientsCureFailed = patientsCureFailed;
			DepartmentReputation = departmentReputation;
		}

		public AmbulanceDepartmentStatsContainer(AmbulanceDepartmentStatsContainer copy)
		{
			PatientsCollected = copy.PatientsCollected;
			PatientsCured = copy.PatientsCured;
			PatientsDied = copy.PatientsDied;
			PatientsCureFailed = copy.PatientsCureFailed;
			DepartmentReputation = copy.DepartmentReputation;
		}

		public void IncrementStats(AmbulanceDepartmentStatsContainer additionalStats)
		{
			PatientsCollected += additionalStats.PatientsCollected;
			PatientsCured += additionalStats.PatientsCured;
			PatientsDied += additionalStats.PatientsDied;
			PatientsCureFailed += additionalStats.PatientsCureFailed;
			if (additionalStats.DepartmentReputation != null)
			{
				DepartmentReputation.AddRange(additionalStats.DepartmentReputation);
			}
		}

		public void ResetStats()
		{
			PatientsCollected = 0;
			PatientsCured = 0;
			PatientsDied = 0;
			PatientsCureFailed = 0;
			DepartmentReputation = new List<int>();
		}

		public int GetStat(AmbulanceDepartmentStats.AmbulanceDepartmentStat statType)
		{
			_totalPatientsProcessed = PatientsCured + PatientsDied + PatientsCureFailed;
			switch (statType)
			{
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCollected:
				return PatientsCollected;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCured:
				if (_totalPatientsProcessed != 0f)
				{
					return (int)((float)PatientsCured / _totalPatientsProcessed * 100f);
				}
				return 0;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsDied:
				if (_totalPatientsProcessed != 0f)
				{
					return (int)((float)PatientsDied / _totalPatientsProcessed * 100f);
				}
				return 0;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCureFailed:
				if (_totalPatientsProcessed != 0f)
				{
					return (int)((float)PatientsCureFailed / _totalPatientsProcessed * 100f);
				}
				return 0;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.DepartmentReputation:
			{
				float num = DepartmentReputation.Sum();
				if (DepartmentReputation.Count > 0)
				{
					num /= (float)DepartmentReputation.Count;
					return (int)num;
				}
				return 0;
			}
			default:
				return 0;
			}
		}

		public void IncrementStat(AmbulanceDepartmentStats.AmbulanceDepartmentStat statType, int value = 1)
		{
			switch (statType)
			{
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCollected:
				PatientsCollected += value;
				break;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCured:
				PatientsCured += value;
				break;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsDied:
				PatientsDied += value;
				break;
			case AmbulanceDepartmentStats.AmbulanceDepartmentStat.PatientsCureFailed:
				PatientsCureFailed += value;
				break;
			}
		}
	}
}
