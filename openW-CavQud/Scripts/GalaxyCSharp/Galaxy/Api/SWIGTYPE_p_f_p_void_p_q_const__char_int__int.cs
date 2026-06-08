using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class SWIGTYPE_p_f_p_void_p_q_const__char_int__int
	{
		private HandleRef swigCPtr;

		internal SWIGTYPE_p_f_p_void_p_q_const__char_int__int(IntPtr cPtr, bool futureUse)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		protected SWIGTYPE_p_f_p_void_p_q_const__char_int__int()
		{
			swigCPtr = new HandleRef(null, IntPtr.Zero);
		}

		internal static HandleRef getCPtr(SWIGTYPE_p_f_p_void_p_q_const__char_int__int obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}
	}
}
