using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/scriptables/tags")]
	[AddComponentMenu("Malbers/Utilities/Tools/Tags")]
	public class Tags : MonoBehaviour
	{
		public static List<Tags> TagsHolders;

		public List<Tag> tags = new List<Tag>();

		private readonly HashSet<int> HashTag = new HashSet<int>();

		private void OnEnable()
		{
			if (TagsHolders == null)
			{
				TagsHolders = new List<Tags>();
			}
			TagsHolders.Add(this);
		}

		private void OnDisable()
		{
			TagsHolders.Remove(this);
		}

		public void Awake()
		{
			HashSet<Tag> hashSet = new HashSet<Tag>(tags);
			hashSet.Remove(null);
			foreach (Tag item in hashSet)
			{
				HashTag.Add(item.ID);
			}
		}

		public static List<GameObject> GambeObjectbyTag(Tag tag)
		{
			return GambeObjectbyTag(tag.ID);
		}

		public static List<GameObject> GambeObjectbyTag(int tag)
		{
			List<GameObject> list = new List<GameObject>();
			if (TagsHolders == null || TagsHolders.Count == 0)
			{
				return null;
			}
			foreach (Tags tagsHolder in TagsHolders)
			{
				if (tagsHolder.HasTag(tag))
				{
					list.Add(tagsHolder.gameObject);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		public static List<GameObject> GambeObjectbyTag(Tag[] tags)
		{
			List<GameObject> list = new List<GameObject>();
			if (TagsHolders == null || TagsHolders.Count == 0)
			{
				return null;
			}
			foreach (Tags tagsHolder in TagsHolders)
			{
				if (tagsHolder.HasTag(tags))
				{
					list.Add(tagsHolder.gameObject);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		public bool HasTag(Tag tag)
		{
			return HasTag(tag.ID);
		}

		public bool HasTag(int key)
		{
			return HashTag.Contains(key);
		}

		public bool HasTag(params Tag[] enteringTags)
		{
			foreach (Tag tag in enteringTags)
			{
				if (HashTag.Contains(tag))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasTag(params int[] enteringTags)
		{
			foreach (int item in enteringTags)
			{
				if (HashTag.Contains(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAllTags(params Tag[] enteringTags)
		{
			foreach (Tag tag in enteringTags)
			{
				if (!HashTag.Contains(tag))
				{
					return false;
				}
			}
			return true;
		}

		public bool HasAllTags(params int[] enteringTags)
		{
			foreach (int item in enteringTags)
			{
				if (!HashTag.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		public void AddTag(Tag t)
		{
			if (!HashTag.Contains(t.ID))
			{
				tags.Add(t);
				HashTag.Add(t.ID);
			}
		}

		public void RemoveTag(Tag t)
		{
			if (HashTag.Contains(t))
			{
				tags.Remove(t);
				HashTag.Remove(t.ID);
			}
		}
	}
}
