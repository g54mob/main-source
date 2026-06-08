namespace Kitchen
{
	public interface IStatistic
	{
		string Summarise();

		void Clear();
	}
	public interface IStatistic<T> : IStatistic
	{
		T ResultValue();
	}
}
