using System;
using System.Collections.Generic;
using UI.Common;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIConfirmModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public List<TableEntryReference> messageEntryRef;

		public Action<bool> onConfirm;

		public MessageModalType messageType;

		public UIConfirmModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, List<TableEntryReference> messageEntryRef, Action<bool> onConfirm, MessageModalType messageType = MessageModalType.None)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = null;
			this.onConfirm = null;
			this.messageType = default(MessageModalType);
		}
	}
}
