using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint wOmYYKYTlpboMeFoDoVMBPZBeRJT;

		private uint YbEIZaLMLFkOdvfOBrOabMkXSJSo;

		private object SvrmMajTKLfuePqXyshvRBkHHlaB;

		private bool GDGJLlRZaNceMvHzQRFOHMJTsjCN;

		private string srOGbObylriwpJbGMPJSEZDVcvGAA;

		public bool hasCachedValue => GDGJLlRZaNceMvHzQRFOHMJTsjCN;

		public object cachedValue
		{
			get
			{
				return SvrmMajTKLfuePqXyshvRBkHHlaB;
			}
			set
			{
				GDGJLlRZaNceMvHzQRFOHMJTsjCN = true;
				SvrmMajTKLfuePqXyshvRBkHHlaB = value;
				if (value == null)
				{
					srOGbObylriwpJbGMPJSEZDVcvGAA = null;
				}
			}
		}

		public string cachedKey => srOGbObylriwpJbGMPJSEZDVcvGAA;

		public KeyedGlyph()
		{
			wOmYYKYTlpboMeFoDoVMBPZBeRJT = 0u;
			YbEIZaLMLFkOdvfOBrOabMkXSJSo = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			wOmYYKYTlpboMeFoDoVMBPZBeRJT = P_0.wOmYYKYTlpboMeFoDoVMBPZBeRJT;
			YbEIZaLMLFkOdvfOBrOabMkXSJSo = P_0.YbEIZaLMLFkOdvfOBrOabMkXSJSo;
			SvrmMajTKLfuePqXyshvRBkHHlaB = P_0.SvrmMajTKLfuePqXyshvRBkHHlaB;
			GDGJLlRZaNceMvHzQRFOHMJTsjCN = P_0.GDGJLlRZaNceMvHzQRFOHMJTsjCN;
			srOGbObylriwpJbGMPJSEZDVcvGAA = P_0.srOGbObylriwpJbGMPJSEZDVcvGAA;
		}

		public void Clear()
		{
			wOmYYKYTlpboMeFoDoVMBPZBeRJT = 0u;
			YbEIZaLMLFkOdvfOBrOabMkXSJSo = 0u;
			SvrmMajTKLfuePqXyshvRBkHHlaB = null;
			GDGJLlRZaNceMvHzQRFOHMJTsjCN = false;
			srOGbObylriwpJbGMPJSEZDVcvGAA = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = wOmYYKYTlpboMeFoDoVMBPZBeRJT != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != YbEIZaLMLFkOdvfOBrOabMkXSJSo;
			if (versionChanged)
			{
				Clear();
				wOmYYKYTlpboMeFoDoVMBPZBeRJT = glyphProviderVersion;
				YbEIZaLMLFkOdvfOBrOabMkXSJSo = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (GDGJLlRZaNceMvHzQRFOHMJTsjCN ? SvrmMajTKLfuePqXyshvRBkHHlaB : null);
				return GDGJLlRZaNceMvHzQRFOHMJTsjCN;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				GDGJLlRZaNceMvHzQRFOHMJTsjCN = glyphProvider.TryGetGlyph(key, out SvrmMajTKLfuePqXyshvRBkHHlaB) && SvrmMajTKLfuePqXyshvRBkHHlaB != null;
				if (GDGJLlRZaNceMvHzQRFOHMJTsjCN)
				{
					srOGbObylriwpJbGMPJSEZDVcvGAA = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (GDGJLlRZaNceMvHzQRFOHMJTsjCN ? SvrmMajTKLfuePqXyshvRBkHHlaB : null);
			return GDGJLlRZaNceMvHzQRFOHMJTsjCN;
		}
	}
}
