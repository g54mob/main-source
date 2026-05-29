using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FinancialGraph : MonoSingleton<FinancialGraph>
	{
		[SerializeField]
		[Space(10f)]
		private UI_Graph _graph;

		public static event Action OnGraphRefresh;

		public static event Action OnGraphLoaded;

		public void UpdateGraph(float[] data)
		{
			_graph.AddDataToGraph(new GraphPerMounthData
			{
				datas = data
			});
		}

		public GraphSaveStruct SaveGraph()
		{
			return _graph.SaveData();
		}

		public void LoadGraph(GraphSaveStruct data)
		{
			if (data.dataPerMounth != null)
			{
				_graph.LoadData(data, MonoSingleton<FinancialMoneyStats>.Instance.ToDataGraph());
				FinancialGraph.OnGraphRefresh?.Invoke();
			}
		}

		protected override void SingletonAwake()
		{
			_graph.OnGraphLoaded += Graph_OnGraphLoaded;
		}

		private void Graph_OnGraphLoaded()
		{
			FinancialGraph.OnGraphLoaded?.Invoke();
		}

		protected override void OnSingletonDestroy()
		{
			_graph.OnGraphLoaded -= FinancialGraph.OnGraphLoaded;
		}
	}
}
