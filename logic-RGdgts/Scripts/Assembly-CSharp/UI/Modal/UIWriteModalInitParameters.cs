using System;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIWriteModalInitParameters
	{
		public Action<string> onConfirm;

		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public string oldText;

		public TableEntryReference placeholder;

		public UIWriteModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference placeholder, Action<string> OnConfirm, string oldText)
		{
			onConfirm = null;
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.oldText = null;
			this.placeholder = default(TableEntryReference);
		}
	}
}
