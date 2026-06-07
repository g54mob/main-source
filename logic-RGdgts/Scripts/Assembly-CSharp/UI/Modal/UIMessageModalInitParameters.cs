using System;
using System.Collections.Generic;
using UI.Common;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIMessageModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public List<Action> OnTicksSelected;

		public List<TableEntryReference> tickMessages;

		public Action onClose;

		public MessageModalType messageType;

		public UIMessageModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef, Action onClose = null, List<Action> OnTicksSelected = null, List<TableEntryReference> tickMessages = null, MessageModalType messageType = MessageModalType.None)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
			this.OnTicksSelected = null;
			this.tickMessages = null;
			this.onClose = null;
			this.messageType = default(MessageModalType);
		}
	}
}
