using MalbersAnimations.Events;

namespace MalbersAnimations
{
	public interface IInputAction
	{
		bool Active { get; set; }

		bool GetValue { get; }

		string Name { get; }

		BoolEvent InputChanged { get; }
	}
}
