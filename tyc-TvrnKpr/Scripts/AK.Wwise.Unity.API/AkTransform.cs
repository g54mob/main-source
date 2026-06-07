using System;
using UnityEngine;

public class AkTransform : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkTransform(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkTransform obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkTransform()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public Vector3 Position()
	{
		return default(Vector3);
	}

	public Vector3 OrientationFront()
	{
		return default(Vector3);
	}

	public Vector3 OrientationTop()
	{
		return default(Vector3);
	}

	public void Set(Vector3 in_position, Vector3 in_orientationFront, Vector3 in_orientationTop)
	{
	}

	public void Set(float in_positionX, float in_positionY, float in_positionZ, float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ)
	{
	}

	public void SetPosition(Vector3 in_position)
	{
	}

	public void SetPosition(float in_x, float in_y, float in_z)
	{
	}

	public void SetOrientation(Vector3 in_orientationFront, Vector3 in_orientationTop)
	{
	}

	public void SetOrientation(float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ)
	{
	}

	public AkTransform()
	{
	}
}
