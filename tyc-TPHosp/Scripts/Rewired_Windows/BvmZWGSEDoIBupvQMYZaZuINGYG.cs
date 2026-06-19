using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class BvmZWGSEDoIBupvQMYZaZuINGYG
{
	[CompilerGenerated]
	private DateTime jcvnYJRwyXUeUuOqaTFtvnPkvie;

	[CompilerGenerated]
	private WeakReference LFiXHClPlOQKAZMODsAzvqhnFhs;

	[CompilerGenerated]
	private string oWYDKxGmeqMKHitlEPUZelxRmLkl;

	public DateTime CreationTime
	{
		[CompilerGenerated]
		get
		{
			return jcvnYJRwyXUeUuOqaTFtvnPkvie;
		}
		[CompilerGenerated]
		private set
		{
			jcvnYJRwyXUeUuOqaTFtvnPkvie = value;
		}
	}

	public WeakReference Object
	{
		[CompilerGenerated]
		get
		{
			return LFiXHClPlOQKAZMODsAzvqhnFhs;
		}
		[CompilerGenerated]
		private set
		{
			LFiXHClPlOQKAZMODsAzvqhnFhs = value;
		}
	}

	public string StackTrace
	{
		[CompilerGenerated]
		get
		{
			return oWYDKxGmeqMKHitlEPUZelxRmLkl;
		}
		[CompilerGenerated]
		private set
		{
			oWYDKxGmeqMKHitlEPUZelxRmLkl = value;
		}
	}

	public bool IsAlive => Object.IsAlive;

	public BvmZWGSEDoIBupvQMYZaZuINGYG(DateTime creationTime, gEzWBZtKpodhyJneHyYqvTiSSEh comObject, string stackTrace)
	{
		CreationTime = creationTime;
		Object = new WeakReference(comObject, trackResurrection: true);
		StackTrace = stackTrace;
	}

	public override string ToString()
	{
		if (!(Object.Target is gEzWBZtKpodhyJneHyYqvTiSSEh gEzWBZtKpodhyJneHyYqvTiSSEh2))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", gEzWBZtKpodhyJneHyYqvTiSSEh2.NativePointer.ToInt64(), gEzWBZtKpodhyJneHyYqvTiSSEh2.GetType().FullName, CreationTime, StackTrace).AppendLine();
		return stringBuilder.ToString();
	}
}
