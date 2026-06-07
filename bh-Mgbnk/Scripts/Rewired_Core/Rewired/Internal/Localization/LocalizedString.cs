using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint PzQRXVytQPjWfAlzYiuheUjhZkcA;

		private uint CcfpWHGYEETfeiCDxLBqheRTqDbD;

		private string rNhOotwlgLbFGbdLIWuZTVzxiecSA;

		private bool YMyQuojCTrtmwFplnUGFxxyuhxmd;

		public bool hasCachedValue => false;

		public string cachedValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LocalizedString()
		{
		}

		public LocalizedString(LocalizedString P_0)
		{
		}

		public void Clear()
		{
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = default(bool);
			result = null;
			return false;
		}
	}
}
