using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	[CreateAssetMenu(fileName = "DlcCatalog", menuName = "VampireSurvivors/New DlcCatalog")]
	public class DlcCatalog : ScriptableObject
	{
		[SerializeField]
		public DlcDataDictionary _DlcData;

		public DlcData GetData(DlcType dlcType)
		{
			return null;
		}

		public string GetTitle(DlcType dlcType)
		{
			return null;
		}

		public DlcType? GetDlcType_SteamAppId(string appId)
		{
			return null;
		}

		public DlcType? GetDlcType_XboxStoreId(string storeId)
		{
			return null;
		}

		public string GetXboxStoreId(DlcType dlcType)
		{
			return null;
		}

		public string GetXboxStorePackageIdentifier(DlcType dlcType)
		{
			return null;
		}
	}
}
