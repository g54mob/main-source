using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class jlaiJdAMfHFcxKQzVfXfSGqdhKQX
{
	[CompilerGenerated]
	private DateTime PYxwpqNCQyvkNDDLvdpimifUcrkAA;

	[CompilerGenerated]
	private WeakReference tZmsArpsFbllTyptOsieurZJWtwx;

	[CompilerGenerated]
	private string UpYjVOufYNIrEInWWaaEdgXCqHwjA;

	public DateTime AXKcaNXbPBEXPDBLiXHAOvjHldVdA
	{
		[CompilerGenerated]
		get
		{
			return PYxwpqNCQyvkNDDLvdpimifUcrkAA;
		}
		[CompilerGenerated]
		private set
		{
			PYxwpqNCQyvkNDDLvdpimifUcrkAA = pYxwpqNCQyvkNDDLvdpimifUcrkAA;
		}
	}

	public WeakReference tSGuyAQuCDoxkkrXvZXPyBpWAfvW
	{
		[CompilerGenerated]
		get
		{
			return tZmsArpsFbllTyptOsieurZJWtwx;
		}
		[CompilerGenerated]
		private set
		{
			tZmsArpsFbllTyptOsieurZJWtwx = weakReference;
		}
	}

	public string OAyNghPAABUnfMqHfJIBaDzOapxu
	{
		[CompilerGenerated]
		get
		{
			return UpYjVOufYNIrEInWWaaEdgXCqHwjA;
		}
		[CompilerGenerated]
		private set
		{
			UpYjVOufYNIrEInWWaaEdgXCqHwjA = upYjVOufYNIrEInWWaaEdgXCqHwjA;
		}
	}

	public bool hwLkZcStndTkbbwaHqMDBwQCdCvu => tSGuyAQuCDoxkkrXvZXPyBpWAfvW.IsAlive;

	public jlaiJdAMfHFcxKQzVfXfSGqdhKQX(DateTime P_0, YutCLanOuXTAhakKQUOtqCxgUWzR P_1, string P_2)
	{
		AXKcaNXbPBEXPDBLiXHAOvjHldVdA = P_0;
		tSGuyAQuCDoxkkrXvZXPyBpWAfvW = new WeakReference(P_1, trackResurrection: true);
		OAyNghPAABUnfMqHfJIBaDzOapxu = P_2;
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		if (!(tSGuyAQuCDoxkkrXvZXPyBpWAfvW.Target is YutCLanOuXTAhakKQUOtqCxgUWzR yutCLanOuXTAhakKQUOtqCxgUWzR))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", yutCLanOuXTAhakKQUOtqCxgUWzR.GMaPHoiZAJyngdXeSoVFwLOeWHKm.ToInt64(), yutCLanOuXTAhakKQUOtqCxgUWzR.GetType().FullName, AXKcaNXbPBEXPDBLiXHAOvjHldVdA, OAyNghPAABUnfMqHfJIBaDzOapxu).AppendLine();
		return stringBuilder.ToString();
	}
}
