using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[ExecuteAlways]
	public class BindHeightFilterRangeToTransform : MonoBehaviour
	{
		public enum BindTarget
		{
			Minimum = 0,
			Maximum = 1
		}

		public enum ValueMode
		{
			Absolute = 0,
			Relative = 1
		}

		public Stamp target;

		public float offset;

		public BindTarget bindTarget;

		public ValueMode valueMode;
	}
}
