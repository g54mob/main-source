using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UISecurityModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public UISecurityModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
		}
	}
}
