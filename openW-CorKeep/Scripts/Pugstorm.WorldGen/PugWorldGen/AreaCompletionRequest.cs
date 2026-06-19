using UnityEngine;
using UnityEngine.Rendering;

namespace PugWorldGen
{
	internal struct AreaCompletionRequest
	{
		public byte channel;

		public int index;

		public Vector2 position;

		public Vector2 size;

		public Vector2Int dataSize;

		public RenderTexture rt;

		public AsyncGPUReadbackRequest gpuReadback;
	}
}
