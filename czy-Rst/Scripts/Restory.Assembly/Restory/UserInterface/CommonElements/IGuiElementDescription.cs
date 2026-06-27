using System;

namespace Restory.UserInterface.CommonElements
{
	public interface IGuiElementDescription
	{
		string Description { get; }

		event Action OnDescriptionChange;
	}
}
