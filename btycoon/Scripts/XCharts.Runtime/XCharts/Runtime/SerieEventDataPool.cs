using UnityEngine;

namespace XCharts.Runtime
{
	public static class SerieEventDataPool
	{
		private static readonly ObjectPool<SerieEventData> s_ListPool = new ObjectPool<SerieEventData>(null, OnClear);

		private static void OnGet(SerieEventData data)
		{
		}

		private static void OnClear(SerieEventData data)
		{
			data.Reset();
		}

		public static SerieEventData Get(Vector3 pos, int serieIndex, int dataIndex, int dimension, double value)
		{
			SerieEventData serieEventData = s_ListPool.Get();
			serieEventData.serieIndex = serieIndex;
			serieEventData.dataIndex = dataIndex;
			serieEventData.pointerPos = pos;
			serieEventData.dimension = dimension;
			return serieEventData;
		}

		public static void Release(SerieEventData toRelease)
		{
			s_ListPool.Release(toRelease);
		}
	}
}
