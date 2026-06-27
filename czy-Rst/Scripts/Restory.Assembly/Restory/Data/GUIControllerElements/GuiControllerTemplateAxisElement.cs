using System;
using Rewired;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[Serializable]
	public sealed class GuiControllerTemplateAxisElement : IGuiControllerTemplateAxisElement, IGuiControllerTemplateElement
	{
		private string identifierName;

		private ControllerElementType elementType;

		[SerializeField]
		private Sprite sprite;

		[SerializeField]
		private Sprite spritePositive;

		[SerializeField]
		private Sprite spriteNegative;

		public string IdentifierName => identifierName;

		public ControllerElementType ElementType => elementType;

		public GuiControllerTemplateAxisElement(string identifierName)
		{
			this.identifierName = identifierName;
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
				AxisRange.Positive => spritePositive, 
				AxisRange.Negative => spriteNegative, 
				_ => null, 
			};
		}

		public Sprite GetPressSprite()
		{
			return null;
		}
	}
}
