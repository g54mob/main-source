using System.Text;

internal static class vodCFExeKaAqZHjPouFUJDcNuibP
{
	public static string eHhEaAXhmZPBiQybMGJBCZFzklEI(this byte[] P_0)
	{
		string text = Encoding.UTF8.GetString(P_0);
		return text.Remove(text.IndexOf('\0'));
	}

	public static string WLTwYeadERdfCtnZasXWsXTZmsuy(this byte[] P_0)
	{
		string text = Encoding.Unicode.GetString(P_0);
		return text.Remove(text.IndexOf('\0'));
	}
}
