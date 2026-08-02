using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JUTPS.CrossPlataform
{
	[AddComponentMenu("JU TPS/Mobile/Button")]
	public class ButtonVirtual : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public bool IsPressed;

		public bool IsPressedVisual;

		public bool IsPressedDown;

		public bool IsPressedUp;

		private void OnDisable()
		{
			IsPressed = false;
			IsPressedDown = false;
			IsPressedUp = false;
			IsPressedVisual = false;
		}

		public void OnPointerDown(PointerEventData e)
		{
			IsPressed = true;
			IsPressedVisual = true;
			IsPressedUp = false;
			IsPressedDown = true;
			StartCoroutine(DisableIsPressedDownAtEndOfFrame());
		}

		public void OnPointerUp(PointerEventData e)
		{
			IsPressed = false;
			IsPressedVisual = false;
			IsPressedDown = false;
			IsPressedUp = true;
			StartCoroutine(DisableIsPressedUpAtEndOfFrame());
		}

		private IEnumerator DisableIsPressedDownAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			IsPressedDown = false;
		}

		private IEnumerator DisableIsPressedUpAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			IsPressedUp = false;
		}
	}
}
