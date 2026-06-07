using System;
using FractureField;

namespace Reactivity
{
	public class CInt : Computed<int>
	{
		public CInt(Func<int> getter)
			: base((Func<int>)null)
		{
		}

		public string Format(FormatOptions options = null)
		{
			return null;
		}

		public static bool operator >(CInt a, RInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, CInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, RFloat b)
		{
			return false;
		}

		public static bool operator >(CInt a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CInt a, RLong b)
		{
			return false;
		}

		public static bool operator >(CInt a, CLong b)
		{
			return false;
		}

		public static bool operator <(CInt a, RInt b)
		{
			return false;
		}

		public static bool operator <(CInt a, CInt b)
		{
			return false;
		}

		public static bool operator <(CInt a, RFloat b)
		{
			return false;
		}

		public static bool operator <(CInt a, CFloat b)
		{
			return false;
		}

		public static bool operator <(CInt a, RLong b)
		{
			return false;
		}

		public static bool operator <(CInt a, CLong b)
		{
			return false;
		}

		public static bool operator >=(CInt a, RInt b)
		{
			return false;
		}

		public static bool operator >=(CInt a, CInt b)
		{
			return false;
		}

		public static bool operator >=(CInt a, RFloat b)
		{
			return false;
		}

		public static bool operator >=(CInt a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(CInt a, RLong b)
		{
			return false;
		}

		public static bool operator >=(CInt a, CLong b)
		{
			return false;
		}

		public static bool operator <=(CInt a, RInt b)
		{
			return false;
		}

		public static bool operator <=(CInt a, CInt b)
		{
			return false;
		}

		public static bool operator <=(CInt a, RFloat b)
		{
			return false;
		}

		public static bool operator <=(CInt a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(CInt a, RLong b)
		{
			return false;
		}

		public static bool operator <=(CInt a, CLong b)
		{
			return false;
		}

		public static bool operator >(CInt a, float b)
		{
			return false;
		}

		public static bool operator <(CInt a, float b)
		{
			return false;
		}

		public static bool operator >=(CInt a, float b)
		{
			return false;
		}

		public static bool operator <=(CInt a, float b)
		{
			return false;
		}

		public static bool operator >(float a, CInt b)
		{
			return false;
		}

		public static bool operator <(float a, CInt b)
		{
			return false;
		}

		public static bool operator >=(float a, CInt b)
		{
			return false;
		}

		public static bool operator <=(float a, CInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, int b)
		{
			return false;
		}

		public static bool operator <(CInt a, int b)
		{
			return false;
		}

		public static bool operator >=(CInt a, int b)
		{
			return false;
		}

		public static bool operator <=(CInt a, int b)
		{
			return false;
		}

		public static bool operator >(int a, CInt b)
		{
			return false;
		}

		public static bool operator <(int a, CInt b)
		{
			return false;
		}

		public static bool operator >=(int a, CInt b)
		{
			return false;
		}

		public static bool operator <=(int a, CInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, long b)
		{
			return false;
		}

		public static bool operator <(CInt a, long b)
		{
			return false;
		}

		public static bool operator >=(CInt a, long b)
		{
			return false;
		}

		public static bool operator <=(CInt a, long b)
		{
			return false;
		}

		public static bool operator >(long a, CInt b)
		{
			return false;
		}

		public static bool operator <(long a, CInt b)
		{
			return false;
		}

		public static bool operator >=(long a, CInt b)
		{
			return false;
		}

		public static bool operator <=(long a, CInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, double b)
		{
			return false;
		}

		public static bool operator <(CInt a, double b)
		{
			return false;
		}

		public static bool operator >=(CInt a, double b)
		{
			return false;
		}

		public static bool operator <=(CInt a, double b)
		{
			return false;
		}

		public static bool operator >(double a, CInt b)
		{
			return false;
		}

		public static bool operator <(double a, CInt b)
		{
			return false;
		}

		public static bool operator >=(double a, CInt b)
		{
			return false;
		}

		public static bool operator <=(double a, CInt b)
		{
			return false;
		}

		public static bool operator >(CInt a, decimal b)
		{
			return false;
		}

		public static bool operator <(CInt a, decimal b)
		{
			return false;
		}

		public static bool operator >=(CInt a, decimal b)
		{
			return false;
		}

		public static bool operator <=(CInt a, decimal b)
		{
			return false;
		}

		public static bool operator >(decimal a, CInt b)
		{
			return false;
		}

		public static bool operator <(decimal a, CInt b)
		{
			return false;
		}

		public static bool operator >=(decimal a, CInt b)
		{
			return false;
		}

		public static bool operator <=(decimal a, CInt b)
		{
			return false;
		}
	}
}
