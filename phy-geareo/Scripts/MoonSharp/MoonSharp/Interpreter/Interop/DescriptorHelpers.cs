using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MoonSharp.Interpreter.Interop
{
	public static class DescriptorHelpers
	{
		[CompilerGenerated]
		private sealed class _003CGetAllImplementedTypes_003Ed__10 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Type _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Type t;

			public Type _003C_003E3__t;

			private Type _003Cot_003E5__2;

			private Type[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			Type IEnumerator<Type>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetAllImplementedTypes_003Ed__10(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static bool? GetVisibilityFromAttributes(this MemberInfo mi)
		{
			return null;
		}

		public static bool IsDelegateType(this Type t)
		{
			return false;
		}

		public static string GetClrVisibility(this Type type)
		{
			return null;
		}

		public static string GetClrVisibility(this FieldInfo info)
		{
			return null;
		}

		public static string GetClrVisibility(this PropertyInfo info)
		{
			return null;
		}

		public static string GetClrVisibility(this MethodBase info)
		{
			return null;
		}

		public static bool IsPropertyInfoPublic(this PropertyInfo pi)
		{
			return false;
		}

		public static List<string> GetMetaNamesFromAttributes(this MethodInfo mi)
		{
			return null;
		}

		public static Type[] SafeGetTypes(this Assembly asm)
		{
			return null;
		}

		public static string GetConversionMethodName(this Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllImplementedTypes_003Ed__10))]
		public static IEnumerable<Type> GetAllImplementedTypes(this Type t)
		{
			return null;
		}

		public static bool IsValidSimpleIdentifier(string str)
		{
			return false;
		}

		public static string ToValidSimpleIdentifier(string str)
		{
			return null;
		}

		public static string Camelify(string name)
		{
			return null;
		}

		public static string UpperFirstLetter(string name)
		{
			return null;
		}
	}
}
