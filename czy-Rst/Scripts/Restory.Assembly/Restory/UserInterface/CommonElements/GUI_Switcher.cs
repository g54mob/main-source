using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public sealed class GUI_Switcher : UIBehaviour, IMoveHandler, IEventSystemHandler
	{
		[Serializable]
		public class SwitcherEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private ToggleGroup group;

		[SerializeField]
		private GUI_Interactable interactable;

		[SerializeField]
		private List<Toggle> options = new List<Toggle>();

		[SerializeField]
		private SwitcherEvent onValueChanged = new SwitcherEvent();

		private int value;

		public int Value
		{
			get
			{
				return value;
			}
			set
			{
				Set(value);
			}
		}

		public event UnityAction<int> OnValueChanged
		{
			add
			{
				onValueChanged.AddListener(value);
			}
			remove
			{
				onValueChanged.RemoveListener(value);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			for (int i = 0; i < options.Count; i++)
			{
				options[i].group = group;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			for (int i = 0; i < options.Count; i++)
			{
				int index = i;
				options[i].SetIsOnWithoutNotify(i == value);
				options[i].onValueChanged.AddListener(delegate(bool isOn)
				{
					if (isOn)
					{
						ToggleOnValueChangedHandler(index);
					}
				});
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			for (int i = 0; i < options.Count; i++)
			{
				options[i].onValueChanged.RemoveAllListeners();
			}
		}

		public bool IsInteractable()
		{
			return interactable.IsInteractable();
		}

		public void SetValueWithoutNotify(int value)
		{
			Set(value, sendCallback: false);
		}

		private void Set(int value, bool sendCallback = true)
		{
			if (this.value != value)
			{
				this.value = Mathf.Clamp(value, 0, options.Count - 1);
				if (this.value < options.Count)
				{
					options[this.value].SetIsOnWithoutNotify(value: true);
				}
				if (sendCallback)
				{
					onValueChanged.Invoke(this.value);
				}
			}
		}

		private void ToggleOnValueChangedHandler(int value)
		{
			this.value = value;
			onValueChanged.Invoke(value);
		}

		public void OnMove(AxisEventData eventData)
		{
			if (IsActive() && IsInteractable())
			{
				switch (eventData.moveDir)
				{
				case MoveDirection.Left:
					Set(value - 1);
					break;
				case MoveDirection.Right:
					Set(value + 1);
					break;
				}
			}
		}
	}
}
