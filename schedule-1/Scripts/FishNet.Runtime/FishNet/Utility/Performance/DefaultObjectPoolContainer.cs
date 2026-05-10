using UnityEngine;

namespace FishNet.Utility.Performance
{
	internal class DefaultObjectPoolContainer : MonoBehaviour
	{
		private DefaultObjectPool _pool;

		private void OnDestroy()
		{
		}

		public void Initialize(DefaultObjectPool dop)
		{
		}
	}
}
