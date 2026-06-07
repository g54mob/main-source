using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class OHBxQeqzwpSOXtKiahobKGuCdFjeb
{
	private int lAEvfBxUzhWCkfdCZIumoFpPCaMS;

	private int bcSWSrxQqAQRddZYnsUKboYThrKL;

	private Player oxxAKpevlZkqDVAmJnLJicomhKym;

	private Player[] UTtCFkJccunmDfkEoCqljrCqLCQbb;

	private Player[] BxHBHebjXjptbFFylGfbNVUMCoGBA;

	private IList<Player> LEgCxtdSlBzyFBODvPYNlUVALEXw;

	private IList<Player> CKcARCltXFuCVuLdtwdAeNyuRaXu;

	private ConfigVars ojFvlpKzaZHmKUfEuuuNjYOwvQoW;

	private bool qumTafanxrjKbDduWdypwIzXqmiP;

	public int DpfYFosOsNWtCFkziqdksZeTEArD => lAEvfBxUzhWCkfdCZIumoFpPCaMS;

	public int gHasbnHhBBqxrnCldOFuzaEkoPaA => bcSWSrxQqAQRddZYnsUKboYThrKL;

	public Player[] EGPTipDFMnhdxCrFBVHXCjgFzgpaA => UTtCFkJccunmDfkEoCqljrCqLCQbb;

	public Player[] WtobyiAcccrasNfUwVICLZaJveRb => BxHBHebjXjptbFFylGfbNVUMCoGBA;

	public IList<Player> LlmRwqxmzAqpUhaVpsDevbYYcmRZ => CKcARCltXFuCVuLdtwdAeNyuRaXu;

	public IList<Player> JKsoUwCAgkKhpVANcbhaqhyjGJigA => LEgCxtdSlBzyFBODvPYNlUVALEXw;

	public OHBxQeqzwpSOXtKiahobKGuCdFjeb(ConfigVars P_0)
	{
		ojFvlpKzaZHmKUfEuuuNjYOwvQoW = P_0;
	}

	public void gUxczTgMdKUcYRnCXamteWaCXJodc()
	{
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			return;
		}
		bcSWSrxQqAQRddZYnsUKboYThrKL = ReInput.UserData.playerCount;
		lAEvfBxUzhWCkfdCZIumoFpPCaMS = bcSWSrxQqAQRddZYnsUKboYThrKL - 1;
		BxHBHebjXjptbFFylGfbNVUMCoGBA = new Player[lAEvfBxUzhWCkfdCZIumoFpPCaMS];
		UTtCFkJccunmDfkEoCqljrCqLCQbb = new Player[bcSWSrxQqAQRddZYnsUKboYThrKL];
		IList<Player_Editor> list = ReInput.UserData.JKsoUwCAgkKhpVANcbhaqhyjGJigA;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			rTFRhglKgUYuRjbuHfpVdAGUmulr rTFRhglKgUYuRjbuHfpVdAGUmulr2 = player_Editor.qnhFaJbEXxChcZiwGfOafxXBabSK();
			ControllerMapLayoutManager.nwmaXXBRLHdsFSHrcaeHCCJdihJCc nwmaXXBRLHdsFSHrcaeHCCJdihJCc = player_Editor.controllerMapLayoutManagerSettings.vtjZXZpyCBGschetPSgbKdzUOHNT();
			ControllerMapEnabler.bfKxbNaTbdokMFkgReyogCBTNRVl bfKxbNaTbdokMFkgReyogCBTNRVl = player_Editor.controllerMapEnablerSettings.vtjZXZpyCBGschetPSgbKdzUOHNT();
			Player player;
			if (i == 0)
			{
				player = (oxxAKpevlZkqDVAmJnLJicomhKym = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, rTFRhglKgUYuRjbuHfpVdAGUmulr2, nwmaXXBRLHdsFSHrcaeHCCJdihJCc, bfKxbNaTbdokMFkgReyogCBTNRVl));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, rTFRhglKgUYuRjbuHfpVdAGUmulr2, nwmaXXBRLHdsFSHrcaeHCCJdihJCc, bfKxbNaTbdokMFkgReyogCBTNRVl);
				BxHBHebjXjptbFFylGfbNVUMCoGBA[i - 1] = player;
			}
			UTtCFkJccunmDfkEoCqljrCqLCQbb[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.bFNXZgUNgqMRHForlQjFsvWmTYtb(true);
			player.controllers.maps.kaIWKFDTncvOVzfylELjBtYAKxzWA(true);
		}
		LEgCxtdSlBzyFBODvPYNlUVALEXw = new ReadOnlyCollection<Player>(BxHBHebjXjptbFFylGfbNVUMCoGBA);
		CKcARCltXFuCVuLdtwdAeNyuRaXu = new ReadOnlyCollection<Player>(UTtCFkJccunmDfkEoCqljrCqLCQbb);
		qumTafanxrjKbDduWdypwIzXqmiP = true;
	}

	public void ZmzfysOEnClEazlEGLYwiVNbIAJT(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!ojFvlpKzaZHmKUfEuuuNjYOwvQoW.reassignJoystickToPreviousOwnerOnReconnect || !DUNfEvABbFQoteTiQGeEbAJfHdQB(P_0))
		{
			HHBtcHvCDGXrykDuDCnIbkVmpZhVA(P_0);
		}
	}

	public void kozuOCiRpWQmCCDJQoKHCpMNlvXo(Joystick P_0)
	{
		if (ojFvlpKzaZHmKUfEuuuNjYOwvQoW.autoAssignJoysticks)
		{
			ZmzfysOEnClEazlEGLYwiVNbIAJT(P_0);
		}
	}

	public void xpgVMmFHxyxDDkbSYqwGfzQvNGmG(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < bcSWSrxQqAQRddZYnsUKboYThrKL; i++)
		{
			UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player hwddIeJafOlGvnIklCDUFMkJMsvyB(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= lAEvfBxUzhWCkfdCZIumoFpPCaMS))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return oxxAKpevlZkqDVAmJnLJicomhKym;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			if (BxHBHebjXjptbFFylGfbNVUMCoGBA[i].id == P_0)
			{
				return BxHBHebjXjptbFFylGfbNVUMCoGBA[P_0];
			}
		}
		return null;
	}

	public Player hwddIeJafOlGvnIklCDUFMkJMsvyB(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (oxxAKpevlZkqDVAmJnLJicomhKym.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return oxxAKpevlZkqDVAmJnLJicomhKym;
			}
			for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
			{
				if (BxHBHebjXjptbFFylGfbNVUMCoGBA[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return BxHBHebjXjptbFFylGfbNVUMCoGBA[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player iLesuLOztWcIVeAaALdlvBgOQKgx()
	{
		return oxxAKpevlZkqDVAmJnLJicomhKym;
	}

	public int SFRhEOjlZMRFojItbLaaaDdHTyAOB(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (oxxAKpevlZkqDVAmJnLJicomhKym.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			if (BxHBHebjXjptbFFylGfbNVUMCoGBA[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return BxHBHebjXjptbFFylGfbNVUMCoGBA[i].id;
			}
		}
		return -1;
	}

	public bool cNsfjSDHCdJDCizaZhpZMoHCdftV(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= lAEvfBxUzhWCkfdCZIumoFpPCaMS))
		{
			return false;
		}
		return true;
	}

	public Player[] NQUxwSVaLstZfnAebSCmUHxoYPWs(bool P_0)
	{
		int num = lAEvfBxUzhWCkfdCZIumoFpPCaMS;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = oxxAKpevlZkqDVAmJnLJicomhKym;
			num2 = 1;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			array[num2 + i] = BxHBHebjXjptbFFylGfbNVUMCoGBA[i];
		}
		return array;
	}

	public string[] FcqfWWYOOTTjleKzvnGcwliZKyhK(bool P_0)
	{
		int num = lAEvfBxUzhWCkfdCZIumoFpPCaMS;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = oxxAKpevlZkqDVAmJnLJicomhKym.name;
			num2 = 1;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			array[num2 + i] = BxHBHebjXjptbFFylGfbNVUMCoGBA[i].name;
		}
		return array;
	}

	public string[] VKfbXriwOizQcmHJLCVHqKcqCoEVA(bool P_0)
	{
		int num = lAEvfBxUzhWCkfdCZIumoFpPCaMS;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = oxxAKpevlZkqDVAmJnLJicomhKym.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			array[num2 + i] = BxHBHebjXjptbFFylGfbNVUMCoGBA[i].descriptiveName;
		}
		return array;
	}

	public int[] XeaCVkMGpncqGbKCMpgQIcPBRkcs(bool P_0)
	{
		int num = lAEvfBxUzhWCkfdCZIumoFpPCaMS;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = oxxAKpevlZkqDVAmJnLJicomhKym.id;
			num2 = 1;
		}
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			array[num2 + i] = BxHBHebjXjptbFFylGfbNVUMCoGBA[i].id;
		}
		return array;
	}

	public bool ICJTVnicgKIrvkHYKFEcCFPuSjKs(Controller P_0)
	{
		if (P_0 == null || UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		return ICJTVnicgKIrvkHYKFEcCFPuSjKs(P_0.type, P_0.id);
	}

	public bool ICJTVnicgKIrvkHYKFEcCFPuSjKs(ControllerType P_0, int P_1)
	{
		if (UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		for (int i = 0; i < UTtCFkJccunmDfkEoCqljrCqLCQbb.Length; i++)
		{
			if (UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool nAGfKAVMrkOAaZmrwkoAEVdHukyx(ControllerType P_0, int P_1, int P_2)
	{
		return hwddIeJafOlGvnIklCDUFMkJMsvyB(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void OwMxxwFLqfpdvTcckateEzXHSnmu(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				oxxAKpevlZkqDVAmJnLJicomhKym.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
			{
				BxHBHebjXjptbFFylGfbNVUMCoGBA[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void OwMxxwFLqfpdvTcckateEzXHSnmu(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			OwMxxwFLqfpdvTcckateEzXHSnmu(controller, P_2);
		}
	}

	public bool omraCcXcKikUzbbjmcWAxEMCLerg(Joystick P_0)
	{
		if (P_0 == null || UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		for (int i = 0; i < UTtCFkJccunmDfkEoCqljrCqLCQbb.Length; i++)
		{
			if (UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool omraCcXcKikUzbbjmcWAxEMCLerg(int P_0)
	{
		if (UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		for (int i = 0; i < UTtCFkJccunmDfkEoCqljrCqLCQbb.Length; i++)
		{
			if (UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool MjYjKBupvdYrwAPPBmcvJhuPUhjo(int P_0, int P_1)
	{
		return hwddIeJafOlGvnIklCDUFMkJMsvyB(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void CeCRRAdhwYEoDxpaYxXOdxnxmDEs(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				oxxAKpevlZkqDVAmJnLJicomhKym.controllers.BLeFCCClaKSzNNgDflPvlbiyZIQM(P_0);
			}
			for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
			{
				BxHBHebjXjptbFFylGfbNVUMCoGBA[i].controllers.BLeFCCClaKSzNNgDflPvlbiyZIQM(P_0);
			}
		}
	}

	public void CeCRRAdhwYEoDxpaYxXOdxnxmDEs(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			CeCRRAdhwYEoDxpaYxXOdxnxmDEs(joystick, P_1);
		}
	}

	public bool jbZTlFWpfSjnpyWVEGfdauhcZGnK(CustomController P_0)
	{
		if (P_0 == null || UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		for (int i = 0; i < UTtCFkJccunmDfkEoCqljrCqLCQbb.Length; i++)
		{
			if (UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool jbZTlFWpfSjnpyWVEGfdauhcZGnK(int P_0)
	{
		if (UTtCFkJccunmDfkEoCqljrCqLCQbb == null)
		{
			return false;
		}
		for (int i = 0; i < UTtCFkJccunmDfkEoCqljrCqLCQbb.Length; i++)
		{
			if (UTtCFkJccunmDfkEoCqljrCqLCQbb[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool eQrTOfnkXQRTrjzrYHIaoOuhCYOiA(int P_0, int P_1)
	{
		return hwddIeJafOlGvnIklCDUFMkJMsvyB(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void ZWVMhhuqIQBKLUkbdBRvziCfFMSHA(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				oxxAKpevlZkqDVAmJnLJicomhKym.controllers.jSFqOYETANyBAUjypvvlDmVpEDmD(P_0);
			}
			for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
			{
				BxHBHebjXjptbFFylGfbNVUMCoGBA[i].controllers.jSFqOYETANyBAUjypvvlDmVpEDmD(P_0);
			}
		}
	}

	public void ZWVMhhuqIQBKLUkbdBRvziCfFMSHA(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			ZWVMhhuqIQBKLUkbdBRvziCfFMSHA(customController, P_1);
		}
	}

	private bool DUNfEvABbFQoteTiQGeEbAJfHdQB(Joystick P_0)
	{
		if (ojFvlpKzaZHmKUfEuuuNjYOwvQoW.distributeJoysticksEvenly)
		{
			int num = zZbYsQHBjFMhFTemKQQBBDZpsyPH();
			if (num < 0)
			{
				return false;
			}
			int num2 = lnlgqqkfbTmSeZrrbotLjWowMnOi(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = BxHBHebjXjptbFFylGfbNVUMCoGBA[num];
			Player player2 = BxHBHebjXjptbFFylGfbNVUMCoGBA[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				BxHBHebjXjptbFFylGfbNVUMCoGBA[num2].controllers.zATZtKwijtiXAsAuMoaoeUTntTAC(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = lnlgqqkfbTmSeZrrbotLjWowMnOi(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		BxHBHebjXjptbFFylGfbNVUMCoGBA[num3].controllers.zATZtKwijtiXAsAuMoaoeUTntTAC(P_0, true);
		return true;
	}

	private bool HHBtcHvCDGXrykDuDCnIbkVmpZhVA(Joystick P_0)
	{
		if (ojFvlpKzaZHmKUfEuuuNjYOwvQoW.distributeJoysticksEvenly)
		{
			int num = zZbYsQHBjFMhFTemKQQBBDZpsyPH();
			if (num >= 0)
			{
				BxHBHebjXjptbFFylGfbNVUMCoGBA[num].controllers.zATZtKwijtiXAsAuMoaoeUTntTAC(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
			{
				Player player = BxHBHebjXjptbFFylGfbNVUMCoGBA[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!ojFvlpKzaZHmKUfEuuuNjYOwvQoW.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < ojFvlpKzaZHmKUfEuuuNjYOwvQoW.maxJoysticksPerPlayer)
				{
					player.controllers.zATZtKwijtiXAsAuMoaoeUTntTAC(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int zZbYsQHBjFMhFTemKQQBBDZpsyPH()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			Player player = BxHBHebjXjptbFFylGfbNVUMCoGBA[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!ojFvlpKzaZHmKUfEuuuNjYOwvQoW.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < ojFvlpKzaZHmKUfEuuuNjYOwvQoW.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int lnlgqqkfbTmSeZrrbotLjWowMnOi(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < lAEvfBxUzhWCkfdCZIumoFpPCaMS; i++)
		{
			Player player = BxHBHebjXjptbFFylGfbNVUMCoGBA[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!ojFvlpKzaZHmKUfEuuuNjYOwvQoW.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < ojFvlpKzaZHmKUfEuuuNjYOwvQoW.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.zIQGyACPBFeXjpPgLmNEBPgviprRA(P_0);
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
