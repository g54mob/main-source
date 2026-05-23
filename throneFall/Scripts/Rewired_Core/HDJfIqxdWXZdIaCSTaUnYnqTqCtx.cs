using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class HDJfIqxdWXZdIaCSTaUnYnqTqCtx
{
	private int kSTVCwHbSovOYYORrfFNiMftKBpN;

	private int cHIMmoMiDnTpWpruqEeHkoNVkJIv;

	private Player ravtBQsrRtklFlAKvtyBraVfIbji;

	private Player[] OtIXzvZWbPbwjLpeNvrtXKsUeNrd;

	private Player[] gcQWSUKkSIThwYTvlyXIBcmytgjH;

	private IList<Player> bhcaJjXnwbpovFdDVmHRZiqDUHcu;

	private IList<Player> xunSHgzYmvKYZKMaQsNNakNXyoLg;

	private ConfigVars lLwBGFjwnTuWRsNIsLXagljGJcozB;

	private bool ykovJsiiGxjYRhRzzeOLEXPdwenEB;

	public int bYsHspPdAWKVmRlbOyRDnMcSXMgu => kSTVCwHbSovOYYORrfFNiMftKBpN;

	public int RLCTJiQobFDVIysJUUNRPShrRMxT => cHIMmoMiDnTpWpruqEeHkoNVkJIv;

	public Player[] ipFcHyhMbZwkElirYYZBptJsVutG => OtIXzvZWbPbwjLpeNvrtXKsUeNrd;

	public Player[] lBeJVPUjmJjiebpWxLfJBeaeqDbNb => gcQWSUKkSIThwYTvlyXIBcmytgjH;

	public IList<Player> ssTAZyhzyjeuEmsFYTerbvGpsIhg => xunSHgzYmvKYZKMaQsNNakNXyoLg;

	public IList<Player> XKQWYjVbbhoomGBuCSuHeIXeXvbX => bhcaJjXnwbpovFdDVmHRZiqDUHcu;

	public HDJfIqxdWXZdIaCSTaUnYnqTqCtx(ConfigVars P_0)
	{
		lLwBGFjwnTuWRsNIsLXagljGJcozB = P_0;
	}

	public void BOFhvxzqbxSctgIWuUWExnJjuUSJ()
	{
		if (ykovJsiiGxjYRhRzzeOLEXPdwenEB)
		{
			return;
		}
		cHIMmoMiDnTpWpruqEeHkoNVkJIv = ReInput.UserData.playerCount;
		kSTVCwHbSovOYYORrfFNiMftKBpN = cHIMmoMiDnTpWpruqEeHkoNVkJIv - 1;
		gcQWSUKkSIThwYTvlyXIBcmytgjH = new Player[kSTVCwHbSovOYYORrfFNiMftKBpN];
		OtIXzvZWbPbwjLpeNvrtXKsUeNrd = new Player[cHIMmoMiDnTpWpruqEeHkoNVkJIv];
		IList<Player_Editor> list = ReInput.UserData.veCQUcbOHBPDdzjQJpMsjmKQamdw;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			wsTGaisyEgVqWobCcVTBhcYPpDji wsTGaisyEgVqWobCcVTBhcYPpDji2 = player_Editor.UJfCCdCTILqbCmYhhvIuqGgnoOQf();
			ControllerMapLayoutManager.ccDuPLOhlbrAqOTHJEHJSRpBmDEb ccDuPLOhlbrAqOTHJEHJSRpBmDEb = player_Editor.controllerMapLayoutManagerSettings.wVKEIekxcMYBiRYsJEKMMHKDYgxqA();
			ControllerMapEnabler.ybCAJZdDMTpCNSaMwMfysgFQeUXm ybCAJZdDMTpCNSaMwMfysgFQeUXm = player_Editor.controllerMapEnablerSettings.ezfZAXMwqAJQyPhVcbDVakfyCnBqA();
			Player player;
			if (i == 0)
			{
				player = (ravtBQsrRtklFlAKvtyBraVfIbji = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, wsTGaisyEgVqWobCcVTBhcYPpDji2, ccDuPLOhlbrAqOTHJEHJSRpBmDEb, ybCAJZdDMTpCNSaMwMfysgFQeUXm));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, wsTGaisyEgVqWobCcVTBhcYPpDji2, ccDuPLOhlbrAqOTHJEHJSRpBmDEb, ybCAJZdDMTpCNSaMwMfysgFQeUXm);
				gcQWSUKkSIThwYTvlyXIBcmytgjH[i - 1] = player;
			}
			OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.yxEUApNVgRRDjrbXWPSpemumAYnEA(true);
			player.controllers.maps.cWhwsUsbGLevXnXUjNuyAILFpcqt(true);
		}
		bhcaJjXnwbpovFdDVmHRZiqDUHcu = new ReadOnlyCollection<Player>(gcQWSUKkSIThwYTvlyXIBcmytgjH);
		xunSHgzYmvKYZKMaQsNNakNXyoLg = new ReadOnlyCollection<Player>(OtIXzvZWbPbwjLpeNvrtXKsUeNrd);
		ykovJsiiGxjYRhRzzeOLEXPdwenEB = true;
	}

	public void UoYJLxwtzmfoxZrWlNxARAWQNlDC(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!lLwBGFjwnTuWRsNIsLXagljGJcozB.reassignJoystickToPreviousOwnerOnReconnect || !yzrggMGGEatRbnhkpJoSYsSXUSkG(P_0))
		{
			ohTcsXhUAtvoKlkKsKHDEhecLxjOb(P_0);
		}
	}

	public void bRktJgjfATCZDAwQEOsgRtPJkBsT(Joystick P_0)
	{
		if (lLwBGFjwnTuWRsNIsLXagljGJcozB.autoAssignJoysticks)
		{
			UoYJLxwtzmfoxZrWlNxARAWQNlDC(P_0);
		}
	}

	public void dDnZgevEYuejaexoiZuYFnKIjvArA(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < cHIMmoMiDnTpWpruqEeHkoNVkJIv; i++)
		{
			OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player brhNoQGyqbXIjYOSldNMHSkKJjCd(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= kSTVCwHbSovOYYORrfFNiMftKBpN))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return ravtBQsrRtklFlAKvtyBraVfIbji;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			if (gcQWSUKkSIThwYTvlyXIBcmytgjH[i].id == P_0)
			{
				return gcQWSUKkSIThwYTvlyXIBcmytgjH[P_0];
			}
		}
		return null;
	}

	public Player JdzicVIeOZJFTgoEefXxXXEHTqPIc(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (ravtBQsrRtklFlAKvtyBraVfIbji.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return ravtBQsrRtklFlAKvtyBraVfIbji;
			}
			for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
			{
				if (gcQWSUKkSIThwYTvlyXIBcmytgjH[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return gcQWSUKkSIThwYTvlyXIBcmytgjH[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player kkFtAnKzLXLJZjMeUjNJMYwsjPoy()
	{
		return ravtBQsrRtklFlAKvtyBraVfIbji;
	}

	public int oZrEHHUHGVdIWcRyejxjcJTAlwzPA(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (ravtBQsrRtklFlAKvtyBraVfIbji.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			if (gcQWSUKkSIThwYTvlyXIBcmytgjH[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return gcQWSUKkSIThwYTvlyXIBcmytgjH[i].id;
			}
		}
		return -1;
	}

	public bool nsNbeqOeAlsDNXrOqYDyFGYaXFSi(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= kSTVCwHbSovOYYORrfFNiMftKBpN))
		{
			return false;
		}
		return true;
	}

	public Player[] vicLQzASVgMgOZOlkcpUHpgcKILt(bool P_0)
	{
		int num = kSTVCwHbSovOYYORrfFNiMftKBpN;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ravtBQsrRtklFlAKvtyBraVfIbji;
			num2 = 1;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			array[num2 + i] = gcQWSUKkSIThwYTvlyXIBcmytgjH[i];
		}
		return array;
	}

	public string[] clhsSQXTqEunSZPtLrJTviATwEiw(bool P_0)
	{
		int num = kSTVCwHbSovOYYORrfFNiMftKBpN;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ravtBQsrRtklFlAKvtyBraVfIbji.name;
			num2 = 1;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			array[num2 + i] = gcQWSUKkSIThwYTvlyXIBcmytgjH[i].name;
		}
		return array;
	}

	public string[] JgneAvJUXaQGcanuivzDbFhyrImVb(bool P_0)
	{
		int num = kSTVCwHbSovOYYORrfFNiMftKBpN;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ravtBQsrRtklFlAKvtyBraVfIbji.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			array[num2 + i] = gcQWSUKkSIThwYTvlyXIBcmytgjH[i].descriptiveName;
		}
		return array;
	}

	public int[] hCIwQVvZzLiiofQNUbPZHvEAqjBU(bool P_0)
	{
		int num = kSTVCwHbSovOYYORrfFNiMftKBpN;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = ravtBQsrRtklFlAKvtyBraVfIbji.id;
			num2 = 1;
		}
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			array[num2 + i] = gcQWSUKkSIThwYTvlyXIBcmytgjH[i].id;
		}
		return array;
	}

	public bool KxuEPrXbjuEtUSSaSIptqdDOyPaN(Controller P_0)
	{
		if (P_0 == null || OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		return zCaqhUPpVHQNkLTwRLccxRSyaWaB(P_0.type, P_0.id);
	}

	public bool zCaqhUPpVHQNkLTwRLccxRSyaWaB(ControllerType P_0, int P_1)
	{
		if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		for (int i = 0; i < OtIXzvZWbPbwjLpeNvrtXKsUeNrd.Length; i++)
		{
			if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool yoLvGOZPVRITkJbKJWuwOmJFWKAy(ControllerType P_0, int P_1, int P_2)
	{
		return brhNoQGyqbXIjYOSldNMHSkKJjCd(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void fsuaJVPefFPHXvtkrVXQtYHMWFuc(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ravtBQsrRtklFlAKvtyBraVfIbji.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
			{
				gcQWSUKkSIThwYTvlyXIBcmytgjH[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void ttcJMadqVCXBBCzetRgaxsDyyaqU(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			fsuaJVPefFPHXvtkrVXQtYHMWFuc(controller, P_2);
		}
	}

	public bool MpcSODiXNcVYOJMDzPCxzfPuinuw(Joystick P_0)
	{
		if (P_0 == null || OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		for (int i = 0; i < OtIXzvZWbPbwjLpeNvrtXKsUeNrd.Length; i++)
		{
			if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool ysrOLAOKAnzAYcgfeJwqaZpkHYAu(int P_0)
	{
		if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		for (int i = 0; i < OtIXzvZWbPbwjLpeNvrtXKsUeNrd.Length; i++)
		{
			if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool toEJXPQGQzieUlLoREVESfJeAige(int P_0, int P_1)
	{
		return brhNoQGyqbXIjYOSldNMHSkKJjCd(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void agVBiCnsTfgnmxgdFBuUVCEiFmKH(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ravtBQsrRtklFlAKvtyBraVfIbji.controllers.kuKQKMUyjGRckdffCfIoilNVwQYH(P_0);
			}
			for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
			{
				gcQWSUKkSIThwYTvlyXIBcmytgjH[i].controllers.kuKQKMUyjGRckdffCfIoilNVwQYH(P_0);
			}
		}
	}

	public void ejAFEvBRnZnNwxIHjomscMoGsnmtb(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			agVBiCnsTfgnmxgdFBuUVCEiFmKH(joystick, P_1);
		}
	}

	public bool UxKhsCINcJXXFXdmTqhTvPwNEkyEA(CustomController P_0)
	{
		if (P_0 == null || OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		for (int i = 0; i < OtIXzvZWbPbwjLpeNvrtXKsUeNrd.Length; i++)
		{
			if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool SrNfOacNoYRkAmikMuFATcccHPHuA(int P_0)
	{
		if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd == null)
		{
			return false;
		}
		for (int i = 0; i < OtIXzvZWbPbwjLpeNvrtXKsUeNrd.Length; i++)
		{
			if (OtIXzvZWbPbwjLpeNvrtXKsUeNrd[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool GkMMUPSePWpOXVpWtAiBcpKBaqny(int P_0, int P_1)
	{
		return brhNoQGyqbXIjYOSldNMHSkKJjCd(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void ZmVYlbDVzFIqecotWDAawCbpuiuj(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				ravtBQsrRtklFlAKvtyBraVfIbji.controllers.MetzsPiLEKFpbqKBxAdSiJvtHFrIb(P_0);
			}
			for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
			{
				gcQWSUKkSIThwYTvlyXIBcmytgjH[i].controllers.MetzsPiLEKFpbqKBxAdSiJvtHFrIb(P_0);
			}
		}
	}

	public void RNRBnwfyiFqyhKeEkiKVIfhAkhByb(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			ZmVYlbDVzFIqecotWDAawCbpuiuj(customController, P_1);
		}
	}

	private bool yzrggMGGEatRbnhkpJoSYsSXUSkG(Joystick P_0)
	{
		if (lLwBGFjwnTuWRsNIsLXagljGJcozB.distributeJoysticksEvenly)
		{
			int num = HAhKaGKoBrsaDCxpUjxFhkyJiQXh();
			if (num < 0)
			{
				return false;
			}
			int num2 = kHTLNkGvjybtAsYtLhbuCODeTAqm(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = gcQWSUKkSIThwYTvlyXIBcmytgjH[num];
			Player player2 = gcQWSUKkSIThwYTvlyXIBcmytgjH[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				gcQWSUKkSIThwYTvlyXIBcmytgjH[num2].controllers.PPdwvLjDdXACcjBWqTJSqmLQuijqA(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = kHTLNkGvjybtAsYtLhbuCODeTAqm(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		gcQWSUKkSIThwYTvlyXIBcmytgjH[num3].controllers.PPdwvLjDdXACcjBWqTJSqmLQuijqA(P_0, true);
		return true;
	}

	private bool ohTcsXhUAtvoKlkKsKHDEhecLxjOb(Joystick P_0)
	{
		if (lLwBGFjwnTuWRsNIsLXagljGJcozB.distributeJoysticksEvenly)
		{
			int num = HAhKaGKoBrsaDCxpUjxFhkyJiQXh();
			if (num >= 0)
			{
				gcQWSUKkSIThwYTvlyXIBcmytgjH[num].controllers.PPdwvLjDdXACcjBWqTJSqmLQuijqA(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
			{
				Player player = gcQWSUKkSIThwYTvlyXIBcmytgjH[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!lLwBGFjwnTuWRsNIsLXagljGJcozB.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < lLwBGFjwnTuWRsNIsLXagljGJcozB.maxJoysticksPerPlayer)
				{
					player.controllers.PPdwvLjDdXACcjBWqTJSqmLQuijqA(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int HAhKaGKoBrsaDCxpUjxFhkyJiQXh()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			Player player = gcQWSUKkSIThwYTvlyXIBcmytgjH[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!lLwBGFjwnTuWRsNIsLXagljGJcozB.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < lLwBGFjwnTuWRsNIsLXagljGJcozB.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int kHTLNkGvjybtAsYtLhbuCODeTAqm(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < kSTVCwHbSovOYYORrfFNiMftKBpN; i++)
		{
			Player player = gcQWSUKkSIThwYTvlyXIBcmytgjH[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!lLwBGFjwnTuWRsNIsLXagljGJcozB.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < lLwBGFjwnTuWRsNIsLXagljGJcozB.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.QyzXhNQhoUjocBcABuyxLmPmBUZV(P_0);
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
