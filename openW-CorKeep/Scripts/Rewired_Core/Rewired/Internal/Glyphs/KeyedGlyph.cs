using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint DKYqzfsrEhTdfeGToWaAWykCaQIN;

		private uint lTgGwHEvqBSZKrthwqtydaBgIYPnc;

		private object dNBDotPVkLgJBFBVLZFxSOmYMtiG;

		private bool tVkggQjnXHtldevCzroWbGcgAaJec;

		private string RIcjUjWiUjTrYzLvpEsQeUgCfsVrA;

		public bool hasCachedValue => tVkggQjnXHtldevCzroWbGcgAaJec;

		public object cachedValue
		{
			get
			{
				return dNBDotPVkLgJBFBVLZFxSOmYMtiG;
			}
			set
			{
				tVkggQjnXHtldevCzroWbGcgAaJec = true;
				dNBDotPVkLgJBFBVLZFxSOmYMtiG = value;
				if (value == null)
				{
					RIcjUjWiUjTrYzLvpEsQeUgCfsVrA = null;
				}
			}
		}

		public string cachedKey => RIcjUjWiUjTrYzLvpEsQeUgCfsVrA;

		public KeyedGlyph()
		{
			DKYqzfsrEhTdfeGToWaAWykCaQIN = 0u;
			lTgGwHEvqBSZKrthwqtydaBgIYPnc = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			DKYqzfsrEhTdfeGToWaAWykCaQIN = P_0.DKYqzfsrEhTdfeGToWaAWykCaQIN;
			lTgGwHEvqBSZKrthwqtydaBgIYPnc = P_0.lTgGwHEvqBSZKrthwqtydaBgIYPnc;
			dNBDotPVkLgJBFBVLZFxSOmYMtiG = P_0.dNBDotPVkLgJBFBVLZFxSOmYMtiG;
			tVkggQjnXHtldevCzroWbGcgAaJec = P_0.tVkggQjnXHtldevCzroWbGcgAaJec;
			RIcjUjWiUjTrYzLvpEsQeUgCfsVrA = P_0.RIcjUjWiUjTrYzLvpEsQeUgCfsVrA;
		}

		public void Clear()
		{
			DKYqzfsrEhTdfeGToWaAWykCaQIN = 0u;
			lTgGwHEvqBSZKrthwqtydaBgIYPnc = 0u;
			dNBDotPVkLgJBFBVLZFxSOmYMtiG = null;
			tVkggQjnXHtldevCzroWbGcgAaJec = false;
			RIcjUjWiUjTrYzLvpEsQeUgCfsVrA = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = DKYqzfsrEhTdfeGToWaAWykCaQIN != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != lTgGwHEvqBSZKrthwqtydaBgIYPnc;
			if (versionChanged)
			{
				Clear();
				DKYqzfsrEhTdfeGToWaAWykCaQIN = glyphProviderVersion;
				lTgGwHEvqBSZKrthwqtydaBgIYPnc = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (tVkggQjnXHtldevCzroWbGcgAaJec ? dNBDotPVkLgJBFBVLZFxSOmYMtiG : null);
				return tVkggQjnXHtldevCzroWbGcgAaJec;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				tVkggQjnXHtldevCzroWbGcgAaJec = glyphProvider.TryGetGlyph(key, out dNBDotPVkLgJBFBVLZFxSOmYMtiG) && dNBDotPVkLgJBFBVLZFxSOmYMtiG != null;
				if (tVkggQjnXHtldevCzroWbGcgAaJec)
				{
					RIcjUjWiUjTrYzLvpEsQeUgCfsVrA = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (tVkggQjnXHtldevCzroWbGcgAaJec ? dNBDotPVkLgJBFBVLZFxSOmYMtiG : null);
			return tVkggQjnXHtldevCzroWbGcgAaJec;
		}
	}
}
