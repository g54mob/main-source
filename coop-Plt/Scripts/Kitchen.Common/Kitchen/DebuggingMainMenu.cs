using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class DebuggingMainMenu : MainMenuSubmenu
	{
		public LabelElement ResultLabel;

		public DebuggingMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			DrawMainPage(player_id);
		}

		private void Write(object txt)
		{
			ResultLabel.SetLabel(txt.ToString());
		}

		private void StartNewPage(int player_id, bool main_page = true)
		{
			ModuleList.Clear();
			ResultLabel = AddInfoText("info text");
			if (!main_page)
			{
				AddButton("Back", delegate
				{
					DrawMainPage(player_id);
				});
			}
		}

		private void DrawMainPage(int player_id)
		{
			StartNewPage(player_id);
			if (PlatformSettings.IsSwitch)
			{
				AddButton("Switch Specific", delegate
				{
					DrawPageSwitch(player_id);
				});
			}
			if (Platform.Current.SupportsLeaderboards)
			{
				AddButton("Leaderboards", delegate
				{
					DrawPageLeaderboards(player_id);
				});
			}
			AddButton("Open software keyboard", async delegate
			{
				TestKeyboard();
			});
			AddButton("Get DLCs", delegate
			{
				ResultLabel.SetLabel($"Has DLC: {Platform.Current.HasDLC(4293)}");
			});
			AddButton("Controller Check", delegate
			{
				TestControllers(player_id);
			});
			AddButton("Grant Achievement", delegate
			{
				Platform.Current.UnlockAchievement("OH_NO", new List<PlatformUser> { InputSourceIdentifier.Default.GetPlatformUser(Players.Main.Get(player_id).ID) });
			});
		}

		private void DrawPageLeaderboards(int player_id)
		{
			StartNewPage(player_id, main_page: false);
			AddButton("Submit leaderboard", delegate
			{
				Platform.Current.SubmitScore(SpeedrunHelpers.GetCurrentLeaderboard(), 124);
			});
			AddButton("Get Best leaderboard", async delegate
			{
				(int, float) tuple = await Platform.Current.GetScore(SpeedrunHelpers.GetCurrentLeaderboard(), 0, modded_mode: false, skip_percentile: false);
				ResultLabel.SetLabel($"{tuple.Item1} / {tuple.Item2}");
			});
		}

		private void DrawPageSwitch(int player_id)
		{
			StartNewPage(player_id, main_page: false);
		}

		public void TestControllers(int main_user)
		{
			Dictionary<int, ControllerType> localPlayerControllersDebug = InputSourceIdentifier.Default.GetLocalPlayerControllersDebug();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, ControllerType> item in localPlayerControllersDebug)
			{
				string text = ((main_user == item.Key) ? "!" : "");
				string text2 = (InputSourceIdentifier.Default.IsPlayerDisconnected(item.Key) ? "x" : "");
				string bindingName = InputSourceIdentifier.Default.GetBindingName(item.Key, Controls.Interact1);
				string tMPIcon = GameData.Main.GlobalLocalisation.ControllerIcons.GetTMPIcon(item.Value, bindingName);
				ControllerPathMap mapByControl = GameData.Main.GlobalLocalisation.ControllerIcons.GetMapByControl(item.Value, bindingName);
				stringBuilder.AppendLine($"{item.Key} ({text}{text2}): {item.Value}/{bindingName}/{mapByControl.Button}/{tMPIcon}");
			}
			ResultLabel.SetLabel(stringBuilder.ToString());
		}

		public async void TestKeyboard()
		{
			bool needed = PlatformSettings.UseSoftwareKeyboard;
			Task<(bool, string)> result = Platform.Current.OpenSoftwareKeyboard("Title", 10, "placeholder");
			int ticks = 0;
			while (!result.IsCompleted)
			{
				ticks++;
				await Task.Delay(100);
			}
			ResultLabel.SetLabel($"SWKB Result {ticks.ToString()}, {result.Result.Item2} (needed: {needed})");
		}
	}
}
