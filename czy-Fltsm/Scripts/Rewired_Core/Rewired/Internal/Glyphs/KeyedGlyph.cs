using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		public const uint INVALID_VERSION = 0u;

		private uint TnUujeKPenDbJIXrdvvfCPifXNAz;

		private uint hnkGiQPlWZxDeQkPbgoTGvJjIHHEb;

		private object ppJJcOdWDBwbomzGKSYJNkSrDyec;

		private bool ppeGyBHKjLWtNOpowhbdcLgbihXfb;

		private string FnobKqIyahInqeUNeQrdTBglhvVPA;

		public bool hasCachedValue => ppeGyBHKjLWtNOpowhbdcLgbihXfb;

		public object cachedValue
		{
			get
			{
				return ppJJcOdWDBwbomzGKSYJNkSrDyec;
			}
			set
			{
				ppeGyBHKjLWtNOpowhbdcLgbihXfb = true;
				ppJJcOdWDBwbomzGKSYJNkSrDyec = value;
				if (value == null)
				{
					FnobKqIyahInqeUNeQrdTBglhvVPA = null;
				}
			}
		}

		public string cachedKey => FnobKqIyahInqeUNeQrdTBglhvVPA;

		public KeyedGlyph()
		{
			TnUujeKPenDbJIXrdvvfCPifXNAz = 0u;
			hnkGiQPlWZxDeQkPbgoTGvJjIHHEb = 0u;
		}

		public KeyedGlyph(KeyedGlyph P_0)
		{
			TnUujeKPenDbJIXrdvvfCPifXNAz = P_0.TnUujeKPenDbJIXrdvvfCPifXNAz;
			hnkGiQPlWZxDeQkPbgoTGvJjIHHEb = P_0.hnkGiQPlWZxDeQkPbgoTGvJjIHHEb;
			ppJJcOdWDBwbomzGKSYJNkSrDyec = P_0.ppJJcOdWDBwbomzGKSYJNkSrDyec;
			ppeGyBHKjLWtNOpowhbdcLgbihXfb = P_0.ppeGyBHKjLWtNOpowhbdcLgbihXfb;
			FnobKqIyahInqeUNeQrdTBglhvVPA = P_0.FnobKqIyahInqeUNeQrdTBglhvVPA;
		}

		public void Clear()
		{
			TnUujeKPenDbJIXrdvvfCPifXNAz = 0u;
			hnkGiQPlWZxDeQkPbgoTGvJjIHHEb = 0u;
			ppJJcOdWDBwbomzGKSYJNkSrDyec = null;
			ppeGyBHKjLWtNOpowhbdcLgbihXfb = false;
			FnobKqIyahInqeUNeQrdTBglhvVPA = null;
		}

		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = TnUujeKPenDbJIXrdvvfCPifXNAz != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != hnkGiQPlWZxDeQkPbgoTGvJjIHHEb;
			if (versionChanged)
			{
				Clear();
				TnUujeKPenDbJIXrdvvfCPifXNAz = glyphProviderVersion;
				hnkGiQPlWZxDeQkPbgoTGvJjIHHEb = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (ppeGyBHKjLWtNOpowhbdcLgbihXfb ? ppJJcOdWDBwbomzGKSYJNkSrDyec : null);
				return ppeGyBHKjLWtNOpowhbdcLgbihXfb;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				ppeGyBHKjLWtNOpowhbdcLgbihXfb = glyphProvider.TryGetGlyph(key, out ppJJcOdWDBwbomzGKSYJNkSrDyec) && ppJJcOdWDBwbomzGKSYJNkSrDyec != null;
				if (ppeGyBHKjLWtNOpowhbdcLgbihXfb)
				{
					FnobKqIyahInqeUNeQrdTBglhvVPA = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (ppeGyBHKjLWtNOpowhbdcLgbihXfb ? ppJJcOdWDBwbomzGKSYJNkSrDyec : null);
			return ppeGyBHKjLWtNOpowhbdcLgbihXfb;
		}
	}
}
