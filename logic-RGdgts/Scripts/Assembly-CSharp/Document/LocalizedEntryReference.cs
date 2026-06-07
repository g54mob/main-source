using System;

namespace Document
{
	[Serializable]
	public struct LocalizedEntryReference
	{
		public string tableName;

		public string entryName;

		public LocalizedEntryReference(string tableName, string entryName)
		{
			this.tableName = null;
			this.entryName = null;
		}
	}
}
