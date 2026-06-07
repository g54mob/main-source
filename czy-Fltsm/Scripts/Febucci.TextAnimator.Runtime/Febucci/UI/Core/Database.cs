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
		private List<T> data = new List<T>();

		private Dictionary<string, T> dictionary;

		public List<T> Data => data;

		public T this[string key]
		{
			get
			{
				BuildOnce();
				return dictionary[key];
			}
		}

		private void OnEnable()
		{
			built = false;
		}

		public void Add(T element)
		{
			if (data == null)
			{
				data = new List<T>();
			}
			data.Add(element);
			if (built && Application.isPlaying)
			{
				string tagID = element.TagID;
				if (dictionary.ContainsKey(tagID))
				{
					Debug.LogError("Text Animator: Tag " + tagID + " is already present in the database. Skipping...");
				}
				else
				{
					dictionary.Add(tagID, element);
				}
			}
			else
			{
				built = false;
			}
		}

		public void ForceBuildRefresh()
		{
			built = false;
			BuildOnce();
		}

		public void BuildOnce()
		{
			if (built)
			{
				return;
			}
			built = true;
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, T>();
			}
			else
			{
				dictionary.Clear();
			}
			foreach (T datum in data)
			{
				if ((bool)datum)
				{
					string tagID = datum.TagID;
					if (string.IsNullOrEmpty(tagID))
					{
						Debug.LogError("Text Animator: Tag is null or empty. Skipping...");
					}
					else if (dictionary.ContainsKey(tagID))
					{
						Debug.LogError("Text Animator: Tag " + tagID + " is already present in the database. Skipping...");
					}
					else
					{
						dictionary.Add(tagID, datum);
					}
				}
			}
			OnBuildOnce();
		}

		protected virtual void OnBuildOnce()
		{
		}

		public bool ContainsKey(string key)
		{
			BuildOnce();
			return dictionary.ContainsKey(key);
		}

		public void DestroyImmediate(bool databaseOnly = false)
		{
			if (!databaseOnly)
			{
				foreach (T datum in data)
				{
					UnityEngine.Object.DestroyImmediate(datum);
				}
			}
			UnityEngine.Object.DestroyImmediate(this);
		}
	}
}
