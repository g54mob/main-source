using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class qolSwVLcvXSMneGdcvjdFoTKDPcf
{
	private int DBzTfJzOfekZjQZsMSkFprQyBGwV;

	private int HPoVVRuiijbyxxcNPEJZrWeMAITAA;

	private Player YrTKMdESsppakfzhYErXaieeBiik;

	private Player[] zTgcfKjabZGcWHMSilKzItbPupeu;

	private Player[] PrqtSzgvUQEAFKkCCJfQSPBfaFwi;

	private IList<Player> MIjaQpnLjCbAHLuuGuVBCLcKQlub;

	private IList<Player> KRqxZEXZnvDoZADtzXLSrmAZbIUA;

	private ConfigVars SGAGlwCzGZjRqVLpPhwucWOYUpxx;

	private bool XJInkTYydhVViVGGQEfJMokdBhuAA;

	public int MAShPKKnbATAFLRWtWcZveXJQFbZ => DBzTfJzOfekZjQZsMSkFprQyBGwV;

	public int sioooHayORrWlgDepTgNQcWmyHqn => HPoVVRuiijbyxxcNPEJZrWeMAITAA;

	public Player[] TBpNyBPMLBhkxjATrrlDocidIume => zTgcfKjabZGcWHMSilKzItbPupeu;

	public Player[] GRMgmqBsZTglRSltAPKVZlJlPGmKA => PrqtSzgvUQEAFKkCCJfQSPBfaFwi;

	public IList<Player> XavrOVNYUlxVBmAFjuhpuXIcfxaH => KRqxZEXZnvDoZADtzXLSrmAZbIUA;

	public IList<Player> sMalrQnbUjebJHEHhcHBxfuzkigcb => MIjaQpnLjCbAHLuuGuVBCLcKQlub;

	public qolSwVLcvXSMneGdcvjdFoTKDPcf(ConfigVars P_0)
	{
		SGAGlwCzGZjRqVLpPhwucWOYUpxx = P_0;
	}

	public void iJtbAKdHSvInWyczNilCYqmkndRyA()
	{
		if (XJInkTYydhVViVGGQEfJMokdBhuAA)
		{
			return;
		}
		HPoVVRuiijbyxxcNPEJZrWeMAITAA = ReInput.UserData.playerCount;
		DBzTfJzOfekZjQZsMSkFprQyBGwV = HPoVVRuiijbyxxcNPEJZrWeMAITAA - 1;
		PrqtSzgvUQEAFKkCCJfQSPBfaFwi = new Player[DBzTfJzOfekZjQZsMSkFprQyBGwV];
		zTgcfKjabZGcWHMSilKzItbPupeu = new Player[HPoVVRuiijbyxxcNPEJZrWeMAITAA];
		IList<Player_Editor> list = ReInput.UserData.EviYdZZAcXSKWfhzsldcaszNDheN;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			FBvloJYAnsSEnqZpZgYHeIbOgKik fBvloJYAnsSEnqZpZgYHeIbOgKik = player_Editor.fCPnkbiAoDdlxaOdUyEubSDoSpFs();
			ControllerMapLayoutManager.ZwEHsomBYpCwhUwueCrLPncgybEq zwEHsomBYpCwhUwueCrLPncgybEq = player_Editor.controllerMapLayoutManagerSettings.DDaKfJBBJGSMDIoJsPzOYNzGgtcn();
			ControllerMapEnabler.JmqjWaNbmLkTeEMjBbAurWsDFFCl jmqjWaNbmLkTeEMjBbAurWsDFFCl = player_Editor.controllerMapEnablerSettings.BbNqtwmmHMnBNXmuTsQPhaWnwtOK();
			Player player;
			if (i == 0)
			{
				player = (YrTKMdESsppakfzhYErXaieeBiik = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, fBvloJYAnsSEnqZpZgYHeIbOgKik, zwEHsomBYpCwhUwueCrLPncgybEq, jmqjWaNbmLkTeEMjBbAurWsDFFCl));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, fBvloJYAnsSEnqZpZgYHeIbOgKik, zwEHsomBYpCwhUwueCrLPncgybEq, jmqjWaNbmLkTeEMjBbAurWsDFFCl);
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i - 1] = player;
			}
			zTgcfKjabZGcWHMSilKzItbPupeu[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.RasNdShhTTBWOlZqpwnnxJTdGBmY(true);
			player.controllers.maps.DRDJIpKtxBajkxzUKFruVukEbnfe(true);
		}
		MIjaQpnLjCbAHLuuGuVBCLcKQlub = new ReadOnlyCollection<Player>(PrqtSzgvUQEAFKkCCJfQSPBfaFwi);
		KRqxZEXZnvDoZADtzXLSrmAZbIUA = new ReadOnlyCollection<Player>(zTgcfKjabZGcWHMSilKzItbPupeu);
		XJInkTYydhVViVGGQEfJMokdBhuAA = true;
	}

	public void tDoopMAISoyhWFONCqEESDzFEcCI(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!SGAGlwCzGZjRqVLpPhwucWOYUpxx.reassignJoystickToPreviousOwnerOnReconnect || !LNTBSjkRneiiMhDDYIwYZutKEXlQ(P_0))
		{
			BRzfVwybnjuddejrRXsDcIXGuyqK(P_0);
		}
	}

	public void OEbERiLhiRGkJKfGlNmHQsCGKdRc(Joystick P_0)
	{
		if (SGAGlwCzGZjRqVLpPhwucWOYUpxx.autoAssignJoysticks)
		{
			tDoopMAISoyhWFONCqEESDzFEcCI(P_0);
		}
	}

	public void GVZpBJNShkccPvGVJlREsknRRyVm(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < HPoVVRuiijbyxxcNPEJZrWeMAITAA; i++)
		{
			zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player UvJedjalXzUlKEDfIYQQGGlTWIFK(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= DBzTfJzOfekZjQZsMSkFprQyBGwV))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return YrTKMdESsppakfzhYErXaieeBiik;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			if (PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].id == P_0)
			{
				return PrqtSzgvUQEAFKkCCJfQSPBfaFwi[P_0];
			}
		}
		return null;
	}

	public Player erNGFwEGrTRGakctWpmpEvjArXUl(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (YrTKMdESsppakfzhYErXaieeBiik.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return YrTKMdESsppakfzhYErXaieeBiik;
			}
			for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
			{
				if (PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player TjnOdGcnoTiIujHJzGeRHFXfoKtbb()
	{
		return YrTKMdESsppakfzhYErXaieeBiik;
	}

	public int RyDAgibqhBJJvgBRBHYxZKcARruGB(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (YrTKMdESsppakfzhYErXaieeBiik.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			if (PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].id;
			}
		}
		return -1;
	}

	public bool KBbeYFsHLdSzoLeETxfqUSxdtIVT(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= DBzTfJzOfekZjQZsMSkFprQyBGwV))
		{
			return false;
		}
		return true;
	}

	public Player[] QqOwzGeXywghrHmYXWYAQOPpcBYX(bool P_0)
	{
		int num = DBzTfJzOfekZjQZsMSkFprQyBGwV;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YrTKMdESsppakfzhYErXaieeBiik;
			num2 = 1;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			array[num2 + i] = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i];
		}
		return array;
	}

	public string[] DiLXbntIPOlezDqOcSyNwBrUnFrs(bool P_0)
	{
		int num = DBzTfJzOfekZjQZsMSkFprQyBGwV;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YrTKMdESsppakfzhYErXaieeBiik.name;
			num2 = 1;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			array[num2 + i] = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].name;
		}
		return array;
	}

	public string[] wNFDdUooawLBTfTZMQGREyCawTdq(bool P_0)
	{
		int num = DBzTfJzOfekZjQZsMSkFprQyBGwV;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YrTKMdESsppakfzhYErXaieeBiik.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			array[num2 + i] = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].descriptiveName;
		}
		return array;
	}

	public int[] OViLpuHhSVyjRfNwbWeBMZnDukIM(bool P_0)
	{
		int num = DBzTfJzOfekZjQZsMSkFprQyBGwV;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = YrTKMdESsppakfzhYErXaieeBiik.id;
			num2 = 1;
		}
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			array[num2 + i] = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].id;
		}
		return array;
	}

	public bool hKgzQLzMimanKYZnYAtStoHNIpcb(Controller P_0)
	{
		if (P_0 == null || zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		return SpSZlMvyOXBRiBxsgupmwbmbFjRX(P_0.type, P_0.id);
	}

	public bool SpSZlMvyOXBRiBxsgupmwbmbFjRX(ControllerType P_0, int P_1)
	{
		if (zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		for (int i = 0; i < zTgcfKjabZGcWHMSilKzItbPupeu.Length; i++)
		{
			if (zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool FennzzbDaTIEDHXzmpJgfXyKUBFpA(ControllerType P_0, int P_1, int P_2)
	{
		return UvJedjalXzUlKEDfIYQQGGlTWIFK(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void WYUHfojTJRKYuvmSUmpSwjhXJLEk(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YrTKMdESsppakfzhYErXaieeBiik.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
			{
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void EFOgfZdHsCfIqoSBGvNkveodmxrUA(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			WYUHfojTJRKYuvmSUmpSwjhXJLEk(controller, P_2);
		}
	}

	public bool bdKzsrEsGsOnUDkUGshKwgmtwtWb(Joystick P_0)
	{
		if (P_0 == null || zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		for (int i = 0; i < zTgcfKjabZGcWHMSilKzItbPupeu.Length; i++)
		{
			if (zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool XVZjqdsVftiWjqJOTXCevEGnDHBs(int P_0)
	{
		if (zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		for (int i = 0; i < zTgcfKjabZGcWHMSilKzItbPupeu.Length; i++)
		{
			if (zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool UYegdeaXzxxYbxqxuboABAlxXVfE(int P_0, int P_1)
	{
		return UvJedjalXzUlKEDfIYQQGGlTWIFK(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void XHtitfXmatfTPnYIciQOQpDnEfLF(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YrTKMdESsppakfzhYErXaieeBiik.controllers.LzezTvgERKIGTzMMzYAetGwELbBP(P_0);
			}
			for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
			{
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].controllers.LzezTvgERKIGTzMMzYAetGwELbBP(P_0);
			}
		}
	}

	public void DKkJnKtkADaAPIUcGnHgeDNKritLB(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			XHtitfXmatfTPnYIciQOQpDnEfLF(joystick, P_1);
		}
	}

	public bool jxigLlCkHVhQirFRysODjaHSKpxzA(CustomController P_0)
	{
		if (P_0 == null || zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		for (int i = 0; i < zTgcfKjabZGcWHMSilKzItbPupeu.Length; i++)
		{
			if (zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool rIzJpBpjTIyztewPfOcOpaHjAYCdA(int P_0)
	{
		if (zTgcfKjabZGcWHMSilKzItbPupeu == null)
		{
			return false;
		}
		for (int i = 0; i < zTgcfKjabZGcWHMSilKzItbPupeu.Length; i++)
		{
			if (zTgcfKjabZGcWHMSilKzItbPupeu[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool likVvwkeiQfXaHHnQLVDktrObpapA(int P_0, int P_1)
	{
		return UvJedjalXzUlKEDfIYQQGGlTWIFK(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void cEzjsIjKqFTXRqNkhkjilKNstDzg(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				YrTKMdESsppakfzhYErXaieeBiik.controllers.xQTPLqEGtCryUaBiQWsOAYOkOOmL(P_0);
			}
			for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
			{
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i].controllers.xQTPLqEGtCryUaBiQWsOAYOkOOmL(P_0);
			}
		}
	}

	public void olbgONITRLatKcqxLZhHqkUxBoWEA(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			cEzjsIjKqFTXRqNkhkjilKNstDzg(customController, P_1);
		}
	}

	private bool LNTBSjkRneiiMhDDYIwYZutKEXlQ(Joystick P_0)
	{
		if (SGAGlwCzGZjRqVLpPhwucWOYUpxx.distributeJoysticksEvenly)
		{
			int num = oRBhobuRczbOuYGAjAYPgkLYLfOx();
			if (num < 0)
			{
				return false;
			}
			int num2 = PPfWkDscAsgejhoMkQEiETqhEBlFb(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[num];
			Player player2 = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[num2].controllers.kHPLUaPgAFSVVTIfZbsAfukHtven(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = PPfWkDscAsgejhoMkQEiETqhEBlFb(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		PrqtSzgvUQEAFKkCCJfQSPBfaFwi[num3].controllers.kHPLUaPgAFSVVTIfZbsAfukHtven(P_0, true);
		return true;
	}

	private bool BRzfVwybnjuddejrRXsDcIXGuyqK(Joystick P_0)
	{
		if (SGAGlwCzGZjRqVLpPhwucWOYUpxx.distributeJoysticksEvenly)
		{
			int num = oRBhobuRczbOuYGAjAYPgkLYLfOx();
			if (num >= 0)
			{
				PrqtSzgvUQEAFKkCCJfQSPBfaFwi[num].controllers.kHPLUaPgAFSVVTIfZbsAfukHtven(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
			{
				Player player = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!SGAGlwCzGZjRqVLpPhwucWOYUpxx.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < SGAGlwCzGZjRqVLpPhwucWOYUpxx.maxJoysticksPerPlayer)
				{
					player.controllers.kHPLUaPgAFSVVTIfZbsAfukHtven(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int oRBhobuRczbOuYGAjAYPgkLYLfOx()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			Player player = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!SGAGlwCzGZjRqVLpPhwucWOYUpxx.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < SGAGlwCzGZjRqVLpPhwucWOYUpxx.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int PPfWkDscAsgejhoMkQEiETqhEBlFb(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < DBzTfJzOfekZjQZsMSkFprQyBGwV; i++)
		{
			Player player = PrqtSzgvUQEAFKkCCJfQSPBfaFwi[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!SGAGlwCzGZjRqVLpPhwucWOYUpxx.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < SGAGlwCzGZjRqVLpPhwucWOYUpxx.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.xHZkqkwXGizDRXfssLfMEwlRRUOA(P_0);
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
