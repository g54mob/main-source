using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class KeyedGetSetValueStore<TKey> : IEnumerable, IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>
	{
		private readonly Dictionary<TKey, object> CIKxyjrGfgKEkXTLUGlIceCoGTde;

		private readonly bool tPLoJLtbdogmBKclDqEITRJcdjGH;

		public int Count => CIKxyjrGfgKEkXTLUGlIceCoGTde.Count;

		public bool isReadOnlyCollection => tPLoJLtbdogmBKclDqEITRJcdjGH;

		ICollection<TKey> IDictionary<TKey, object>.Keys => CIKxyjrGfgKEkXTLUGlIceCoGTde.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => CIKxyjrGfgKEkXTLUGlIceCoGTde.Values;

		object IDictionary<TKey, object>.this[TKey key]
		{
			get
			{
				return CIKxyjrGfgKEkXTLUGlIceCoGTde[key];
			}
			set
			{
				udAMddxnAAvKCfofyUgsUjZGlSf();
				CIKxyjrGfgKEkXTLUGlIceCoGTde[key] = value;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => CIKxyjrGfgKEkXTLUGlIceCoGTde.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => tPLoJLtbdogmBKclDqEITRJcdjGH;

		public KeyedGetSetValueStore(Dictionary<TKey, object> valueDelegates, bool isReadOnlyCollection)
		{
			CIKxyjrGfgKEkXTLUGlIceCoGTde = valueDelegates;
			tPLoJLtbdogmBKclDqEITRJcdjGH = isReadOnlyCollection;
		}

		public KeyedGetSetValueStore(bool isReadOnlyCollection)
		{
			tPLoJLtbdogmBKclDqEITRJcdjGH = isReadOnlyCollection;
			CIKxyjrGfgKEkXTLUGlIceCoGTde = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			while (true)
			{
				udAMddxnAAvKCfofyUgsUjZGlSf();
				int num = 801915796;
				while (true)
				{
					switch (num ^ 0x2FCC4396)
					{
					case 0:
						goto IL_000e;
					case 1:
						break;
					default:
						CIKxyjrGfgKEkXTLUGlIceCoGTde.Add(key, item);
						return;
					}
					break;
					IL_000e:
					num = 801915799;
				}
			}
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!CIKxyjrGfgKEkXTLUGlIceCoGTde.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				qBLuRLmYjzizAQElJxBbMjTTpPD(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.ContainsKey(key);
		}

		public void Clear()
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			CIKxyjrGfgKEkXTLUGlIceCoGTde.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (CIKxyjrGfgKEkXTLUGlIceCoGTde.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				qBLuRLmYjzizAQElJxBbMjTTpPD(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (TrySetValue(key, value))
			{
				return;
			}
			while (true)
			{
				int num = -1526981780;
				while (true)
				{
					switch (num ^ -1526981779)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0028;
					case 0:
						return;
					}
					break;
					IL_0028:
					qBLuRLmYjzizAQElJxBbMjTTpPD(key, typeof(TValue));
					num = -1526981779;
				}
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (CIKxyjrGfgKEkXTLUGlIceCoGTde.TryGetValue(key, out var value2))
			{
				while (true)
				{
					int num = 1132821030;
					while (true)
					{
						switch (num ^ 0x43857A24)
						{
						case 0:
							break;
						case 2:
							goto IL_002e;
						default:
							goto end_IL_0010;
						}
						break;
						IL_002e:
						if (!(value2 is IGetValue<TValue> getValue))
						{
							num = 1132821029;
							continue;
						}
						value = getValue.GetValue();
						return true;
					}
					continue;
					end_IL_0010:
					break;
				}
			}
			value = default(TValue);
			Logger.LogError(FkuEbtKVAzfKqIVOPJZpcRUkMuJw(key, typeof(TValue)), requiredThreadSafety: true);
			return false;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			int num;
			if (CIKxyjrGfgKEkXTLUGlIceCoGTde.TryGetValue(key, out var value2))
			{
				ISetValue<TValue> setValue;
				if ((setValue = value2 as GetSetValue<TValue>) == null)
				{
					goto IL_001a;
				}
				setValue.SetValue(value);
				num = 1588886924;
				goto IL_001f;
			}
			goto IL_0038;
			IL_001f:
			switch (num ^ 0x5EB47D8D)
			{
			case 0:
				break;
			case 2:
				goto IL_0038;
			default:
				return true;
			}
			goto IL_001a;
			IL_0038:
			Logger.LogError(FkuEbtKVAzfKqIVOPJZpcRUkMuJw(key, typeof(TValue)), requiredThreadSafety: true);
			return false;
			IL_001a:
			num = 1588886927;
			goto IL_001f;
		}

		private void udAMddxnAAvKCfofyUgsUjZGlSf()
		{
			if (!tPLoJLtbdogmBKclDqEITRJcdjGH)
			{
				return;
			}
			while (true)
			{
				switch (0x3326C244 ^ 0x3326C246)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					throw new Exception("The collection is read-only.");
				case 1:
					return;
				}
			}
		}

		private static void qBLuRLmYjzizAQElJxBbMjTTpPD(TKey P_0, Type P_1)
		{
			throw new Exception(FkuEbtKVAzfKqIVOPJZpcRUkMuJw(P_0, P_1));
		}

		private static string FkuEbtKVAzfKqIVOPJZpcRUkMuJw(TKey P_0, Type P_1)
		{
			object[] array = new object[5] { "Value with key ", null, null, null, null };
			while (true)
			{
				int num = -919705459;
				while (true)
				{
					switch (num ^ -919705460)
					{
					case 2:
						break;
					case 1:
						goto IL_002d;
					default:
						array[4] = " not found.";
						return string.Concat(array);
					}
					break;
					IL_002d:
					array[1] = P_0;
					array[2] = " of type ";
					array[3] = P_1;
					num = -919705460;
				}
			}
		}

		void IDictionary<TKey, object>.Add(TKey key, object value)
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			CIKxyjrGfgKEkXTLUGlIceCoGTde.Add(key, value);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey key)
		{
			return ContainsKey(key);
		}

		bool IDictionary<TKey, object>.Remove(TKey key)
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.Remove(key);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey key, out object value)
		{
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> item)
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			((ICollection<KeyValuePair<TKey, object>>)CIKxyjrGfgKEkXTLUGlIceCoGTde).Add(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			((ICollection<KeyValuePair<TKey, object>>)CIKxyjrGfgKEkXTLUGlIceCoGTde).Clear();
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> item)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)CIKxyjrGfgKEkXTLUGlIceCoGTde).Contains(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, object>>)CIKxyjrGfgKEkXTLUGlIceCoGTde).CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> item)
		{
			udAMddxnAAvKCfofyUgsUjZGlSf();
			return ((ICollection<KeyValuePair<TKey, object>>)CIKxyjrGfgKEkXTLUGlIceCoGTde).Remove(item);
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return CIKxyjrGfgKEkXTLUGlIceCoGTde.GetEnumerator();
		}
	}
}
