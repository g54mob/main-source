using Helpers.Extensions;

namespace Mandragora.Utils
{
	public static class MatrixUtils
	{
		public static bool[,] PrepareBuildMaskMatrix(bool[,] mask)
		{
			bool[,] array = new bool[mask.GetLength(0), mask.GetLength(1)];
			int length = mask.GetLength(1);
			for (int i = 0; i < mask.GetLength(0); i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, length - j - 1] = mask[i, j];
				}
			}
			return array.RotateMatrix(270f);
		}
	}
}
