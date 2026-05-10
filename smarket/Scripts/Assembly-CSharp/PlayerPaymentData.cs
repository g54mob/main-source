using System;
using ExitGames.Client.Photon;

[Serializable]
public class PlayerPaymentData
{
	public int LoanID;

	public int Date;

	public float Amount;

	public PlayerPaymentType PaymentType;

	public float LatePaymentFee;

	private static readonly byte[] INTBuf;

	private static readonly byte[] FloatBuf;

	public float TotalAmount => 0f;

	public bool IsEqual(PlayerPaymentData other)
	{
		return false;
	}

	private static int WriteInt(StreamBuffer s, int v)
	{
		return 0;
	}

	private static int WriteFloat(StreamBuffer s, float v)
	{
		return 0;
	}

	private static int ReadInt(StreamBuffer s)
	{
		return 0;
	}

	private static float ReadFloat(StreamBuffer s)
	{
		return 0f;
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
