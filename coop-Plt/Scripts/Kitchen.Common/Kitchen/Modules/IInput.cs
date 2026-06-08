using System;

namespace Kitchen.Modules
{
	public interface IInput<T>
	{
		T Value { get; set; }

		event Action<T> OnOptionHighlighted;

		event Action<T> OnOptionChosen;
	}
}
