using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk;
using LitJson;

namespace Gh
{
	[Serializable]
	public sealed class DataStore : IDataStore
	{
		[CompilerGenerated]
		private sealed class _003CGetAllPropertyAndFieldValuesToPersist_003Ed__19 : IEnumerable<Tuple<string, object>>, IEnumerable, IEnumerator<Tuple<string, object>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Tuple<string, object> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private object o;

			public object _003C_003E3__o;

			private Type _003Ctype_003E5__2;

			private Dictionary<string, SaveLoadExtensions.DetailedPropertyInfo>.ValueCollection.Enumerator _003C_003E7__wrap2;

			private Dictionary<string, SaveLoadExtensions.DetailedFieldInfo>.ValueCollection.Enumerator _003C_003E7__wrap3;

			Tuple<string, object> IEnumerator<Tuple<string, object>>.Current
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
			public _003CGetAllPropertyAndFieldValuesToPersist_003Ed__19(int _003C_003E1__state)
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
			IEnumerator<Tuple<string, object>> IEnumerable<Tuple<string, object>>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private JsonData _jsonData;

		internal Dictionary<string, object> _dict;

		public DataStore()
		{
		}

		internal DataStore(Dictionary<string, object> data)
		{
		}

		internal DataStore(JsonData data)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public void WriteToJson(JsonWriter writer)
		{
		}

		public bool HasValue(string key)
		{
			return false;
		}

		public void SetValue(string key, object value)
		{
		}

		public T GetValue<T>(string key)
		{
			return default(T);
		}

		public T GetOrSetValue<T>(string key, T fallback)
		{
			return default(T);
		}

		public void RemoveValue(string key)
		{
		}

		private void TryLoadKeyFromJson<T>(string key)
		{
		}

		public void MergeData(DataStore dataStore, bool overrideExisting = false, Func<string, bool> keyFilter = null)
		{
		}

		private IList CopyIList(IList data)
		{
			return null;
		}

		public IDataStore CreateSubEntry(string key)
		{
			return null;
		}

		public DataStore(object o)
		{
		}

		public void FillFromObject(object o)
		{
		}

		private static object GetReferenceValue(object value)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllPropertyAndFieldValuesToPersist_003Ed__19))]
		private static IEnumerable<Tuple<string, object>> GetAllPropertyAndFieldValuesToPersist(object o)
		{
			return null;
		}

		public DataStore CloneSlow()
		{
			return null;
		}
	}
}
