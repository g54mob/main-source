using System;
using System.Runtime.CompilerServices;

public class SettingEntry<T>
{
	public T Value { get; private set; }

	public event Action<T> Changed
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

	public void Set(T value)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
