using System;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIConfirmImportAssetModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public Action<bool, Asset> onConfirm;

		public Asset asset;

		public UIConfirmImportAssetModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef, Action<bool, Asset> onConfirm, Asset asset)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
			this.onConfirm = null;
			this.asset = null;
		}
	}
}
