using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/Controllers/GUI/GuiMouseTemplate", fileName = "New GuiMouseTemplate")]
	public sealed class GuiMouseTemplate : GuiControllerTemplate, IGuiMouseTemplate, IGuiControllerTemplate
	{
		private static class Style
		{
			public const string Movement = "Movement";

			public const string Wheel = "Wheel";

			public const string Buttons = "Buttons";
		}

		[SerializeField]
		private ControllerId controllerId;

		[SerializeField]
		private GuiControllerTemplateAxisElement horizontal = new GuiControllerTemplateAxisElement("Mouse Horizontal");

		[SerializeField]
		private GuiControllerTemplateAxisElement vertical = new GuiControllerTemplateAxisElement("Mouse Vertical");

		[SerializeField]
		private GuiControllerTemplateWheelElement wheel = new GuiControllerTemplateWheelElement("Mouse Wheel", new GuiControllerTemplateAxisElement("Mouse Wheel Vertical"), new GuiControllerTemplateAxisElement("Mouse Wheel Horizontal"), new GuiControllerTemplateButtonElement("Mouse Wheel Button"));

		[SerializeField]
		private GuiControllerTemplateButtonElement leftButton = new GuiControllerTemplateButtonElement("Left Mouse Button");

		[SerializeField]
		private GuiControllerTemplateButtonElement rightButton = new GuiControllerTemplateButtonElement("Right Mouse Button");

		private List<IGuiControllerTemplateElement> elements;

		public override ControllerId ControllerId => controllerId;

		public override IReadOnlyList<IGuiControllerTemplateElement> Elements
		{
			get
			{
				List<IGuiControllerTemplateElement> list = elements;
				if (list == null)
				{
					List<IGuiControllerTemplateElement> obj = new List<IGuiControllerTemplateElement> { horizontal, vertical, wheel, wheel.Horizontal, wheel.Vertical, wheel.Press, leftButton, rightButton };
					List<IGuiControllerTemplateElement> list2 = obj;
					elements = obj;
					list = list2;
				}
				return list;
			}
		}

		public IGuiControllerTemplateAxisElement Horizontal => horizontal;

		public IGuiControllerTemplateAxisElement Vertical => vertical;

		public IGuiControllerTemplateWheelElement Wheel => wheel;

		public IGuiControllerTemplateButtonElement LeftButton => leftButton;

		public IGuiControllerTemplateButtonElement RightButton => rightButton;

		public override bool TryGetElement(int elementId, out IGuiControllerTemplateElement element)
		{
			element = GetElement(elementId);
			return element != null;
		}

		public override IGuiControllerTemplateElement GetElement(int elementId)
		{
			return elementId switch
			{
				0 => horizontal, 
				1 => vertical, 
				2 => wheel.Vertical, 
				10 => wheel.Horizontal, 
				5 => wheel.Press, 
				3 => leftButton, 
				4 => rightButton, 
				_ => null, 
			};
		}
	}
}
