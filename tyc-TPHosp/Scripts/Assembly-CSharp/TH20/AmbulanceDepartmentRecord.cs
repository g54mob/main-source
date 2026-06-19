using System.Collections.Generic;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class AmbulanceDepartmentRecord
	{
		private AmbulanceDepartment _department;

		private PanelItemGraph _itemGraph;

		private double _monthlyCurrentStanding;

		private double _yearlyCurrentStanding;

		private List<LineGraph.DataVector2> _cachedMonthlyData;

		private List<LineGraph.DataVector2> _cachedYearlyData;

		public AmbulanceDepartment Department => _department;

		public double MonthlyCurrentStanding => _monthlyCurrentStanding;

		public double YearlyCurrentStanding => _yearlyCurrentStanding;

		public List<LineGraph.DataVector2> CachedMonthlyData => _cachedMonthlyData;

		public List<LineGraph.DataVector2> CachedYearlyData => _cachedYearlyData;

		public AmbulanceDepartmentRecord(AmbulanceDepartment department, PanelItemGraph graph, Color teamColour)
		{
			_department = department;
			_monthlyCurrentStanding = 0.0;
			_yearlyCurrentStanding = 0.0;
			_cachedMonthlyData = new List<LineGraph.DataVector2>();
			_cachedYearlyData = new List<LineGraph.DataVector2>();
			_itemGraph = graph;
			if (_itemGraph != null)
			{
				if (department is RivalAmbulanceDepartment rivalAmbulanceDepartment)
				{
					_itemGraph.Setup(rivalAmbulanceDepartment.Config.RivalFoundationDefinition.Instance.FoundationName, teamColour);
				}
				else
				{
					_itemGraph.Setup(department.FoundationName, teamColour);
				}
			}
		}

		public void CacheMonthlyData(List<LineGraph.DataVector2> data)
		{
			if (data != null && data.Count != 0)
			{
				_cachedMonthlyData.Clear();
				for (int i = 0; i < data.Count; i++)
				{
					_cachedMonthlyData.Add(new LineGraph.DataVector2(i, data[i].y));
				}
				_monthlyCurrentStanding = data[data.Count - 1].y;
			}
		}

		public void CacheYearlyData(List<LineGraph.DataVector2> data)
		{
			if (data != null && data.Count != 0)
			{
				_cachedYearlyData.Clear();
				for (int i = 0; i < data.Count; i++)
				{
					_cachedYearlyData.Add(new LineGraph.DataVector2(i, data[i].y));
				}
				_yearlyCurrentStanding = data[data.Count - 1].y;
			}
		}

		public void AssignCachedDataToGraph()
		{
			if (_itemGraph != null)
			{
				_itemGraph.AssignMonthlyData(_cachedMonthlyData);
				_itemGraph.AssignYearlyData(_cachedYearlyData);
			}
		}
	}
}
