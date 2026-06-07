using System;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class ColorButtonControl : WidgetControl
	{
		public class ColorChangedEventArgs : EventArgs
		{
			public Color32 Color { get; set; }
		}

		private TextWidget _labelText;

		public bool AllowTransparency { get; set; }

		public ButtonWidget Button { get; private set; }

		public Color32 Color
		{
			get
			{
				return Button.Color.Base;
			}
			set
			{
				Button.Color.Base = value;
			}
		}

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

		public event EventHandler<ColorChangedEventArgs> ColorChanged;

		public ColorButtonControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			Button = widget.FindWidget<ButtonWidget>("button");
			Button.Clicked += OnButtonClicked;
		}

		private void OnButtonClicked(Widget widget)
		{
			ColorPickerDialogScript colorPickerDialogScript = Game.Instance.UserInterface.CreateColorPickerDialog();
			Color32 color = Color;
			colorPickerDialogScript.Color = color;
			colorPickerDialogScript.AllowTransparency = AllowTransparency;
			colorPickerDialogScript.ColorChanged += delegate(ColorPickerDialogScript d)
			{
				Color = d.Color;
				this.ColorChanged?.Invoke(this, new ColorChangedEventArgs
				{
					Color = d.Color
				});
			};
		}
	}
}
