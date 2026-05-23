using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct BicPxZfWIPNacckpNSxKcxfbKgVe : IEquatable<BicPxZfWIPNacckpNSxKcxfbKgVe>
{
	private int dynXgnhpIaYlXIfpfzzMjbyXSDGf;

	public BicPxZfWIPNacckpNSxKcxfbKgVe(bool P_0)
	{
		dynXgnhpIaYlXIfpfzzMjbyXSDGf = (P_0 ? 1 : 0);
	}

	public bool Equals(BicPxZfWIPNacckpNSxKcxfbKgVe other)
	{
		return dynXgnhpIaYlXIfpfzzMjbyXSDGf == other.dynXgnhpIaYlXIfpfzzMjbyXSDGf;
	}

	bool IEquatable<BicPxZfWIPNacckpNSxKcxfbKgVe>.Equals(BicPxZfWIPNacckpNSxKcxfbKgVe other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool hOzikrPCKbLUmabguSOzxwOibsrq(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is BicPxZfWIPNacckpNSxKcxfbKgVe)
		{
			return Equals((BicPxZfWIPNacckpNSxKcxfbKgVe)P_0);
		}
		return false;
	}

	public int OeIOaHbJgFpynAkiFQWWuIBWzJcK()
	{
		return dynXgnhpIaYlXIfpfzzMjbyXSDGf;
	}

	[SpecialName]
	public static bool djmjBYcgSBvPAbNpLkCORNxbblXr(BicPxZfWIPNacckpNSxKcxfbKgVe P_0, BicPxZfWIPNacckpNSxKcxfbKgVe P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool TDWLLbpBGlMkdWIrPreUfnjdjTok(BicPxZfWIPNacckpNSxKcxfbKgVe P_0, BicPxZfWIPNacckpNSxKcxfbKgVe P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool yXvrBeVlsOTBNQbJXTTtRJxFyGrX(BicPxZfWIPNacckpNSxKcxfbKgVe P_0)
	{
		return P_0.dynXgnhpIaYlXIfpfzzMjbyXSDGf != 0;
	}

	[SpecialName]
	public static BicPxZfWIPNacckpNSxKcxfbKgVe dTZbXfxUPhlbXNpjTofmRqALgPrFA(bool P_0)
	{
		return new BicPxZfWIPNacckpNSxKcxfbKgVe(P_0);
	}

	public string aJfglbfiTgSDrcJIfNtTpvuqEAjY()
	{
		return $"{dynXgnhpIaYlXIfpfzzMjbyXSDGf != 0}";
	}
}
