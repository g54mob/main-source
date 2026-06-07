using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class KeyedGetSetValueStore<TKey> : IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>, IEnumerable
	{
		private readonly Dictionary<TKey, object> jBuymIPbKpwvYfqPLYsRSIGxssJq;

		private readonly bool eCtZIPydDTHlnAQNNzgMhXZzAMIX;

		public int Count => 0;

		public bool isReadOnlyCollection => false;

		ICollection<TKey> IDictionary<TKey, object>.Keys => null;

		ICollection<object> IDictionary<TKey, object>.Values => null;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => 0;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => false;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
		}

		public KeyedGetSetValueStore(bool P_0)
		{
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			return null;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			return default(TValue);
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			return false;
		}

		private void vJPutBxKQzqXCfAJdcGdEHLNbShSA()
		{
		}

		private static void TBhgYEmhLDlntyHuvBFUDVjlzyjz(TKey P_0, Type P_1)
		{
		}

		private static string QNroImYOnHGZlidcXbDjsbGccFhX(TKey P_0, Type P_1)
		{
			return null;
		}

		private void EYWqqOOtoIrUcDzmIxoWqLkJwuDl(TKey P_0, object P_1)
		{
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EYWqqOOtoIrUcDzmIxoWqLkJwuDl
			this.EYWqqOOtoIrUcDzmIxoWqLkJwuDl(P_0, P_1);
		}

		private bool ntYStZByOZbBTqooAgzwPdYIgOEJA(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ntYStZByOZbBTqooAgzwPdYIgOEJA
			return this.ntYStZByOZbBTqooAgzwPdYIgOEJA(P_0);
		}

		private bool yksSeehaWhedwBiYtbjoLyDkSQDO(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yksSeehaWhedwBiYtbjoLyDkSQDO
			return this.yksSeehaWhedwBiYtbjoLyDkSQDO(P_0);
		}

		private bool yDoHMIZyaRKfbZCfVkIjmhGLwiEM(TKey P_0, out object P_1)
		{
			P_1 = null;
			return false;
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yDoHMIZyaRKfbZCfVkIjmhGLwiEM
			return this.yDoHMIZyaRKfbZCfVkIjmhGLwiEM(P_0, out P_1);
		}

		private void kaZJItfAsJepfbheiaSMxfZiSarlA(KeyValuePair<TKey, object> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kaZJItfAsJepfbheiaSMxfZiSarlA
			this.kaZJItfAsJepfbheiaSMxfZiSarlA(P_0);
		}

		private void OKRlqSApLWHdITzKNtMstpaWDbVM()
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OKRlqSApLWHdITzKNtMstpaWDbVM
			this.OKRlqSApLWHdITzKNtMstpaWDbVM();
		}

		private bool nvOfjcItRXzzDIHBpRovjpgjHFsdc(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nvOfjcItRXzzDIHBpRovjpgjHFsdc
			return this.nvOfjcItRXzzDIHBpRovjpgjHFsdc(P_0);
		}

		private void UIXzYweyLiUIzSjqjChtFjmYzfxu(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UIXzYweyLiUIzSjqjChtFjmYzfxu
			this.UIXzYweyLiUIzSjqjChtFjmYzfxu(P_0, P_1);
		}

		private bool LliMECYpeIaoXhmysUTKpezKOCEjb(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in LliMECYpeIaoXhmysUTKpezKOCEjb
			return this.LliMECYpeIaoXhmysUTKpezKOCEjb(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> OIuiySQcLQWVirCDopkztDfyzFqH()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OIuiySQcLQWVirCDopkztDfyzFqH
			return this.OIuiySQcLQWVirCDopkztDfyzFqH();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
