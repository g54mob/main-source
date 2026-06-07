using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Kamgam.UIToolkitComponentsForSettings
{
	public class UIElementEvents : UIElementClickEvent
	{
		[Header("Events")]
		public UnityEvent<PointerDownEvent> OnPointerDown;

		public UnityEvent<PointerUpEvent> OnPointerUp;

		public UnityEvent<PointerEnterEvent> OnPointerEnter;

		public UnityEvent<PointerLeaveEvent> OnPointerLeave;

		public UnityEvent<FocusEvent> OnFocus;

		public UnityEvent<BlurEvent> OnBlur;

		public UnityEvent<KeyDownEvent> OnKeyDown;

		public UnityEvent<KeyUpEvent> OnKeyUp;

		public UnityEvent<ChangeEvent<bool>> OnChangeBool;

		public UnityEvent<ChangeEvent<int>> OnChangeInt;

		public UnityEvent<ChangeEvent<float>> OnChangeFloat;

		public UnityEvent<ChangeEvent<string>> OnChangeString;

		public override void RegisterEvents()
		{
			if (Elements.Count == 0)
			{
				return;
			}
			foreach (VisualElement element in Elements)
			{
				if (OnPointerDown != null)
				{
					element.RegisterCallback<PointerDownEvent>(onPointerDown);
				}
				if (OnPointerUp != null)
				{
					element.RegisterCallback<PointerUpEvent>(onPointerUp);
				}
				if (OnPointerEnter != null)
				{
					element.RegisterCallback<PointerEnterEvent>(onPointerEnter);
				}
				if (OnPointerLeave != null)
				{
					element.RegisterCallback<PointerLeaveEvent>(onPointerLeave);
				}
				if (OnFocus != null)
				{
					element.RegisterCallback<FocusEvent>(onFocus);
				}
				if (OnBlur != null)
				{
					element.RegisterCallback<BlurEvent>(onBlur);
				}
				if (OnKeyDown != null)
				{
					element.RegisterCallback<KeyDownEvent>(onKeyDown);
				}
				if (OnKeyUp != null)
				{
					element.RegisterCallback<KeyUpEvent>(onKeyUp);
				}
				if (OnChangeBool != null)
				{
					element.RegisterCallback<ChangeEvent<bool>>(onChangeBool);
				}
				if (OnChangeInt != null)
				{
					element.RegisterCallback<ChangeEvent<int>>(onChangeInt);
				}
				if (OnChangeFloat != null)
				{
					element.RegisterCallback<ChangeEvent<float>>(onChangeFloat);
				}
				if (OnChangeString != null)
				{
					element.RegisterCallback<ChangeEvent<string>>(onChangeString);
				}
			}
			base.RegisterEvents();
		}

		public override void UnregisterEvents()
		{
			if (Elements.Count == 0)
			{
				return;
			}
			foreach (VisualElement element in Elements)
			{
				if (OnPointerDown != null)
				{
					element.UnregisterCallback<PointerDownEvent>(onPointerDown);
				}
				if (OnPointerUp != null)
				{
					element.UnregisterCallback<PointerUpEvent>(onPointerUp);
				}
				if (OnPointerEnter != null)
				{
					element.UnregisterCallback<PointerEnterEvent>(onPointerEnter);
				}
				if (OnPointerLeave != null)
				{
					element.UnregisterCallback<PointerLeaveEvent>(onPointerLeave);
				}
				if (OnFocus != null)
				{
					element.UnregisterCallback<FocusEvent>(onFocus);
				}
				if (OnBlur != null)
				{
					element.UnregisterCallback<BlurEvent>(onBlur);
				}
				if (OnKeyDown != null)
				{
					element.UnregisterCallback<KeyDownEvent>(onKeyDown);
				}
				if (OnKeyUp != null)
				{
					element.UnregisterCallback<KeyUpEvent>(onKeyUp);
				}
				if (OnChangeBool != null)
				{
					element.UnregisterCallback<ChangeEvent<bool>>(onChangeBool);
				}
				if (OnChangeInt != null)
				{
					element.UnregisterCallback<ChangeEvent<int>>(onChangeInt);
				}
				if (OnChangeFloat != null)
				{
					element.UnregisterCallback<ChangeEvent<float>>(onChangeFloat);
				}
				if (OnChangeString != null)
				{
					element.UnregisterCallback<ChangeEvent<string>>(onChangeString);
				}
			}
			base.UnregisterEvents();
		}

		protected virtual void onPointerDown(PointerDownEvent evt)
		{
			OnPointerDown?.Invoke(evt);
		}

		protected virtual void onPointerUp(PointerUpEvent evt)
		{
			OnPointerUp?.Invoke(evt);
		}

		protected virtual void onPointerEnter(PointerEnterEvent evt)
		{
			OnPointerEnter?.Invoke(evt);
		}

		protected virtual void onPointerLeave(PointerLeaveEvent evt)
		{
			OnPointerLeave?.Invoke(evt);
		}

		protected virtual void onFocus(FocusEvent evt)
		{
			OnFocus?.Invoke(evt);
		}

		protected virtual void onBlur(BlurEvent evt)
		{
			OnBlur?.Invoke(evt);
		}

		protected virtual void onKeyDown(KeyDownEvent evt)
		{
			OnKeyDown?.Invoke(evt);
		}

		protected virtual void onKeyUp(KeyUpEvent evt)
		{
			OnKeyUp?.Invoke(evt);
		}

		protected virtual void onChangeBool(ChangeEvent<bool> evt)
		{
			OnChangeBool?.Invoke(evt);
		}

		protected virtual void onChangeInt(ChangeEvent<int> evt)
		{
			OnChangeInt?.Invoke(evt);
		}

		protected virtual void onChangeFloat(ChangeEvent<float> evt)
		{
			OnChangeFloat?.Invoke(evt);
		}

		protected virtual void onChangeString(ChangeEvent<string> evt)
		{
			OnChangeString?.Invoke(evt);
		}
	}
}
