using System;

[Serializable]
public class PipeConnection
{
	public int Pipe1ID;

	public int Pipe2ID;

	public bool Contains(int id)
	{
		return false;
	}

	public PipeConnection(int pipe1ID, int pipe2ID)
	{
	}
}
