using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class kfVJCyCDaGCuiDEEEMtqgVXykXX
{
	private int DlGMeHRjxOLgHPOwpcDtBGYjZkwP;

	private int JAMVBpHZiprqSPSeZNOTDgdvlNi;

	private Player UnxvVvEuncjQczNEbdyEELNCAVG;

	private Player[] sHxbYwGtqFnCwcFwDInatNlExAkf;

	private Player[] thLaKykXFSONOCdQPyksMrrsVkyT;

	private IList<Player> dhiBazVdrafCeAllHCBMIVcisOzj;

	private IList<Player> wuceIIRQXgXgkSiDBccNbGRWHapB;

	private ConfigVars SRJmkvsqkiIalkRkItQQVjlCCTY;

	private bool SqipAxIcjKKBSnKUcHhsIAAfbiWH;

	public int gamePlayerCount => DlGMeHRjxOLgHPOwpcDtBGYjZkwP;

	public int allPlayerCount => JAMVBpHZiprqSPSeZNOTDgdvlNi;

	public Player[] AllPlayers_orig => sHxbYwGtqFnCwcFwDInatNlExAkf;

	public Player[] Players_orig => thLaKykXFSONOCdQPyksMrrsVkyT;

	public IList<Player> AllPlayers_readOnly => wuceIIRQXgXgkSiDBccNbGRWHapB;

	public IList<Player> Players_readOnly => dhiBazVdrafCeAllHCBMIVcisOzj;

	public kfVJCyCDaGCuiDEEEMtqgVXykXX(ConfigVars configVars)
	{
		SRJmkvsqkiIalkRkItQQVjlCCTY = configVars;
	}

	public void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
	{
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			return;
		}
		JAMVBpHZiprqSPSeZNOTDgdvlNi = ReInput.UserData.playerCount;
		DlGMeHRjxOLgHPOwpcDtBGYjZkwP = JAMVBpHZiprqSPSeZNOTDgdvlNi - 1;
		thLaKykXFSONOCdQPyksMrrsVkyT = new Player[DlGMeHRjxOLgHPOwpcDtBGYjZkwP];
		sHxbYwGtqFnCwcFwDInatNlExAkf = new Player[JAMVBpHZiprqSPSeZNOTDgdvlNi];
		IList<Player_Editor> players_readOnly = ReInput.UserData.Players_readOnly;
		if (players_readOnly == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < players_readOnly.Count; i++)
		{
			Player_Editor player_Editor = players_readOnly[i];
			HRJeTaRmGlgEoVaWhsuEDjticiT startingControllerMapInfo = player_Editor.WypoOZTcWWXaNvnSqMgvRUqplkk();
			ControllerMapLayoutManager.PseBURjmDgdQyBrNSFfUTuoWirpM controllerMapLayoutManagerSettings = player_Editor.controllerMapLayoutManagerSettings.PrfAiLNTEsMCPZVXnxzgaYuqXXt();
			ControllerMapEnabler.FIAqEJWjdCiOptKWtsxrOjilkTn controllerMapEnablerSettings = player_Editor.controllerMapEnablerSettings.PrfAiLNTEsMCPZVXnxzgaYuqXXt();
			Player player;
			if (i == 0)
			{
				player = (UnxvVvEuncjQczNEbdyEELNCAVG = new Player(isSystem: true, 9999999, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings));
			}
			else
			{
				player = new Player(isSystem: false, i - 1, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
				thLaKykXFSONOCdQPyksMrrsVkyT[i - 1] = player;
			}
			sHxbYwGtqFnCwcFwDInatNlExAkf[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.NcVkKPwxNNIsmzNYNMPcELAADNi(true);
			player.controllers.maps.YcGDcTlWnJupoXBEHCLaNSzihyB(true);
		}
		dhiBazVdrafCeAllHCBMIVcisOzj = new ReadOnlyCollection<Player>(thLaKykXFSONOCdQPyksMrrsVkyT);
		wuceIIRQXgXgkSiDBccNbGRWHapB = new ReadOnlyCollection<Player>(sHxbYwGtqFnCwcFwDInatNlExAkf);
		SqipAxIcjKKBSnKUcHhsIAAfbiWH = true;
	}

	public void pxrxiumvSxmFHZqNkZtuUuxFAva(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!SRJmkvsqkiIalkRkItQQVjlCCTY.reassignJoystickToPreviousOwnerOnReconnect || !jPJggUejDwmeBKDfEtLlDxnXRPN(P_0))
		{
			jTTxUZZKVxZmBOGAraWTMCaMALH(P_0);
		}
	}

	public void WYzHcCWbflFQfqeneHHCgklpstlG(Joystick P_0)
	{
		if (SRJmkvsqkiIalkRkItQQVjlCCTY.autoAssignJoysticks)
		{
			pxrxiumvSxmFHZqNkZtuUuxFAva(P_0);
		}
	}

	public void VtoLUmzBFNaRsYtVcArJETKFsZA(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < JAMVBpHZiprqSPSeZNOTDgdvlNi; i++)
		{
			sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player FgvPueKchdieOiiAPcILDqNkmwJD(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= DlGMeHRjxOLgHPOwpcDtBGYjZkwP))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return UnxvVvEuncjQczNEbdyEELNCAVG;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			if (thLaKykXFSONOCdQPyksMrrsVkyT[i].id == P_0)
			{
				return thLaKykXFSONOCdQPyksMrrsVkyT[P_0];
			}
		}
		return null;
	}

	public Player FgvPueKchdieOiiAPcILDqNkmwJD(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (UnxvVvEuncjQczNEbdyEELNCAVG.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return UnxvVvEuncjQczNEbdyEELNCAVG;
			}
			for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
			{
				if (thLaKykXFSONOCdQPyksMrrsVkyT[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return thLaKykXFSONOCdQPyksMrrsVkyT[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player InehxVsbhjanyOASwkbyVFduGgO()
	{
		return UnxvVvEuncjQczNEbdyEELNCAVG;
	}

	public int qITXfUNdBbAdXeHXFufzpoAzNmo(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (UnxvVvEuncjQczNEbdyEELNCAVG.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			if (thLaKykXFSONOCdQPyksMrrsVkyT[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return thLaKykXFSONOCdQPyksMrrsVkyT[i].id;
			}
		}
		return -1;
	}

	public bool EJgmhObMJAnIfOIVroEKcjegjXB(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= DlGMeHRjxOLgHPOwpcDtBGYjZkwP))
		{
			return false;
		}
		return true;
	}

	public Player[] ztCjyKnfPLfiEDnKXPLdcHEOTfe(bool P_0)
	{
		int num = DlGMeHRjxOLgHPOwpcDtBGYjZkwP;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = UnxvVvEuncjQczNEbdyEELNCAVG;
			num2 = 1;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			array[num2 + i] = thLaKykXFSONOCdQPyksMrrsVkyT[i];
		}
		return array;
	}

	public string[] xmwbDOmUOkXNMSlXXfHxCKJhTeJW(bool P_0)
	{
		int num = DlGMeHRjxOLgHPOwpcDtBGYjZkwP;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = UnxvVvEuncjQczNEbdyEELNCAVG.name;
			num2 = 1;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			array[num2 + i] = thLaKykXFSONOCdQPyksMrrsVkyT[i].name;
		}
		return array;
	}

	public string[] pBdfGrYUULEoLxvxxmGAsARSAkya(bool P_0)
	{
		int num = DlGMeHRjxOLgHPOwpcDtBGYjZkwP;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = UnxvVvEuncjQczNEbdyEELNCAVG.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			array[num2 + i] = thLaKykXFSONOCdQPyksMrrsVkyT[i].descriptiveName;
		}
		return array;
	}

	public int[] xHufTcekvGBGnyBwePzLaeiczqCB(bool P_0)
	{
		int num = DlGMeHRjxOLgHPOwpcDtBGYjZkwP;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = UnxvVvEuncjQczNEbdyEELNCAVG.id;
			num2 = 1;
		}
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			array[num2 + i] = thLaKykXFSONOCdQPyksMrrsVkyT[i].id;
		}
		return array;
	}

	public bool qmDFIzGYulUJKGUsgvBzDqiWKvsF(Controller P_0)
	{
		if (P_0 == null || sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		return qmDFIzGYulUJKGUsgvBzDqiWKvsF(P_0.type, P_0.id);
	}

	public bool qmDFIzGYulUJKGUsgvBzDqiWKvsF(ControllerType P_0, int P_1)
	{
		if (sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		for (int i = 0; i < sHxbYwGtqFnCwcFwDInatNlExAkf.Length; i++)
		{
			if (sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool BlQbHKandRnqXPhFYnpPfaWhUaKl(ControllerType P_0, int P_1, int P_2)
	{
		return FgvPueKchdieOiiAPcILDqNkmwJD(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void cGMtaipcmCyBYxrAQiqfiOsfYtW(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				UnxvVvEuncjQczNEbdyEELNCAVG.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
			{
				thLaKykXFSONOCdQPyksMrrsVkyT[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void cGMtaipcmCyBYxrAQiqfiOsfYtW(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			cGMtaipcmCyBYxrAQiqfiOsfYtW(controller, P_2);
		}
	}

	public bool IvrezgzceBEuYLfNAkpTLjlquXT(Joystick P_0)
	{
		if (P_0 == null || sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		for (int i = 0; i < sHxbYwGtqFnCwcFwDInatNlExAkf.Length; i++)
		{
			if (sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool IvrezgzceBEuYLfNAkpTLjlquXT(int P_0)
	{
		if (sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		for (int i = 0; i < sHxbYwGtqFnCwcFwDInatNlExAkf.Length; i++)
		{
			if (sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool qAWZRYIzkKFTLclJrdyvtJKhdHf(int P_0, int P_1)
	{
		return FgvPueKchdieOiiAPcILDqNkmwJD(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void ebWjIQjVsjKQiODYgaOPjBSkXNwq(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				UnxvVvEuncjQczNEbdyEELNCAVG.controllers.nwaJKAsevjXsebhXFWcqRNNGQia(P_0);
			}
			for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
			{
				thLaKykXFSONOCdQPyksMrrsVkyT[i].controllers.nwaJKAsevjXsebhXFWcqRNNGQia(P_0);
			}
		}
	}

	public void ebWjIQjVsjKQiODYgaOPjBSkXNwq(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			ebWjIQjVsjKQiODYgaOPjBSkXNwq(joystick, P_1);
		}
	}

	public bool JJFYCZaNtlCVQfSheeLgHUEbMDXT(CustomController P_0)
	{
		if (P_0 == null || sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		for (int i = 0; i < sHxbYwGtqFnCwcFwDInatNlExAkf.Length; i++)
		{
			if (sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool JJFYCZaNtlCVQfSheeLgHUEbMDXT(int P_0)
	{
		if (sHxbYwGtqFnCwcFwDInatNlExAkf == null)
		{
			return false;
		}
		for (int i = 0; i < sHxbYwGtqFnCwcFwDInatNlExAkf.Length; i++)
		{
			if (sHxbYwGtqFnCwcFwDInatNlExAkf[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool CMfJZvBuJjpaQFmBkHplQOFPMbc(int P_0, int P_1)
	{
		return FgvPueKchdieOiiAPcILDqNkmwJD(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void boJkshEfCridssATBESoRChHBOuB(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				UnxvVvEuncjQczNEbdyEELNCAVG.controllers.TPBQzKwhRwfWtmCNVYcejNFNlGQ(P_0);
			}
			for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
			{
				thLaKykXFSONOCdQPyksMrrsVkyT[i].controllers.TPBQzKwhRwfWtmCNVYcejNFNlGQ(P_0);
			}
		}
	}

	public void boJkshEfCridssATBESoRChHBOuB(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			boJkshEfCridssATBESoRChHBOuB(customController, P_1);
		}
	}

	private bool jPJggUejDwmeBKDfEtLlDxnXRPN(Joystick P_0)
	{
		if (SRJmkvsqkiIalkRkItQQVjlCCTY.distributeJoysticksEvenly)
		{
			int num = HJxrNMdGVgJkopjGkuTQpZsDncd();
			if (num < 0)
			{
				return false;
			}
			int num2 = FwxmbmKafgOENfiLBzlIFxVINQe(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = thLaKykXFSONOCdQPyksMrrsVkyT[num];
			Player player2 = thLaKykXFSONOCdQPyksMrrsVkyT[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				thLaKykXFSONOCdQPyksMrrsVkyT[num2].controllers.ByLRMWSEaQYOtQxguVzbYinZLhi(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = FwxmbmKafgOENfiLBzlIFxVINQe(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		thLaKykXFSONOCdQPyksMrrsVkyT[num3].controllers.ByLRMWSEaQYOtQxguVzbYinZLhi(P_0, true);
		return true;
	}

	private bool jTTxUZZKVxZmBOGAraWTMCaMALH(Joystick P_0)
	{
		if (SRJmkvsqkiIalkRkItQQVjlCCTY.distributeJoysticksEvenly)
		{
			int num = HJxrNMdGVgJkopjGkuTQpZsDncd();
			if (num >= 0)
			{
				thLaKykXFSONOCdQPyksMrrsVkyT[num].controllers.ByLRMWSEaQYOtQxguVzbYinZLhi(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
			{
				Player player = thLaKykXFSONOCdQPyksMrrsVkyT[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!SRJmkvsqkiIalkRkItQQVjlCCTY.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < SRJmkvsqkiIalkRkItQQVjlCCTY.maxJoysticksPerPlayer)
				{
					player.controllers.ByLRMWSEaQYOtQxguVzbYinZLhi(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int HJxrNMdGVgJkopjGkuTQpZsDncd()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			Player player = thLaKykXFSONOCdQPyksMrrsVkyT[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!SRJmkvsqkiIalkRkItQQVjlCCTY.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < SRJmkvsqkiIalkRkItQQVjlCCTY.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int FwxmbmKafgOENfiLBzlIFxVINQe(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < DlGMeHRjxOLgHPOwpcDtBGYjZkwP; i++)
		{
			Player player = thLaKykXFSONOCdQPyksMrrsVkyT[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!SRJmkvsqkiIalkRkItQQVjlCCTY.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < SRJmkvsqkiIalkRkItQQVjlCCTY.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.VfSAtErJNgBtSKzOlHUHCtLZEbLQ(P_0);
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
