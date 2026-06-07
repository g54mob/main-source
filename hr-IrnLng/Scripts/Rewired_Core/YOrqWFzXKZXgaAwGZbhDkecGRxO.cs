using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class YOrqWFzXKZXgaAwGZbhDkecGRxO
{
	private int proBRfaaKLGJXhYEdaHgFGleTmUQ;

	private int nUocXykBoeSAIIEmYVQcTSaNdMl;

	private Player axZDcFxfSrTzugQuesWNChisbGg;

	private Player[] GVDnpMSqPQqbeQSOJpfnPFIqmSK;

	private Player[] ZUrLjGwyiHTgGgZwYqFbzzUSapK;

	private IList<Player> HrIHcRkbOzbJkkYDGLfZVBLCHOL;

	private IList<Player> WhARhaafupJPiZpxGyuEEqmwXqJ;

	private ConfigVars kEfTcVPDPtzkvdMGLfLPBGnaUJq;

	private bool iTMWkJzAQHobYymwbflfUznXqqe;

	public int gamePlayerCount => proBRfaaKLGJXhYEdaHgFGleTmUQ;

	public int allPlayerCount => nUocXykBoeSAIIEmYVQcTSaNdMl;

	public Player[] AllPlayers_orig => GVDnpMSqPQqbeQSOJpfnPFIqmSK;

	public Player[] Players_orig => ZUrLjGwyiHTgGgZwYqFbzzUSapK;

	public IList<Player> AllPlayers_readOnly => WhARhaafupJPiZpxGyuEEqmwXqJ;

	public IList<Player> Players_readOnly => HrIHcRkbOzbJkkYDGLfZVBLCHOL;

	public YOrqWFzXKZXgaAwGZbhDkecGRxO(ConfigVars configVars)
	{
		kEfTcVPDPtzkvdMGLfLPBGnaUJq = configVars;
	}

	public void iDBXctPcOcjjzWbKaCnxuPiVNUc()
	{
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			return;
		}
		nUocXykBoeSAIIEmYVQcTSaNdMl = ReInput.UserData.playerCount;
		proBRfaaKLGJXhYEdaHgFGleTmUQ = nUocXykBoeSAIIEmYVQcTSaNdMl - 1;
		ZUrLjGwyiHTgGgZwYqFbzzUSapK = new Player[proBRfaaKLGJXhYEdaHgFGleTmUQ];
		GVDnpMSqPQqbeQSOJpfnPFIqmSK = new Player[nUocXykBoeSAIIEmYVQcTSaNdMl];
		IList<Player_Editor> players_readOnly = ReInput.UserData.Players_readOnly;
		if (players_readOnly == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < players_readOnly.Count; i++)
		{
			Player_Editor player_Editor = players_readOnly[i];
			zejNqQaBPwGHoSseyBcLZGOKcwt startingControllerMapInfo = player_Editor.iEHfftjwnXHFZQeydKeaaFXNJsMi();
			ControllerMapLayoutManager.nVKdNlGaejzDgsTfDjPFiRPkzxZ controllerMapLayoutManagerSettings = player_Editor.controllerMapLayoutManagerSettings.vXvlnwhmbxFrKnbuhrDslxYRVF();
			ControllerMapEnabler.nRwNnlnQOFltouymedybQVFLNDP controllerMapEnablerSettings = player_Editor.controllerMapEnablerSettings.vXvlnwhmbxFrKnbuhrDslxYRVF();
			Player player;
			if (i == 0)
			{
				player = (axZDcFxfSrTzugQuesWNChisbGg = new Player(isSystem: true, 9999999, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings));
			}
			else
			{
				player = new Player(isSystem: false, i - 1, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[i - 1] = player;
			}
			GVDnpMSqPQqbeQSOJpfnPFIqmSK[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.nzrwhfDOuQHLskLeCNZfYRjspZE(true);
			player.controllers.maps.cWaujwSKNUVkNCcDOOnpVQUKrzM(true);
		}
		HrIHcRkbOzbJkkYDGLfZVBLCHOL = new ReadOnlyCollection<Player>(ZUrLjGwyiHTgGgZwYqFbzzUSapK);
		WhARhaafupJPiZpxGyuEEqmwXqJ = new ReadOnlyCollection<Player>(GVDnpMSqPQqbeQSOJpfnPFIqmSK);
		iTMWkJzAQHobYymwbflfUznXqqe = true;
	}

	public void PkTWASHdMcjRDWrOrgHsjGBxPCR(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!kEfTcVPDPtzkvdMGLfLPBGnaUJq.reassignJoystickToPreviousOwnerOnReconnect || !LcxVRiTvslTTNZZTHVecZEElKDx(P_0))
		{
			JMtIvWyaeimNTRqFweiGYTukBJd(P_0);
		}
	}

	public void cILiesvYEynzhnVKvJDFgUiJtfR(Joystick P_0)
	{
		if (kEfTcVPDPtzkvdMGLfLPBGnaUJq.autoAssignJoysticks)
		{
			PkTWASHdMcjRDWrOrgHsjGBxPCR(P_0);
		}
	}

	public void vgIatAEAoUywaMBdvLtOaZztCNeG(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < nUocXykBoeSAIIEmYVQcTSaNdMl; i++)
		{
			GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player lZXmlWxQPcBFEbyBUMCSggeIoJj(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= proBRfaaKLGJXhYEdaHgFGleTmUQ))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return axZDcFxfSrTzugQuesWNChisbGg;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			if (ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].id == P_0)
			{
				return ZUrLjGwyiHTgGgZwYqFbzzUSapK[P_0];
			}
		}
		return null;
	}

	public Player lZXmlWxQPcBFEbyBUMCSggeIoJj(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (axZDcFxfSrTzugQuesWNChisbGg.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return axZDcFxfSrTzugQuesWNChisbGg;
			}
			for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
			{
				if (ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return ZUrLjGwyiHTgGgZwYqFbzzUSapK[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player ikAQnlPYKaPDyPGwvHipJdyKxOw()
	{
		return axZDcFxfSrTzugQuesWNChisbGg;
	}

	public int GmfmqgwwruAcVvlPCjzaddlByMI(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (axZDcFxfSrTzugQuesWNChisbGg.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			if (ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].id;
			}
		}
		return -1;
	}

	public bool waMPqyEZdXSlrPjgiomVglTYvwr(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= proBRfaaKLGJXhYEdaHgFGleTmUQ))
		{
			return false;
		}
		return true;
	}

	public Player[] DsOmuKlyICAQExaARSykOjoLWQ(bool P_0)
	{
		int num = proBRfaaKLGJXhYEdaHgFGleTmUQ;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = axZDcFxfSrTzugQuesWNChisbGg;
			num2 = 1;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			array[num2 + i] = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i];
		}
		return array;
	}

	public string[] VPCnmgLFdrmuGBobAhPkIEeTAolB(bool P_0)
	{
		int num = proBRfaaKLGJXhYEdaHgFGleTmUQ;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = axZDcFxfSrTzugQuesWNChisbGg.name;
			num2 = 1;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			array[num2 + i] = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].name;
		}
		return array;
	}

	public string[] XKJhTJfgdOBDZqfJcBGFkNaqcUU(bool P_0)
	{
		int num = proBRfaaKLGJXhYEdaHgFGleTmUQ;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = axZDcFxfSrTzugQuesWNChisbGg.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			array[num2 + i] = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].descriptiveName;
		}
		return array;
	}

	public int[] VrWNuYJxMDQfdSQUfevYuCHLXgk(bool P_0)
	{
		int num = proBRfaaKLGJXhYEdaHgFGleTmUQ;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = axZDcFxfSrTzugQuesWNChisbGg.id;
			num2 = 1;
		}
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			array[num2 + i] = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].id;
		}
		return array;
	}

	public bool GVznlLdqRgXcMHaCvcVsieBcNlQA(Controller P_0)
	{
		if (P_0 == null || GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		return GVznlLdqRgXcMHaCvcVsieBcNlQA(P_0.type, P_0.id);
	}

	public bool GVznlLdqRgXcMHaCvcVsieBcNlQA(ControllerType P_0, int P_1)
	{
		if (GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		for (int i = 0; i < GVDnpMSqPQqbeQSOJpfnPFIqmSK.Length; i++)
		{
			if (GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool pOoMiyOTIOHNVgqnXlxSqnnXwRw(ControllerType P_0, int P_1, int P_2)
	{
		return lZXmlWxQPcBFEbyBUMCSggeIoJj(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void IugDVSYkDFZiUqhwVGiwiTPVCdw(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				axZDcFxfSrTzugQuesWNChisbGg.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
			{
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void IugDVSYkDFZiUqhwVGiwiTPVCdw(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			IugDVSYkDFZiUqhwVGiwiTPVCdw(controller, P_2);
		}
	}

	public bool aiTSSOKxTWlWSUxnTlgSBQYSFDb(Joystick P_0)
	{
		if (P_0 == null || GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		for (int i = 0; i < GVDnpMSqPQqbeQSOJpfnPFIqmSK.Length; i++)
		{
			if (GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool aiTSSOKxTWlWSUxnTlgSBQYSFDb(int P_0)
	{
		if (GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		for (int i = 0; i < GVDnpMSqPQqbeQSOJpfnPFIqmSK.Length; i++)
		{
			if (GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool KhsagjbQMXqLFdZRydktrWoNjob(int P_0, int P_1)
	{
		return lZXmlWxQPcBFEbyBUMCSggeIoJj(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void MusrlwucDobbeEOklRAYNPplLBQz(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				axZDcFxfSrTzugQuesWNChisbGg.controllers.PIUibaZzJyyFaqSXWQcpLHakJEY(P_0);
			}
			for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
			{
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].controllers.PIUibaZzJyyFaqSXWQcpLHakJEY(P_0);
			}
		}
	}

	public void MusrlwucDobbeEOklRAYNPplLBQz(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			MusrlwucDobbeEOklRAYNPplLBQz(joystick, P_1);
		}
	}

	public bool htlintTFWqroATMLzSJxYDxgpFt(CustomController P_0)
	{
		if (P_0 == null || GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		for (int i = 0; i < GVDnpMSqPQqbeQSOJpfnPFIqmSK.Length; i++)
		{
			if (GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool htlintTFWqroATMLzSJxYDxgpFt(int P_0)
	{
		if (GVDnpMSqPQqbeQSOJpfnPFIqmSK == null)
		{
			return false;
		}
		for (int i = 0; i < GVDnpMSqPQqbeQSOJpfnPFIqmSK.Length; i++)
		{
			if (GVDnpMSqPQqbeQSOJpfnPFIqmSK[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool sZRejVcyWsEKSAjxvXLqCyPdCuA(int P_0, int P_1)
	{
		return lZXmlWxQPcBFEbyBUMCSggeIoJj(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void BvlCDHporsdVoEpxIfCtPLSnyCEj(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				axZDcFxfSrTzugQuesWNChisbGg.controllers.tWdfQmBPudobtUdhGKshtjyjmUgb(P_0);
			}
			for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
			{
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[i].controllers.tWdfQmBPudobtUdhGKshtjyjmUgb(P_0);
			}
		}
	}

	public void BvlCDHporsdVoEpxIfCtPLSnyCEj(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			BvlCDHporsdVoEpxIfCtPLSnyCEj(customController, P_1);
		}
	}

	private bool LcxVRiTvslTTNZZTHVecZEElKDx(Joystick P_0)
	{
		if (kEfTcVPDPtzkvdMGLfLPBGnaUJq.distributeJoysticksEvenly)
		{
			int num = tVHeaikQmtINieowCzXVzxDbLkLI();
			if (num < 0)
			{
				return false;
			}
			int num2 = hIDcUGdzUhYvDiczIUzPkBqqTAIF(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = ZUrLjGwyiHTgGgZwYqFbzzUSapK[num];
			Player player2 = ZUrLjGwyiHTgGgZwYqFbzzUSapK[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[num2].controllers.tUnghiHvJLidlTBQdQnaACAvMpOh(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = hIDcUGdzUhYvDiczIUzPkBqqTAIF(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		ZUrLjGwyiHTgGgZwYqFbzzUSapK[num3].controllers.tUnghiHvJLidlTBQdQnaACAvMpOh(P_0, true);
		return true;
	}

	private bool JMtIvWyaeimNTRqFweiGYTukBJd(Joystick P_0)
	{
		if (kEfTcVPDPtzkvdMGLfLPBGnaUJq.distributeJoysticksEvenly)
		{
			int num = tVHeaikQmtINieowCzXVzxDbLkLI();
			if (num >= 0)
			{
				ZUrLjGwyiHTgGgZwYqFbzzUSapK[num].controllers.tUnghiHvJLidlTBQdQnaACAvMpOh(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
			{
				Player player = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!kEfTcVPDPtzkvdMGLfLPBGnaUJq.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < kEfTcVPDPtzkvdMGLfLPBGnaUJq.maxJoysticksPerPlayer)
				{
					player.controllers.tUnghiHvJLidlTBQdQnaACAvMpOh(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int tVHeaikQmtINieowCzXVzxDbLkLI()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			Player player = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!kEfTcVPDPtzkvdMGLfLPBGnaUJq.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < kEfTcVPDPtzkvdMGLfLPBGnaUJq.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int hIDcUGdzUhYvDiczIUzPkBqqTAIF(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < proBRfaaKLGJXhYEdaHgFGleTmUQ; i++)
		{
			Player player = ZUrLjGwyiHTgGgZwYqFbzzUSapK[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!kEfTcVPDPtzkvdMGLfLPBGnaUJq.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < kEfTcVPDPtzkvdMGLfLPBGnaUJq.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.bjeMDwUhupEACsloaEuCzQcznzh(P_0);
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
