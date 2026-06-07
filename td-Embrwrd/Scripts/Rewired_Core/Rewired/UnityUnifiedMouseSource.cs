using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class UXSKRgVhcGzxduwnfkuPGScfUSoW
		{
			private float[] dvBUKgCKLvIiKepYYdfAXHvkjzyVA;

			private bool[] HJitDTxHhkoyMuABpJuxRkqjqnxn;

			public UXSKRgVhcGzxduwnfkuPGScfUSoW(int P_0, int P_1)
			{
			}

			public void qoJtygjeehqTzEcFgNiEZtSNOujX(bool[] P_0, float[] P_1)
			{
			}

			public void BuKxkrywSamxkKezfheIRLVteZGW(ControllerDataUpdater P_0)
			{
			}

			public void lKtVihmgFlILfoBpqsSByRmuHTqq()
			{
			}

			public void QjRAEMfrTiPLRKrCfJvkuDYLiBAab()
			{
			}
		}

		[Serializable]
		private sealed class QRvYceGgqlyMmVZteDFJpTIVSNdq
		{
			public static readonly QRvYceGgqlyMmVZteDFJpTIVSNdq _003C_003E9;

			public static Func<UXSKRgVhcGzxduwnfkuPGScfUSoW> _003C_003E9__20_0;

			internal UXSKRgVhcGzxduwnfkuPGScfUSoW EGKFLpfCZMNEJdKQCbYrDDfDplrTA()
			{
				return null;
			}
		}

		private static HardwareControllerMap_Game pjrtVhnonFVBYixsUjMDvEfprCdN;

		private UpdateLoopDataSet<UXSKRgVhcGzxduwnfkuPGScfUSoW> LFrgozdoPimaWDdQHqMHAwHSTRlp;

		private float[] NOQINcUfTQAcQiBWarvkiYBgKyeZ;

		private bool[] YaFreSCqGlNGMCAsEvUWiXehBESF;

		private bool WLiAySEAZUaEKCThBsYMTxxaGPlCc;

		private bool LycrUmcoWjVrmvjMJbLaisEBFZXU;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public InputSource inputSource => default(InputSource);

		public HardwareControllerMap_Game hardwareMap => null;

		public int buttonCount => 0;

		public int axisCount => 0;

		public Vector2 mousePosition => default(Vector2);

		public Controller.Extension controllerExtension => null;

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
		}

		public void Clear()
		{
		}

		private void gLlcvHaczzTKmvRDVbBkfoLRtoIJ()
		{
		}

		private void ZptAzSKHQWJqZEHiVBuGeMDmTcLn(UpdateLoopType P_0)
		{
		}

		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			return null;
		}

		public void Dispose()
		{
		}

		~UnityUnifiedMouseSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}
	}
}
