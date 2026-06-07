public class PropertyItem<T> : IPropertyItem
{
	private T _value;

	public T value => _value;

	public void ChangeValue(T nextValue)
	{
		_value = nextValue;
	}

	public void InitializeValue(T initialValue)
	{
		_value = initialValue;
	}
}
