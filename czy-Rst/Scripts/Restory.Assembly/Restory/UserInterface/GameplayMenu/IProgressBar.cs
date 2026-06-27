using UnityEngine.Events;

namespace Restory.UserInterface.GameplayMenu
{
	public interface IProgressBar
	{
		float Value { get; }

		UnityEvent OnValueChanged { get; }
	}
}
