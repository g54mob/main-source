using System;
using System.Collections.Generic;
using UnityEngine;

namespace Febucci.UI.Core
{
	[Serializable]
	public class Database<T> : ScriptableObject where T : ScriptableObject, ITagProvider
	{
		private bool built;

		[SerializeField]
		private List<T> data;

		private Dictionary<string, T> dictionary;

		public List<T> Data => null;

		public T this[string key] => null;

		private void OnEnable()
		{
		}

		public void Add(T element)
		{
		}

		public void ForceBuildRefresh()
		{
		}

		public void BuildOnce()
		{
		}

		protected virtual void OnBuildOnce()
		{
		}

		public bool ContainsKey(string key)
		{
			return false;
		}

		public void DestroyImmediate(bool databaseOnly = false)
		{
		}
	}
}
