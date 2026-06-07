using System;
using DV.Common;
using DV.UserManagement.Data;
using Newtonsoft.Json.Linq;

namespace DV.Items.Brick
{
	public abstract class BrickRom
	{
		protected const string SAVE_GAME_KEY = "BrickRomSaveData";

		protected readonly BrickAssets assets;

		protected readonly BrickScreen screen;

		protected readonly BrickAudio audio;

		private User user;

		protected JObject saveData;

		public abstract string GameName { get; protected set; }

		protected bool GamePaused { get; private set; }

		public event Action GameStarted;

		public event Action GameEnded;

		public abstract void Tick();

		protected abstract void StartGame();

		protected abstract void EndGame();

		protected void FireGameStarted()
		{
			this.GameStarted?.Invoke();
		}

		protected void FireGameEnded()
		{
			this.GameEnded?.Invoke();
		}

		protected BrickRom(BrickAssets assets, BrickScreen screen, BrickAudio audio, User user)
		{
			this.assets = assets;
			this.screen = screen;
			this.audio = audio;
			this.user = user;
		}

		protected string GetRomSpecificSaveGameKey()
		{
			return "BrickRomSaveData_" + GameName;
		}

		public virtual void ExecuteInput(BrickInput.BrickInputAction action)
		{
			switch (action)
			{
			case BrickInput.BrickInputAction.PowerOn:
				GamePaused = false;
				StartGame();
				break;
			case BrickInput.BrickInputAction.PowerOff:
				EndGame();
				screen.ClearScreen();
				GamePaused = false;
				break;
			case BrickInput.BrickInputAction.Pause:
			case BrickInput.BrickInputAction.Resume:
			{
				bool flag = action == BrickInput.BrickInputAction.Pause;
				if (GamePaused != flag)
				{
					GamePaused = flag;
					GamePauseChanged();
				}
				break;
			}
			}
		}

		protected virtual void GamePauseChanged()
		{
			if (!(audio == null))
			{
				if (GamePaused)
				{
					audio.PauseAudio();
				}
				else
				{
					audio.ResumeAudio();
				}
			}
		}

		protected JObject GetSaveData()
		{
			return user?.GameData?[GetRomSpecificSaveGameKey()] as JObject;
		}

		protected void SaveGame()
		{
			if (user != null && saveData != null)
			{
				user.GameData[GetRomSpecificSaveGameKey()] = saveData;
				user.Save(UserSavingMode.JustUser);
			}
		}
	}
}
