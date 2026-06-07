using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class WrSlmJxoZFgCLSWPeQjtyKXyDhws : GLNYbQuaOXeaSToXMWjUhtXAplaf
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TouchpadInfo
	{
		public int maxTouches;

		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public bool invertY;

		public bool reverseY;

		public TouchpadInfo(int P_0, int P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
		{
		}

		public void CalculateTouch(ref TouchData data)
		{
		}
	}

	private class jBwcUzTCtuFgSRrTbSOSgqCRvbGy
	{
		public readonly TouchData[] yEvzSJoyUWaAZlKhIOPaVJeugZlFA;

		public jBwcUzTCtuFgSRrTbSOSgqCRvbGy(int P_0)
		{
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct TouchData
	{
		public int touchId;

		public float timeStamp;

		public bool isTouching;

		public int positionRawX;

		public int positionRawY;

		public float positionX;

		public float positionY;

		public int positionAbsX;

		public int positionAbsY;

		public void Clear()
		{
		}
	}

	private TouchpadInfo WRedgGAAbnYYYJBVZBvwlGRSLxTp;

	private RingBuffer<jBwcUzTCtuFgSRrTbSOSgqCRvbGy> eygDJwAAApNlQNeqLMXuRJsxFomSA;

	private TouchData[] gYPsntTyihfoitSEwfEHIIVBmneC;

	private Action<NativeBuffer, TouchData[]> dnAXSejIhuiruVZjTlrIkJXzOKFl;

	public TouchData[] ZSOCYhCHwlgvClOcxQaaKYrddvnaA;

	private ObjectPool<jBwcUzTCtuFgSRrTbSOSgqCRvbGy> FsqwiuoknKFrTVnKKqIeFTGSFFAi;

	public WrSlmJxoZFgCLSWPeQjtyKXyDhws(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(0, null)
	{
	}

	public override void pbQJKBeNEhApcsLUxZlDcAvKwGws(NativeBuffer P_0, double P_1)
	{
	}

	public void APYcPPMfZEAxIFREsqLFdZVnZCAp()
	{
	}

	public bool GCQcOAvDpBVuRlXTprXgMbZTKdlR(int P_0)
	{
		return false;
	}

	[CompilerGenerated]
	private jBwcUzTCtuFgSRrTbSOSgqCRvbGy NhqjcXiQoZPWrDndqcHGuZZzwFId()
	{
		return null;
	}
}
