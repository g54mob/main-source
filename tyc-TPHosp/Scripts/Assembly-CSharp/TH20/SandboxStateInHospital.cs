using System;
using I2.Loc;

namespace TH20
{
	public class SandboxStateInHospital : BaseStateInHospital
	{
		private readonly App _app;

		private readonly SandboxSettings _settings;

		private readonly bool _restartLevel;

		private readonly bool _saveOldLevel;

		private readonly bool _newGame;

		public SandboxStateInHospital(App app, MetagameMap map, SandboxSettings settings, bool restartLevel = false, bool saveOldLevel = true, bool newGame = false)
			: base(map)
		{
			_app = app;
			_settings = settings;
			_restartLevel = restartLevel;
			_saveOldLevel = saveOldLevel;
			_newGame = newGame;
		}

		public override void Enter()
		{
			base.Enter();
			bool flag = SandboxSaveManager.CurrentSettings != _settings;
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			if (_saveOldLevel && SandboxSaveManager.CurrentSettings != null)
			{
				_app.QuickSaveInstantly();
			}
			SandboxSaveManager.CurrentSettings = _settings;
			LevelConfig levelConfig = _settings.LevelConfig;
			if (_restartLevel)
			{
				_app.GameMode.Restart();
				MetagameMap.Close(levelConfig, ignoreSave: true, saveOldLevel: false);
				return;
			}
			if (MetagameMap.Level != null && !flag)
			{
				MetagameMap.Close();
				return;
			}
			bool flag2 = _app.GameMode.LoadMetagame(_newGame, 0);
			Metagame = _app.GameMode.Metagame;
			if (Metagame == null)
			{
				if (flag2)
				{
					_app.MessageBox.Show(ScriptLocalization.Menu_Messages.Sandbox_Load_Failed_Unstable_Title_CS, ScriptLocalization.Menu_Messages.Sandbox_Load_Failed_Unstable_Body_CS, ScriptLocalization.Menu_Messages.OK_Button_CS);
				}
				else
				{
					_app.MessageBox.Show(ScriptLocalization.Menu_Messages.Sandbox_Load_Failed_Title_CS, ScriptLocalization.Menu_Messages.Sandbox_Load_Failed_Body_CS, ScriptLocalization.Menu_Messages.OK_Button_CS);
				}
				_app.GameMode.LoadMetagame(ignoreSave: true, 0);
				SandboxSaveManager.CurrentSettings = null;
				PopState();
			}
			else
			{
				MetagameMap.Close(levelConfig, ignoreSave: false, saveOldLevel: false, forceLevelLoad: true);
			}
		}

		public override void Destroy()
		{
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			base.Destroy();
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			_settings.Apply(level, loadedFromSave);
		}

		public override void OnReturnToMetagameMap()
		{
			if (base.Owner.TopState == this)
			{
				PopState();
			}
		}
	}
}
