using System;
using UnityEngine;

[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
public class AkVertex
{
	private Vector3 Vector;

	public float X
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Y
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Z
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public void Zero()
	{
	}

	public static implicit operator Vector3(AkVertex vector)
	{
		return default(Vector3);
	}

	public AkVertex()
	{
	}

	public AkVertex(float x, float y, float z)
	{
	}

	public void Clear()
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public void Clone(AkVertex other)
	{
	}
}
