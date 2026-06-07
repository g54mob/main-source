using System;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout((LayoutKind)0)]
public class SavedGameDataGameCenter
{
	public string deviceName;

	public string name;

	public double modificationDate;
}
