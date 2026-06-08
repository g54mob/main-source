namespace Castle.Components.DictionaryAdapter
{
	public abstract class DynamicValue<T> : IDynamicValue<T>, IDynamicValue
	{
		public abstract T Value { get; }

		object IDynamicValue.GetValue()
		{
			return Value;
		}

		public override string ToString()
		{
			T value = Value;
			if (value != null)
			{
				return value.ToString();
			}
			return base.ToString();
		}
	}
}
