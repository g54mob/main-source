using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class NetworkTransform : NetworkTransformBase
	{
		protected override Transform targetComponent => null;

		private void MirrorProcessed()
		{
		}
	}
}
