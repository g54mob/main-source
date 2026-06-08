namespace MLAPI.NetworkedVar.Collections
{
	public struct NetworkedListEvent<T>
	{
		public enum EventType
		{
			Add = 0,
			Insert = 1,
			Remove = 2,
			RemoveAt = 3,
			Value = 4,
			Clear = 5
		}

		public EventType eventType;

		public T value;

		public int index;
	}
}
