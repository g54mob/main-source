namespace OUSystems.Basics.DataStructures
{
	public struct ValueUpdateData<T>
	{
		public T OldValue;

		public T Value;

		public ValueUpdateData(T oldQuantity, T newQuantity)
		{
			OldValue = default(T);
			Value = default(T);
		}

		public static implicit operator T(ValueUpdateData<T> valueUpdateData)
		{
			return default(T);
		}
	}
}
