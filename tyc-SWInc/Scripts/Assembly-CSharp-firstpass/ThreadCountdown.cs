using System.Threading;

public class ThreadCountdown
{
	public int Target;

	public int Done;

	private ManualResetEvent _callback = new ManualResetEvent(false);

	public ThreadCountdown(int target)
	{
		Target = target;
	}

	public void Reset(int target)
	{
		Target = target;
		Done = 0;
		_callback.Reset();
	}

	public void FinishTask()
	{
		lock (this)
		{
			Done++;
			if (Done >= Target)
			{
				_callback.Set();
			}
		}
	}

	public void Wait()
	{
		_callback.WaitOne();
	}
}
