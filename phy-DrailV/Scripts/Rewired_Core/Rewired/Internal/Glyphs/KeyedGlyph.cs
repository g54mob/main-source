using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint tfAdzpwjdzpgCqNajGKdsMzPQZUn;

		private uint gIIxuCBAqZyQkJfoJMLsTBbJbVGn;

		private object bMyURbLdeuRteirDJTlmRhCSISBhA;

		private bool OuGGoaNDRMLLtOdUUPeUvlZLLVkn;

		private string vMxkGNKHXgtrLlIqLvgNcCFGiglt;

		public bool hasCachedValue => OuGGoaNDRMLLtOdUUPeUvlZLLVkn;

		public object cachedValue
		{
			get
			{
				return bMyURbLdeuRteirDJTlmRhCSISBhA;
			}
			set
			{
				OuGGoaNDRMLLtOdUUPeUvlZLLVkn = true;
				bMyURbLdeuRteirDJTlmRhCSISBhA = value;
				if (value == null)
				{
					vMxkGNKHXgtrLlIqLvgNcCFGiglt = null;
				}
			}
		}

		public string cachedKey => vMxkGNKHXgtrLlIqLvgNcCFGiglt;

		public KeyedGlyph()
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = 0u;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = P_0.tfAdzpwjdzpgCqNajGKdsMzPQZUn;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = P_0.gIIxuCBAqZyQkJfoJMLsTBbJbVGn;
			bMyURbLdeuRteirDJTlmRhCSISBhA = P_0.bMyURbLdeuRteirDJTlmRhCSISBhA;
			OuGGoaNDRMLLtOdUUPeUvlZLLVkn = P_0.OuGGoaNDRMLLtOdUUPeUvlZLLVkn;
			vMxkGNKHXgtrLlIqLvgNcCFGiglt = P_0.vMxkGNKHXgtrLlIqLvgNcCFGiglt;
		}

		public void Clear()
		{
			tfAdzpwjdzpgCqNajGKdsMzPQZUn = 0u;
			gIIxuCBAqZyQkJfoJMLsTBbJbVGn = 0u;
			bMyURbLdeuRteirDJTlmRhCSISBhA = null;
			OuGGoaNDRMLLtOdUUPeUvlZLLVkn = false;
			vMxkGNKHXgtrLlIqLvgNcCFGiglt = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = tfAdzpwjdzpgCqNajGKdsMzPQZUn != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != gIIxuCBAqZyQkJfoJMLsTBbJbVGn;
			if (versionChanged)
			{
				Clear();
				tfAdzpwjdzpgCqNajGKdsMzPQZUn = glyphProviderVersion;
				gIIxuCBAqZyQkJfoJMLsTBbJbVGn = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
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
				OuGGoaNDRMLLtOdUUPeUvlZLLVkn = glyphProvider.TryGetGlyph(key, out bMyURbLdeuRteirDJTlmRhCSISBhA) && bMyURbLdeuRteirDJTlmRhCSISBhA != null;
				if (OuGGoaNDRMLLtOdUUPeUvlZLLVkn)
				{
					vMxkGNKHXgtrLlIqLvgNcCFGiglt = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (OuGGoaNDRMLLtOdUUPeUvlZLLVkn ? bMyURbLdeuRteirDJTlmRhCSISBhA : null);
			return OuGGoaNDRMLLtOdUUPeUvlZLLVkn;
		}
	}
}
