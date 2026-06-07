using System;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIImportLibModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public Action<LibsController.Lib> OnSelected;

		public Action OnClosed;

		public UIImportLibModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, Action<LibsController.Lib> OnSelected = null, Action OnClosed = null)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.OnSelected = null;
			this.OnClosed = null;
		}
	}
}
