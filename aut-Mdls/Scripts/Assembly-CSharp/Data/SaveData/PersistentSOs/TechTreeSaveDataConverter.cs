using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	public class TechTreeSaveDataConverter : SaveDataConverter<TechTreeSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public int FocusedNodeID;

			public List<int> UnlockedNodeIDs = new List<int>();

			public ISaveVersion ToNextVersion()
			{
				List<TechTreeSaveDataNode> list = new List<TechTreeSaveDataNode>();
				for (int i = 0; i < UnlockedNodeIDs.Count; i++)
				{
					list.Add(new TechTreeSaveDataNode(UnlockedNodeIDs[i], i, null));
				}
				return new TechTreeSaveData(null, list, FocusedNodeID);
			}
		}

		private class Version1 : IPreviousSaveVersion, ISaveVersion
		{
			[Serializable]
			public class Version1_Node
			{
				public int ID;

				public int UnlockIndex;

				public List<(int resourceDataId, int amount)> PaidCosts;
			}

			public string TechTreeGuid;

			public int FocusedNodeID;

			public List<Version1_Node> UnlockedNodes = new List<Version1_Node>();

			public ISaveVersion ToNextVersion()
			{
				List<TechTreeSaveDataNode> list = new List<TechTreeSaveDataNode>();
				for (int i = 0; i < UnlockedNodes.Count; i++)
				{
					list.Add(new TechTreeSaveDataNode(UnlockedNodes[i].ID, UnlockedNodes[i].UnlockIndex, null));
				}
				return new TechTreeSaveData(null, list, FocusedNodeID);
			}
		}

		public TechTreeSaveDataConverter()
			: base(2)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			return version switch
			{
				0 => typeof(Version0), 
				1 => typeof(Version1), 
				_ => null, 
			};
		}
	}
}
