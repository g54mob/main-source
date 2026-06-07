using System;
using System.Runtime.CompilerServices;

namespace Coherence.Toolkit
{
	public abstract class Observable<T>
	{
		public T Value { get; private set; }

		internal event Action<T, T> OnValueUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected Observable(T initialValue)
		{
		}

		public void UpdateValue(T newValue)
		{
		}
	}
}
