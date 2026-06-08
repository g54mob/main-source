using System;

[Serializable]
public class TransportOptions : Options
{
	public int transport;

	public TransportOptions(int id)
	{
		transport = id;
	}
}
