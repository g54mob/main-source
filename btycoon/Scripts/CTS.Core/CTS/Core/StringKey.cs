using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	public struct StringKey : IEquatable<StringKey>, IEquatable<uint>, IEquatable<string>, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal string _stringKey;

		[SerializeField]
		internal ScriptableStringKey _scriptable;

		[SerializeField]
		internal bool _useScriptable;

		private uint? _id;

		public uint Id
		{
			get
			{
				uint? id = _id;
				if (!id.HasValue)
				{
					_id = StringKeyBehaviour.GetID(ref _stringKey);
					return _id.Value;
				}
				return _id.Value;
			}
		}

		public bool IsValid()
		{
			return Id != 0;
		}

		public void AssertKeyValidity()
		{
			if (!IsValid())
			{
				throw new Exception("Key is not valid.");
			}
		}

		private StringKey(bool useScriptable, ScriptableStringKey scriptable, string stringKey)
		{
			_useScriptable = useScriptable;
			_scriptable = scriptable;
			_stringKey = stringKey;
			_id = StringKeyBehaviour.GetID(ref _stringKey);
		}

		private StringKey(bool useScriptable, ScriptableStringKey scriptable, string stringKey, uint id)
		{
			_useScriptable = useScriptable;
			_scriptable = scriptable;
			_stringKey = stringKey;
			_id = id;
		}

		public StringKey(string key)
			: this(useScriptable: false, null, key)
		{
		}

		public StringKey(StringKey<ScriptableStringKey> other)
			: this(other._useScriptable, other._scriptable, other._stringKey, other.Id)
		{
		}

		public StringKey(ScriptableStringKey scriptable)
		{
			_useScriptable = true;
			_scriptable = scriptable;
			if (_scriptable == null)
			{
				_stringKey = null;
				_id = null;
			}
			else
			{
				_stringKey = scriptable._stringKey._stringKey;
				_id = scriptable._stringKey.Id;
			}
		}

		public static implicit operator uint(StringKey key)
		{
			return key.Id;
		}

		public static implicit operator string(StringKey key)
		{
			return key._stringKey;
		}

		public static implicit operator StringKey(string key)
		{
			return new StringKey(key);
		}

		public static implicit operator StringKey(ScriptableStringKey key)
		{
			return key._stringKey;
		}

		public static bool operator ==(StringKey one, StringKey two)
		{
			return one.Id == two.Id;
		}

		public static bool operator !=(StringKey one, StringKey two)
		{
			return one.Id != two.Id;
		}

		public static bool operator ==(StringKey one, string two)
		{
			return one.Equals(two);
		}

		public static bool operator !=(StringKey one, string two)
		{
			return !one.Equals(two);
		}

		public static bool operator ==(string one, StringKey two)
		{
			return two.Equals(one);
		}

		public static bool operator !=(string one, StringKey two)
		{
			return !two.Equals(one);
		}

		public bool Equals(StringKey other)
		{
			return Equals(other.Id);
		}

		public bool Equals(uint other)
		{
			return Id == other;
		}

		public bool Equals(string other)
		{
			if (!StringKeyBehaviour.TryGetID(ref other, out var outId))
			{
				return false;
			}
			return Equals(outId);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is StringKey other))
			{
				if (!(obj is uint other2))
				{
					if (obj is string other3)
					{
						return Equals(other3);
					}
					return Id.Equals(obj);
				}
				return Equals(other2);
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return StringKeyBehaviour.ToString(ref _useScriptable, _scriptable, ref _stringKey);
		}

		public void OnBeforeSerialize()
		{
			if (_useScriptable)
			{
				if ((object)_scriptable != null)
				{
					_stringKey = _scriptable.Key;
				}
				else
				{
					_stringKey = null;
				}
			}
		}

		public void OnAfterDeserialize()
		{
			if (string.IsNullOrEmpty(_stringKey))
			{
				_id = 0u;
			}
			else
			{
				_id = StringKeyBehaviour.GetID(ref _stringKey);
			}
		}
	}
	[Serializable]
	public struct StringKey<T> : IEquatable<StringKey>, IEquatable<StringKey<T>>, IEquatable<uint>, IEquatable<string>, ISerializationCallbackReceiver where T : ScriptableStringKey
	{
		[SerializeField]
		internal string _stringKey;

		[SerializeField]
		internal T _scriptable;

		[SerializeField]
		internal bool _useScriptable;

		private uint? _id;

		public uint Id
		{
			get
			{
				uint? id = _id;
				if (!id.HasValue)
				{
					_id = StringKeyBehaviour.GetID(ref _stringKey);
					return _id.Value;
				}
				return _id.Value;
			}
		}

		public bool IsValid()
		{
			return Id != 0;
		}

		public void AssertKeyValidity()
		{
			if (!IsValid())
			{
				throw new Exception("Key is not valid.");
			}
		}

		private StringKey(bool useScriptable, T scriptable, string stringKey)
		{
			_useScriptable = useScriptable;
			_scriptable = scriptable;
			_stringKey = stringKey;
			_id = StringKeyBehaviour.GetID(ref _stringKey);
		}

		private StringKey(bool useScriptable, T scriptable, string stringKey, uint id)
		{
			_useScriptable = useScriptable;
			_scriptable = scriptable;
			_stringKey = stringKey;
			_id = id;
		}

		public StringKey(string key)
			: this(useScriptable: false, null, key)
		{
		}

		public StringKey(StringKey<T> other)
			: this(other._useScriptable, other._scriptable, other._stringKey, other.Id)
		{
		}

		public StringKey(T scriptable)
		{
			_useScriptable = true;
			_scriptable = scriptable;
			if (_scriptable == null)
			{
				_stringKey = null;
				_id = null;
			}
			else
			{
				_stringKey = scriptable._stringKey._stringKey;
				_id = scriptable._stringKey.Id;
			}
		}

		public static implicit operator uint(StringKey<T> key)
		{
			return key.Id;
		}

		public static implicit operator string(StringKey<T> key)
		{
			return key._stringKey;
		}

		public static implicit operator StringKey(StringKey<T> key)
		{
			return key._stringKey;
		}

		public static implicit operator StringKey<T>(string key)
		{
			return new StringKey<T>(key);
		}

		public static implicit operator StringKey<T>(T key)
		{
			return new StringKey<T>(key);
		}

		public static bool operator ==(StringKey<T> one, StringKey<T> two)
		{
			return one.Id == two.Id;
		}

		public static bool operator !=(StringKey<T> one, StringKey<T> two)
		{
			return one.Id != two.Id;
		}

		public static bool operator ==(StringKey one, StringKey<T> two)
		{
			return one.Id == two.Id;
		}

		public static bool operator !=(StringKey one, StringKey<T> two)
		{
			return one.Id != two.Id;
		}

		public static bool operator ==(StringKey<T> one, StringKey two)
		{
			return one.Id == two.Id;
		}

		public static bool operator !=(StringKey<T> one, StringKey two)
		{
			return one.Id != two.Id;
		}

		public static bool operator ==(StringKey<T> one, string two)
		{
			return one.Equals(two);
		}

		public static bool operator !=(StringKey<T> one, string two)
		{
			return !one.Equals(two);
		}

		public static bool operator ==(string one, StringKey<T> two)
		{
			return two.Equals(one);
		}

		public static bool operator !=(string one, StringKey<T> two)
		{
			return !two.Equals(one);
		}

		public bool Equals(StringKey<T> other)
		{
			return Id == other.Id;
		}

		public bool Equals(StringKey other)
		{
			return Id == other.Id;
		}

		public bool Equals(uint other)
		{
			return Id == other;
		}

		public bool Equals(string other)
		{
			if (!StringKeyBehaviour.TryGetID(ref other, out var outId))
			{
				return false;
			}
			return Id == outId;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is StringKey<T> other))
			{
				if (!(obj is StringKey other2))
				{
					if (!(obj is uint other3))
					{
						if (obj is string other4)
						{
							return Equals(other4);
						}
						return Id.Equals(obj);
					}
					return Equals(other3);
				}
				return Equals(other2);
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return StringKeyBehaviour.ToString(ref _useScriptable, _scriptable, ref _stringKey);
		}

		public void OnBeforeSerialize()
		{
			if (_useScriptable)
			{
				if ((object)_scriptable != null)
				{
					_stringKey = _scriptable.Key;
				}
				else
				{
					_stringKey = null;
				}
			}
		}

		public void OnAfterDeserialize()
		{
			if (string.IsNullOrEmpty(_stringKey))
			{
				_id = 0u;
			}
			else
			{
				_id = StringKeyBehaviour.GetID(ref _stringKey);
			}
		}
	}
}
