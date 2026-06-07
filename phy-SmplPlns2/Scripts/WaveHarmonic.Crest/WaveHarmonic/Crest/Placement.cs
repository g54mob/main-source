using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum Placement
	{
		[Tooltip("The component is in a fixed position.")]
		Fixed = 0,
		[Tooltip("The component follows the transform.")]
		Transform = 1,
		[Tooltip("The component follows the viewpoint.")]
		Viewpoint = 2
	}
}
