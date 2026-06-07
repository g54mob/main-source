using System;
using System.Collections.Generic;

namespace UI.Elements
{
	public class CodeAssetInspector : AssetInspector
	{
		public RetroUIText preview;

		public override void Init(Action delete, Action edit, Action<string> rename, Action<string> duplicate, List<string> existingNames, Action<string> export, AssetType assetType = AssetType.Code)
		{
		}

		public override void ActivateAssetInspector(Asset asset)
		{
		}

		public override void OpenExportDialog()
		{
		}

		public override void OnExport(string name)
		{
		}
	}
}
