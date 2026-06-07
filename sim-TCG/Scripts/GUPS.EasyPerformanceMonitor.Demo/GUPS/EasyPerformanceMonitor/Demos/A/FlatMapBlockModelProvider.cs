using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.A
{
	public class FlatMapBlockModelProvider : AHeightArrayBlockModelProvider
	{
		private int[,] mapHeight;

		protected override int[,] MapHeight
		{
			get
			{
				if (mapHeight == null)
				{
					mapHeight = GenerateMapHeight();
				}
				return mapHeight;
			}
		}

		public override Color Color => new Color(0.15f, 0.15f, 0.15f);

		private int[,] GenerateMapHeight()
		{
			int num = 75;
			int num2 = 75;
			int[,] array = new int[num, num2];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[i, j] = 1;
					int num3 = 5;
					if (i > 0 && array[i - 1, j] == 2)
					{
						num3 += 10;
					}
					if (j > 0 && array[i, j - 1] == 2)
					{
						num3 += 10;
					}
					if (i < num - 1 && array[i + 1, j] == 2)
					{
						num3 += 10;
					}
					if (j < num2 - 1 && array[i, j + 1] == 2)
					{
						num3 += 10;
					}
					if (Random.Range(0, 100) < num3)
					{
						array[i, j] = 2;
					}
				}
			}
			return array;
		}
	}
}
