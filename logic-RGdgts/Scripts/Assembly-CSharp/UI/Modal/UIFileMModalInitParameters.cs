using System;
using System.Collections.Generic;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIFileMModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public string initPath;

		public bool showFiles;

		public bool showFolders;

		public List<string> extension;

		public Action<AssetType, string, string, string> OnSelected;

		public Action OnClosed;

		public List<string> existingNames;

		public bool importSameNameAllowed;

		public UIFileMModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, string initPath = null, bool showFiles = true, bool showFolders = true, List<string> extension = null, Action<AssetType, string, string, string> OnSelected = null, Action OnClosed = null, List<string> existingNames = null, bool importSameNameAllowed = false)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.initPath = null;
			this.showFiles = false;
			this.showFolders = false;
			this.extension = null;
			this.OnSelected = null;
			this.OnClosed = null;
			this.existingNames = null;
			this.importSameNameAllowed = false;
		}
	}
}
