using System;
using System.Runtime.InteropServices;

internal struct dQrAZjxmvMRuuUvHYPSsKegoCJrCA
{
	public IntPtr hIDtEbVnfedAcwbabdUQOxCSVaMm;

	public int heKFjVFnGOvZcoIksirovtuZpYKgb;

	public int JaUoCJvJieUwSVusZsZEvYfRaHVI;

	public pFKEYBfdSFpyWlUlolJLZXZaRgbo wZWZYdhupQABWZEQqexXIjnmCGhaA;

	public bool YdfmKboEuGEtLsndpRrzIkKbzQRC
	{
		get
		{
			if (hIDtEbVnfedAcwbabdUQOxCSVaMm != IntPtr.Zero && heKFjVFnGOvZcoIksirovtuZpYKgb > 0)
			{
				return JaUoCJvJieUwSVusZsZEvYfRaHVI > 0;
			}
			return false;
		}
	}

	public dQrAZjxmvMRuuUvHYPSsKegoCJrCA(IntPtr P_0, int P_1, int P_2)
	{
		hIDtEbVnfedAcwbabdUQOxCSVaMm = P_0;
		heKFjVFnGOvZcoIksirovtuZpYKgb = P_1;
		JaUoCJvJieUwSVusZsZEvYfRaHVI = P_2;
		wZWZYdhupQABWZEQqexXIjnmCGhaA = pFKEYBfdSFpyWlUlolJLZXZaRgbo.None;
	}

	public void FViUEdNFiXcONIUkVLkNzEWasgBmA()
	{
		hIDtEbVnfedAcwbabdUQOxCSVaMm = IntPtr.Zero;
		heKFjVFnGOvZcoIksirovtuZpYKgb = 0;
		JaUoCJvJieUwSVusZsZEvYfRaHVI = 0;
		wZWZYdhupQABWZEQqexXIjnmCGhaA = pFKEYBfdSFpyWlUlolJLZXZaRgbo.None;
	}

	public string xGelrnjhlIcKUjjPntjONwOeKCAUA()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((hIDtEbVnfedAcwbabdUQOxCSVaMm == IntPtr.Zero) ? "NULL" : ("Is Valid (" + hIDtEbVnfedAcwbabdUQOxCSVaMm + ")")) + "\n";
		text = text + "bufferLength = " + heKFjVFnGOvZcoIksirovtuZpYKgb + "\n";
		text = text + "reportLength = " + JaUoCJvJieUwSVusZsZEvYfRaHVI + "\n";
		string text2 = text;
		int num = (int)wZWZYdhupQABWZEQqexXIjnmCGhaA;
		text = text2 + "options = " + num + "\n";
		if (hIDtEbVnfedAcwbabdUQOxCSVaMm != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < JaUoCJvJieUwSVusZsZEvYfRaHVI; i++)
			{
				text += Marshal.ReadByte(hIDtEbVnfedAcwbabdUQOxCSVaMm, i).ToString("X2");
				if (i < JaUoCJvJieUwSVusZsZEvYfRaHVI - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
