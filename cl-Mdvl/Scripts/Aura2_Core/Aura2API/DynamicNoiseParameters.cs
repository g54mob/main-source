using System;

namespace Aura2API
{
	[Serializable]
	public struct DynamicNoiseParameters
	{
		public bool enable;

		public float speed;

		public TransformParameters transform;
	}
}
