using UnityEngine;

namespace GamingIsLove.Footsteps
{
	public abstract class FootstepSource : MonoBehaviour
	{
		public abstract FootstepEffect GetFootstepAt(Vector3 position, string effectTag);
	}
}
