using System;

[Serializable]
public class ArgsPlay : Args
{
	public string action;

	public int transport;

	public ArgsPlay(string a, int t)
	{
		action = a;
		transport = t;
	}
}
