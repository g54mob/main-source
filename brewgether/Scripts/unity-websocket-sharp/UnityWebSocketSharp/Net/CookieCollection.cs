using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	[Serializable]
	internal class CookieCollection : ICollection<Cookie>, IEnumerable<Cookie>, IEnumerable
	{
		private List<Cookie> _list;

		private bool _readOnly;

		private object _sync;

		internal IList<Cookie> List => null;

		internal IEnumerable<Cookie> Sorted => null;

		public int Count => 0;

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool IsSynchronized => false;

		public Cookie this[int index] => null;

		public Cookie this[string name] => null;

		public object SyncRoot => null;

		private void add(Cookie cookie)
		{
		}

		private static int compareForSort(Cookie x, Cookie y)
		{
			return 0;
		}

		private static int compareForSorted(Cookie x, Cookie y)
		{
			return 0;
		}

		private static CookieCollection parseRequest(string value)
		{
			return null;
		}

		private static CookieCollection parseResponse(string value)
		{
			return null;
		}

		private int search(Cookie cookie)
		{
			return 0;
		}

		private static string urlDecode(string s, Encoding encoding)
		{
			return null;
		}

		internal static CookieCollection Parse(string value, bool response)
		{
			return null;
		}

		internal void SetOrRemove(Cookie cookie)
		{
		}

		internal void SetOrRemove(CookieCollection cookies)
		{
		}

		internal void Sort()
		{
		}

		public void Add(Cookie cookie)
		{
		}

		public void Add(CookieCollection cookies)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(Cookie cookie)
		{
			return false;
		}

		public void CopyTo(Cookie[] array, int index)
		{
		}

		public IEnumerator<Cookie> GetEnumerator()
		{
			return null;
		}

		public bool Remove(Cookie cookie)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
