using System.Collections.Generic;

namespace App.Data
{
	public class UnlockGroup
	{
		public List<string> questsKeyNames;

		public List<int> questsHashes;

		public int numUnlock;

		public UnlockGroup()
		{
			questsKeyNames = new List<string>();
			questsHashes = new List<int>();
		}

		public int IsUnlocked()
		{
			int num = 0;
			foreach (string questsKeyName in questsKeyNames)
			{
				BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(questsKeyName);
				if (baseQuestByKeyName.Locked == 1)
				{
					if (IsUnlocked(baseQuestByKeyName.ReqUnlockGroups, onlyUnlock: true))
					{
						num++;
					}
				}
				else if (Logic.GetModel().curPreview.IsQuestDone(questsKeyName))
				{
					num++;
				}
			}
			if (num >= numUnlock)
			{
				return 1;
			}
			return 0;
		}

		public bool IsEmpty()
		{
			return questsHashes.Count == 0;
		}

		public static int GetNumUnlocked(List<UnlockGroup> groups)
		{
			int num = 0;
			foreach (UnlockGroup group in groups)
			{
				num += group.IsUnlocked();
			}
			return num;
		}

		public static bool IsUnlocked(List<UnlockGroup> groups, bool onlyUnlock = false)
		{
			if (onlyUnlock && Logic.IsCheatActivated("UNLOCK_ALL"))
			{
				return true;
			}
			return GetNumUnlocked(groups) >= groups.Count;
		}

		public static int GetNumVisibleGroups(List<UnlockGroup> groups)
		{
			int num = 0;
			foreach (UnlockGroup group in groups)
			{
				num = ((!group.IsEmpty()) ? (num + group.IsUnlocked()) : (num + 1));
			}
			return num;
		}

		public static bool IsVisible(List<UnlockGroup> groups, int depth, bool onlyUnlock = false)
		{
			if (onlyUnlock && Logic.IsCheatActivated("UNLOCK_ALL"))
			{
				return true;
			}
			if (groups.Count == 0)
			{
				return true;
			}
			bool flag = GetNumVisibleGroups(groups) > 0;
			if (depth > 0)
			{
				foreach (UnlockGroup group in groups)
				{
					foreach (string questsKeyName in group.questsKeyNames)
					{
						BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(questsKeyName);
						if (baseQuestByKeyName != null)
						{
							flag = flag || IsVisible(baseQuestByKeyName.ReqUnlockGroups, depth - 1);
							flag = flag || Logic.GetModel().curPreview.IsQuestDone(baseQuestByKeyName.KeyName);
						}
					}
				}
			}
			return flag;
		}
	}
}
