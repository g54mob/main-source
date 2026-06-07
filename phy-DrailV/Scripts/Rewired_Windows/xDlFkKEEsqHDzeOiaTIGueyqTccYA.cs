using System;
using System.Runtime.InteropServices;

internal struct xDlFkKEEsqHDzeOiaTIGueyqTccYA
{
	public IntPtr QtXcZTickhBwGLYIAJbqpdfWpmzB;

	public int lDyirplEdcjITMQkfVCzTYSCKrGg;

	public int muWgIwfZykaHnaQEEYPetzSeXIsSA;

	public nKtbafSXrnTNPtOvtJxfpVimFmOA vVKRiokJGjZFUsDfHXTaxdFOMKfy;

	public bool LOAKUriHGZEbByAroDTyQAHhOjqU
	{
		get
		{
			if (QtXcZTickhBwGLYIAJbqpdfWpmzB != IntPtr.Zero && lDyirplEdcjITMQkfVCzTYSCKrGg > 0)
			{
				return muWgIwfZykaHnaQEEYPetzSeXIsSA > 0;
			}
			return false;
		}
	}

	public xDlFkKEEsqHDzeOiaTIGueyqTccYA(IntPtr P_0, int P_1, int P_2)
	{
		QtXcZTickhBwGLYIAJbqpdfWpmzB = P_0;
		lDyirplEdcjITMQkfVCzTYSCKrGg = P_1;
		muWgIwfZykaHnaQEEYPetzSeXIsSA = P_2;
		vVKRiokJGjZFUsDfHXTaxdFOMKfy = nKtbafSXrnTNPtOvtJxfpVimFmOA.None;
	}

	public void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		QtXcZTickhBwGLYIAJbqpdfWpmzB = IntPtr.Zero;
		lDyirplEdcjITMQkfVCzTYSCKrGg = 0;
		muWgIwfZykaHnaQEEYPetzSeXIsSA = 0;
		vVKRiokJGjZFUsDfHXTaxdFOMKfy = nKtbafSXrnTNPtOvtJxfpVimFmOA.None;
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((QtXcZTickhBwGLYIAJbqpdfWpmzB == IntPtr.Zero) ? "NULL" : ("Is Valid (" + QtXcZTickhBwGLYIAJbqpdfWpmzB + ")")) + "\n";
		text = text + "bufferLength = " + lDyirplEdcjITMQkfVCzTYSCKrGg + "\n";
		text = text + "reportLength = " + muWgIwfZykaHnaQEEYPetzSeXIsSA + "\n";
		string text2 = text;
		int num = (int)vVKRiokJGjZFUsDfHXTaxdFOMKfy;
		text = text2 + "options = " + num + "\n";
		if (QtXcZTickhBwGLYIAJbqpdfWpmzB != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < muWgIwfZykaHnaQEEYPetzSeXIsSA; i++)
			{
				text += Marshal.ReadByte(QtXcZTickhBwGLYIAJbqpdfWpmzB, i).ToString("X2");
				if (i < muWgIwfZykaHnaQEEYPetzSeXIsSA - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
