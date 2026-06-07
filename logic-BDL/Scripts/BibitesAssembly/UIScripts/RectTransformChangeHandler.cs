using UnityEngine;
using UnityEngine.Events;

namespace UIScripts
{
	public class RectTransformChangeHandler : MonoBehaviour
	{
		public UnityEvent onRectTransformChange = new UnityEvent();

		private void OnRectTransformDimensionsChange()
		{
			onRectTransformChange.Invoke();
		}
	}
}
