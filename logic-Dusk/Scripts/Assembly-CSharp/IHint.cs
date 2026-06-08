public interface IHint
{
	int Priority { get; }

	bool IsCompleting { get; }

	bool HasStarted { get; }

	bool CompleteTriggersNextStep { get; }

	bool OnlyAllowCompleteIfStarted { get; }

	IHintState Start();

	IHintState GetNextState();

	IHintState Completed();

	IHintState Terminate();

	void Update();
}
