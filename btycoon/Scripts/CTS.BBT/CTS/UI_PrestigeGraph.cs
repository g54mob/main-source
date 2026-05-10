using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_PrestigeGraph : MonoSingleton<UI_PrestigeGraph>
	{
		[SerializeField]
		private UI_Graph _graph;

		public static event Action OnGraphLoaded;

		protected override void SingletonAwake()
		{
		}

		private void Start()
		{
			Prestige.PrestigeChanged += PrestigeChanged;
		}

		protected override void OnSingletonDestroy()
		{
			Prestige.PrestigeChanged -= PrestigeChanged;
		}

		private void PrestigeChanged(PrestigeLevelData arg1, float arg2)
		{
			_graph.AddDataToGraph(new GraphPerMounthData
			{
				datas = ToDataGraph()
			});
		}

		private float[] ToDataGraph()
		{
			return new float[3]
			{
				MonoSingleton<Prestige>.Instance.TotalRewardValue,
				MonoSingleton<Prestige>.Instance.TotalReviewsValue,
				MonoSingleton<Prestige>.Instance.TotalBarPrestige
			};
		}

		public void Clear()
		{
			_graph.Clear();
		}

		public GraphSaveStruct SaveData()
		{
			return _graph.SaveData();
		}

		public void LoadData(GraphSaveStruct data)
		{
			if (data.dataPerMounth != null)
			{
				_graph.LoadData(data, ToDataGraph());
			}
		}

		public SavePrestigeGraphData SaveDataConvertion()
		{
			return SavePrestigeGraphData.ConvertFromGraphSaveStruct(_graph.SaveData());
		}

		public void LoadDataConvertion(SavePrestigeGraphData data)
		{
			if (data.prestigePerMounth != null)
			{
				_graph.LoadData(SavePrestigeGraphData.ConvertToGraphSaveStruct(data), ToDataGraph());
			}
		}
	}
}
