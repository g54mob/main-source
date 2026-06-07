using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class SteamPlatformSettings
	{
		[SerializeField]
		private uint appId;

		[SerializeField]
		private bool useSteamDrm;

		[SerializeField]
		private string wishlistURL;

		public uint AppID => 0u;

		public bool UseSteamDrm => false;

		public string WishlistURL => null;
	}
}
