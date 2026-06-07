using UnityEngine;

namespace Mirror.Experimental
{
	[DisallowMultipleComponent]
	public class NetworkTransform : NetworkTransformBase
	{
		protected override Transform targetTransform => null;

		private void MirrorProcessed()
		{
		}
	}
}
