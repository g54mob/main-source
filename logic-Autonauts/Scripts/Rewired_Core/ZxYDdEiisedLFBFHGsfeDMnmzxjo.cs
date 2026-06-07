using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class ZxYDdEiisedLFBFHGsfeDMnmzxjo
{
	private int oLQMverzueZouXfHiXxloicHMOa;

	private int sBZFrTjdkDoSjBHzzTRTbpVBsLMf;

	private Player pzwrFDidtUvQFxBFJqTAydfXGsa;

	private Player[] XrcegCBncxnNJRLjwnrkbTVXqpW;

	private Player[] CUQyyYlDRswuhnhPbqpeBHXrSCQ;

	private IList<Player> ItnVSPbcdAlzPrskffXIxQMbPmZ;

	private IList<Player> NileBylaFCIDLAiGnxaVgarRSSB;

	private ConfigVars liMFOVAIkIPrOJivyHfIDbBCDeae;

	private bool fxzgZHdorylahBrNCBxmuceoqOgc;

	public int gamePlayerCount
	{
		get
		{
			return oLQMverzueZouXfHiXxloicHMOa;
		}
	}

	public int allPlayerCount
	{
		get
		{
			return sBZFrTjdkDoSjBHzzTRTbpVBsLMf;
		}
	}

	public Player[] AllPlayers_orig
	{
		get
		{
			return XrcegCBncxnNJRLjwnrkbTVXqpW;
		}
	}

	public Player[] Players_orig
	{
		get
		{
			return CUQyyYlDRswuhnhPbqpeBHXrSCQ;
		}
	}

	public IList<Player> AllPlayers_readOnly
	{
		get
		{
			return NileBylaFCIDLAiGnxaVgarRSSB;
		}
	}

	public IList<Player> Players_readOnly
	{
		get
		{
			return ItnVSPbcdAlzPrskffXIxQMbPmZ;
		}
	}

	public ZxYDdEiisedLFBFHGsfeDMnmzxjo(ConfigVars configVars)
	{
		liMFOVAIkIPrOJivyHfIDbBCDeae = configVars;
	}

	public void dFyvOnKBbTYzKLbxHBbiIGdcrpeH()
	{
		if (fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		Player player = default(Player);
		int num2 = default(int);
		Player_Editor player_Editor = default(Player_Editor);
		khKFGQdNkFnBHTxVFbmEvpDlEMj startingControllerMapInfo = default(khKFGQdNkFnBHTxVFbmEvpDlEMj);
		ControllerMapLayoutManager.StartingSettings controllerMapLayoutManagerSettings = default(ControllerMapLayoutManager.StartingSettings);
		ControllerMapEnabler.euPDSnhapeLdIFbRcRtnHgEFqhjZ controllerMapEnablerSettings = default(ControllerMapEnabler.euPDSnhapeLdIFbRcRtnHgEFqhjZ);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		while (true)
		{
			sBZFrTjdkDoSjBHzzTRTbpVBsLMf = ReInput.UserData.playerCount;
			int num = 1297378775;
			while (true)
			{
				switch (num ^ 0x4D546DD6)
				{
				case 0:
					num = 1297378768;
					continue;
				case 6:
					break;
				case 4:
					player = new Player(false, num2 - 1, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
					num = 1297378769;
					continue;
				case 3:
					player.isPlaying = player_Editor.startPlaying;
					player.controllers.hasMouse = player_Editor.assignMouseOnStart;
					player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
					player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
					player.controllers.maps.sxMsDfScVvJlXlEZbJzgsEiVxZA(true);
					player.controllers.maps.daBgjdJLbrPLDAHTDhWyTzFPxRbW(true);
					num2++;
					num = 1297378772;
					continue;
				case 13:
					player_Editor = players_readOnly[num2];
					num = 1297378781;
					continue;
				case 9:
					players_readOnly = ReInput.UserData.Players_readOnly;
					if (players_readOnly == null)
					{
						throw new ArgumentNullException("Players cannot be null!");
					}
					goto case 12;
				case 1:
					oLQMverzueZouXfHiXxloicHMOa = sBZFrTjdkDoSjBHzzTRTbpVBsLMf - 1;
					CUQyyYlDRswuhnhPbqpeBHXrSCQ = new Player[oLQMverzueZouXfHiXxloicHMOa];
					num = 1297378780;
					continue;
				case 5:
					player = (pzwrFDidtUvQFxBFJqTAydfXGsa = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings));
					num = 1297378777;
					continue;
				case 15:
					XrcegCBncxnNJRLjwnrkbTVXqpW[num2] = player;
					num = 1297378773;
					continue;
				case 12:
					num2 = 0;
					num = 1297378772;
					continue;
				case 11:
					startingControllerMapInfo = player_Editor.jbyopidUzyFqZzHMJudffEfyMKC();
					num = 1297378776;
					continue;
				case 2:
					if (num2 >= players_readOnly.Count)
					{
						ItnVSPbcdAlzPrskffXIxQMbPmZ = new ReadOnlyCollection<Player>(CUQyyYlDRswuhnhPbqpeBHXrSCQ);
						num = 1297378782;
						continue;
					}
					goto case 13;
				case 10:
					XrcegCBncxnNJRLjwnrkbTVXqpW = new Player[sBZFrTjdkDoSjBHzzTRTbpVBsLMf];
					num = 1297378783;
					continue;
				case 14:
				{
					controllerMapLayoutManagerSettings = player_Editor.controllerMapLayoutManagerSettings.aiqbcfAlKIAlyjPCBVtoGAgqjnJO();
					controllerMapEnablerSettings = player_Editor.controllerMapEnablerSettings.aiqbcfAlKIAlyjPCBVtoGAgqjnJO();
					int num3;
					if (num2 == 0)
					{
						num = 1297378771;
						num3 = num;
					}
					else
					{
						num = 1297378770;
						num3 = num;
					}
					continue;
				}
				case 7:
					CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2 - 1] = player;
					num = 1297378777;
					continue;
				default:
					NileBylaFCIDLAiGnxaVgarRSSB = new ReadOnlyCollection<Player>(XrcegCBncxnNJRLjwnrkbTVXqpW);
					fxzgZHdorylahBrNCBxmuceoqOgc = true;
					return;
				}
				break;
			}
		}
	}

	public void CPsrZMWBfXaFqLffSjNpAwOYCoPo(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
			return;
		}
		while (liMFOVAIkIPrOJivyHfIDbBCDeae.reassignJoystickToPreviousOwnerOnReconnect)
		{
			bool flag = CWEIOyWBLMJhkUkuwRRffBmSvFv(P_0);
			int num = 803774065;
			while (true)
			{
				switch (num ^ 0x2FE89E73)
				{
				case 0:
					num = 803774064;
					continue;
				case 3:
					break;
				case 2:
					if (flag)
					{
						return;
					}
					goto end_IL_0044;
				default:
					goto end_IL_0044;
				}
				break;
			}
			continue;
			end_IL_0044:
			break;
		}
		WTUEVnGrHBlwmCSFPyiRnuCJczrn(P_0);
	}

	public void zQsgfajurXOpIxqySqTWGGZkXLR(Joystick P_0)
	{
		if (liMFOVAIkIPrOJivyHfIDbBCDeae.autoAssignJoysticks)
		{
			CPsrZMWBfXaFqLffSjNpAwOYCoPo(P_0);
		}
	}

	public void qreHAXgTzsFHANAUbdDdmiOhyk(ControllerType P_0, int P_1)
	{
		int num = 0;
		while (num < sBZFrTjdkDoSjBHzzTRTbpVBsLMf)
		{
			while (true)
			{
				XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.RemoveController(P_0, P_1);
				num++;
				int num2 = -85915283;
				while (true)
				{
					switch (num2 ^ -85915284)
					{
					case 0:
						num2 = -85915282;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0022;
					}
					break;
				}
				continue;
				end_IL_0022:
				break;
			}
		}
	}

	public Player mGsUlCssxNPJpaIPjZSPUkhxHGhB(int P_0)
	{
		if (P_0 != 9999999)
		{
			if (P_0 < 0)
			{
				goto IL_007b;
			}
			if (P_0 >= oLQMverzueZouXfHiXxloicHMOa)
			{
				goto IL_001b;
			}
		}
		if (P_0 == 9999999)
		{
			return pzwrFDidtUvQFxBFJqTAydfXGsa;
		}
		int num = 0;
		int num2 = -1944527616;
		goto IL_0020;
		IL_0020:
		while (true)
		{
			switch (num2 ^ -1944527612)
			{
			case 7:
				break;
			case 5:
				return CUQyyYlDRswuhnhPbqpeBHXrSCQ[P_0];
			case 0:
				goto IL_0064;
			case 6:
				goto IL_007b;
			case 1:
				return null;
			case 2:
				goto IL_00b9;
			case 4:
				num2 = -1944527610;
				continue;
			default:
				return null;
			}
			break;
			IL_00b9:
			int num3;
			if (num < oLQMverzueZouXfHiXxloicHMOa)
			{
				num2 = -1944527612;
				num3 = num2;
			}
			else
			{
				num2 = -1944527609;
				num3 = num2;
			}
			continue;
			IL_0064:
			if (CUQyyYlDRswuhnhPbqpeBHXrSCQ[num].id != P_0)
			{
				num++;
				num2 = -1944527610;
			}
			else
			{
				num2 = -1944527615;
			}
		}
		goto IL_001b;
		IL_001b:
		num2 = -1944527614;
		goto IL_0020;
		IL_007b:
		Logger.LogError("Player id " + P_0 + " does not exist!");
		num2 = -1944527611;
		goto IL_0020;
	}

	public Player mGsUlCssxNPJpaIPjZSPUkhxHGhB(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (pzwrFDidtUvQFxBFJqTAydfXGsa.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return pzwrFDidtUvQFxBFJqTAydfXGsa;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= oLQMverzueZouXfHiXxloicHMOa)
				{
					num2 = -644075124;
					num3 = num2;
				}
				else
				{
					num2 = -644075122;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -644075123)
					{
					case 2:
						num2 = -644075122;
						continue;
					case 3:
						break;
					case 0:
						goto end_IL_003a;
					default:
						goto end_IL_0081;
					}
					if (CUQyyYlDRswuhnhPbqpeBHXrSCQ[num].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return CUQyyYlDRswuhnhPbqpeBHXrSCQ[num];
					}
					num++;
					num2 = -644075123;
					continue;
					end_IL_003a:
					break;
				}
				continue;
				end_IL_0081:
				break;
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player ljtfDbQTnJBHJAjJCIcaEvxvpwaG()
	{
		return pzwrFDidtUvQFxBFJqTAydfXGsa;
	}

	public int XSCtpmrqXBUIycVInefrNruehMM(string P_0)
	{
		int num;
		int num2 = default(int);
		if (P_0 != null)
		{
			if (P_0 == string.Empty)
			{
				goto IL_0010;
			}
			if (pzwrFDidtUvQFxBFJqTAydfXGsa.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				num = 406983957;
			}
			else
			{
				num2 = 0;
				num = 406983953;
			}
			goto IL_0015;
		}
		goto IL_0036;
		IL_0015:
		while (true)
		{
			switch (num ^ 0x18421511)
			{
			case 2:
				break;
			case 3:
				goto IL_0036;
			case 4:
				return 9999999;
			case 1:
				goto IL_0062;
			default:
				if (num2 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					return -1;
				}
				goto IL_0062;
			}
			break;
			IL_0062:
			if (CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2].id;
			}
			num2++;
			num = 406983953;
		}
		goto IL_0010;
		IL_0010:
		num = 406983954;
		goto IL_0015;
		IL_0036:
		return -1;
	}

	public bool pAdUIyPLGgWUUEGNZNyEKBMtlXt(int P_0)
	{
		if (P_0 != 9999999)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -1039984228;
					while (true)
					{
						switch (num ^ -1039984226)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (P_0 >= oLQMverzueZouXfHiXxloicHMOa)
						{
							num = -1039984225;
							continue;
						}
						goto IL_003c;
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return false;
		}
		goto IL_003c;
		IL_003c:
		return true;
	}

	public Player[] YFTaDyATDlpMbSTVziNheSmjFdSf(bool P_0)
	{
		int num = oLQMverzueZouXfHiXxloicHMOa;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_003c;
		IL_003c:
		Player[] array = new Player[num];
		int num2 = 0;
		int num3;
		int num4;
		if (!P_0)
		{
			num3 = -876945665;
			num4 = num3;
		}
		else
		{
			num3 = -876945666;
			num4 = num3;
		}
		goto IL_0013;
		IL_000e:
		num3 = -876945670;
		goto IL_0013;
		IL_0013:
		int num5 = default(int);
		while (true)
		{
			switch (num3 ^ -876945669)
			{
			case 6:
				break;
			case 1:
				goto IL_003c;
			case 4:
				num5 = 0;
				num3 = -876945672;
				continue;
			case 5:
				array[0] = pzwrFDidtUvQFxBFJqTAydfXGsa;
				num3 = -876945671;
				continue;
			case 0:
				array[num2 + num5] = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num5];
				num5++;
				num3 = -876945672;
				continue;
			case 2:
				num2 = 1;
				num3 = -876945665;
				continue;
			default:
				if (num5 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					return array;
				}
				goto case 0;
			}
			break;
		}
		goto IL_000e;
	}

	public string[] YpdbiuOmOQsgxEcOhfXveQbmFWh(bool P_0)
	{
		int num = oLQMverzueZouXfHiXxloicHMOa;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_003c;
		IL_003c:
		string[] array = new string[num];
		int num2 = 0;
		int num3;
		int num4;
		if (!P_0)
		{
			num3 = 1993862394;
			num4 = num3;
		}
		else
		{
			num3 = 1993862399;
			num4 = num3;
		}
		goto IL_0013;
		IL_000e:
		num3 = 1993862396;
		goto IL_0013;
		IL_0013:
		int num5 = default(int);
		while (true)
		{
			switch (num3 ^ 0x76D7ECFE)
			{
			case 6:
				break;
			case 2:
				goto IL_003c;
			case 4:
				num5 = 0;
				num3 = 1993862397;
				continue;
			case 0:
				num5++;
				num3 = 1993862397;
				continue;
			case 1:
				array[0] = pzwrFDidtUvQFxBFJqTAydfXGsa.name;
				num2 = 1;
				num3 = 1993862394;
				continue;
			case 5:
				array[num2 + num5] = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num5].name;
				num3 = 1993862398;
				continue;
			default:
				if (num5 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					return array;
				}
				goto case 5;
			}
			break;
		}
		goto IL_000e;
	}

	public string[] QLgzmRkyCnoNmpIwXoAWCqfFHSSi(bool P_0)
	{
		int num = oLQMverzueZouXfHiXxloicHMOa;
		int num4 = default(int);
		string[] array = default(string[]);
		int num3 = default(int);
		while (true)
		{
			int num2 = 2061463407;
			while (true)
			{
				switch (num2 ^ 0x7ADF6F6B)
				{
				case 3:
					break;
				case 5:
					num4 = 1;
					num2 = 2061463402;
					continue;
				case 6:
					array = new string[num];
					num4 = 0;
					if (P_0)
					{
						array[0] = pzwrFDidtUvQFxBFJqTAydfXGsa.descriptiveName;
						num2 = 2061463406;
						continue;
					}
					goto case 1;
				case 2:
					array[num4 + num3] = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num3].descriptiveName;
					num3++;
					num2 = 2061463403;
					continue;
				case 4:
					if (P_0)
					{
						num++;
						num2 = 2061463405;
						continue;
					}
					goto case 6;
				case 1:
					num3 = 0;
					num2 = 2061463403;
					continue;
				default:
					if (num3 >= oLQMverzueZouXfHiXxloicHMOa)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public int[] OsrlGCQObivPULPnIdxJGNUuYik(bool P_0)
	{
		int num = oLQMverzueZouXfHiXxloicHMOa;
		int[] array = default(int[]);
		int num5 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = -735650408;
			while (true)
			{
				switch (num2 ^ -735650403)
				{
				case 2:
					break;
				case 9:
					num2 = -735650404;
					continue;
				case 3:
					array = new int[num];
					num5 = 0;
					num2 = -735650406;
					continue;
				case 0:
					array[0] = pzwrFDidtUvQFxBFJqTAydfXGsa.id;
					num5 = 1;
					num2 = -735650411;
					continue;
				case 5:
					if (P_0)
					{
						num++;
						num2 = -735650402;
						continue;
					}
					goto case 3;
				case 4:
					array[num5 + num3] = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num3].id;
					num2 = -735650405;
					continue;
				case 8:
					num3 = 0;
					num2 = -735650412;
					continue;
				case 6:
					num3++;
					num2 = -735650404;
					continue;
				case 7:
				{
					int num4;
					if (P_0)
					{
						num2 = -735650403;
						num4 = num2;
					}
					else
					{
						num2 = -735650411;
						num4 = num2;
					}
					continue;
				}
				default:
					if (num3 >= oLQMverzueZouXfHiXxloicHMOa)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public bool LqOsIFgLyRmAdSarMBDbInCHiLI(Controller P_0)
	{
		if (P_0 == null || XrcegCBncxnNJRLjwnrkbTVXqpW == null)
		{
			return false;
		}
		return LqOsIFgLyRmAdSarMBDbInCHiLI(P_0.type, P_0.id);
	}

	public bool LqOsIFgLyRmAdSarMBDbInCHiLI(ControllerType P_0, int P_1)
	{
		if (XrcegCBncxnNJRLjwnrkbTVXqpW == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = -1339073607;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num2 ^ -1339073606)
			{
			case 0:
				break;
			case 2:
				if (XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.ContainsController(P_0, P_1))
				{
					return true;
				}
				num++;
				num2 = -1339073602;
				continue;
			case 3:
				num2 = -1339073602;
				continue;
			case 1:
				return false;
			default:
				if (num >= XrcegCBncxnNJRLjwnrkbTVXqpW.Length)
				{
					return false;
				}
				goto case 2;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num2 = -1339073605;
		goto IL_000d;
	}

	public bool woFxHwVTprBXahGtsdcXWiqeAzo(ControllerType P_0, int P_1, int P_2)
	{
		Player player = mGsUlCssxNPJpaIPjZSPUkhxHGhB(P_2);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(P_0, P_1);
	}

	public void TvLIHINEoeJcxvdLoUqvEoIiuPk(Controller P_0, bool P_1)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_003e;
		IL_0003:
		int num = 1840577791;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x6DB4FCFE)
			{
			case 4:
				break;
			case 6:
				goto IL_0035;
			case 0:
				goto IL_003e;
			case 1:
				return;
			case 3:
				num = 1840577785;
				continue;
			case 5:
				CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2].controllers.RemoveController(P_0);
				num = 1840577788;
				continue;
			case 2:
				num2++;
				num = 1840577785;
				continue;
			default:
				if (num2 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					return;
				}
				goto case 5;
			}
			break;
		}
		goto IL_0003;
		IL_003e:
		if (P_1)
		{
			pzwrFDidtUvQFxBFJqTAydfXGsa.controllers.RemoveController(P_0);
			num = 1840577784;
			goto IL_0008;
		}
		goto IL_0035;
		IL_0035:
		num2 = 0;
		num = 1840577789;
		goto IL_0008;
	}

	public void TvLIHINEoeJcxvdLoUqvEoIiuPk(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller == null)
		{
			while (true)
			{
				switch (-392899267 ^ -392899268)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		TvLIHINEoeJcxvdLoUqvEoIiuPk(controller, P_2);
	}

	public bool lbyVKQJogxdVfVUFgbcPfDTttev(Joystick P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (XrcegCBncxnNJRLjwnrkbTVXqpW == null)
			{
				goto IL_000b;
			}
			num = 0;
			num2 = -1683539067;
			goto IL_0010;
		}
		goto IL_0031;
		IL_0010:
		while (true)
		{
			switch (num2 ^ -1683539068)
			{
			case 2:
				break;
			case 3:
				goto IL_0031;
			case 0:
				goto IL_003c;
			case 4:
				return true;
			default:
				if (num >= XrcegCBncxnNJRLjwnrkbTVXqpW.Length)
				{
					return false;
				}
				goto IL_003c;
			}
			break;
			IL_003c:
			if (XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.ContainsController(P_0))
			{
				num2 = -1683539072;
				continue;
			}
			num++;
			num2 = -1683539067;
		}
		goto IL_000b;
		IL_0031:
		return false;
		IL_000b:
		num2 = -1683539065;
		goto IL_0010;
	}

	public bool lbyVKQJogxdVfVUFgbcPfDTttev(int P_0)
	{
		if (XrcegCBncxnNJRLjwnrkbTVXqpW == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = 1094188725;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num2 ^ 0x4137FEB6)
			{
			case 0:
				break;
			case 2:
				return false;
			case 1:
				if (!XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.ContainsController(ControllerType.Joystick, P_0))
				{
					goto IL_004d;
				}
				return true;
			default:
				if (num >= XrcegCBncxnNJRLjwnrkbTVXqpW.Length)
				{
					return false;
				}
				goto case 1;
			}
			break;
			IL_004d:
			num++;
			num2 = 1094188725;
		}
		goto IL_0008;
		IL_0008:
		num2 = 1094188724;
		goto IL_000d;
	}

	public bool NlZNlvekbylqgoVyDitcFrvcPPn(int P_0, int P_1)
	{
		Player player = mGsUlCssxNPJpaIPjZSPUkhxHGhB(P_1);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(ControllerType.Joystick, P_0);
	}

	public void ROTeZojMeDrvJFrNYYMFxdgOcfI(Joystick P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			IL_007a:
			int num;
			if (P_1)
			{
				pzwrFDidtUvQFxBFJqTAydfXGsa.controllers.OofrlqURwBfyXhkklkQophvJZqM(P_0);
				num = 1373609259;
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x51DF9D28)
				{
				case 6:
					num = 1373609261;
					continue;
				default:
					return;
				case 7:
					num = 1373609256;
					continue;
				case 3:
					break;
				case 0:
					goto IL_0046;
				case 2:
					CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2].controllers.OofrlqURwBfyXhkklkQophvJZqM(P_0);
					num = 1373609257;
					continue;
				case 5:
					goto IL_007a;
				case 1:
					num2++;
					num = 1373609256;
					continue;
				case 4:
					return;
				}
				break;
				IL_0046:
				int num3;
				if (num2 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					num = 1373609260;
					num3 = num;
				}
				else
				{
					num = 1373609258;
					num3 = num;
				}
			}
			goto IL_003d;
			IL_003d:
			num2 = 0;
			num = 1373609263;
			goto IL_0009;
		}
	}

	public void ROTeZojMeDrvJFrNYYMFxdgOcfI(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			ROTeZojMeDrvJFrNYYMFxdgOcfI(joystick, P_1);
		}
	}

	public bool cQIAqpWsdRbazCBsUcPweagLCntn(CustomController P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (XrcegCBncxnNJRLjwnrkbTVXqpW == null)
			{
				goto IL_000b;
			}
			num = 0;
			num2 = -2084974855;
			goto IL_0010;
		}
		goto IL_006f;
		IL_0010:
		while (true)
		{
			switch (num2 ^ -2084974854)
			{
			case 0:
				break;
			case 3:
				goto IL_0031;
			case 2:
				goto IL_004d;
			case 1:
				goto IL_006f;
			default:
				return false;
			}
			break;
			IL_004d:
			if (XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.ContainsController(P_0))
			{
				return true;
			}
			num++;
			num2 = -2084974855;
			continue;
			IL_0031:
			int num3;
			if (num >= XrcegCBncxnNJRLjwnrkbTVXqpW.Length)
			{
				num2 = -2084974850;
				num3 = num2;
			}
			else
			{
				num2 = -2084974856;
				num3 = num2;
			}
		}
		goto IL_000b;
		IL_006f:
		return false;
		IL_000b:
		num2 = -2084974853;
		goto IL_0010;
	}

	public bool cQIAqpWsdRbazCBsUcPweagLCntn(int P_0)
	{
		if (XrcegCBncxnNJRLjwnrkbTVXqpW == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = 2084983121;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num2 ^ 0x7C465152)
			{
			case 2:
				break;
			case 4:
				return false;
			case 3:
			{
				int num3;
				if (num < XrcegCBncxnNJRLjwnrkbTVXqpW.Length)
				{
					num2 = 2084983122;
					num3 = num2;
				}
				else
				{
					num2 = 2084983123;
					num3 = num2;
				}
				continue;
			}
			case 0:
				if (XrcegCBncxnNJRLjwnrkbTVXqpW[num].controllers.ContainsController(ControllerType.Custom, P_0))
				{
					return true;
				}
				num++;
				num2 = 2084983121;
				continue;
			default:
				return false;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num2 = 2084983126;
		goto IL_000d;
	}

	public bool bDajfBktJPoMlvTQSWFzgujSDcQH(int P_0, int P_1)
	{
		Player player = mGsUlCssxNPJpaIPjZSPUkhxHGhB(P_1);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(ControllerType.Custom, P_0);
	}

	public void QYWJGTwGCPsJLqXMnTOavcZUFoYe(CustomController P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			int num;
			if (P_1)
			{
				pzwrFDidtUvQFxBFJqTAydfXGsa.controllers.aUKDbmOXgEhxGqWknoZkFlKUkao(P_0);
				num = 1696221126;
				goto IL_0009;
			}
			goto IL_009a;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x651A47C3)
				{
				case 6:
					num = 1696221122;
					continue;
				default:
					return;
				case 0:
					num = 1696221120;
					continue;
				case 3:
					break;
				case 4:
					num2++;
					num = 1696221120;
					continue;
				case 7:
					CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2].controllers.aUKDbmOXgEhxGqWknoZkFlKUkao(P_0);
					num = 1696221127;
					continue;
				case 1:
					goto end_IL_0009;
				case 5:
					goto IL_009a;
				case 2:
					return;
				}
				int num3;
				if (num2 < oLQMverzueZouXfHiXxloicHMOa)
				{
					num = 1696221124;
					num3 = num;
				}
				else
				{
					num = 1696221121;
					num3 = num;
				}
				continue;
				end_IL_0009:
				break;
			}
			continue;
			IL_009a:
			num2 = 0;
			num = 1696221123;
			goto IL_0009;
		}
	}

	public void QYWJGTwGCPsJLqXMnTOavcZUFoYe(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		while (true)
		{
			switch (0x6E176E4E ^ 0x6E176E4C)
			{
			case 0:
				continue;
			case 2:
				if (customController == null)
				{
					return;
				}
				break;
			}
			break;
		}
		QYWJGTwGCPsJLqXMnTOavcZUFoYe(customController, P_1);
	}

	private bool CWEIOyWBLMJhkUkuwRRffBmSvFv(Joystick P_0)
	{
		if (liMFOVAIkIPrOJivyHfIDbBCDeae.distributeJoysticksEvenly)
		{
			goto IL_0010;
		}
		int num = qSRKgifMndiHfEhjnMdhfPNeOy(P_0.id);
		int num2 = 1262121069;
		goto IL_0015;
		IL_0015:
		int num4 = default(int);
		Player player = default(Player);
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ 0x4B3A7069)
			{
			case 3:
				break;
			case 4:
				if (num < 0)
				{
					return false;
				}
				CUQyyYlDRswuhnhPbqpeBHXrSCQ[num].controllers.smUkDayiHihrGSbHIdshwNmKRmC(P_0, true);
				num2 = 1262121068;
				continue;
			case 6:
				return false;
			case 0:
				if (num4 < 0)
				{
					return false;
				}
				player = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num3];
				num2 = 1262121064;
				continue;
			case 1:
			{
				Player player2 = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num4];
				if (num4 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
				{
					CUQyyYlDRswuhnhPbqpeBHXrSCQ[num4].controllers.smUkDayiHihrGSbHIdshwNmKRmC(P_0, true);
					return true;
				}
				return false;
			}
			case 2:
				num3 = aNurqkBPeOTCBdZaUNMWRMYOWrP();
				if (num3 >= 0)
				{
					num4 = qSRKgifMndiHfEhjnMdhfPNeOy(P_0.id);
					num2 = 1262121065;
				}
				else
				{
					num2 = 1262121071;
				}
				continue;
			default:
				return true;
			}
			break;
		}
		goto IL_0010;
		IL_0010:
		num2 = 1262121067;
		goto IL_0015;
	}

	private bool WTUEVnGrHBlwmCSFPyiRnuCJczrn(Joystick P_0)
	{
		if (liMFOVAIkIPrOJivyHfIDbBCDeae.distributeJoysticksEvenly)
		{
			int num = aNurqkBPeOTCBdZaUNMWRMYOWrP();
			if (num >= 0)
			{
				CUQyyYlDRswuhnhPbqpeBHXrSCQ[num].controllers.smUkDayiHihrGSbHIdshwNmKRmC(P_0, true);
				return true;
			}
		}
		else
		{
			int num2 = 0;
			Player player = default(Player);
			while (true)
			{
				int num3;
				int num4;
				if (num2 >= oLQMverzueZouXfHiXxloicHMOa)
				{
					num3 = 1881600398;
					num4 = num3;
				}
				else
				{
					num3 = 1881600397;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x7026F18C)
					{
					case 0:
						num3 = 1881600397;
						continue;
					case 1:
						break;
					case 4:
						goto end_IL_003a;
					case 3:
						goto IL_00aa;
					default:
						goto end_IL_0090;
					}
					player = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num2];
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						if (!liMFOVAIkIPrOJivyHfIDbBCDeae.assignJoysticksToPlayingPlayersOnly)
						{
							goto IL_00aa;
						}
						if (player.isPlaying)
						{
							num3 = 1881600399;
							continue;
						}
					}
					goto IL_00d1;
					IL_00aa:
					if (player.controllers.joystickCount < liMFOVAIkIPrOJivyHfIDbBCDeae.maxJoysticksPerPlayer)
					{
						player.controllers.smUkDayiHihrGSbHIdshwNmKRmC(P_0, true);
						return true;
					}
					goto IL_00d1;
					IL_00d1:
					num2++;
					num3 = 1881600392;
					continue;
					end_IL_003a:
					break;
				}
				continue;
				end_IL_0090:
				break;
			}
		}
		return false;
	}

	private int aNurqkBPeOTCBdZaUNMWRMYOWrP()
	{
		int num = -1;
		int num2 = 0;
		int num3 = 0;
		Player player = default(Player);
		int joystickCount = default(int);
		while (true)
		{
			int num4 = 471280299;
			while (true)
			{
				switch (num4 ^ 0x1C172AA3)
				{
				case 6:
					break;
				case 8:
					num4 = 471280292;
					continue;
				case 2:
				{
					int num6;
					if (!player.isPlaying)
					{
						num4 = 471280294;
						num6 = num4;
					}
					else
					{
						num4 = 471280288;
						num6 = num4;
					}
					continue;
				}
				case 3:
					joystickCount = player.controllers.joystickCount;
					if (joystickCount >= liMFOVAIkIPrOJivyHfIDbBCDeae.maxJoysticksPerPlayer)
					{
						goto case 5;
					}
					if (num != -1)
					{
						int num7;
						if (joystickCount >= num2)
						{
							num4 = 471280294;
							num7 = num4;
						}
						else
						{
							num4 = 471280295;
							num7 = num4;
						}
						continue;
					}
					goto case 4;
				case 5:
					num3++;
					num4 = 471280292;
					continue;
				case 4:
					num = num3;
					num4 = 471280291;
					continue;
				case 0:
					num2 = joystickCount;
					num4 = 471280294;
					continue;
				case 1:
					player = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num3];
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						int num5;
						if (liMFOVAIkIPrOJivyHfIDbBCDeae.assignJoysticksToPlayingPlayersOnly)
						{
							num4 = 471280289;
							num5 = num4;
						}
						else
						{
							num4 = 471280288;
							num5 = num4;
						}
						continue;
					}
					goto case 5;
				default:
					if (num3 >= oLQMverzueZouXfHiXxloicHMOa)
					{
						return num;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public int qSRKgifMndiHfEhjnMdhfPNeOy(int P_0)
	{
		int num = -1;
		float num2 = 0f;
		int num3 = 0;
		Player player = default(Player);
		float num7 = default(float);
		while (true)
		{
			int num4;
			int num5;
			if (num3 >= oLQMverzueZouXfHiXxloicHMOa)
			{
				num4 = -1236201520;
				num5 = num4;
			}
			else
			{
				num4 = -1236201518;
				num5 = num4;
			}
			while (true)
			{
				switch (num4 ^ -1236201517)
				{
				case 7:
					num4 = -1236201518;
					continue;
				case 1:
				{
					player = CUQyyYlDRswuhnhPbqpeBHXrSCQ[num3];
					int num8;
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						num4 = -1236201519;
						num8 = num4;
					}
					else
					{
						num4 = -1236201513;
						num8 = num4;
					}
					continue;
				}
				case 2:
					if (liMFOVAIkIPrOJivyHfIDbBCDeae.assignJoysticksToPlayingPlayersOnly)
					{
						int num6;
						if (!player.isPlaying)
						{
							num4 = -1236201513;
							num6 = num4;
						}
						else
						{
							num4 = -1236201517;
							num6 = num4;
						}
						continue;
					}
					goto case 0;
				case 0:
					if (player.controllers.joystickCount < liMFOVAIkIPrOJivyHfIDbBCDeae.maxJoysticksPerPlayer)
					{
						num7 = player.controllers.mJZwByThJOFSfjEZTDKBAZbEcZfE(P_0);
						if (!(num7 < 0f))
						{
							if (num >= 0)
							{
								int num9;
								if (num7 > num2)
								{
									num4 = -1236201514;
									num9 = num4;
								}
								else
								{
									num4 = -1236201513;
									num9 = num4;
								}
								continue;
							}
							goto case 5;
						}
					}
					goto case 4;
				case 4:
					num3++;
					num4 = -1236201515;
					continue;
				case 5:
					num2 = num7;
					num = num3;
					num4 = -1236201513;
					continue;
				case 6:
					break;
				default:
					return num;
				}
				break;
			}
		}
	}
}
