using UnityEngine;
using UnityEngine.Rendering;

namespace PugWorldGen
{
	internal struct PointCompletionRequest
	{
		public int index;

		public ComputeBuffer buffer;

		public int count;

		public AsyncGPUReadbackRequest gpuReadback;
	}
}
