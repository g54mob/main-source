using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class CmJrJrItMoTbvbevKsCGaiZxZUH
{
	[CompilerGenerated]
	private DateTime eAOOUsLoKDHCDImCgFwTNAGWvspp;

	[CompilerGenerated]
	private WeakReference UYNsSlxFZEISXTgKPhJTIoKHsgv;

	[CompilerGenerated]
	private string xinjKGeYncYEUnTOHrrCOyKCOtM;

	public DateTime CreationTime
	{
		[CompilerGenerated]
		get
		{
			return eAOOUsLoKDHCDImCgFwTNAGWvspp;
		}
		[CompilerGenerated]
		private set
		{
			eAOOUsLoKDHCDImCgFwTNAGWvspp = value;
		}
	}

	public WeakReference Object
	{
		[CompilerGenerated]
		get
		{
			return UYNsSlxFZEISXTgKPhJTIoKHsgv;
		}
		[CompilerGenerated]
		private set
		{
			UYNsSlxFZEISXTgKPhJTIoKHsgv = value;
		}
	}

	public string StackTrace
	{
		[CompilerGenerated]
		get
		{
			return xinjKGeYncYEUnTOHrrCOyKCOtM;
		}
		[CompilerGenerated]
		private set
		{
			xinjKGeYncYEUnTOHrrCOyKCOtM = value;
		}
	}

	public bool IsAlive => Object.IsAlive;

	public CmJrJrItMoTbvbevKsCGaiZxZUH(DateTime creationTime, thUdjkhtsoEtlHZFTxVMIBAaDZoG comObject, string stackTrace)
	{
		CreationTime = creationTime;
		Object = new WeakReference(comObject, trackResurrection: true);
		StackTrace = stackTrace;
	}

	public override string ToString()
	{
		if (!(Object.Target is thUdjkhtsoEtlHZFTxVMIBAaDZoG thUdjkhtsoEtlHZFTxVMIBAaDZoG2))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", thUdjkhtsoEtlHZFTxVMIBAaDZoG2.NativePointer.ToInt64(), thUdjkhtsoEtlHZFTxVMIBAaDZoG2.GetType().FullName, CreationTime, StackTrace).AppendLine();
		return stringBuilder.ToString();
	}
}
