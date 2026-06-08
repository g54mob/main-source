using System;

public interface IWeakEventHandler<E> where E : EventArgs
{
	EventHandler<E> Handler { get; }
}
