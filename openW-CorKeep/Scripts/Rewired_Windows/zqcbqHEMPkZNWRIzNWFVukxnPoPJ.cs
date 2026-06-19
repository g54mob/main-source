using System;
using System.Runtime.CompilerServices;

internal struct zqcbqHEMPkZNWRIzNWFVukxnPoPJ
{
	private uint umQCAYXvNLhbAJyPQhuwpydwjmxF;

	private ulong JNIlBQmJEuByGOeaJYGcvXMrDsOe;

	private static readonly bool JbGykOmBdebyBaWvjmiUGDMAupUS;

	public static readonly int rBOJibzcNnrzJQqIqifuNMoflOuX;

	static zqcbqHEMPkZNWRIzNWFVukxnPoPJ()
	{
		JbGykOmBdebyBaWvjmiUGDMAupUS = IntPtr.Size == 8;
		rBOJibzcNnrzJQqIqifuNMoflOuX = (JbGykOmBdebyBaWvjmiUGDMAupUS ? 8 : 4);
	}

	public static zqcbqHEMPkZNWRIzNWFVukxnPoPJ ekHIESzyVqTutDSGMuiHclgkpxul(byte[] P_0, int P_1)
	{
		zqcbqHEMPkZNWRIzNWFVukxnPoPJ result = default(zqcbqHEMPkZNWRIzNWFVukxnPoPJ);
		if (JbGykOmBdebyBaWvjmiUGDMAupUS)
		{
			result.JNIlBQmJEuByGOeaJYGcvXMrDsOe = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.umQCAYXvNLhbAJyPQhuwpydwjmxF = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint AjLtbBGSPjgsdduKigqFEpnwcnlMA(zqcbqHEMPkZNWRIzNWFVukxnPoPJ P_0)
	{
		if (JbGykOmBdebyBaWvjmiUGDMAupUS)
		{
			return (uint)P_0.JNIlBQmJEuByGOeaJYGcvXMrDsOe;
		}
		return P_0.umQCAYXvNLhbAJyPQhuwpydwjmxF;
	}

	[SpecialName]
	public static ulong AjLtbBGSPjgsdduKigqFEpnwcnlMA(zqcbqHEMPkZNWRIzNWFVukxnPoPJ P_0)
	{
		if (JbGykOmBdebyBaWvjmiUGDMAupUS)
		{
			return P_0.JNIlBQmJEuByGOeaJYGcvXMrDsOe;
		}
		return P_0.umQCAYXvNLhbAJyPQhuwpydwjmxF;
	}

	public string SUcaBBwyCHQNmwCoQDOGJlUNYsqbA()
	{
		if (JbGykOmBdebyBaWvjmiUGDMAupUS)
		{
			return JNIlBQmJEuByGOeaJYGcvXMrDsOe.ToString();
		}
		return umQCAYXvNLhbAJyPQhuwpydwjmxF.ToString();
	}
}
