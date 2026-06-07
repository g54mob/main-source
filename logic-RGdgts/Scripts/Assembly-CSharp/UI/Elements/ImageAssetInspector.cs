using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
	public class ImageAssetInspector : AssetInspector
	{
		public RawImage preview;

		[SerializeField]
		private Image bkgImage;

		private Material previewMaterial;

		private Material transparentBkgMaterial;

		public override void Init(Action delete, Action edit, Action<string> rename, Action<string> duplicate, List<string> existingNames, Action<string> export, AssetType assetType = AssetType.SpriteSheet)
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
