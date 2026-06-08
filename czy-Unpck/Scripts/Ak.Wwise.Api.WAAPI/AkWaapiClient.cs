using System.Threading.Tasks;

internal class AkWaapiClient
{
	public Wamp wamp;

	public event Wamp.DisconnectedHandler Disconnected;

	public async Task Connect(string uri = "ws://localhost:8080/waapi", int timeout = int.MaxValue)
	{
		if (wamp == null)
		{
			wamp = new Wamp();
		}
		wamp.Disconnected += Wamp_Disconnected;
		await wamp.Connect(uri, timeout);
	}

	private void Wamp_Disconnected()
	{
		if (this.Disconnected != null)
		{
			this.Disconnected();
		}
	}

	public async Task Close(int timeout = int.MaxValue)
	{
		if (wamp == null)
		{
			throw new Wamp.WampNotConnectedException("WAMP connection is not established");
		}
		await wamp.Close(timeout);
		wamp.Disconnected -= Wamp_Disconnected;
		wamp = null;
	}

	public bool IsConnected()
	{
		if (wamp == null)
		{
			return false;
		}
		return wamp.IsConnected();
	}

	public async Task<string> Call(string uri, string args = "{}", string options = "{}", int timeout = int.MaxValue)
	{
		if (wamp == null)
		{
			throw new Wamp.WampNotConnectedException("WAMP connection is not established");
		}
		if (args == null)
		{
			args = "{}";
		}
		if (options == null)
		{
			options = "{}";
		}
		return await wamp.Call(uri, args, options, timeout);
	}

	public async Task<uint> Subscribe(string topic, string options, Wamp.PublishHandler publishHandler, int timeout = int.MaxValue)
	{
		if (wamp == null)
		{
			throw new Wamp.WampNotConnectedException("WAMP connection is not established");
		}
		if (options == null)
		{
			options = "{}";
		}
		return await wamp.Subscribe(topic, options, publishHandler, timeout);
	}

	public async Task Unsubscribe(uint subscriptionId, int timeout = int.MaxValue)
	{
		if (wamp == null)
		{
			throw new Wamp.WampNotConnectedException("WAMP connection is not established");
		}
		await wamp.Unsubscribe(subscriptionId, timeout);
	}
}
