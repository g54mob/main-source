using System;

public class Memento
{
	public Action<object[]> undoMethod;

	public object[] values;

	public int id;

	public Memento(Action<object[]> m, object[] v, int i)
	{
	}
}
