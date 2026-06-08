using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class aQEMIPEePyEmScvmvEQnOdVcwpE
{
	private int NPHursLHMwvEpcuCSsqwqwQpePh;

	private int NUXChAVPUPTEakaAuaOCxJptIqt;

	private Player MygLWGQkYMlaCWNgMpVVoHBQzXT;

	private Player[] qvqfVZrkTxcyUktMvGSrxgpUdhl;

	private Player[] xtEeJJTUgeBnwYmgqEBvHevmpPf;

	private IList<Player> rQxjWNBGGraOZOVoRqNknkcHxcn;

	private IList<Player> ghvkHzHgiEHCWixxwLPGbiPAlDmO;

	private ConfigVars MgGtJKaHLSyjHLoGfGQLvKxEfrJ;

	private bool UUnypIIfQihusKKsRGbhsEYxCLL;

	public int gamePlayerCount => NPHursLHMwvEpcuCSsqwqwQpePh;

	public int allPlayerCount => NUXChAVPUPTEakaAuaOCxJptIqt;

	public Player[] AllPlayers_orig => qvqfVZrkTxcyUktMvGSrxgpUdhl;

	public Player[] Players_orig => xtEeJJTUgeBnwYmgqEBvHevmpPf;

	public IList<Player> AllPlayers_readOnly => ghvkHzHgiEHCWixxwLPGbiPAlDmO;

	public IList<Player> Players_readOnly => rQxjWNBGGraOZOVoRqNknkcHxcn;

	public aQEMIPEePyEmScvmvEQnOdVcwpE(ConfigVars configVars)
	{
		MgGtJKaHLSyjHLoGfGQLvKxEfrJ = configVars;
	}

	public void SdmfoteCDVoXNaSlWEvRMBbwmDy()
	{
		if (UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			return;
		}
		Player player = default(Player);
		int num2 = default(int);
		Player_Editor player_Editor = default(Player_Editor);
		NdAxeLDWXXGREuIaIVGNrwziLyY startingControllerMapInfo = default(NdAxeLDWXXGREuIaIVGNrwziLyY);
		ControllerMapLayoutManager.StartingSettings controllerMapLayoutManagerSettings = default(ControllerMapLayoutManager.StartingSettings);
		ControllerMapEnabler.DsPdjyUGWkefBITeOKEcuyqvmdo controllerMapEnablerSettings = default(ControllerMapEnabler.DsPdjyUGWkefBITeOKEcuyqvmdo);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		while (true)
		{
			NUXChAVPUPTEakaAuaOCxJptIqt = ReInput.UserData.playerCount;
			int num = 1114368773;
			while (true)
			{
				switch (num ^ 0x426BEB03)
				{
				case 10:
					num = 1114368770;
					continue;
				case 9:
					player = new Player(isSystem: false, num2 - 1, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
					xtEeJJTUgeBnwYmgqEBvHevmpPf[num2 - 1] = player;
					num = 1114368775;
					continue;
				case 3:
					player = (MygLWGQkYMlaCWNgMpVVoHBQzXT = new Player(isSystem: true, 9999999, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings));
					num = 1114368775;
					continue;
				case 4:
					qvqfVZrkTxcyUktMvGSrxgpUdhl[num2] = player;
					num = 1114368769;
					continue;
				case 11:
					player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
					player.controllers.maps.NzCeJigeudJAQjUkkwwdliYCvkvk(true);
					player.controllers.maps.OXNUGodCXnCCWaFicpLlbufwEAM(true);
					num2++;
					num = 1114368779;
					continue;
				case 1:
					break;
				case 6:
					NPHursLHMwvEpcuCSsqwqwQpePh = NUXChAVPUPTEakaAuaOCxJptIqt - 1;
					xtEeJJTUgeBnwYmgqEBvHevmpPf = new Player[NPHursLHMwvEpcuCSsqwqwQpePh];
					num = 1114368774;
					continue;
				case 7:
					num2 = 0;
					num = 1114368779;
					continue;
				case 8:
				{
					int num4;
					if (num2 < players_readOnly.Count)
					{
						num = 1114368771;
						num4 = num;
					}
					else
					{
						num = 1114368783;
						num4 = num;
					}
					continue;
				}
				case 2:
					player.isPlaying = player_Editor.startPlaying;
					player.controllers.hasMouse = player_Editor.assignMouseOnStart;
					player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
					num = 1114368776;
					continue;
				case 0:
				{
					player_Editor = players_readOnly[num2];
					startingControllerMapInfo = player_Editor.GdayHkNEleVQjMNyFALelYwfJLv();
					controllerMapLayoutManagerSettings = player_Editor.controllerMapLayoutManagerSettings.VAqTUwRbJIeTdanGWWozEUgsoBs();
					controllerMapEnablerSettings = player_Editor.controllerMapEnablerSettings.VAqTUwRbJIeTdanGWWozEUgsoBs();
					int num3;
					if (num2 != 0)
					{
						num = 1114368778;
						num3 = num;
					}
					else
					{
						num = 1114368768;
						num3 = num;
					}
					continue;
				}
				case 5:
					qvqfVZrkTxcyUktMvGSrxgpUdhl = new Player[NUXChAVPUPTEakaAuaOCxJptIqt];
					players_readOnly = ReInput.UserData.Players_readOnly;
					if (players_readOnly == null)
					{
						throw new ArgumentNullException("Players cannot be null!");
					}
					goto case 7;
				default:
					rQxjWNBGGraOZOVoRqNknkcHxcn = new ReadOnlyCollection<Player>(xtEeJJTUgeBnwYmgqEBvHevmpPf);
					ghvkHzHgiEHCWixxwLPGbiPAlDmO = new ReadOnlyCollection<Player>(qvqfVZrkTxcyUktMvGSrxgpUdhl);
					UUnypIIfQihusKKsRGbhsEYxCLL = true;
					return;
				}
				break;
			}
		}
	}

	public void rLadaVaiWVUKvuGILgeiscwRnpq(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
			return;
		}
		while (MgGtJKaHLSyjHLoGfGQLvKxEfrJ.reassignJoystickToPreviousOwnerOnReconnect)
		{
			bool flag = xdWcjzeuqEdWtVdZnaaqFrhfPcOJ(P_0);
			int num = -510467199;
			while (true)
			{
				switch (num ^ -510467197)
				{
				case 3:
					num = -510467198;
					continue;
				case 1:
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
		zMAwNiPawVlOxlcyYVAMefoIkQU(P_0);
	}

	public void OJyGtzSbKHgFXJYPNuiBAYnpEqg(Joystick P_0)
	{
		if (MgGtJKaHLSyjHLoGfGQLvKxEfrJ.autoAssignJoysticks)
		{
			rLadaVaiWVUKvuGILgeiscwRnpq(P_0);
		}
	}

	public void JfhtXHzUivDvEfCtJoOItmIJvaZ(ControllerType P_0, int P_1)
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < NUXChAVPUPTEakaAuaOCxJptIqt)
			{
				num2 = -784549762;
				num3 = num2;
			}
			else
			{
				num2 = -784549761;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -784549764)
				{
				case 0:
					num2 = -784549762;
					continue;
				default:
					return;
				case 2:
					qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.RemoveController(P_0, P_1);
					num2 = -784549768;
					continue;
				case 1:
					break;
				case 4:
					num++;
					num2 = -784549763;
					continue;
				case 3:
					return;
				}
				break;
			}
		}
	}

	public Player LwwGNDEKhVGiAVsVapAOKLGgPGB(int P_0)
	{
		if (P_0 != 9999999)
		{
			goto IL_000b;
		}
		goto IL_00ab;
		IL_000b:
		int num = 744306993;
		goto IL_0010;
		IL_0010:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x2C5D3930)
			{
			case 0:
				break;
			case 1:
				goto IL_003c;
			case 6:
				goto IL_0051;
			case 2:
				Logger.LogError("Player id " + P_0 + " does not exist!");
				num = 744306997;
				continue;
			case 4:
				goto IL_0082;
			case 5:
				return null;
			default:
				if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
				{
					return null;
				}
				goto IL_0082;
			}
			break;
			IL_0082:
			if (xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].id == P_0)
			{
				return xtEeJJTUgeBnwYmgqEBvHevmpPf[P_0];
			}
			num2++;
			num = 744306995;
			continue;
			IL_0051:
			if (P_0 >= NPHursLHMwvEpcuCSsqwqwQpePh)
			{
				num = 744306994;
				continue;
			}
			goto IL_00ab;
			IL_003c:
			int num3;
			if (P_0 >= 0)
			{
				num = 744306998;
				num3 = num;
			}
			else
			{
				num = 744306994;
				num3 = num;
			}
		}
		goto IL_000b;
		IL_00ab:
		if (P_0 == 9999999)
		{
			return MygLWGQkYMlaCWNgMpVVoHBQzXT;
		}
		num2 = 0;
		num = 744306995;
		goto IL_0010;
	}

	public Player LwwGNDEKhVGiAVsVapAOKLGgPGB(string P_0)
	{
		if (P_0 != null)
		{
			int num2 = default(int);
			while (true)
			{
				int num = -388943560;
				while (true)
				{
					switch (num ^ -388943555)
					{
					case 0:
						break;
					case 2:
						goto IL_003b;
					case 6:
						goto IL_0065;
					case 5:
						goto IL_0080;
					case 4:
						goto IL_00a1;
					case 7:
						num = -388943559;
						continue;
					case 3:
						return MygLWGQkYMlaCWNgMpVVoHBQzXT;
					default:
						goto end_IL_0006;
					}
					break;
					IL_00a1:
					int num3;
					if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						num = -388943556;
						num3 = num;
					}
					else
					{
						num = -388943553;
						num3 = num;
					}
					continue;
					IL_0065:
					if (MygLWGQkYMlaCWNgMpVVoHBQzXT.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						num = -388943554;
						continue;
					}
					num2 = 0;
					num = -388943558;
					continue;
					IL_003b:
					if (xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return xtEeJJTUgeBnwYmgqEBvHevmpPf[num2];
					}
					num2++;
					num = -388943559;
					continue;
					IL_0080:
					int num4;
					if (P_0 == string.Empty)
					{
						num = -388943556;
						num4 = num;
					}
					else
					{
						num = -388943557;
						num4 = num;
					}
				}
				continue;
				end_IL_0006:
				break;
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player SJbqFeuTGPOUMrjgHHxfbLJovAZ()
	{
		return MygLWGQkYMlaCWNgMpVVoHBQzXT;
	}

	public int qSEOrEDcNqVnzNvwEWwOHIpkHbA(string P_0)
	{
		if (P_0 != null)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1285635550;
				while (true)
				{
					switch (num ^ 0x4CA13DDA)
					{
					case 0:
						break;
					case 4:
						goto IL_0029;
					case 1:
						goto end_IL_0003;
					case 3:
						goto IL_0062;
					default:
						if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
						{
							return -1;
						}
						goto IL_0062;
					}
					break;
					IL_0062:
					if (xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].id;
					}
					num2++;
					num = 1285635544;
					continue;
					IL_0029:
					if (P_0 == string.Empty)
					{
						num = 1285635547;
						continue;
					}
					if (MygLWGQkYMlaCWNgMpVVoHBQzXT.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return 9999999;
					}
					num2 = 0;
					num = 1285635544;
				}
				continue;
				end_IL_0003:
				break;
			}
		}
		return -1;
	}

	public bool IBtfhptRpkxJLxquIWDLWUiaeKE(int P_0)
	{
		if (P_0 != 9999999)
		{
			while (true)
			{
				int num = -1458727427;
				while (true)
				{
					switch (num ^ -1458727425)
					{
					case 0:
						break;
					case 2:
						if (P_0 >= 0)
						{
							goto IL_002a;
						}
						goto default;
					default:
						return false;
					}
					break;
					IL_002a:
					if (P_0 < NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						goto end_IL_0008;
					}
					num = -1458727426;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		return true;
	}

	public Player[] dDDalbxytdZwyugUekPoOQWOwop(bool P_0)
	{
		int num = NPHursLHMwvEpcuCSsqwqwQpePh;
		int num3 = default(int);
		Player[] array = default(Player[]);
		int num5 = default(int);
		while (true)
		{
			int num2 = -937884583;
			while (true)
			{
				switch (num2 ^ -937884592)
				{
				case 8:
					break;
				case 1:
					num3++;
					num2 = -937884586;
					continue;
				case 7:
					array = new Player[num];
					num2 = -937884592;
					continue;
				case 2:
					num3 = 0;
					num2 = -937884586;
					continue;
				case 3:
					array[num5 + num3] = xtEeJJTUgeBnwYmgqEBvHevmpPf[num3];
					num2 = -937884591;
					continue;
				case 9:
					if (P_0)
					{
						num++;
						num2 = -937884585;
						continue;
					}
					goto case 7;
				case 0:
					num5 = 0;
					num2 = -937884588;
					continue;
				case 4:
					if (P_0)
					{
						array[0] = MygLWGQkYMlaCWNgMpVVoHBQzXT;
						num5 = 1;
						num2 = -937884590;
						continue;
					}
					goto case 2;
				case 6:
				{
					int num4;
					if (num3 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						num2 = -937884587;
						num4 = num2;
					}
					else
					{
						num2 = -937884589;
						num4 = num2;
					}
					continue;
				}
				default:
					return array;
				}
				break;
			}
		}
	}

	public string[] jOrfQfojbAHbmHjpgeiwpmTrtHSJ(bool P_0)
	{
		int num = NPHursLHMwvEpcuCSsqwqwQpePh;
		if (P_0)
		{
			goto IL_000a;
		}
		goto IL_0072;
		IL_000a:
		int num2 = -1660482260;
		goto IL_000f;
		IL_000f:
		int num4 = default(int);
		string[] array = default(string[]);
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -1660482264)
			{
			case 5:
				break;
			case 4:
				num++;
				num2 = -1660482261;
				continue;
			case 2:
				num4 = 1;
				num2 = -1660482263;
				continue;
			case 0:
				array[num4 + num3] = xtEeJJTUgeBnwYmgqEBvHevmpPf[num3].name;
				num3++;
				num2 = -1660482258;
				continue;
			case 1:
				goto IL_0069;
			case 3:
				goto IL_0072;
			default:
				if (num3 >= NPHursLHMwvEpcuCSsqwqwQpePh)
				{
					return array;
				}
				goto case 0;
			}
			break;
		}
		goto IL_000a;
		IL_0069:
		num3 = 0;
		num2 = -1660482258;
		goto IL_000f;
		IL_0072:
		array = new string[num];
		num4 = 0;
		if (P_0)
		{
			array[0] = MygLWGQkYMlaCWNgMpVVoHBQzXT.name;
			num2 = -1660482262;
			goto IL_000f;
		}
		goto IL_0069;
	}

	public string[] lJqTfOWvHvWdpYHOOvDXEDLIHwt(bool P_0)
	{
		int num = NPHursLHMwvEpcuCSsqwqwQpePh;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_0069;
		IL_0069:
		string[] array = new string[num];
		int num2 = -176654305;
		goto IL_0013;
		IL_000e:
		num2 = -176654311;
		goto IL_0013;
		IL_0013:
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			switch (num2 ^ -176654305)
			{
			case 5:
				break;
			case 4:
				num2 = -176654306;
				continue;
			case 3:
				num3 = 0;
				num2 = -176654309;
				continue;
			case 2:
				array[num4 + num3] = xtEeJJTUgeBnwYmgqEBvHevmpPf[num3].descriptiveName;
				num3++;
				num2 = -176654306;
				continue;
			case 6:
				goto IL_0069;
			case 0:
				num4 = 0;
				if (P_0)
				{
					array[0] = MygLWGQkYMlaCWNgMpVVoHBQzXT.descriptiveName;
					num4 = 1;
					num2 = -176654308;
					continue;
				}
				goto case 3;
			default:
				if (num3 >= NPHursLHMwvEpcuCSsqwqwQpePh)
				{
					return array;
				}
				goto case 2;
			}
			break;
		}
		goto IL_000e;
	}

	public int[] frvGAVyFEksoXubEPwACMkmjoXL(bool P_0)
	{
		int num = NPHursLHMwvEpcuCSsqwqwQpePh;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_0034;
		IL_0074:
		int num2 = 0;
		int num3 = 277115420;
		goto IL_0013;
		IL_000e:
		num3 = 277115421;
		goto IL_0013;
		IL_0013:
		int[] array = default(int[]);
		int num4 = default(int);
		while (true)
		{
			switch (num3 ^ 0x1084721E)
			{
			case 4:
				break;
			case 3:
				goto IL_0034;
			case 1:
				array[num4 + num2] = xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].id;
				num2++;
				num3 = 277115420;
				continue;
			case 0:
				goto IL_0074;
			default:
				if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
				{
					return array;
				}
				goto case 1;
			}
			break;
		}
		goto IL_000e;
		IL_0034:
		array = new int[num];
		num4 = 0;
		if (P_0)
		{
			array[0] = MygLWGQkYMlaCWNgMpVVoHBQzXT.id;
			num4 = 1;
			num3 = 277115422;
			goto IL_0013;
		}
		goto IL_0074;
	}

	public bool uuChLUKXPXhvadoSFWyqGXcYaWr(Controller P_0)
	{
		if (P_0 != null)
		{
			while (true)
			{
				int num = -1878212499;
				while (true)
				{
					switch (num ^ -1878212500)
					{
					case 2:
						break;
					case 1:
						goto IL_0021;
					default:
						goto end_IL_0003;
					}
					break;
					IL_0021:
					if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
					{
						num = -1878212500;
						continue;
					}
					return uuChLUKXPXhvadoSFWyqGXcYaWr(P_0.type, P_0.id);
				}
				continue;
				end_IL_0003:
				break;
			}
		}
		return false;
	}

	public bool uuChLUKXPXhvadoSFWyqGXcYaWr(ControllerType P_0, int P_1)
	{
		if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < qvqfVZrkTxcyUktMvGSrxgpUdhl.Length)
			{
				num2 = 94640422;
				num3 = num2;
			}
			else
			{
				num2 = 94640420;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x5A41927)
				{
				case 2:
					num2 = 94640422;
					continue;
				case 1:
					if (qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.ContainsController(P_0, P_1))
					{
						return true;
					}
					num++;
					num2 = 94640423;
					continue;
				case 0:
					break;
				default:
					return false;
				}
				break;
			}
		}
	}

	public bool NnHfMvjJAnZEhWplfbSEfCMxYDR(ControllerType P_0, int P_1, int P_2)
	{
		return LwwGNDEKhVGiAVsVapAOKLGgPGB(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void iuZLrBzGFyvlgUxeviNoOPgtzSJ(Controller P_0, bool P_1)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_003c;
		IL_0003:
		int num = 1580351926;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x5E3241B4)
			{
			case 3:
				break;
			case 1:
				num2++;
				num = 1580351922;
				continue;
			case 4:
				goto IL_003c;
			case 5:
				xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].controllers.RemoveController(P_0);
				num = 1580351925;
				continue;
			case 2:
				return;
			case 0:
				goto IL_0079;
			default:
				if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
				{
					return;
				}
				goto case 5;
			}
			break;
		}
		goto IL_0003;
		IL_0079:
		num2 = 0;
		num = 1580351922;
		goto IL_0008;
		IL_003c:
		if (P_1)
		{
			MygLWGQkYMlaCWNgMpVVoHBQzXT.controllers.RemoveController(P_0);
			num = 1580351924;
			goto IL_0008;
		}
		goto IL_0079;
	}

	public void iuZLrBzGFyvlgUxeviNoOPgtzSJ(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller == null)
		{
			goto IL_0010;
		}
		goto IL_003a;
		IL_0010:
		int num = -590459067;
		goto IL_0015;
		IL_0015:
		switch (num ^ -590459068)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			return;
		case 0:
			goto IL_003a;
		case 2:
			return;
		}
		goto IL_0010;
		IL_003a:
		iuZLrBzGFyvlgUxeviNoOPgtzSJ(controller, P_2);
		num = -590459066;
		goto IL_0015;
	}

	public bool QieAqBkpTdqkilefxFMYCnvJkkWI(Joystick P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
			{
				goto IL_000b;
			}
			num = 0;
			num2 = -539276524;
			goto IL_0010;
		}
		goto IL_0031;
		IL_0010:
		while (true)
		{
			switch (num2 ^ -539276521)
			{
			case 2:
				break;
			case 4:
				goto IL_0031;
			case 0:
				goto IL_003c;
			case 3:
				num2 = -539276522;
				continue;
			default:
				if (num >= qvqfVZrkTxcyUktMvGSrxgpUdhl.Length)
				{
					return false;
				}
				goto IL_003c;
			}
			break;
			IL_003c:
			if (qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.ContainsController(P_0))
			{
				return true;
			}
			num++;
			num2 = -539276522;
		}
		goto IL_000b;
		IL_0031:
		return false;
		IL_000b:
		num2 = -539276525;
		goto IL_0010;
	}

	public bool QieAqBkpTdqkilefxFMYCnvJkkWI(int P_0)
	{
		if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < qvqfVZrkTxcyUktMvGSrxgpUdhl.Length)
			{
				num2 = 1611994428;
				num3 = num2;
			}
			else
			{
				num2 = 1611994430;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x6015153D)
				{
				case 2:
					num2 = 1611994428;
					continue;
				case 1:
					if (qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.ContainsController(ControllerType.Joystick, P_0))
					{
						return true;
					}
					num++;
					num2 = 1611994429;
					continue;
				case 0:
					break;
				default:
					return false;
				}
				break;
			}
		}
	}

	public bool khHQWaSXMsvHxRVuOCZxHVYrGxY(int P_0, int P_1)
	{
		Player player = LwwGNDEKhVGiAVsVapAOKLGgPGB(P_1);
		while (true)
		{
			int num = 1099370678;
			while (true)
			{
				switch (num ^ 0x418710B7)
				{
				case 0:
					break;
				case 1:
					if (player == null)
					{
						goto IL_0029;
					}
					return player.controllers.ContainsController(ControllerType.Joystick, P_0);
				default:
					return false;
				}
				break;
				IL_0029:
				num = 1099370677;
			}
		}
	}

	public void atTKHbDpLNgsWakgJGjYrOGBisbf(Joystick P_0, bool P_1)
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
				MygLWGQkYMlaCWNgMpVVoHBQzXT.controllers.bkhdMfmQPHfhCGcFctvlbKVAspb(P_0);
				num = 486886438;
				goto IL_0009;
			}
			goto IL_004d;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x1D054C23)
				{
				case 0:
					num = 486886434;
					continue;
				case 1:
					break;
				case 5:
					goto IL_004d;
				case 3:
					num2++;
					num = 486886439;
					continue;
				case 6:
					xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].controllers.bkhdMfmQPHfhCGcFctvlbKVAspb(P_0);
					num = 486886432;
					continue;
				case 2:
					num = 486886439;
					continue;
				default:
					if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						return;
					}
					goto case 6;
				}
				break;
			}
			continue;
			IL_004d:
			num2 = 0;
			num = 486886433;
			goto IL_0009;
		}
	}

	public void atTKHbDpLNgsWakgJGjYrOGBisbf(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		while (true)
		{
			switch (0x4A599597 ^ 0x4A599596)
			{
			case 0:
				continue;
			case 1:
				if (joystick == null)
				{
					return;
				}
				break;
			}
			break;
		}
		atTKHbDpLNgsWakgJGjYrOGBisbf(joystick, P_1);
	}

	public bool TuGOPoiOKXbzulXNZumfijMOzoI(CustomController P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
			{
				goto IL_000b;
			}
			num = 0;
			num2 = 51618125;
			goto IL_0010;
		}
		goto IL_005a;
		IL_0010:
		while (true)
		{
			switch (num2 ^ 0x313A14D)
			{
			case 4:
				break;
			case 2:
				return true;
			case 1:
				goto IL_003e;
			case 3:
				goto IL_005a;
			default:
				if (num >= qvqfVZrkTxcyUktMvGSrxgpUdhl.Length)
				{
					return false;
				}
				goto IL_003e;
			}
			break;
			IL_003e:
			if (!qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.ContainsController(P_0))
			{
				num++;
				num2 = 51618125;
			}
			else
			{
				num2 = 51618127;
			}
		}
		goto IL_000b;
		IL_005a:
		return false;
		IL_000b:
		num2 = 51618126;
		goto IL_0010;
	}

	public bool TuGOPoiOKXbzulXNZumfijMOzoI(int P_0)
	{
		if (qvqfVZrkTxcyUktMvGSrxgpUdhl == null)
		{
			return false;
		}
		int num = 0;
		while (num < qvqfVZrkTxcyUktMvGSrxgpUdhl.Length)
		{
			while (true)
			{
				if (qvqfVZrkTxcyUktMvGSrxgpUdhl[num].controllers.ContainsController(ControllerType.Custom, P_0))
				{
					return true;
				}
				num++;
				int num2 = 314286342;
				while (true)
				{
					switch (num2 ^ 0x12BBA107)
					{
					case 0:
						num2 = 314286341;
						continue;
					case 2:
						break;
					default:
						goto end_IL_002c;
					}
					break;
				}
				continue;
				end_IL_002c:
				break;
			}
		}
		return false;
	}

	public bool UboYCMBvmTXjgcxxJmCaynZNlDr(int P_0, int P_1)
	{
		return LwwGNDEKhVGiAVsVapAOKLGgPGB(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void lUIddKOZzHEfCFUzonMtlUhLxNv(CustomController P_0, bool P_1)
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
				MygLWGQkYMlaCWNgMpVVoHBQzXT.controllers.DWWXsjaPmOBkVDVbcwVtOBPDVdXv(P_0);
				num = 608974634;
				goto IL_0009;
			}
			goto IL_0063;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x244C372F)
				{
				case 3:
					num = 608974637;
					continue;
				case 2:
					break;
				case 0:
					xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].controllers.DWWXsjaPmOBkVDVbcwVtOBPDVdXv(P_0);
					num = 608974638;
					continue;
				case 5:
					goto IL_0063;
				case 1:
					num2++;
					num = 608974635;
					continue;
				default:
					if (num2 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			continue;
			IL_0063:
			num2 = 0;
			num = 608974635;
			goto IL_0009;
		}
	}

	public void lUIddKOZzHEfCFUzonMtlUhLxNv(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			lUIddKOZzHEfCFUzonMtlUhLxNv(customController, P_1);
		}
	}

	private bool xdWcjzeuqEdWtVdZnaaqFrhfPcOJ(Joystick P_0)
	{
		int num = default(int);
		int num2 = default(int);
		int num3;
		int num4 = default(int);
		if (MgGtJKaHLSyjHLoGfGQLvKxEfrJ.distributeJoysticksEvenly)
		{
			num = HUuwIfzksOtUGYgiFGcPkLwTtZgP();
			if (num < 0)
			{
				goto IL_001b;
			}
			num2 = FhkTqRAVISruhOsrgMGPpyBGorj(P_0.id);
			num3 = -1265946225;
		}
		else
		{
			num4 = FhkTqRAVISruhOsrgMGPpyBGorj(P_0.id);
			num3 = -1265946227;
		}
		goto IL_0020;
		IL_001b:
		num3 = -1265946230;
		goto IL_0020;
		IL_0020:
		while (true)
		{
			switch (num3 ^ -1265946226)
			{
			case 0:
				break;
			case 3:
				if (num4 < 0)
				{
					num3 = -1265946228;
					continue;
				}
				xtEeJJTUgeBnwYmgqEBvHevmpPf[num4].controllers.HTKzJtWKDmkqZbNAPiKgDorFSCpp(P_0, true);
				return true;
			case 5:
				xtEeJJTUgeBnwYmgqEBvHevmpPf[num2].controllers.HTKzJtWKDmkqZbNAPiKgDorFSCpp(P_0, true);
				return true;
			case 1:
			{
				if (num2 < 0)
				{
					return false;
				}
				Player player = xtEeJJTUgeBnwYmgqEBvHevmpPf[num];
				Player player2 = xtEeJJTUgeBnwYmgqEBvHevmpPf[num2];
				if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
				{
					num3 = -1265946229;
					continue;
				}
				return false;
			}
			case 4:
				return false;
			default:
				return false;
			}
			break;
		}
		goto IL_001b;
	}

	private bool zMAwNiPawVlOxlcyYVAMefoIkQU(Joystick P_0)
	{
		int num = default(int);
		if (MgGtJKaHLSyjHLoGfGQLvKxEfrJ.distributeJoysticksEvenly)
		{
			num = HUuwIfzksOtUGYgiFGcPkLwTtZgP();
			if (num >= 0)
			{
				goto IL_001e;
			}
			goto IL_0141;
		}
		int num2 = 0;
		int num3 = 763941151;
		goto IL_0023;
		IL_0141:
		return false;
		IL_0023:
		Player player = default(Player);
		while (true)
		{
			switch (num3 ^ 0x2D88D11F)
			{
			case 5:
				break;
			case 2:
				goto IL_005f;
			case 6:
				goto IL_0076;
			case 7:
				xtEeJJTUgeBnwYmgqEBvHevmpPf[num].controllers.HTKzJtWKDmkqZbNAPiKgDorFSCpp(P_0, true);
				num3 = 763941150;
				continue;
			case 8:
				goto IL_00b2;
			case 9:
				goto IL_00e1;
			case 1:
				return true;
			case 4:
				player = xtEeJJTUgeBnwYmgqEBvHevmpPf[num2];
				num3 = 763941149;
				continue;
			case 0:
				goto IL_0114;
			case 3:
				return true;
			default:
				goto IL_0141;
			}
			break;
			IL_0114:
			int num4;
			if (num2 < NPHursLHMwvEpcuCSsqwqwQpePh)
			{
				num3 = 763941147;
				num4 = num3;
			}
			else
			{
				num3 = 763941141;
				num4 = num3;
			}
			continue;
			IL_0133:
			num2++;
			num3 = 763941151;
			continue;
			IL_0076:
			int num5;
			if (!MgGtJKaHLSyjHLoGfGQLvKxEfrJ.assignJoysticksToPlayingPlayersOnly)
			{
				num3 = 763941143;
				num5 = num3;
			}
			else
			{
				num3 = 763941142;
				num5 = num3;
			}
			continue;
			IL_00e1:
			if (player.isPlaying)
			{
				num3 = 763941143;
				continue;
			}
			goto IL_0133;
			IL_005f:
			if (!player.controllers.excludeFromControllerAutoAssignment)
			{
				num3 = 763941145;
				continue;
			}
			goto IL_0133;
			IL_00b2:
			if (player.controllers.joystickCount < MgGtJKaHLSyjHLoGfGQLvKxEfrJ.maxJoysticksPerPlayer)
			{
				player.controllers.HTKzJtWKDmkqZbNAPiKgDorFSCpp(P_0, true);
				num3 = 763941148;
				continue;
			}
			goto IL_0133;
		}
		goto IL_001e;
		IL_001e:
		num3 = 763941144;
		goto IL_0023;
	}

	private int HUuwIfzksOtUGYgiFGcPkLwTtZgP()
	{
		int num = -1;
		int num2 = 0;
		int num3 = 0;
		int joystickCount = default(int);
		Player player = default(Player);
		while (true)
		{
			int num4 = -1896442475;
			while (true)
			{
				switch (num4 ^ -1896442480)
				{
				case 6:
					break;
				case 7:
					num2 = joystickCount;
					num4 = -1896442479;
					continue;
				case 3:
					joystickCount = player.controllers.joystickCount;
					if (joystickCount < MgGtJKaHLSyjHLoGfGQLvKxEfrJ.maxJoysticksPerPlayer)
					{
						if (num != -1)
						{
							int num7;
							if (joystickCount < num2)
							{
								num4 = -1896442470;
								num7 = num4;
							}
							else
							{
								num4 = -1896442479;
								num7 = num4;
							}
							continue;
						}
						goto case 10;
					}
					goto case 1;
				case 8:
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						int num8;
						if (MgGtJKaHLSyjHLoGfGQLvKxEfrJ.assignJoysticksToPlayingPlayersOnly)
						{
							num4 = -1896442480;
							num8 = num4;
						}
						else
						{
							num4 = -1896442477;
							num8 = num4;
						}
						continue;
					}
					goto case 1;
				case 10:
					num = num3;
					num4 = -1896442473;
					continue;
				case 9:
					player = xtEeJJTUgeBnwYmgqEBvHevmpPf[num3];
					num4 = -1896442472;
					continue;
				case 5:
					num4 = -1896442478;
					continue;
				case 2:
				{
					int num6;
					if (num3 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						num4 = -1896442476;
						num6 = num4;
					}
					else
					{
						num4 = -1896442471;
						num6 = num4;
					}
					continue;
				}
				case 1:
					num3++;
					num4 = -1896442478;
					continue;
				case 0:
				{
					int num5;
					if (player.isPlaying)
					{
						num4 = -1896442477;
						num5 = num4;
					}
					else
					{
						num4 = -1896442479;
						num5 = num4;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
		}
	}

	public int FhkTqRAVISruhOsrgMGPpyBGorj(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		int num5 = default(int);
		Player player = default(Player);
		double num4 = default(double);
		while (true)
		{
			int num3 = -347593241;
			while (true)
			{
				switch (num3 ^ -347593247)
				{
				case 11:
					break;
				case 9:
				{
					int num8;
					if (num5 >= NPHursLHMwvEpcuCSsqwqwQpePh)
					{
						num3 = -347593243;
						num8 = num3;
					}
					else
					{
						num3 = -347593248;
						num8 = num3;
					}
					continue;
				}
				case 0:
					num3 = -347593240;
					continue;
				case 5:
				{
					int num10;
					if (!player.isPlaying)
					{
						num3 = -347593245;
						num10 = num3;
					}
					else
					{
						num3 = -347593242;
						num10 = num3;
					}
					continue;
				}
				case 8:
				{
					int num12;
					if (num4 <= num2)
					{
						num3 = -347593245;
						num12 = num3;
					}
					else
					{
						num3 = -347593246;
						num12 = num3;
					}
					continue;
				}
				case 6:
					num5 = 0;
					num3 = -347593247;
					continue;
				case 13:
				{
					int num7;
					if (num >= 0)
					{
						num3 = -347593239;
						num7 = num3;
					}
					else
					{
						num3 = -347593246;
						num7 = num3;
					}
					continue;
				}
				case 10:
				{
					int num11;
					if (!(num4 < 0.0))
					{
						num3 = -347593236;
						num11 = num3;
					}
					else
					{
						num3 = -347593245;
						num11 = num3;
					}
					continue;
				}
				case 7:
				{
					int num9;
					if (player.controllers.joystickCount >= MgGtJKaHLSyjHLoGfGQLvKxEfrJ.maxJoysticksPerPlayer)
					{
						num3 = -347593245;
						num9 = num3;
					}
					else
					{
						num3 = -347593235;
						num9 = num3;
					}
					continue;
				}
				case 1:
					player = xtEeJJTUgeBnwYmgqEBvHevmpPf[num5];
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						int num6;
						if (!MgGtJKaHLSyjHLoGfGQLvKxEfrJ.assignJoysticksToPlayingPlayersOnly)
						{
							num3 = -347593242;
							num6 = num3;
						}
						else
						{
							num3 = -347593244;
							num6 = num3;
						}
						continue;
					}
					goto case 2;
				case 2:
					num5++;
					num3 = -347593240;
					continue;
				case 12:
					num4 = player.controllers.PHJizEpcDYNHcKgdEfOKDBeDKiC(P_0);
					num3 = -347593237;
					continue;
				case 3:
					num2 = num4;
					num = num5;
					num3 = -347593245;
					continue;
				default:
					return num;
				}
				break;
			}
		}
	}
}
