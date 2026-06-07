namespace Coherence.RSL.Tickers
{
	public interface ITickProvider
	{
		bool Elapsed();

		void Reset();
	}
}
