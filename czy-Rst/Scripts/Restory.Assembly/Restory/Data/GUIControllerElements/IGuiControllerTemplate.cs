using System.Collections.Generic;

namespace Restory.Data.GUIControllerElements
{
	public interface IGuiControllerTemplate
	{
		ControllerId ControllerId { get; }

		IReadOnlyList<IGuiControllerTemplateElement> Elements { get; }

		IGuiControllerTemplateElement GetElement(int elementId);

		bool TryGetElement(int elementId, out IGuiControllerTemplateElement element);
	}
}
