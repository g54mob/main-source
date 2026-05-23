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

internal class tQvvHtjvyoLHXIDvEFlotdGkgMVJ : PlatformInputManager, INativePlatformHelper
{
	private class eUrAgsjqJfMgSXdyOYmUuVkSKlAgA
	{
		private class DtBaPjRIYebkdyZpGImDfuiMqfnV
		{
			public int CDnvSOcGjJPPIyzvetabnvXpfjrX;

			public int mjYApcJNjBEenhirQeoCksQQlNnrA;

			public int JjlwUunalRBmQYyNNlyUYUlyEVv;

			public InputSource oLReFwyeALMgIPrIVozHrGjUBJiu;

			public DtBaPjRIYebkdyZpGImDfuiMqfnV(int P_0, int P_1, int P_2, InputSource P_3)
			{
				CDnvSOcGjJPPIyzvetabnvXpfjrX = P_0;
				mjYApcJNjBEenhirQeoCksQQlNnrA = P_1;
				JjlwUunalRBmQYyNNlyUYUlyEVv = P_2;
				oLReFwyeALMgIPrIVozHrGjUBJiu = P_3;
			}

			public void FOQqfPqRLzbxXTyObwfHTbwLiHC(int P_0)
			{
				mjYApcJNjBEenhirQeoCksQQlNnrA = P_0;
			}

			public uAKhPeMZXCItOXzgkPuznjJHZRCr SFwMvJSmumKKGKrdUDWVJkkUGpXi()
			{
				return new uAKhPeMZXCItOXzgkPuznjJHZRCr(CDnvSOcGjJPPIyzvetabnvXpfjrX, mjYApcJNjBEenhirQeoCksQQlNnrA, oLReFwyeALMgIPrIVozHrGjUBJiu);
			}

			public static int hgOKyILeRqogtQHHafzpYarVdcUh(DtBaPjRIYebkdyZpGImDfuiMqfnV P_0, DtBaPjRIYebkdyZpGImDfuiMqfnV P_1)
			{
				if (P_0.CDnvSOcGjJPPIyzvetabnvXpfjrX < P_1.CDnvSOcGjJPPIyzvetabnvXpfjrX)
				{
					return -1;
				}
				if (P_0.CDnvSOcGjJPPIyzvetabnvXpfjrX > P_1.CDnvSOcGjJPPIyzvetabnvXpfjrX)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct uAKhPeMZXCItOXzgkPuznjJHZRCr
		{
			public int XnydYMdrZaxnhWnBmtnaICLZQjES;

			public int ZGXtFboJVlcVPfWwknWoMHceDSxdA;

			public InputSource GasIVCbxxLqBpBMnOIznmuxWAeFrA;

			public uAKhPeMZXCItOXzgkPuznjJHZRCr(int P_0, int P_1, InputSource P_2)
			{
				XnydYMdrZaxnhWnBmtnaICLZQjES = P_0;
				ZGXtFboJVlcVPfWwknWoMHceDSxdA = P_1;
				GasIVCbxxLqBpBMnOIznmuxWAeFrA = P_2;
			}
		}

		public enum nNLJiPTgIrHVOfkkRmHEIlxcNaHz
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<DtBaPjRIYebkdyZpGImDfuiMqfnV> xBjDjMZsmAamegOAuqnMmbqamESgA;

		private List<DtBaPjRIYebkdyZpGImDfuiMqfnV> PjJEyMPHctpHQJBaiAmYAmzWGXQn;

		public int LCllQxEEHKNHovRwIWzaCQtCIpDL => PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count;

		public eUrAgsjqJfMgSXdyOYmUuVkSKlAgA()
		{
			PjJEyMPHctpHQJBaiAmYAmzWGXQn = new List<DtBaPjRIYebkdyZpGImDfuiMqfnV>();
			xBjDjMZsmAamegOAuqnMmbqamESgA = new List<DtBaPjRIYebkdyZpGImDfuiMqfnV>();
		}

		public void tHSWlsZyDmOaCdiNdJBehfowGMXj(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = BGGygZzhpgDmRUcXgdZoYMtuwKaT(sourceJoystick.rewiredId, nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected);
			DtBaPjRIYebkdyZpGImDfuiMqfnV dtBaPjRIYebkdyZpGImDfuiMqfnV;
			if (num >= 0)
			{
				dtBaPjRIYebkdyZpGImDfuiMqfnV = PjJEyMPHctpHQJBaiAmYAmzWGXQn[num];
				dtBaPjRIYebkdyZpGImDfuiMqfnV.FOQqfPqRLzbxXTyObwfHTbwLiHC(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new xOMDMeVbpdCCWfFlnaNufjGMHMIVA(sourceJoystick, dtBaPjRIYebkdyZpGImDfuiMqfnV.CDnvSOcGjJPPIyzvetabnvXpfjrX);
				return;
			}
			num = BGGygZzhpgDmRUcXgdZoYMtuwKaT(sourceJoystick.rewiredId, nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected);
			if (num >= 0)
			{
				dtBaPjRIYebkdyZpGImDfuiMqfnV = xBjDjMZsmAamegOAuqnMmbqamESgA[num];
				xBjDjMZsmAamegOAuqnMmbqamESgA.RemoveAt(num);
				int cDnvSOcGjJPPIyzvetabnvXpfjrX = DhxqBLaCvZGEVTpZLmkRNYELNQek(dtBaPjRIYebkdyZpGImDfuiMqfnV.CDnvSOcGjJPPIyzvetabnvXpfjrX);
				dtBaPjRIYebkdyZpGImDfuiMqfnV.CDnvSOcGjJPPIyzvetabnvXpfjrX = cDnvSOcGjJPPIyzvetabnvXpfjrX;
			}
			else
			{
				dtBaPjRIYebkdyZpGImDfuiMqfnV = new DtBaPjRIYebkdyZpGImDfuiMqfnV(fdfFjXdhzbiAjHNSCHZhZMYarTfIB(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new xOMDMeVbpdCCWfFlnaNufjGMHMIVA(sourceJoystick, dtBaPjRIYebkdyZpGImDfuiMqfnV.CDnvSOcGjJPPIyzvetabnvXpfjrX);
			PjJEyMPHctpHQJBaiAmYAmzWGXQn.Add(dtBaPjRIYebkdyZpGImDfuiMqfnV);
			PjJEyMPHctpHQJBaiAmYAmzWGXQn.Sort(DtBaPjRIYebkdyZpGImDfuiMqfnV.hgOKyILeRqogtQHHafzpYarVdcUh);
		}

		public void OAOqWwOrqtdEvUDHJxJmdTOFkkgP(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0.rewiredId, nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				DtBaPjRIYebkdyZpGImDfuiMqfnV item = PjJEyMPHctpHQJBaiAmYAmzWGXQn[num];
				PjJEyMPHctpHQJBaiAmYAmzWGXQn.RemoveAt(num);
				xBjDjMZsmAamegOAuqnMmbqamESgA.Add(item);
			}
		}

		public void gBOcXwBABNPvUXRtWbzOARnHcsIy(int P_0, int P_1)
		{
			int num = BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0, nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected);
			if (num >= 0)
			{
				PjJEyMPHctpHQJBaiAmYAmzWGXQn[num].FOQqfPqRLzbxXTyObwfHTbwLiHC(P_1);
				return;
			}
			num = BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0, nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected);
			if (num >= 0)
			{
				xBjDjMZsmAamegOAuqnMmbqamESgA[num].FOQqfPqRLzbxXTyObwfHTbwLiHC(P_1);
			}
		}

		public bool MhDlSAMJGQIDIgaQKVocJfCxRiFE(int P_0, nNLJiPTgIrHVOfkkRmHEIlxcNaHz P_1)
		{
			if (BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int BGGygZzhpgDmRUcXgdZoYMtuwKaT(int P_0, nNLJiPTgIrHVOfkkRmHEIlxcNaHz P_1)
		{
			switch (P_1)
			{
			case nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected:
			{
				int count2 = PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count;
				for (int j = 0; j < count2; j++)
				{
					if (PjJEyMPHctpHQJBaiAmYAmzWGXQn[j].JjlwUunalRBmQYyNNlyUYUlyEVv == P_0)
					{
						return j;
					}
				}
				break;
			}
			case nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected:
			{
				int count = xBjDjMZsmAamegOAuqnMmbqamESgA.Count;
				for (int i = 0; i < count; i++)
				{
					if (xBjDjMZsmAamegOAuqnMmbqamESgA[i].JjlwUunalRBmQYyNNlyUYUlyEVv == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int tpurdtBLiEduAgImvEqIqEiDVccI(int P_0, InputSource P_1, nNLJiPTgIrHVOfkkRmHEIlxcNaHz P_2)
		{
			switch (P_2)
			{
			case nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected:
			{
				int count2 = PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count;
				for (int j = 0; j < count2; j++)
				{
					if (PjJEyMPHctpHQJBaiAmYAmzWGXQn[j].CDnvSOcGjJPPIyzvetabnvXpfjrX == P_0 && PjJEyMPHctpHQJBaiAmYAmzWGXQn[j].oLReFwyeALMgIPrIVozHrGjUBJiu == P_1)
					{
						return j;
					}
				}
				break;
			}
			case nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected:
			{
				int count = xBjDjMZsmAamegOAuqnMmbqamESgA.Count;
				for (int i = 0; i < count; i++)
				{
					if (xBjDjMZsmAamegOAuqnMmbqamESgA[i].CDnvSOcGjJPPIyzvetabnvXpfjrX == P_0 && xBjDjMZsmAamegOAuqnMmbqamESgA[i].oLReFwyeALMgIPrIVozHrGjUBJiu == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public uAKhPeMZXCItOXzgkPuznjJHZRCr QZRCFEfSxSewrvmXdPagnpJpdpRBA(int P_0, nNLJiPTgIrHVOfkkRmHEIlxcNaHz P_1)
		{
			if (P_1 == nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected)
			{
				if (P_0 < 0 || P_0 >= PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return PjJEyMPHctpHQJBaiAmYAmzWGXQn[P_0].SFwMvJSmumKKGKrdUDWVJkkUGpXi();
			}
			if (P_0 < 0 || P_0 >= xBjDjMZsmAamegOAuqnMmbqamESgA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return xBjDjMZsmAamegOAuqnMmbqamESgA[P_0].SFwMvJSmumKKGKrdUDWVJkkUGpXi();
		}

		public int ZtMWKHWiPENIqbxzdepyVBGksODh(int P_0, InputSource P_1, nNLJiPTgIrHVOfkkRmHEIlxcNaHz P_2)
		{
			int num = tpurdtBLiEduAgImvEqIqEiDVccI(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected => PjJEyMPHctpHQJBaiAmYAmzWGXQn[num].mjYApcJNjBEenhirQeoCksQQlNnrA, 
				nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected => xBjDjMZsmAamegOAuqnMmbqamESgA[num].mjYApcJNjBEenhirQeoCksQQlNnrA, 
				_ => -1, 
			};
		}

		private int DhxqBLaCvZGEVTpZLmkRNYELNQek(int P_0)
		{
			int count = PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count;
			for (int i = 0; i < count; i++)
			{
				if (PjJEyMPHctpHQJBaiAmYAmzWGXQn[i].CDnvSOcGjJPPIyzvetabnvXpfjrX == P_0)
				{
					return fdfFjXdhzbiAjHNSCHZhZMYarTfIB();
				}
			}
			return P_0;
		}

		private int fdfFjXdhzbiAjHNSCHZhZMYarTfIB()
		{
			int count = PjJEyMPHctpHQJBaiAmYAmzWGXQn.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (PjJEyMPHctpHQJBaiAmYAmzWGXQn[i].CDnvSOcGjJPPIyzvetabnvXpfjrX == num)
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

	private class xOMDMeVbpdCCWfFlnaNufjGMHMIVA : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic eagbLiNPZcMYzdWhRRqQKaRSyodi;

		private int icocuxEjUkkCVETQPWKKSEaMLgLPA;

		int IInputManagerJoystickPublic.rewiredId => eagbLiNPZcMYzdWhRRqQKaRSyodi.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => icocuxEjUkkCVETQPWKKSEaMLgLPA;

		string IInputManagerJoystickPublic.name => eagbLiNPZcMYzdWhRRqQKaRSyodi.name;

		long? IInputManagerJoystickPublic.systemId => eagbLiNPZcMYzdWhRRqQKaRSyodi.systemId;

		int IInputManagerJoystickPublic.unityId => eagbLiNPZcMYzdWhRRqQKaRSyodi.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => eagbLiNPZcMYzdWhRRqQKaRSyodi.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => eagbLiNPZcMYzdWhRRqQKaRSyodi.extension;

		public xOMDMeVbpdCCWfFlnaNufjGMHMIVA(IInputManagerJoystickPublic P_0, int P_1)
		{
			eagbLiNPZcMYzdWhRRqQKaRSyodi = P_0;
			icocuxEjUkkCVETQPWKKSEaMLgLPA = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			eagbLiNPZcMYzdWhRRqQKaRSyodi.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			eagbLiNPZcMYzdWhRRqQKaRSyodi.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (eagbLiNPZcMYzdWhRRqQKaRSyodi is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class AfgRbCBqksIxAIPNATqUxuYJZPyc
	{
		public static readonly AfgRbCBqksIxAIPNATqUxuYJZPyc _003C_003E9 = new AfgRbCBqksIxAIPNATqUxuYJZPyc();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool wBRkaEVKNJiIbBCXKrYrSgLUcPbO(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class bwmpUwmmWvDdstSIhJxHxHjJFbjw
	{
		public int AHzkkZyzumIncUBAIcwHwQrvbTRGA;

		internal int rJUfUcrEMjAfkdHPmANWzMkJGDJDb()
		{
			return AHzkkZyzumIncUBAIcwHwQrvbTRGA++;
		}
	}

	private const bool suqjsXRcCdegunWmaHBtGkQrjyelA = false;

	private const bool qiuiKgKBvyuwLkBRzqiJdvDKvZv = false;

	private const bool LtRlrXXlmfkZVOztbtXeBfokUwvI = false;

	private const bool NGwYYtipWudsvUUrHCQjGThsJllN = false;

	private const bool nWxUzofdgxtNdNayTvlSPoczFCup = false;

	private const bool vLFRclSlEKXdIRygAVQdYJQRaArgA = false;

	private bool zfJomXWLxtsqXBlpWChrUqVSwcRI;

	private psyVvNoJtvYzYzORZMfifaHpFkfs ZLAgCfQxmckeqZfVyaqsSEfMBCwh;

	private IndexedDictionary<int, PlatformInputManager> ejgpaCMxKykgQuwCwIRAcLDneTNU;

	private eUrAgsjqJfMgSXdyOYmUuVkSKlAgA hHEvmYXLOqUuPxulawyLOLkjoShc;

	private Action<int, ControllerDataUpdater> nsiOZhhvSpgIYruaJnMeepXyDeV;

	private WindowsStandalonePrimaryInputSource bhObAtiHfnnqZatugbcxKZnwmybQA;

	private PlatformInputManager CTsFFsEapdQLdoWUSfXWrnEuqPCoA;

	private bool vZkvXtLuvUIQTvIDemPtHYmNPejC;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> JsEgfuztFGOvRIxBBubiylULlaIA;

	private Func<int> eirwgEnKRpDJrgNMmbFQEwoJEwZyA;

	private Func<PidVid, bool> scPUqAtdAkjOmKLTXjDbzdNftALWA;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = FanHTnvZmXVTOfDHuteqdkMyhpJj.VIXkMfLylzleLBdreNdjhcEErdNB();
			IntPtr intPtr2 = FanHTnvZmXVTOfDHuteqdkMyhpJj.ijitjiayhvhWQoKCwerAUgHUVate();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => hHEvmYXLOqUuPxulawyLOLkjoShc.LCllQxEEHKNHovRwIWzaCQtCIpDL;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => CTsFFsEapdQLdoWUSfXWrnEuqPCoA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => CTsFFsEapdQLdoWUSfXWrnEuqPCoA.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (CTsFFsEapdQLdoWUSfXWrnEuqPCoA == null)
			{
				return InputSource.None;
			}
			return CTsFFsEapdQLdoWUSfXWrnEuqPCoA.inputSourceType;
		}
	}

	public tQvvHtjvyoLHXIDvEFlotdGkgMVJ(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			bhObAtiHfnnqZatugbcxKZnwmybQA = P_0.windowsStandalonePrimaryInputSource;
			scPUqAtdAkjOmKLTXjDbzdNftALWA = AfgRbCBqksIxAIPNATqUxuYJZPyc._003C_003E9.wBRkaEVKNJiIbBCXKrYrSgLUcPbO;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.DirectInput || bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.RawInput);
			iSWDNvpsUMPLKHvHHpHbIawpGErjA iSWDNvpsUMPLKHvHHpHbIawpGErjA2 = iSWDNvpsUMPLKHvHHpHbIawpGErjA.None;
			if (flag2)
			{
				iSWDNvpsUMPLKHvHHpHbIawpGErjA2 = (P_0.GetPlatformVar_useWindowsGamingInput() ? iSWDNvpsUMPLKHvHHpHbIawpGErjA.WindowsGamingInput : (P_0.useXInput ? iSWDNvpsUMPLKHvHHpHbIawpGErjA.XInput : iSWDNvpsUMPLKHvHHpHbIawpGErjA.None));
			}
			bool flag3 = iSWDNvpsUMPLKHvHHpHbIawpGErjA2 == iSWDNvpsUMPLKHvHHpHbIawpGErjA.WindowsGamingInput || iSWDNvpsUMPLKHvHHpHbIawpGErjA2 == iSWDNvpsUMPLKHvHHpHbIawpGErjA.XInput || bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.XInput || bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			JsEgfuztFGOvRIxBBubiylULlaIA = P_1;
			eirwgEnKRpDJrgNMmbFQEwoJEwZyA = P_2;
			bool flag4 = false;
			ejgpaCMxKykgQuwCwIRAcLDneTNU = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					WNDYrcPDOUObmqnBCmqijYTVsDhn.XkFBMSYBBtgiSCQLXCPTmqNpFqTzA(flag3);
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
				switch (iSWDNvpsUMPLKHvHHpHbIawpGErjA2)
				{
				case iSWDNvpsUMPLKHvHHpHbIawpGErjA.XInput:
					if (pcSWBjJtMBxfGrqIHVZkOgKSMXGo(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case iSWDNvpsUMPLKHvHHpHbIawpGErjA.WindowsGamingInput:
					if (gqGHTNUqGuryKIwVAQnihviWBsmx(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (pcSWBjJtMBxfGrqIHVZkOgKSMXGo(P_0, false, out platformInputManager))
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
				if (!flag4 && !pcSWBjJtMBxfGrqIHVZkOgKSMXGo(P_0, true, out CTsFFsEapdQLdoWUSfXWrnEuqPCoA))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				ZLAgCfQxmckeqZfVyaqsSEfMBCwh = new psyVvNoJtvYzYzORZMfifaHpFkfs();
				bool flag5 = false;
				if (bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = srRQZSTOXkvSOmiXKHGlbruTPesH(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, platformInputManager as MpfSAJjorzYIlCIHNIPpIhZKdISt);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = LxKJIZspXOpDGXSUNvBrnmpZNuuB(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, platformInputManager as MpfSAJjorzYIlCIHNIPpIhZKdISt);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							bhObAtiHfnnqZatugbcxKZnwmybQA = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = LxKJIZspXOpDGXSUNvBrnmpZNuuB(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, platformInputManager as MpfSAJjorzYIlCIHNIPpIhZKdISt);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = srRQZSTOXkvSOmiXKHGlbruTPesH(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, platformInputManager as MpfSAJjorzYIlCIHNIPpIhZKdISt);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							bhObAtiHfnnqZatugbcxKZnwmybQA = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = pcSWBjJtMBxfGrqIHVZkOgKSMXGo(P_0, true, out CTsFFsEapdQLdoWUSfXWrnEuqPCoA);
					flag4 = flag5;
					if (flag5)
					{
						asDGIYkaqaFNKqycyPAOKPLXGyDm(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = LxKJIZspXOpDGXSUNvBrnmpZNuuB(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							bhObAtiHfnnqZatugbcxKZnwmybQA = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (bhObAtiHfnnqZatugbcxKZnwmybQA == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = gqGHTNUqGuryKIwVAQnihviWBsmx(P_0, true, out CTsFFsEapdQLdoWUSfXWrnEuqPCoA);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = pcSWBjJtMBxfGrqIHVZkOgKSMXGo(P_0, true, out CTsFFsEapdQLdoWUSfXWrnEuqPCoA);
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
							flag5 = LxKJIZspXOpDGXSUNvBrnmpZNuuB(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								bhObAtiHfnnqZatugbcxKZnwmybQA = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						asDGIYkaqaFNKqycyPAOKPLXGyDm(P_0, ZLAgCfQxmckeqZfVyaqsSEfMBCwh);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				ZLAgCfQxmckeqZfVyaqsSEfMBCwh.mLELthMlrHyZglepoJEUDkDciuYs += DbMJbTrAakBwSqqjkiqPrhdDPFTl;
				ZLAgCfQxmckeqZfVyaqsSEfMBCwh.mLTyAwMAyiWAUqFDaFkLoFzaiwSB += lJapHwcXdEmXzVBtILTBUQYtEGBHA;
			}
			if (CTsFFsEapdQLdoWUSfXWrnEuqPCoA == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			nsiOZhhvSpgIYruaJnMeepXyDeV = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool srRQZSTOXkvSOmiXKHGlbruTPesH(ConfigVars P_0, psyVvNoJtvYzYzORZMfifaHpFkfs P_1, MpfSAJjorzYIlCIHNIPpIhZKdISt P_2)
	{
		dJgkOkKFuKUDgFbGQdAHAkRKhOSf dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = null;
		hJTsUFYdZHioKpvWwgoNOlLVAREN hJTsUFYdZHioKpvWwgoNOlLVAREN2 = null;
		try
		{
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = new dJgkOkKFuKUDgFbGQdAHAkRKhOSf(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			hJTsUFYdZHioKpvWwgoNOlLVAREN2 = (hJTsUFYdZHioKpvWwgoNOlLVAREN)(CTsFFsEapdQLdoWUSfXWrnEuqPCoA = new hJTsUFYdZHioKpvWwgoNOlLVAREN(P_0.updateLoop, P_2, P_1.eovRvjMQzTqSRBbyBMxcqpwvrQbX, JsEgfuztFGOvRIxBBubiylULlaIA, eirwgEnKRpDJrgNMmbFQEwoJEwZyA));
			ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(5, dJgkOkKFuKUDgFbGQdAHAkRKhOSf2);
			ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(1, CTsFFsEapdQLdoWUSfXWrnEuqPCoA);
			P_1.ZzSFnLoxrLlQpYpPYgrSqHMqsiuL += dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.WAjlddwrRunmDtDsyKjaifSgJaQp;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
			hJTsUFYdZHioKpvWwgoNOlLVAREN2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
			hJTsUFYdZHioKpvWwgoNOlLVAREN2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
			hJTsUFYdZHioKpvWwgoNOlLVAREN2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
			return true;
		}
		catch (Exception)
		{
			hJTsUFYdZHioKpvWwgoNOlLVAREN2?.OnDestroy();
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool LxKJIZspXOpDGXSUNvBrnmpZNuuB(ConfigVars P_0, psyVvNoJtvYzYzORZMfifaHpFkfs P_1, MpfSAJjorzYIlCIHNIPpIhZKdISt P_2)
	{
		dJgkOkKFuKUDgFbGQdAHAkRKhOSf dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = null;
		try
		{
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = new dJgkOkKFuKUDgFbGQdAHAkRKhOSf(P_0, P_2, JsEgfuztFGOvRIxBBubiylULlaIA, eirwgEnKRpDJrgNMmbFQEwoJEwZyA, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(5, dJgkOkKFuKUDgFbGQdAHAkRKhOSf2);
			P_1.ZzSFnLoxrLlQpYpPYgrSqHMqsiuL += dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.WAjlddwrRunmDtDsyKjaifSgJaQp;
			CTsFFsEapdQLdoWUSfXWrnEuqPCoA = dJgkOkKFuKUDgFbGQdAHAkRKhOSf2;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2?.OnDestroy();
		}
		return false;
	}

	private bool asDGIYkaqaFNKqycyPAOKPLXGyDm(ConfigVars P_0, psyVvNoJtvYzYzORZMfifaHpFkfs P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		dJgkOkKFuKUDgFbGQdAHAkRKhOSf dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = null;
		try
		{
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = new dJgkOkKFuKUDgFbGQdAHAkRKhOSf(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.ZzSFnLoxrLlQpYpPYgrSqHMqsiuL += dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.WAjlddwrRunmDtDsyKjaifSgJaQp;
			ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(5, dJgkOkKFuKUDgFbGQdAHAkRKhOSf2);
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2?.OnDestroy();
			dJgkOkKFuKUDgFbGQdAHAkRKhOSf2 = null;
			return false;
		}
	}

	private bool pcSWBjJtMBxfGrqIHVZkOgKSMXGo(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				bwmpUwmmWvDdstSIhJxHxHjJFbjw bwmpUwmmWvDdstSIhJxHxHjJFbjw2 = new bwmpUwmmWvDdstSIhJxHxHjJFbjw();
				bwmpUwmmWvDdstSIhJxHxHjJFbjw2.AHzkkZyzumIncUBAIcwHwQrvbTRGA = 0;
				P_2 = new YeDLvUUmeuKtQrgSaWuhUANSLKCe(flag, updateLoop, JsEgfuztFGOvRIxBBubiylULlaIA, bwmpUwmmWvDdstSIhJxHxHjJFbjw2.rJUfUcrEMjAfkdHPmANWzMkJGDJDb, scPUqAtdAkjOmKLTXjDbzdNftALWA);
				ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(2, P_2);
			}
			else
			{
				P_2 = new YeDLvUUmeuKtQrgSaWuhUANSLKCe(flag, updateLoop, JsEgfuztFGOvRIxBBubiylULlaIA, eirwgEnKRpDJrgNMmbFQEwoJEwZyA, scPUqAtdAkjOmKLTXjDbzdNftALWA);
				ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(2, P_2);
				P_2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
				P_2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
				P_2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
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
				for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
				{
					if (ejgpaCMxKykgQuwCwIRAcLDneTNU[i] != null && ejgpaCMxKykgQuwCwIRAcLDneTNU[i] is WcLOVIVVtbKfXzBpbdfQnbxdxBNU { DWTeVmUMIVxWjJIJYcGdVrdyhSFu: not null } wcLOVIVVtbKfXzBpbdfQnbxdxBNU && wcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu.eTLBhMfMnPjkUahXllXeDmNbLwJA == iSWDNvpsUMPLKHvHHpHbIawpGErjA.XInput)
					{
						wcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + bhObAtiHfnnqZatugbcxKZnwmybQA.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool gqGHTNUqGuryKIwVAQnihviWBsmx(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new SRHvnCwPfEHusreoJBituTimFFjv(P_0, JsEgfuztFGOvRIxBBubiylULlaIA, eirwgEnKRpDJrgNMmbFQEwoJEwZyA, scPUqAtdAkjOmKLTXjDbzdNftALWA);
			if (P_1)
			{
				CTsFFsEapdQLdoWUSfXWrnEuqPCoA = P_2;
			}
			ejgpaCMxKykgQuwCwIRAcLDneTNU.Add(30, P_2);
			P_2.DeviceConnectedEvent += UdUkBtCgyHUrHceAtFxycSCRcxebb;
			P_2.DeviceDisconnectedEvent += YUIUhjuovHBpcoauyEElcUzEBkJMA;
			P_2.UpdateControllerInfoEvent += hmQQJDEsSEckCRjVzCaGIntmCIeh;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
				{
					if (ejgpaCMxKykgQuwCwIRAcLDneTNU[i] != null && ejgpaCMxKykgQuwCwIRAcLDneTNU[i] is WcLOVIVVtbKfXzBpbdfQnbxdxBNU { DWTeVmUMIVxWjJIJYcGdVrdyhSFu: not null } wcLOVIVVtbKfXzBpbdfQnbxdxBNU && wcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu.eTLBhMfMnPjkUahXllXeDmNbLwJA == iSWDNvpsUMPLKHvHHpHbIawpGErjA.WindowsGamingInput)
					{
						wcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu = null;
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
		zfJomXWLxtsqXBlpWChrUqVSwcRI = true;
		hHEvmYXLOqUuPxulawyLOLkjoShc = new eUrAgsjqJfMgSXdyOYmUuVkSKlAgA();
		for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
		{
			ejgpaCMxKykgQuwCwIRAcLDneTNU[i].Initialize();
		}
	}

	public virtual void AIFwdKeFwAzkdoFxZdJNGqWFmLep(UpdateLoopType P_0)
	{
		for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
		{
			ejgpaCMxKykgQuwCwIRAcLDneTNU[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = ejgpaCMxKykgQuwCwIRAcLDneTNU.Count - 1; num >= 0; num--)
		{
			ejgpaCMxKykgQuwCwIRAcLDneTNU[num].OnDestroy();
		}
		ejgpaCMxKykgQuwCwIRAcLDneTNU.Clear();
		if (ZLAgCfQxmckeqZfVyaqsSEfMBCwh != null)
		{
			ZLAgCfQxmckeqZfVyaqsSEfMBCwh.anYYivuBGViQIiBeRknyYeFbTRik();
			ZLAgCfQxmckeqZfVyaqsSEfMBCwh = null;
		}
		WNDYrcPDOUObmqnBCmqijYTVsDhn.dQYgavNEvoJDZEMfULixAHPMzaFi();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return nsiOZhhvSpgIYruaJnMeepXyDeV;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		ejgpaCMxKykgQuwCwIRAcLDneTNU.GetValue((int)data.source).UpdateControllerData(hHEvmYXLOqUuPxulawyLOLkjoShc.ZtMWKHWiPENIqbxzdepyVBGksODh(controllerId, data.source, eUrAgsjqJfMgSXdyOYmUuVkSKlAgA.nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected), data);
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
		for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = ejgpaCMxKykgQuwCwIRAcLDneTNU[i].GetUnifiedMouseSource();
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
		for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = ejgpaCMxKykgQuwCwIRAcLDneTNU[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void UdUkBtCgyHUrHceAtFxycSCRcxebb(BridgedController P_0)
	{
		if (P_0 != null)
		{
			hHEvmYXLOqUuPxulawyLOLkjoShc.tHSWlsZyDmOaCdiNdJBehfowGMXj(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void YUIUhjuovHBpcoauyEElcUzEBkJMA(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			hHEvmYXLOqUuPxulawyLOLkjoShc.OAOqWwOrqtdEvUDHJxJmdTOFkkgP(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void DbMJbTrAakBwSqqjkiqPrhdDPFTl(EventArgs P_0)
	{
		if (zfJomXWLxtsqXBlpWChrUqVSwcRI)
		{
			for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
			{
				ejgpaCMxKykgQuwCwIRAcLDneTNU[i].SystemDeviceConnected();
			}
		}
	}

	private void lJapHwcXdEmXzVBtILTBUQYtEGBHA(EventArgs P_0)
	{
		if (zfJomXWLxtsqXBlpWChrUqVSwcRI)
		{
			for (int i = 0; i < ejgpaCMxKykgQuwCwIRAcLDneTNU.Count; i++)
			{
				ejgpaCMxKykgQuwCwIRAcLDneTNU[i].SystemDeviceDisconnected();
			}
		}
	}

	private void hmQQJDEsSEckCRjVzCaGIntmCIeh(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		hHEvmYXLOqUuPxulawyLOLkjoShc.gBOcXwBABNPvUXRtWbzOARnHcsIy(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		eUrAgsjqJfMgSXdyOYmUuVkSKlAgA.nNLJiPTgIrHVOfkkRmHEIlxcNaHz nNLJiPTgIrHVOfkkRmHEIlxcNaHz = eUrAgsjqJfMgSXdyOYmUuVkSKlAgA.nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Connected;
		int num = hHEvmYXLOqUuPxulawyLOLkjoShc.BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0.sourceJoystick.rewiredId, nNLJiPTgIrHVOfkkRmHEIlxcNaHz);
		if (num < 0)
		{
			nNLJiPTgIrHVOfkkRmHEIlxcNaHz = eUrAgsjqJfMgSXdyOYmUuVkSKlAgA.nNLJiPTgIrHVOfkkRmHEIlxcNaHz.Disconnected;
			num = hHEvmYXLOqUuPxulawyLOLkjoShc.BGGygZzhpgDmRUcXgdZoYMtuwKaT(P_0.sourceJoystick.rewiredId, nNLJiPTgIrHVOfkkRmHEIlxcNaHz);
		}
		if (num >= 0)
		{
			eUrAgsjqJfMgSXdyOYmUuVkSKlAgA.uAKhPeMZXCItOXzgkPuznjJHZRCr uAKhPeMZXCItOXzgkPuznjJHZRCr = hHEvmYXLOqUuPxulawyLOLkjoShc.QZRCFEfSxSewrvmXdPagnpJpdpRBA(num, nNLJiPTgIrHVOfkkRmHEIlxcNaHz);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new xOMDMeVbpdCCWfFlnaNufjGMHMIVA(P_0.sourceJoystick, uAKhPeMZXCItOXzgkPuznjJHZRCr.XnydYMdrZaxnhWnBmtnaICLZQjES)));
			}
		}
	}
}
