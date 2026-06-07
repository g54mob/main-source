using System;
using System.Collections.Generic;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIRenameModalInitParameters
	{
		public string oldName;

		public Action<string> onRename;

		public bool sameNameAllowed;

		public Action onClose;

		public List<string> existingNames;

		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public TableEntryReference placeholder;

		public UIRenameModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef, TableEntryReference placeholder, string oldName = null, Action<string> onRename = null, Action onClose = null, List<string> existingNames = null, bool sameNameAllowed = false)
		{
			this.oldName = null;
			this.onRename = null;
			this.sameNameAllowed = false;
			this.onClose = null;
			this.existingNames = null;
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
			this.placeholder = default(TableEntryReference);
		}
	}
}
