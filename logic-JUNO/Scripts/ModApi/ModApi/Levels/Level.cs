using System;
using System.Collections.Generic;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.Levels.Events;
using ModApi.Levels.Requirements;
using ModApi.Levels.Scores;
using ModApi.Scenes;
using ModApi.Scenes.Events;
using ModApi.Scenes.Parameters;
using ModApi.State;
using UnityEngine;

namespace ModApi.Levels
{
	public abstract class Level : MonoBehaviour, ILevel
	{
		private HashSet<string> _allowedPartTypes;

		private HashSet<string> _disallowedPartTypes;

		private bool _disposed;

		private bool _firstStageActivated;

		private FuelMonitor _fuelMonitor;

		private List<ILevelRequirement> _levelRequirements = new List<ILevelRequirement>();

		private ISceneManager _sceneManager;

		private LevelTimer _timer;

		public bool AllRequirementsPassed
		{
			get
			{
				foreach (ILevelRequirement levelRequirement in LevelRequirements)
				{
					if (levelRequirement.Status != LevelRequirementStatus.Pass)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool AnyRequirementFailed
		{
			get
			{
				foreach (ILevelRequirement levelRequirement in LevelRequirements)
				{
					if (levelRequirement.Status == LevelRequirementStatus.Fail)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool ContinueFlightUpdateEventsAfterCompletion { get; protected set; }

		public bool DisplayCraftFuelInDesigner { get; set; }

		public IFlightScene FlightScene { get; private set; }

		public virtual float FuelUsed
		{
			get
			{
				if (_fuelMonitor != null)
				{
					return _fuelMonitor.FuelUsed;
				}
				return 0f;
			}
		}

		GameObject ILevel.GameObject => base.gameObject;

		public bool IsComplete { get; private set; }

		public virtual LaunchLocation LaunchLocation
		{
			get
			{
				if (LevelData.LevelType == LevelType.Flight && LevelData.LaunchCraftId == null)
				{
					return null;
				}
				return new LaunchLocation("Launch Pad", LaunchLocationType.SurfaceLockedGround, "Droo", 0.0, -130.256, Vector3d.zero, 0.0, 66.7);
			}
		}

		public ILevelData LevelData { get; private set; }

		public IReadOnlyList<ILevelRequirement> LevelRequirements => _levelRequirements;

		public virtual bool OutOfFuel
		{
			get
			{
				if (_fuelMonitor != null)
				{
					return _fuelMonitor.OutOfFuel;
				}
				return false;
			}
		}

		public ICraftScript PlayerCraft { get; private set; }

		public virtual float Score { get; protected set; }

		public LevelTimer Timer
		{
			get
			{
				if (_timer == null)
				{
					_timer = new LevelTimer();
				}
				return _timer;
			}
		}

		public ILevelUI UI { get; private set; }

		protected string CurrentScene { get; private set; }

		protected IDesigner DesignerScene { get; private set; }

		protected virtual bool FailLevelIfCraftDestroyed { get; set; } = true;

		protected virtual bool FailLevelIfFuelEmpty { get; set; }

		protected bool SceneTransitionInProgress { get; private set; }

		event EventHandler<LevelEventArgs> ILevel.LevelEnded
		{
			add
			{
				_levelEnded += value;
			}
			remove
			{
				_levelEnded -= value;
			}
		}

		event EventHandler<LevelCompletedEventArgs> ILevel.LevelFailed
		{
			add
			{
				_levelFailed += value;
			}
			remove
			{
				_levelFailed -= value;
			}
		}

		event EventHandler<LevelCompletedEventArgs> ILevel.LevelPassed
		{
			add
			{
				_levelPassed += value;
			}
			remove
			{
				_levelPassed -= value;
			}
		}

		private event EventHandler<LevelEventArgs> _levelEnded;

		private event EventHandler<LevelCompletedEventArgs> _levelFailed;

		private event EventHandler<LevelCompletedEventArgs> _levelPassed;

		void ILevel.Cleanup()
		{
			if (!_disposed)
			{
				_disposed = true;
				_sceneManager.SceneLoading -= OnSceneLoading;
				_sceneManager.SceneLoaded -= OnSceneLoaded;
				_sceneManager.SceneUnloading -= OnSceneUnloading;
				_sceneManager.SceneUnloaded -= OnSceneUnloaded;
				_sceneManager.SceneTransitionStarted -= OnSceneTransitionStarted;
				_sceneManager.SceneTransitionCompleted -= OnSceneTransitionCompleted;
				OnCleanup();
			}
		}

		public virtual string GetPersistentMessage()
		{
			return null;
		}

		string ILevel.GetUIXml()
		{
			return InvokeSceneFunction(CurrentScene, GetFlightUIXml, GetDesignerUIXml);
		}

		public virtual bool HasRequiredParts(ICraftScript craft, out string missingPartsMessage)
		{
			missingPartsMessage = string.Empty;
			return true;
		}

		void ILevel.Initialize(ILevelData levelData, ISceneManager sceneManager)
		{
			LevelData = levelData;
			_sceneManager = sceneManager;
			_sceneManager.SceneLoading += OnSceneLoading;
			_sceneManager.SceneLoaded += OnSceneLoaded;
			_sceneManager.SceneUnloading += OnSceneUnloading;
			_sceneManager.SceneUnloaded += OnSceneUnloaded;
			_sceneManager.SceneTransitionStarted += OnSceneTransitionStarted;
			_sceneManager.SceneTransitionCompleted += OnSceneTransitionCompleted;
			CurrentScene = _sceneManager.CurrentScene;
			_allowedPartTypes = new HashSet<string>();
			_disallowedPartTypes = new HashSet<string>();
			IsComplete = false;
			ContinueFlightUpdateEventsAfterCompletion = false;
			OnInitialized();
		}

		void ILevel.Initialize(ILevelUI levelUI)
		{
			UI = levelUI;
			OnLevelUIInitialized();
		}

		public abstract void InitializeRequirements();

		public virtual bool IsLegalCraft(ICraftScript craft)
		{
			bool flag = true;
			foreach (PartData part in craft.Data.Assembly.Parts)
			{
				flag &= IsLegalCraftPart(part);
			}
			return flag;
		}

		public virtual bool IsLegalCraftPart(PartData part)
		{
			return IsPartTypeAllowedWithCachedLookup(part.PartType);
		}

		public bool IsLevelScene(string sceneName)
		{
			if (!(sceneName == "Flight"))
			{
				if (sceneName == "Design")
				{
					return LevelData.LevelType == LevelType.Design;
				}
				return false;
			}
			return true;
		}

		bool ILevel.IsPartTypeAllowed(PartType partType)
		{
			return IsPartTypeAllowedWithCachedLookup(partType);
		}

		void ILevel.OnFixedUpdate()
		{
			OnFixedUpdate();
		}

		void ILevel.OnLateUpdate()
		{
			OnLateUpdate();
		}

		void ILevel.OnUpdate()
		{
			OnUpdate();
		}

		void ILevel.OverrideFlightSceneLoadParameters(FlightSceneLoadParameters loadParameters)
		{
			OverrideFlightSceneLoadParameters(loadParameters);
		}

		protected ILevelRequirement AddLevelRequirement(ILevelRequirement levelRequirement)
		{
			_levelRequirements.Add(levelRequirement);
			return levelRequirement;
		}

		protected void CompleteLevel(bool success, float score)
		{
			if (IsComplete)
			{
				return;
			}
			IsComplete = true;
			LevelScore score2 = new LevelScore(score, DateTime.UtcNow);
			if (success)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.LevelSuccess);
				try
				{
					OnLevelPassed(score2);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				this._levelPassed?.Invoke(this, new LevelCompletedEventArgs(this, score2));
			}
			else
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.LevelFail);
				try
				{
					OnLevelFailed(score2);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
				this._levelFailed?.Invoke(this, new LevelCompletedEventArgs(this, score2));
			}
		}

		protected virtual string GetDesignerUIXml()
		{
			return null;
		}

		protected virtual string GetFlightUIXml()
		{
			return null;
		}

		protected virtual bool IsPartTypeAllowed(PartType partType)
		{
			return true;
		}

		protected virtual void OnCleanup()
		{
		}

		protected virtual void OnDesignFixedUpdate()
		{
		}

		protected virtual void OnDesignLateUpdate()
		{
		}

		protected virtual void OnDesignSceneExit()
		{
		}

		protected virtual void OnDesignSceneLoaded()
		{
		}

		protected virtual void OnDesignSceneLoading()
		{
		}

		protected virtual void OnDesignSceneReady()
		{
		}

		protected virtual void OnDesignSceneUnloaded()
		{
		}

		protected virtual void OnDesignSceneUnloading()
		{
		}

		protected virtual void OnDesignUpdate()
		{
		}

		protected virtual void OnDestroy()
		{
			((ILevel)this).Cleanup();
		}

		protected virtual void OnFirstStageActivated()
		{
		}

		protected virtual void OnFixedUpdate()
		{
			if (!SceneTransitionInProgress)
			{
				InvokeSceneAction(CurrentScene, FlightFixedUpdate, DesignFixedUpdate);
			}
		}

		protected virtual void OnFlightFixedUpdate()
		{
		}

		protected virtual void OnFlightLateUpdate()
		{
		}

		protected virtual void OnFlightSceneExit()
		{
		}

		protected virtual void OnFlightSceneLoaded()
		{
		}

		protected virtual void OnFlightSceneLoading()
		{
		}

		protected virtual void OnFlightSceneReady()
		{
		}

		protected virtual void OnFlightSceneUnloaded()
		{
		}

		protected virtual void OnFlightSceneUnloading()
		{
		}

		protected virtual void OnFlightUpdate()
		{
		}

		protected virtual void OnInitialized()
		{
		}

		protected virtual void OnLateUpdate()
		{
			if (!SceneTransitionInProgress)
			{
				InvokeSceneAction(CurrentScene, FlightLateUpdate, DesignLateUpdate);
			}
			_fuelMonitor?.LateUpdate();
		}

		protected virtual void OnLevelFailed(LevelScore score)
		{
		}

		protected virtual void OnLevelPassed(LevelScore score)
		{
		}

		protected virtual void OnLevelUIInitialized()
		{
		}

		protected virtual void OnPlayerCraftChanged(ICraftScript previousCraft, ICraftScript newCraft)
		{
		}

		protected virtual void OnPlayerCraftDestroyed()
		{
		}

		protected virtual void OnSceneLoaded(string scene)
		{
		}

		protected virtual void OnSceneLoading(string scene)
		{
		}

		protected virtual void OnSceneTransitionCompleted(string fromScene, string toScene)
		{
		}

		protected virtual void OnSceneTransitionStarted(string fromScene, string toScene)
		{
		}

		protected virtual void OnSceneUnloaded(string scene)
		{
		}

		protected virtual void OnSceneUnloading(string scene)
		{
		}

		protected virtual void OnUpdate()
		{
			if (!SceneTransitionInProgress)
			{
				_timer?.Update();
				InvokeSceneAction(CurrentScene, FlightUpdate, DesignUpdate);
			}
		}

		protected virtual void OverrideFlightSceneLoadParameters(FlightSceneLoadParameters loadParameters)
		{
		}

		private static void InvokeSceneAction(string scene, Action flightSceneAction, Action designerSceneAction)
		{
			if (scene == "Flight")
			{
				flightSceneAction();
			}
			else if (scene == "Design")
			{
				designerSceneAction();
			}
		}

		private static TResult InvokeSceneFunction<TResult>(string scene, Func<TResult> flightSceneFunction, Func<TResult> designerSceneFunction)
		{
			if (scene == "Flight")
			{
				return flightSceneFunction();
			}
			if (scene == "Design")
			{
				return designerSceneFunction();
			}
			return default(TResult);
		}

		private static TResult InvokeSceneFunction<T1, TResult>(string scene, Func<T1, TResult> flightSceneFunction, Func<T1, TResult> designerSceneFunction, T1 value)
		{
			if (scene == "Flight")
			{
				return flightSceneFunction(value);
			}
			if (scene == "Design")
			{
				return designerSceneFunction(value);
			}
			return default(TResult);
		}

		private void DesignerSceneCraftLoaded()
		{
			ICraftScript playerCraft = PlayerCraft;
			PlayerCraft = DesignerScene.CraftScript;
			OnPlayerCraftChanged(playerCraft, PlayerCraft);
		}

		private void DesignFixedUpdate()
		{
			OnDesignFixedUpdate();
		}

		private void DesignLateUpdate()
		{
			OnDesignLateUpdate();
		}

		private void DesignSceneLoaded()
		{
			DesignerScene = Game.Instance.Designer;
			PlayerCraft = DesignerScene.CraftScript;
			DesignerScene.CraftLoaded += DesignerSceneCraftLoaded;
			OnDesignSceneLoaded();
			UI?.OnSceneLoaded();
		}

		private void DesignSceneLoading()
		{
			OnDesignSceneLoading();
		}

		private void DesignSceneUnloaded()
		{
			DesignerScene = null;
			PlayerCraft = null;
			OnDesignSceneUnloaded();
		}

		private void DesignSceneUnloading()
		{
			DesignerScene.CraftLoaded -= DesignerSceneCraftLoaded;
			OnDesignSceneUnloading();
		}

		private void DesignUpdate()
		{
			OnDesignUpdate();
		}

		private void FlightFixedUpdate()
		{
			if (!IsComplete || ContinueFlightUpdateEventsAfterCompletion)
			{
				OnFlightFixedUpdate();
			}
		}

		private void FlightLateUpdate()
		{
			if (!IsComplete || ContinueFlightUpdateEventsAfterCompletion)
			{
				OnFlightLateUpdate();
			}
		}

		private void FlightSceneCraftChanged(ICraftNode craftNode)
		{
			ICraftScript playerCraft = PlayerCraft;
			if (playerCraft != null && playerCraft.CraftNode != null)
			{
				playerCraft.CraftNode.Destroyed -= PlayerCraftDestroyed;
			}
			PlayerCraft = craftNode.CraftScript;
			if (craftNode != null)
			{
				craftNode.Destroyed += PlayerCraftDestroyed;
			}
			OnPlayerCraftChanged(playerCraft, PlayerCraft);
		}

		private void FlightSceneLoaded()
		{
			FlightScene = Game.Instance.FlightScene;
			PlayerCraft = FlightScene.CraftNode.CraftScript;
			FlightScene.CraftChanged += FlightSceneCraftChanged;
			FlightScene.CraftNode.Destroyed += PlayerCraftDestroyed;
			_fuelMonitor = new FuelMonitor(PlayerCraft);
			_firstStageActivated = false;
			InitializeRequirements();
			OnFlightSceneLoaded();
			UI?.OnSceneLoaded();
		}

		private void FlightSceneLoading()
		{
			OnFlightSceneLoading();
		}

		private void FlightSceneUnloaded()
		{
			FlightScene = null;
			PlayerCraft = null;
			OnFlightSceneUnloaded();
		}

		private void FlightSceneUnloading()
		{
			UI?.OnSceneUnloading();
			_fuelMonitor = null;
			_levelRequirements.Clear();
			FlightScene.CraftChanged -= FlightSceneCraftChanged;
			if (FlightScene.CraftNode != null)
			{
				FlightScene.CraftNode.Destroyed -= PlayerCraftDestroyed;
			}
			OnFlightSceneUnloading();
		}

		private void FlightUpdate()
		{
			if (!IsComplete || ContinueFlightUpdateEventsAfterCompletion)
			{
				if (!_firstStageActivated && PlayerCraft.PrimaryCommandPod.CurrentStage > 0)
				{
					_firstStageActivated = true;
					OnFirstStageActivated();
				}
				foreach (ILevelRequirement levelRequirement in LevelRequirements)
				{
					levelRequirement.FlightUpdate();
				}
				OnFlightUpdate();
			}
			_fuelMonitor.Update();
			if (!IsComplete && FailLevelIfFuelEmpty && OutOfFuel)
			{
				CompleteLevel(success: false, 0f);
			}
		}

		private bool IsPartTypeAllowedWithCachedLookup(PartType partType)
		{
			string id = partType.Id;
			if (_allowedPartTypes.Contains(id))
			{
				return true;
			}
			if (_disallowedPartTypes.Contains(id))
			{
				return false;
			}
			bool num = IsPartTypeAllowed(partType);
			if (num)
			{
				_allowedPartTypes.Add(id);
				return num;
			}
			_disallowedPartTypes.Add(id);
			return num;
		}

		private void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			OnSceneLoaded(e.Scene);
			InvokeSceneAction(e.Scene, FlightSceneLoaded, DesignSceneLoaded);
		}

		private void OnSceneLoading(object sender, SceneEventArgs e)
		{
			CurrentScene = e.Scene;
			OnSceneLoading(e.Scene);
			InvokeSceneAction(e.Scene, FlightSceneLoading, DesignSceneLoading);
		}

		private void OnSceneTransitionCompleted(object sender, SceneTransitionEventArgs e)
		{
			SceneTransitionInProgress = false;
			OnSceneTransitionCompleted(e.TransitionFromScene, e.TransitionToScene);
			InvokeSceneAction(e.TransitionToScene, OnFlightSceneReady, OnDesignSceneReady);
		}

		private void OnSceneTransitionStarted(object sender, SceneTransitionEventArgs e)
		{
			if (!IsLevelScene(e.TransitionToScene))
			{
				this._levelEnded?.Invoke(this, new LevelEventArgs(this));
				return;
			}
			SceneTransitionInProgress = true;
			OnSceneTransitionStarted(e.TransitionFromScene, e.TransitionToScene);
			InvokeSceneAction(e.TransitionFromScene, OnFlightSceneExit, OnDesignSceneExit);
		}

		private void OnSceneUnloaded(object sender, SceneEventArgs e)
		{
			CurrentScene = _sceneManager.CurrentScene;
			IsComplete = false;
			UI = null;
			_timer = null;
			OnSceneUnloaded(e.Scene);
			InvokeSceneAction(e.Scene, FlightSceneUnloaded, DesignSceneUnloaded);
		}

		private void OnSceneUnloading(object sender, SceneEventArgs e)
		{
			OnSceneUnloading(e.Scene);
			InvokeSceneAction(e.Scene, FlightSceneUnloading, DesignSceneUnloading);
		}

		private void PlayerCraftDestroyed(INode node)
		{
			OnPlayerCraftDestroyed();
			if (FailLevelIfCraftDestroyed && !IsComplete)
			{
				CompleteLevel(success: false, Score);
			}
		}
	}
}
