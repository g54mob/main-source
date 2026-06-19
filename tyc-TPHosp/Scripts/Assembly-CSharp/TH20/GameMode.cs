#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TH20
{
	public abstract class GameMode : MustCallDestroy
	{
		protected App App { get; private set; }

		public Metagame Metagame { get; protected set; }

		public MetagameMap MetagameMap { get; private set; }

		private bool IsLoading { get; set; }

		public abstract string GetMetagameSceneName();

		public abstract State CreateStateMachine(MetagameMap metagameMap);

		public abstract bool OnlineFeaturesEnabled();

		protected GameMode()
		{
			Metagame = null;
		}

		public virtual void Init(App app)
		{
			App = app;
		}

		public override void Destroy()
		{
			if (MetagameMap != null)
			{
				MetagameMap.Uninitialise();
				MetagameMap.Destroy();
				MetagameMap = null;
			}
			if (Metagame != null)
			{
				Metagame.Destroy();
				Metagame = null;
			}
			base.Destroy();
		}

		public void Update(float deltaTime, float unscaledDeltaTime)
		{
			if (Metagame != null)
			{
				Metagame.Update(deltaTime, unscaledDeltaTime);
			}
		}

		public virtual void Restart()
		{
			App.StartCoroutine(RestartAsync(App.SaveSystem.CurrentSaveSlot));
		}

		public IEnumerator RestartAsync(int saveSlotIndex)
		{
			IsLoading = true;
			yield return App.UnloadLevelIfLoaded();
			App.SaveSystem.DeleteAllLevelSaves(saveSlotIndex);
			yield return Unload();
			yield return LoadAsyncInner(ignoreSave: true, saveSlotIndex);
			IsLoading = false;
		}

		public IEnumerator Unload()
		{
			Logging.Info(LogChannels.GameFlow, "Unloading metagame");
			if (MetagameMap != null)
			{
				try
				{
					Logging.Info(LogChannels.GameFlow, "Uninitialising metagame map");
					MetagameMap.Uninitialise();
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.GameFlow, "Exception thrown while uninitialising metagame map: {0}", ex);
				}
				try
				{
					Logging.Info(LogChannels.GameFlow, "Destroying metagame map");
					MetagameMap.Destroy();
				}
				catch (Exception ex2)
				{
					Logging.Error(LogChannels.GameFlow, "Exception thrown while destroying metagame map: {0}", ex2);
				}
				MetagameMap = null;
			}
			if (Metagame != null)
			{
				try
				{
					Logging.Info(LogChannels.GameFlow, "Destroying metagame");
					Metagame.Destroy();
				}
				catch (Exception ex3)
				{
					Logging.Error(LogChannels.GameFlow, "Exception thrown while destroying metgame: {0}", ex3);
				}
				Metagame = null;
			}
			Scene sceneByName = SceneManager.GetSceneByName(GetMetagameSceneName());
			if (sceneByName.isLoaded)
			{
				Logging.Info(LogChannels.GameFlow, "Unloading metagame scene");
				yield return SceneManager.UnloadSceneAsync(sceneByName);
				yield return Resources.UnloadUnusedAssets();
			}
			else
			{
				yield return null;
			}
			Logging.Info(LogChannels.GameFlow, "Metagame unloaded");
		}

		public IEnumerator LoadAsync(bool ignoreSave, int saveSlotIndex)
		{
			IsLoading = true;
			yield return LoadAsyncInner(ignoreSave, saveSlotIndex);
			IsLoading = false;
		}

		private IEnumerator LoadAsyncInner(bool ignoreSave, int saveSlotIndex)
		{
			Logging.Info(LogChannels.GameFlow, "Starting load GameMode coroutine");
			yield return App.FadeOutCoroutine(App.Config.LevelLoadFadeTime, Color.white);
			App.LoadSaveProgressScreen.Show();
			while (App.LoadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			yield return App.LoadLevelCommon();
			Logging.Info(LogChannels.GameFlow, "Loading metagame scene");
			Application.backgroundLoadingPriority = ThreadPriority.Low;
			AsyncOperation loadMetagameOperation = SceneManager.LoadSceneAsync(GetMetagameSceneName(), LoadSceneMode.Additive);
			loadMetagameOperation.allowSceneActivation = true;
			while (!loadMetagameOperation.isDone)
			{
				float num = Mathf.Clamp01(loadMetagameOperation.progress / 0.9f);
				App.LoadSaveProgressScreen.SetProgress(0.25f + num * 0.5f);
				yield return null;
			}
			yield return loadMetagameOperation;
			App.LoadSaveProgressScreen.SetProgress(0.75f);
			LoadMetagame(ignoreSave, saveSlotIndex);
			if (Metagame == null)
			{
				Logging.Info(LogChannels.GameFlow, "Metagame failed to load; returning to frontend");
				yield return Unload();
				App.OpeningScreen.Show();
				App.LoadSaveProgressScreen.Hide();
				while (App.LoadSaveProgressScreen.IsAnimating)
				{
					yield return null;
				}
				yield return App.FadeInCoroutine(App.Config.LevelLoadFadeTime, Color.white);
				MetagameSaveHeader backupCareerHeader = null;
				if (App.SaveSystem.TryGetBackupCareerSave(saveSlotIndex, out var saveData))
				{
					backupCareerHeader = saveData.MetagameSaveHeader;
				}
				App.BackupSave.ShowCareerBackup(saveSlotIndex, backupCareerHeader);
				yield break;
			}
			yield return null;
			App.LoadSaveProgressScreen.SetProgress(0.85f);
			Logging.Info(LogChannels.GameFlow, "Initialising metagame map");
			MetagameMap = UnityEngine.Object.FindObjectOfType<MetagameMap>();
			MetagameMap.Initialise(App, App.MetagameMapScene, GetMetagameSceneName(), App.InputManager, App.LevelCommonScript.MenusTransform, App.LevelCommonScript.InWorldTransform, App.SaveSystem, App.UserPreferences, App.LocalPreferences);
			App.LoadSaveProgressScreen.SetProgress(1f);
			yield return null;
			Logging.Info(LogChannels.GameFlow, "Setting active scene to metagame");
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(GetMetagameSceneName()));
			App.LoadSaveProgressScreen.Hide();
			while (App.LoadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			Logging.Info(LogChannels.GameFlow, "Showing metagame map");
			MetagameMap.Open();
			yield return App.FadeInCoroutine(App.Config.LevelLoadFadeTime, Color.white);
			Logging.Info(LogChannels.GameFlow, "Faded in");
			PostLoad();
		}

		public virtual bool LoadMetagame(bool ignoreSave, int saveSlotIndex)
		{
			OnlineManager.SetGameMode(App.GameMode);
			bool result = false;
			if (Metagame != null)
			{
				Metagame.Destroy();
				Metagame = null;
			}
			if (ignoreSave)
			{
				Logging.Info(LogChannels.GameFlow, "Loading metagame while being told to ignore save file; creating new metagame data");
				Metagame = new Metagame(App.Config.MetagameConfig.Instance, App);
				App.SaveSystem.CurrentSaveSlot = saveSlotIndex;
				Metagame.AwardPrimeGamingKudosh();
			}
			else
			{
				Debug.AssertMode currentAssertMode = Debug.CurrentAssertMode;
				Debug.CurrentAssertMode = Debug.AssertMode.ThrowException;
				try
				{
					Logging.Info(LogChannels.GameFlow, "Trying to load metagame save");
					MetagameSaveDataAndHeader metagameSaveDataAndHeader = App.SaveSystem.LoadMetagameSaveData(saveSlotIndex);
					if (metagameSaveDataAndHeader != null)
					{
						Logging.Info(LogChannels.GameFlow, "Successfully loaded metagame save on startup");
						Stopwatch stopwatch = new Stopwatch();
						stopwatch.Start();
						if (metagameSaveDataAndHeader.MetagameSaveData == null)
						{
							throw new CorruptSaveException("Loaded metagame save data is null; must have had error on save");
						}
						if (metagameSaveDataAndHeader.MetagameSaveData.Metagame == null)
						{
							throw new CorruptSaveException("Loaded metagame is null; must have had error on save");
						}
						Metagame = metagameSaveDataAndHeader.MetagameSaveData.Metagame;
						stopwatch.Stop();
						long num = stopwatch.ElapsedTicks / 10;
						Logging.Info(LogChannels.Save, "Loaded metagame in {0}s", (float)num / 1000000f);
						try
						{
							stopwatch.Reset();
							stopwatch.Start();
							App.IsRestoringFromSave = true;
							Metagame.RestoreFromSave(App.Config.MetagameConfig.Instance, App);
							App.IsRestoringFromSave = false;
							stopwatch.Stop();
							long num2 = stopwatch.ElapsedTicks / 10;
							Logging.Info(LogChannels.Save, "Restored metagame from save in {0}s", (float)num2 / 1000000f);
						}
						catch (Exception ex)
						{
							App.IsRestoringFromSave = false;
							Logging.Info(LogChannels.Save, "Exception while restoring metagame save after a load. Could be a bug, could be an old save. Exception: " + ex);
							try
							{
								if (Metagame != null)
								{
									Metagame.Destroy();
								}
							}
							catch (Exception ex2)
							{
								Logging.Warning(LogChannels.Save, "Failed to destroy metagame after failed restore. Exception: " + ex2);
								throw new CorruptSaveUnstableGameException("Failed to restore metagame after load, and failed to destroy the partially restored object too. (destroy exception is logged)", ex);
							}
							Metagame = null;
							throw new CorruptSaveException("Failed to restore metagame after load", ex);
						}
					}
					else
					{
						Logging.Info(LogChannels.Save, "No metagame save exists yet; creating new metagame data");
						Metagame = new Metagame(App.Config.MetagameConfig.Instance, App);
					}
				}
				catch (Exception ex3)
				{
					Logging.Error(LogChannels.Save, "Exception encountered whilst loading metagame save: " + ex3);
					Metagame = null;
					if (ex3 is CorruptSaveUnstableGameException)
					{
						result = true;
					}
				}
				finally
				{
					Debug.CurrentAssertMode = currentAssertMode;
				}
			}
			return result;
		}

		protected virtual void PostLoad()
		{
		}

		public virtual bool AllowGameToBeSaved()
		{
			return true;
		}

		public virtual void RestartLevel()
		{
			if (App.Level != null)
			{
				App.LoadLevel(App.Level.Config, null, ignoreSave: true);
			}
		}
	}
}
