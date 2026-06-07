using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class twryUExgDGLgXIFKRmEEbGMrUxBA : PlatformInputManager, INativePlatformHelper
{
	private class LSSaQOyjxBKKgckyXAoJQGPijVKP
	{
		private class FCMDoZInaZHPSqmQHbMNPREDsRavA
		{
			public int saTtsKYxNzreuCpToynSEFzacyVDA;

			public int IBQfJduRaoUhsPpVgDvmqzVPgLBE;

			public int ZcOWSxWEpdiaCeByXxlHUmwadWxEA;

			public InputSource gpRRWpNgaNJmzGbrEaNwChwYyxtY;

			public FCMDoZInaZHPSqmQHbMNPREDsRavA(int P_0, int P_1, int P_2, InputSource P_3)
			{
				saTtsKYxNzreuCpToynSEFzacyVDA = P_0;
				IBQfJduRaoUhsPpVgDvmqzVPgLBE = P_1;
				ZcOWSxWEpdiaCeByXxlHUmwadWxEA = P_2;
				gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_3;
			}

			public void mefhGqvTkcrETnFSidhNngFjAYNV(int P_0)
			{
				IBQfJduRaoUhsPpVgDvmqzVPgLBE = P_0;
			}

			public wCLcWTbQFfEvrcLKAoNJDfPifxeie szomBNAfyNNNcDinGDTycxDpOIjGA()
			{
				return new wCLcWTbQFfEvrcLKAoNJDfPifxeie(saTtsKYxNzreuCpToynSEFzacyVDA, IBQfJduRaoUhsPpVgDvmqzVPgLBE, gpRRWpNgaNJmzGbrEaNwChwYyxtY);
			}

			public static int WoHAzmiLSvqoNLITczhgWwQBGgQGA(FCMDoZInaZHPSqmQHbMNPREDsRavA P_0, FCMDoZInaZHPSqmQHbMNPREDsRavA P_1)
			{
				if (P_0.saTtsKYxNzreuCpToynSEFzacyVDA < P_1.saTtsKYxNzreuCpToynSEFzacyVDA)
				{
					return -1;
				}
				if (P_0.saTtsKYxNzreuCpToynSEFzacyVDA > P_1.saTtsKYxNzreuCpToynSEFzacyVDA)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct wCLcWTbQFfEvrcLKAoNJDfPifxeie
		{
			public int saTtsKYxNzreuCpToynSEFzacyVDA;

			public int IBQfJduRaoUhsPpVgDvmqzVPgLBE;

			public InputSource gpRRWpNgaNJmzGbrEaNwChwYyxtY;

			public wCLcWTbQFfEvrcLKAoNJDfPifxeie(int P_0, int P_1, InputSource P_2)
			{
				saTtsKYxNzreuCpToynSEFzacyVDA = P_0;
				IBQfJduRaoUhsPpVgDvmqzVPgLBE = P_1;
				gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_2;
			}
		}

		public enum hPAhvsBwYGVVjqeOJFucGpdEhYpVA
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<FCMDoZInaZHPSqmQHbMNPREDsRavA> aTmNAgxngYdxlbzoiTazOudqkExO;

		private List<FCMDoZInaZHPSqmQHbMNPREDsRavA> KHIXUIbTYPWAKFJwedIGiQbXQdGD;

		public int cbjBtQgEcnCRBhgaoUwFdCjDWhjXB => KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count;

		public LSSaQOyjxBKKgckyXAoJQGPijVKP()
		{
			KHIXUIbTYPWAKFJwedIGiQbXQdGD = new List<FCMDoZInaZHPSqmQHbMNPREDsRavA>();
			aTmNAgxngYdxlbzoiTazOudqkExO = new List<FCMDoZInaZHPSqmQHbMNPREDsRavA>();
		}

		public void veRTpSicUyGksqyIruVCBNTwdMJs(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(sourceJoystick.rewiredId, hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected);
			FCMDoZInaZHPSqmQHbMNPREDsRavA fCMDoZInaZHPSqmQHbMNPREDsRavA;
			if (num >= 0)
			{
				fCMDoZInaZHPSqmQHbMNPREDsRavA = KHIXUIbTYPWAKFJwedIGiQbXQdGD[num];
				fCMDoZInaZHPSqmQHbMNPREDsRavA.mefhGqvTkcrETnFSidhNngFjAYNV(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new HFDbqbZOXpcjJWiZtXTgcFSAChCK(sourceJoystick, fCMDoZInaZHPSqmQHbMNPREDsRavA.saTtsKYxNzreuCpToynSEFzacyVDA);
				return;
			}
			num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(sourceJoystick.rewiredId, hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected);
			if (num >= 0)
			{
				fCMDoZInaZHPSqmQHbMNPREDsRavA = aTmNAgxngYdxlbzoiTazOudqkExO[num];
				aTmNAgxngYdxlbzoiTazOudqkExO.RemoveAt(num);
				int saTtsKYxNzreuCpToynSEFzacyVDA = tWwxKnEDDhdPiOZDhUSCgOIBhCKC(fCMDoZInaZHPSqmQHbMNPREDsRavA.saTtsKYxNzreuCpToynSEFzacyVDA);
				fCMDoZInaZHPSqmQHbMNPREDsRavA.saTtsKYxNzreuCpToynSEFzacyVDA = saTtsKYxNzreuCpToynSEFzacyVDA;
			}
			else
			{
				fCMDoZInaZHPSqmQHbMNPREDsRavA = new FCMDoZInaZHPSqmQHbMNPREDsRavA(tWwxKnEDDhdPiOZDhUSCgOIBhCKC(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new HFDbqbZOXpcjJWiZtXTgcFSAChCK(sourceJoystick, fCMDoZInaZHPSqmQHbMNPREDsRavA.saTtsKYxNzreuCpToynSEFzacyVDA);
			KHIXUIbTYPWAKFJwedIGiQbXQdGD.Add(fCMDoZInaZHPSqmQHbMNPREDsRavA);
			KHIXUIbTYPWAKFJwedIGiQbXQdGD.Sort(FCMDoZInaZHPSqmQHbMNPREDsRavA.WoHAzmiLSvqoNLITczhgWwQBGgQGA);
		}

		public void CBCfunYlaFTjvuySlcPuEOYlKnAX(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0.rewiredId, hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				FCMDoZInaZHPSqmQHbMNPREDsRavA item = KHIXUIbTYPWAKFJwedIGiQbXQdGD[num];
				KHIXUIbTYPWAKFJwedIGiQbXQdGD.RemoveAt(num);
				aTmNAgxngYdxlbzoiTazOudqkExO.Add(item);
			}
		}

		public void qApdHIvnExfmEeRXjrRaBQSMJkTAb(int P_0, int P_1)
		{
			int num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected);
			if (num >= 0)
			{
				KHIXUIbTYPWAKFJwedIGiQbXQdGD[num].mefhGqvTkcrETnFSidhNngFjAYNV(P_1);
				return;
			}
			num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected);
			if (num >= 0)
			{
				aTmNAgxngYdxlbzoiTazOudqkExO[num].mefhGqvTkcrETnFSidhNngFjAYNV(P_1);
			}
		}

		public bool ecSZEwttGfkQfToParxnBfHCGISs(int P_0, hPAhvsBwYGVVjqeOJFucGpdEhYpVA P_1)
		{
			if (oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(int P_0, hPAhvsBwYGVVjqeOJFucGpdEhYpVA P_1)
		{
			switch (P_1)
			{
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected:
			{
				int count2 = KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count;
				for (int j = 0; j < count2; j++)
				{
					if (KHIXUIbTYPWAKFJwedIGiQbXQdGD[j].ZcOWSxWEpdiaCeByXxlHUmwadWxEA == P_0)
					{
						return j;
					}
				}
				break;
			}
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected:
			{
				int count = aTmNAgxngYdxlbzoiTazOudqkExO.Count;
				for (int i = 0; i < count; i++)
				{
					if (aTmNAgxngYdxlbzoiTazOudqkExO[i].ZcOWSxWEpdiaCeByXxlHUmwadWxEA == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(int P_0, InputSource P_1, hPAhvsBwYGVVjqeOJFucGpdEhYpVA P_2)
		{
			switch (P_2)
			{
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected:
			{
				int count2 = KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count;
				for (int j = 0; j < count2; j++)
				{
					if (KHIXUIbTYPWAKFJwedIGiQbXQdGD[j].saTtsKYxNzreuCpToynSEFzacyVDA == P_0 && KHIXUIbTYPWAKFJwedIGiQbXQdGD[j].gpRRWpNgaNJmzGbrEaNwChwYyxtY == P_1)
					{
						return j;
					}
				}
				break;
			}
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected:
			{
				int count = aTmNAgxngYdxlbzoiTazOudqkExO.Count;
				for (int i = 0; i < count; i++)
				{
					if (aTmNAgxngYdxlbzoiTazOudqkExO[i].saTtsKYxNzreuCpToynSEFzacyVDA == P_0 && aTmNAgxngYdxlbzoiTazOudqkExO[i].gpRRWpNgaNJmzGbrEaNwChwYyxtY == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public wCLcWTbQFfEvrcLKAoNJDfPifxeie szomBNAfyNNNcDinGDTycxDpOIjGA(int P_0, hPAhvsBwYGVVjqeOJFucGpdEhYpVA P_1)
		{
			if (P_1 == hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected)
			{
				if (P_0 < 0 || P_0 >= KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return KHIXUIbTYPWAKFJwedIGiQbXQdGD[P_0].szomBNAfyNNNcDinGDTycxDpOIjGA();
			}
			if (P_0 < 0 || P_0 >= aTmNAgxngYdxlbzoiTazOudqkExO.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return aTmNAgxngYdxlbzoiTazOudqkExO[P_0].szomBNAfyNNNcDinGDTycxDpOIjGA();
		}

		public int FYQGWAOkRmcsESDdpolWcdcEUaab(int P_0, InputSource P_1, hPAhvsBwYGVVjqeOJFucGpdEhYpVA P_2)
		{
			int num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			switch (P_2)
			{
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected:
				return KHIXUIbTYPWAKFJwedIGiQbXQdGD[num].IBQfJduRaoUhsPpVgDvmqzVPgLBE;
			case hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected:
				return aTmNAgxngYdxlbzoiTazOudqkExO[num].IBQfJduRaoUhsPpVgDvmqzVPgLBE;
			default:
				return -1;
			}
		}

		private int tWwxKnEDDhdPiOZDhUSCgOIBhCKC(int P_0)
		{
			int count = KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count;
			for (int i = 0; i < count; i++)
			{
				if (KHIXUIbTYPWAKFJwedIGiQbXQdGD[i].saTtsKYxNzreuCpToynSEFzacyVDA == P_0)
				{
					return tWwxKnEDDhdPiOZDhUSCgOIBhCKC();
				}
			}
			return P_0;
		}

		private int tWwxKnEDDhdPiOZDhUSCgOIBhCKC()
		{
			int count = KHIXUIbTYPWAKFJwedIGiQbXQdGD.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (KHIXUIbTYPWAKFJwedIGiQbXQdGD[i].saTtsKYxNzreuCpToynSEFzacyVDA == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}
	}

	private class HFDbqbZOXpcjJWiZtXTgcFSAChCK : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic UztXDfeobYvTILthUwbphNPSdKam;

		private int AbdOkDHXcpgjyfrhCHXeOOUtOUtC;

		public int rewiredId => UztXDfeobYvTILthUwbphNPSdKam.rewiredId;

		public int inputManagerId => AbdOkDHXcpgjyfrhCHXeOOUtOUtC;

		public string name => UztXDfeobYvTILthUwbphNPSdKam.name;

		public long? systemId => UztXDfeobYvTILthUwbphNPSdKam.systemId;

		public int unityId => UztXDfeobYvTILthUwbphNPSdKam.unityId;

		public Guid instanceGuid => UztXDfeobYvTILthUwbphNPSdKam.instanceGuid;

		public Guid persistentGuid => instanceGuid;

		public Controller.Extension extension => UztXDfeobYvTILthUwbphNPSdKam.extension;

		public HFDbqbZOXpcjJWiZtXTgcFSAChCK(IInputManagerJoystickPublic P_0, int P_1)
		{
			UztXDfeobYvTILthUwbphNPSdKam = P_0;
			AbdOkDHXcpgjyfrhCHXeOOUtOUtC = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			UztXDfeobYvTILthUwbphNPSdKam.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			UztXDfeobYvTILthUwbphNPSdKam.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (UztXDfeobYvTILthUwbphNPSdKam is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class GhdBWbNYmDqYrUQbQvmmvuqfDdKn
	{
		public static readonly GhdBWbNYmDqYrUQbQvmmvuqfDdKn _003C_003E9 = new GhdBWbNYmDqYrUQbQvmmvuqfDdKn();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool MZcWtpsXUBxWfRFSDJxOPoSobfHB(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class xwdWTDctOIazBczcnZgxRjrnCTBFb
	{
		public int aCydqpceKhJEHIShBuPdvJgJIXTmA;

		internal int JyVntikZcsNUBbnxNYCiKixpbqpW()
		{
			return aCydqpceKhJEHIShBuPdvJgJIXTmA++;
		}
	}

	private const bool HEtBRxhMvePHBAYadEipWwGIHwxmB = false;

	private const bool VhZabgxYOuNerqjsPcgejcbNuFSw = false;

	private const bool OoLbLjTqvXfIFCIGHvJpCHgXYvFmA = false;

	private const bool GYWgXwVTgxVrPNqwLgsweiyCNUSF = false;

	private const bool QFftVcvAmYpnrqpHXlIYZGHeCcDZ = false;

	private const bool YAQcRzyFKPuqSWVeTFhKiQVeqmoU = false;

	private bool vzsCKgEyOZYnMHSYbeEpEieJXjoE;

	private tRxWniojlYUQtbpCVvaSxCPROnZE gljANFByvnGYVkPpoabwcckaRCWCc;

	private IndexedDictionary<int, PlatformInputManager> OjRrBijLPjSchEkdZkqDuPmEOtsW;

	private LSSaQOyjxBKKgckyXAoJQGPijVKP psQRnUGAxXXGjIkyrLVogNnrUEGD;

	private Action<int, ControllerDataUpdater> ogoLdzNKsHvptwEnFfXlaACHoIJO;

	private WindowsStandalonePrimaryInputSource QYUtNbMtCgMnyNuLpRYMsIcuLrEi;

	private PlatformInputManager cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	private bool QLsdSUfnOYeAZpZwrwIACtcnqfhzA;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> EtLWzOxoiSdkpGOpmFcLCIXPfrDbb;

	private Func<int> FkKAFEXjiJpbaBpOcYIALNvtByLEA;

	private Func<PidVid, bool> hHaeeNHMQpezjCnHXObXPxrEFduT;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.uJlHmdwEmZILzmHAFnPMQfvwLnfH();
			IntPtr intPtr2 = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.vscZBvMucbOyMfqJkbaPPOFWbTRj();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => psQRnUGAxXXGjIkyrLVogNnrUEGD.cbjBtQgEcnCRBhgaoUwFdCjDWhjXB;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => cenkEFLNjUadqCYJhKRRkUtIKUYNA.inputSource;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (cenkEFLNjUadqCYJhKRRkUtIKUYNA == null)
			{
				return InputSource.None;
			}
			return cenkEFLNjUadqCYJhKRRkUtIKUYNA.inputSourceType;
		}
	}

	public twryUExgDGLgXIFKRmEEbGMrUxBA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			QYUtNbMtCgMnyNuLpRYMsIcuLrEi = P_0.windowsStandalonePrimaryInputSource;
			hHaeeNHMQpezjCnHXObXPxrEFduT = GhdBWbNYmDqYrUQbQvmmvuqfDdKn._003C_003E9.MZcWtpsXUBxWfRFSDJxOPoSobfHB;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.DirectInput || QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.RawInput);
			ivZaYCCtEtNTtFRjdTwDlGuFTodBC ivZaYCCtEtNTtFRjdTwDlGuFTodBC2 = ivZaYCCtEtNTtFRjdTwDlGuFTodBC.None;
			if (flag2)
			{
				ivZaYCCtEtNTtFRjdTwDlGuFTodBC2 = (P_0.GetPlatformVar_useWindowsGamingInput() ? ivZaYCCtEtNTtFRjdTwDlGuFTodBC.WindowsGamingInput : (P_0.useXInput ? ivZaYCCtEtNTtFRjdTwDlGuFTodBC.XInput : ivZaYCCtEtNTtFRjdTwDlGuFTodBC.None));
			}
			bool flag3 = ivZaYCCtEtNTtFRjdTwDlGuFTodBC2 == ivZaYCCtEtNTtFRjdTwDlGuFTodBC.WindowsGamingInput || ivZaYCCtEtNTtFRjdTwDlGuFTodBC2 == ivZaYCCtEtNTtFRjdTwDlGuFTodBC.XInput || QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.XInput || QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			EtLWzOxoiSdkpGOpmFcLCIXPfrDbb = P_1;
			FkKAFEXjiJpbaBpOcYIALNvtByLEA = P_2;
			bool flag4 = false;
			OjRrBijLPjSchEkdZkqDuPmEOtsW = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					YMIsqNPkWjrdLcJvEeLWjHNzddLY.sXJldihOTtQuAobmFasPIcWImTtk(flag3);
				}
				catch (Exception ex)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				switch (ivZaYCCtEtNTtFRjdTwDlGuFTodBC2)
				{
				case ivZaYCCtEtNTtFRjdTwDlGuFTodBC.XInput:
					if (rYLFLmnVQsYgoAAAMYQYAwqxzbLG(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case ivZaYCCtEtNTtFRjdTwDlGuFTodBC.WindowsGamingInput:
					if (oUhcJkuFeikkaLgxRLvzcKxffGQx(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (rYLFLmnVQsYgoAAAMYQYAwqxzbLG(P_0, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							P_0.useXInput = false;
						}
					}
					break;
				}
			}
			if (flag)
			{
				if (!flag4 && !rYLFLmnVQsYgoAAAMYQYAwqxzbLG(P_0, true, out cenkEFLNjUadqCYJhKRRkUtIKUYNA))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				gljANFByvnGYVkPpoabwcckaRCWCc = new tRxWniojlYUQtbpCVvaSxCPROnZE();
				bool flag5 = false;
				if (QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = NWfskOTcSyesuzZmvICmYzZqHVEn(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, platformInputManager as MOkVWevpNUQwQWbUTpfVSRcmsAig);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = rfGjJCCvghyTruozpejikyiKDBcgb(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, platformInputManager as MOkVWevpNUQwQWbUTpfVSRcmsAig);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							QYUtNbMtCgMnyNuLpRYMsIcuLrEi = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = rfGjJCCvghyTruozpejikyiKDBcgb(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, platformInputManager as MOkVWevpNUQwQWbUTpfVSRcmsAig);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = NWfskOTcSyesuzZmvICmYzZqHVEn(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, platformInputManager as MOkVWevpNUQwQWbUTpfVSRcmsAig);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							QYUtNbMtCgMnyNuLpRYMsIcuLrEi = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = rYLFLmnVQsYgoAAAMYQYAwqxzbLG(P_0, true, out cenkEFLNjUadqCYJhKRRkUtIKUYNA);
					flag4 = flag5;
					if (flag5)
					{
						qKBChqfYUYhasrUCfrUxxRxrrXsh(P_0, gljANFByvnGYVkPpoabwcckaRCWCc);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = rfGjJCCvghyTruozpejikyiKDBcgb(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							QYUtNbMtCgMnyNuLpRYMsIcuLrEi = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (QYUtNbMtCgMnyNuLpRYMsIcuLrEi == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = oUhcJkuFeikkaLgxRLvzcKxffGQx(P_0, true, out cenkEFLNjUadqCYJhKRRkUtIKUYNA);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = rYLFLmnVQsYgoAAAMYQYAwqxzbLG(P_0, true, out cenkEFLNjUadqCYJhKRRkUtIKUYNA);
							flag4 = flag5;
							if (flag5)
							{
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								P_0.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = rfGjJCCvghyTruozpejikyiKDBcgb(P_0, gljANFByvnGYVkPpoabwcckaRCWCc, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								QYUtNbMtCgMnyNuLpRYMsIcuLrEi = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						qKBChqfYUYhasrUCfrUxxRxrrXsh(P_0, gljANFByvnGYVkPpoabwcckaRCWCc);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				gljANFByvnGYVkPpoabwcckaRCWCc.AstUEERlLmUaonzwBDJmewKRotJy += OHratVfhsEcqhROeGtUjrADosoiJ;
				gljANFByvnGYVkPpoabwcckaRCWCc.VZbOqFpaMyZvsgsGwqtAbDlWAmeS += RZUgSvkhKmrsvPvWSySTSbTXKoFD;
			}
			if (cenkEFLNjUadqCYJhKRRkUtIKUYNA == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			ogoLdzNKsHvptwEnFfXlaACHoIJO = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool NWfskOTcSyesuzZmvICmYzZqHVEn(ConfigVars P_0, tRxWniojlYUQtbpCVvaSxCPROnZE P_1, MOkVWevpNUQwQWbUTpfVSRcmsAig P_2)
	{
		fKpnWTQDLfAaFVzDGMjvAtHuVFyi fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = null;
		nHYtgmYZbuslvbwvuThTQLBbdmkB nHYtgmYZbuslvbwvuThTQLBbdmkB2 = null;
		try
		{
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = new fKpnWTQDLfAaFVzDGMjvAtHuVFyi(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			nHYtgmYZbuslvbwvuThTQLBbdmkB2 = (nHYtgmYZbuslvbwvuThTQLBbdmkB)(cenkEFLNjUadqCYJhKRRkUtIKUYNA = new nHYtgmYZbuslvbwvuThTQLBbdmkB(P_0.updateLoop, P_2, P_1.EiBBsdJiTwHqmUCtjqJHAQyKnVevA, EtLWzOxoiSdkpGOpmFcLCIXPfrDbb, FkKAFEXjiJpbaBpOcYIALNvtByLEA));
			OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(5, fKpnWTQDLfAaFVzDGMjvAtHuVFyi2);
			OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(1, cenkEFLNjUadqCYJhKRRkUtIKUYNA);
			P_1.mQLjdgDGeuHveKaafBTzbypZvUDDA += fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.fUKyHtmhZZukPxnAZWBUOeDmuBpE;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			nHYtgmYZbuslvbwvuThTQLBbdmkB2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
			nHYtgmYZbuslvbwvuThTQLBbdmkB2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
			nHYtgmYZbuslvbwvuThTQLBbdmkB2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			return true;
		}
		catch (Exception)
		{
			nHYtgmYZbuslvbwvuThTQLBbdmkB2?.OnDestroy();
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool rfGjJCCvghyTruozpejikyiKDBcgb(ConfigVars P_0, tRxWniojlYUQtbpCVvaSxCPROnZE P_1, MOkVWevpNUQwQWbUTpfVSRcmsAig P_2)
	{
		fKpnWTQDLfAaFVzDGMjvAtHuVFyi fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = null;
		try
		{
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = new fKpnWTQDLfAaFVzDGMjvAtHuVFyi(P_0, P_2, EtLWzOxoiSdkpGOpmFcLCIXPfrDbb, FkKAFEXjiJpbaBpOcYIALNvtByLEA, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(5, fKpnWTQDLfAaFVzDGMjvAtHuVFyi2);
			P_1.mQLjdgDGeuHveKaafBTzbypZvUDDA += fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.fUKyHtmhZZukPxnAZWBUOeDmuBpE;
			cenkEFLNjUadqCYJhKRRkUtIKUYNA = fKpnWTQDLfAaFVzDGMjvAtHuVFyi2;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2?.OnDestroy();
		}
		return false;
	}

	private bool qKBChqfYUYhasrUCfrUxxRxrrXsh(ConfigVars P_0, tRxWniojlYUQtbpCVvaSxCPROnZE P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		fKpnWTQDLfAaFVzDGMjvAtHuVFyi fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = null;
		try
		{
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = new fKpnWTQDLfAaFVzDGMjvAtHuVFyi(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.mQLjdgDGeuHveKaafBTzbypZvUDDA += fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.fUKyHtmhZZukPxnAZWBUOeDmuBpE;
			OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(5, fKpnWTQDLfAaFVzDGMjvAtHuVFyi2);
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2?.OnDestroy();
			fKpnWTQDLfAaFVzDGMjvAtHuVFyi2 = null;
			return false;
		}
	}

	private bool rYLFLmnVQsYgoAAAMYQYAwqxzbLG(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				xwdWTDctOIazBczcnZgxRjrnCTBFb xwdWTDctOIazBczcnZgxRjrnCTBFb2 = new xwdWTDctOIazBczcnZgxRjrnCTBFb();
				xwdWTDctOIazBczcnZgxRjrnCTBFb2.aCydqpceKhJEHIShBuPdvJgJIXTmA = 0;
				P_2 = new QFMIdjQvuHEqbdqAsbQLKYQulzoJ(flag, updateLoop, EtLWzOxoiSdkpGOpmFcLCIXPfrDbb, xwdWTDctOIazBczcnZgxRjrnCTBFb2.JyVntikZcsNUBbnxNYCiKixpbqpW, hHaeeNHMQpezjCnHXObXPxrEFduT);
				OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(2, P_2);
			}
			else
			{
				P_2 = new QFMIdjQvuHEqbdqAsbQLKYQulzoJ(flag, updateLoop, EtLWzOxoiSdkpGOpmFcLCIXPfrDbb, FkKAFEXjiJpbaBpOcYIALNvtByLEA, hHaeeNHMQpezjCnHXObXPxrEFduT);
				OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(2, P_2);
				P_2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
				P_2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
				P_2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			}
			return true;
		}
		catch
		{
			P_2 = null;
			if (P_1)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				P_0.useXInput = false;
				for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
				{
					if (OjRrBijLPjSchEkdZkqDuPmEOtsW[i] != null && OjRrBijLPjSchEkdZkqDuPmEOtsW[i] is EbCVMtZcbYODojUXzIyunqpRvZvf ebCVMtZcbYODojUXzIyunqpRvZvf && ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX != null && ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX.ataxcpEqueNAsfQPoyDnpadipQUk == ivZaYCCtEtNTtFRjdTwDlGuFTodBC.XInput)
					{
						ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + QYUtNbMtCgMnyNuLpRYMsIcuLrEi.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool oUhcJkuFeikkaLgxRLvzcKxffGQx(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new MQOourktjhvDLxLUFhVTyXcWjhFV(P_0, EtLWzOxoiSdkpGOpmFcLCIXPfrDbb, FkKAFEXjiJpbaBpOcYIALNvtByLEA, hHaeeNHMQpezjCnHXObXPxrEFduT);
			if (P_1)
			{
				cenkEFLNjUadqCYJhKRRkUtIKUYNA = P_2;
			}
			OjRrBijLPjSchEkdZkqDuPmEOtsW.Add(30, P_2);
			P_2.DeviceConnectedEvent += WKRGsNNNzKIRFTGkEeRTxkRzIETD;
			P_2.DeviceDisconnectedEvent += FPUFFUueUECrqJHjIsoQbctEtTCpA;
			P_2.UpdateControllerInfoEvent += ECneuWBWxWIlEvwfHhyyakomOzLhA;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
				{
					if (OjRrBijLPjSchEkdZkqDuPmEOtsW[i] != null && OjRrBijLPjSchEkdZkqDuPmEOtsW[i] is EbCVMtZcbYODojUXzIyunqpRvZvf ebCVMtZcbYODojUXzIyunqpRvZvf && ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX != null && ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX.ataxcpEqueNAsfQPoyDnpadipQUk == ivZaYCCtEtNTtFRjdTwDlGuFTodBC.WindowsGamingInput)
					{
						ebCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX = null;
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		vzsCKgEyOZYnMHSYbeEpEieJXjoE = true;
		psQRnUGAxXXGjIkyrLVogNnrUEGD = new LSSaQOyjxBKKgckyXAoJQGPijVKP();
		for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
		{
			OjRrBijLPjSchEkdZkqDuPmEOtsW[i].Initialize();
		}
	}

	public virtual void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
		{
			OjRrBijLPjSchEkdZkqDuPmEOtsW[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = OjRrBijLPjSchEkdZkqDuPmEOtsW.Count - 1; num >= 0; num--)
		{
			OjRrBijLPjSchEkdZkqDuPmEOtsW[num].OnDestroy();
		}
		OjRrBijLPjSchEkdZkqDuPmEOtsW.Clear();
		if (gljANFByvnGYVkPpoabwcckaRCWCc != null)
		{
			gljANFByvnGYVkPpoabwcckaRCWCc.UQZzWxMeIVaOaZVMlBSlYBtxDEugA();
			gljANFByvnGYVkPpoabwcckaRCWCc = null;
		}
		YMIsqNPkWjrdLcJvEeLWjHNzddLY.vCBFvIdHsbAnKBZkroQOsRrLIAyV();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return ogoLdzNKsHvptwEnFfXlaACHoIJO;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		OjRrBijLPjSchEkdZkqDuPmEOtsW.GetValue((int)data.source).UpdateControllerData(psQRnUGAxXXGjIkyrLVogNnrUEGD.FYQGWAOkRmcsESDdpolWcdcEUaab(controllerId, data.source, LSSaQOyjxBKKgckyXAoJQGPijVKP.hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = OjRrBijLPjSchEkdZkqDuPmEOtsW[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = OjRrBijLPjSchEkdZkqDuPmEOtsW[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void WKRGsNNNzKIRFTGkEeRTxkRzIETD(BridgedController P_0)
	{
		if (P_0 != null)
		{
			psQRnUGAxXXGjIkyrLVogNnrUEGD.veRTpSicUyGksqyIruVCBNTwdMJs(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void FPUFFUueUECrqJHjIsoQbctEtTCpA(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			psQRnUGAxXXGjIkyrLVogNnrUEGD.CBCfunYlaFTjvuySlcPuEOYlKnAX(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void OHratVfhsEcqhROeGtUjrADosoiJ(EventArgs P_0)
	{
		if (vzsCKgEyOZYnMHSYbeEpEieJXjoE)
		{
			for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
			{
				OjRrBijLPjSchEkdZkqDuPmEOtsW[i].SystemDeviceConnected();
			}
		}
	}

	private void RZUgSvkhKmrsvPvWSySTSbTXKoFD(EventArgs P_0)
	{
		if (vzsCKgEyOZYnMHSYbeEpEieJXjoE)
		{
			for (int i = 0; i < OjRrBijLPjSchEkdZkqDuPmEOtsW.Count; i++)
			{
				OjRrBijLPjSchEkdZkqDuPmEOtsW[i].SystemDeviceDisconnected();
			}
		}
	}

	private void ECneuWBWxWIlEvwfHhyyakomOzLhA(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		psQRnUGAxXXGjIkyrLVogNnrUEGD.qApdHIvnExfmEeRXjrRaBQSMJkTAb(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		LSSaQOyjxBKKgckyXAoJQGPijVKP.hPAhvsBwYGVVjqeOJFucGpdEhYpVA hPAhvsBwYGVVjqeOJFucGpdEhYpVA = LSSaQOyjxBKKgckyXAoJQGPijVKP.hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Connected;
		int num = psQRnUGAxXXGjIkyrLVogNnrUEGD.oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0.sourceJoystick.rewiredId, hPAhvsBwYGVVjqeOJFucGpdEhYpVA);
		if (num < 0)
		{
			hPAhvsBwYGVVjqeOJFucGpdEhYpVA = LSSaQOyjxBKKgckyXAoJQGPijVKP.hPAhvsBwYGVVjqeOJFucGpdEhYpVA.Disconnected;
			num = psQRnUGAxXXGjIkyrLVogNnrUEGD.oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0.sourceJoystick.rewiredId, hPAhvsBwYGVVjqeOJFucGpdEhYpVA);
		}
		if (num >= 0)
		{
			LSSaQOyjxBKKgckyXAoJQGPijVKP.wCLcWTbQFfEvrcLKAoNJDfPifxeie wCLcWTbQFfEvrcLKAoNJDfPifxeie = psQRnUGAxXXGjIkyrLVogNnrUEGD.szomBNAfyNNNcDinGDTycxDpOIjGA(num, hPAhvsBwYGVVjqeOJFucGpdEhYpVA);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new HFDbqbZOXpcjJWiZtXTgcFSAChCK(P_0.sourceJoystick, wCLcWTbQFfEvrcLKAoNJDfPifxeie.saTtsKYxNzreuCpToynSEFzacyVDA)));
			}
		}
	}
}
