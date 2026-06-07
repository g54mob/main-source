using System;
using System.Text;
using Rewired.Interfaces;
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
				public static readonly bvvBHJFrRcMZbYgSZGPwqxHGMCmd _003C_003E9;

				public static Action<IPrefetch> _003C_003E9__7_0;

				internal void fpfcSNbZybivlRrgRlRnSjMIjhoWA(IPrefetch P_0)
				{
				}
			}

			private const float wERHakkWHnzMqYmesHIHdCTnJOHbA = 60f;

			private readonly global::McrWGzywssbBXMqJxDJhUtfikIyT<IPrefetch> vctPEURusRavLAgSHgsXaQdbPNhq;

			public bool nnIqGQqNLCafQLRAMBJGLRvxXoFv;

			public IGlyphProvider EaBBoKiCDTIYJfmjgpkjhtdeCMmZB;

			public uint mcgemaAeuQDhTSlQASSiRTXucDaXA;

			private Action<IPrefetch> BDKCYpOxlsMEUXnBZtTxEViEtTLL;

			private Id TqWFNAeebREchTqENxwofQvYadSc;

			public void rkmJbiTMaxsAcuHwzsvBWQygjJpg(IGlyphProvider P_0)
			{
			}

			public void SEcvGSGWiGSuRcoFrvegLAmUXixV(bool P_0)
			{
			}

			public void khvejdxuBehmvZyTnrllyGJLBhyW()
			{
			}

			public void pbKWeyCUXBInfDPncUnnCySTdMAw()
			{
			}

			public uint ocgQChQmqgVohFrUjsPdWpeZhsok(IPrefetch P_0)
			{
				return 0u;
			}

			public bool wwUTGGvmwAyJKEBsRGBAxNKwgTWCA(uint P_0)
			{
				return false;
			}

			public void qbiAcBxhkbVDXTfjxGgiflZgxwkr()
			{
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

		public static bool isEnabled => false;

		public static uint version => 0u;

		public static IGlyphProvider glyphProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool autoPrefetch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void Initialize()
		{
		}

		public static void Deinitialize()
		{
		}

		public static void Add(IPrefetch obj, ref Id id)
		{
		}

		public static bool Remove(ref Id id)
		{
			return false;
		}

		public static void Prefetch()
		{
		}

		public static void Reload()
		{
		}

		private static void bxIfreHUHsSrbiafsgKeWgbQBEtCA()
		{
		}

		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			glyphProviderVersionChanged = default(bool);
			result = null;
			return false;
		}

		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			result = null;
			return false;
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			result = null;
			return default(GetAndUpdateGlyphResultFlags);
		}

		public static GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, string key, string keyCategory, IReadOnlyList<string> parentKeys, out object result)
		{
			result = null;
			return default(GetAndUpdateGlyphResultFlags);
		}

		private static bool MnKrBdErhJqOZHlKQhsUngltvbxF(KeyedGlyph P_0, IReadOnlyList<string> P_1, string P_2, out object P_3)
		{
			P_3 = null;
			return false;
		}

		private static bool krUhCRUtKcDAcqmBDKfYMEOMuByT(KeyedGlyph P_0, string P_1, string P_2, IReadOnlyList<string> P_3, out object P_4)
		{
			P_4 = null;
			return false;
		}

		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			return null;
		}
	}
}
