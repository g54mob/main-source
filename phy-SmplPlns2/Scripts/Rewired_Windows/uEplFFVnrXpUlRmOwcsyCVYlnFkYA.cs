using System;
using System.Runtime.CompilerServices;

internal class uEplFFVnrXpUlRmOwcsyCVYlnFkYA : IEquatable<uEplFFVnrXpUlRmOwcsyCVYlnFkYA>
{
	private IntPtr gINaKPjJZgrsKLcDkQdkcWujDXpeA;

	public IntPtr JxxdWaDmvgKSCzUIgwOvUOXvmPIeb => gINaKPjJZgrsKLcDkQdkcWujDXpeA;

	public bool ZvqMesFmeReyyefFhWtKYooLbRJo => gINaKPjJZgrsKLcDkQdkcWujDXpeA != IntPtr.Zero;

	public uEplFFVnrXpUlRmOwcsyCVYlnFkYA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		gINaKPjJZgrsKLcDkQdkcWujDXpeA = P_0;
	}

	public virtual bool JyIcveDdIJVpcaFSZGTYJIzFPakO(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is uEplFFVnrXpUlRmOwcsyCVYlnFkYA))
		{
			return false;
		}
		return ((uEplFFVnrXpUlRmOwcsyCVYlnFkYA)P_0).gINaKPjJZgrsKLcDkQdkcWujDXpeA == gINaKPjJZgrsKLcDkQdkcWujDXpeA;
	}

	public virtual int qNhexBaFnNDcuGTNihNMwnutYvawB()
	{
		return base.GetHashCode();
	}

	public bool Equals(uEplFFVnrXpUlRmOwcsyCVYlnFkYA other)
	{
		if (other == null)
		{
			return false;
		}
		return gINaKPjJZgrsKLcDkQdkcWujDXpeA == other.gINaKPjJZgrsKLcDkQdkcWujDXpeA;
	}

	bool IEquatable<uEplFFVnrXpUlRmOwcsyCVYlnFkYA>.Equals(uEplFFVnrXpUlRmOwcsyCVYlnFkYA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool EbTedXFezrlvXFXAYXlDNAUgqJJcA(uEplFFVnrXpUlRmOwcsyCVYlnFkYA P_0, uEplFFVnrXpUlRmOwcsyCVYlnFkYA P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool zSjDmwCgdFOZYcBajLKbFnpOqsVQ(uEplFFVnrXpUlRmOwcsyCVYlnFkYA P_0, uEplFFVnrXpUlRmOwcsyCVYlnFkYA P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return false;
		}
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}
}
