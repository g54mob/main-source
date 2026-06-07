using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class msekTewPMCDuklrYGYDofSmhfOLW
{
	private int FecgIiGZSbfaqTlViEnQFzvJJJZL;

	private int XQnQqPBBckMksskyzxEANPopDCeE;

	private Player EpQiJQfjFieZlqqMucUKKaHPDYDk;

	private Player[] lklElfWuGImKNWSxOomoiDAabcDp;

	private Player[] TtbAyEFoSBwyGNNdknrHwzwChoNi;

	private IList<Player> SWLzlrEiugAXFKWFIRIKqKupFLYeA;

	private IList<Player> UKKyigsQgaIphZswRBtQHbVbjsjo;

	private ConfigVars OUXqoXdTrGbBhKsOjWhlKfpvbcWS;

	private bool NtHclsjREiTltIVjeBPGeAPGxuRt;

	public int UJTUqhYGWFaEOAtpDKAOMicqQsWF => FecgIiGZSbfaqTlViEnQFzvJJJZL;

	public int uUlAdkTrrGmeatOJXDQKcoxXeSHs => XQnQqPBBckMksskyzxEANPopDCeE;

	public Player[] NgmgAgHubQJNcfshkZPYpCFVWTBJB => lklElfWuGImKNWSxOomoiDAabcDp;

	public Player[] CLRvmHDqKULeIoFAmoISFEsSaXTQ => TtbAyEFoSBwyGNNdknrHwzwChoNi;

	public IList<Player> LgeEoisNbkWVEtfiDwUoWAbPysPR => UKKyigsQgaIphZswRBtQHbVbjsjo;

	public IList<Player> kXxcetKhlgDvETXoPvvQXNPCzSTG => SWLzlrEiugAXFKWFIRIKqKupFLYeA;

	public msekTewPMCDuklrYGYDofSmhfOLW(ConfigVars P_0)
	{
		OUXqoXdTrGbBhKsOjWhlKfpvbcWS = P_0;
	}

	public void yAiJybyDrkVhPlGUzbHLIsXFkuuR()
	{
		if (NtHclsjREiTltIVjeBPGeAPGxuRt)
		{
			return;
		}
		XQnQqPBBckMksskyzxEANPopDCeE = ReInput.UserData.playerCount;
		FecgIiGZSbfaqTlViEnQFzvJJJZL = XQnQqPBBckMksskyzxEANPopDCeE - 1;
		TtbAyEFoSBwyGNNdknrHwzwChoNi = new Player[FecgIiGZSbfaqTlViEnQFzvJJJZL];
		lklElfWuGImKNWSxOomoiDAabcDp = new Player[XQnQqPBBckMksskyzxEANPopDCeE];
		IList<Player_Editor> list = ReInput.UserData.WhOmmIcRUFeHIqIDYZllQSPokJqb;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			FGaEqsabChAigPfOzNCChKOtJbXxA fGaEqsabChAigPfOzNCChKOtJbXxA = player_Editor.jAGUcWZdDYhJuerIylmhaZqDsyaJA();
			ControllerMapLayoutManager.LGBrMNZdvgtEkBpNABJGpIHRtmbV lGBrMNZdvgtEkBpNABJGpIHRtmbV = player_Editor.controllerMapLayoutManagerSettings.BdbyLyimaLktAJckULbHyhCfeeTU();
			ControllerMapEnabler.ZppkwHkpXIKClTnElCTrJXPsNYtW zppkwHkpXIKClTnElCTrJXPsNYtW = player_Editor.controllerMapEnablerSettings.DJOasPLeyDqbOYPVfkSYZrrYQdbU();
			Player player;
			if (i == 0)
			{
				player = (EpQiJQfjFieZlqqMucUKKaHPDYDk = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, fGaEqsabChAigPfOzNCChKOtJbXxA, lGBrMNZdvgtEkBpNABJGpIHRtmbV, zppkwHkpXIKClTnElCTrJXPsNYtW));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, fGaEqsabChAigPfOzNCChKOtJbXxA, lGBrMNZdvgtEkBpNABJGpIHRtmbV, zppkwHkpXIKClTnElCTrJXPsNYtW);
				TtbAyEFoSBwyGNNdknrHwzwChoNi[i - 1] = player;
			}
			lklElfWuGImKNWSxOomoiDAabcDp[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.PHrCsrQbySgaJgoPTrVydHoSzKVqA(true);
			player.controllers.maps.FkItCCpSIQXMpguYktGhpYJfkWWg(true);
		}
		SWLzlrEiugAXFKWFIRIKqKupFLYeA = new ReadOnlyCollection<Player>(TtbAyEFoSBwyGNNdknrHwzwChoNi);
		UKKyigsQgaIphZswRBtQHbVbjsjo = new ReadOnlyCollection<Player>(lklElfWuGImKNWSxOomoiDAabcDp);
		NtHclsjREiTltIVjeBPGeAPGxuRt = true;
	}

	public void nejjbnhTtxZEBIEhoUYDuTQguDdn(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!OUXqoXdTrGbBhKsOjWhlKfpvbcWS.reassignJoystickToPreviousOwnerOnReconnect || !XNYESCVGGhBQRIwaotIPwvMvIEKxA(P_0))
		{
			FRwGwVNJIeTJujsYlUcCYHedroJi(P_0);
		}
	}

	public void UINXRmiKSWCitDCAPLlzcdFvhNSeA(Joystick P_0)
	{
		if (OUXqoXdTrGbBhKsOjWhlKfpvbcWS.autoAssignJoysticks)
		{
			nejjbnhTtxZEBIEhoUYDuTQguDdn(P_0);
		}
	}

	public void WOAYxuoAOtJKAgsypnLBGESablou(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < XQnQqPBBckMksskyzxEANPopDCeE; i++)
		{
			lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player MgIIdYJCmureJBUYamqZmJEeOVwP(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= FecgIiGZSbfaqTlViEnQFzvJJJZL))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return EpQiJQfjFieZlqqMucUKKaHPDYDk;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			if (TtbAyEFoSBwyGNNdknrHwzwChoNi[i].id == P_0)
			{
				return TtbAyEFoSBwyGNNdknrHwzwChoNi[P_0];
			}
		}
		return null;
	}

	public Player cKIQrJlTSQyJxdaOmUakiQMlyXrI(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (EpQiJQfjFieZlqqMucUKKaHPDYDk.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return EpQiJQfjFieZlqqMucUKKaHPDYDk;
			}
			for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
			{
				if (TtbAyEFoSBwyGNNdknrHwzwChoNi[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return TtbAyEFoSBwyGNNdknrHwzwChoNi[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player TwkaSnHIHKDqhuSmBQQQfkiEADGX()
	{
		return EpQiJQfjFieZlqqMucUKKaHPDYDk;
	}

	public int NmWlsBDGCCjSySvifsukqnZccEFi(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (EpQiJQfjFieZlqqMucUKKaHPDYDk.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			if (TtbAyEFoSBwyGNNdknrHwzwChoNi[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return TtbAyEFoSBwyGNNdknrHwzwChoNi[i].id;
			}
		}
		return -1;
	}

	public bool UgiMDeTxuuKNnOzpnMPfmqCKEXgM(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= FecgIiGZSbfaqTlViEnQFzvJJJZL))
		{
			return false;
		}
		return true;
	}

	public Player[] MqLupPFDEvBgZQbLneFFmkUIEhZb(bool P_0)
	{
		int num = FecgIiGZSbfaqTlViEnQFzvJJJZL;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = EpQiJQfjFieZlqqMucUKKaHPDYDk;
			num2 = 1;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			array[num2 + i] = TtbAyEFoSBwyGNNdknrHwzwChoNi[i];
		}
		return array;
	}

	public string[] HCguGDKyERYuSUpnESAcSAexYAGd(bool P_0)
	{
		int num = FecgIiGZSbfaqTlViEnQFzvJJJZL;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = EpQiJQfjFieZlqqMucUKKaHPDYDk.name;
			num2 = 1;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			array[num2 + i] = TtbAyEFoSBwyGNNdknrHwzwChoNi[i].name;
		}
		return array;
	}

	public string[] kNWmYvJkJdrbWmDsqFqMuUdRCESX(bool P_0)
	{
		int num = FecgIiGZSbfaqTlViEnQFzvJJJZL;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = EpQiJQfjFieZlqqMucUKKaHPDYDk.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			array[num2 + i] = TtbAyEFoSBwyGNNdknrHwzwChoNi[i].descriptiveName;
		}
		return array;
	}

	public int[] QmbdcXyflSrRYeHXZKOQwISqcxvr(bool P_0)
	{
		int num = FecgIiGZSbfaqTlViEnQFzvJJJZL;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = EpQiJQfjFieZlqqMucUKKaHPDYDk.id;
			num2 = 1;
		}
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			array[num2 + i] = TtbAyEFoSBwyGNNdknrHwzwChoNi[i].id;
		}
		return array;
	}

	public bool dnXYozCQzzGGsGZwBZkgMNVaJBIz(Controller P_0)
	{
		if (P_0 == null || lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		return QSNsQfKqxGlslWBTKhCtKRRAbwmq(P_0.type, P_0.id);
	}

	public bool QSNsQfKqxGlslWBTKhCtKRRAbwmq(ControllerType P_0, int P_1)
	{
		if (lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		for (int i = 0; i < lklElfWuGImKNWSxOomoiDAabcDp.Length; i++)
		{
			if (lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool FzkcmWYkRYBsUYsUAsdnxJNvIQyU(ControllerType P_0, int P_1, int P_2)
	{
		return MgIIdYJCmureJBUYamqZmJEeOVwP(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void EkRjCRGMcAayxuyhglCPYkYwYIjR(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				EpQiJQfjFieZlqqMucUKKaHPDYDk.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
			{
				TtbAyEFoSBwyGNNdknrHwzwChoNi[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void ECNcYoeNBNwNbDqokpibCGDYuiUf(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			EkRjCRGMcAayxuyhglCPYkYwYIjR(controller, P_2);
		}
	}

	public bool bgNYuDvpHpIouWcRmuUySlZGFrUGA(Joystick P_0)
	{
		if (P_0 == null || lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		for (int i = 0; i < lklElfWuGImKNWSxOomoiDAabcDp.Length; i++)
		{
			if (lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool JiChqYZJQsWCijZpretnJjzWEQwjA(int P_0)
	{
		if (lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		for (int i = 0; i < lklElfWuGImKNWSxOomoiDAabcDp.Length; i++)
		{
			if (lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool OfjejBNfKuuDscFFQzVFnYhALSUy(int P_0, int P_1)
	{
		return MgIIdYJCmureJBUYamqZmJEeOVwP(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void LXqftQFkRqxJSvypWNCZIaOGAFotA(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				EpQiJQfjFieZlqqMucUKKaHPDYDk.controllers.XlhpsUFMcRPoOyGhZKitXyTxQmsU(P_0);
			}
			for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
			{
				TtbAyEFoSBwyGNNdknrHwzwChoNi[i].controllers.XlhpsUFMcRPoOyGhZKitXyTxQmsU(P_0);
			}
		}
	}

	public void FrrkTpOHtAsPOFEZuDfzfkiSChUX(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			LXqftQFkRqxJSvypWNCZIaOGAFotA(joystick, P_1);
		}
	}

	public bool bgnWmADipMaDdUcVEqOxQgzzuEpB(CustomController P_0)
	{
		if (P_0 == null || lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		for (int i = 0; i < lklElfWuGImKNWSxOomoiDAabcDp.Length; i++)
		{
			if (lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool rXawwoUkoBTOkvwaLYPRLMoWDjnm(int P_0)
	{
		if (lklElfWuGImKNWSxOomoiDAabcDp == null)
		{
			return false;
		}
		for (int i = 0; i < lklElfWuGImKNWSxOomoiDAabcDp.Length; i++)
		{
			if (lklElfWuGImKNWSxOomoiDAabcDp[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool bTjkZEVNxHzpZCKQwbQZJQszyHgb(int P_0, int P_1)
	{
		return MgIIdYJCmureJBUYamqZmJEeOVwP(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void aguhapBMrWorAazyRMQdhHtXZuCaA(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				EpQiJQfjFieZlqqMucUKKaHPDYDk.controllers.nmWYJXdDOFaYTdfPaMyVuplNdRBw(P_0);
			}
			for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
			{
				TtbAyEFoSBwyGNNdknrHwzwChoNi[i].controllers.nmWYJXdDOFaYTdfPaMyVuplNdRBw(P_0);
			}
		}
	}

	public void qXaTpivpuSDJRppEzPBIKwxQzBxl(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			aguhapBMrWorAazyRMQdhHtXZuCaA(customController, P_1);
		}
	}

	private bool XNYESCVGGhBQRIwaotIPwvMvIEKxA(Joystick P_0)
	{
		if (OUXqoXdTrGbBhKsOjWhlKfpvbcWS.distributeJoysticksEvenly)
		{
			int num = oOAgaOFcRuZLlJAxVLiAQrivesvp();
			if (num < 0)
			{
				return false;
			}
			int num2 = PQaxszRhInIkflbMQehijHMIMKkb(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = TtbAyEFoSBwyGNNdknrHwzwChoNi[num];
			Player player2 = TtbAyEFoSBwyGNNdknrHwzwChoNi[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				TtbAyEFoSBwyGNNdknrHwzwChoNi[num2].controllers.sCIFHToWfQnhEAfArrKPFMLckxRK(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = PQaxszRhInIkflbMQehijHMIMKkb(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		TtbAyEFoSBwyGNNdknrHwzwChoNi[num3].controllers.sCIFHToWfQnhEAfArrKPFMLckxRK(P_0, true);
		return true;
	}

	private bool FRwGwVNJIeTJujsYlUcCYHedroJi(Joystick P_0)
	{
		if (OUXqoXdTrGbBhKsOjWhlKfpvbcWS.distributeJoysticksEvenly)
		{
			int num = oOAgaOFcRuZLlJAxVLiAQrivesvp();
			if (num >= 0)
			{
				TtbAyEFoSBwyGNNdknrHwzwChoNi[num].controllers.sCIFHToWfQnhEAfArrKPFMLckxRK(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
			{
				Player player = TtbAyEFoSBwyGNNdknrHwzwChoNi[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!OUXqoXdTrGbBhKsOjWhlKfpvbcWS.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < OUXqoXdTrGbBhKsOjWhlKfpvbcWS.maxJoysticksPerPlayer)
				{
					player.controllers.sCIFHToWfQnhEAfArrKPFMLckxRK(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int oOAgaOFcRuZLlJAxVLiAQrivesvp()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			Player player = TtbAyEFoSBwyGNNdknrHwzwChoNi[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!OUXqoXdTrGbBhKsOjWhlKfpvbcWS.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < OUXqoXdTrGbBhKsOjWhlKfpvbcWS.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int PQaxszRhInIkflbMQehijHMIMKkb(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < FecgIiGZSbfaqTlViEnQFzvJJJZL; i++)
		{
			Player player = TtbAyEFoSBwyGNNdknrHwzwChoNi[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!OUXqoXdTrGbBhKsOjWhlKfpvbcWS.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < OUXqoXdTrGbBhKsOjWhlKfpvbcWS.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.lLSxpTRMcNgXMYtOMTfcsVDWpGpX(P_0);
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
