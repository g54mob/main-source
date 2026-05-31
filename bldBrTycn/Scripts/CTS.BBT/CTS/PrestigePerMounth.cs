using System;

namespace CTS
{
	[Serializable]
	public struct PrestigePerMounth
	{
		public float bar;

		public float review;

		public float others;

		public float Total => bar + review + others;

		public GraphPerMounthData ConvertToGraphPerMounthData()
		{
			return new GraphPerMounthData
			{
				datas = new float[3] { others, review, bar }
			};
		}

		public static PrestigePerMounth ConvertFromGraphPerMounthData(GraphPerMounthData data)
		{
			return new PrestigePerMounth
			{
				others = data.datas[0],
				review = data.datas[1],
				bar = data.datas[2]
			};
		}
	}
}
