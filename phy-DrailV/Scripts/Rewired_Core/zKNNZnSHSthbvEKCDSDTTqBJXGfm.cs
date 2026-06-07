using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class zKNNZnSHSthbvEKCDSDTTqBJXGfm
{
	private int CkQqkOTUNpodOKsmeqsAdBSEcsCkA;

	private int SfELawDMMQgrBEuVGegeqjtGpbQh;

	private Player FuhzBwMsPVqVfmcWaPJfrdJbjMwDA;

	private Player[] rdhfGnjxQcgZlAUqFhIFbapnNYKTA;

	private Player[] sgTgSbAVzjDCDmoCKKXRcOxEFiCPB;

	private IList<Player> uHygMmVjFXgJtcVrGjwvcZyPYJLk;

	private IList<Player> vTsaAHIHjNYbxiPFWlNcGfXhzkPjB;

	private ConfigVars DMXabkqQUJPnibCwPIPncbvzMVgD;

	private bool DlyzgeEtPbGSRivIvEmZhBSIEqiU;

	public int kLtKHYOKyHabTdaYNJSDSbiURQrCA => CkQqkOTUNpodOKsmeqsAdBSEcsCkA;

	public int TmZgxqdxZNPOJEXaGaspgkRVmNTg => SfELawDMMQgrBEuVGegeqjtGpbQh;

	public Player[] fxZfvknkcbAODIobmbPnsRZAgxtg => rdhfGnjxQcgZlAUqFhIFbapnNYKTA;

	public Player[] lHbfkpyWIowAIkuHlIjyOnmSjjyP => sgTgSbAVzjDCDmoCKKXRcOxEFiCPB;

	public IList<Player> qocjBrREVEKPmUknGfrCijxNqmDi => vTsaAHIHjNYbxiPFWlNcGfXhzkPjB;

	public IList<Player> yhcwtnieSsbrJKctPqNEcbZsdLgXA => uHygMmVjFXgJtcVrGjwvcZyPYJLk;

	public zKNNZnSHSthbvEKCDSDTTqBJXGfm(ConfigVars P_0)
	{
		DMXabkqQUJPnibCwPIPncbvzMVgD = P_0;
	}

	public void TlzckGoQDITHcUYaslQXPQBOhTwq()
	{
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			return;
		}
		SfELawDMMQgrBEuVGegeqjtGpbQh = ReInput.UserData.playerCount;
		CkQqkOTUNpodOKsmeqsAdBSEcsCkA = SfELawDMMQgrBEuVGegeqjtGpbQh - 1;
		sgTgSbAVzjDCDmoCKKXRcOxEFiCPB = new Player[CkQqkOTUNpodOKsmeqsAdBSEcsCkA];
		rdhfGnjxQcgZlAUqFhIFbapnNYKTA = new Player[SfELawDMMQgrBEuVGegeqjtGpbQh];
		IList<Player_Editor> list = ReInput.UserData.yhcwtnieSsbrJKctPqNEcbZsdLgXA;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			WWVuXrRYVOzShWUocNjzkxVTwGrG wWVuXrRYVOzShWUocNjzkxVTwGrG = player_Editor.JWdnIGZSohotIgnIhATKypsQkaCP();
			ControllerMapLayoutManager.QMsaCCjejTLLpcQRJGrdNeitKrRP qMsaCCjejTLLpcQRJGrdNeitKrRP = player_Editor.controllerMapLayoutManagerSettings.MWrElALuoTPPAYbLsGATPtERRDZH();
			ControllerMapEnabler.KiSiAESwVlRDyuCSgIKOzduAyJHX kiSiAESwVlRDyuCSgIKOzduAyJHX = player_Editor.controllerMapEnablerSettings.MWrElALuoTPPAYbLsGATPtERRDZH();
			Player player;
			if (i == 0)
			{
				player = (FuhzBwMsPVqVfmcWaPJfrdJbjMwDA = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, wWVuXrRYVOzShWUocNjzkxVTwGrG, qMsaCCjejTLLpcQRJGrdNeitKrRP, kiSiAESwVlRDyuCSgIKOzduAyJHX));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, wWVuXrRYVOzShWUocNjzkxVTwGrG, qMsaCCjejTLLpcQRJGrdNeitKrRP, kiSiAESwVlRDyuCSgIKOzduAyJHX);
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i - 1] = player;
			}
			rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.OGNeQCaKpeqbbqjCSYcDrdGrhVAeA(true);
			player.controllers.maps.ZdYVXGfaJcxnvYPSYdyByenJrdzL(true);
		}
		uHygMmVjFXgJtcVrGjwvcZyPYJLk = new ReadOnlyCollection<Player>(sgTgSbAVzjDCDmoCKKXRcOxEFiCPB);
		vTsaAHIHjNYbxiPFWlNcGfXhzkPjB = new ReadOnlyCollection<Player>(rdhfGnjxQcgZlAUqFhIFbapnNYKTA);
		DlyzgeEtPbGSRivIvEmZhBSIEqiU = true;
	}

	public void kdhtvwuLfWpGpQsmdwQRdufkKFHB(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!DMXabkqQUJPnibCwPIPncbvzMVgD.reassignJoystickToPreviousOwnerOnReconnect || !orTJmZwUzTObUZMvLewAcRriBPdP(P_0))
		{
			kyJdFONLzCMPUHpOqJoejcclPipK(P_0);
		}
	}

	public void TEpNMPEPLAJUavBzbyUbFVjQrNHh(Joystick P_0)
	{
		if (DMXabkqQUJPnibCwPIPncbvzMVgD.autoAssignJoysticks)
		{
			kdhtvwuLfWpGpQsmdwQRdufkKFHB(P_0);
		}
	}

	public void SYypCjrRtkGujTdFrBIywpGgaLcq(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < SfELawDMMQgrBEuVGegeqjtGpbQh; i++)
		{
			rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player GMfdPhKaTGGvREtYKUxukZZFdgrwA(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= CkQqkOTUNpodOKsmeqsAdBSEcsCkA))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return FuhzBwMsPVqVfmcWaPJfrdJbjMwDA;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			if (sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].id == P_0)
			{
				return sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[P_0];
			}
		}
		return null;
	}

	public Player GMfdPhKaTGGvREtYKUxukZZFdgrwA(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return FuhzBwMsPVqVfmcWaPJfrdJbjMwDA;
			}
			for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
			{
				if (sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player POqlaIweLUrFjDIOnEPRqRFLSGgs()
	{
		return FuhzBwMsPVqVfmcWaPJfrdJbjMwDA;
	}

	public int ljBCLXLZvMpyQrsTGkOKKJMMeoOaA(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			if (sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].id;
			}
		}
		return -1;
	}

	public bool PewwNLbwpvegjTYkSPjCBkENpnkB(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= CkQqkOTUNpodOKsmeqsAdBSEcsCkA))
		{
			return false;
		}
		return true;
	}

	public Player[] sTMdNPbszkkvXQhWGcnARFEdHTEF(bool P_0)
	{
		int num = CkQqkOTUNpodOKsmeqsAdBSEcsCkA;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = FuhzBwMsPVqVfmcWaPJfrdJbjMwDA;
			num2 = 1;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			array[num2 + i] = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i];
		}
		return array;
	}

	public string[] wlgfVPGuuPhYVDNTFEmYdtNSKipBB(bool P_0)
	{
		int num = CkQqkOTUNpodOKsmeqsAdBSEcsCkA;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.name;
			num2 = 1;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			array[num2 + i] = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].name;
		}
		return array;
	}

	public string[] ubvURaEZsshLIcHfwxVhNBJbHyQP(bool P_0)
	{
		int num = CkQqkOTUNpodOKsmeqsAdBSEcsCkA;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			array[num2 + i] = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].descriptiveName;
		}
		return array;
	}

	public int[] kNkBNvbiJxqLsbIwflCouZakIqsfc(bool P_0)
	{
		int num = CkQqkOTUNpodOKsmeqsAdBSEcsCkA;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.id;
			num2 = 1;
		}
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			array[num2 + i] = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].id;
		}
		return array;
	}

	public bool fmTBCgEAQIZMRJZgfloQKZgrGjIVA(Controller P_0)
	{
		if (P_0 == null || rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		return fmTBCgEAQIZMRJZgfloQKZgrGjIVA(P_0.type, P_0.id);
	}

	public bool fmTBCgEAQIZMRJZgfloQKZgrGjIVA(ControllerType P_0, int P_1)
	{
		if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		for (int i = 0; i < rdhfGnjxQcgZlAUqFhIFbapnNYKTA.Length; i++)
		{
			if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool AkAfZLHbVwotEGeNcRQmGJOwQqwKc(ControllerType P_0, int P_1, int P_2)
	{
		return GMfdPhKaTGGvREtYKUxukZZFdgrwA(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void dFUzutxeEjoEHoWONFDUTGeOVtqm(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
			{
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void dFUzutxeEjoEHoWONFDUTGeOVtqm(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			dFUzutxeEjoEHoWONFDUTGeOVtqm(controller, P_2);
		}
	}

	public bool DVbirfzaWgaTTGRXTgCeaotBMFlCA(Joystick P_0)
	{
		if (P_0 == null || rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		for (int i = 0; i < rdhfGnjxQcgZlAUqFhIFbapnNYKTA.Length; i++)
		{
			if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool DVbirfzaWgaTTGRXTgCeaotBMFlCA(int P_0)
	{
		if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		for (int i = 0; i < rdhfGnjxQcgZlAUqFhIFbapnNYKTA.Length; i++)
		{
			if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool zZGPkOEHSlYETjpDuIDVCHfGrctE(int P_0, int P_1)
	{
		return GMfdPhKaTGGvREtYKUxukZZFdgrwA(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void tAOdQTZUCMxRxSLQvehqeJEyMHEx(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.controllers.acqHFXgWWsCzAizcMtRVoFtwGOcb(P_0);
			}
			for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
			{
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].controllers.acqHFXgWWsCzAizcMtRVoFtwGOcb(P_0);
			}
		}
	}

	public void tAOdQTZUCMxRxSLQvehqeJEyMHEx(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			tAOdQTZUCMxRxSLQvehqeJEyMHEx(joystick, P_1);
		}
	}

	public bool AKXsKWmQTCjETHKbbJaLFtQtRLbEA(CustomController P_0)
	{
		if (P_0 == null || rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		for (int i = 0; i < rdhfGnjxQcgZlAUqFhIFbapnNYKTA.Length; i++)
		{
			if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool AKXsKWmQTCjETHKbbJaLFtQtRLbEA(int P_0)
	{
		if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA == null)
		{
			return false;
		}
		for (int i = 0; i < rdhfGnjxQcgZlAUqFhIFbapnNYKTA.Length; i++)
		{
			if (rdhfGnjxQcgZlAUqFhIFbapnNYKTA[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool FhvRHoZutIqnJUIHhcBMxRTuOlWj(int P_0, int P_1)
	{
		return GMfdPhKaTGGvREtYKUxukZZFdgrwA(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void gNZuXyEeHYpuhhPwYboZmzyuMWLb(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				FuhzBwMsPVqVfmcWaPJfrdJbjMwDA.controllers.YpPprTyCjXINuDdRSIPPjCHwrQiRA(P_0);
			}
			for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
			{
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i].controllers.YpPprTyCjXINuDdRSIPPjCHwrQiRA(P_0);
			}
		}
	}

	public void gNZuXyEeHYpuhhPwYboZmzyuMWLb(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			gNZuXyEeHYpuhhPwYboZmzyuMWLb(customController, P_1);
		}
	}

	private bool orTJmZwUzTObUZMvLewAcRriBPdP(Joystick P_0)
	{
		if (DMXabkqQUJPnibCwPIPncbvzMVgD.distributeJoysticksEvenly)
		{
			int num = MjplHZzttPcthgESjecjcWwoDwHIA();
			if (num < 0)
			{
				return false;
			}
			int num2 = YwjNtnIKNBYXGguBEMWhqRLviKKs(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[num];
			Player player2 = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[num2].controllers.OXDLUVEiAffTyVMkdFIAAbfqttALA(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = YwjNtnIKNBYXGguBEMWhqRLviKKs(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[num3].controllers.OXDLUVEiAffTyVMkdFIAAbfqttALA(P_0, true);
		return true;
	}

	private bool kyJdFONLzCMPUHpOqJoejcclPipK(Joystick P_0)
	{
		if (DMXabkqQUJPnibCwPIPncbvzMVgD.distributeJoysticksEvenly)
		{
			int num = MjplHZzttPcthgESjecjcWwoDwHIA();
			if (num >= 0)
			{
				sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[num].controllers.OXDLUVEiAffTyVMkdFIAAbfqttALA(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
			{
				Player player = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!DMXabkqQUJPnibCwPIPncbvzMVgD.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < DMXabkqQUJPnibCwPIPncbvzMVgD.maxJoysticksPerPlayer)
				{
					player.controllers.OXDLUVEiAffTyVMkdFIAAbfqttALA(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int MjplHZzttPcthgESjecjcWwoDwHIA()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			Player player = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!DMXabkqQUJPnibCwPIPncbvzMVgD.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < DMXabkqQUJPnibCwPIPncbvzMVgD.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int YwjNtnIKNBYXGguBEMWhqRLviKKs(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < CkQqkOTUNpodOKsmeqsAdBSEcsCkA; i++)
		{
			Player player = sgTgSbAVzjDCDmoCKKXRcOxEFiCPB[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!DMXabkqQUJPnibCwPIPncbvzMVgD.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < DMXabkqQUJPnibCwPIPncbvzMVgD.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.GZEcbVtzbDdmPovWgthqUjFayzlm(P_0);
				if (!(num3 < 0.0) && (num < 0 || num3 > num2))
				{
					num2 = num3;
					num = i;
				}
			}
		}
		return num;
	}
}
