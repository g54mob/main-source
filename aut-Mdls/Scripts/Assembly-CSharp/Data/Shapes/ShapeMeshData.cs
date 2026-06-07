using UnityEngine;

namespace Data.Shapes
{
	public static class ShapeMeshData
	{
		public static Vector3[] CUBE_VERTICES = new Vector3[24]
		{
			new Vector3(1f, -1f, 1f) * 0.05f,
			new Vector3(-1f, -1f, 1f) * 0.05f,
			new Vector3(1f, 1f, 1f) * 0.05f,
			new Vector3(-1f, 1f, 1f) * 0.05f,
			new Vector3(1f, 1f, -1f) * 0.05f,
			new Vector3(-1f, 1f, -1f) * 0.05f,
			new Vector3(1f, -1f, -1f) * 0.05f,
			new Vector3(-1f, -1f, -1f) * 0.05f,
			new Vector3(1f, 1f, 1f) * 0.05f,
			new Vector3(-1f, 1f, 1f) * 0.05f,
			new Vector3(1f, 1f, -1f) * 0.05f,
			new Vector3(-1f, 1f, -1f) * 0.05f,
			new Vector3(1f, -1f, -1f) * 0.05f,
			new Vector3(1f, -1f, 1f) * 0.05f,
			new Vector3(-1f, -1f, 1f) * 0.05f,
			new Vector3(-1f, -1f, -1f) * 0.05f,
			new Vector3(-1f, -1f, 1f) * 0.05f,
			new Vector3(-1f, 1f, 1f) * 0.05f,
			new Vector3(-1f, 1f, -1f) * 0.05f,
			new Vector3(-1f, -1f, -1f) * 0.05f,
			new Vector3(1f, -1f, -1f) * 0.05f,
			new Vector3(1f, 1f, -1f) * 0.05f,
			new Vector3(1f, 1f, 1f) * 0.05f,
			new Vector3(1f, -1f, 1f) * 0.05f
		};

		public static int[] CUBE_TRIANGLES = new int[36]
		{
			0, 2, 3, 0, 3, 1, 4, 6, 7, 4,
			7, 5, 8, 10, 11, 8, 11, 9, 12, 13,
			14, 12, 14, 15, 16, 17, 18, 16, 18, 19,
			20, 21, 22, 20, 22, 23
		};

		public static int[] CUBE_TRIANGLES_FWD = new int[6] { 0, 2, 3, 0, 3, 1 };

		public static int[] CUBE_TRIANGLES_BACK = new int[6] { 4, 6, 7, 4, 7, 5 };

		public static int[] CUBE_TRIANGLES_UP = new int[6] { 8, 10, 11, 8, 11, 9 };

		public static int[] CUBE_TRIANGLES_DOWN = new int[6] { 12, 13, 14, 12, 14, 15 };

		public static int[] CUBE_TRIANGLES_LEFT = new int[6] { 16, 17, 18, 16, 18, 19 };

		public static int[] CUBE_TRIANGLES_RIGHT = new int[6] { 20, 21, 22, 20, 22, 23 };

		public static Vector2[] CUBE_UVS = new Vector2[24]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f)
		};

		public static Vector3[] CUBE_NORMALS = new Vector3[24]
		{
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(1f, 0f, 0f)
		};
	}
}
