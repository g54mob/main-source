using System;

public class AkResourceMonitorDataSummary : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float totalCPU
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float pluginCPU
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint physicalVoices
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint virtualVoices
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint totalVoices
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint nbActiveEvents
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkResourceMonitorDataSummary(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkResourceMonitorDataSummary obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkResourceMonitorDataSummary()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkResourceMonitorDataSummary()
	{
	}
}
