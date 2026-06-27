using System;
using Rewired;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[Serializable]
	public sealed class GuiControllerTemplateWheelElement : IGuiControllerTemplateWheelElement, IGuiControllerTemplateElement
	{
		private string identifierName;

		private ControllerElementType elementType = ControllerElementType.CompoundElement;

		[SerializeField]
		private Sprite sprite;

		[SerializeField]
		private GuiControllerTemplateAxisElement horizontal;

		[SerializeField]
		private GuiControllerTemplateAxisElement vertical;

		[SerializeField]
		private GuiControllerTemplateButtonElement press;

		public string IdentifierName => identifierName;

		public ControllerElementType ElementType => elementType;

		public IGuiControllerTemplateAxisElement Horizontal => horizontal;

		public IGuiControllerTemplateAxisElement Vertical => vertical;

		public IGuiControllerTemplateButtonElement Press => press;

		public GuiControllerTemplateWheelElement(string identifierName, GuiControllerTemplateAxisElement horizontal, GuiControllerTemplateAxisElement vertical, GuiControllerTemplateButtonElement press)
		{
			this.identifierName = identifierName;
			this.horizontal = horizontal;
			this.vertical = vertical;
			this.press = press;
		}

		public Sprite GetSprite()
		{
			return sprite;
		}

		public Sprite GetSprite(AxisRange axis)
		{
			return sprite;
		}

		public Sprite GetPressSprite()
		{
			return press.GetPressSprite();
		}
	}
}
