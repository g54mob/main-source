using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class QMkQwacWarHtMonSPhuPjiyaJAxp
{
	public IntPtr WcknYZiOcjodZwGlUWBohoXWTjjd;

	public QMkQwacWarHtMonSPhuPjiyaJAxp(IntPtr P_0)
	{
		WcknYZiOcjodZwGlUWBohoXWTjjd = P_0;
	}

	public unsafe QMkQwacWarHtMonSPhuPjiyaJAxp(void* P_0)
	{
		WcknYZiOcjodZwGlUWBohoXWTjjd = new IntPtr(P_0);
	}

	[SpecialName]
	public static IntPtr MYOcrFCJAoRyFWUoNNduHXpaPYpMA(QMkQwacWarHtMonSPhuPjiyaJAxp P_0)
	{
		return P_0.WcknYZiOcjodZwGlUWBohoXWTjjd;
	}

	[SpecialName]
	public static QMkQwacWarHtMonSPhuPjiyaJAxp JjYcZUqsaxAJvFBbygzuvbWczuCqA(IntPtr P_0)
	{
		return new QMkQwacWarHtMonSPhuPjiyaJAxp(P_0);
	}

	[SpecialName]
	public unsafe static void* rirRGsTvuiFgZKPnaBHsKNuoRZct(QMkQwacWarHtMonSPhuPjiyaJAxp P_0)
	{
		return (void*)P_0.WcknYZiOcjodZwGlUWBohoXWTjjd;
	}

	[SpecialName]
	public unsafe static QMkQwacWarHtMonSPhuPjiyaJAxp qgSZpgeVtkLSomznKRDUQdVISjMg(void* P_0)
	{
		return new QMkQwacWarHtMonSPhuPjiyaJAxp(P_0);
	}

	public virtual string AesvkwmAWBALiaiFiAvahKLyKMUe()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", WcknYZiOcjodZwGlUWBohoXWTjjd);
	}

	public string rnrZbjWUhSBvVzUFuFCcpFNJTNMw(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", WcknYZiOcjodZwGlUWBohoXWTjjd.ToString(P_0));
	}

	public virtual int VstcoVloHZiHGQIlFtGKGLGJhUUU()
	{
		return WcknYZiOcjodZwGlUWBohoXWTjjd.ToInt32();
	}

	public bool reujuGfYWlDieaLzaXyrilokdtyqB(QMkQwacWarHtMonSPhuPjiyaJAxp P_0)
	{
		return WcknYZiOcjodZwGlUWBohoXWTjjd == P_0.WcknYZiOcjodZwGlUWBohoXWTjjd;
	}

	public virtual bool SPZcJceGvNuOqruqJbclVYlzcyBnA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(QMkQwacWarHtMonSPhuPjiyaJAxp))
		{
			return false;
		}
		return reujuGfYWlDieaLzaXyrilokdtyqB((QMkQwacWarHtMonSPhuPjiyaJAxp)P_0);
	}
}
