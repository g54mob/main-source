public sealed class Signaller
{
	public readonly object _lock;

	public void PulseAll()
	{
	}

	public void Wait()
	{
	}

	public bool Wait(int timeoutMilliseconds)
	{
		return false;
	}
}
