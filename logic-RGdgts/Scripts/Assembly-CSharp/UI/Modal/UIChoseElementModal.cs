using System;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIChoseElementModal : UIModal<UIChoseModalInitParameters>
	{
		[SerializeField]
		private UIButton openButton;

		[SerializeField]
		private UIButton closeButton;

		[SerializeField]
		private GameObject noAssetMessageBox;

		private Action<Asset> OnSelected;

		private ElementListContainer assetListContainer;

		private Asset selectedAsset;

		private List<Asset> internalAssets;

		private LocalizedString localizedStringTitle;

		private AssetListConverter converter;

		public override void Init(UIModalManager modalManager, UIChoseModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void OnOpen()
		{
		}

		private void OnElementSelectedInList(int assetIndex)
		{
		}

		public void OnElementDoubleClicked(int assetIndex)
		{
		}

		public void OnSelectionConfirmed()
		{
		}

		public Asset GetAsset()
		{
			return null;
		}

		public override void OnClose()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		public override void Set()
		{
		}
	}
}
