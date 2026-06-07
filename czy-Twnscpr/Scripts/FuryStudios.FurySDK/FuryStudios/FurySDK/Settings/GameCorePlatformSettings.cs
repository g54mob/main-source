using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class GameCorePlatformSettings
	{
		[SerializeField]
		private bool usesXBL;

		[SerializeField]
		private bool syncStorageOnDemand;

		[SerializeField]
		private string scidConsoles;

		[SerializeField]
		private string msaAppIdConsoles;

		[SerializeField]
		private string titleIdConsoles;

		[SerializeField]
		private uint numericTitleIdConsoles;

		[SerializeField]
		private string storeIdConsoles;

		[SerializeField]
		private string wishlistStoreIdConsoles;

		[SerializeField]
		private string scidWin10;

		[SerializeField]
		private string msaAppIdWin10;

		[SerializeField]
		private string titleIdWin10;

		[SerializeField]
		private uint numericTitleIdWin10;

		[SerializeField]
		private string storeIdWin10;

		public bool UsesXBL => false;

		public bool SyncStorageOnDemand => false;

		public string SCID => null;

		public string MSAAppId => null;

		public string TitleId => null;

		public uint NumericTitleId => 0u;

		public string StoreId => null;

		public string WishlistStoreId => null;
	}
}
