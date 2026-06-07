using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIObjectDestroyer : MonoBehaviour
	{
		public float timeToDestroy = 5f;

		private float _enabledTime;

		private void OnEnable()
		{
			_enabledTime = Time.time;
		}

		private void Update()
		{
			if (Time.time - _enabledTime > timeToDestroy)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
