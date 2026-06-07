namespace ReinforcementLearning
{
	public interface IReplayBuffer<T>
	{
		int MaxBufferSize { get; set; }

		void Add(T obj);

		T[] GetSamples(long samplesNumber);

		T[] GetAllSamples();

		long Count();

		void Clear();
	}
}
