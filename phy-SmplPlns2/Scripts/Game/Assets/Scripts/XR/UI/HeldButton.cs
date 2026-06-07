using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class HeldButton : Button
	{
		private bool _pressedCurrent;

		[SerializeField]
		private UnityEvent onEndPress = new UnityEvent();

		[SerializeField]
		private UnityEvent onStartPress = new UnityEvent();

		public UnityEvent OnEndPress
		{
			get
			{
				return onEndPress;
			}
			private set
			{
				onEndPress = value;
			}
		}

		public UnityEvent OnStartPress
		{
			get
			{
				return onStartPress;
			}
			private set
			{
				onStartPress = value;
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			PotentialStateChange();
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			PotentialStateChange();
		}

		public void PotentialStateChange()
		{
			if (_pressedCurrent != IsPressed())
			{
				if (_pressedCurrent)
				{
					onEndPress.Invoke();
					_pressedCurrent = false;
				}
				else
				{
					onStartPress.Invoke();
					_pressedCurrent = true;
				}
			}
		}

		protected override void InstantClearState()
		{
			base.InstantClearState();
			PotentialStateChange();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			PotentialStateChange();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			PotentialStateChange();
		}
	}
}
