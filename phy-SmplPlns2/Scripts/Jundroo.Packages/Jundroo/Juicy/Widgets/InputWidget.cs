using System.Text.RegularExpressions;
using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class InputWidget : ImageWidget, ISelectableWidget
	{
		public delegate bool ValidationFunctionDelegate(string input, out string validationErrorMessage);

		[SerializeField]
		private Image _background;

		private RectOffset _padding;

		[SerializeField]
		private TextMeshProUGUI _placeholder;

		[SerializeField]
		private TextMeshProUGUI _text;

		private string _validationErrorMessage;

		public Image Background => _background;

		public ColorProperty BackgroundColor { get; private set; }

		public bool EnableSubLayout
		{
			get
			{
				return Input.ChildLayout.enabled;
			}
			set
			{
				Input.ChildLayout.enabled = value;
			}
		}

		public DraggableInputField Input { get; private set; }

		public override bool Interactable
		{
			get
			{
				return base.Interactable;
			}
			set
			{
				base.Interactable = value;
				Selectable.interactable = value;
			}
		}

		public RectOffset Padding
		{
			get
			{
				return _padding;
			}
			set
			{
				_padding = value;
				RectTransform component = Input.ChildLayout.GetComponent<RectTransform>();
				component.offsetMin = new Vector2(_padding.left, _padding.bottom);
				component.offsetMax = new Vector2(-_padding.right, -_padding.top);
			}
		}

		public TextMeshProUGUI Placeholder => _placeholder;

		public ColorProperty PlaceholderColor { get; private set; }

		public Selectable Selectable => Input;

		public string Text
		{
			get
			{
				return Input.text;
			}
			set
			{
				Input.text = value;
			}
		}

		public ColorProperty TextColor { get; private set; }

		public TextMeshProUGUI TextMeshPro => _text;

		public string ValidationErrorMessage => _validationErrorMessage;

		public ValidationFunctionDelegate ValidationFunction { get; set; }

		public string ValidationRegex { get; set; }

		protected override AttributeSet AttributeSet => InputAttributes.Set;

		public event InputWidgetDelegate Validated;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			Input = GetComponent<DraggableInputField>();
			TextColor = new ColorProperty(TextMeshPro.color, delegate(Color x)
			{
				TextMeshPro.color = x;
			});
			PlaceholderColor = new ColorProperty(Placeholder.color, delegate(Color x)
			{
				Placeholder.color = x;
			});
			BackgroundColor = new ColorProperty(Background.color, delegate(Color x)
			{
				Background.color = x;
			});
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			if (base.HasError)
			{
				Validate();
			}
		}

		public void Validate()
		{
			base.HasError = !(ValidationFunction?.Invoke(Text, out _validationErrorMessage) ?? true);
			if (!string.IsNullOrEmpty(ValidationRegex))
			{
				base.HasError |= !Regex.IsMatch(Text, ValidationRegex);
			}
			this.Validated?.Invoke(this);
		}

		protected override void Start()
		{
			base.Start();
			GetComponentInChildren<TMP_SelectionCaret>().raycastTarget = false;
		}
	}
}
