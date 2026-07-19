using UnityEngine;

namespace Subdiv
{
	public class Kernel
	{
		private int index;

		private uint threadX;

		private uint threadY;

		private uint threadZ;

		public int Index => index;

		public uint ThreadX => threadX;

		public uint ThreadY => threadY;

		public uint ThreadZ => threadZ;

		public Kernel(ComputeShader shader, string key)
		{
			index = shader.FindKernel(key);
			if (index < 0)
			{
				Debug.LogWarning("Can't find kernel");
			}
			else
			{
				shader.GetKernelThreadGroupSizes(index, out threadX, out threadY, out threadZ);
			}
		}
	}
}
