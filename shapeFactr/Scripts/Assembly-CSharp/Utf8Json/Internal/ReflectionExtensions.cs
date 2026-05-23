using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Utf8Json.Internal
{
	internal static class ReflectionExtensions
	{
		[CompilerGenerated]
		private sealed class _003CGetAllFieldsCore_003Ed__6 : IEnumerable<FieldInfo>, IEnumerable, IEnumerator<FieldInfo>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private FieldInfo _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Type type;

			public Type _003C_003E3__type;

			private HashSet<string> nameCheck;

			public HashSet<string> _003C_003E3__nameCheck;

			private IEnumerator<FieldInfo> _003C_003E7__wrap1;

			FieldInfo IEnumerator<FieldInfo>.Current
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
			public _003CGetAllFieldsCore_003Ed__6(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<FieldInfo> IEnumerable<FieldInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAllPropertiesCore_003Ed__4 : IEnumerable<PropertyInfo>, IEnumerable, IEnumerator<PropertyInfo>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private PropertyInfo _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Type type;

			public Type _003C_003E3__type;

			private HashSet<string> nameCheck;

			public HashSet<string> _003C_003E3__nameCheck;

			private IEnumerator<PropertyInfo> _003C_003E7__wrap1;

			PropertyInfo IEnumerator<PropertyInfo>.Current
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
			public _003CGetAllPropertiesCore_003Ed__4(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<PropertyInfo> IEnumerable<PropertyInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static bool IsNullable(this TypeInfo type)
		{
			return false;
		}

		public static bool IsPublic(this TypeInfo type)
		{
			return false;
		}

		public static bool IsAnonymous(this TypeInfo type)
		{
			return false;
		}

		public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllPropertiesCore_003Ed__4))]
		private static IEnumerable<PropertyInfo> GetAllPropertiesCore(Type type, HashSet<string> nameCheck)
		{
			return null;
		}

		public static IEnumerable<FieldInfo> GetAllFields(this Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllFieldsCore_003Ed__6))]
		private static IEnumerable<FieldInfo> GetAllFieldsCore(Type type, HashSet<string> nameCheck)
		{
			return null;
		}
	}
}
