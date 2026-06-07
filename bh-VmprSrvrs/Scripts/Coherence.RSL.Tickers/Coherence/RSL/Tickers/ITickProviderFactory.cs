namespace Coherence.RSL.Tickers
{
	public interface ITickProviderFactory
	{
		ITickProvider NewTicker(int frequency);
	}
}
