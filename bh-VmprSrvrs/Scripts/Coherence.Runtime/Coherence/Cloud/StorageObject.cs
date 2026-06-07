using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal sealed class StorageObject : ICollection<StorageItem>, IEnumerable<StorageItem>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CCoherence_002DCloud_002DStorageItem_003E_002DGetEnumerator_003Ed__52 : IEnumerator<StorageItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private StorageItem _003C_003E2__current;

			public StorageObject _003C_003E4__this;

			private Dictionary<Key, Value>.Enumerator _003C_003E7__wrap1;

			StorageItem IEnumerator<StorageItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(StorageItem);
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
			public _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CCoherence_002DCloud_002DStorageItem_003E_002DGetEnumerator_003Ed__52(int _003C_003E1__state)
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
		}

		[CompilerGenerated]
		private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StorageObject _003C_003E4__this;

			private Dictionary<Key, Value>.Enumerator _003C_003E7__wrap1;

			object IEnumerator<object>.Current
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
			public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__53(int _003C_003E1__state)
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
		}

		internal static readonly JsonConverter[] jsonConverters;

		private readonly Dictionary<Key, Value> dictionary;

		private object @object;

		private Type objectType;

		public StorageObjectId ObjectId { get; }

		public object Object => null;

		public Type ObjectType => null;

		public int Count => 0;

		public Dictionary<Key, Value>.KeyCollection Keys => null;

		public Dictionary<Key, Value>.ValueCollection Values => null;

		public Value this[Key key]
		{
			get
			{
				return default(Value);
			}
			set
			{
			}
		}

		bool ICollection<StorageItem>.IsReadOnly => false;

		public bool TryGetObject<TObject>([MaybeNull] out TObject result)
		{
			result = default(TObject);
			return false;
		}

		public StorageObject(StorageObjectId objectId)
		{
		}

		public StorageObject(StorageObjectId objectId, object @object, Type objectType)
		{
		}

		public StorageObject(StorageObjectId objectId, IEnumerable<StorageItem> items)
		{
		}

		public StorageObject(StorageObjectId objectId, params StorageItem[] items)
		{
		}

		internal static bool From<TObject>(StorageObjectId objectId, StorageObjectMutationType mutationType, TObject @object, [MaybeNullWhen(false)][NotNullWhen(true)] out StorageObject storageObject, [MaybeNullWhen(true)][NotNullWhen(false)] out StorageException exception)
		{
			storageObject = null;
			exception = null;
			return false;
		}

		internal static bool To<TObject>(StorageObject storageObject, [MaybeNull] out TObject @object, [MaybeNullWhen(true)][NotNullWhen(false)] out StorageException exception)
		{
			@object = default(TObject);
			exception = null;
			return false;
		}

		public bool ContainsKey(Key key)
		{
			return false;
		}

		public bool Contains(StorageItem item)
		{
			return false;
		}

		public bool TryGetValue(Key key, out Value value)
		{
			value = default(Value);
			return false;
		}

		public bool TryGetValue(Key key, out bool value)
		{
			value = default(bool);
			return false;
		}

		public bool TryGetValue(Key key, out int value)
		{
			value = default(int);
			return false;
		}

		public bool TryGetValue<TValue>(Key key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TryGetValue(Key key, out string value)
		{
			value = null;
			return false;
		}

		public bool TryGetValue(Key key, out float value)
		{
			value = default(float);
			return false;
		}

		public bool TryGetValue(Key key, out double value)
		{
			value = default(double);
			return false;
		}

		public bool TryGetValue(Key key, out short value)
		{
			value = default(short);
			return false;
		}

		public bool TryGetValue(Key key, out byte value)
		{
			value = default(byte);
			return false;
		}

		public bool TryGetValue(Key key, out Enum value)
		{
			value = null;
			return false;
		}

		public void Clear()
		{
		}

		public bool Remove(Key key)
		{
			return false;
		}

		public bool Remove(StorageItem item)
		{
			return false;
		}

		public int RemoveItems([DisallowNull] IEnumerable<Key> keys)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] IEnumerable<StorageItem> items)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] params Key[] keys)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] params StorageItem[] items)
		{
			return 0;
		}

		public void SetItems([DisallowNull] IEnumerable<StorageItem> items)
		{
		}

		public void SetItems([DisallowNull] IEnumerable<KeyValuePair<Key, Value>> items)
		{
		}

		public void SetItems([DisallowNull] IEnumerable<KeyValuePair<string, string>> items)
		{
		}

		public void SetItems([DisallowNull] params StorageItem[] items)
		{
		}

		public void Set(StorageItem item)
		{
		}

		public void Set(Key key, Value value)
		{
		}

		[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CCoherence_002DCloud_002DStorageItem_003E_002DGetEnumerator_003Ed__52))]
		IEnumerator<StorageItem> IEnumerable<StorageItem>.GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__53))]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		void ICollection<StorageItem>.Add(StorageItem item)
		{
		}

		void ICollection<StorageItem>.CopyTo(StorageItem[] array, int arrayIndex)
		{
		}

		private static string ToString(Type type)
		{
			return null;
		}
	}
}
