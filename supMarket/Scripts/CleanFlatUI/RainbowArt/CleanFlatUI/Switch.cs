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
		private SwitchEvent onValueChanged;

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SwitchEvent OnValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		private void UpdateGUI(bool isInit)
		{
		}
	}
}
