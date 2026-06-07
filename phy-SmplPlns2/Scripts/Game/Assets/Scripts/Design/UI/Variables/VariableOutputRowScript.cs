using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Jundroo.Juicy.Widgets.Extra;
using TMPro;

namespace Assets.Scripts.Design.UI.Variables
{
	public class VariableOutputRowScript : WidgetScript
	{
		private InputWidget _activatorInput;

		private VariableOutputsDialogScript _dialog;

		private InputWidget _nameInput;

		private TextWidget _outputIdLabel;

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

		public VariableOutputDefinition Definition { get; set; }

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

		public PartModifierData Modifier { get; set; }

		public string OutputId
		{
			get
			{
				return _outputIdLabel.Text;
			}
			set
			{
				_outputIdLabel.Text = value;
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

		public string Variable
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

		public void Initialize(VariableOutputsDialogScript dialog)
		{
			_dialog = dialog;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_nameInput = widget.FindWidget<InputWidget>("input-name");
			_activatorInput = widget.FindWidget<InputWidget>("input-activator");
			_priorityInput = widget.FindWidget<InputWidget>("input-priority");
			_outputIdLabel = widget.FindWidget<TextWidget>("output-id");
			DraggableInputField input = _nameInput.Input;
			input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(input.onValidateInput, new TMP_InputField.OnValidateInput(ValidateInput));
		}

		protected virtual void OnEnable()
		{
			IsOpen = false;
		}

		protected virtual void Start()
		{
			DraggableInputField input = _nameInput.Input;
			input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(input.onValidateInput, new TMP_InputField.OnValidateInput(ValidateInput));
		}

		private void OnMoreClicked(Widget widget)
		{
			IsOpen = !IsOpen;
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
