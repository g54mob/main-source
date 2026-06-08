using System;

namespace MoonSharp.Interpreter.Interop.LuaStateInterop
{
	public class CharPtr
	{
		public char[] chars;

		public int index;

		public char this[int offset]
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public char this[uint offset]
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public char this[long offset]
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public static implicit operator CharPtr(string str)
		{
			return null;
		}

		public static implicit operator CharPtr(char[] chars)
		{
			return null;
		}

		public static implicit operator CharPtr(byte[] bytes)
		{
			return null;
		}

		public CharPtr()
		{
		}

		public CharPtr(string str)
		{
		}

		public CharPtr(CharPtr ptr)
		{
		}

		public CharPtr(CharPtr ptr, int index)
		{
		}

		public CharPtr(char[] chars)
		{
		}

		public CharPtr(char[] chars, int index)
		{
		}

		public CharPtr(byte[] bytes)
		{
		}

		public CharPtr(IntPtr ptr)
		{
		}

		public static CharPtr operator +(CharPtr ptr, int offset)
		{
			return null;
		}

		public static CharPtr operator -(CharPtr ptr, int offset)
		{
			return null;
		}

		public static CharPtr operator +(CharPtr ptr, uint offset)
		{
			return null;
		}

		public static CharPtr operator -(CharPtr ptr, uint offset)
		{
			return null;
		}

		public void inc()
		{
		}

		public void dec()
		{
		}

		public CharPtr next()
		{
			return null;
		}

		public CharPtr prev()
		{
			return null;
		}

		public CharPtr add(int ofs)
		{
			return null;
		}

		public CharPtr sub(int ofs)
		{
			return null;
		}

		public static bool operator ==(CharPtr ptr, char ch)
		{
			return false;
		}

		public static bool operator ==(char ch, CharPtr ptr)
		{
			return false;
		}

		public static bool operator !=(CharPtr ptr, char ch)
		{
			return false;
		}

		public static bool operator !=(char ch, CharPtr ptr)
		{
			return false;
		}

		public static CharPtr operator +(CharPtr ptr1, CharPtr ptr2)
		{
			return null;
		}

		public static int operator -(CharPtr ptr1, CharPtr ptr2)
		{
			return 0;
		}

		public static bool operator <(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public static bool operator <=(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public static bool operator >(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public static bool operator >=(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public static bool operator ==(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public static bool operator !=(CharPtr ptr1, CharPtr ptr2)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(int length)
		{
			return null;
		}
	}
}
