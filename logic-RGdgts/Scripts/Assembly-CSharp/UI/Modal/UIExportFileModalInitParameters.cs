using System;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIExportFileModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference placeholder;

		public string oldName;

		public string initPath;

		public AssetType assetType;

		public Action<string> OnSave;

		public Action OnClosed;

		public UIExportFileModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference placeholder, AssetType assetType, string oldName = null, string initPath = null, Action<string> OnSelected = null, Action OnClosed = null)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.placeholder = default(TableEntryReference);
			this.oldName = null;
			this.initPath = null;
			this.assetType = default(AssetType);
			OnSave = null;
			this.OnClosed = null;
		}
	}
}
