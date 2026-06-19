using UnityEngine;

namespace PugWorldGen
{
	internal struct AreaRequest
	{
		public byte channel;

		public int index;

		public Vector2 position;

		public Vector2 size;

		public Vector2Int dataSize;

		public RenderTexture rt;

		public OutputType outputType;
	}
}
