using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.SmallCanvas
{
	public class AssetSmallPanel : MonoBehaviour
	{
		private Asset currentAsset;

		[SerializeField]
		private TextMeshProUGUI assetName;

		[SerializeField]
		private TextMeshProUGUI created;

		[SerializeField]
		private TextMeshProUGUI updated;

		[SerializeField]
		private TextMeshProUGUI assetType;

		private LocalizedString localizedString;

		public void InitAsset(Asset asset)
		{
		}

		public void UpdateAssetData(Asset asset)
		{
		}

		public void ClearData()
		{
		}
	}
}
