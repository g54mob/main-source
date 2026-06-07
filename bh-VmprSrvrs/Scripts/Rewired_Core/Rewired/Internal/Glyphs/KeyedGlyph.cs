using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint DVUSfsIrHQQwMoPWwkcRXCUqHhgO;

		private uint vqHDSIVrmGkdflyiavhknfjurhdE;

		private object dSHIkcrXxgKBmVnCLuZgBGUwHtGV;

		private bool noXDLVsMmSGExNTjyiJVMWgTPfS;

		private string TxknNyeaVIGSbnigrloBJNCsmHrV;

		public bool hasCachedValue => false;

		public object cachedValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string cachedKey => null;

		public KeyedGlyph()
		{
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
		}

		public void Clear()
		{
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = default(bool);
			result = null;
			return false;
		}
	}
}
