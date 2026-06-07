using System;

public class InternetConnectionHandle : IDisposable
{
	private bool _isOpen;

	private IReachability _reachability;

	private static int NextId = 1;

	public int Id { get; }

	public bool IsAvailable => _reachability.Connectivity == InternetConnectivity.Connected;

	public InternetConnectionHandle(IReachability reachability)
	{
		_isOpen = true;
		_reachability = reachability;
		Id = NextId;
		NextId++;
	}

	~InternetConnectionHandle()
	{
		Close();
	}

	public void Close()
	{
		if (_isOpen)
		{
			_reachability.CloseConnection(this);
			_isOpen = false;
		}
	}

	public void Dispose()
	{
		Close();
	}
}
