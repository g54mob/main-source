using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class GJAcZNYjdUXNLaChyfXkNzGZYI
{
	[CompilerGenerated]
	private DateTime guCpBECmSAzOjQZeNqtKQiuhwfc;

	[CompilerGenerated]
	private WeakReference MSPnhRwhBLWhvrCIsgmYIpIwCfcF;

	[CompilerGenerated]
	private string zBzedkrWNtEeULhyumokOSlxPym;

	public DateTime CreationTime
	{
		[CompilerGenerated]
		get
		{
			return guCpBECmSAzOjQZeNqtKQiuhwfc;
		}
		[CompilerGenerated]
		private set
		{
			guCpBECmSAzOjQZeNqtKQiuhwfc = value;
		}
	}

	public WeakReference Object
	{
		[CompilerGenerated]
		get
		{
			return MSPnhRwhBLWhvrCIsgmYIpIwCfcF;
		}
		[CompilerGenerated]
		private set
		{
			MSPnhRwhBLWhvrCIsgmYIpIwCfcF = value;
		}
	}

	public string StackTrace
	{
		[CompilerGenerated]
		get
		{
			return zBzedkrWNtEeULhyumokOSlxPym;
		}
		[CompilerGenerated]
		private set
		{
			zBzedkrWNtEeULhyumokOSlxPym = value;
		}
	}

	public bool IsAlive => Object.IsAlive;

	public GJAcZNYjdUXNLaChyfXkNzGZYI(DateTime creationTime, vAWguSwtalYfBjVbuWSVCdiToKd comObject, string stackTrace)
	{
		CreationTime = creationTime;
		Object = new WeakReference(comObject, trackResurrection: true);
		StackTrace = stackTrace;
	}

	public override string ToString()
	{
		if (!(Object.Target is vAWguSwtalYfBjVbuWSVCdiToKd vAWguSwtalYfBjVbuWSVCdiToKd2))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", vAWguSwtalYfBjVbuWSVCdiToKd2.NativePointer.ToInt64(), vAWguSwtalYfBjVbuWSVCdiToKd2.GetType().FullName, CreationTime, StackTrace).AppendLine();
		return stringBuilder.ToString();
	}
}
