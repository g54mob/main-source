namespace MLAPI.NetworkedVar.Collections
{
	public struct NetworkedDictionaryEvent<TKey, TValue>
	{
		public enum NetworkedListEventType
		{
			Add = 0,
			Remove = 1,
			RemovePair = 2,
			Clear = 3,
			Value = 4
		}

		public NetworkedListEventType eventType;

		public TKey key;

		public TValue value;
	}
}
