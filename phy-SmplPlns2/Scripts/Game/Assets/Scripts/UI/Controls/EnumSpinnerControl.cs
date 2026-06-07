using System;
using Jundroo.Common.Attributes;
using Jundroo.Common.Collections;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class EnumSpinnerControl<T> : WidgetControl where T : struct, Enum
	{
		private T _value;

		private CircularList<T> _values = new CircularList<T>();

		public TextWidget LabelText { get; }

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
				RefreshLabel();
			}
		}

		public CircularList<T> Values => _values;

		public EnumSpinnerControl(Widget widget, string nextButtonId = "next-button", string prevButtonId = "prev-button")
			: base(widget)
		{
			OnLabelRequested = (T x) => x.DisplayName();
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
			foreach (T value in EnumUtility<T>.Values)
			{
				UiVisibility uiVisibility = EnumUtility<T>.GetAttribute<UiVisibilityAttribute>(value)?.Visibility ?? UiVisibility.Visible;
				if (uiVisibility == UiVisibility.Visible || (uiVisibility == UiVisibility.DebugOnly && Device.IsDebugBuild))
				{
					_values.Add(value);
				}
			}
			LabelText = widget.FindWidget<TextWidget>("label-text");
			Text = widget.FindWidget<TextWidget>("value-text");
			RefreshLabel();
		}

		public void RefreshLabel()
		{
			if (Text != null)
			{
				Text.Text = OnLabelRequested(_value);
			}
		}

		protected virtual void OnDestroy()
		{
			OnLabelRequested = null;
			OnValueChanged = null;
		}

		private void OnButtonClicked(int direction)
		{
			if (_values.Count > 0)
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
