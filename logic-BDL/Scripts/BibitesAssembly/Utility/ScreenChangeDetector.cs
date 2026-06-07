using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
	public class ScreenChangeDetector : MonoBehaviour
	{
		public static UnityEvent onScreenDimensionChange = new UnityEvent();

		public static void Reload()
		{
			onScreenDimensionChange.Invoke();
		}

		private void OnRectTransformDimensionsChange()
		{
			onScreenDimensionChange.Invoke();
		}

		private void OnDestroy()
		{
			onScreenDimensionChange.RemoveAllListeners();
		}
	}
}
