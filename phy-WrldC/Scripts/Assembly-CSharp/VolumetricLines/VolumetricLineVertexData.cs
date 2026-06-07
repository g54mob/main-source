using UnityEngine;

namespace VolumetricLines
{
	public static class VolumetricLineVertexData
	{
		public static readonly Vector2[] TexCoords = new Vector2[8]
		{
			new Vector2(1f, 1f),
			new Vector2(1f, 0f),
			new Vector2(0.5f, 1f),
			new Vector2(0.5f, 0f),
			new Vector2(0.5f, 0f),
			new Vector2(0.5f, 1f),
			new Vector2(0f, 0f),
			new Vector2(0f, 1f)
		};

		public static readonly Vector2[] VertexOffsets = new Vector2[8]
		{
			new Vector2(1f, 1f),
			new Vector2(1f, -1f),
			new Vector2(0f, 1f),
			new Vector2(0f, -1f),
			new Vector2(0f, 1f),
			new Vector2(0f, -1f),
			new Vector2(1f, 1f),
			new Vector2(1f, -1f)
		};

		public static readonly int[] Indices = new int[18]
		{
			2, 1, 0, 3, 1, 2, 4, 3, 2, 5,
			4, 2, 4, 5, 6, 6, 5, 7
		};
	}
}
