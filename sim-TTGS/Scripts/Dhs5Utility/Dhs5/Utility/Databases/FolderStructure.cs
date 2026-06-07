using System;
using System.Collections.Generic;

namespace Dhs5.Utility.Databases
{
	public class FolderStructure
	{
		private Dictionary<int, List<FolderStructureEntry>> m_structure;

		private List<FolderStructureEntry> m_state;

		private List<int> m_validIndexes;

		private Dictionary<int, List<string>> m_openGroups;

		public Comparison<object> CustomSort { get; set; }

		public int TotalCount => m_state.Count;

		public int ValidCount => m_validIndexes.Count;

		public FolderStructure()
		{
			m_structure = new Dictionary<int, List<FolderStructureEntry>>();
			m_state = new List<FolderStructureEntry>();
			m_validIndexes = new List<int>();
		}

		public FolderStructureEntry GetEntryAtIndex(int index)
		{
			if (m_state.IsIndexValid(index))
			{
				return m_state[index];
			}
			return null;
		}

		public IEnumerable<FolderStructureEntry> GetValidEntries()
		{
			foreach (int validIndex in m_validIndexes)
			{
				yield return m_state[validIndex];
			}
		}

		public IEnumerable<int> GetValidEntriesIndexes()
		{
			foreach (int validIndex in m_validIndexes)
			{
				yield return validIndex;
			}
		}

		public int GetValidEntryCount()
		{
			return m_validIndexes.Count;
		}

		public IEnumerable<int> GetFilteredEntriesIndexes(string filter, bool includeGroups = false, bool useGroupName = true)
		{
			bool includeChildren = false;
			int parentLevel = 0;
			for (int i = 0; i < m_state.Count; i++)
			{
				FolderStructureEntry folderStructureEntry = m_state[i];
				if (includeChildren && folderStructureEntry.level <= parentLevel)
				{
					includeChildren = false;
				}
				bool flag = folderStructureEntry.content.Contains(filter, StringComparison.OrdinalIgnoreCase);
				if (folderStructureEntry is FolderStructureGroupEntry folderStructureGroupEntry)
				{
					if (flag)
					{
						if (useGroupName && !includeChildren)
						{
							includeChildren = true;
							parentLevel = folderStructureGroupEntry.level;
						}
						if (includeGroups)
						{
							yield return i;
						}
					}
				}
				else if (flag || includeChildren)
				{
					yield return i;
				}
			}
		}

		public void UpdateContent(Dictionary<string, object> dico)
		{
			SaveGroupsState();
			Clear();
			AddRange(dico);
			LoadGroupsState();
			RecomputeState();
		}

		public void Add(string content, object data = null)
		{
			InternalAdd(content, data);
			RecomputeState();
		}

		private void AddRange(Dictionary<string, object> dico)
		{
			foreach (var (content, data) in dico)
			{
				InternalAdd(content, data);
			}
			RecomputeState();
		}

		private void InternalAdd(string content, object data)
		{
			string[] array = content.Split('/', StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				return;
			}
			int i = 0;
			FolderStructureGroupEntry folderStructureGroupEntry = null;
			for (; i < array.Length - 1; i++)
			{
				if (!TryGetGroup(array[i], i, out var group))
				{
					group = new FolderStructureGroupEntry(array[i], i, folderStructureGroupEntry);
					if (m_structure.TryGetValue(i, out var value))
					{
						value.Add(group);
					}
					else
					{
						m_structure.Add(i, new List<FolderStructureEntry> { group });
					}
				}
				folderStructureGroupEntry = group;
			}
			FolderStructureEntry item = new FolderStructureEntry(array[i], i, folderStructureGroupEntry, data);
			if (m_structure.TryGetValue(i, out var value2))
			{
				value2.Add(item);
				return;
			}
			m_structure.Add(i, new List<FolderStructureEntry> { item });
		}

		public void EnsureVisibilityOfEntry(FolderStructureEntry entry)
		{
			while (entry.group != null)
			{
				entry.group.SetOpen(open: true);
				entry = entry.group;
			}
			RecomputeValidEntries();
		}

		public void SetOpen(FolderStructureGroupEntry group, bool open)
		{
			group.SetOpen(open);
			RecomputeValidEntries();
		}

		public void Clear()
		{
			m_structure.Clear();
		}

		public void RecomputeState()
		{
			m_state.Clear();
			m_validIndexes.Clear();
			if (!m_structure.TryGetValue(0, out var value) || value == null || value.Count <= 0)
			{
				return;
			}
			List<FolderStructureEntry> list = new List<FolderStructureEntry>(value);
			Sort(list);
			foreach (FolderStructureEntry item in list)
			{
				if (item is FolderStructureGroupEntry folderStructureGroupEntry)
				{
					RecursiveAddGroupContentToState(folderStructureGroupEntry, open: true);
					continue;
				}
				m_state.Add(item);
				m_validIndexes.Add(m_state.Count - 1);
			}
		}

		private void RecursiveAddGroupContentToState(FolderStructureGroupEntry group, bool open)
		{
			if (!m_structure.TryGetValue(group.level + 1, out var value) || value == null || value.Count <= 0)
			{
				return;
			}
			List<FolderStructureEntry> list = new List<FolderStructureEntry>();
			foreach (FolderStructureEntry item in value)
			{
				if (item.group == group)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			m_state.Add(group);
			if (open)
			{
				m_validIndexes.Add(m_state.Count - 1);
			}
			open = open && group.Open;
			Sort(list);
			foreach (FolderStructureEntry item2 in list)
			{
				if (item2 is FolderStructureGroupEntry folderStructureGroupEntry)
				{
					RecursiveAddGroupContentToState(folderStructureGroupEntry, open);
					continue;
				}
				m_state.Add(item2);
				if (open)
				{
					m_validIndexes.Add(m_state.Count - 1);
				}
			}
		}

		public void RecomputeValidEntries()
		{
			m_validIndexes.Clear();
			int num = 0;
			for (int i = 0; i < m_state.Count; i++)
			{
				FolderStructureEntry folderStructureEntry = m_state[i];
				if (folderStructureEntry.level <= num)
				{
					m_validIndexes.Add(i);
					num = ((!(folderStructureEntry is FolderStructureGroupEntry { Open: not false })) ? folderStructureEntry.level : (folderStructureEntry.level + 1));
				}
			}
		}

		private void Sort(List<FolderStructureEntry> list)
		{
			list.Sort(delegate(FolderStructureEntry e1, FolderStructureEntry e2)
			{
				if (e1.IsGroup && e2.IsGroup)
				{
					return e1.content.CompareTo(e2.content);
				}
				if (!e1.IsGroup && !e2.IsGroup)
				{
					if (CustomSort != null)
					{
						return CustomSort(e1, e2);
					}
					return e1.content.CompareTo(e2.content);
				}
				return e1.IsGroup ? 1 : (-1);
			});
		}

		private void SaveGroupsState()
		{
			if (m_structure == null)
			{
				return;
			}
			m_openGroups = new Dictionary<int, List<string>>();
			foreach (KeyValuePair<int, List<FolderStructureEntry>> item in m_structure)
			{
				item.Deconstruct(out var key, out var value);
				int key2 = key;
				List<FolderStructureEntry> list = value;
				List<string> list2 = new List<string>();
				foreach (FolderStructureEntry item2 in list)
				{
					if (item2 is FolderStructureGroupEntry { Open: not false } folderStructureGroupEntry)
					{
						list2.Add(folderStructureGroupEntry.content);
					}
				}
				m_openGroups.Add(key2, list2);
			}
		}

		private void LoadGroupsState()
		{
			if (m_openGroups == null)
			{
				return;
			}
			foreach (var (key, list2) in m_openGroups)
			{
				if (!m_structure.TryGetValue(key, out var value))
				{
					continue;
				}
				foreach (FolderStructureEntry item in value)
				{
					if (item is FolderStructureGroupEntry folderStructureGroupEntry && list2.Contains(folderStructureGroupEntry.content))
					{
						folderStructureGroupEntry.SetOpen(open: true);
					}
				}
			}
			m_openGroups.Clear();
			m_openGroups = null;
		}

		private bool TryGetGroup(string name, int level, out FolderStructureGroupEntry group)
		{
			if (m_structure.TryGetValue(level, out var value) && value.Find((FolderStructureEntry e) => e.content == name) is FolderStructureGroupEntry folderStructureGroupEntry)
			{
				group = folderStructureGroupEntry;
				return true;
			}
			group = null;
			return false;
		}
	}
}
