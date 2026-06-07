using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class DeltaVAdjustorButtonScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public delegate void ButtonDownDelegate(float input);

		public float CurrentInput { get; private set; }

		public float CurrentInputTime { get; private set; }

		public bool IsPointerDown { get; private set; }

		public float TimeToFullInput { get; set; } = 2f;

		public event ButtonDownDelegate ButtonDown;

		public void OnPointerDown(PointerEventData eventData)
		{
			IsPointerDown = true;
			OnPointerDown();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			IsPointerDown = false;
			CurrentInput = 0f;
			CurrentInputTime = 0f;
		}

		protected virtual void Update()
		{
			if (IsPointerDown)
			{
				OnPointerDown();
			}
		}

		private void OnPointerDown()
		{
			CurrentInputTime += Time.unscaledDeltaTime;
			CurrentInput = Mathf.Clamp01(CurrentInputTime / TimeToFullInput);
			this.ButtonDown?.Invoke(CurrentInput);
		}
	}
}
