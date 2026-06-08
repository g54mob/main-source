using System;
using System.Runtime.CompilerServices;

namespace Rhizomatic.Reactive
{
	public abstract class State
	{
		public abstract object valueObj { get; set; }

		public event Action onChanged
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

		public virtual Type GetDeclaredType()
		{
			return null;
		}

		public virtual void Changed()
		{
		}
	}
	public class State<T> : State
	{
		public T _value;

		public T value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public override object valueObj
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public State(T defaultValue = default(T))
		{
		}

		public override Type GetDeclaredType()
		{
			return null;
		}

		public void SetValue(T value)
		{
		}

		public static implicit operator T(State<T> state)
		{
			return default(T);
		}
	}
}
