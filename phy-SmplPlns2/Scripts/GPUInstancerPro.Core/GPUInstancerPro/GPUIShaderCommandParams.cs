using UnityEngine;

namespace GPUInstancerPro
{
	public struct GPUIShaderCommandParams
	{
		public int key;

		public Matrix4x4 transformOffset;

		public int instanceDataBufferShiftMultiplier;
	}
}
