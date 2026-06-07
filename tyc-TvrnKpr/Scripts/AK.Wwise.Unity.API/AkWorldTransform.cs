using System;
using UnityEngine;

public class AkWorldTransform : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkWorldTransform(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkWorldTransform obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkWorldTransform()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkVector64 Position()
	{
		return null;
	}

	public Vector3 OrientationFront()
	{
		return default(Vector3);
	}

	public Vector3 OrientationTop()
	{
		return default(Vector3);
	}

	public void Set(AkVector64 in_position, Vector3 in_orientationFront, Vector3 in_orientationTop)
	{
	}

	public void Set(double in_positionX, double in_positionY, double in_positionZ, float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ)
	{
	}

	public void SetPosition(AkVector64 in_position)
	{
	}

	public void SetPosition(double in_x, double in_y, double in_z)
	{
	}

	public void SetOrientation(Vector3 in_orientationFront, Vector3 in_orientationTop)
	{
	}

	public void SetOrientation(float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ)
	{
	}

	public AkWorldTransform()
	{
	}
}
