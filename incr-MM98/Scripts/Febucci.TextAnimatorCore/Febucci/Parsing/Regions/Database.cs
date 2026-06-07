using System;
using System.Collections.Generic;
using Febucci.GameEnginesBridge;

namespace Febucci.Parsing.Regions
{
	[Serializable]
	public abstract class Database<T> where T : ITagProvider
	{
		private bool built;

		private Dictionary<string, T> dictionary;

		public virtual bool IsCaseSensitive => true;

		protected abstract List<T> Data { get; set; }

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
			if (Data == null)
			{
				Data = new List<T>();
			}
			Data.Add(element);
			if (built && EngineWrapper.IsPlaying)
			{
				string tagID = element.TagID;
				if (!dictionary.ContainsKey(tagID))
				{
					dictionary.Add(tagID, element);
				}
				else
				{
					EngineWrapper.LogError("Tag " + tagID + " is already present in the database. Skipping...");
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
			if (Data == null)
			{
				Data = new List<T>();
			}
			foreach (T datum in Data)
			{
				if (datum != null)
				{
					string text = datum.TagID;
					if (!IsCaseSensitive)
					{
						text = text.ToLowerInvariant();
					}
					if (string.IsNullOrEmpty(text))
					{
						EngineWrapper.LogError("Tag is null or empty. Skipping...");
					}
					else if (!dictionary.ContainsKey(text))
					{
						dictionary.Add(text, datum);
					}
					else
					{
						EngineWrapper.LogError("Tag " + text + " is already present in the database. Skipping...");
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
	}
}
