using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Sirenix.Serialization.Utilities;

namespace Sirenix.Serialization
{
	public static class FormatterLocator
	{
		private struct FormatterInfo
		{
			public Type FormatterType;

			public Type TargetType;

			public Type WeakFallbackType;

			public bool AskIfCanFormatTypes;

			public int Priority;
		}

		private struct FormatterLocatorInfo
		{
			public IFormatterLocator LocatorInstance;

			public int Priority;
		}

		[CompilerGenerated]
		private sealed class _003CGetAllPossibleMissingAOTTypes_003Ed__17 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Type type;

			public Type _003C_003E3__type;

			private Type[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private Type _003Carg_003E5__4;

			private IEnumerator<string> _003C_003E7__wrap4;

			string IEnumerator<string>.Current
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
			public _003CGetAllPossibleMissingAOTTypes_003Ed__17(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static readonly object StrongFormatters_LOCK;

		private static readonly object WeakFormatters_LOCK;

		private static readonly Dictionary<Type, IFormatter> FormatterInstances;

		private static readonly DoubleLookupDictionary<Type, ISerializationPolicy, IFormatter> StrongTypeFormatterMap;

		private static readonly DoubleLookupDictionary<Type, ISerializationPolicy, IFormatter> WeakTypeFormatterMap;

		private static readonly List<FormatterLocatorInfo> FormatterLocators;

		private static readonly List<FormatterInfo> FormatterInfos;

		[Obsolete("Use the new IFormatterLocator interface instead, and register your custom locator with the RegisterFormatterLocator assembly attribute.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static event Func<Type, IFormatter> FormatterResolve
		{
			add
			{
			}
			remove
			{
			}
		}

		static FormatterLocator()
		{
		}

		public static IFormatter<T> GetFormatter<T>(ISerializationPolicy policy)
		{
			return null;
		}

		public static IFormatter GetFormatter(Type type, ISerializationPolicy policy)
		{
			return null;
		}

		public static IFormatter GetFormatter(Type type, ISerializationPolicy policy, bool allowWeakFallbackFormatters)
		{
			return null;
		}

		private static void LogAOTError(Type type, Exception ex)
		{
		}

		[IteratorStateMachine(typeof(_003CGetAllPossibleMissingAOTTypes_003Ed__17))]
		private static IEnumerable<string> GetAllPossibleMissingAOTTypes(Type type)
		{
			return null;
		}

		internal static List<IFormatter> GetAllCompatiblePredefinedFormatters(Type type, ISerializationPolicy policy)
		{
			return null;
		}

		private static IFormatter CreateFormatter(Type type, ISerializationPolicy policy, bool allowWeakFormatters)
		{
			return null;
		}

		private static IFormatter GetFormatterInstance(Type type)
		{
			return null;
		}
	}
}
