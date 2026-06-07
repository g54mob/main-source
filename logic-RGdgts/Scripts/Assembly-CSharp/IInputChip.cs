using System.Collections.Generic;

public interface IInputChip
{
	ICollection<string> GetInputBindings();

	bool IsInputBindingValid(string name);

	InputBinding.Type GetInputBindingType(string name);

	bool GetButtonState(InputBinding inputBinding);

	bool GetButtonUp(InputBinding inputBinding);

	bool GetButtonDown(InputBinding inputBinding);

	float GetAxis(InputBinding inputBinding);
}
