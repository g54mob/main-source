using System;
using ExitGames.Client.Photon;

[Serializable]
public class LoanData
{
	public int LoanID;

	public int TermLength;

	public int RemainingPayments;

	public bool Taken;

	private static readonly byte[] INTBuf;

	private static readonly byte[] BoolBuf;

	public void Reset()
	{
	}

	private static int WriteInt(StreamBuffer s, int v)
	{
		return 0;
	}

	private static int ReadInt(StreamBuffer s)
	{
		return 0;
	}

	private static int WriteBool(StreamBuffer s, bool v)
	{
		return 0;
	}

	private static bool ReadBool(StreamBuffer s)
	{
		return false;
	}

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}
}
