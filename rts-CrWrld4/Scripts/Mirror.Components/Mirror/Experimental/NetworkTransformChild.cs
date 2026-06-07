using UnityEngine;

namespace Mirror.Experimental
{
	public class NetworkTransformChild : NetworkTransformBase
	{
		public Transform target;

		protected override Transform targetTransform => null;

		private void MirrorProcessed()
		{
		}
	}
}
