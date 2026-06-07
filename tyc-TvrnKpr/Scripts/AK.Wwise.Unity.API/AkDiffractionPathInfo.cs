using System;
using UnityEngine;

public class AkDiffractionPathInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public const uint kMaxNodes = 8u;

	public AkVector64 emitterPos
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkWorldTransform virtualPos
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint nodeCount
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float diffraction
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float transmissionLoss
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float totLength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float obstructionValue
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float occlusionValue
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float gain
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkDiffractionPathInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkDiffractionPathInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkDiffractionPathInfo()
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

	public Vector3 GetNodes(uint idx)
	{
		return default(Vector3);
	}

	public float GetAngles(uint idx)
	{
		return 0f;
	}

	public ulong GetPortals(uint idx)
	{
		return 0uL;
	}

	public ulong GetRooms(uint idx)
	{
		return 0uL;
	}

	public void Clone(AkDiffractionPathInfo other)
	{
	}

	public AkDiffractionPathInfo()
	{
	}
}
