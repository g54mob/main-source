using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class TextInputElementScript : ExpressionElementScript
	{
		private bool _disable;

		private bool _enableEditing;

		private ConstantExpression _expression;

		private TMP_InputField _input;

		public override bool AllowEditing
		{
			get
			{
				return base.AllowEditing;
			}
			set
			{
				base.AllowEditing = value;
			}
		}

		public bool EnableEditing
		{
			get
			{
				return _enableEditing;
			}
			set
			{
				_enableEditing = value;
				_input.interactable = value;
			}
		}

		public string Text
		{
			get
			{
				return _input.text;
			}
			set
			{
				_input.text = value;
			}
		}

		public NodeFormat.Token Token { get; set; }

		public override void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			base.Initialize(vizzyUI, node, style);
			base.DragBehavior = DragBehaviorType.Disabled;
			_expression = node as ConstantExpression;
		}

		public override Vector2 LayoutElement()
		{
			Vector2 blockSize = new Vector2(_input.preferredWidth + (float)base.Padding.left + (float)base.Padding.right, base.RectTransform.sizeDelta.y + (float)base.Padding.top + (float)base.Padding.bottom);
			base.Size = SetBlockSize(blockSize);
			return base.Size;
		}

		protected override void Awake()
		{
			base.Awake();
			_input = GetComponent<TMP_InputField>();
			_input.interactable = false;
			_input.characterLimit = 500;
		}

		protected override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if ((eventData.position - eventData.pressPosition).magnitude < 25f && AllowEditing)
			{
				EnableEditing = true;
				_input.Select();
			}
		}

		protected override void Start()
		{
			_input.text = _expression.ExpressionResult.TextValue;
			_input.onValueChanged.AddListener(OnValueChanged);
			_input.onEndEdit.AddListener(OnEndEdit);
			_input.onSelect.AddListener(OnSelected);
			_input.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true).color = base.Style.TextColor;
		}

		protected override void Update()
		{
			base.Update();
			if (_disable)
			{
				_disable = false;
				EnableEditing = false;
			}
		}

		private void OnEndEdit(string s)
		{
			base.VizzyUI.CreateUndoStep(base.Node.GetHashCode().ToString());
			if (Token?.Validation != null)
			{
				ValidateInput(Token.Validation, s);
			}
			_disable = true;
			if (base.Parent != null)
			{
				NodeStyle style = base.Parent.Style;
				if (style != null && style.HasDynamicExpressionsSlots)
				{
					base.VizzyUI.NodeBuilder.RebuildChildren(base.ExpressionSlot.Parent);
				}
			}
		}

		private void OnSelected(string s)
		{
			if (base.Error != null)
			{
				base.VizzyUI.ShowValidationError(base.Error);
			}
		}

		private void OnValueChanged(string s)
		{
			OnChildSizeChanged();
			_expression.ExpressionResult.TextValue = s;
		}

		private void ValidateInput(string validation, string s)
		{
			double? num = null;
			double result = 0.0;
			if (double.TryParse(s, out result))
			{
				num = result;
			}
			string text = null;
			switch (validation)
			{
			case "Number":
				if (!num.HasValue)
				{
					text = "Input must be a number.";
				}
				break;
			case "ZeroOrMore":
				if (!num.HasValue || num.Value < 0.0)
				{
					text = "Input must a number equal to or greater than zero.";
				}
				break;
			case "OneOrMore":
				if (!num.HasValue || num.Value < 1.0)
				{
					text = "Input must a number equal to or greater than one.";
				}
				break;
			case "NegOneToPosOne":
				if (!num.HasValue || num.Value < -1.0 || num.Value > 1.0)
				{
					text = "Input must a number between -1 and 1.";
				}
				break;
			case "ZeroToOne":
				if (!num.HasValue || num.Value < 0.0 || num.Value > 1.0)
				{
					text = "Input must a number between 0 and 1.";
				}
				break;
			}
			if (base.Error != text)
			{
				base.Error = text;
				if (base.Error == null)
				{
					base.VizzyUI.ShowValidationError(string.Empty);
				}
				UpdateColor();
			}
			if (text != null)
			{
				string message = $"Input '{s}' is invalid. {text}";
				base.VizzyUI.ShowValidationError(message);
			}
		}
	}
}
