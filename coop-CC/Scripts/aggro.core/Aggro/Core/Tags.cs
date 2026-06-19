using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Aggro.Core
{
	public static class Tags
	{
		private struct EntityTagsEntry
		{
			public TagList key;

			public List<EntityKey> keys;
		}

		public struct PrefabEntry : ITaggedAsset
		{
			public TagList tags;

			public GameObject prefab;

			public TagList GetAssetTagList()
			{
				return tags;
			}
		}

		private static List<PrefabEntry> _prefabEntries;

		private static List<EntityTagsEntry> _entries;

		private static Dictionary<TagList, int> _tagsToEntriesIndex;

		private static List<TagList> _currentEntities;

		private static List<EntityKey> _keys = new List<EntityKey>();

		private static TagsObject _tags;

		public static TagsObject tags => _tags;

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			_tags = Resources.Load<TagsObject>("tags");
			_prefabEntries = new List<PrefabEntry>();
			GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = array[i];
				if (!gameObject.scene.IsValid() && gameObject.TryGetComponent<ITaggedAsset>(out var component) && !gameObject.name.Contains("-base") && !gameObject.name.Contains("-DUPEME") && !gameObject.name.Contains("template"))
				{
					PrefabEntry item = new PrefabEntry
					{
						prefab = gameObject,
						tags = component.GetAssetTagList()
					};
					_prefabEntries.Add(item);
				}
			}
			_entries = new List<EntityTagsEntry>();
			_tagsToEntriesIndex = new Dictionary<TagList, int>();
			_currentEntities = new List<TagList>();
		}

		public static PrefabEntry[] GetPrefabHas(Tag tag)
		{
			return GetPrefabsHasAny(tag.GetMask());
		}

		public static PrefabEntry[] GetPrefabDoesNotHave(Tag tag)
		{
			return GetPrefabsHasNone(tag.GetMask());
		}

		public static PrefabEntry[] GetPrefabsHasAny(TagMask mask)
		{
			List<PrefabEntry> list = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAny(mask))
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasAny(IList<Tag> list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAny(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasAny(TagList list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAny(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasAll(TagMask mask)
		{
			List<PrefabEntry> list = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAll(mask))
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasAll(IList<Tag> list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAll(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasAll(TagList list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasAll(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasNone(TagMask mask)
		{
			List<PrefabEntry> list = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasNone(mask))
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasNone(IList<Tag> list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasNone(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static PrefabEntry[] GetPrefabsHasNone(TagList list)
		{
			List<PrefabEntry> list2 = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				if (item.tags.HasNone(list))
				{
					list2.Add(item);
				}
			}
			return list2.ToArray();
		}

		public static void Filter<T>(List<T> list, TagQuery query) where T : ITaggedAsset
		{
			if (query.IsEmpty())
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (!query.Evaluate(list[i].GetAssetTagList()))
				{
					list.RemoveAtSwapBack(i);
					i--;
				}
			}
		}

		public static void Filter(List<TagList> list, TagQuery query)
		{
			if (query.IsEmpty())
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (!query.Evaluate(list[i]))
				{
					list.RemoveAtSwapBack(i);
					i--;
				}
			}
		}

		public static PrefabEntry[] GetPrefabs(TagQuery query)
		{
			List<PrefabEntry> list = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				list.Add(item);
			}
			Filter(list, query);
			return list.ToArray();
		}

		public static PrefabEntry[] GetAllPrefabsEntries()
		{
			List<PrefabEntry> list = new List<PrefabEntry>();
			int count = _prefabEntries.Count;
			for (int i = 0; i < count; i++)
			{
				PrefabEntry item = _prefabEntries[i];
				list.Add(item);
			}
			return list.ToArray();
		}

		public static void DebugSortByLabel(List<Tag> tags)
		{
			tags.Sort(delegate(Tag x, Tag y)
			{
				string strA = _tags.DebugGetTagLabel(x);
				string strB = _tags.DebugGetTagLabel(y);
				return string.Compare(strA, strB, StringComparison.InvariantCultureIgnoreCase);
			});
		}

		public static void UpdateEntityTags(Entity entity, TagList tags)
		{
			UpdateEntityTags(entity.key, tags);
		}

		public static void UpdateEntityTags(EntityKey key, TagList tags)
		{
			if (_currentEntities.Count > key.index)
			{
				TagList tagList = _currentEntities[key.index];
				if (tagList != null)
				{
					_currentEntities[key.index] = null;
					int index = _tagsToEntriesIndex[tagList];
					_entries[index].keys[key.index] = EntityKey.invalid;
				}
			}
			if (tags != null)
			{
				while (_currentEntities.Count <= key.index)
				{
					_currentEntities.Add(null);
				}
				if (!_tagsToEntriesIndex.TryGetValue(tags, out var value))
				{
					EntityTagsEntry item = default(EntityTagsEntry);
					item.key = new TagList();
					item.key.AddTags(tags);
					item.keys = new List<EntityKey>();
					_tagsToEntriesIndex[item.key] = _entries.Count;
					_entries.Add(item);
				}
				EntityTagsEntry entityTagsEntry = _entries[value];
				_currentEntities[key.index] = entityTagsEntry.key;
				while (entityTagsEntry.keys.Count <= key.index)
				{
					entityTagsEntry.keys.Add(EntityKey.invalid);
				}
				entityTagsEntry.keys[key.index] = key;
			}
		}

		public static void GetEntities(TagQuery query, List<Entity> entities)
		{
			_keys.Clear();
			GetEntities(query, EntityWorld.gameObjectWorld.entityManager, _keys);
			int count = _keys.Count;
			for (int i = 0; i < count; i++)
			{
				entities.Add(new Entity(_keys[i], EntityWorld.gameObjectWorld));
			}
		}

		public static void GetEntities(TagQuery query, EntityManager entityManager, List<EntityKey> keys)
		{
			int count = _entries.Count;
			for (int i = 0; i < count; i++)
			{
				EntityTagsEntry entityTagsEntry = _entries[i];
				if (!query.Evaluate(entityTagsEntry.key))
				{
					continue;
				}
				int count2 = entityTagsEntry.keys.Count;
				for (int j = 0; j < count2; j++)
				{
					EntityKey entityKey = entityTagsEntry.keys[j];
					if (entityManager.Exists(entityKey) && !entityManager.IsDying(entityKey))
					{
						keys.Add(entityKey);
					}
				}
			}
		}
	}
}
