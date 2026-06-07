using System;

public abstract class RandomItem
{
	public abstract Type Type { get; }
}
public class RandomItem<T> : RandomItem
{
	public override Type Type => typeof(T);

	public T Value { get; set; }
}
