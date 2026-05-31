using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class VisibilityScript : MonoBehaviour
	{
		private bool _readyToRemove;

		private bool _neverBeenVisible;

		public void Reset()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnBecameInvisible()
		{
		}

		public bool IsNotInView()
		{
			return false;
		}
	}
}
