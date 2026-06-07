using System;
using UnityEngine;

public class AkGeometryInstanceParams : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkWorldTransform PositionAndOrientation
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Vector3 Scale
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public bool UseForReflectionAndDiffraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool BypassPortalSubtraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsSolid
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkGeometryInstanceParams(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkGeometryInstanceParams obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkGeometryInstanceParams()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkGeometryInstanceParams()
	{
	}
}
