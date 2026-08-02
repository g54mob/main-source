using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Auto Destroy")]
	public class AutoDestroy : MonoBehaviour
	{
		public float SecondsToDestroy;

		public bool DestroyOnStart = true;

		private void Start()
		{
			if (DestroyOnStart)
			{
				TimedDestroyObject();
			}
		}

		public void TimedDestroyObject()
		{
			Object.Destroy(base.gameObject, SecondsToDestroy);
		}
	}
}
