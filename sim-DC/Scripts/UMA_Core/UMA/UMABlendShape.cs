using System;
using System.Runtime.InteropServices;

namespace UMA
{
	[Serializable]
	[StructLayout((LayoutKind)0)]
	public class UMABlendShape
	{
		public string shapeName;

		public UMABlendFrame[] frames;
	}
}
