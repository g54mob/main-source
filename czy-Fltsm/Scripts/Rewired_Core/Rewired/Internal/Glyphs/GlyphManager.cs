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
		private sealed class ZdtxPVBhfUhCUDMHiaaZgDnQxGjA
		{
			[Serializable]
			private sealed class vAxPvGnjJccGZfJCANLTlCvlADsiA
			{
				public static readonly vAxPvGnjJccGZfJCANLTlCvlADsiA _003C_003E9 = new vAxPvGnjJccGZfJCANLTlCvlADsiA();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void pjvjKCpKQnAhFQGKKaSYFqQpHkeJA(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float kgDicvELrtnSSnkIlvHsTHDGZTVl = 60f;

			private readonly global::KzfQCuMWKcBHvhIjiQIELWzVhLyv<IPrefetch> nGpTARfUKFoxpzxwOvYubLdIQSpH;

			public bool nJCWWRWOvYnbguuaBpGpGDbWLnLu;

			public IGlyphProvider CJuHDSrIPOefDcBvxFWeGxxRKel;

			public uint mWojqnGeIWUvnWcwZvTNWyBBvGeo;

			private Action<IPrefetch> VIEwcuqHaYtcmChMAsMHuuzuHVF = vAxPvGnjJccGZfJCANLTlCvlADsiA._003C_003E9.pjvjKCpKQnAhFQGKKaSYFqQpHkeJA;

			private Id DPYBjGWCYHEIXmpYSEoZuPOxhnbJA;

			public ZdtxPVBhfUhCUDMHiaaZgDnQxGjA()
			{
				nGpTARfUKFoxpzxwOvYubLdIQSpH = new global::KzfQCuMWKcBHvhIjiQIELWzVhLyv<IPrefetch>(60f);
				mWojqnGeIWUvnWcwZvTNWyBBvGeo = 0u;
				DPYBjGWCYHEIXmpYSEoZuPOxhnbJA = 1u;
			}

			public void tieADbnrupoaYPkSwgzwDCwJuenk(IGlyphProvider P_0)
			{
				CJuHDSrIPOefDcBvxFWeGxxRKel = P_0;
				if (P_0 != null)
				{
					mWojqnGeIWUvnWcwZvTNWyBBvGeo = DPYBjGWCYHEIXmpYSEoZuPOxhnbJA.id;
					DPYBjGWCYHEIXmpYSEoZuPOxhnbJA.Increment();
				}
				else
				{
					mWojqnGeIWUvnWcwZvTNWyBBvGeo = 0u;
				}
				uYiIdAXFKxEFlswFeSpZsAVPzvgP();
			}

			public void GceTAVkjIOcijjNrqOlNHWogxbzDB(bool P_0)
			{
				if (P_0 != nJCWWRWOvYnbguuaBpGpGDbWLnLu)
				{
					nJCWWRWOvYnbguuaBpGpGDbWLnLu = P_0;
					if (P_0)
					{
						ijxiraTHjwzmVkEteImUthDoQiyy();
					}
				}
			}

			public void ijxiraTHjwzmVkEteImUthDoQiyy()
			{
				if (CJuHDSrIPOefDcBvxFWeGxxRKel != null)
				{
					nGpTARfUKFoxpzxwOvYubLdIQSpH.cDSrTXhbnOhragUUBjpNUNZmnQXY(VIEwcuqHaYtcmChMAsMHuuzuHVF);
				}
			}

			public void jyGQydgxvRltFeiNdgcOAPAuYLGtA()
			{
				if (CJuHDSrIPOefDcBvxFWeGxxRKel != null)
				{
					mWojqnGeIWUvnWcwZvTNWyBBvGeo = DPYBjGWCYHEIXmpYSEoZuPOxhnbJA.id;
					DPYBjGWCYHEIXmpYSEoZuPOxhnbJA.Increment();
					if (nJCWWRWOvYnbguuaBpGpGDbWLnLu)
					{
						ijxiraTHjwzmVkEteImUthDoQiyy();
					}
					else
					{
						uYiIdAXFKxEFlswFeSpZsAVPzvgP();
					}
				}
			}

			public uint afmuCgiNUghqDihqaDGQeDguVusEA(IPrefetch P_0)
			{
				return nGpTARfUKFoxpzxwOvYubLdIQSpH.hIvovHVycAsETKhbyBaTjGTJZfpk(P_0);
			}

			public bool gZYNYJRYUMawetfUUgOhqmMPwWMP(uint P_0)
			{
				return nGpTARfUKFoxpzxwOvYubLdIQSpH.mWWzFZepvjeRDDpPaQhsUmEzGyxyA(P_0);
			}

			public void uYiIdAXFKxEFlswFeSpZsAVPzvgP()
			{
				nGpTARfUKFoxpzxwOvYubLdIQSpH.QBBfslHhUSFaibroWpVWnhhNeeBH();
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

		private static ZdtxPVBhfUhCUDMHiaaZgDnQxGjA rcohlxjupqeZImshLkQGCCeDdUxk;

		private static StringBuilder izmPKZkGYTxfCQboSubPGqOkhtBl;

		public static bool isEnabled
		{
			get
			{
				if (rcohlxjupqeZImshLkQGCCeDdUxk == null)
				{
					return false;
				}
				return rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel != null;
			}
		}

		public static uint version
		{
			get
			{
				dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
				return rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
				return rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel;
			}
			set
			{
				dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
				rcohlxjupqeZImshLkQGCCeDdUxk.tieADbnrupoaYPkSwgzwDCwJuenk(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
				return rcohlxjupqeZImshLkQGCCeDdUxk.nJCWWRWOvYnbguuaBpGpGDbWLnLu;
			}
			set
			{
				dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
				rcohlxjupqeZImshLkQGCCeDdUxk.GceTAVkjIOcijjNrqOlNHWogxbzDB(value);
			}
		}

		public static void Initialize()
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk != null)
			{
				throw new Exception("Already initialized");
			}
			rcohlxjupqeZImshLkQGCCeDdUxk = new ZdtxPVBhfUhCUDMHiaaZgDnQxGjA();
		}

		public static void Deinitialize()
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk != null)
			{
				rcohlxjupqeZImshLkQGCCeDdUxk = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
			id = rcohlxjupqeZImshLkQGCCeDdUxk.afmuCgiNUghqDihqaDGQeDguVusEA(obj);
		}

		public static bool Remove(ref Id id)
		{
			dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
			bool result = rcohlxjupqeZImshLkQGCCeDdUxk.gZYNYJRYUMawetfUUgOhqmMPwWMP(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
			rcohlxjupqeZImshLkQGCCeDdUxk.ijxiraTHjwzmVkEteImUthDoQiyy();
		}

		public static void Reload()
		{
			dxEfrpdzfiISDMNRnaFZhLhEvPdhc();
			rcohlxjupqeZImshLkQGCCeDdUxk.jyGQydgxvRltFeiNdgcOAPAuYLGtA();
		}

		private static void dxEfrpdzfiISDMNRnaFZhLhEvPdhc()
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel != null)
			{
				return keyedGlyph.TryGetValue(null, rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel, rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel, rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (QMCAzqqLVNEknolZBxihsUkYvkjV(keyedGlyph, parentKeys, keyCategory, out result))
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
			if (rcohlxjupqeZImshLkQGCCeDdUxk.CJuHDSrIPOefDcBvxFWeGxxRKel == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (ypOZGUiTiwgGOLObSwmrXlMlKCyv(keyedGlyph, key, keyCategory, parentKeys, out result))
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

		private static bool QMCAzqqLVNEknolZBxihsUkYvkjV(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
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
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, 0u, out P_3))
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

		private static bool ypOZGUiTiwgGOLObSwmrXlMlKCyv(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
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
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, dependenciesVersion, out P_4))
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
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), rcohlxjupqeZImshLkQGCCeDdUxk.mWojqnGeIWUvnWcwZvTNWyBBvGeo, dependenciesVersion, out P_4))
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
			if (izmPKZkGYTxfCQboSubPGqOkhtBl != null)
			{
				izmPKZkGYTxfCQboSubPGqOkhtBl.Length = 0;
				return izmPKZkGYTxfCQboSubPGqOkhtBl;
			}
			return izmPKZkGYTxfCQboSubPGqOkhtBl = new StringBuilder();
		}
	}
}
