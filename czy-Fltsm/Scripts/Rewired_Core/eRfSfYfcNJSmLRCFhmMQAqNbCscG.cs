using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class eRfSfYfcNJSmLRCFhmMQAqNbCscG
{
	private int JEpvfAZnVeTHRbYQFthoaZWPcFwu;

	private int LtisPSQUGvDgNMTnStGiwacfQNDn;

	private Player YNJQwckSuljqUUJUVFQyjueDUqWc;

	private Player[] vwsuNNLPxHkbsegltHPWBzVicWqD;

	private Player[] LNwtJsQlRWYibbLaJIEdNoFQlQsG;

	private IList<Player> CgEdgPJbjtEbcJuYxWvgRtZpyZjm;

	private IList<Player> WWNcbGtUvtpZApTrqcOgytqpqgYu;

	private ConfigVars KnOgxlqwuPfPIdiHWRpRrlKdqmfvA;

	private bool LhQyyYgmBnBRCozeXFkmZgwCPgan;

	public int KAOhRVBrBYwCtoNeiOpilaTceGbbA => JEpvfAZnVeTHRbYQFthoaZWPcFwu;

	public int imgzsKYXwFRKJFlIkipkRfWZvIoo => LtisPSQUGvDgNMTnStGiwacfQNDn;

	public Player[] JAvTLYlvaBhSZQAuqeeozNmITTyT => vwsuNNLPxHkbsegltHPWBzVicWqD;

	public Player[] OmYguzUKrHvxxCFFPKBkcRLCHHsW => LNwtJsQlRWYibbLaJIEdNoFQlQsG;

	public IList<Player> TCxpaUtqwtvVjZtIczZUxEFBsccG => WWNcbGtUvtpZApTrqcOgytqpqgYu;

	public IList<Player> iLgYnNBBmfEbfjvbkBEifkofAzqvB => CgEdgPJbjtEbcJuYxWvgRtZpyZjm;

	public eRfSfYfcNJSmLRCFhmMQAqNbCscG(ConfigVars P_0)
	{
		KnOgxlqwuPfPIdiHWRpRrlKdqmfvA = P_0;
	}

	public void afzIGRjFcjspiDBJEPgfpmoJRgTo()
	{
		if (LhQyyYgmBnBRCozeXFkmZgwCPgan)
		{
			return;
		}
		LtisPSQUGvDgNMTnStGiwacfQNDn = ReInput.UserData.playerCount;
		JEpvfAZnVeTHRbYQFthoaZWPcFwu = LtisPSQUGvDgNMTnStGiwacfQNDn - 1;
		LNwtJsQlRWYibbLaJIEdNoFQlQsG = new Player[JEpvfAZnVeTHRbYQFthoaZWPcFwu];
		vwsuNNLPxHkbsegltHPWBzVicWqD = new Player[LtisPSQUGvDgNMTnStGiwacfQNDn];
		IList<Player_Editor> list = ReInput.UserData.CqaNhCrdUVQUcSQVbyoNlYtceigM;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			ReblhCinFkWhDVFLEbjmzIdfVvaS reblhCinFkWhDVFLEbjmzIdfVvaS = player_Editor.xXNrcfAIdFvJZBPEZBBSuJbFyZXc();
			ControllerMapLayoutManager.VRUPdzKgeveqVvQabkIaYFoBcpSf vRUPdzKgeveqVvQabkIaYFoBcpSf = player_Editor.controllerMapLayoutManagerSettings.VHwazEanfUAOnVtvxksxbTlFvmoLb();
			ControllerMapEnabler.LoufCxnWRPkzSbBIKyhZshokUpWL loufCxnWRPkzSbBIKyhZshokUpWL = player_Editor.controllerMapEnablerSettings.BXBulpYKnSzHfiOUULhyuBUUjpKo();
			Player player;
			if (i == 0)
			{
				player = (YNJQwckSuljqUUJUVFQyjueDUqWc = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, reblhCinFkWhDVFLEbjmzIdfVvaS, vRUPdzKgeveqVvQabkIaYFoBcpSf, loufCxnWRPkzSbBIKyhZshokUpWL));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, reblhCinFkWhDVFLEbjmzIdfVvaS, vRUPdzKgeveqVvQabkIaYFoBcpSf, loufCxnWRPkzSbBIKyhZshokUpWL);
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[i - 1] = player;
			}
			vwsuNNLPxHkbsegltHPWBzVicWqD[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.HzsYdTXFjFOIuEwOwWiMcZFAxEwN(true);
			player.controllers.maps.LwRRHmiaFTigGKaTPnERChyhfcfIA(true);
		}
		CgEdgPJbjtEbcJuYxWvgRtZpyZjm = new ReadOnlyCollection<Player>(LNwtJsQlRWYibbLaJIEdNoFQlQsG);
		WWNcbGtUvtpZApTrqcOgytqpqgYu = new ReadOnlyCollection<Player>(vwsuNNLPxHkbsegltHPWBzVicWqD);
		LhQyyYgmBnBRCozeXFkmZgwCPgan = true;
	}

	public void xbeiDDqjgykocyFaNWjvXBpapRSt(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.reassignJoystickToPreviousOwnerOnReconnect || !VJJVCoIFFieGcQcbJjbjGDxlQUrP(P_0))
		{
			DWxCJlaOFzHzNRHNOItgUdVdrxqkA(P_0);
		}
	}

	public void CVYbSCjOJTUSKjgXsmUBFfetqFlo(Joystick P_0)
	{
		if (KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.autoAssignJoysticks)
		{
			xbeiDDqjgykocyFaNWjvXBpapRSt(P_0);
		}
	}

	public void WsXSJIfrDkQedMVvECXlvIloixZN(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < LtisPSQUGvDgNMTnStGiwacfQNDn; i++)
		{
			vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player SsVuigQhQtABwxcDHPRhTnSsVBJh(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= JEpvfAZnVeTHRbYQFthoaZWPcFwu))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return YNJQwckSuljqUUJUVFQyjueDUqWc;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			if (LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].id == P_0)
			{
				return LNwtJsQlRWYibbLaJIEdNoFQlQsG[P_0];
			}
		}
		return null;
	}

	public Player wpNBDvmrXFEYIRVPRbdGALfzHeGhb(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (YNJQwckSuljqUUJUVFQyjueDUqWc.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return YNJQwckSuljqUUJUVFQyjueDUqWc;
			}
			for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
			{
				if (LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return LNwtJsQlRWYibbLaJIEdNoFQlQsG[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player JnxxdHKLKTWWOGpjgTpkAKLMeRjbA()
	{
		return YNJQwckSuljqUUJUVFQyjueDUqWc;
	}

	public int DaRkwrQjNDBRBiYfWNPYJMsgkeuo(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (YNJQwckSuljqUUJUVFQyjueDUqWc.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			if (LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].id;
			}
		}
		return -1;
	}

	public bool WbfSUuQhwzzYOgqDCeHuXhKAZPOB(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= JEpvfAZnVeTHRbYQFthoaZWPcFwu))
		{
			return false;
		}
		return true;
	}

	public Player[] SsUPhNIlGyizTmJyYJZxZBXOoYWT(bool P_0)
	{
		int num = JEpvfAZnVeTHRbYQFthoaZWPcFwu;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YNJQwckSuljqUUJUVFQyjueDUqWc;
			num2 = 1;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			array[num2 + i] = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i];
		}
		return array;
	}

	public string[] PKDMjuTkjKkQVeWqjxxelNpfWWzG(bool P_0)
	{
		int num = JEpvfAZnVeTHRbYQFthoaZWPcFwu;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YNJQwckSuljqUUJUVFQyjueDUqWc.name;
			num2 = 1;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			array[num2 + i] = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].name;
		}
		return array;
	}

	public string[] stJDbLaUSaWDvKUtPONckPSZsOvbA(bool P_0)
	{
		int num = JEpvfAZnVeTHRbYQFthoaZWPcFwu;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YNJQwckSuljqUUJUVFQyjueDUqWc.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			array[num2 + i] = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].descriptiveName;
		}
		return array;
	}

	public int[] IZqWpvlIwPjxtUIAsMraXklaIlSZ(bool P_0)
	{
		int num = JEpvfAZnVeTHRbYQFthoaZWPcFwu;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YNJQwckSuljqUUJUVFQyjueDUqWc.id;
			num2 = 1;
		}
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			array[num2 + i] = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].id;
		}
		return array;
	}

	public bool jwOahFLYkiBcLtShkRRUkPsuePjfA(Controller P_0)
	{
		if (P_0 == null || vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		return EqIDBmRybTLHYoGchhiRbqTIwWDC(P_0.type, P_0.id);
	}

	public bool EqIDBmRybTLHYoGchhiRbqTIwWDC(ControllerType P_0, int P_1)
	{
		if (vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		for (int i = 0; i < vwsuNNLPxHkbsegltHPWBzVicWqD.Length; i++)
		{
			if (vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool FCnyfuDDSDgWnGmRrZAVVUkjlCFNA(ControllerType P_0, int P_1, int P_2)
	{
		return SsVuigQhQtABwxcDHPRhTnSsVBJh(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void KwYTlvVhlFAMYYsuVdrtlhvwCEMG(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YNJQwckSuljqUUJUVFQyjueDUqWc.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
			{
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void YgCedEdGGIwUIlppJKUPtiwEDetN(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			KwYTlvVhlFAMYYsuVdrtlhvwCEMG(controller, P_2);
		}
	}

	public bool hcOExfsJUgPEFcgQRUtQtRgOcfnQ(Joystick P_0)
	{
		if (P_0 == null || vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		for (int i = 0; i < vwsuNNLPxHkbsegltHPWBzVicWqD.Length; i++)
		{
			if (vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool VQZxNkKRkbgXBTsIWYDXwCWWQVXc(int P_0)
	{
		if (vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		for (int i = 0; i < vwsuNNLPxHkbsegltHPWBzVicWqD.Length; i++)
		{
			if (vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool QbmgcfGFrblzLSQThujQSGwSAhPb(int P_0, int P_1)
	{
		return SsVuigQhQtABwxcDHPRhTnSsVBJh(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void BFbmxetoSrdQrABkhbdtPntIKZJO(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YNJQwckSuljqUUJUVFQyjueDUqWc.controllers.DkOncnMnWrWxeEmylVVbowdiaRdA(P_0);
			}
			for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
			{
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].controllers.DkOncnMnWrWxeEmylVVbowdiaRdA(P_0);
			}
		}
	}

	public void HkuctBEZuVyAzHfIRpYFSMRKrtnNA(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			BFbmxetoSrdQrABkhbdtPntIKZJO(joystick, P_1);
		}
	}

	public bool vWeeTsMprBHKGaKvnGDoirBxLodLA(CustomController P_0)
	{
		if (P_0 == null || vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		for (int i = 0; i < vwsuNNLPxHkbsegltHPWBzVicWqD.Length; i++)
		{
			if (vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool fnnZpATKxKjhRLZnuntpojRSaXEcA(int P_0)
	{
		if (vwsuNNLPxHkbsegltHPWBzVicWqD == null)
		{
			return false;
		}
		for (int i = 0; i < vwsuNNLPxHkbsegltHPWBzVicWqD.Length; i++)
		{
			if (vwsuNNLPxHkbsegltHPWBzVicWqD[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool lLmsjtEeKGdFEhoLNjMqAyfvLkqZA(int P_0, int P_1)
	{
		return SsVuigQhQtABwxcDHPRhTnSsVBJh(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void sdppVJNWiJThpXgjcChRwLGPkknT(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YNJQwckSuljqUUJUVFQyjueDUqWc.controllers.xnNwTjwEZWCgoEZEDKFvKFCBQBgAb(P_0);
			}
			for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
			{
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[i].controllers.xnNwTjwEZWCgoEZEDKFvKFCBQBgAb(P_0);
			}
		}
	}

	public void gQfgOWdyfDYnoVIBCrowpZMQppMR(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			sdppVJNWiJThpXgjcChRwLGPkknT(customController, P_1);
		}
	}

	private bool VJJVCoIFFieGcQcbJjbjGDxlQUrP(Joystick P_0)
	{
		if (KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.distributeJoysticksEvenly)
		{
			int num = ooJhliIORbhVAzwycTHkfVLfoBWG();
			if (num < 0)
			{
				return false;
			}
			int num2 = DtlqwGMcsgDwXhFerALRYAcYuAtuA(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = LNwtJsQlRWYibbLaJIEdNoFQlQsG[num];
			Player player2 = LNwtJsQlRWYibbLaJIEdNoFQlQsG[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[num2].controllers.kgFzKznruBeNzkDBKoxpkVkyQsiO(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = DtlqwGMcsgDwXhFerALRYAcYuAtuA(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		LNwtJsQlRWYibbLaJIEdNoFQlQsG[num3].controllers.kgFzKznruBeNzkDBKoxpkVkyQsiO(P_0, true);
		return true;
	}

	private bool DWxCJlaOFzHzNRHNOItgUdVdrxqkA(Joystick P_0)
	{
		if (KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.distributeJoysticksEvenly)
		{
			int num = ooJhliIORbhVAzwycTHkfVLfoBWG();
			if (num >= 0)
			{
				LNwtJsQlRWYibbLaJIEdNoFQlQsG[num].controllers.kgFzKznruBeNzkDBKoxpkVkyQsiO(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
			{
				Player player = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.maxJoysticksPerPlayer)
				{
					player.controllers.kgFzKznruBeNzkDBKoxpkVkyQsiO(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int ooJhliIORbhVAzwycTHkfVLfoBWG()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			Player player = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int DtlqwGMcsgDwXhFerALRYAcYuAtuA(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < JEpvfAZnVeTHRbYQFthoaZWPcFwu; i++)
		{
			Player player = LNwtJsQlRWYibbLaJIEdNoFQlQsG[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < KnOgxlqwuPfPIdiHWRpRrlKdqmfvA.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.dvPcspUFpGAddujJxHGMEVqOSUGBA(P_0);
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
