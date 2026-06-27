using System;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Glyphs
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class GlyphManager
	{
		private sealed class CDKXlEYFavoThhrMcmPyPTOKeDpU
		{
			[Serializable]
			private sealed class yjQrBRqXKwKskDAOnPoVUemYabZaA
			{
				public static readonly yjQrBRqXKwKskDAOnPoVUemYabZaA _003C_003E9 = new yjQrBRqXKwKskDAOnPoVUemYabZaA();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void iyWIBHwqHdHfugJEnnfWFJXUMMDF(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float tBwaScTWenaCxZOQKyOoehAlbveX = 60f;

			private readonly global::DKUUkxPGBuBtODzxLffUargekjJN<IPrefetch> cWMOcYeHQVSJYRmBnSEwMcXpiUMC;

			public bool oSfSGqFuPAXLkIkQmppTfgenBsVb;

			public IGlyphProvider TCsAiIeRwBomEijFAGWYoTgCMdgLe;

			public uint nkNcbkDPLSVMOuvgaisTbFMyagLl;

			private Action<IPrefetch> QDhcKhKnWsLqZLYxrBbMaknISIiub = yjQrBRqXKwKskDAOnPoVUemYabZaA._003C_003E9.iyWIBHwqHdHfugJEnnfWFJXUMMDF;

			private Id IUrrHZPuTBSweUOKfhLPLuTESNGP;

			public CDKXlEYFavoThhrMcmPyPTOKeDpU()
			{
				cWMOcYeHQVSJYRmBnSEwMcXpiUMC = new global::DKUUkxPGBuBtODzxLffUargekjJN<IPrefetch>(60f);
				nkNcbkDPLSVMOuvgaisTbFMyagLl = 0u;
				IUrrHZPuTBSweUOKfhLPLuTESNGP = 1u;
			}

			public void aaTPZgiJzlEhtjaWDiGiyzviKUGk(IGlyphProvider P_0)
			{
				TCsAiIeRwBomEijFAGWYoTgCMdgLe = P_0;
				if (P_0 != null)
				{
					nkNcbkDPLSVMOuvgaisTbFMyagLl = IUrrHZPuTBSweUOKfhLPLuTESNGP.id;
					IUrrHZPuTBSweUOKfhLPLuTESNGP.Increment();
				}
				else
				{
					nkNcbkDPLSVMOuvgaisTbFMyagLl = 0u;
				}
				jdDDWLYUHhxrYYhBBUSPLIWcxRNU();
			}

			public void RdTIiUnfHYjWIrypFWIBfdpGyJYn(bool P_0)
			{
				if (P_0 != oSfSGqFuPAXLkIkQmppTfgenBsVb)
				{
					oSfSGqFuPAXLkIkQmppTfgenBsVb = P_0;
					if (P_0)
					{
						xuSZstCxmiFFgGtfHxRWOeCDAEZCA();
					}
				}
			}

			public void xuSZstCxmiFFgGtfHxRWOeCDAEZCA()
			{
				if (TCsAiIeRwBomEijFAGWYoTgCMdgLe != null)
				{
					cWMOcYeHQVSJYRmBnSEwMcXpiUMC.rEvRuOqxuQPMRinSqAcXkjIDcEeH(QDhcKhKnWsLqZLYxrBbMaknISIiub);
				}
			}

			public void cmjgnkngoRBFiIGZIFHQbmHFLhjyA()
			{
				if (TCsAiIeRwBomEijFAGWYoTgCMdgLe != null)
				{
					nkNcbkDPLSVMOuvgaisTbFMyagLl = IUrrHZPuTBSweUOKfhLPLuTESNGP.id;
					IUrrHZPuTBSweUOKfhLPLuTESNGP.Increment();
					if (oSfSGqFuPAXLkIkQmppTfgenBsVb)
					{
						xuSZstCxmiFFgGtfHxRWOeCDAEZCA();
					}
					else
					{
						jdDDWLYUHhxrYYhBBUSPLIWcxRNU();
					}
				}
			}

			public uint jXZUnIbPYgQyQMqcFpOJwfNDQJXb(IPrefetch P_0)
			{
				return cWMOcYeHQVSJYRmBnSEwMcXpiUMC.otMvaeITjObGwaebZFuDBIMyrbKIA(P_0);
			}

			public bool nKxAUKMsRMbIPXOYbixpDBNkgqpGA(uint P_0)
			{
				return cWMOcYeHQVSJYRmBnSEwMcXpiUMC.jtIXMnMsdulgRWTRTGaHgHIXGSW(P_0);
			}

			public void jdDDWLYUHhxrYYhBBUSPLIWcxRNU()
			{
				cWMOcYeHQVSJYRmBnSEwMcXpiUMC.LGsdbubURKsvZrBcnoMUgYqozOqvA();
			}
		}

		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateGlyphResultFlags
		{
			None = 0,
			Failed = 1,
			IsCachedValue = 2,
			Changed = 4,
			JustGot = 8
		}

		private static CDKXlEYFavoThhrMcmPyPTOKeDpU qAVdUkgsgixGhWjdwALYzznqJrWJ;

		private static StringBuilder zJJMUGpfTHBWzqCcvIELnAFZKDwu;

		public static bool isEnabled
		{
			get
			{
				if (qAVdUkgsgixGhWjdwALYzznqJrWJ == null)
				{
					return false;
				}
				return qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe != null;
			}
		}

		public static uint version
		{
			get
			{
				oHrbvicsIieNmhNrWaRZmycMpGQf();
				return qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				oHrbvicsIieNmhNrWaRZmycMpGQf();
				return qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe;
			}
			set
			{
				oHrbvicsIieNmhNrWaRZmycMpGQf();
				qAVdUkgsgixGhWjdwALYzznqJrWJ.aaTPZgiJzlEhtjaWDiGiyzviKUGk(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				oHrbvicsIieNmhNrWaRZmycMpGQf();
				return qAVdUkgsgixGhWjdwALYzznqJrWJ.oSfSGqFuPAXLkIkQmppTfgenBsVb;
			}
			set
			{
				oHrbvicsIieNmhNrWaRZmycMpGQf();
				qAVdUkgsgixGhWjdwALYzznqJrWJ.RdTIiUnfHYjWIrypFWIBfdpGyJYn(value);
			}
		}

		public static void Initialize()
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ != null)
			{
				throw new Exception("Already initialized");
			}
			qAVdUkgsgixGhWjdwALYzznqJrWJ = new CDKXlEYFavoThhrMcmPyPTOKeDpU();
		}

		public static void Deinitialize()
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ != null)
			{
				qAVdUkgsgixGhWjdwALYzznqJrWJ = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			oHrbvicsIieNmhNrWaRZmycMpGQf();
			id = qAVdUkgsgixGhWjdwALYzznqJrWJ.jXZUnIbPYgQyQMqcFpOJwfNDQJXb(obj);
		}

		public static bool Remove(ref Id id)
		{
			oHrbvicsIieNmhNrWaRZmycMpGQf();
			bool result = qAVdUkgsgixGhWjdwALYzznqJrWJ.nKxAUKMsRMbIPXOYbixpDBNkgqpGA(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			oHrbvicsIieNmhNrWaRZmycMpGQf();
			qAVdUkgsgixGhWjdwALYzznqJrWJ.xuSZstCxmiFFgGtfHxRWOeCDAEZCA();
		}

		public static void Reload()
		{
			oHrbvicsIieNmhNrWaRZmycMpGQf();
			qAVdUkgsgixGhWjdwALYzznqJrWJ.cmjgnkngoRBFiIGZIFHQbmHFLhjyA();
		}

		private static void oHrbvicsIieNmhNrWaRZmycMpGQf()
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe != null)
			{
				return keyedGlyph.TryGetValue(null, qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe, qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe, qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (TRxndvtNMBvWECYFelRlRpllFGAbA(keyedGlyph, parentKeys, keyCategory, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, string key, string keyCategory, IReadOnlyList<string> parentKeys, out object result)
		{
			if (qAVdUkgsgixGhWjdwALYzznqJrWJ.TCsAiIeRwBomEijFAGWYoTgCMdgLe == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (holWQTffdsiHllervGRniENQuaJN(keyedGlyph, key, keyCategory, parentKeys, out result))
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		private static bool TRxndvtNMBvWECYFelRlRpllFGAbA(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
		{
			if (P_1 == null)
			{
				P_3 = null;
				return false;
			}
			bool result = false;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			int num = 0;
			while (true)
			{
				if (num < P_1.Count)
				{
					if (!string.IsNullOrEmpty(P_1[num]))
					{
						sharedStringBuilder.Length = 0;
						if (flag)
						{
							sharedStringBuilder.Append(P_2);
						}
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, 0u, out P_3))
						{
							result = true;
							break;
						}
					}
					num++;
					continue;
				}
				P_3 = null;
				break;
			}
			P_0.cachedValue = P_3;
			return result;
		}

		private static bool holWQTffdsiHllervGRniENQuaJN(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_4 = null;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0u;
			bool flag = !string.IsNullOrEmpty(P_2);
			StringBuilder sharedStringBuilder = GetSharedStringBuilder();
			if (P_3 != null)
			{
				for (int i = 0; i < P_3.Count; i++)
				{
					if (string.IsNullOrEmpty(P_3[i]))
					{
						continue;
					}
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_3[i]);
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, dependenciesVersion, out P_4))
					{
						continue;
					}
					goto IL_007d;
				}
			}
			if (P_3 == null || P_3.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), qAVdUkgsgixGhWjdwALYzznqJrWJ.nkNcbkDPLSVMOuvgaisTbFMyagLl, dependenciesVersion, out P_4))
				{
					result = true;
					goto IL_00d9;
				}
			}
			P_4 = null;
			goto IL_00d9;
			IL_00d9:
			P_0.cachedValue = P_4;
			return result;
			IL_007d:
			result = true;
			goto IL_00d9;
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (zJJMUGpfTHBWzqCcvIELnAFZKDwu != null)
			{
				zJJMUGpfTHBWzqCcvIELnAFZKDwu.Length = 0;
				return zJJMUGpfTHBWzqCcvIELnAFZKDwu;
			}
			return zJJMUGpfTHBWzqCcvIELnAFZKDwu = new StringBuilder();
		}
	}
}
