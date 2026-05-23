using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint xqwYIFKLEDzWOFfHnvPkHJRvfHGH;

		private uint iBdaMSyxfPTixbqgxGMkGBpThKLT;

		private string ZQaFpnbKXKnFCtcxSwnZkgeloESyA;

		private bool cxvHscLkFefjqKBllVIXKfZkBGwc;

		public bool hasCachedValue => cxvHscLkFefjqKBllVIXKfZkBGwc;

		public string cachedValue
		{
			get
			{
				return ZQaFpnbKXKnFCtcxSwnZkgeloESyA;
			}
			set
			{
				cxvHscLkFefjqKBllVIXKfZkBGwc = true;
				ZQaFpnbKXKnFCtcxSwnZkgeloESyA = value;
			}
		}

		public LocalizedString()
		{
			xqwYIFKLEDzWOFfHnvPkHJRvfHGH = 0u;
			iBdaMSyxfPTixbqgxGMkGBpThKLT = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			xqwYIFKLEDzWOFfHnvPkHJRvfHGH = P_0.xqwYIFKLEDzWOFfHnvPkHJRvfHGH;
			iBdaMSyxfPTixbqgxGMkGBpThKLT = P_0.iBdaMSyxfPTixbqgxGMkGBpThKLT;
			ZQaFpnbKXKnFCtcxSwnZkgeloESyA = P_0.ZQaFpnbKXKnFCtcxSwnZkgeloESyA;
			cxvHscLkFefjqKBllVIXKfZkBGwc = P_0.cxvHscLkFefjqKBllVIXKfZkBGwc;
		}

		public void Clear()
		{
			xqwYIFKLEDzWOFfHnvPkHJRvfHGH = 0u;
			iBdaMSyxfPTixbqgxGMkGBpThKLT = 0u;
			ZQaFpnbKXKnFCtcxSwnZkgeloESyA = null;
			cxvHscLkFefjqKBllVIXKfZkBGwc = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = xqwYIFKLEDzWOFfHnvPkHJRvfHGH != ((localizer != null) ? localizerVersion : 0) || userVersion != iBdaMSyxfPTixbqgxGMkGBpThKLT;
			if (versionChanged)
			{
				Clear();
				xqwYIFKLEDzWOFfHnvPkHJRvfHGH = localizerVersion;
				iBdaMSyxfPTixbqgxGMkGBpThKLT = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (cxvHscLkFefjqKBllVIXKfZkBGwc ? ZQaFpnbKXKnFCtcxSwnZkgeloESyA : null);
				return cxvHscLkFefjqKBllVIXKfZkBGwc;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				cxvHscLkFefjqKBllVIXKfZkBGwc = localizer.TryGetLocalizedString(key, out ZQaFpnbKXKnFCtcxSwnZkgeloESyA) && !string.IsNullOrEmpty(ZQaFpnbKXKnFCtcxSwnZkgeloESyA);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (cxvHscLkFefjqKBllVIXKfZkBGwc ? ZQaFpnbKXKnFCtcxSwnZkgeloESyA : null);
			return cxvHscLkFefjqKBllVIXKfZkBGwc;
		}
	}
}
