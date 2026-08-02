using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Timer Destroy")]
	public sealed class TimerDestroy : MonoBehaviour
	{
		[Tooltip("If this timer runs out, the gameObject is destroyed. Counted from start, in seconds.")]
		public float Timer = 5f;

		private void Start()
		{
			Object.Destroy(base.gameObject, Timer);
		}
	}
}
