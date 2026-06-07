using UnityEngine;

namespace QFSW.MOP2
{
	[DisallowMultipleComponent]
	public class AutoPool : PoolableMonoBehaviour
	{
		[Tooltip("The duration of time to wait before releasing the object to the pool.")]
		[SerializeField]
		private float _poolTimer;

		[Tooltip("Whether to use scaled or unscaled time.")]
		[SerializeField]
		private bool _scaledTime;

		private float _elapsedTime;

		protected override void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
