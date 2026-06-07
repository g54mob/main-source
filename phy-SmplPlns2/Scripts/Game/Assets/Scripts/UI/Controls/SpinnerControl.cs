using System;
using System.Collections.Generic;
using Jundroo.Common.Collections;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class SpinnerControl : SpinnerControl<string>
	{
		public SpinnerControl(Widget widget)
			: base(widget, (Func<string, string>)((string x) => x), (IEqualityComparer<string>)EqualityComparer<string>.Default, "next-button", "prev-button")
		{
		}
	}
	public class SpinnerControl<T> : WidgetControl
	{
		private TextWidget _labelText;

		private T _value;

		private CircularList<T> _values;

		public string LabelText
		{
			get
			{
				return _labelText.Text;
			}
			set
			{
				_labelText.Text = value;
			}
		}

		public ButtonWidget NextButton { get; }

		public Func<T, string> OnLabelRequested { get; set; }

		public OnValueChanged<T> OnValueChanged { get; set; }

		public OnValueChanging<T> OnValueChanging { get; set; }

		public ButtonWidget PrevButton { get; }

		public TextWidget Text { get; }

		public T Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				if (Text != null)
				{
					Text.Text = OnLabelRequested(value);
				}
			}
		}

		public CircularList<T> Values => _values;

		public SpinnerControl(Widget widget, string nextButtonId = "next-button", string prevButtonId = "prev-button")
			: this(widget, (Func<T, string>)null, (IEqualityComparer<T>)null, nextButtonId, prevButtonId)
		{
		}

		public SpinnerControl(Widget widget, Func<T, string> onLabelRequested, IEqualityComparer<T> equalityComparer, string nextButtonId = "next-button", string prevButtonId = "prev-button")
			: base(widget)
		{
			if (onLabelRequested == null)
			{
				onLabelRequested = (T x) => x?.ToString();
			}
			if (equalityComparer == null)
			{
				equalityComparer = EqualityComparer<T>.Default;
			}
			_values = new CircularList<T>(equalityComparer);
			OnLabelRequested = onLabelRequested;
			NextButton = widget.FindWidget<ButtonWidget>(nextButtonId);
			NextButton.Clicked += delegate(Widget b)
			{
				OnButtonClicked((b.PointerEventData.pointerId != -2) ? 1 : (-1));
			};
			PrevButton = ((prevButtonId == null) ? null : widget.FindWidget<ButtonWidget>(prevButtonId));
			if (PrevButton != null)
			{
				PrevButton.Clicked += delegate
				{
					OnButtonClicked(-1);
				};
			}
			_labelText = widget.FindWidget<TextWidget>("label-text");
			Text = widget.FindWidget<TextWidget>("value-text");
			Text.Text = OnLabelRequested(Value);
		}

		protected virtual void OnDestroy()
		{
			OnLabelRequested = null;
			OnValueChanged = null;
		}

		private void OnButtonClicked(int direction)
		{
			if (Values.Count > 0)
			{
				T value = Value;
				T val = ((direction > 0) ? _values.NextValue(value) : _values.PreviousValue(value));
				OnValueChanging?.Invoke(value, val);
				Value = val;
				OnValueChanged?.Invoke(value, val);
			}
		}
	}
}
