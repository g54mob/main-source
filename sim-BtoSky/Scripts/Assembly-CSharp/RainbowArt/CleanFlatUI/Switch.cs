using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class Switch : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[Serializable]
		public class SwitchEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private bool isOn;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private SwitchEvent onValueChanged = new SwitchEvent();

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
					UpdateGUI(isInit: false);
				}
			}
		}

		public SwitchEvent OnValueChanged
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

		private void Start()
		{
			UpdateGUI(isInit: true);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isOn = !isOn;
			UpdateGUI(isInit: false);
		}

		private void UpdateGUI(bool isInit)
		{
			if (isInit)
			{
				if (isOn)
				{
					animator.Play("On Init", 0, 0f);
				}
				else
				{
					animator.Play("Off Init", 0, 0f);
				}
			}
			else if (isOn)
			{
				animator.Play("On", 0, 0f);
				onValueChanged.Invoke(arg0: true);
			}
			else
			{
				animator.Play("Off", 0, 0f);
				onValueChanged.Invoke(arg0: false);
			}
		}
	}
}
