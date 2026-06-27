using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint GThjanDhypXiabhwMUbxqhTOpEnC;

		private uint upBgODOVNZnAHaNZKLyXARAMhTwf;

		private object sNsWVfqbBHAKADQvfyxGjszEilNNA;

		private bool cRDeuQGukVLpmsUiPQptwDxWXLoK;

		private string UVRGNnrHrhLrFesVHMAbidrEHDmp;

		public bool hasCachedValue => cRDeuQGukVLpmsUiPQptwDxWXLoK;

		public object cachedValue
		{
			get
			{
				return sNsWVfqbBHAKADQvfyxGjszEilNNA;
			}
			set
			{
				cRDeuQGukVLpmsUiPQptwDxWXLoK = true;
				sNsWVfqbBHAKADQvfyxGjszEilNNA = value;
				if (value == null)
				{
					UVRGNnrHrhLrFesVHMAbidrEHDmp = null;
				}
			}
		}

		public string cachedKey => UVRGNnrHrhLrFesVHMAbidrEHDmp;

		public KeyedGlyph()
		{
			GThjanDhypXiabhwMUbxqhTOpEnC = 0u;
			upBgODOVNZnAHaNZKLyXARAMhTwf = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			GThjanDhypXiabhwMUbxqhTOpEnC = P_0.GThjanDhypXiabhwMUbxqhTOpEnC;
			upBgODOVNZnAHaNZKLyXARAMhTwf = P_0.upBgODOVNZnAHaNZKLyXARAMhTwf;
			sNsWVfqbBHAKADQvfyxGjszEilNNA = P_0.sNsWVfqbBHAKADQvfyxGjszEilNNA;
			cRDeuQGukVLpmsUiPQptwDxWXLoK = P_0.cRDeuQGukVLpmsUiPQptwDxWXLoK;
			UVRGNnrHrhLrFesVHMAbidrEHDmp = P_0.UVRGNnrHrhLrFesVHMAbidrEHDmp;
		}

		public void Clear()
		{
			GThjanDhypXiabhwMUbxqhTOpEnC = 0u;
			upBgODOVNZnAHaNZKLyXARAMhTwf = 0u;
			sNsWVfqbBHAKADQvfyxGjszEilNNA = null;
			cRDeuQGukVLpmsUiPQptwDxWXLoK = false;
			UVRGNnrHrhLrFesVHMAbidrEHDmp = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = GThjanDhypXiabhwMUbxqhTOpEnC != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != upBgODOVNZnAHaNZKLyXARAMhTwf;
			if (versionChanged)
			{
				Clear();
				GThjanDhypXiabhwMUbxqhTOpEnC = glyphProviderVersion;
				upBgODOVNZnAHaNZKLyXARAMhTwf = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (cRDeuQGukVLpmsUiPQptwDxWXLoK ? sNsWVfqbBHAKADQvfyxGjszEilNNA : null);
				return cRDeuQGukVLpmsUiPQptwDxWXLoK;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				cRDeuQGukVLpmsUiPQptwDxWXLoK = glyphProvider.TryGetGlyph(key, out sNsWVfqbBHAKADQvfyxGjszEilNNA) && sNsWVfqbBHAKADQvfyxGjszEilNNA != null;
				if (cRDeuQGukVLpmsUiPQptwDxWXLoK)
				{
					UVRGNnrHrhLrFesVHMAbidrEHDmp = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (cRDeuQGukVLpmsUiPQptwDxWXLoK ? sNsWVfqbBHAKADQvfyxGjszEilNNA : null);
			return cRDeuQGukVLpmsUiPQptwDxWXLoK;
		}
	}
}
