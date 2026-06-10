using System;

namespace TwitchIntegration
{
	[Serializable]
	public struct OAuth
	{
		public string accessToken;

		public string scope;

		public string state;
	}
}
