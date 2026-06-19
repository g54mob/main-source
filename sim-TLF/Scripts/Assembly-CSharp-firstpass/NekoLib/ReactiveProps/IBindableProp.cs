using System;

namespace NekoLib.ReactiveProps
{
	public interface IBindableProp<T>
	{
		T Value { get; set; }

		event Action<T> ValueChanged;
	}
}
