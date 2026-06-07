using System;

public abstract class Command<T> where T : struct, IComparable, IFormattable, IConvertible
{
	public abstract T Execute();

	public abstract void Revert();
}
