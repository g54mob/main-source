using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VideoKit.UI
{
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	public sealed class VideoKitRecordButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[Header("Settings")]
		[Range(5f, 60f)]
		[Tooltip("Maximum duration that button can be pressed.")]
		public float maxDuration = 10f;

		[Header("UI")]
		[Tooltip("Countdown image.")]
		public Image countdown;

		[Header("Events")]
		[Tooltip("Event invoked when the button is tapped.")]
		public UnityEvent OnTap;

		[Tooltip("Event invoked when the button starts being held.")]
		[FormerlySerializedAs("OnStartRecording")]
		public UnityEvent OnBeginHold;

		[Tooltip("Event invoked when the button stops being held.")]
		[FormerlySerializedAs("OnStopRecording")]
		public UnityEvent OnEndHold;

		private Image button;

		private bool touch;

		private const float TapDelay = 0.2f;

		private void Awake()
		{
			button = GetComponent<Image>();
		}

		private void Start()
		{
			Zero();
		}

		private void Zero()
		{
			button.fillAmount = 1f;
			countdown.fillAmount = 0f;
		}

		private IEnumerator Countdown()
		{
			touch = true;
			yield return new WaitForSeconds(0.2f);
			if (!touch)
			{
				OnTap?.Invoke();
				yield break;
			}
			OnBeginHold?.Invoke();
			float startTime = Time.time;
			while (touch)
			{
				float num = (Time.time - startTime) / maxDuration;
				touch = num <= 1f;
				countdown.fillAmount = num;
				button.fillAmount = 1f - num;
				yield return null;
			}
			Zero();
			OnEndHold?.Invoke();
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			StartCoroutine(Countdown());
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			touch = false;
		}
	}
}
