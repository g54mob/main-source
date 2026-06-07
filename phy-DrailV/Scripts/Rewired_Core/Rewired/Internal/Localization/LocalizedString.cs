using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint tfAdzpwjdzpgCqNajGKdsMzPQZUn;

		private uint gIIxuCBAqZyQkJfoJMLsTBbJbVGn;

		private string bMyURbLdeuRteirDJTlmRhCSISBhA;

		private bool OuGGoaNDRMLLtOdUUPeUvlZLLVkn;

		public bool hasCachedValue => OuGGoaNDRMLLtOdUUPeUvlZLLVkn;

		public string cachedValue
		{
			get
			{
				return bMyURbLdeuRteirDJTlmRhCSISBhA;
			}
			set
			{
				OuGGoaNDRMLLtOdUUPeUvlZLLVkn = true;
				bMyURbLdeuRteirDJTlmRhCSISBhA = value;
			}
		}

		public LocalizedString()
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = 0u;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = P_0.tfAdzpwjdzpgCqNajGKdsMzPQZUn;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = P_0.gIIxuCBAqZyQkJfoJMLsTBbJbVGn;
			bMyURbLdeuRteirDJTlmRhCSISBhA = P_0.bMyURbLdeuRteirDJTlmRhCSISBhA;
			OuGGoaNDRMLLtOdUUPeUvlZLLVkn = P_0.OuGGoaNDRMLLtOdUUPeUvlZLLVkn;
		}

		public void Clear()
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = 0u;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = 0u;
			bMyURbLdeuRteirDJTlmRhCSISBhA = null;
			OuGGoaNDRMLLtOdUUPeUvlZLLVkn = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = tfAdzpwjdzpgCqNajGKdsMzPQZUn != ((localizer != null) ? localizerVersion : 0) || userVersion != gIIxuCBAqZyQkJfoJMLsTBbJbVGn;
			if (versionChanged)
			{
				Clear();
				tfAdzpwjdzpgCqNajGKdsMzPQZUn = localizerVersion;
				gIIxuCBAqZyQkJfoJMLsTBbJbVGn = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (OuGGoaNDRMLLtOdUUPeUvlZLLVkn ? bMyURbLdeuRteirDJTlmRhCSISBhA : null);
				return OuGGoaNDRMLLtOdUUPeUvlZLLVkn;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				OuGGoaNDRMLLtOdUUPeUvlZLLVkn = localizer.TryGetLocalizedString(key, out bMyURbLdeuRteirDJTlmRhCSISBhA) && !string.IsNullOrEmpty(bMyURbLdeuRteirDJTlmRhCSISBhA);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (OuGGoaNDRMLLtOdUUPeUvlZLLVkn ? bMyURbLdeuRteirDJTlmRhCSISBhA : null);
			return OuGGoaNDRMLLtOdUUPeUvlZLLVkn;
		}
	}
}
