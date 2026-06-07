using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class cphySyblTqRHzdCDofohJZUaAidOA
{
	private int ThbvwyPHzFYdSLQZIrFZzJKEljDb;

	private int PxyBheQWSSdmhqfzPOkDlgfsjrSl;

	private Player ELRUIWoIYINeqiYVETXDaihKQabU;

	private Player[] xGiTkzNMBsznIMJkyVRbQvmdWYhs;

	private Player[] TWymbSCQZfKFVNboKjMGHOOXNVngA;

	private IList<Player> WaYlcxDKxOmmMMEMsQlVSRQixtik;

	private IList<Player> CETJjedQjGVOcZYtrrAVjurwVOZs;

	private ConfigVars AOGbLhckLyKqCEJcFnkegFTqUpoE;

	private bool RWOkQsoeNKSDgCImIieZMcvBWYpN;

	public int QgKBkzTWRhNyHSaqnbOBoqQdimmk => ThbvwyPHzFYdSLQZIrFZzJKEljDb;

	public int mooyxmIaIkRmxhKLrtWLQNfGkXnC => PxyBheQWSSdmhqfzPOkDlgfsjrSl;

	public Player[] BJnQXsvCggAobdogrloHoqxDQfxkA => xGiTkzNMBsznIMJkyVRbQvmdWYhs;

	public Player[] KsMyqZGefwiiNqZPSAVLfkWTitjv => TWymbSCQZfKFVNboKjMGHOOXNVngA;

	public IList<Player> PMpThobquCgsRjfzpSvflwDGgSfmA => CETJjedQjGVOcZYtrrAVjurwVOZs;

	public IList<Player> yAwpzjFCiQoMTZIlbKhXnUfBNRjl => WaYlcxDKxOmmMMEMsQlVSRQixtik;

	public cphySyblTqRHzdCDofohJZUaAidOA(ConfigVars P_0)
	{
		AOGbLhckLyKqCEJcFnkegFTqUpoE = P_0;
	}

	public void kXldWpzJqMVeExiPFEkQCadSSSOxA()
	{
		if (RWOkQsoeNKSDgCImIieZMcvBWYpN)
		{
			return;
		}
		PxyBheQWSSdmhqfzPOkDlgfsjrSl = ReInput.UserData.playerCount;
		ThbvwyPHzFYdSLQZIrFZzJKEljDb = PxyBheQWSSdmhqfzPOkDlgfsjrSl - 1;
		TWymbSCQZfKFVNboKjMGHOOXNVngA = new Player[ThbvwyPHzFYdSLQZIrFZzJKEljDb];
		xGiTkzNMBsznIMJkyVRbQvmdWYhs = new Player[PxyBheQWSSdmhqfzPOkDlgfsjrSl];
		IList<Player_Editor> list = ReInput.UserData.EUylEkfoKkBUEodVsyHiwCsvjWhO;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			NavnfkqhNDpXrjtRFqpTiDksPJbU navnfkqhNDpXrjtRFqpTiDksPJbU = player_Editor.vxJEvCHACqGinMnRADBivjGCuCWgA();
			ControllerMapLayoutManager.BDYFZVSWwKErjELSidgTrNxCIGTnA bDYFZVSWwKErjELSidgTrNxCIGTnA = player_Editor.controllerMapLayoutManagerSettings.NsidkifnfsXPBZrmHyEyMyukWrvA();
			ControllerMapEnabler.PmwXpNvOYcWhwXXBRFyufZxzkmZh pmwXpNvOYcWhwXXBRFyufZxzkmZh = player_Editor.controllerMapEnablerSettings.HnLlaVUFhvOWTOLOTpkNrZZPVVHf();
			Player player;
			if (i == 0)
			{
				player = (ELRUIWoIYINeqiYVETXDaihKQabU = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, navnfkqhNDpXrjtRFqpTiDksPJbU, bDYFZVSWwKErjELSidgTrNxCIGTnA, pmwXpNvOYcWhwXXBRFyufZxzkmZh));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, navnfkqhNDpXrjtRFqpTiDksPJbU, bDYFZVSWwKErjELSidgTrNxCIGTnA, pmwXpNvOYcWhwXXBRFyufZxzkmZh);
				TWymbSCQZfKFVNboKjMGHOOXNVngA[i - 1] = player;
			}
			xGiTkzNMBsznIMJkyVRbQvmdWYhs[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.LbwllfRjbuLOKuHAzdwzjjMJRszn(true);
			player.controllers.maps.BDLfJUyaNiyxuucLSjOekXbieOuWA(true);
		}
		WaYlcxDKxOmmMMEMsQlVSRQixtik = new ReadOnlyCollection<Player>(TWymbSCQZfKFVNboKjMGHOOXNVngA);
		CETJjedQjGVOcZYtrrAVjurwVOZs = new ReadOnlyCollection<Player>(xGiTkzNMBsznIMJkyVRbQvmdWYhs);
		RWOkQsoeNKSDgCImIieZMcvBWYpN = true;
	}

	public void jXoqutavsNBfWWIeOzvWSVwdbfRT(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!AOGbLhckLyKqCEJcFnkegFTqUpoE.reassignJoystickToPreviousOwnerOnReconnect || !FUNtTIGmNROxGaFjKLhKRksgggeQ(P_0))
		{
			NllVHJYBUEyDhbVpNfPNuUisRghC(P_0);
		}
	}

	public void McQkKmbAVuOBoNIPxiGwBMvwSpglA(Joystick P_0)
	{
		if (AOGbLhckLyKqCEJcFnkegFTqUpoE.autoAssignJoysticks)
		{
			jXoqutavsNBfWWIeOzvWSVwdbfRT(P_0);
		}
	}

	public void SiZLDopAVHxpJoZrTGLEgzyzFZEI(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < PxyBheQWSSdmhqfzPOkDlgfsjrSl; i++)
		{
			xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player CdVzoIAGjOsZSBsVEHDGWSgvSrMu(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= ThbvwyPHzFYdSLQZIrFZzJKEljDb))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return ELRUIWoIYINeqiYVETXDaihKQabU;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			if (TWymbSCQZfKFVNboKjMGHOOXNVngA[i].id == P_0)
			{
				return TWymbSCQZfKFVNboKjMGHOOXNVngA[P_0];
			}
		}
		return null;
	}

	public Player yDDPDFuPIyZoCdTwIddvOaQsOZSb(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (ELRUIWoIYINeqiYVETXDaihKQabU.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return ELRUIWoIYINeqiYVETXDaihKQabU;
			}
			for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
			{
				if (TWymbSCQZfKFVNboKjMGHOOXNVngA[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return TWymbSCQZfKFVNboKjMGHOOXNVngA[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player LPpnIhYgEyRiiqljhjpHPsIBtMwL()
	{
		return ELRUIWoIYINeqiYVETXDaihKQabU;
	}

	public int VSZbmXOPTkgGrdIhFbZvJCljdOblA(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (ELRUIWoIYINeqiYVETXDaihKQabU.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			if (TWymbSCQZfKFVNboKjMGHOOXNVngA[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return TWymbSCQZfKFVNboKjMGHOOXNVngA[i].id;
			}
		}
		return -1;
	}

	public bool CnraUkgOpCTmmmKqDQamvIcHNpOQA(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= ThbvwyPHzFYdSLQZIrFZzJKEljDb))
		{
			return false;
		}
		return true;
	}

	public Player[] UWAzTnCUULyArGVwZDXAWnAVwjTG(bool P_0)
	{
		int num = ThbvwyPHzFYdSLQZIrFZzJKEljDb;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ELRUIWoIYINeqiYVETXDaihKQabU;
			num2 = 1;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			array[num2 + i] = TWymbSCQZfKFVNboKjMGHOOXNVngA[i];
		}
		return array;
	}

	public string[] VcTfkUBSznrojWSaanOBsGcugzyE(bool P_0)
	{
		int num = ThbvwyPHzFYdSLQZIrFZzJKEljDb;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ELRUIWoIYINeqiYVETXDaihKQabU.name;
			num2 = 1;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			array[num2 + i] = TWymbSCQZfKFVNboKjMGHOOXNVngA[i].name;
		}
		return array;
	}

	public string[] ghDfFjEGXXQGFoleWBnJGHaMyVoE(bool P_0)
	{
		int num = ThbvwyPHzFYdSLQZIrFZzJKEljDb;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ELRUIWoIYINeqiYVETXDaihKQabU.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			array[num2 + i] = TWymbSCQZfKFVNboKjMGHOOXNVngA[i].descriptiveName;
		}
		return array;
	}

	public int[] EPutkDjhkekPRywUlzDFIEwvfBDP(bool P_0)
	{
		int num = ThbvwyPHzFYdSLQZIrFZzJKEljDb;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ELRUIWoIYINeqiYVETXDaihKQabU.id;
			num2 = 1;
		}
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			array[num2 + i] = TWymbSCQZfKFVNboKjMGHOOXNVngA[i].id;
		}
		return array;
	}

	public bool dQGjxbDQwXTvhBSfjdFlvglvIdihA(Controller P_0)
	{
		if (P_0 == null || xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		return MpMEJddRuwkYwaYOoJnkVupRrOUuA(P_0.type, P_0.id);
	}

	public bool MpMEJddRuwkYwaYOoJnkVupRrOUuA(ControllerType P_0, int P_1)
	{
		if (xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		for (int i = 0; i < xGiTkzNMBsznIMJkyVRbQvmdWYhs.Length; i++)
		{
			if (xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool RSdfPAXAOoNuNGjBmAKsHsfswMQG(ControllerType P_0, int P_1, int P_2)
	{
		return CdVzoIAGjOsZSBsVEHDGWSgvSrMu(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void EGUYVFTXzgVOqyBiQkrIeRmrieLx(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ELRUIWoIYINeqiYVETXDaihKQabU.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
			{
				TWymbSCQZfKFVNboKjMGHOOXNVngA[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void QzOrqgzxApPhsHMhYCFaiZrXIhwK(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			EGUYVFTXzgVOqyBiQkrIeRmrieLx(controller, P_2);
		}
	}

	public bool pjYjhLcFIZVVxCWWKlzxyxpLBKkf(Joystick P_0)
	{
		if (P_0 == null || xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		for (int i = 0; i < xGiTkzNMBsznIMJkyVRbQvmdWYhs.Length; i++)
		{
			if (xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool RONwjKMELSizrftsBKUewdFPWoWbA(int P_0)
	{
		if (xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		for (int i = 0; i < xGiTkzNMBsznIMJkyVRbQvmdWYhs.Length; i++)
		{
			if (xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool SLcuoNAuJOhgfciGuUyCDUHJJquq(int P_0, int P_1)
	{
		return CdVzoIAGjOsZSBsVEHDGWSgvSrMu(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void ZAhuuMdmCOdaHFekcblImUeVnbEXA(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ELRUIWoIYINeqiYVETXDaihKQabU.controllers.BsoCrWISbtZHPAoujqFiBpdcwCEkb(P_0);
			}
			for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
			{
				TWymbSCQZfKFVNboKjMGHOOXNVngA[i].controllers.BsoCrWISbtZHPAoujqFiBpdcwCEkb(P_0);
			}
		}
	}

	public void BachvcTguUTLTWGAcMoKVSFoZeZA(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			ZAhuuMdmCOdaHFekcblImUeVnbEXA(joystick, P_1);
		}
	}

	public bool rCiBQESZfsRuaGJhkJsXaIryMEqg(CustomController P_0)
	{
		if (P_0 == null || xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		for (int i = 0; i < xGiTkzNMBsznIMJkyVRbQvmdWYhs.Length; i++)
		{
			if (xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool rbnzeILxAbqIjxxsjhAWxMKDjLNe(int P_0)
	{
		if (xGiTkzNMBsznIMJkyVRbQvmdWYhs == null)
		{
			return false;
		}
		for (int i = 0; i < xGiTkzNMBsznIMJkyVRbQvmdWYhs.Length; i++)
		{
			if (xGiTkzNMBsznIMJkyVRbQvmdWYhs[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool xPunGBCMChMTuGgFWGtTdruoYHzL(int P_0, int P_1)
	{
		return CdVzoIAGjOsZSBsVEHDGWSgvSrMu(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void wzvRppNUsgCKRdXlfrbszeNEsSot(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ELRUIWoIYINeqiYVETXDaihKQabU.controllers.rPZNNNiNEnzGAbdCMJlAQYHMradL(P_0);
			}
			for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
			{
				TWymbSCQZfKFVNboKjMGHOOXNVngA[i].controllers.rPZNNNiNEnzGAbdCMJlAQYHMradL(P_0);
			}
		}
	}

	public void irdAqnavOmwSihLHXkHBiTNZVPpB(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			wzvRppNUsgCKRdXlfrbszeNEsSot(customController, P_1);
		}
	}

	private bool FUNtTIGmNROxGaFjKLhKRksgggeQ(Joystick P_0)
	{
		if (AOGbLhckLyKqCEJcFnkegFTqUpoE.distributeJoysticksEvenly)
		{
			int num = olHxvEKAUUawohLinrHRUmSyjOFhb();
			if (num < 0)
			{
				return false;
			}
			int num2 = XxlkPmWLkXxHrxuTkPcgJdlFiZyE(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = TWymbSCQZfKFVNboKjMGHOOXNVngA[num];
			Player player2 = TWymbSCQZfKFVNboKjMGHOOXNVngA[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				TWymbSCQZfKFVNboKjMGHOOXNVngA[num2].controllers.eWLWlDdqVwMePCdNZtkUlUhzWelk(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = XxlkPmWLkXxHrxuTkPcgJdlFiZyE(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		TWymbSCQZfKFVNboKjMGHOOXNVngA[num3].controllers.eWLWlDdqVwMePCdNZtkUlUhzWelk(P_0, true);
		return true;
	}

	private bool NllVHJYBUEyDhbVpNfPNuUisRghC(Joystick P_0)
	{
		if (AOGbLhckLyKqCEJcFnkegFTqUpoE.distributeJoysticksEvenly)
		{
			int num = olHxvEKAUUawohLinrHRUmSyjOFhb();
			if (num >= 0)
			{
				TWymbSCQZfKFVNboKjMGHOOXNVngA[num].controllers.eWLWlDdqVwMePCdNZtkUlUhzWelk(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
			{
				Player player = TWymbSCQZfKFVNboKjMGHOOXNVngA[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!AOGbLhckLyKqCEJcFnkegFTqUpoE.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < AOGbLhckLyKqCEJcFnkegFTqUpoE.maxJoysticksPerPlayer)
				{
					player.controllers.eWLWlDdqVwMePCdNZtkUlUhzWelk(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int olHxvEKAUUawohLinrHRUmSyjOFhb()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			Player player = TWymbSCQZfKFVNboKjMGHOOXNVngA[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!AOGbLhckLyKqCEJcFnkegFTqUpoE.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < AOGbLhckLyKqCEJcFnkegFTqUpoE.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int XxlkPmWLkXxHrxuTkPcgJdlFiZyE(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < ThbvwyPHzFYdSLQZIrFZzJKEljDb; i++)
		{
			Player player = TWymbSCQZfKFVNboKjMGHOOXNVngA[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!AOGbLhckLyKqCEJcFnkegFTqUpoE.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < AOGbLhckLyKqCEJcFnkegFTqUpoE.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.ppTKiHMXzlemXAFVcLOjEBjNTeBr(P_0);
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
