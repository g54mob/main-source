using NSEipix.Base;

namespace NSMedieval.Tools.Regions
{
	public class RegionDetection : Singleton<RegionDetection>
	{
		private RegionDetection()
		{
		}

		public Vec3Int[][] ComputeLargestConnectedGrid(Vec3Int[][] input)
		{
			int num = int.MinValue;
			int num2 = input.Length;
			int num3 = input[0].Length;
			Vec3Int[][] initializedJaggedArray = GetInitializedJaggedArray(num2, num3);
			Vec3Int[][] initializedJaggedArray2 = GetInitializedJaggedArray(num2, num3);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num3; j++)
				{
					ResetVisited(initializedJaggedArray2);
					int count = 0;
					if (j + 1 < num3)
					{
						Bfs(input[i][j], input[i][j + 1], i, j, input, initializedJaggedArray2, ref count);
					}
					if (count >= num)
					{
						num = count;
						ResetResult(input, initializedJaggedArray, initializedJaggedArray2);
					}
					ResetVisited(initializedJaggedArray2);
					count = 0;
					if (i + 1 < num2)
					{
						Bfs(input[i][j], input[i + 1][j], i, j, input, initializedJaggedArray2, ref count);
					}
					if (count >= num)
					{
						num = count;
						ResetResult(input, initializedJaggedArray, initializedJaggedArray2);
					}
				}
			}
			return initializedJaggedArray;
		}

		private void Bfs(Vec3Int x, Vec3Int y, int i, int j, Vec3Int[][] input, Vec3Int[][] visited, ref int count)
		{
			if (x == Vec3Int.zero || y == Vec3Int.zero)
			{
				return;
			}
			visited[i][j] = input[i][j];
			count++;
			int[] array = new int[4] { 0, 0, 1, -1 };
			int[] array2 = new int[4] { 1, -1, 0, 0 };
			for (int k = 0; k < 4; k++)
			{
				if (Valid(i + array2[k], j + array[k], input, visited))
				{
					Bfs(x, y, i + array2[k], j + array[k], input, visited, ref count);
				}
			}
		}

		private bool Valid(int x, int y, Vec3Int[][] input, Vec3Int[][] visited)
		{
			if (x >= input.Length || y >= input[0].Length || x < 0 || y < 0)
			{
				return false;
			}
			if (visited[x][y] == Vec3Int.zero)
			{
				return input[x][y] != Vec3Int.zero;
			}
			return false;
		}

		private void ResetVisited(Vec3Int[][] input)
		{
			int num = input.Length;
			int num2 = input[0].Length;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					input[i][j] = Vec3Int.zero;
				}
			}
		}

		private void ResetResult(Vec3Int[][] input, Vec3Int[][] result, Vec3Int[][] visited)
		{
			int num = input.Length;
			int num2 = input[0].Length;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (visited[i][j] != Vec3Int.zero && input[i][j] != Vec3Int.zero)
					{
						result[i][j] = visited[i][j];
					}
					else
					{
						result[i][j] = Vec3Int.zero;
					}
				}
			}
		}

		private Vec3Int[][] GetInitializedJaggedArray(int size1, int size2)
		{
			Vec3Int[][] array = new Vec3Int[size1][];
			for (int i = 0; i < size1; i++)
			{
				array[i] = new Vec3Int[size2];
			}
			return array;
		}
	}
}
