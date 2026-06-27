using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class hSQdAZAaMRJsyVvNAYTUQfKIxyBHA
{
	private int MxShDhOYDepJqTMfaQssJBjcznHD;

	private int CQNXGNDCFnUumizdflLwBDhKcpsU;

	private Player PVwEGdjpJjBVzWyXciaabCniOkXYA;

	private Player[] wiNgaYfSGXsONMQmCleAGcuHpGLMA;

	private Player[] GtPhrpHnAAHyYXEiqXzbwBWrYJLr;

	private IList<Player> ByllkMQGsrFTTjMEQnCaFiSGzzWfA;

	private IList<Player> XliMjVgnuvwhnNRfNcxkXTzCqEpn;

	private ConfigVars HRrzokxxPJxyrIXgtQWVOJFAMLIC;

	private bool YlbwTBhOGpbjPIccVNahwdrlCRFb;

	public int PgvVwCKqIMiCGICkPcSeOjADhiYHA => MxShDhOYDepJqTMfaQssJBjcznHD;

	public int tTAgJsZjTDwqxfQZLEchyJiueBhb => CQNXGNDCFnUumizdflLwBDhKcpsU;

	public Player[] UhKEPLicjLTRaqjePDVyKtjrIvZbA => wiNgaYfSGXsONMQmCleAGcuHpGLMA;

	public Player[] BrjataNvgVFVOmITmwEwVxOllNFI => GtPhrpHnAAHyYXEiqXzbwBWrYJLr;

	public IList<Player> AHWgfJfctrWLAdtjHSOGbKBsDGRTA => XliMjVgnuvwhnNRfNcxkXTzCqEpn;

	public IList<Player> jHkpGHSbDxJCtHlTDhmvZphxDDtB => ByllkMQGsrFTTjMEQnCaFiSGzzWfA;

	public hSQdAZAaMRJsyVvNAYTUQfKIxyBHA(ConfigVars P_0)
	{
		HRrzokxxPJxyrIXgtQWVOJFAMLIC = P_0;
	}

	public void rDGAsGaojnDPNxgJdXwzYFbyGYcJ()
	{
		if (YlbwTBhOGpbjPIccVNahwdrlCRFb)
		{
			return;
		}
		CQNXGNDCFnUumizdflLwBDhKcpsU = ReInput.UserData.playerCount;
		MxShDhOYDepJqTMfaQssJBjcznHD = CQNXGNDCFnUumizdflLwBDhKcpsU - 1;
		GtPhrpHnAAHyYXEiqXzbwBWrYJLr = new Player[MxShDhOYDepJqTMfaQssJBjcznHD];
		wiNgaYfSGXsONMQmCleAGcuHpGLMA = new Player[CQNXGNDCFnUumizdflLwBDhKcpsU];
		IList<Player_Editor> list = ReInput.UserData.RsZazJyYPNugVeFNMaHRGPaHgKVT;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			GdOldZdkCaFseCtTjjUkzAqYRXRaA gdOldZdkCaFseCtTjjUkzAqYRXRaA = player_Editor.sfevprHfXNJJgzwZuKiPDvAkSUmo();
			ControllerMapLayoutManager.SLxTBaXfrhZCyLfCEqNyvKbuXYzr sLxTBaXfrhZCyLfCEqNyvKbuXYzr = player_Editor.controllerMapLayoutManagerSettings.YaBzBVmKiIslCZAvQEVduNwKgQTt();
			ControllerMapEnabler.MpLdxmCiVDCEhjPNCfTXmDrkNyfGc mpLdxmCiVDCEhjPNCfTXmDrkNyfGc = player_Editor.controllerMapEnablerSettings.EkglfmNyEGbFYGFUrYogXbXjNnnh();
			Player player;
			if (i == 0)
			{
				player = (PVwEGdjpJjBVzWyXciaabCniOkXYA = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, gdOldZdkCaFseCtTjjUkzAqYRXRaA, sLxTBaXfrhZCyLfCEqNyvKbuXYzr, mpLdxmCiVDCEhjPNCfTXmDrkNyfGc));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, gdOldZdkCaFseCtTjjUkzAqYRXRaA, sLxTBaXfrhZCyLfCEqNyvKbuXYzr, mpLdxmCiVDCEhjPNCfTXmDrkNyfGc);
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i - 1] = player;
			}
			wiNgaYfSGXsONMQmCleAGcuHpGLMA[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.CNVzMCqaRbuLiMCBvRATJUhGeBHA(true);
			player.controllers.maps.MhirTlpsOVhUveaPclxDpqjUUIOR(true);
		}
		ByllkMQGsrFTTjMEQnCaFiSGzzWfA = new ReadOnlyCollection<Player>(GtPhrpHnAAHyYXEiqXzbwBWrYJLr);
		XliMjVgnuvwhnNRfNcxkXTzCqEpn = new ReadOnlyCollection<Player>(wiNgaYfSGXsONMQmCleAGcuHpGLMA);
		YlbwTBhOGpbjPIccVNahwdrlCRFb = true;
	}

	public void ufFgsSdkjuDAVfUimDAlLssVnttAA(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!HRrzokxxPJxyrIXgtQWVOJFAMLIC.reassignJoystickToPreviousOwnerOnReconnect || !OUqCBrDRCeFSPGafmrExqhgAomItA(P_0))
		{
			YLSDdaRdYdRogrUVfMsaWGSWNDPh(P_0);
		}
	}

	public void NJhnARcEELdedFLFVWpTyufQZhAw(Joystick P_0)
	{
		if (HRrzokxxPJxyrIXgtQWVOJFAMLIC.autoAssignJoysticks)
		{
			ufFgsSdkjuDAVfUimDAlLssVnttAA(P_0);
		}
	}

	public void DOoFeNcCwaYbSapZvprfEkUZVhwD(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < CQNXGNDCFnUumizdflLwBDhKcpsU; i++)
		{
			wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player RmeButhFmdxsBQPRyEgbZicZgdaPA(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= MxShDhOYDepJqTMfaQssJBjcznHD))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return PVwEGdjpJjBVzWyXciaabCniOkXYA;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			if (GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].id == P_0)
			{
				return GtPhrpHnAAHyYXEiqXzbwBWrYJLr[P_0];
			}
		}
		return null;
	}

	public Player bocNkkzFUJiZbroHaQlOkMmYMkvf(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (PVwEGdjpJjBVzWyXciaabCniOkXYA.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return PVwEGdjpJjBVzWyXciaabCniOkXYA;
			}
			for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
			{
				if (GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player UYvxAAXLLbizFcdHDYaOxGuhfKrc()
	{
		return PVwEGdjpJjBVzWyXciaabCniOkXYA;
	}

	public int GIsqGsJQAFbAcORnhkeGcqxHCbHm(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (PVwEGdjpJjBVzWyXciaabCniOkXYA.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			if (GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].id;
			}
		}
		return -1;
	}

	public bool BgKyOLXYenjPzKFwpJJDovuhtjeN(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= MxShDhOYDepJqTMfaQssJBjcznHD))
		{
			return false;
		}
		return true;
	}

	public Player[] BqfzOERENaENmAzcvLuhwmQdccjR(bool P_0)
	{
		int num = MxShDhOYDepJqTMfaQssJBjcznHD;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = PVwEGdjpJjBVzWyXciaabCniOkXYA;
			num2 = 1;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			array[num2 + i] = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i];
		}
		return array;
	}

	public string[] UTccntAdaUQUkUlaYJCwIosGNySV(bool P_0)
	{
		int num = MxShDhOYDepJqTMfaQssJBjcznHD;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = PVwEGdjpJjBVzWyXciaabCniOkXYA.name;
			num2 = 1;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			array[num2 + i] = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].name;
		}
		return array;
	}

	public string[] tKgxaALdNenyWoGnoeDmoAHwJsSw(bool P_0)
	{
		int num = MxShDhOYDepJqTMfaQssJBjcznHD;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = PVwEGdjpJjBVzWyXciaabCniOkXYA.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			array[num2 + i] = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].descriptiveName;
		}
		return array;
	}

	public int[] RhLpctkdEXHYRuQFrCigsaAHBfDc(bool P_0)
	{
		int num = MxShDhOYDepJqTMfaQssJBjcznHD;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = PVwEGdjpJjBVzWyXciaabCniOkXYA.id;
			num2 = 1;
		}
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			array[num2 + i] = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].id;
		}
		return array;
	}

	public bool uHrozQCgbwBKiBItVqiSRudRuvQN(Controller P_0)
	{
		if (P_0 == null || wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		return VQjvBWONvPgtzDMAEuUJEOdxbYqXA(P_0.type, P_0.id);
	}

	public bool VQjvBWONvPgtzDMAEuUJEOdxbYqXA(ControllerType P_0, int P_1)
	{
		if (wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		for (int i = 0; i < wiNgaYfSGXsONMQmCleAGcuHpGLMA.Length; i++)
		{
			if (wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool KACzddYFWPaCRMRgYzhRhtqUiKoC(ControllerType P_0, int P_1, int P_2)
	{
		return RmeButhFmdxsBQPRyEgbZicZgdaPA(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void VnbbRojUeZTerKamyiExpAwDrmlOA(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				PVwEGdjpJjBVzWyXciaabCniOkXYA.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
			{
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void LcdpRTuBLUFctXObwCnLSgblfEWhA(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			VnbbRojUeZTerKamyiExpAwDrmlOA(controller, P_2);
		}
	}

	public bool ugjLfyrLVgwwuEeEkxAGGIdbQHCY(Joystick P_0)
	{
		if (P_0 == null || wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		for (int i = 0; i < wiNgaYfSGXsONMQmCleAGcuHpGLMA.Length; i++)
		{
			if (wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool KMwghhEZYhtAqlhodovVOJZhmcqkA(int P_0)
	{
		if (wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		for (int i = 0; i < wiNgaYfSGXsONMQmCleAGcuHpGLMA.Length; i++)
		{
			if (wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool BDBgkqhPEdyHkVeMWkNrPnFvdaAVA(int P_0, int P_1)
	{
		return RmeButhFmdxsBQPRyEgbZicZgdaPA(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void IxAfwpqfRhrFSgIcGcIbCagpqpaeb(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				PVwEGdjpJjBVzWyXciaabCniOkXYA.controllers.WoLyvxVxaOGmOayuVloVBsbYBYst(P_0);
			}
			for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
			{
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].controllers.WoLyvxVxaOGmOayuVloVBsbYBYst(P_0);
			}
		}
	}

	public void QvVhGSAKlTmnEDIQulhFrWKfFNAk(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			IxAfwpqfRhrFSgIcGcIbCagpqpaeb(joystick, P_1);
		}
	}

	public bool ifDTfvBZeFogdEcvSgmsWgOUbMIEA(CustomController P_0)
	{
		if (P_0 == null || wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		for (int i = 0; i < wiNgaYfSGXsONMQmCleAGcuHpGLMA.Length; i++)
		{
			if (wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool uVMvSTEHyIJxkxefJAHnJQOznapi(int P_0)
	{
		if (wiNgaYfSGXsONMQmCleAGcuHpGLMA == null)
		{
			return false;
		}
		for (int i = 0; i < wiNgaYfSGXsONMQmCleAGcuHpGLMA.Length; i++)
		{
			if (wiNgaYfSGXsONMQmCleAGcuHpGLMA[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool ySJhjaZCFYiphYLBmsliPpaWgSLW(int P_0, int P_1)
	{
		return RmeButhFmdxsBQPRyEgbZicZgdaPA(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void tEQixQAylHQlAnvnBcONTEXeTIOM(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				PVwEGdjpJjBVzWyXciaabCniOkXYA.controllers.epoFkErIWYIJNhGbsqhnmLswvJCc(P_0);
			}
			for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
			{
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i].controllers.epoFkErIWYIJNhGbsqhnmLswvJCc(P_0);
			}
		}
	}

	public void tsKINBdiQJRwJpFKlXFkWRznTIzc(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			tEQixQAylHQlAnvnBcONTEXeTIOM(customController, P_1);
		}
	}

	private bool OUqCBrDRCeFSPGafmrExqhgAomItA(Joystick P_0)
	{
		if (HRrzokxxPJxyrIXgtQWVOJFAMLIC.distributeJoysticksEvenly)
		{
			int num = fwgGlpdFBtOFdqZcBymuEHMCmGxt();
			if (num < 0)
			{
				return false;
			}
			int num2 = KQUypHHbnuKQwnNiKdsZBpttEwWWA(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[num];
			Player player2 = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[num2].controllers.tBeKinwvFPvMaGNohApbTvgJUcRe(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = KQUypHHbnuKQwnNiKdsZBpttEwWWA(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		GtPhrpHnAAHyYXEiqXzbwBWrYJLr[num3].controllers.tBeKinwvFPvMaGNohApbTvgJUcRe(P_0, true);
		return true;
	}

	private bool YLSDdaRdYdRogrUVfMsaWGSWNDPh(Joystick P_0)
	{
		if (HRrzokxxPJxyrIXgtQWVOJFAMLIC.distributeJoysticksEvenly)
		{
			int num = fwgGlpdFBtOFdqZcBymuEHMCmGxt();
			if (num >= 0)
			{
				GtPhrpHnAAHyYXEiqXzbwBWrYJLr[num].controllers.tBeKinwvFPvMaGNohApbTvgJUcRe(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
			{
				Player player = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!HRrzokxxPJxyrIXgtQWVOJFAMLIC.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < HRrzokxxPJxyrIXgtQWVOJFAMLIC.maxJoysticksPerPlayer)
				{
					player.controllers.tBeKinwvFPvMaGNohApbTvgJUcRe(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int fwgGlpdFBtOFdqZcBymuEHMCmGxt()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			Player player = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!HRrzokxxPJxyrIXgtQWVOJFAMLIC.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < HRrzokxxPJxyrIXgtQWVOJFAMLIC.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int KQUypHHbnuKQwnNiKdsZBpttEwWWA(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < MxShDhOYDepJqTMfaQssJBjcznHD; i++)
		{
			Player player = GtPhrpHnAAHyYXEiqXzbwBWrYJLr[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!HRrzokxxPJxyrIXgtQWVOJFAMLIC.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < HRrzokxxPJxyrIXgtQWVOJFAMLIC.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.ijaPyyBveGpVMOkFGIzUmWbzjqhgA(P_0);
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
