using Rewired;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	public interface IGuiControllerTemplateElement
	{
		string IdentifierName { get; }

		ControllerElementType ElementType { get; }

		Sprite GetSprite();

		Sprite GetSprite(AxisRange axis);

		Sprite GetPressSprite();
	}
}
