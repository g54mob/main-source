using UnityEngine;

namespace CTS
{
	public readonly struct TrailTarget
	{
		public Transform Target { get; }

		public TrailTarget(Transform target)
		{
			Target = target;
		}
	}
}
