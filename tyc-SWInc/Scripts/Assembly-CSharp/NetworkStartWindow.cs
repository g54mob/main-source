using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SINetworking;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class NetworkStartWindow : MonoBehaviour
{
	public static bool Dirty;

	public GUIWindow Window;

	public GUIListView LobbyList;

	public GUIListView PreviousList;

	public MenuItemScript MenuScript;

	public GUICombobox SteamGameType;

	public GUICombobox SteamLatency;

	public InputField GameName;

	public InputField GamePassword;

	public Button RefreshButton;

	public GameObject ResumeGameButton;

	public GameObject ServerTypePanel;

	public GameObject RedundantPanel;

	public GameObject IPButton;

	public GameObject HostPadding;

	public GameObject[] HostObjects;

	public GameObject[] JoinObjects;

	public Text RedundantLabel;

	public Text SwitchModeLabel;

	public RectTransform RefreshProgBack;

	public RectTransform RefreshProg;

	[NonSerialized]
	private float _nextRefresh;

	private bool _joinMode = true;

	public GameObject SteamFilterPanel;

	public GUICombobox YearAB;

	public GUICombobox Year;

	public GUICombobox DPM;

	public GUICombobox DifficultyAB;

	public GUICombobox Difficulty;

	public ThreeStateCheck Modded;

	public ThreeStateCheck ForcedIPO;

	public ThreeStateCheck PasswordProtected;

	public ThreeStateCheck CodeMods;

	public ThreeStateCheck FurnitureMods;

	[NonSerialized]
	private List<SaveGame> _redundantSaves = new List<SaveGame>();

	private bool _hasSorted;

	public void TogglePasswordVisible(bool visible)
	{
		GamePassword.contentType = ((!visible) ? InputField.ContentType.Password : InputField.ContentType.Standard);
		string text = GamePassword.text;
		GamePassword.text = text + "1";
		GamePassword.text = text;
	}

	public ELobbyComparison GetComp(GUICombobox combo)
	{
		if (combo.Selected == 0)
		{
			return ELobbyComparison.k_ELobbyComparisonEqualToOrLessThan;
		}
		if (combo.Selected == 1)
		{
			return ELobbyComparison.k_ELobbyComparisonEqual;
		}
		return ELobbyComparison.k_ELobbyComparisonEqualToOrGreaterThan;
	}

	private void Awake()
	{
		SteamGameType.UpdateContent(new string[3] { "PrivateSteamGame", "FriendsOnlySteamGame", "PublicSteamGame" });
		SteamLatency.UpdateContent(new string[3] { "Low", "Default", "High" });
		Year.UpdateContent(new int?[7] { null, 1980, 1990, 2000, 2010, 2020, 2030 });
		Year.SelectedItem = null;
		YearAB.UpdateContent(new string[3] { "TestBelow", "TestEqual", "TestAbove" });
		YearAB.Selected = 1;
		Difficulty.UpdateContent(new string[1].Concat(DifficultyValues.NetworkDifficultyComp.Select((DifficultyValues.DifficultySetting x) => x.Name)));
		Difficulty.SelectedItem = null;
		DifficultyAB.UpdateContent(new string[3] { "TestBelow", "TestEqual", "TestAbove" });
		DifficultyAB.Selected = 1;
		DPM.UpdateContent(new int?[9] { null, 1, 2, 3, 4, 5, 6, 7, 8 });
		DPM.SelectedItem = null;
		PreviousList.OnSelectChange = delegate
		{
			SaveGame firstSelected = PreviousList.GetFirstSelected<SaveGame>();
			if (firstSelected != null)
			{
				GameName.text = firstSelected.NetworkData.ServerName;
				GamePassword.text = firstSelected.NetworkData.Password ?? "";
				SteamGameType.Selected = (int)firstSelected.NetworkData.LobbyType;
			}
			ResumeGameButton.SetActive(firstSelected != null);
		};
	}

	private void Start()
	{
		SteamGameType.Selected = (int)SteamLayer.LobbyType;
		SteamLatency.Selected = 1;
		PreviousList["SaveGameUUID"].ToggleActive(false, false);
		LobbyList.OnDoubleClick = JoinButton;
	}

	public void UpdateLobbies()
	{
		LobbyList.Items = NetworkLayer.Active.Lobbies.Cast<object>().ToList();
	}

	public void ResumeLobby()
	{
		SaveGame firstSelected = PreviousList.GetFirstSelected<SaveGame>();
		if (firstSelected != null)
		{
			SteamLayer.LobbyType = firstSelected.NetworkData.LobbyType;
			GameData.LobbyName = firstSelected.NetworkData.ServerName.StripRichTags();
			GameData.LobbyPassword = (string.IsNullOrWhiteSpace(GamePassword.text) ? null : GamePassword.text);
			NetworkMeta networkMeta = (GameData.NetworkData = new NetworkMeta(firstSelected.NetworkData));
			GameData.NetworkAllowCodeMods = networkMeta.AllowCodeMods;
			GameData.NetworkAllowFurnitureMods = networkMeta.AllowModdedFurniture;
			if (!firstSelected.NetworkData.AllowCodeMods)
			{
				ModController.Instance.UnloadAllMods();
			}
			NetworkManager.Instance.Host = true;
			GameData.MultiplayerMode = true;
			MenuScript.LoadSave(firstSelected);
			Window.Close();
		}
	}

	public void JoinButton()
	{
		NetworkLobby firstSelected = LobbyList.GetFirstSelected<NetworkLobby>();
		if (firstSelected != null)
		{
			if (firstSelected.Compatible)
			{
				NetworkManager.Instance.HandleJoinLobby(firstSelected);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("IncompatibleLobby".Loc(), true, DialogWindow.DialogType.Error, Window);
			}
		}
	}

	public void StartLobby()
	{
		if (NetworkLayer.Active.CurrentLobby != null || string.IsNullOrWhiteSpace(GameName.text))
		{
			return;
		}
		Options.SaveToFile();
		SaveGameManager.Instance.Show(false, false, false, true, delegate(SaveGame y)
		{
			SteamLayer.LobbyType = (ELobbyType)SteamGameType.Selected;
			GameData.LobbyName = GameName.text.StripRichTags();
			GameData.LobbyPassword = (string.IsNullOrWhiteSpace(GamePassword.text) ? null : GamePassword.text);
			NetworkManager.Instance.Host = true;
			GameData.MultiplayerMode = true;
			if (y != null)
			{
				NetworkMeta networkMeta = (GameData.NetworkData = new NetworkMeta(y.NetworkData));
				GameData.NetworkAllowCodeMods = networkMeta.AllowCodeMods;
				GameData.NetworkAllowFurnitureMods = networkMeta.AllowModdedFurniture;
				if (!y.NetworkData.AllowCodeMods)
				{
					ModController.Instance.UnloadAllMods();
				}
				MenuScript.LoadSave(y);
			}
			else
			{
				MenuScript.Action(0);
			}
			Window.Close();
		}, true);
		SaveGameManager.Instance.SaveGameWindow.SetParentWindow(Window);
	}

	private void Update()
	{
		if (_nextRefresh > 0f)
		{
			_nextRefresh -= Time.deltaTime;
			RefreshProg.sizeDelta = new Vector2(RefreshProgBack.rect.width * (_nextRefresh / 5f), 0f);
			if (_nextRefresh <= 0f)
			{
				RefreshProg.sizeDelta = Vector2.zero;
				RefreshButton.interactable = true;
			}
		}
		if (Dirty)
		{
			RefreshSaveList();
		}
	}

	public void RefreshSaveList()
	{
		Dirty = false;
		List<SaveGame> list = (from x in SaveGameManager.SaveGames
			where x.NetworkData != null
			orderby x.RealTime descending
			select x).ToList();
		PreviousList.Items = list.Cast<object>().ToList();
		_redundantSaves.Clear();
		bool flag = PreviousList.Items.Count > 0;
		PreviousList.gameObject.SetActive(flag);
		HostPadding.SetActive(!flag);
		if (flag)
		{
			PreviousList.Select(0);
			PreviousList.OnSelectChange(false);
			List<SaveGame> list2 = list.ToList();
			for (int num = 0; num < list.Count; num++)
			{
				list2.Remove(list[num]);
				for (int num2 = 0; num2 < list2.Count; num2++)
				{
					if (list[num] != list2[num2] && list[num].NetworkData.ShareUUIDs(list2[num2].NetworkData))
					{
						_redundantSaves.Add(list2[num2]);
						list2.RemoveAt(num2);
						num2--;
					}
				}
			}
		}
		else
		{
			ResumeGameButton.SetActive(false);
		}
		RedundantPanel.SetActive(_redundantSaves.Count > 0);
		if (_redundantSaves.Count > 0)
		{
			RedundantLabel.text = "RedundantSaveFiles".Loc(_redundantSaves.Count, _redundantSaves.SumSafe((SaveGame x) => x.FileSize).ByteSize());
		}
	}

	public void ClearRedundant()
	{
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show("DeleteSaveConf".Loc(), false, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Yes", delegate
		{
			for (int i = 0; i < _redundantSaves.Count; i++)
			{
				SaveGameManager.Instance.DeleteSave(_redundantSaves[i], false);
			}
			_redundantSaves.Clear();
			RefreshSaveList();
			diag.Window.Close();
		}), new KeyValuePair<string, Action>("No", delegate
		{
			diag.Window.Close();
		}));
		diag.Window.SetParentWindow(Window);
	}

	public void DoPick(bool join)
	{
		_joinMode = join;
		SwitchModeLabel.text = (join ? "HostGame".Loc() : "JoinGame".Loc());
		JoinObjects.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(join);
		});
		HostObjects.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(!join);
		});
		HostPadding.SetActive(false);
		if (join)
		{
			UpdateLobbySort();
			if (_nextRefresh <= 0f)
			{
				RefreshLobbies();
			}
			SteamFilterPanel.SetActive(NetworkLayer.Active is SteamLayer);
			IPButton.SetActive(NetworkLayer.Active is LANLayer);
		}
		else
		{
			RefreshSaveList();
			ServerTypePanel.SetActive(NetworkLayer.Active is SteamLayer);
		}
	}

	public void SwitchMode()
	{
		_joinMode = !_joinMode;
		DoPick(_joinMode);
	}

	public void Show()
	{
		Show(_joinMode);
	}

	public void Show(bool join)
	{
		Options.RunInBackground = true;
		Window.Show();
		DoPick(join);
	}

	private void UpdateLobbySort()
	{
		if (!_hasSorted)
		{
			_hasSorted = true;
			GUIColumn gUIColumn = LobbyList["LobbyLocal"];
			LobbyList.LastSort = gUIColumn;
			gUIColumn.Sort(false);
		}
	}

	public void RefreshLobbies()
	{
		if (NetworkLayer.Active is SteamLayer)
		{
			_nextRefresh = 5f;
			RefreshButton.interactable = false;
		}
		LobbyList.Items.Clear();
		NetworkLayer.Active.QueryLobbies();
	}

	public void JoinDirect()
	{
		WindowManager.SpawnInputDialog("PleaseEnterIP".Loc(), "Multiplayer".Loc(), Options.LastIP, delegate(string x)
		{
			ValueTuple<string, int> valueTuple = LANLayer.ParseConnection(x, Options.GamePort);
			IPAddress address;
			if (IPAddress.TryParse(valueTuple.Item1, out address))
			{
				Options.LastIP = x;
				Options.SaveToFile();
				NetworkLobby lobby = new NetworkLobby("Unknown", new IPEndPoint(address, valueTuple.Item2), null);
				NetworkManager.Instance.HandleJoinLobby(lobby);
			}
		});
	}
}
