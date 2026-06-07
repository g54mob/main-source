using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BaseComponent
	{
		protected HandleRef swigCPtr;

		public bool IsDisposed => false;

		internal static BaseComponent CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		public BaseComponent(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		public static HandleRef getCPtr(BaseComponent obj)
		{
			return default(HandleRef);
		}

		~BaseComponent()
		{
		}

		internal static IntPtr GetStaticType()
		{
			return (IntPtr)0;
		}

		internal static IntPtr GetDynamicType(IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		public static IntPtr GetBaseType(IntPtr nativeType)
		{
			return (IntPtr)0;
		}

		internal static void AddReference(IntPtr cPtr)
		{
		}

		internal static void Release(IntPtr cPtr)
		{
		}

		public static int GetNumReferences(IntPtr cPtr)
		{
			return 0;
		}

		internal static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		protected BaseComponent()
		{
		}

		private void Init(IntPtr cPtr, bool cMemoryOwn, bool registerExtend)
		{
		}

		internal static void ForceRelease(object instance, IntPtr cPtr)
		{
		}

		private void ReleaseProxy(IntPtr cPtr)
		{
		}

		protected virtual IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		protected IntPtr CreateExtendCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static IntPtr GetPtr(object instance)
		{
			return (IntPtr)0;
		}

		public static object GetProxy(IntPtr ptr)
		{
			return null;
		}

		public static bool operator ==(BaseComponent a, BaseComponent b)
		{
			return false;
		}

		public static bool operator !=(BaseComponent a, BaseComponent b)
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
	}
}
