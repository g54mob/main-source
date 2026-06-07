using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class SwitchSimple : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[Serializable]
		public class SwitchSimpleEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private bool isOn;

		[SerializeField]
		private RectTransform backgroundOn;

		[SerializeField]
		private RectTransform backgroundOff;

		[SerializeField]
		private RectTransform handleOn;

		[SerializeField]
		private RectTransform handleOff;

		[SerializeField]
		private RectTransform handleSlideArea;

		[SerializeField]
		private SwitchSimpleEvent onValueChanged = new SwitchSimpleEvent();

		private CanvasGroup canvasGroupBGOn;

		private CanvasGroup canvasGroupBGOff;

		private CanvasGroup canvasGroupOn;

		private CanvasGroup canvasGroupOff;

		public bool IsOn
		{
			get
			{
				return isOn;
			}
			set
			{
				if (isOn != value)
				{
					isOn = value;
					UpdateGUI();
				}
			}
		}

		public SwitchSimpleEvent OnValueChanged
		{
			get
			{
				return onValueChanged;
			}
			set
			{
				onValueChanged = value;
			}
		}

		private IEnumerator Start()
		{
			InitGUI();
			yield return null;
			UpdateGUI();
		}

		private void InitGUI()
		{
			canvasGroupBGOn = backgroundOn.gameObject.GetComponent<CanvasGroup>();
			canvasGroupBGOff = backgroundOff.gameObject.GetComponent<CanvasGroup>();
			canvasGroupOn = handleOn.gameObject.GetComponent<CanvasGroup>();
			canvasGroupOff = handleOff.gameObject.GetComponent<CanvasGroup>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isOn = !isOn;
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			float width = handleSlideArea.rect.width;
			handleOn.anchoredPosition3D = new Vector3(width, 0f, 0f);
			handleOff.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			if (isOn)
			{
				SetCanvasGroupAlpha(canvasGroupBGOn, 1f);
				SetCanvasGroupAlpha(canvasGroupBGOff, 0f);
				SetCanvasGroupAlpha(canvasGroupOn, 1f);
				SetCanvasGroupAlpha(canvasGroupOff, 0f);
				onValueChanged.Invoke(arg0: true);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupBGOn, 0f);
				SetCanvasGroupAlpha(canvasGroupBGOff, 1f);
				SetCanvasGroupAlpha(canvasGroupOn, 0f);
				SetCanvasGroupAlpha(canvasGroupOff, 1f);
				onValueChanged.Invoke(arg0: false);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
