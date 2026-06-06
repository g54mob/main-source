using System;
using System.Collections.Generic;
using Febucci.Parsing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	public class Database<T> : ScriptableObject where T : ScriptableObject, ITagProvider
	{
		private bool built;

		[SerializeReference]
		private List<T> data = new List<T>();

		private Dictionary<string, T> dictionary;

		public virtual bool IsCaseSensitive => true;

		public List<T> Data => data;

		public Dictionary<string, T> Dictionary
		{
			get
			{
				BuildOnce();
				return dictionary;
			}
		}

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

		[ContextMenu("Force rebuild")]
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
					string text = datum.TagID;
					if (!IsCaseSensitive)
					{
						text = text.ToLowerInvariant();
					}
					if (string.IsNullOrEmpty(text))
					{
						Debug.LogError("Text Animator: Tag is null or empty. Skipping...");
					}
					else if (dictionary.ContainsKey(text))
					{
						Debug.LogError("Text Animator: Tag " + text + " is already present in the database. Skipping...");
					}
					else
					{
						dictionary.Add(text, datum);
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
