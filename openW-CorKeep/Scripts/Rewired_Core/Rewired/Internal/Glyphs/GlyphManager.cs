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
		private sealed class NzdcdIxmJnlvmoSwMnlTjwNWeyAm
		{
			[Serializable]
			private sealed class bvvBHJFrRcMZbYgSZGPwqxHGMCmd
			{
				public static readonly bvvBHJFrRcMZbYgSZGPwqxHGMCmd _003C_003E9 = new bvvBHJFrRcMZbYgSZGPwqxHGMCmd();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void fpfcSNbZybivlRrgRlRnSjMIjhoWA(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float wERHakkWHnzMqYmesHIHdCTnJOHbA = 60f;

			private readonly global::McrWGzywssbBXMqJxDJhUtfikIyT<IPrefetch> vctPEURusRavLAgSHgsXaQdbPNhq;

			public bool nnIqGQqNLCafQLRAMBJGLRvxXoFv;

			public IGlyphProvider EaBBoKiCDTIYJfmjgpkjhtdeCMmZB;

			public uint mcgemaAeuQDhTSlQASSiRTXucDaXA;

			private Action<IPrefetch> BDKCYpOxlsMEUXnBZtTxEViEtTLL = bvvBHJFrRcMZbYgSZGPwqxHGMCmd._003C_003E9.fpfcSNbZybivlRrgRlRnSjMIjhoWA;

			private Id TqWFNAeebREchTqENxwofQvYadSc;

			public NzdcdIxmJnlvmoSwMnlTjwNWeyAm()
			{
				vctPEURusRavLAgSHgsXaQdbPNhq = new global::McrWGzywssbBXMqJxDJhUtfikIyT<IPrefetch>(60f);
				mcgemaAeuQDhTSlQASSiRTXucDaXA = 0u;
				TqWFNAeebREchTqENxwofQvYadSc = 1u;
			}

			public void rkmJbiTMaxsAcuHwzsvBWQygjJpg(IGlyphProvider P_0)
			{
				EaBBoKiCDTIYJfmjgpkjhtdeCMmZB = P_0;
				if (P_0 != null)
				{
					mcgemaAeuQDhTSlQASSiRTXucDaXA = TqWFNAeebREchTqENxwofQvYadSc.id;
					TqWFNAeebREchTqENxwofQvYadSc.Increment();
				}
				else
				{
					mcgemaAeuQDhTSlQASSiRTXucDaXA = 0u;
				}
				qbiAcBxhkbVDXTfjxGgiflZgxwkr();
			}

			public void SEcvGSGWiGSuRcoFrvegLAmUXixV(bool P_0)
			{
				if (P_0 != nnIqGQqNLCafQLRAMBJGLRvxXoFv)
				{
					nnIqGQqNLCafQLRAMBJGLRvxXoFv = P_0;
					if (P_0)
					{
						khvejdxuBehmvZyTnrllyGJLBhyW();
					}
				}
			}

			public void khvejdxuBehmvZyTnrllyGJLBhyW()
			{
				if (EaBBoKiCDTIYJfmjgpkjhtdeCMmZB != null)
				{
					vctPEURusRavLAgSHgsXaQdbPNhq.uHSsPAZdPIflOinwUJuyDGBTZTVZ(BDKCYpOxlsMEUXnBZtTxEViEtTLL);
				}
			}

			public void pbKWeyCUXBInfDPncUnnCySTdMAw()
			{
				if (EaBBoKiCDTIYJfmjgpkjhtdeCMmZB != null)
				{
					mcgemaAeuQDhTSlQASSiRTXucDaXA = TqWFNAeebREchTqENxwofQvYadSc.id;
					TqWFNAeebREchTqENxwofQvYadSc.Increment();
					if (nnIqGQqNLCafQLRAMBJGLRvxXoFv)
					{
						khvejdxuBehmvZyTnrllyGJLBhyW();
					}
					else
					{
						qbiAcBxhkbVDXTfjxGgiflZgxwkr();
					}
				}
			}

			public uint ocgQChQmqgVohFrUjsPdWpeZhsok(IPrefetch P_0)
			{
				return vctPEURusRavLAgSHgsXaQdbPNhq.zOdcayhaCQLqdzGDlEGoDmPmrGtEA(P_0);
			}

			public bool wwUTGGvmwAyJKEBsRGBAxNKwgTWCA(uint P_0)
			{
				return vctPEURusRavLAgSHgsXaQdbPNhq.wXGmDEAFNfELnKYttEiFilWASdzpA(P_0);
			}

			public void qbiAcBxhkbVDXTfjxGgiflZgxwkr()
			{
				vctPEURusRavLAgSHgsXaQdbPNhq.EgJtVgbhmILaUKPMRuZxmnpgzHDG();
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

		private static NzdcdIxmJnlvmoSwMnlTjwNWeyAm xbshxsTrJqFHaBZBSypfVzomgsrl;

		private static StringBuilder uWstSGSkyLNdobaMXTqyLyEVgQZL;

		public static bool isEnabled
		{
			get
			{
				if (xbshxsTrJqFHaBZBSypfVzomgsrl == null)
				{
					return false;
				}
				return xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB != null;
			}
		}

		public static uint version
		{
			get
			{
				bxIfreHUHsSrbiafsgKeWgbQBEtCA();
				return xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				bxIfreHUHsSrbiafsgKeWgbQBEtCA();
				return xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB;
			}
			set
			{
				bxIfreHUHsSrbiafsgKeWgbQBEtCA();
				xbshxsTrJqFHaBZBSypfVzomgsrl.rkmJbiTMaxsAcuHwzsvBWQygjJpg(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				bxIfreHUHsSrbiafsgKeWgbQBEtCA();
				return xbshxsTrJqFHaBZBSypfVzomgsrl.nnIqGQqNLCafQLRAMBJGLRvxXoFv;
			}
			set
			{
				bxIfreHUHsSrbiafsgKeWgbQBEtCA();
				xbshxsTrJqFHaBZBSypfVzomgsrl.SEcvGSGWiGSuRcoFrvegLAmUXixV(value);
			}
		}

		public static void Initialize()
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl != null)
			{
				throw new Exception("Already initialized");
			}
			xbshxsTrJqFHaBZBSypfVzomgsrl = new NzdcdIxmJnlvmoSwMnlTjwNWeyAm();
		}

		public static void Deinitialize()
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl != null)
			{
				xbshxsTrJqFHaBZBSypfVzomgsrl = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			bxIfreHUHsSrbiafsgKeWgbQBEtCA();
			id = xbshxsTrJqFHaBZBSypfVzomgsrl.ocgQChQmqgVohFrUjsPdWpeZhsok(obj);
		}

		public static bool Remove(ref Id id)
		{
			bxIfreHUHsSrbiafsgKeWgbQBEtCA();
			bool result = xbshxsTrJqFHaBZBSypfVzomgsrl.wwUTGGvmwAyJKEBsRGBAxNKwgTWCA(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			bxIfreHUHsSrbiafsgKeWgbQBEtCA();
			xbshxsTrJqFHaBZBSypfVzomgsrl.khvejdxuBehmvZyTnrllyGJLBhyW();
		}

		public static void Reload()
		{
			bxIfreHUHsSrbiafsgKeWgbQBEtCA();
			xbshxsTrJqFHaBZBSypfVzomgsrl.pbKWeyCUXBInfDPncUnnCySTdMAw();
		}

		private static void bxIfreHUHsSrbiafsgKeWgbQBEtCA()
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB != null)
			{
				return keyedGlyph.TryGetValue(null, xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB, xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB, xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (MnKrBdErhJqOZHlKQhsUngltvbxF(keyedGlyph, parentKeys, keyCategory, out result))
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
			if (xbshxsTrJqFHaBZBSypfVzomgsrl.EaBBoKiCDTIYJfmjgpkjhtdeCMmZB == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (krUhCRUtKcDAcqmBDKfYMEOMuByT(keyedGlyph, key, keyCategory, parentKeys, out result))
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

		private static bool MnKrBdErhJqOZHlKQhsUngltvbxF(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
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
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, 0u, out P_3))
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

		private static bool krUhCRUtKcDAcqmBDKfYMEOMuByT(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
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
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, dependenciesVersion, out P_4))
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
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), xbshxsTrJqFHaBZBSypfVzomgsrl.mcgemaAeuQDhTSlQASSiRTXucDaXA, dependenciesVersion, out P_4))
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
			if (uWstSGSkyLNdobaMXTqyLyEVgQZL != null)
			{
				uWstSGSkyLNdobaMXTqyLyEVgQZL.Length = 0;
				return uWstSGSkyLNdobaMXTqyLyEVgQZL;
			}
			return uWstSGSkyLNdobaMXTqyLyEVgQZL = new StringBuilder();
		}
	}
}
