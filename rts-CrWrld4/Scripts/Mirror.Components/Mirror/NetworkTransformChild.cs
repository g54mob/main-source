using UnityEngine;

namespace Mirror
{
	public class NetworkTransformChild : NetworkTransformBase
	{
		public Transform target;

		protected override Transform targetComponent => null;

		private void MirrorProcessed()
		{
		}
	}
}
