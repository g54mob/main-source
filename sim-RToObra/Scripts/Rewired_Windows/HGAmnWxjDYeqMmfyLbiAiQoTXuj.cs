using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class HGAmnWxjDYeqMmfyLbiAiQoTXuj
{
	[CompilerGenerated]
	private DateTime jfBJTPbuwjLxqgtAgppVRMfliuHo;

	[CompilerGenerated]
	private WeakReference HBKfdSKvteOpgAqsOhqPMWVvriL;

	[CompilerGenerated]
	private string sQowvtDRgMxlhiuPQoJfOaBgIeV;

	public DateTime CreationTime
	{
		[CompilerGenerated]
		get
		{
			return jfBJTPbuwjLxqgtAgppVRMfliuHo;
		}
		[CompilerGenerated]
		private set
		{
			jfBJTPbuwjLxqgtAgppVRMfliuHo = value;
		}
	}

	public WeakReference Object
	{
		[CompilerGenerated]
		get
		{
			return HBKfdSKvteOpgAqsOhqPMWVvriL;
		}
		[CompilerGenerated]
		private set
		{
			HBKfdSKvteOpgAqsOhqPMWVvriL = value;
		}
	}

	public string StackTrace
	{
		[CompilerGenerated]
		get
		{
			return sQowvtDRgMxlhiuPQoJfOaBgIeV;
		}
		[CompilerGenerated]
		private set
		{
			sQowvtDRgMxlhiuPQoJfOaBgIeV = value;
		}
	}

	public bool IsAlive
	{
		get
		{
			return Object.IsAlive;
		}
	}

	public HGAmnWxjDYeqMmfyLbiAiQoTXuj(DateTime creationTime, gZHsmLYRWYRWOYtXCrCKGLdQONK comObject, string stackTrace)
	{
		CreationTime = creationTime;
		Object = new WeakReference(comObject, true);
		StackTrace = stackTrace;
	}

	public override string ToString()
	{
		gZHsmLYRWYRWOYtXCrCKGLdQONK gZHsmLYRWYRWOYtXCrCKGLdQONK2 = Object.Target as gZHsmLYRWYRWOYtXCrCKGLdQONK;
		if (gZHsmLYRWYRWOYtXCrCKGLdQONK2 == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", gZHsmLYRWYRWOYtXCrCKGLdQONK2.NativePointer.ToInt64(), gZHsmLYRWYRWOYtXCrCKGLdQONK2.GetType().FullName, CreationTime, StackTrace).AppendLine();
		return stringBuilder.ToString();
	}
}
