using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint OASzGnUMTVypLsNIZXaFVvaNzpVG;

		private uint PORBEwmJcBSAaUdlPGsFQoGjbKSo;

		private string sMWZODWiQKpCLXcicnNowDZZyKNv;

		private bool HHieOxTrcBsnUnCVBrmAOKbWDNuB;

		public bool hasCachedValue => HHieOxTrcBsnUnCVBrmAOKbWDNuB;

		public string cachedValue
		{
			get
			{
				return sMWZODWiQKpCLXcicnNowDZZyKNv;
			}
			set
			{
				HHieOxTrcBsnUnCVBrmAOKbWDNuB = true;
				sMWZODWiQKpCLXcicnNowDZZyKNv = value;
			}
		}

		public LocalizedString()
		{
			OASzGnUMTVypLsNIZXaFVvaNzpVG = 0u;
			PORBEwmJcBSAaUdlPGsFQoGjbKSo = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			OASzGnUMTVypLsNIZXaFVvaNzpVG = P_0.OASzGnUMTVypLsNIZXaFVvaNzpVG;
			PORBEwmJcBSAaUdlPGsFQoGjbKSo = P_0.PORBEwmJcBSAaUdlPGsFQoGjbKSo;
			sMWZODWiQKpCLXcicnNowDZZyKNv = P_0.sMWZODWiQKpCLXcicnNowDZZyKNv;
			HHieOxTrcBsnUnCVBrmAOKbWDNuB = P_0.HHieOxTrcBsnUnCVBrmAOKbWDNuB;
		}

		public void Clear()
		{
			OASzGnUMTVypLsNIZXaFVvaNzpVG = 0u;
			PORBEwmJcBSAaUdlPGsFQoGjbKSo = 0u;
			sMWZODWiQKpCLXcicnNowDZZyKNv = null;
			HHieOxTrcBsnUnCVBrmAOKbWDNuB = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = OASzGnUMTVypLsNIZXaFVvaNzpVG != ((localizer != null) ? localizerVersion : 0) || userVersion != PORBEwmJcBSAaUdlPGsFQoGjbKSo;
			if (versionChanged)
			{
				Clear();
				OASzGnUMTVypLsNIZXaFVvaNzpVG = localizerVersion;
				PORBEwmJcBSAaUdlPGsFQoGjbKSo = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (HHieOxTrcBsnUnCVBrmAOKbWDNuB ? sMWZODWiQKpCLXcicnNowDZZyKNv : null);
				return HHieOxTrcBsnUnCVBrmAOKbWDNuB;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				HHieOxTrcBsnUnCVBrmAOKbWDNuB = localizer.TryGetLocalizedString(key, out sMWZODWiQKpCLXcicnNowDZZyKNv) && !string.IsNullOrEmpty(sMWZODWiQKpCLXcicnNowDZZyKNv);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (HHieOxTrcBsnUnCVBrmAOKbWDNuB ? sMWZODWiQKpCLXcicnNowDZZyKNv : null);
			return HHieOxTrcBsnUnCVBrmAOKbWDNuB;
		}
	}
}
