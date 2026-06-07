using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout((LayoutKind)0)]
public class AkVector64
{
	public double X;

	public double Y;

	public double Z;

	public void Zero()
	{
	}

	public static implicit operator AkVector64(Vector3 vector)
	{
		return null;
	}
}
