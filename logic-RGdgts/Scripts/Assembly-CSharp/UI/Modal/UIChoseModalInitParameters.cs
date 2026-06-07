using System;
using System.Collections.Generic;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UIChoseModalInitParameters
	{
		public List<AssetType> assetType;

		public Action<Asset> OnSelected;

		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public List<Asset> internalAssets;

		public UIChoseModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, List<AssetType> assetType, Action<Asset> OnSelected = null, List<Asset> internalAssets = null)
		{
			this.assetType = null;
			this.OnSelected = null;
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.internalAssets = null;
		}
	}
}
