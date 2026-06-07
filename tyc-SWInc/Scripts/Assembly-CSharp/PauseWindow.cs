using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using Achievements;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
	public GameObject Panel;

	public GameObject MoveButton;

	public GameObject LoadButton;

	public GameObject DisableCanvas;

	public GameObject PauseBlocker;

	public Text IPLabel;

	[NonSerialized]
	private List<GUIWindow> _disabledWindows;

	public void ToggleShow()
	{
		Panel.SetActive(!Panel.activeSelf);
		if (Panel.activeSelf)
		{
			if (NetworkManager.IsConnected && NetworkLayer.Active is LANLayer)
			{
				IPLabel.gameObject.SetActive(true);
				if (NetworkManager.IsHost)
				{
					IPLabel.text = ((TcpListener)NetworkManager.Instance.HostPlayer.ConnectionObject).LocalEndpoint.ToString();
				}
				else
				{
					NetworkPlayer hostPlayer = NetworkManager.Instance.HostPlayer;
					TcpClient tcpClient;
					if ((tcpClient = ((hostPlayer != null) ? hostPlayer.ConnectionObject : null) as TcpClient) != null)
					{
						IPLabel.text = tcpClient.Client.RemoteEndPoint.ToString();
					}
					else
					{
						IPLabel.gameObject.SetActive(false);
					}
				}
			}
			else
			{
				IPLabel.gameObject.SetActive(false);
			}
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
			MoveButton.SetActive(!GameSettings.Instance.IsNetworkMode && !GameSettings.Instance.EditMode && !GameSettings.Instance.HasDanger());
			LoadButton.SetActive(!GameSettings.Instance.IsNetworkMode);
			_disabledWindows = WindowManager.DisableAll(true);
			DisableCanvas.SetActive(false);
			PauseBlocker.SetActive(true);
			HUD.Instance.CloseDropDownPanels();
		}
		else
		{
			OptionsWindow.Instance.Window.Close();
			SaveGameManager.Instance.SaveGameWindow.Close();
			GameSettings.ForcePause = false;
			DisableCanvas.SetActive(true);
			PauseBlocker.SetActive(false);
			WindowManager.EnableAll(_disabledWindows);
		}
	}

	public void CaptureScreenshot()
	{
		GameSettings.Instance.StartCoroutine(ReportScreen());
		ToggleShow();
	}

	public IEnumerator ReportScreen()
	{
		HUD.Instance.BlurScript.blurSize = 0f;
		yield return null;
		string path = Path.Combine(Path.GetFullPath("./"), "ScreenCap.png");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		ScreenCapture.CaptureScreenshot(path);
		while (!File.Exists(path))
		{
			yield return new WaitForEndOfFrame();
		}
		FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Feedback, path, false, false, null, path);
	}

	private void MoveCompany(SaveGame x)
	{
		try
		{
			SaveGameManager.Instance.ShowWaitPanel();
			float num = (GameSettings.Instance.RentMode ? GameSettings.Instance.sRoomManager.AllFurniture.Where((Furniture y) => !y.PlacedInEditMode && !y.PartOfGen && string.IsNullOrEmpty(y.MetalMarket) && !"Award".Equals(y.Type)).SumSafe((Furniture y) => y.GetSellPrice()) : GameSettings.Instance.GetMapCost(true));
			bool flag = false;
			SaveGame saveGame = null;
			if (!GameSettings.Instance.RentMode && GameSettings.Instance.sRoomManager.Rooms.Count > 0)
			{
				saveGame = SaveGameManager.Instance.BuildingSave();
				flag = true;
			}
			if (flag && saveGame == null)
			{
				SaveGameManager.Instance.HideWaitPanel();
				return;
			}
			if (x == null)
			{
				num -= PlotArea.StartPlotPrice;
				if (!GameSettings.Instance.MyCompany.CanMakeTransaction(num))
				{
					WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
					SaveGameManager.Instance.DeleteSave(saveGame, false);
					SaveGameManager.Instance.HideWaitPanel();
					return;
				}
				FrameTransition.StartTransition(true);
				SaveGameManager.Instance.AutoSave();
				GameSettings.Instance.sRoomManager.AllFurniture.Where((Furniture z) => z != null && "Award".Equals(z.Type)).ForEachEnum(GameSettings.AddToInventory);
				GameSettings.Instance.sRoomManager.AllFurniture.Where((Furniture z) => z != null && !string.IsNullOrEmpty(z.MetalMarket)).ForEachEnum(delegate(Furniture z)
				{
					GameSettings.Instance.OffshoreAccount += z.GetSellPrice();
					GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
					AchievementController.SetInteraction(AchievementController.Mechanics.OffshoreAccount);
				});
				GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, true, "Relocation");
				byte[] companyData = GameReader.CreateDictionaryData(GameReader.NewLoadMode.Company, Writeable.LoadType.Default, 0);
				GameData.DaysPerMonth = GameSettings.DaysPerMonth;
				SaveGameManager.LoadGame(null, companyData, SDateTime.Now(), false, true, false, false);
				return;
			}
			GameData.LoadYear = SDateTime.Now().RealYear;
			float[] buildMeta = x.GetBuildMeta();
			bool flag2 = false;
			if (buildMeta[0] == 1f)
			{
				num -= buildMeta[2];
				if (!GameSettings.Instance.MyCompany.CanMakeTransaction(num))
				{
					flag2 = true;
					WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
				}
			}
			byte[] companyData2 = null;
			if (!flag2)
			{
				SaveGameManager.Instance.AutoSave();
				GameSettings.Instance.sRoomManager.AllFurniture.Where((Furniture z) => z != null && "Award".Equals(z.Type)).ForEachEnum(GameSettings.AddToInventory);
				GameSettings.Instance.sRoomManager.AllFurniture.Where((Furniture z) => z != null && !string.IsNullOrEmpty(z.MetalMarket)).ForEachEnum(delegate(Furniture z)
				{
					GameSettings.Instance.OffshoreAccount += z.GetSellPrice();
					GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
					AchievementController.SetInteraction(AchievementController.Mechanics.OffshoreAccount);
				});
				GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, true, "Relocation");
				companyData2 = GameReader.CreateDictionaryData(GameReader.NewLoadMode.Company, Writeable.LoadType.Default, 0);
				GameData.DaysPerMonth = GameSettings.DaysPerMonth;
			}
			FrameTransition.StartTransition(true);
			if (flag2 || !SaveGameManager.LoadGame(x, companyData2, SDateTime.Now(), false, true, true, false))
			{
				if (!flag2)
				{
					GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Construction, true, "Relocation");
				}
				SaveGameManager.Instance.DeleteSave(saveGame, false);
				SaveGameManager.Instance.HideWaitPanel();
				GameData.LoadYear = 0;
			}
		}
		catch (Exception exception)
		{
			SaveGameManager.Instance.HideWaitPanel();
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void DoAction(int i)
	{
		switch (i)
		{
		case 0:
			ToggleShow();
			break;
		case 1:
			if (CheckRentModeError())
			{
				SaveGameManager.Instance.AutoSave(false, null, true);
			}
			break;
		case 2:
			if (CheckRentModeError())
			{
				SaveGameManager.Instance.Show(true, false, GameSettings.Instance.EditMode);
			}
			break;
		case 3:
			SaveGameManager.Instance.Show(false, false);
			break;
		case 4:
			OptionsWindow.Instance.Show();
			break;
		case 5:
			CheckSave(QuitToMainMenu);
			break;
		case 6:
			CheckSave(delegate
			{
				bool isConnected = NetworkManager.IsConnected;
				if (isConnected)
				{
					NetworkMessaging.SendDisconnectPlayer(false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					NetworkMessaging.SendAllNow();
					NetworkManager.Instance.CleanUpEverything(true);
				}
				GameSettings.UnloadNow();
				DevConsole.Console.SaveHistory();
				SteamManager.Shutdown();
				if (isConnected)
				{
					Application.Quit();
				}
				else
				{
					Process.GetCurrentProcess().Kill();
				}
			});
			break;
		case 7:
			if (GameSettings.Instance.IsNetworkMode)
			{
				break;
			}
			if (GameSettings.Instance.CampaignMode && !GameSettings.Instance.CompletedMissions.Contains("Mission11"))
			{
				if (GameSettings.Instance.CurrentMissions.Contains("Mission02"))
				{
					foreach (Actor item in GameSettings.Instance.sActorManager.Others["Parent"].ToList())
					{
						item.DestroyGO();
						item.OnDestroy();
					}
					MoveCompany(SaveGame.LoadGame("Campaign/Rentable", true, false, true));
				}
				else if (GameSettings.Instance.CurrentMissions.Contains("Mission06"))
				{
					GameData.Climate = GameData.ClimateType.Temperate;
					GameData.Environment = GameData.EnvironmentType.City;
					GameData.RandomString = "MakeyDaMaps";
					MoveCompany(null);
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("CampaignLockError".Loc(), true, DialogWindow.DialogType.Error);
				}
			}
			else
			{
				SaveGameManager.Instance.Show(false, false, true, true, MoveCompany);
			}
			break;
		}
	}

	public static void QuitToMainMenu()
	{
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.DisconnectMyself();
			NetworkMessaging.SendAllNow();
			NetworkManager.Instance.CleanUpEverything(true);
		}
		GameSettings.Instance.LoadingText.text = "LoadDestroyScene".Loc();
		GameSettings.Instance.LoadingImage.gameObject.SetActive(false);
		GameSettings.Instance.LoadingCamera.gameObject.SetActive(true);
		GameSettings.UnloadNow();
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		GameSettings.Instance = null;
		FrameTransition.StartTransition(true);
		DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("MainMenu");
	}

	public static void CheckSave(Action a)
	{
		if (GameSettings.Instance.IsNetworkMode)
		{
			GameSettings.HasQuitSaved = true;
			SaveGameManager.Instance.AutoSave();
			lock (GameReader.WriteLock)
			{
				a();
				return;
			}
		}
		TimeSpan span = DateTime.Now - GameSettings.Instance.LastSaveTime;
		if (span.TotalMinutes < 1.0)
		{
			a();
			return;
		}
		WindowManager.Instance.ShowMessageBox("QuitConfirmation".Loc(span.GetString()), false, DialogWindow.DialogType.Question, delegate
		{
			if (CheckRentModeError())
			{
				SaveGameManager.Instance.AutoSave();
				lock (GameReader.WriteLock)
				{
					a();
				}
			}
		}, null, a);
	}

	public static bool CheckRentModeError(bool prompt = true)
	{
		RoomManager sRoomManager = GameSettings.Instance.sRoomManager;
		if (GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
		{
			if (!sRoomManager.Rooms.Any((Room x) => x.PlayerOwned && x.Rentable))
			{
				if (prompt)
				{
					WindowManager.Instance.ShowMessageBox("RentModeEditorError".Loc(), true, DialogWindow.DialogType.Error);
				}
				return false;
			}
			HashSet<PathNode<Vector3>> hashSet = new HashSet<PathNode<Vector3>>();
			HashSet<Room> hashSet2 = new HashSet<Room>();
			foreach (Room room2 in sRoomManager.Rooms)
			{
				if (!room2.Rentable)
				{
					continue;
				}
				Room room = room2.ParentRoom ?? room2;
				if (!hashSet2.Add(room))
				{
					continue;
				}
				hashSet.Clear();
				if (FindPathToOutsideRent(room, room, hashSet))
				{
					continue;
				}
				if (prompt)
				{
					SelectorController.Instance.SetSelection(room);
					if (BuildController.Instance.CanChangeFloor())
					{
						CameraScript.Instance.MoveTo(room.GetFlatPos(), room.GetFloor());
					}
					DataOverlay.Instance.ActivateFunc("Rent");
					DataOverlay.ShowPlayerOwned = false;
					WindowManager.Instance.ShowMessageBox("RentModeMazeError".Loc(), true, DialogWindow.DialogType.Error);
				}
				return false;
			}
		}
		return true;
	}

	private static bool FindPathToOutsideRent(Room parentRent, Room current, HashSet<PathNode<Vector3>> visited)
	{
		if (current.Outside)
		{
			return true;
		}
		if (current.Rentable && (current.ParentRoom ?? current) != parentRent)
		{
			return false;
		}
		foreach (PathNode<Vector3> pathNode in current.PathNodes)
		{
			if (FindPathToOutsideRent(parentRent, pathNode, visited))
			{
				return true;
			}
		}
		return false;
	}

	private static bool FindPathToOutsideRent(Room parentRent, PathNode<Vector3> current, HashSet<PathNode<Vector3>> visited)
	{
		if (visited.Add(current))
		{
			Room room;
			if ((object)(room = current.Tag as Room) != null)
			{
				if (room.Outside)
				{
					return true;
				}
				if (room.Rentable && (room.ParentRoom ?? room) != parentRent)
				{
					return false;
				}
				if (FindPathToOutsideRent(parentRent, room, visited))
				{
					return true;
				}
			}
			foreach (PathNode<Vector3> connection in current.GetConnections())
			{
				if (FindPathToOutsideRent(parentRent, connection, visited))
				{
					return true;
				}
			}
		}
		return false;
	}
}
