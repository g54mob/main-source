public interface IHintState
{
	HintStateTypeEnum StateType { get; }

	void Start();

	bool Update();

	void Stop();
}
