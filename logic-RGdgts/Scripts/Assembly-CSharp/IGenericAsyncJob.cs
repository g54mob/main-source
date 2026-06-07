using System;

public interface IGenericAsyncJob
{
	Type ResultType { get; }

	bool IsComplete();
}
