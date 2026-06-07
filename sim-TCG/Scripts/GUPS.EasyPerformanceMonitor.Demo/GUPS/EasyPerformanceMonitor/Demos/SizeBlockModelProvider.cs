using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	public class SizeBlockModelProvider : MonoBehaviour, IBlockModelProvider
	{
		public Vector3 Size;

		public Color Color;

		public BlockModel GenerateBlockModel()
		{
			BlockModel blockModel = new BlockModel(new Block[(int)(Size.x * Size.y * Size.z)], new Vector3(Size.x, Size.y, Size.z));
			for (int i = 0; (float)i < Size.x; i++)
			{
				for (int j = 0; (float)j < Size.z; j++)
				{
					for (int k = 0; (float)k < Size.y; k++)
					{
						blockModel.SetBlock(i, k, j, Color);
					}
				}
			}
			return blockModel;
		}
	}
}
