using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class aSOYcRCZqytuczbEAnlwvDhfgcsc
{
	private int ZKLTiqBbxwezNfrctVxpPUagJNT;

	private int LnHYqEXHiPclWcpoVgVHACZGuADs;

	private Player GHooUCCAbAMTcNOrjofIJhzLlMd;

	private Player[] ijwArNjnopBIgvmoSLnoOyTDUpJ;

	private Player[] phKrVTRgBsFPEJGANsmkszTdKXP;

	private IList<Player> jUpFLSdPtSLCyJWtZEREDUOvajGL;

	private IList<Player> eVrcllNFPWGegJwZHxuVaLjJgRGN;

	private ConfigVars AzMyTQkqkOhQhSBeGZpAEMZVrzb;

	private bool WktzUSAcjulBYRNUcifkLEmijRhD;

	public int gamePlayerCount
	{
		get
		{
			return ZKLTiqBbxwezNfrctVxpPUagJNT;
		}
	}

	public int allPlayerCount
	{
		get
		{
			return LnHYqEXHiPclWcpoVgVHACZGuADs;
		}
	}

	public Player[] AllPlayers_orig
	{
		get
		{
			return ijwArNjnopBIgvmoSLnoOyTDUpJ;
		}
	}

	public Player[] Players_orig
	{
		get
		{
			return phKrVTRgBsFPEJGANsmkszTdKXP;
		}
	}

	public IList<Player> AllPlayers_readOnly
	{
		get
		{
			return eVrcllNFPWGegJwZHxuVaLjJgRGN;
		}
	}

	public IList<Player> Players_readOnly
	{
		get
		{
			return jUpFLSdPtSLCyJWtZEREDUOvajGL;
		}
	}

	public aSOYcRCZqytuczbEAnlwvDhfgcsc(ConfigVars configVars)
	{
		AzMyTQkqkOhQhSBeGZpAEMZVrzb = configVars;
	}

	public void YJaAHaimrHWIfKrgfWxeihnqrcza()
	{
		if (WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			return;
		}
		ControllerMapLayoutManager.StartingSettings controllerMapLayoutManagerSettings = default(ControllerMapLayoutManager.StartingSettings);
		Player_Editor player_Editor = default(Player_Editor);
		ControllerMapEnabler.JUZYTaWfnqZOjNkWvtfvZbKqPkC controllerMapEnablerSettings = default(ControllerMapEnabler.JUZYTaWfnqZOjNkWvtfvZbKqPkC);
		int num2 = default(int);
		Player player = default(Player);
		LDQPFPXQyLIyqtAUvmVCEbFpcBq startingControllerMapInfo = default(LDQPFPXQyLIyqtAUvmVCEbFpcBq);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		while (true)
		{
			LnHYqEXHiPclWcpoVgVHACZGuADs = ReInput.UserData.playerCount;
			ZKLTiqBbxwezNfrctVxpPUagJNT = LnHYqEXHiPclWcpoVgVHACZGuADs - 1;
			int num = 599612395;
			while (true)
			{
				switch (num ^ 0x23BD5BEE)
				{
				case 8:
					num = 599612397;
					continue;
				case 7:
					controllerMapLayoutManagerSettings = player_Editor.controllerMapLayoutManagerSettings.RDaWziREIKhWZlbRtZbglsspeWG();
					controllerMapEnablerSettings = player_Editor.controllerMapEnablerSettings.RDaWziREIKhWZlbRtZbglsspeWG();
					if (num2 == 0)
					{
						player = (GHooUCCAbAMTcNOrjofIJhzLlMd = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings));
						num = 599612388;
						continue;
					}
					goto case 0;
				case 2:
					num2 = 0;
					num = 599612392;
					continue;
				case 1:
					if (players_readOnly == null)
					{
						throw new ArgumentNullException("Players cannot be null!");
					}
					goto case 2;
				case 5:
					phKrVTRgBsFPEJGANsmkszTdKXP = new Player[ZKLTiqBbxwezNfrctVxpPUagJNT];
					ijwArNjnopBIgvmoSLnoOyTDUpJ = new Player[LnHYqEXHiPclWcpoVgVHACZGuADs];
					players_readOnly = ReInput.UserData.Players_readOnly;
					num = 599612399;
					continue;
				case 9:
					startingControllerMapInfo = player_Editor.SycpkkLkUewaZPGUqaerYpMkdXJB();
					num = 599612393;
					continue;
				case 10:
					ijwArNjnopBIgvmoSLnoOyTDUpJ[num2] = player;
					player.isPlaying = player_Editor.startPlaying;
					player.controllers.hasMouse = player_Editor.assignMouseOnStart;
					player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
					player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
					player.controllers.maps.ZiOtfyiFJruheJOmPVfgJhkZapP(true);
					player.controllers.maps.MqFYiibffvHsqbxSBlCwKKPzqQau(true);
					num2++;
					num = 599612392;
					continue;
				case 3:
					break;
				case 0:
					player = new Player(false, num2 - 1, player_Editor.name, player_Editor.descriptiveName, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
					phKrVTRgBsFPEJGANsmkszTdKXP[num2 - 1] = player;
					num = 599612388;
					continue;
				case 4:
					player_Editor = players_readOnly[num2];
					num = 599612391;
					continue;
				default:
					if (num2 >= players_readOnly.Count)
					{
						jUpFLSdPtSLCyJWtZEREDUOvajGL = new ReadOnlyCollection<Player>(phKrVTRgBsFPEJGANsmkszTdKXP);
						eVrcllNFPWGegJwZHxuVaLjJgRGN = new ReadOnlyCollection<Player>(ijwArNjnopBIgvmoSLnoOyTDUpJ);
						WktzUSAcjulBYRNUcifkLEmijRhD = true;
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public void txmhENmkzPovHzbmahTnZKEIihQ(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (!AzMyTQkqkOhQhSBeGZpAEMZVrzb.reassignJoystickToPreviousOwnerOnReconnect)
			{
				num = 660734084;
				num2 = num;
			}
			else
			{
				num = 660734087;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x27620084)
				{
				case 4:
					num = 660734085;
					continue;
				default:
					return;
				case 0:
					tsOUQoNVZVjNDagYdIiRXKIXhwq(P_0);
					num = 660734086;
					continue;
				case 3:
					if (nEVPvqkFWveHaifISTdUdRGYau(P_0))
					{
						return;
					}
					goto case 0;
				case 1:
					break;
				case 2:
					return;
				}
				break;
			}
		}
	}

	public void QzuwmtOhlLCOpHQfwELOgjJhsYId(Joystick P_0)
	{
		if (AzMyTQkqkOhQhSBeGZpAEMZVrzb.autoAssignJoysticks)
		{
			txmhENmkzPovHzbmahTnZKEIihQ(P_0);
		}
	}

	public void ZzjzlBbZnbZhcsABirkBCwgKwih(ControllerType P_0, int P_1)
	{
		int num = 0;
		while (num < LnHYqEXHiPclWcpoVgVHACZGuADs)
		{
			while (true)
			{
				ijwArNjnopBIgvmoSLnoOyTDUpJ[num].controllers.RemoveController(P_0, P_1);
				num++;
				int num2 = -22379048;
				while (true)
				{
					switch (num2 ^ -22379046)
					{
					case 0:
						num2 = -22379045;
						continue;
					case 1:
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

	public Player BguZqZULdBNeIEfARdMNkptxqJou(int P_0)
	{
		if (P_0 != 9999999)
		{
			if (P_0 >= 0)
			{
				goto IL_000f;
			}
			goto IL_0088;
		}
		goto IL_00a4;
		IL_00a4:
		int num = default(int);
		int num2;
		if (P_0 != 9999999)
		{
			num = 0;
			num2 = -229758374;
		}
		else
		{
			num2 = -229758372;
		}
		goto IL_0014;
		IL_000f:
		num2 = -229758370;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -229758372)
			{
			case 5:
				break;
			case 2:
				goto IL_003d;
			case 3:
				goto IL_004d;
			case 0:
				return GHooUCCAbAMTcNOrjofIJhzLlMd;
			case 6:
				num2 = -229758371;
				continue;
			case 4:
				goto IL_0088;
			default:
				if (num >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return null;
				}
				goto IL_004d;
			}
			break;
			IL_004d:
			if (phKrVTRgBsFPEJGANsmkszTdKXP[num].id == P_0)
			{
				return phKrVTRgBsFPEJGANsmkszTdKXP[P_0];
			}
			num++;
			num2 = -229758371;
			continue;
			IL_003d:
			if (P_0 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
			{
				num2 = -229758376;
				continue;
			}
			goto IL_00a4;
		}
		goto IL_000f;
		IL_0088:
		Logger.LogError("Player id " + P_0 + " does not exist!");
		return null;
	}

	public Player BguZqZULdBNeIEfARdMNkptxqJou(string P_0)
	{
		if (P_0 != null)
		{
			goto IL_0003;
		}
		goto IL_004a;
		IL_0003:
		int num = -383418631;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -383418632)
			{
			case 2:
				break;
			case 3:
				goto IL_0030;
			case 5:
				goto IL_004a;
			case 1:
				goto IL_0066;
			case 4:
				goto IL_009a;
			default:
				return null;
			}
			break;
			IL_009a:
			if (phKrVTRgBsFPEJGANsmkszTdKXP[num2].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return phKrVTRgBsFPEJGANsmkszTdKXP[num2];
			}
			num2++;
			num = -383418629;
			continue;
			IL_0066:
			if (!(P_0 == string.Empty))
			{
				if (GHooUCCAbAMTcNOrjofIJhzLlMd.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return GHooUCCAbAMTcNOrjofIJhzLlMd;
				}
				num2 = 0;
				num = -383418629;
				continue;
			}
			goto IL_004a;
			IL_0030:
			int num3;
			if (num2 < ZKLTiqBbxwezNfrctVxpPUagJNT)
			{
				num = -383418628;
				num3 = num;
			}
			else
			{
				num = -383418627;
				num3 = num;
			}
		}
		goto IL_0003;
		IL_004a:
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		num = -383418632;
		goto IL_0008;
	}

	public Player OAxOAmqPhXfcosjWwcgifExlsrf()
	{
		return GHooUCCAbAMTcNOrjofIJhzLlMd;
	}

	public int oqWCkffPFVQxBAYLHqvdvygwfZDB(string P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (P_0 == string.Empty)
			{
				goto IL_0010;
			}
			if (GHooUCCAbAMTcNOrjofIJhzLlMd.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return 9999999;
			}
			num = 0;
			num2 = 530546383;
			goto IL_0015;
		}
		goto IL_0070;
		IL_0015:
		while (true)
		{
			switch (num2 ^ 0x1F9F7ECE)
			{
			case 5:
				break;
			case 3:
				goto IL_003a;
			case 0:
				return phKrVTRgBsFPEJGANsmkszTdKXP[num].id;
			case 2:
				goto IL_0070;
			case 1:
				num2 = 530546378;
				continue;
			default:
				if (num >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return -1;
				}
				goto IL_003a;
			}
			break;
			IL_003a:
			if (phKrVTRgBsFPEJGANsmkszTdKXP[num].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				num2 = 530546382;
				continue;
			}
			num++;
			num2 = 530546378;
		}
		goto IL_0010;
		IL_0010:
		num2 = 530546380;
		goto IL_0015;
		IL_0070:
		return -1;
	}

	public bool IDrKDdfuMsShzmwAlMuWnxGbEue(int P_0)
	{
		if (P_0 != 9999999)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = 1658182648;
					while (true)
					{
						switch (num ^ 0x62D5DBF9)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (P_0 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
						{
							num = 1658182649;
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

	public Player[] tFHVYhhCZvDtYdhENXXnrFqDoiJ(bool P_0)
	{
		int num = ZKLTiqBbxwezNfrctVxpPUagJNT;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_0064;
		IL_0064:
		Player[] array = new Player[num];
		int num2 = 634614553;
		goto IL_0013;
		IL_000e:
		num2 = 634614557;
		goto IL_0013;
		IL_0013:
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			switch (num2 ^ 0x25D3731C)
			{
			case 4:
				break;
			case 0:
				num3 = 0;
				num2 = 634614558;
				continue;
			case 6:
				array[num4 + num3] = phKrVTRgBsFPEJGANsmkszTdKXP[num3];
				num3++;
				num2 = 634614559;
				continue;
			case 2:
				num2 = 634614559;
				continue;
			case 1:
				goto IL_0064;
			case 5:
				num4 = 0;
				if (P_0)
				{
					array[0] = GHooUCCAbAMTcNOrjofIJhzLlMd;
					num4 = 1;
					num2 = 634614556;
					continue;
				}
				goto case 0;
			default:
				if (num3 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return array;
				}
				goto case 6;
			}
			break;
		}
		goto IL_000e;
	}

	public string[] dmxAurkhWSGLWImVNrZhZVzuzRm(bool P_0)
	{
		int num = ZKLTiqBbxwezNfrctVxpPUagJNT;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_0038;
		IL_0038:
		string[] array = new string[num];
		int num2 = 0;
		int num3;
		if (P_0)
		{
			array[0] = GHooUCCAbAMTcNOrjofIJhzLlMd.name;
			num3 = 1284206716;
			goto IL_0013;
		}
		goto IL_0059;
		IL_000e:
		num3 = 1284206719;
		goto IL_0013;
		IL_0013:
		int num4 = default(int);
		while (true)
		{
			switch (num3 ^ 0x4C8B707D)
			{
			case 5:
				break;
			case 2:
				goto IL_0038;
			case 0:
				goto IL_0059;
			case 1:
				num2 = 1;
				num3 = 1284206717;
				continue;
			case 4:
				array[num2 + num4] = phKrVTRgBsFPEJGANsmkszTdKXP[num4].name;
				num4++;
				num3 = 1284206718;
				continue;
			default:
				if (num4 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return array;
				}
				goto case 4;
			}
			break;
		}
		goto IL_000e;
		IL_0059:
		num4 = 0;
		num3 = 1284206718;
		goto IL_0013;
	}

	public string[] zakGjCgQSdNmHhDnlWAEvzvVrZH(bool P_0)
	{
		int num = ZKLTiqBbxwezNfrctVxpPUagJNT;
		if (P_0)
		{
			num++;
			goto IL_000e;
		}
		goto IL_004c;
		IL_004c:
		string[] array = new string[num];
		int num2 = 0;
		int num3;
		if (P_0)
		{
			array[0] = GHooUCCAbAMTcNOrjofIJhzLlMd.descriptiveName;
			num2 = 1;
			num3 = -583528397;
			goto IL_0013;
		}
		goto IL_0043;
		IL_000e:
		num3 = -583528398;
		goto IL_0013;
		IL_0013:
		int num4 = default(int);
		while (true)
		{
			switch (num3 ^ -583528394)
			{
			case 0:
				break;
			case 3:
				num4++;
				num3 = -583528396;
				continue;
			case 5:
				goto IL_0043;
			case 4:
				goto IL_004c;
			case 1:
				array[num2 + num4] = phKrVTRgBsFPEJGANsmkszTdKXP[num4].descriptiveName;
				num3 = -583528395;
				continue;
			default:
				if (num4 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return array;
				}
				goto case 1;
			}
			break;
		}
		goto IL_000e;
		IL_0043:
		num4 = 0;
		num3 = -583528396;
		goto IL_0013;
	}

	public int[] vppbwPswfcBMlnJkgKbRlQUkGFp(bool P_0)
	{
		int num = ZKLTiqBbxwezNfrctVxpPUagJNT;
		int[] array = default(int[]);
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = 1108825168;
			while (true)
			{
				switch (num2 ^ 0x42175451)
				{
				case 0:
					break;
				case 2:
					array[num4 + num3] = phKrVTRgBsFPEJGANsmkszTdKXP[num3].id;
					num3++;
					num2 = 1108825170;
					continue;
				case 4:
					array[0] = GHooUCCAbAMTcNOrjofIJhzLlMd.id;
					num4 = 1;
					num2 = 1108825172;
					continue;
				case 6:
				{
					array = new int[num];
					num4 = 0;
					int num5;
					if (P_0)
					{
						num2 = 1108825173;
						num5 = num2;
					}
					else
					{
						num2 = 1108825172;
						num5 = num2;
					}
					continue;
				}
				case 5:
					num3 = 0;
					num2 = 1108825170;
					continue;
				case 1:
					if (P_0)
					{
						num++;
						num2 = 1108825175;
						continue;
					}
					goto case 6;
				default:
					if (num3 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public bool usWbhMCAoDVLOcTyqkZhzdUHFOJ(Controller P_0)
	{
		if (P_0 == null || ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
		{
			return false;
		}
		return usWbhMCAoDVLOcTyqkZhzdUHFOJ(P_0.type, P_0.id);
	}

	public bool usWbhMCAoDVLOcTyqkZhzdUHFOJ(ControllerType P_0, int P_1)
	{
		if (ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2 = -1345891211;
			while (true)
			{
				switch (num2 ^ -1345891212)
				{
				case 3:
					break;
				case 1:
					num2 = -1345891212;
					continue;
				case 2:
					if (ijwArNjnopBIgvmoSLnoOyTDUpJ[num].controllers.ContainsController(P_0, P_1))
					{
						return true;
					}
					num++;
					num2 = -1345891212;
					continue;
				default:
					if (num >= ijwArNjnopBIgvmoSLnoOyTDUpJ.Length)
					{
						return false;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public bool XKVAinnLdbesNeZZMWrDvfgmuRnA(ControllerType P_0, int P_1, int P_2)
	{
		Player player = BguZqZULdBNeIEfARdMNkptxqJou(P_2);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(P_0, P_1);
	}

	public void ygFXITzTeaNLUBEAOhmjfmKmRGp(Controller P_0, bool P_1)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0060;
		IL_0003:
		int num = 1779475038;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x6A10A25C)
			{
			case 4:
				break;
			case 2:
				return;
			case 7:
				phKrVTRgBsFPEJGANsmkszTdKXP[num2].controllers.RemoveController(P_0);
				num = 1779475036;
				continue;
			case 1:
				goto IL_0057;
			case 5:
				goto IL_0060;
			case 0:
				num2++;
				num = 1779475039;
				continue;
			case 6:
				num = 1779475039;
				continue;
			default:
				if (num2 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					return;
				}
				goto case 7;
			}
			break;
		}
		goto IL_0003;
		IL_0057:
		num2 = 0;
		num = 1779475034;
		goto IL_0008;
		IL_0060:
		if (P_1)
		{
			GHooUCCAbAMTcNOrjofIJhzLlMd.controllers.RemoveController(P_0);
			num = 1779475037;
			goto IL_0008;
		}
		goto IL_0057;
	}

	public void ygFXITzTeaNLUBEAOhmjfmKmRGp(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		while (true)
		{
			int num = 2012616376;
			while (true)
			{
				switch (num ^ 0x77F616BB)
				{
				case 2:
					break;
				default:
					return;
				case 3:
				{
					int num2;
					if (controller != null)
					{
						num = 2012616378;
						num2 = num;
					}
					else
					{
						num = 2012616383;
						num2 = num;
					}
					continue;
				}
				case 1:
					ygFXITzTeaNLUBEAOhmjfmKmRGp(controller, P_2);
					num = 2012616379;
					continue;
				case 4:
					return;
				case 0:
					return;
				}
				break;
			}
		}
	}

	public bool EbiGJUzmFpIMKpVjYviLAJorscq(Joystick P_0)
	{
		if (P_0 != null)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1332832442;
				while (true)
				{
					switch (num ^ 0x4F7168B8)
					{
					case 5:
						break;
					case 0:
						goto IL_002d;
					case 1:
						goto IL_004f;
					case 2:
						goto IL_006b;
					case 4:
						goto end_IL_0003;
					default:
						return false;
					}
					break;
					IL_006b:
					if (ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
					{
						num = 1332832444;
						continue;
					}
					num2 = 0;
					num = 1332832441;
					continue;
					IL_004f:
					int num3;
					if (num2 >= ijwArNjnopBIgvmoSLnoOyTDUpJ.Length)
					{
						num = 1332832443;
						num3 = num;
					}
					else
					{
						num = 1332832440;
						num3 = num;
					}
					continue;
					IL_002d:
					if (ijwArNjnopBIgvmoSLnoOyTDUpJ[num2].controllers.ContainsController(P_0))
					{
						return true;
					}
					num2++;
					num = 1332832441;
				}
				continue;
				end_IL_0003:
				break;
			}
		}
		return false;
	}

	public bool EbiGJUzmFpIMKpVjYviLAJorscq(int P_0)
	{
		if (ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = 1912293679;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num2 ^ 0x71FB492F)
			{
			case 2:
				break;
			case 1:
				return false;
			case 3:
				if (ijwArNjnopBIgvmoSLnoOyTDUpJ[num].controllers.ContainsController(ControllerType.Joystick, P_0))
				{
					return true;
				}
				num++;
				num2 = 1912293679;
				continue;
			case 0:
			{
				int num3;
				if (num < ijwArNjnopBIgvmoSLnoOyTDUpJ.Length)
				{
					num2 = 1912293676;
					num3 = num2;
				}
				else
				{
					num2 = 1912293675;
					num3 = num2;
				}
				continue;
			}
			default:
				return false;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num2 = 1912293678;
		goto IL_000d;
	}

	public bool iTTDqmIjnoMNBKrjrexqulnePYg(int P_0, int P_1)
	{
		Player player = BguZqZULdBNeIEfARdMNkptxqJou(P_1);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(ControllerType.Joystick, P_0);
	}

	public void oTRaljLmiJFUileIsSQZOjcAriR(Joystick P_0, bool P_1)
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
				GHooUCCAbAMTcNOrjofIJhzLlMd.controllers.zwbHitsqiXGFqJjlZgUaENxJxbF(P_0);
				num = -1410048369;
				goto IL_0009;
			}
			goto IL_006e;
			IL_0009:
			while (true)
			{
				switch (num ^ -1410048374)
				{
				case 4:
					num = -1410048376;
					continue;
				case 2:
					break;
				case 1:
					phKrVTRgBsFPEJGANsmkszTdKXP[num2].controllers.zwbHitsqiXGFqJjlZgUaENxJxbF(P_0);
					num = -1410048374;
					continue;
				case 0:
					num2++;
					num = -1410048375;
					continue;
				case 5:
					goto IL_006e;
				default:
					if (num2 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
			continue;
			IL_006e:
			num2 = 0;
			num = -1410048375;
			goto IL_0009;
		}
	}

	public void oTRaljLmiJFUileIsSQZOjcAriR(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick == null)
		{
			while (true)
			{
				switch (-444452737 ^ -444452738)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		oTRaljLmiJFUileIsSQZOjcAriR(joystick, P_1);
	}

	public bool HrGncikfxNdXGcsrqTNgBpkPuam(CustomController P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
			{
				goto IL_000b;
			}
			num = 0;
			num2 = 33559228;
			goto IL_0010;
		}
		goto IL_0031;
		IL_0010:
		while (true)
		{
			switch (num2 ^ 0x20012BF)
			{
			case 0:
				break;
			case 2:
				goto IL_0031;
			case 3:
				goto IL_003c;
			case 4:
				goto IL_0058;
			default:
				return false;
			}
			break;
			IL_0058:
			if (ijwArNjnopBIgvmoSLnoOyTDUpJ[num].controllers.ContainsController(P_0))
			{
				return true;
			}
			num++;
			num2 = 33559228;
			continue;
			IL_003c:
			int num3;
			if (num >= ijwArNjnopBIgvmoSLnoOyTDUpJ.Length)
			{
				num2 = 33559230;
				num3 = num2;
			}
			else
			{
				num2 = 33559227;
				num3 = num2;
			}
		}
		goto IL_000b;
		IL_0031:
		return false;
		IL_000b:
		num2 = 33559229;
		goto IL_0010;
	}

	public bool HrGncikfxNdXGcsrqTNgBpkPuam(int P_0)
	{
		if (ijwArNjnopBIgvmoSLnoOyTDUpJ == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < ijwArNjnopBIgvmoSLnoOyTDUpJ.Length)
			{
				num2 = -2046707684;
				num3 = num2;
			}
			else
			{
				num2 = -2046707681;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -2046707683)
				{
				case 3:
					num2 = -2046707684;
					continue;
				case 1:
					if (ijwArNjnopBIgvmoSLnoOyTDUpJ[num].controllers.ContainsController(ControllerType.Custom, P_0))
					{
						return true;
					}
					num++;
					num2 = -2046707683;
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

	public bool IgozmIHOJVFvChnNkzZpsBlMHfLM(int P_0, int P_1)
	{
		Player player = BguZqZULdBNeIEfARdMNkptxqJou(P_1);
		if (player == null)
		{
			return false;
		}
		return player.controllers.ContainsController(ControllerType.Custom, P_0);
	}

	public void fiGrFWWKIXnogWJRBqKoSYJAwjJ(CustomController P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			IL_0051:
			int num;
			if (P_1)
			{
				GHooUCCAbAMTcNOrjofIJhzLlMd.controllers.PDQUjpckXCQXzCfTVwQoaafKrYv(P_0);
				num = 1622898210;
				goto IL_0009;
			}
			goto IL_0048;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x60BB7623)
				{
				case 3:
					num = 1622898209;
					continue;
				case 0:
					phKrVTRgBsFPEJGANsmkszTdKXP[num2].controllers.PDQUjpckXCQXzCfTVwQoaafKrYv(P_0);
					num2++;
					num = 1622898215;
					continue;
				case 1:
					break;
				case 2:
					goto IL_0051;
				default:
					if (num2 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0048;
			IL_0048:
			num2 = 0;
			num = 1622898215;
			goto IL_0009;
		}
	}

	public void fiGrFWWKIXnogWJRBqKoSYJAwjJ(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController == null)
		{
			while (true)
			{
				switch (0x72726894 ^ 0x72726895)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		fiGrFWWKIXnogWJRBqKoSYJAwjJ(customController, P_1);
	}

	private bool nEVPvqkFWveHaifISTdUdRGYau(Joystick P_0)
	{
		int num2 = default(int);
		Player player = default(Player);
		if (AzMyTQkqkOhQhSBeGZpAEMZVrzb.distributeJoysticksEvenly)
		{
			int num = DPycsxnBQUudePfKuHbScwQIVNE();
			if (num < 0)
			{
				return false;
			}
			num2 = RcwCGVMBpCCzFDQRPrSUQHbZpIX(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			player = phKrVTRgBsFPEJGANsmkszTdKXP[num];
			goto IL_0039;
		}
		int num3 = RcwCGVMBpCCzFDQRPrSUQHbZpIX(P_0.id);
		int num4 = -824359002;
		goto IL_003e;
		IL_0039:
		num4 = -824359001;
		goto IL_003e;
		IL_003e:
		Player player2 = default(Player);
		while (true)
		{
			switch (num4 ^ -824359003)
			{
			case 0:
				break;
			case 2:
				player2 = phKrVTRgBsFPEJGANsmkszTdKXP[num2];
				if (num2 >= 0)
				{
					goto IL_0068;
				}
				goto IL_00d0;
			case 1:
				if (player2.controllers.joystickCount <= player.controllers.joystickCount)
				{
					phKrVTRgBsFPEJGANsmkszTdKXP[num2].controllers.LQGxclUaisClvyzkifGfZFVUDUD(P_0, true);
					return true;
				}
				goto IL_00d0;
			default:
				{
					if (num3 < 0)
					{
						return false;
					}
					phKrVTRgBsFPEJGANsmkszTdKXP[num3].controllers.LQGxclUaisClvyzkifGfZFVUDUD(P_0, true);
					return true;
				}
				IL_00d0:
				return false;
			}
			break;
			IL_0068:
			num4 = -824359004;
		}
		goto IL_0039;
	}

	private bool tsOUQoNVZVjNDagYdIiRXKIXhwq(Joystick P_0)
	{
		if (AzMyTQkqkOhQhSBeGZpAEMZVrzb.distributeJoysticksEvenly)
		{
			int num = DPycsxnBQUudePfKuHbScwQIVNE();
			if (num >= 0)
			{
				phKrVTRgBsFPEJGANsmkszTdKXP[num].controllers.LQGxclUaisClvyzkifGfZFVUDUD(P_0, true);
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
				if (num2 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
				{
					num3 = -989495484;
					num4 = num3;
				}
				else
				{
					num3 = -989495488;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -989495486)
					{
					case 0:
						num3 = -989495488;
						continue;
					case 2:
						player = phKrVTRgBsFPEJGANsmkszTdKXP[num2];
						num3 = -989495482;
						continue;
					case 3:
						return true;
					case 5:
						break;
					case 4:
						goto IL_009d;
					case 1:
						goto IL_00c9;
					default:
						goto end_IL_0083;
					}
					break;
					IL_009d:
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						if (!AzMyTQkqkOhQhSBeGZpAEMZVrzb.assignJoysticksToPlayingPlayersOnly)
						{
							goto IL_00c9;
						}
						if (player.isPlaying)
						{
							num3 = -989495485;
							continue;
						}
					}
					goto IL_0078;
					IL_0078:
					num2++;
					num3 = -989495481;
					continue;
					IL_00c9:
					if (player.controllers.joystickCount < AzMyTQkqkOhQhSBeGZpAEMZVrzb.maxJoysticksPerPlayer)
					{
						player.controllers.LQGxclUaisClvyzkifGfZFVUDUD(P_0, true);
						num3 = -989495487;
						continue;
					}
					goto IL_0078;
				}
				continue;
				end_IL_0083:
				break;
			}
		}
		return false;
	}

	private int DPycsxnBQUudePfKuHbScwQIVNE()
	{
		int num = -1;
		int joystickCount = default(int);
		int num4 = default(int);
		Player player = default(Player);
		int num3 = default(int);
		while (true)
		{
			int num2 = 1406119215;
			while (true)
			{
				switch (num2 ^ 0x53CFAD27)
				{
				case 3:
					break;
				case 9:
					if (joystickCount >= AzMyTQkqkOhQhSBeGZpAEMZVrzb.maxJoysticksPerPlayer)
					{
						goto case 4;
					}
					if (num != -1)
					{
						int num6;
						if (joystickCount < num4)
						{
							num2 = 1406119201;
							num6 = num2;
						}
						else
						{
							num2 = 1406119203;
							num6 = num2;
						}
						continue;
					}
					goto case 6;
				case 0:
					joystickCount = player.controllers.joystickCount;
					num2 = 1406119214;
					continue;
				case 1:
					num2 = 1406119200;
					continue;
				case 10:
					num4 = joystickCount;
					num2 = 1406119203;
					continue;
				case 2:
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						if (AzMyTQkqkOhQhSBeGZpAEMZVrzb.assignJoysticksToPlayingPlayersOnly)
						{
							int num5;
							if (!player.isPlaying)
							{
								num2 = 1406119203;
								num5 = num2;
							}
							else
							{
								num2 = 1406119207;
								num5 = num2;
							}
							continue;
						}
						goto case 0;
					}
					goto case 4;
				case 4:
					num3++;
					num2 = 1406119200;
					continue;
				case 8:
					num4 = 0;
					num3 = 0;
					num2 = 1406119206;
					continue;
				case 5:
					player = phKrVTRgBsFPEJGANsmkszTdKXP[num3];
					num2 = 1406119205;
					continue;
				case 6:
					num = num3;
					num2 = 1406119213;
					continue;
				default:
					if (num3 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
					{
						return num;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	public int RcwCGVMBpCCzFDQRPrSUQHbZpIX(int P_0)
	{
		int num = -1;
		float num2 = 0f;
		int num4 = default(int);
		Player player = default(Player);
		float num5 = default(float);
		while (true)
		{
			int num3 = 1007756345;
			while (true)
			{
				switch (num3 ^ 0x3C11243D)
				{
				case 0:
					break;
				case 2:
					num4++;
					num3 = 1007756350;
					continue;
				case 6:
				{
					int num7;
					if (!player.controllers.excludeFromControllerAutoAssignment)
					{
						num3 = 1007756341;
						num7 = num3;
					}
					else
					{
						num3 = 1007756351;
						num7 = num3;
					}
					continue;
				}
				case 7:
					player = phKrVTRgBsFPEJGANsmkszTdKXP[num4];
					num3 = 1007756347;
					continue;
				case 1:
					num2 = num5;
					num = num4;
					num3 = 1007756351;
					continue;
				case 5:
					if (player.controllers.joystickCount < AzMyTQkqkOhQhSBeGZpAEMZVrzb.maxJoysticksPerPlayer)
					{
						num5 = player.controllers.XXTbAdtxZQctMkRGrECRxopILGib(P_0);
						num3 = 1007756340;
						continue;
					}
					goto case 2;
				case 8:
					if (AzMyTQkqkOhQhSBeGZpAEMZVrzb.assignJoysticksToPlayingPlayersOnly)
					{
						int num8;
						if (player.isPlaying)
						{
							num3 = 1007756344;
							num8 = num3;
						}
						else
						{
							num3 = 1007756351;
							num8 = num3;
						}
						continue;
					}
					goto case 5;
				case 9:
					if (num5 < 0f)
					{
						goto case 2;
					}
					if (num >= 0)
					{
						int num6;
						if (num5 <= num2)
						{
							num3 = 1007756351;
							num6 = num3;
						}
						else
						{
							num3 = 1007756348;
							num6 = num3;
						}
						continue;
					}
					goto case 1;
				case 4:
					num4 = 0;
					num3 = 1007756350;
					continue;
				default:
					if (num4 >= ZKLTiqBbxwezNfrctVxpPUagJNT)
					{
						return num;
					}
					goto case 7;
				}
				break;
			}
		}
	}
}
