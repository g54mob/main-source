namespace MeshXtensions
{
	public struct Triangle
	{
		public int v1;

		public int v2;

		public int v3;

		public Triangle(int v1, int v2, int v3)
		{
			this.v1 = v1;
			this.v2 = v2;
			this.v3 = v3;
		}

		public static int[] ToIntArray(Triangle[] triangles)
		{
			int[] array = new int[triangles.Length * 3];
			for (int i = 0; i < triangles.Length; i++)
			{
				array[i * 3] = triangles[i].v1;
				array[i * 3 + 1] = triangles[i].v2;
				array[i * 3 + 2] = triangles[i].v3;
			}
			return array;
		}
	}
}
