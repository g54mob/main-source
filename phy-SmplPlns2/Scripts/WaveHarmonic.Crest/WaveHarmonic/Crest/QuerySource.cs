using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum QuerySource
	{
		[Tooltip("This game object's transform.")]
		Transform = 0,
		[Tooltip("The viewer's transform.\n\nThe viewer is the main camera the system uses.")]
		Viewer = 1
	}
}
