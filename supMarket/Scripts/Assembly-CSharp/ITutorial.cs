public interface ITutorial
{
	bool IsCompleted { get; }

	void BeginTutorial();

	void EndTutorial();
}
