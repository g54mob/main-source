public interface IEventBase
{
	int Count { get; }

	bool IsEmpty { get; }

	uint SendEventCount { get; }

	void Clear();
}
