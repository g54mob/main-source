namespace Ink.Runtime
{
	public abstract class Value : Object
	{
		public abstract ValueType valueType { get; }

		public abstract bool isTruthy { get; }

		public abstract object valueObject { get; }

		public abstract Value Cast(ValueType newType);

		public static Value Create(object val)
		{
			return null;
		}

		public override Object Copy()
		{
			return null;
		}

		protected StoryException BadCastException(ValueType targetType)
		{
			return null;
		}
	}
	public abstract class Value<T> : Value
	{
		public T value { get; set; }

		public override object valueObject => null;

		public Value(T val)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
