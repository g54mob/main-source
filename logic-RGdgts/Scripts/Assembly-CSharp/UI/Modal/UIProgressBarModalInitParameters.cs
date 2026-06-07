using System;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIProgressBarModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public Action OnStart;

		public Action onClose;

		public UIProgressBarModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef, Action OnStart, Action onClose = null)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
			this.OnStart = null;
			this.onClose = null;
		}
	}
}
