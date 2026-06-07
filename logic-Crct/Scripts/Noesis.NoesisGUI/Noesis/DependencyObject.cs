using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DependencyObject : DispatcherObject
	{
		private delegate object GetDelegate(IntPtr cPtr, IntPtr dp);

		private delegate void SetDelegate(IntPtr cPtr, IntPtr dp, object value);

		private delegate void NoesisEnumPropertiesCallback(int id, IntPtr dpPtr, IntPtr valPtr);

		private struct EnumPropsInfo
		{
			public EnumDependencyPropertiesDelegate Callback;
		}

		public delegate void DestroyedHandler(IntPtr d);

		internal delegate void RaiseDestroyedCallback(IntPtr cPtr);

		private static Dictionary<Type, GetDelegate> _getFunctions;

		private static Dictionary<Type, SetDelegate> _setFunctions;

		private static NoesisEnumPropertiesCallback _enumProps;

		private static Dictionary<int, EnumPropsInfo> _enumPropsInfo;

		private static RaiseDestroyedCallback _raiseDestroyed;

		internal static Dictionary<long, DestroyedHandler> _Destroyed;

		public bool IsSealed => false;

		public event DestroyedHandler Destroyed
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static DependencyObject CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DependencyObject(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DependencyObject obj)
		{
			return default(HandleRef);
		}

		protected DependencyObject()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public object ReadLocalValue(DependencyProperty dp)
		{
			return null;
		}

		public void InvalidateProperty(DependencyProperty dp)
		{
		}

		public Expression GetExpression(DependencyProperty dp)
		{
			return null;
		}

		public void ClearValue(DependencyProperty dp)
		{
		}

		public void ClearAnimation(DependencyProperty dp)
		{
		}

		public void CoerceValue(DependencyProperty dp)
		{
		}

		private IntPtr ReadLocalValueHelper(DependencyProperty dp)
		{
			return (IntPtr)0;
		}

		public void SetCurrentValue(DependencyProperty dp, object value)
		{
		}

		protected internal void InitObject()
		{
		}

		private void InvalidatePropertyHelper(DependencyProperty dp)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		public object GetValue(DependencyProperty dp)
		{
			return null;
		}

		public void SetValue(DependencyProperty dp, object value)
		{
		}

		private static Dictionary<Type, GetDelegate> CreateGetFunctions()
		{
			return null;
		}

		private static Dictionary<Type, SetDelegate> CreateSetFunctions()
		{
			return null;
		}

		private static void CheckProperty(IntPtr dependencyObject, IntPtr dependencyProperty, string msg)
		{
		}

		public void EnumProperties(EnumDependencyPropertiesDelegate callback)
		{
		}

		[MonoPInvokeCallback(typeof(NoesisEnumPropertiesCallback))]
		private static void OnEnumProperties(int id, IntPtr dpPtr, IntPtr valPtr)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseDestroyedCallback))]
		private static void RaiseDestroyed(IntPtr cPtr)
		{
		}

		[PreserveSig]
		private static extern bool Noesis_DependencyGet_Bool(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern float Noesis_DependencyGet_Float(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern double Noesis_DependencyGet_Double(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern int Noesis_DependencyGet_Int(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern uint Noesis_DependencyGet_UInt(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern short Noesis_DependencyGet_Short(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern ushort Noesis_DependencyGet_UShort(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_String(IntPtr dependencyObject, IntPtr dependencyProperty);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Uri(IntPtr dependencyObject, IntPtr dependencyProperty);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Color(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Point(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Rect(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Int32Rect(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Size(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Thickness(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_CornerRadius(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_TimeSpan(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Duration(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_KeyTime(IntPtr dependencyObject, IntPtr dependencyProperty, bool isNullable, out bool isNull);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_Type(IntPtr dependencyObject, IntPtr dependencyProperty);

		[PreserveSig]
		private static extern IntPtr Noesis_DependencyGet_BaseComponent(IntPtr dependencyObject, IntPtr dependencyProperty);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Bool(IntPtr dependencyObject, IntPtr dependencyProperty, bool val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Float(IntPtr dependencyObject, IntPtr dependencyProperty, float val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Double(IntPtr dependencyObject, IntPtr dependencyProperty, double val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Int(IntPtr dependencyObject, IntPtr dependencyProperty, int val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_UInt(IntPtr dependencyObject, IntPtr dependencyProperty, uint val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Short(IntPtr dependencyObject, IntPtr dependencyProperty, short val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_UShort(IntPtr dependencyObject, IntPtr dependencyProperty, ushort val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_String(IntPtr dependencyObject, IntPtr dependencyProperty, string val);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Uri(IntPtr dependencyObject, IntPtr dependencyProperty, string val);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Color(IntPtr dependencyObject, IntPtr dependencyProperty, ref Color val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Point(IntPtr dependencyObject, IntPtr dependencyProperty, ref Point val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Rect(IntPtr dependencyObject, IntPtr dependencyProperty, ref Rect val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Int32Rect(IntPtr dependencyObject, IntPtr dependencyProperty, ref Int32Rect val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Size(IntPtr dependencyObject, IntPtr dependencyProperty, ref Size val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Thickness(IntPtr dependencyObject, IntPtr dependencyProperty, ref Thickness val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_CornerRadius(IntPtr dependencyObject, IntPtr dependencyProperty, ref CornerRadius val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_TimeSpan(IntPtr dependencyObject, IntPtr dependencyProperty, ref TimeSpanStruct val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Duration(IntPtr dependencyObject, IntPtr dependencyProperty, ref Duration val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_KeyTime(IntPtr dependencyObject, IntPtr dependencyProperty, ref KeyTime val, bool isNullable, bool isNull);

		[PreserveSig]
		private static extern void Noesis_DependencySet_Type(IntPtr dependencyObject, IntPtr dependencyProperty, IntPtr val);

		[PreserveSig]
		private static extern void Noesis_DependencySet_BaseComponent(IntPtr dependencyObject, IntPtr dependencyProperty, IntPtr val);

		[PreserveSig]
		private static extern void Noesis_Dependency_EnumProps(IntPtr dependencyObject, int id, NoesisEnumPropertiesCallback callback);

		[PreserveSig]
		private static extern void Noesis_Dependency_Destroyed_Bind(RaiseDestroyedCallback callback, HandleRef instance);

		[PreserveSig]
		private static extern void Noesis_Dependency_Destroyed_Unbind(RaiseDestroyedCallback callback, HandleRef instance);
	}
}
