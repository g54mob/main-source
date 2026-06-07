using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint OCshXLxQHRgYEklySfUAEkOJEHfbb;

		private uint ZwdexAFukFDurBIJEjxUpruhXmwZ;

		private string uiocSbnnIQgCWHQObWunZojNkxth;

		private bool NztrEeiwleQWmfRmEBoflVyClIfL;

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
