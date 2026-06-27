using System.ComponentModel;
using System.Runtime.CompilerServices;
using Restory.Data.GameConfigs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class GameVersionCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly GameConfig gameConfig;

		private const string COMMON_CATEGORY = "Game Version Cheats";

		[Category("Game Version Cheats")]
		[DisplayName("Selected Version")]
		public string SelectedVersionType => gameConfig.VersionType.ToString() ?? "";

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Game Version Cheats")]
		[DisplayName("Demo")]
		public void SetDemoVersion()
		{
			ChangeGameVersionType(VersionType.Demo);
		}

		[Category("Game Version Cheats")]
		[DisplayName("Playtest")]
		public void SetPlaytestVersion()
		{
			ChangeGameVersionType(VersionType.Playtest);
		}

		[Category("Game Version Cheats")]
		[DisplayName("Release")]
		public void SetReleaseVersion()
		{
			ChangeGameVersionType(VersionType.Release);
		}

		private void ChangeGameVersionType(VersionType versionType)
		{
			gameConfig.ReplaceVersionType(versionType);
			Debug.Log("Cheat command: same switched to " + versionType.ToString() + " version type");
			OnPropertyChanged("SelectedVersionType");
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		[Inject]
		public GameVersionCheats(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
		}
	}
}
