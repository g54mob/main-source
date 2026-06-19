using UnityEngine;

namespace Utilities
{
	public class AutoTimedDestroy : MonoBehaviour
	{
		[SerializeField]
		private float _destroyIn;

		private void Start()
		{
			Object.Destroy(base.gameObject, _destroyIn);
		}
	}
}
