using System;

public class AkImageSourceSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkImageSourceParams params_
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkImageSourceSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkImageSourceSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkImageSourceSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkImageSourceSettings()
	{
	}

	public AkImageSourceSettings(AkVector64 in_sourcePosition, float in_fDistanceScalingFactor, float in_fLevel)
	{
	}

	public void SetOneTexture(uint in_texture)
	{
	}
}
