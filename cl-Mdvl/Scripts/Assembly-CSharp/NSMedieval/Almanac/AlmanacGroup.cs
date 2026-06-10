using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Almanac
{
	public class AlmanacGroup
	{
		[SerializeField]
		private string groupId;

		[SerializeField]
		private string path;

		[SerializeField]
		private List<string> subGroupIDs;

		[SerializeField]
		private List<string> entryIDs;

		[SerializeField]
		private int depth;

		public string GroupId => groupId;

		public int Depth => depth;

		public string Path => path;

		public List<string> SubGroupIDs => subGroupIDs;

		public List<string> EntryIDs => entryIDs;

		public AlmanacGroup(string groupId, string path, int depth, List<string> subGroupIDs, List<string> entryIDs)
		{
			this.groupId = groupId;
			this.path = path;
			this.subGroupIDs = subGroupIDs;
			this.entryIDs = entryIDs;
			this.depth = depth;
		}
	}
}
