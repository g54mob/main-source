using System;

public class MonitorErrorInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public string m_name
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string m_message
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal MonitorErrorInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(MonitorErrorInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~MonitorErrorInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public MonitorErrorInfo(string in_name, string in_message)
	{
	}

	public MonitorErrorInfo(string in_name)
	{
	}

	public MonitorErrorInfo()
	{
	}
}
