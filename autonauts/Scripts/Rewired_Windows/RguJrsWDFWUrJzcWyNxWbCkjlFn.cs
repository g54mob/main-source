using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class RguJrsWDFWUrJzcWyNxWbCkjlFn
{
	[CompilerGenerated]
	private DateTime pNjIvvLsCzgXfguBCraTBAxQcaH;

	[CompilerGenerated]
	private WeakReference XRmMmghMjaewvhBIbCiVBDTAJiJY;

	[CompilerGenerated]
	private string sGYDvZclsEFcsnblfZqjPqHUpGD;

	public DateTime CreationTime
	{
		[CompilerGenerated]
		get
		{
			return pNjIvvLsCzgXfguBCraTBAxQcaH;
		}
		[CompilerGenerated]
		private set
		{
			pNjIvvLsCzgXfguBCraTBAxQcaH = value;
		}
	}

	public WeakReference Object
	{
		[CompilerGenerated]
		get
		{
			return XRmMmghMjaewvhBIbCiVBDTAJiJY;
		}
		[CompilerGenerated]
		private set
		{
			XRmMmghMjaewvhBIbCiVBDTAJiJY = value;
		}
	}

	public string StackTrace
	{
		[CompilerGenerated]
		get
		{
			return sGYDvZclsEFcsnblfZqjPqHUpGD;
		}
		[CompilerGenerated]
		private set
		{
			sGYDvZclsEFcsnblfZqjPqHUpGD = value;
		}
	}

	public bool IsAlive
	{
		get
		{
			return Object.IsAlive;
		}
	}

	public RguJrsWDFWUrJzcWyNxWbCkjlFn(DateTime creationTime, wTffSbnzKKVYFFadbCeIXFvuFVC comObject, string stackTrace)
	{
		CreationTime = creationTime;
		Object = new WeakReference(comObject, true);
		StackTrace = stackTrace;
	}

	public override string ToString()
	{
		wTffSbnzKKVYFFadbCeIXFvuFVC wTffSbnzKKVYFFadbCeIXFvuFVC2 = Object.Target as wTffSbnzKKVYFFadbCeIXFvuFVC;
		if (wTffSbnzKKVYFFadbCeIXFvuFVC2 == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", wTffSbnzKKVYFFadbCeIXFvuFVC2.NativePointer.ToInt64(), wTffSbnzKKVYFFadbCeIXFvuFVC2.GetType().FullName, CreationTime, StackTrace).AppendLine();
		return stringBuilder.ToString();
	}
}
