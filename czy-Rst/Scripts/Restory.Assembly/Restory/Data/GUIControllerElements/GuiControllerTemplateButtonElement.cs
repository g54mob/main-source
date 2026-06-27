using System;
using Rewired;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[Serializable]
	public sealed class GuiControllerTemplateButtonElement : IGuiControllerTemplateButtonElement, IGuiControllerTemplateElement
	{
		private string identifierName;

		private ControllerElementType elementType = ControllerElementType.Button;

		[SerializeField]
		private Sprite sprite;

		[SerializeField]
		private Sprite pressSprite;

		public string IdentifierName => identifierName;

		public ControllerElementType ElementType => elementType;

		public GuiControllerTemplateButtonElement(string identifierName)
			: this(identifierName, ControllerElementType.Button)
		{
		}

		public GuiControllerTemplateButtonElement(string identifierName, ControllerElementType elementType)
		{
			this.identifierName = identifierName;
			this.elementType = elementType;
		}

		public Sprite GetSprite()
		{
			return sprite;
		}

		public Sprite GetSprite(AxisRange axis)
		{
			return axis switch
			{
				AxisRange.Full => sprite, 
				AxisRange.Positive => sprite, 
				AxisRange.Negative => sprite, 
				_ => null, 
			};
		}

		public Sprite GetPressSprite()
		{
			return pressSprite;
		}
	}
}
