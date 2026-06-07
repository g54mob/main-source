using System;
using UnityEngine;

public class AkReflectionPathInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkVector64 imageSource
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint numPathPoints
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint numReflections
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float level
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool isOccluded
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkReflectionPathInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkReflectionPathInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkReflectionPathInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public Vector3 GetPathPoint(uint idx)
	{
		return default(Vector3);
	}

	public uint GetTextureIDs(uint idx)
	{
		return 0u;
	}

	public float GetDiffraction(uint idx)
	{
		return 0f;
	}

	public void Clone(AkReflectionPathInfo other)
	{
	}

	public AkReflectionPathInfo()
	{
	}
}
