using System;

namespace CTS
{
	[Serializable]
	public struct GraphPerMounthData
	{
		public float[] datas;

		public float Total
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < datas.Length; i++)
				{
					num += datas[i];
				}
				return num;
			}
		}

		public GraphPerMounthData Copy()
		{
			float[] array = new float[datas.Length];
			for (int i = 0; i < datas.Length; i++)
			{
				array[i] = datas[i];
			}
			return new GraphPerMounthData
			{
				datas = array
			};
		}
	}
}
