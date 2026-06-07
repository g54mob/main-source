using System;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Jundroo.Juicy.Widgets.Extra;
using TMPro;

namespace Assets.Scripts.Design.UI.Variables
{
	public class VariableRowScript : WidgetScript
	{
		private InputWidget _activatorInput;

		private VariableSettersDialogScript _dialog;

		private InputWidget _expressionInput;

		private InputWidget _nameInput;

		private InputWidget _priorityInput;

		public string Activator
		{
			get
			{
				return _activatorInput.Text;
			}
			set
			{
				_activatorInput.Text = value;
			}
		}

		public string Expression
		{
			get
			{
				return _expressionInput.Text;
			}
			set
			{
				_expressionInput.Text = value;
			}
		}

		public bool IsOpen
		{
			get
			{
				return base.Widget.HasClass("row-open");
			}
			set
			{
				base.Widget.EnableClass("row-open", value);
				_dialog.UpdateLayout().Forget();
			}
		}

		public string Name
		{
			get
			{
				return _nameInput.Text;
			}
			set
			{
				_nameInput.Text = value;
			}
		}

		public int Priority
		{
			get
			{
				if (int.TryParse(_priorityInput.Text, out var result))
				{
					return result;
				}
				return 0;
			}
			set
			{
				_priorityInput.Text = value.ToString();
			}
		}

		public string PriorityText
		{
			get
			{
				return _priorityInput.Text;
			}
			set
			{
				_priorityInput.Text = value;
			}
		}

		public void Initialize(VariableSettersDialogScript dialog)
		{
			_dialog = dialog;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_nameInput = widget.FindWidget<InputWidget>("input-name");
			_activatorInput = widget.FindWidget<InputWidget>("input-activator");
			_expressionInput = widget.FindWidget<InputWidget>("input-expression");
			_priorityInput = widget.FindWidget<InputWidget>("input-priority");
			DraggableInputField input = _nameInput.Input;
			input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(input.onValidateInput, new TMP_InputField.OnValidateInput(ValidateInput));
		}

		private void OnDeleteClicked(Widget widget)
		{
			_dialog.DeleteRow(this);
		}

		private void OnMoreClicked(Widget widget)
		{
			IsOpen = !IsOpen;
		}

		private void OnMoveDownClicked(Widget widget)
		{
			_dialog.MoveRow(this, up: false);
		}

		private void OnMoveUpClicked(Widget widget)
		{
			_dialog.MoveRow(this, up: true);
		}

		private char ValidateInput(string text, int index, char added)
		{
			if ((char.IsDigit(added) && index == 0) || (added != '_' && !char.IsLetterOrDigit(added)))
			{
				return '\0';
			}
			return added;
		}
	}
}
