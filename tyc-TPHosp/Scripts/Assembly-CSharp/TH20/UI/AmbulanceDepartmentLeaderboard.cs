using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	public class AmbulanceDepartmentLeaderboard : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text[] _leaderboardTexts;

		private List<AmbulanceDepartmentRecord> _orderedDepartments;

		public void RefreshLeaderboard(List<AmbulanceDepartmentRecord> competingDepartments, AmbulanceDepartmentStats.AmbulanceDepartmentStat statToShow, bool monthly)
		{
			if (competingDepartments == null || competingDepartments.Count < _leaderboardTexts.Length)
			{
				return;
			}
			if (monthly)
			{
				_orderedDepartments = competingDepartments.OrderByDescending((AmbulanceDepartmentRecord x) => x.Department.Stats.GetMonthlyLeaguePosition(statToShow)).ToList();
			}
			else
			{
				_orderedDepartments = competingDepartments.OrderByDescending((AmbulanceDepartmentRecord x) => x.Department.Stats.GetYearlyLeaguePosition(statToShow)).ToList();
			}
			for (int num = 0; num < _orderedDepartments.Count; num++)
			{
				if (num < _leaderboardTexts.Length)
				{
					_leaderboardTexts[_leaderboardTexts.Length - 1 - num].text = _orderedDepartments[num].Department.FoundationName;
				}
			}
		}
	}
}
