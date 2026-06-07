using System;
using System.Runtime.InteropServices;

internal struct dccInhMggZtLYGkWFjXacEyGQoUL
{
	public IntPtr nSMLXraEgpqESkWlwSKSinMmlYpN;

	public int zoZZFjYZKLkUmIbYjWkrNoVbDtqb;

	public int ZJBuOJOStbVKiBMhUsKGVrrxvlom;

	public zQFonDSyLUVtcnBuzoJLlVRGpkWG ofRcrROmEPgbgDZJnODVczeCRfSh;

	public bool IYocMhXuJJhjjemyypgvPacZpoeLA
	{
		get
		{
			if (nSMLXraEgpqESkWlwSKSinMmlYpN != IntPtr.Zero && zoZZFjYZKLkUmIbYjWkrNoVbDtqb > 0)
			{
				return ZJBuOJOStbVKiBMhUsKGVrrxvlom > 0;
			}
			return false;
		}
	}

	public dccInhMggZtLYGkWFjXacEyGQoUL(IntPtr P_0, int P_1, int P_2)
	{
		nSMLXraEgpqESkWlwSKSinMmlYpN = P_0;
		zoZZFjYZKLkUmIbYjWkrNoVbDtqb = P_1;
		ZJBuOJOStbVKiBMhUsKGVrrxvlom = P_2;
		ofRcrROmEPgbgDZJnODVczeCRfSh = zQFonDSyLUVtcnBuzoJLlVRGpkWG.None;
	}

	public void PFhuLvwxUYvDhSjOGHeJsMcMbQgC()
	{
		nSMLXraEgpqESkWlwSKSinMmlYpN = IntPtr.Zero;
		zoZZFjYZKLkUmIbYjWkrNoVbDtqb = 0;
		ZJBuOJOStbVKiBMhUsKGVrrxvlom = 0;
		ofRcrROmEPgbgDZJnODVczeCRfSh = zQFonDSyLUVtcnBuzoJLlVRGpkWG.None;
	}

	public string bPlNgbYTcBxcuzBMmiIYKcIUtPxx()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((nSMLXraEgpqESkWlwSKSinMmlYpN == IntPtr.Zero) ? "NULL" : ("Is Valid (" + nSMLXraEgpqESkWlwSKSinMmlYpN + ")")) + "\n";
		text = text + "bufferLength = " + zoZZFjYZKLkUmIbYjWkrNoVbDtqb + "\n";
		text = text + "reportLength = " + ZJBuOJOStbVKiBMhUsKGVrrxvlom + "\n";
		string text2 = text;
		int num = (int)ofRcrROmEPgbgDZJnODVczeCRfSh;
		text = text2 + "options = " + num + "\n";
		if (nSMLXraEgpqESkWlwSKSinMmlYpN != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < ZJBuOJOStbVKiBMhUsKGVrrxvlom; i++)
			{
				text += Marshal.ReadByte(nSMLXraEgpqESkWlwSKSinMmlYpN, i).ToString("X2");
				if (i < ZJBuOJOStbVKiBMhUsKGVrrxvlom - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
