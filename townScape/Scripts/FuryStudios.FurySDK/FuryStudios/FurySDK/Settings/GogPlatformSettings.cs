using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class GogPlatformSettings
	{
		[SerializeField]
		private string clientId;

		[SerializeField]
		private string clientSecret;

		[SerializeField]
		private string wishlistURL;

		public string ClientID => null;

		public string ClientSecret => null;

		public string WishlistURL => null;
	}
}
