using System;
using FractureField;

namespace Reactivity
{
	public class CFloat : Computed<float>
	{
		public CFloat(Func<float> getter)
			: base((Func<float>)null)
		{
		}

		public string Format(FormatOptions options = null)
		{
			return null;
		}

		public static bool operator >(CFloat a, RInt b)
		{
			return false;
		}

		public static bool operator >(CFloat a, CInt b)
		{
			return false;
		}

		public static bool operator >(CFloat a, RFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, RLong b)
		{
			return false;
		}

		public static bool operator >(CFloat a, CLong b)
		{
			return false;
		}

		public static bool operator <(CFloat a, RInt b)
		{
			return false;
		}

		public static bool operator <(CFloat a, CInt b)
		{
			return false;
		}

		public static bool operator <(CFloat a, RFloat b)
		{
			return false;
		}

		public static bool operator <(CFloat a, CFloat b)
		{
			return false;
		}

		public static bool operator <(CFloat a, RLong b)
		{
			return false;
		}

		public static bool operator <(CFloat a, CLong b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, RInt b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, CInt b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, RFloat b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, RLong b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, CLong b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, RInt b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, CInt b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, RFloat b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, RLong b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, CLong b)
		{
			return false;
		}

		public static bool operator >(CFloat a, float b)
		{
			return false;
		}

		public static bool operator <(CFloat a, float b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, float b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, float b)
		{
			return false;
		}

		public static bool operator >(float a, CFloat b)
		{
			return false;
		}

		public static bool operator <(float a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(float a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(float a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, int b)
		{
			return false;
		}

		public static bool operator <(CFloat a, int b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, int b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, int b)
		{
			return false;
		}

		public static bool operator >(int a, CFloat b)
		{
			return false;
		}

		public static bool operator <(int a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(int a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(int a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, long b)
		{
			return false;
		}

		public static bool operator <(CFloat a, long b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, long b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, long b)
		{
			return false;
		}

		public static bool operator >(long a, CFloat b)
		{
			return false;
		}

		public static bool operator <(long a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(long a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(long a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, double b)
		{
			return false;
		}

		public static bool operator <(CFloat a, double b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, double b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, double b)
		{
			return false;
		}

		public static bool operator >(double a, CFloat b)
		{
			return false;
		}

		public static bool operator <(double a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(double a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(double a, CFloat b)
		{
			return false;
		}

		public static bool operator >(CFloat a, decimal b)
		{
			return false;
		}

		public static bool operator <(CFloat a, decimal b)
		{
			return false;
		}

		public static bool operator >=(CFloat a, decimal b)
		{
			return false;
		}

		public static bool operator <=(CFloat a, decimal b)
		{
			return false;
		}

		public static bool operator >(decimal a, CFloat b)
		{
			return false;
		}

		public static bool operator <(decimal a, CFloat b)
		{
			return false;
		}

		public static bool operator >=(decimal a, CFloat b)
		{
			return false;
		}

		public static bool operator <=(decimal a, CFloat b)
		{
			return false;
		}
	}
}
