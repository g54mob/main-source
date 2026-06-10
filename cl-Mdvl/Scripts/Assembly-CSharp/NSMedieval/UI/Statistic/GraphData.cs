using System;
using System.Collections.Generic;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	[Serializable]
	[FVSerializableKey("GraphData", "")]
	public class GraphData : IFVSerializable
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private StatisticGraphType graphType;

		[SerializeField]
		private Color graphColor;

		[SerializeField]
		private List<float> nodeValues;

		public List<float> NodeValues
		{
			get
			{
				List<float> obj = nodeValues ?? new List<float>();
				List<float> result = obj;
				nodeValues = obj;
				return result;
			}
		}

		public string ID => id;

		public StatisticGraphType GraphType => graphType;

		public Color GraphColor => graphColor;

		public GraphData(string id, StatisticGraphType graphType, Color graphColor)
		{
			this.id = id;
			this.graphType = graphType;
			this.graphColor = graphColor;
		}

		public GraphData()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("graphType", graphType.ToString());
			serializer.Write("graphColor", graphColor);
			serializer.Write("nodeValues", nodeValues);
		}

		public GraphData(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			graphType = Enum.Parse<StatisticGraphType>(deserializer.ReadString("graphType"));
			graphColor = deserializer.ReadColor("graphColor");
			nodeValues = deserializer.ReadFloatList("nodeValues");
		}
	}
}
