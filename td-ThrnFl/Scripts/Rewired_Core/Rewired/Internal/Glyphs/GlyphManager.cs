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
		private sealed class oPNOlCXiZpmXUeToxGBAauNTpFnc
		{
			[Serializable]
			private sealed class UxPgryrFWeFREMLHwzvufpCTjZzw
			{
				public static readonly UxPgryrFWeFREMLHwzvufpCTjZzw _003C_003E9 = new UxPgryrFWeFREMLHwzvufpCTjZzw();

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void MkTgvenUPrVaExtVeKebuQjHechCA(IPrefetch P_0)
				{
					P_0.Prefetch();
				}
			}

			private const float BtvhBVSWqbVNPIpJVHrVVukmfPOx = 60f;

			private readonly global::nvBlnMElFudOyJAqIDsjvVIbYJjZ<IPrefetch> GQTzljxIRJGzyAOjcOJXqbKcUQuKA;

			public bool WHiZjlIBiEugzRfftXeUErKqFjYo;

			public IGlyphProvider lNnJIlKkoLByyeStLXWzcGFTTUpd;

			public uint JwKDPJSTZYmgudvlhCrkKmkvOOnU;

			private Action<IPrefetch> iOclEIsGCkJOxRaKiyvvZBYRmsIe = UxPgryrFWeFREMLHwzvufpCTjZzw._003C_003E9.MkTgvenUPrVaExtVeKebuQjHechCA;

			private Id wckDaaKfZNpXQZmPkVMeiFzNbrsCA;

			public oPNOlCXiZpmXUeToxGBAauNTpFnc()
			{
				GQTzljxIRJGzyAOjcOJXqbKcUQuKA = new global::nvBlnMElFudOyJAqIDsjvVIbYJjZ<IPrefetch>(60f);
				JwKDPJSTZYmgudvlhCrkKmkvOOnU = 0u;
				wckDaaKfZNpXQZmPkVMeiFzNbrsCA = 1u;
			}

			public void AjUcaBrZjfUpNkpPMRJXXALhrcgw(IGlyphProvider P_0)
			{
				lNnJIlKkoLByyeStLXWzcGFTTUpd = P_0;
				if (P_0 != null)
				{
					JwKDPJSTZYmgudvlhCrkKmkvOOnU = wckDaaKfZNpXQZmPkVMeiFzNbrsCA.id;
					wckDaaKfZNpXQZmPkVMeiFzNbrsCA.Increment();
				}
				else
				{
					JwKDPJSTZYmgudvlhCrkKmkvOOnU = 0u;
				}
				BmEhBuDqPfKwkPjKAZSciggpGxdv();
			}

			public void boOMbbupPUCxiyBiYTPwKWRBsloN(bool P_0)
			{
				if (P_0 != WHiZjlIBiEugzRfftXeUErKqFjYo)
				{
					WHiZjlIBiEugzRfftXeUErKqFjYo = P_0;
					if (P_0)
					{
						BGTPRUHglyeKEPcqGWklnoQGijrC();
					}
				}
			}

			public void BGTPRUHglyeKEPcqGWklnoQGijrC()
			{
				if (lNnJIlKkoLByyeStLXWzcGFTTUpd != null)
				{
					GQTzljxIRJGzyAOjcOJXqbKcUQuKA.VQypiftOqKaitpdJhMReTskQUMET(iOclEIsGCkJOxRaKiyvvZBYRmsIe);
				}
			}

			public void UWglZTabgXJeENsUDrGbZGbYvHDN()
			{
				if (lNnJIlKkoLByyeStLXWzcGFTTUpd != null)
				{
					JwKDPJSTZYmgudvlhCrkKmkvOOnU = wckDaaKfZNpXQZmPkVMeiFzNbrsCA.id;
					wckDaaKfZNpXQZmPkVMeiFzNbrsCA.Increment();
					if (WHiZjlIBiEugzRfftXeUErKqFjYo)
					{
						BGTPRUHglyeKEPcqGWklnoQGijrC();
					}
					else
					{
						BmEhBuDqPfKwkPjKAZSciggpGxdv();
					}
				}
			}

			public uint ZSEYdGkJHgzhCPTnOtyjDmFMhyln(IPrefetch P_0)
			{
				return GQTzljxIRJGzyAOjcOJXqbKcUQuKA.KzNFDaXdZQnOsbknYnymfwQnPwRB(P_0);
			}

			public bool NBcOnnDYDIWpnCzRkRqAmyffqUVv(uint P_0)
			{
				return GQTzljxIRJGzyAOjcOJXqbKcUQuKA.XUsTejstazeMUIrOUEBLcuzNrmoX(P_0);
			}

			public void BmEhBuDqPfKwkPjKAZSciggpGxdv()
			{
				GQTzljxIRJGzyAOjcOJXqbKcUQuKA.zmlKINPFJCScnWBdabJphDQrfoCKA();
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

		private static oPNOlCXiZpmXUeToxGBAauNTpFnc YRSHYDhkocPMXNsgdPEhWATzrzcO;

		private static StringBuilder LcEpbxsuRTfwFdYvwqLiKcdEufSv;

		public static bool isEnabled
		{
			get
			{
				if (YRSHYDhkocPMXNsgdPEhWATzrzcO == null)
				{
					return false;
				}
				return YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd != null;
			}
		}

		public static uint version
		{
			get
			{
				CVqAOFFzksiNEhsGFvzsDPEZfHajb();
				return YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU;
			}
		}

		public static IGlyphProvider glyphProvider
		{
			get
			{
				CVqAOFFzksiNEhsGFvzsDPEZfHajb();
				return YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd;
			}
			set
			{
				CVqAOFFzksiNEhsGFvzsDPEZfHajb();
				YRSHYDhkocPMXNsgdPEhWATzrzcO.AjUcaBrZjfUpNkpPMRJXXALhrcgw(value);
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				CVqAOFFzksiNEhsGFvzsDPEZfHajb();
				return YRSHYDhkocPMXNsgdPEhWATzrzcO.WHiZjlIBiEugzRfftXeUErKqFjYo;
			}
			set
			{
				CVqAOFFzksiNEhsGFvzsDPEZfHajb();
				YRSHYDhkocPMXNsgdPEhWATzrzcO.boOMbbupPUCxiyBiYTPwKWRBsloN(value);
			}
		}

		public static void Initialize()
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO != null)
			{
				throw new Exception("Already initialized");
			}
			YRSHYDhkocPMXNsgdPEhWATzrzcO = new oPNOlCXiZpmXUeToxGBAauNTpFnc();
		}

		public static void Deinitialize()
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO != null)
			{
				YRSHYDhkocPMXNsgdPEhWATzrzcO = null;
			}
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
			CVqAOFFzksiNEhsGFvzsDPEZfHajb();
			id = YRSHYDhkocPMXNsgdPEhWATzrzcO.ZSEYdGkJHgzhCPTnOtyjDmFMhyln(obj);
		}

		public static bool Remove(ref Id id)
		{
			CVqAOFFzksiNEhsGFvzsDPEZfHajb();
			bool result = YRSHYDhkocPMXNsgdPEhWATzrzcO.NBcOnnDYDIWpnCzRkRqAmyffqUVv(id);
			id = 0u;
			return result;
		}

		public static void Prefetch()
		{
			CVqAOFFzksiNEhsGFvzsDPEZfHajb();
			YRSHYDhkocPMXNsgdPEhWATzrzcO.BGTPRUHglyeKEPcqGWklnoQGijrC();
		}

		public static void Reload()
		{
			CVqAOFFzksiNEhsGFvzsDPEZfHajb();
			YRSHYDhkocPMXNsgdPEhWATzrzcO.UWglZTabgXJeENsUDrGbZGbYvHDN();
		}

		private static void CVqAOFFzksiNEhsGFvzsDPEZfHajb()
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd != null)
			{
				return keyedGlyph.TryGetValue(null, YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd, YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd != null)
			{
				keyedGlyph.Clear();
				bool versionChanged;
				return keyedGlyph.TryGetValue(key, YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd, YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, dependenciesVersion, out versionChanged, out result);
			}
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (hZyMXUsVINleaZSOpOVOoPRqsEif(keyedGlyph, parentKeys, keyCategory, out result))
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
			if (YRSHYDhkocPMXNsgdPEhWATzrzcO.lNnJIlKkoLByyeStLXWzcGFTTUpd == null)
			{
				result = null;
				return GetAndUpdateGlyphResultFlags.Failed;
			}
			GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ((!TryGetCachedGlyph(keyedGlyph, YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, 0u, out var glyphProviderVersionChanged, out result)) ? GetAndUpdateGlyphResultFlags.Failed : GetAndUpdateGlyphResultFlags.IsCachedValue);
			if (!keyedGlyph.hasCachedValue || glyphProviderVersionChanged)
			{
				getAndUpdateGlyphResultFlags |= GetAndUpdateGlyphResultFlags.Changed;
				if (HdqHtgeklgmNXVacaBKYNVrPkWrVA(keyedGlyph, key, keyCategory, parentKeys, out result))
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

		private static bool hZyMXUsVINleaZSOpOVOoPRqsEif(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
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
						if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, 0u, out P_3))
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

		private static bool HdqHtgeklgmNXVacaBKYNVrPkWrVA(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
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
					if (!TryGetGlyph(P_0, sharedStringBuilder.ToString(), YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, dependenciesVersion, out P_4))
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
				if (TryGetGlyph(P_0, sharedStringBuilder.ToString(), YRSHYDhkocPMXNsgdPEhWATzrzcO.JwKDPJSTZYmgudvlhCrkKmkvOOnU, dependenciesVersion, out P_4))
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
			if (LcEpbxsuRTfwFdYvwqLiKcdEufSv != null)
			{
				LcEpbxsuRTfwFdYvwqLiKcdEufSv.Length = 0;
				return LcEpbxsuRTfwFdYvwqLiKcdEufSv;
			}
			return LcEpbxsuRTfwFdYvwqLiKcdEufSv = new StringBuilder();
		}
	}
}
