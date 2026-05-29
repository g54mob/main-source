using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	public abstract class AHeightArrayBlockModelProvider : MonoBehaviour, IBlockModelProvider
	{
		private const int CMaxHeight = 25;

		protected abstract int[,] MapHeight { get; }

		public virtual Color Color => Color.white;

		public BlockModel GenerateBlockModel()
		{
			int length = MapHeight.GetLength(0);
			int num = 25;
			int length2 = MapHeight.GetLength(1);
			BlockModel blockModel = new BlockModel(new Block[MapHeight.GetLength(0) * 25 * MapHeight.GetLength(1)], new Vector3(length, num, length2));
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					for (int k = 0; k < num; k++)
					{
						if (k < MapHeight[i, j])
						{
							blockModel.SetBlock(i, Mathf.Min(k, 25), j, Color);
						}
					}
				}
			}
			return blockModel;
		}
	}
}
