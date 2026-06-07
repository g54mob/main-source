using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sirenix.Serialization
{
	public static class DictionaryKeyUtility
	{
		private class UnityObjectKeyComparer<T> : IComparer<T>
		{
			public int Compare(T x, T y)
			{
				return 0;
			}
		}

		private class FallbackKeyComparer<T> : IComparer<T>
		{
			public int Compare(T x, T y)
			{
				return 0;
			}
		}

		public class KeyComparer<T> : IComparer<T>
		{
			public static readonly KeyComparer<T> Default;

			private readonly IComparer<T> actualComparer;

			public int Compare(T x, T y)
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetPersistentPathKeyTypes_003Ed__14 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private Type _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private HashSet<Type>.Enumerator _003C_003E7__wrap1;

			private Dictionary<Type, IDictionaryKeyPathProvider>.KeyCollection.Enumerator _003C_003E7__wrap2;

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
			public _003CGetPersistentPathKeyTypes_003Ed__14(int _003C_003E1__state)
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

		private static readonly Dictionary<Type, bool> GetSupportedDictionaryKeyTypesResults;

		private static readonly HashSet<Type> BaseSupportedDictionaryKeyTypes;

		private static readonly HashSet<char> AllowedSpecialKeyStrChars;

		private static readonly Dictionary<Type, IDictionaryKeyPathProvider> TypeToKeyPathProviders;

		private static readonly Dictionary<string, IDictionaryKeyPathProvider> IDToKeyPathProviders;

		private static readonly Dictionary<IDictionaryKeyPathProvider, string> ProviderToID;

		private static readonly Dictionary<object, string> ObjectsToTempKeys;

		private static readonly Dictionary<string, object> TempKeysToObjects;

		private static long tempKeyCounter;

		static DictionaryKeyUtility()
		{
		}

		private static void LogInvalidKeyPathProvider(Type type, Assembly assembly, string reason)
		{
		}

		[IteratorStateMachine(typeof(_003CGetPersistentPathKeyTypes_003Ed__14))]
		public static IEnumerable<Type> GetPersistentPathKeyTypes()
		{
			return null;
		}

		public static bool KeyTypeSupportsPersistentPaths(Type type)
		{
			return false;
		}

		private static bool PrivateIsSupportedDictionaryKeyType(Type type)
		{
			return false;
		}

		public static string GetDictionaryKeyString(object key)
		{
			return null;
		}

		public static object GetDictionaryKeyValue(string keyStr, Type expectedType)
		{
			return null;
		}

		private static string FromTo(this string str, int from, int to)
		{
			return null;
		}
	}
}
