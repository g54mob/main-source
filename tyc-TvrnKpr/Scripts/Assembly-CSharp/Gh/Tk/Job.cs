using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Gh.Tk.Story;
using LitJson;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[PersistenceOptIn]
	public abstract class Job : IPersistable, IReferenceableObject, ICustomSaveState, IContextMenuProvider
	{
		private static ObservableCollection<Job> _jobs;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _jobAbortIsSuspended;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _ignoreWorkHours;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _iterateWhenAborting;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool RunWhenGameIsPaused;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool OnHold;

		[PersistenceOptIn]
		public string AdditionalJobStateDisplayInfo;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _manuallyStarted;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _name;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool KeepAliveWhenSourceIsNull;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool TargetWasSet;

		[PersistenceObjectReference]
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private GameObjectX _owner;

		public static EventHandler<EventArgs> PriorityChanged;

		[PersistenceOptIn]
		private int _priority;

		[PersistenceOptIn]
		[PersistenceDefaultValue(JobErrorHandlingStrategy.Abort)]
		protected JobErrorHandlingStrategy ErrorHandlingStrategy;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _abortHandlingStrategy;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _temporaryAbortHandlingStrategy;

		[PersistenceOptIn]
		public string ManualOverrideDescriptionKey;

		[PersistenceOptIn]
		[JsonAlias("State", false)]
		private JobState _state;

		protected bool _isDestroyed;

		[PersistenceOptIn]
		private float _pausedUntil;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected float _suspendValidityCheckRefreshUntil;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool _isJobValid;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		public List<Job> ParentJobs;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<Job> SubJobs;

		private DataStore _activityStateToRestore;

		private IEnumerator<Activity> _activitiesEnumerator;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected GameObjectXMatchInfo _matchInfo;

		private List<Action> _onErrorActions;

		private List<Action> _cleanupActions;

		private List<Action> _finishActions;

		internal Activity HandoverActivity;

		private int _currentResets;

		internal Activity ResetJobActivity;

		internal DataStore _stateData;

		public static ObservableCollection<Job> Jobs => null;

		public bool JobAbortIsSuspended
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreWorkHours
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ManuallyStarted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsAborting => false;

		public string Name => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string HighLevelTaskDescriptionKey { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX Source { get; protected set; }

		public Actor ActorSource => null;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX Target { get; protected set; }

		[PersistenceOptIn]
		public float Timestamp { get; private set; }

		[PersistenceOptIn]
		public int Id { get; private set; }

		public GameObjectX Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int Priority
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public string JobRole { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string IdleTimeJobRole { get; set; }

		public string JobRoleKey => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IgnoreParentCancel { get; set; }

		public string AbortHandlingStrategy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool NotifyTargetUsedOnFinish { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool CanAbortJobForFree { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public Actor RestrictToActor { get; set; }

		public JobState State
		{
			get
			{
				return default(JobState);
			}
			protected set
			{
			}
		}

		public Activity CurrentActivity { get; private set; }

		protected bool ShouldReset { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public ActiveStory SourceStory { get; set; }

		public static event EventHandler StateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnAiComponentAddedOrRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		public static void Add(Job job)
		{
		}

		internal static void ClearJobs()
		{
		}

		public static IEnumerable<Job> GetFreeJobs()
		{
			return null;
		}

		protected Job()
		{
		}

		private void RoomOnAllRoomsChanged(object sender, EventArgs e)
		{
		}

		private void Room_AfterZoneChanged(object sender, EventArgs e)
		{
		}

		private void ValidPropsChanged(object sender, EventArgs e)
		{
		}

		public virtual void InitPostLoad()
		{
		}

		public IDisposable EnsureToIterateWhenAborting()
		{
			return null;
		}

		public void UpdateOnHold()
		{
		}

		public virtual void SetOnHold(bool onHold)
		{
		}

		protected virtual bool CheckOnHoldInternal()
		{
			return false;
		}

		protected bool CheckOnHoldInternal(bool ignoreWhenBroken)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		protected Job(GameObjectX source, GameObjectX target = null, int priority = 0)
		{
		}

		private void Target_MandatoryAccessPointIsObstructedChanged(object sender, EventArgs e)
		{
		}

		internal virtual void ForceCompleteReset(bool removeOwner = true, bool forceDestroy = false)
		{
		}

		public string GetHighLevelTaskDescriptionKey()
		{
			return null;
		}

		protected virtual string GetHighLevelTaskDescriptionKeyInternal()
		{
			return null;
		}

		protected void UpdateHighLevelTaskDescriptionOnActor()
		{
		}

		public string GetJobRole()
		{
			return null;
		}

		public void SetTemporaryAbortHandlingStrategy(string abortHandlingStrategy)
		{
		}

		protected void OnStateChanged()
		{
		}

		public (string, string) GetStaffJobDisplayState()
		{
			return default((string, string));
		}

		public void DestroyJob(bool destroyParentToo = false, bool forceDestroy = false)
		{
		}

		public float GetAge()
		{
			return 0f;
		}

		public void PauseJobFor(float seconds)
		{
		}

		public virtual bool IsPaused()
		{
			return false;
		}

		public bool IsRunning()
		{
			return false;
		}

		public IEnumerable<GameObjectX> GetAllActiveOwners()
		{
			return null;
		}

		protected virtual bool EnableValidityCheck()
		{
			return false;
		}

		protected virtual bool CheckIsValidInternal()
		{
			return false;
		}

		public bool CheckIsValid(bool forceRefresh = false)
		{
			return false;
		}

		public void Cancel()
		{
		}

		public virtual void ForceDestroy(bool destroyParentToo = false)
		{
		}

		protected virtual void OnAbortedInternal()
		{
		}

		public void OnAborted()
		{
		}

		public IEnumerable<Job> GetAllSubJobs(bool recursive = false)
		{
			return null;
		}

		public IEnumerable<Job> GetAllParentJobsIncludingSelf()
		{
			return null;
		}

		public void AddSubJob(Job job)
		{
		}

		public void RemoveSubJob(Job job)
		{
		}

		public bool CanPlayerAbortJob()
		{
			return false;
		}

		public virtual void Abort(bool destroy = false)
		{
		}

		private void FinalizeJob()
		{
		}

		public DataStore SaveActivityState()
		{
			return null;
		}

		private void ApplyActivityState()
		{
		}

		protected bool HandleCurrentActivity()
		{
			return false;
		}

		public void Update()
		{
		}

		public virtual bool IsValid()
		{
			return false;
		}

		public abstract IEnumerable<Activity> GetActivities();

		public void AddOnErrorAction(Action action)
		{
		}

		protected virtual void OnErrorInternal()
		{
		}

		private void OnError()
		{
		}

		public void AddCleanupAction(Action action)
		{
		}

		protected virtual void OnCleanupInternal()
		{
		}

		private void OnCleanup()
		{
		}

		public void AddFinishAction(Action action)
		{
		}

		protected virtual void OnFinishInternal()
		{
		}

		private void OnFinish()
		{
		}

		public Activity ForceImmediateContinueSubJobWithSameOwner(Job job)
		{
			return null;
		}

		public Activity HandoverToSubjob(Job job, bool sameActor = true, bool originalActorResumesJob = true, JobErrorHandlingStrategy errorHandlingStrategy = JobErrorHandlingStrategy.Default, string subJobId = null, bool inheritPriority = true, bool inheritAbortHandlingStrategy = false, bool inheritSkill = false, bool inheritRestrictToActor = true)
		{
			return null;
		}

		protected Activity ResetJob(int maxReset = 2147483647)
		{
			return null;
		}

		public void ResetDataStore()
		{
		}

		public virtual bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		public virtual IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		public virtual IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public virtual void Start()
		{
		}

		public bool HasStateVariable(string key)
		{
			return false;
		}

		public T GetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public void SetStateVariable<T>(string key, T value)
		{
		}

		public void RemoveStateVariable(string key)
		{
		}

		public T GetOrSetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public bool IsPartActiveOrSet(int value, string key = "default")
		{
			return false;
		}

		public bool PartWasNeverActiveBefore(int value, string key = "default")
		{
			return false;
		}

		public virtual void SaveState(IDataStore data)
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}

		protected void NotifyStoryThatJobCompleted()
		{
		}

		protected void NotifyStoryThatJobFailed()
		{
		}
	}
}
