using System.Text;

internal static class cbijpueoqDMDfCibhLIICicgRqUW
{
	public static string CEUkbEPslyOaPsaogvXwNzQWoim(this byte[] P_0)
	{
		string text = Encoding.UTF8.GetString(P_0);
		return text.Remove(text.IndexOf('\0'));
	}

	public static string vVceaGcnWoUkcNIqwtrjAdDGwbE(this byte[] P_0)
	{
		string text = Encoding.Unicode.GetString(P_0);
		return text.Remove(text.IndexOf('\0'));
	}
}
