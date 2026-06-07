using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class ButtonWidget : ImageWidget, ISelectableWidget
	{
		public Button Button { get; private set; }

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

		public Selectable Selectable => Button;

		protected override AttributeSet AttributeSet => ButtonAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			Button = GetComponent<Button>();
		}
	}
}
