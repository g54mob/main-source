using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public abstract class State : ScriptableObject
	{
		[HideInInspector]
		public bool Active = true;

		public MAnimal animal;

		protected Transform transform;

		[Space]
		[Tooltip("Input to Activate the State, leave empty for automatic states")]
		public string Input;

		[Tooltip("Input to Exit the State, leave empty for automatic states")]
		public StringReference ExitInput;

		[Tooltip("Profiles works as profiles to activate different ways of using a State. E.g. You can fly as Ironman or with a Broom")]
		public IntReference m_StateProfile = new IntReference();

		[Tooltip("Forces the State to move always forward. E.g. when Flying the animal will not stay idling in one place")]
		public BoolReference AlwaysForward = new BoolReference();

		[Tooltip("Priority of the State. Higher value -> more priority to be activated")]
		public int Priority;

		[Tooltip("If the State is trying to be activated by an Input, and it failed... then Reset the Input Value")]
		public bool resetInputOnFailed;

		[Tooltip("When Entering this state the last state Animator Parameter will be be reset to -1")]
		public bool ResetLastState;

		[Tooltip("Main/Core Modifier. When the Animal enters the Main Animation, it will change the core parameters of the Animal")]
		public AnimalModifier General;

		[Tooltip("Main/Core Animation Messages. When the Animal enters the Main Animation,It will send messages to the Animal Components")]
		public List<MesssageItem> GeneralMessage;

		public List<TagModifier> TagModifiers = new List<TagModifier>();

		[Tooltip("When Sending messages, it will use Unity: SendMessage, instead of the IAnimatorListener Interface")]
		public bool UseSendMessage;

		[Tooltip("When Sending messages, it will send the messages to all the Animal Children gameobjects")]
		public bool IncludeChildren = true;

		internal Vector3 MovementAxisMult;

		[Tooltip(" To Allow to Exit the state, the Animations need to use the [Allow Exit Behaviour] on the Animator.")]
		public bool AllowExitFromAnim;

		[Tooltip("The State can be Activated even when it's already the Current Active state. Usefull for Double Jumps")]
		public bool CanTransitionToItself;

		[Tooltip("Sleep from state check if the Active State is on this list. Set this value to false to invert the list")]
		public bool IncludeSleepState = true;

		[Tooltip("If the Active State is one of one on the List, the state cannot be activated")]
		public List<StateID> SleepFromState = new List<StateID>();

		[Tooltip(" If A mode is Enabled and is one of one on the List ...the state cannot be activated")]
		public List<ModeID> SleepFromMode = new List<ModeID>();

		[Tooltip("When the State is active, Disable these modes. Modes will be internally disabled")]
		public List<ModeID> DisableModes = new List<ModeID>();

		[Tooltip("Do not allow any modes when using this State. Modes will be internally disabled")]
		public BoolReference noModes = new BoolReference();

		[Tooltip("If The state is trying to be active but the active State is on this list, the State will be queued until the Active State is not inlcuded on the queue list")]
		public List<StateID> QueueFrom = new List<StateID>();

		[Tooltip("If the State exit, it cannot be used again until one of these states on this list gets activated.\nE.g. You can disable fly and not using it again until the animal uses Idle or Locomotion.")]
		public List<StateID> ResetFrom = new List<StateID>();

		[Tooltip(" If A Stance is active, and is one of one on the List ...the state cannot be activated")]
		public List<StanceID> SleepFromStance = new List<StanceID>();

		[Tooltip("Which stances are allowed during this State. Leave empty to include all")]
		public List<StanceID> stances = new List<StanceID>();

		[Tooltip("Try States will try to activate every X frames")]
		public IntReference TryLoop = new IntReference(1);

		[Tooltip("Keeps the state enabled for x seconds. It executes internally the AllowExit() state method. If is set to zero this will be ignored.")]
		public FloatReference Duration = new FloatReference();

		[Tooltip("Tag to Identify Entering Animations on a State.\nE.g. (TakeOff) in Fly, EnterWater on Swim")]
		public StringReference EnterTag = new StringReference();

		[Tooltip("Tag to Identify Exiting Animations on a State.\nE.g. (Land) in Fall, or SwimClimb in Swim")]
		public StringReference ExitTag = new StringReference();

		[Tooltip("Try Exit State on Main State Animation. E.g. The Fall Animation can try to exit only when is on the Fall Animation")]
		public bool ExitOnMain = true;

		[Tooltip("Time needed to activate this state again after exit")]
		public FloatReference EnterCooldown = new FloatReference(0f);

		[Tooltip("Time needed to exit this state after being activated")]
		public FloatReference ExitCooldown = new FloatReference(0f);

		[Tooltip("Can straffing be used with this State?")]
		public bool CanStrafe;

		[Tooltip("This state has new  strafe animations. If is set to false, then it will not update the Animator with the [StateOn] Paramter")]
		public bool StrafeAnimations = true;

		[Tooltip("Strafe Multiplier when movement is detected. This will make the Character be aligned to the Strafe Direction Quickly")]
		[Range(0f, 1f)]
		public float MovementStrafe = 1f;

		[Tooltip("Strafe Multiplier when there's no movement. This will make the Character be aligned to the Strafe Direction Quickly")]
		[Range(0f, 1f)]
		public float IdleStrafe = 1f;

		public bool m_debug = true;

		[HideInInspector]
		public int Editor_Tabs1;

		internal OnEnterExitState EnterExitEvent;

		public List<MSpeedSet> SpeedSets = new List<MSpeedSet>();

		[Tooltip("ID to Identify the State. The name of the ID is the Core Tag used on the Animator")]
		public StateID ID;

		private IAnimatorListener[] listeners;

		private IEnumerator C_Duration;

		public Vector3 Position
		{
			get
			{
				return transform.position;
			}
			set
			{
				transform.position = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return transform.rotation;
			}
			set
			{
				transform.rotation = value;
			}
		}

		public int EnterStatus { get; set; }

		public bool GizmoDebug
		{
			get
			{
				if (m_debug)
				{
					return animal.debugGizmos;
				}
				return false;
			}
		}

		public abstract string StateName { get; }

		public abstract string StateIDName { get; }

		public bool IsActiveState => animal.ActiveState == this;

		protected float Height => animal.Height;

		internal Vector3 MovementRaw => animal.MovementAxisRaw;

		internal Vector3 MovementSmooth => animal.MovementAxisSmoothed;

		protected Vector3 Gravity => animal.Gravity;

		protected LayerMask GroundLayer => animal.GroundLayer;

		protected Vector3 UpVector => animal.UpVector;

		protected Vector3 Forward => animal.Forward;

		protected Vector3 Up => animal.Up;

		protected Vector3 Right => animal.Right;

		protected Vector3 DeltaPos => animal.DeltaPos;

		protected float ScaleFactor => animal.ScaleFactor;

		public bool NoModes => noModes.Value;

		public bool OnHoldByReset { get; set; }

		public bool HasResetFrom => ResetFrom.Count > 0;

		public bool HasStances
		{
			get
			{
				if (stances != null)
				{
					return stances.Count > 0;
				}
				return false;
			}
		}

		public virtual bool KeepForwardMovement => false;

		protected QueryTriggerInteraction IgnoreTrigger => QueryTriggerInteraction.Ignore;

		public int UniqueID { get; private set; }

		protected Animator Anim => animal.Anim;

		public bool CanBeActivated
		{
			get
			{
				string color = "orange";
				if (ActiveState == null)
				{
					DebugingState("Activating [" + base.name + "] failed. There's no active State (First Creation)", color);
					return false;
				}
				if (animal.JustActivateState)
				{
					DebugingState("Activating [" + base.name + "] failed. Another state was just activated", color);
					return false;
				}
				if (!Active || IsSleep)
				{
					DebugingState("Activating [" + base.name + "] failed. State is disabled or Animal is set to Sleep", color);
					return false;
				}
				if (ActiveState.Priority > Priority && ActiveState.IgnoreLowerStates)
				{
					DebugingState("Activating [" + base.name + "] failed. Current State has High Priority and [Ignore Lower States] is On", color);
					return false;
				}
				if (IsActiveState && !CanTransitionToItself)
				{
					DebugingState("Activating [" + base.name + "] failed. State is already active and [Can transition to Self] is False", color);
					return false;
				}
				if (OnEnterCoolDown)
				{
					DebugingState("Activating [" + base.name + "] failed. State is still in on Enter Cooldown", color);
					return false;
				}
				if (OnHoldByReset)
				{
					DebugingState("Activating [" + base.name + "] failed. State [On Hold by Reset]. It needs other states to Reset it", color);
					return false;
				}
				if (ActiveState.IsPending)
				{
					if (ActiveState.Priority < Priority)
					{
						DebugingState($"Activating [{base.name}] Override Pending. Current State Priority [{ActiveState.Priority}] Animation", color);
						return true;
					}
					DebugingState("Activating [" + base.name + "] failed. The Current State is Pending.. it has not enter its Main Animation", color);
					return false;
				}
				return true;
			}
		}

		public bool OnEnterCoolDown
		{
			get
			{
				if ((float)EnterCooldown > 0f)
				{
					return !MTools.ElapsedTime(CurrentExitTime, EnterCooldown.Value);
				}
				return false;
			}
		}

		public int MainTagHash { get; private set; }

		protected int ExitTagHash { get; private set; }

		protected int EnterTagHash { get; private set; }

		public bool InExitAnimation
		{
			get
			{
				if (ExitTagHash != 0)
				{
					return ExitTagHash == CurrentAnimTag;
				}
				return false;
			}
		}

		public bool InEnterAnimation
		{
			get
			{
				if (EnterTagHash != 0)
				{
					return EnterTagHash == CurrentAnimTag;
				}
				return false;
			}
		}

		internal float CurrentExitTime { get; set; }

		internal float CurrentEnterTime { get; set; }

		public int StateProfile
		{
			get
			{
				return m_StateProfile.Value;
			}
			set
			{
				m_StateProfile.Value = value;
			}
		}

		protected int CurrentAnimTag => animal.AnimStateTag;

		protected State ActiveState => animal.ActiveState;

		protected State CurrentActiveState => ActiveState;

		public bool CanExit { get; internal set; }

		public virtual bool InputValue { get; set; }

		public virtual bool ExitInputValue { get; set; }

		public virtual bool IsSleepFromState { get; internal set; }

		public virtual bool IsSleepFromMode { get; internal set; }

		public virtual bool IsSleepFromStance { get; internal set; }

		public virtual bool IsSleep
		{
			get
			{
				if (!IsSleepFromMode && !IsSleepFromState)
				{
					return IsSleepFromStance;
				}
				return true;
			}
		}

		public virtual bool OnQueue { get; internal set; }

		public bool OnActiveQueue { get; internal set; }

		public bool InCoreAnimation { get; internal set; }

		public float CurrentSpeedPos
		{
			get
			{
				return animal.CurrentSpeedModifier.position;
			}
			set
			{
				animal.currentSpeedModifier.position = value;
			}
		}

		public MSpeed CurrentSpeed => animal.CurrentSpeedModifier;

		public bool IsPersistent { get; set; }

		public bool IgnoreLowerStates { get; set; }

		public bool IsPending { get; set; }

		public virtual float GravityMultiplier => 1f;

		public virtual bool TryOverride { get; set; }

		internal bool ValidStance(StanceID currentStance)
		{
			if (!HasStances)
			{
				return true;
			}
			return stances.Contains(currentStance);
		}

		private void DebugingState(string value, string color1 = "white")
		{
		}

		protected bool StateAnimationTags(int MainTag)
		{
			if (MainTagHash == MainTag)
			{
				return true;
			}
			return TagModifiers.Find((TagModifier tag) => tag.TagHash == MainTag) != null;
		}

		public void AwakeState(MAnimal mAnimal)
		{
			animal = mAnimal;
			transform = animal.transform;
			AwakeState();
			TryOverride = true;
		}

		public virtual void InputAxisUpdate()
		{
			animal.InputAxisUpdate();
		}

		public virtual void AwakeState()
		{
			if (ID == null)
			{
				Debug.LogError("State " + base.name + " is missing its ID", this);
			}
			MainTagHash = Animator.StringToHash(ID.name);
			ExitTagHash = Animator.StringToHash(ExitTag.Value);
			EnterTagHash = Animator.StringToHash(EnterTag.Value);
			foreach (TagModifier tagModifier in TagModifiers)
			{
				tagModifier.TagHash = Animator.StringToHash(tagModifier.AnimationTag);
			}
			if (SpeedSets == null || SpeedSets.Count == 0)
			{
				SpeedSets = new List<MSpeedSet>();
				foreach (MSpeedSet speedSet in animal.speedSets)
				{
					if (speedSet.states.Contains(ID))
					{
						SpeedSets.Add(speedSet);
					}
				}
			}
			foreach (MSpeedSet speedSet2 in SpeedSets)
			{
				speedSet2.CurrentIndex = speedSet2.StartVerticalIndex;
			}
			if (SpeedSets.Count > 0)
			{
				SpeedSets.Sort();
			}
			EnterExitEvent = animal.OnEnterExitStates.Find((OnEnterExitState st) => st.ID == ID);
			InputValue = false;
			ExitInputValue = false;
			OnHoldByReset = false;
			ResetState();
			ResetStateValues();
			if ((int)TryLoop < 1)
			{
				TryLoop = 1;
			}
			UniqueID = Random.Range(0, 99999);
			if (!UseSendMessage)
			{
				if (IncludeChildren)
				{
					listeners = animal.GetComponentsInChildren<IAnimatorListener>();
				}
				else
				{
					listeners = animal.GetComponents<IAnimatorListener>();
				}
			}
		}

		public virtual Vector3 Speed_Direction()
		{
			return animal.Forward * Mathf.Abs(animal.VerticalSmooth);
		}

		public bool CheckQueuedState()
		{
			if (OnQueue)
			{
				OnActiveQueue = true;
				Debugging("<color=green>[Active*Queued]</color>. Allow Exit to Active State: [" + ActiveState.ID.name + "]");
				ActiveState.AllowExit();
				animal.QueueState = this;
				return true;
			}
			return false;
		}

		internal void ConnectInput(IInputSource InputSource, bool connect)
		{
			if (connect)
			{
				InputSource.ConnectInput(Input, ActivatebyInput);
			}
			else
			{
				InputSource.DisconnectInput(Input, ActivatebyInput);
			}
			if (connect)
			{
				InputSource.ConnectInput(ExitInput, ExitByInput);
			}
			else
			{
				InputSource.DisconnectInput(ExitInput, ExitByInput);
			}
			ExtraInputs(InputSource, connect);
		}

		public virtual void ExtraInputs(IInputSource InputSource, bool connect)
		{
		}

		public virtual void Activate(int StateStatus)
		{
			EnterStatus = StateStatus;
			animal.State_SetEnterStatus(EnterStatus);
			Activate();
		}

		public virtual void Activate()
		{
			if (CheckQueuedState())
			{
				return;
			}
			if (ActiveState.IsPending)
			{
				ActiveState.IsPending = false;
			}
			animal.LastState = animal.ActiveState;
			animal.Check_Queue_States(ID);
			if (animal.LastState != this)
			{
				DisableModes_Temp(disable: false, animal.LastState.DisableModes);
			}
			if (animal.QueueReleased)
			{
				animal.QueueState.ActivateQueued();
			}
			else if (!animal.JustActivateState)
			{
				Debugging("Activated");
				animal.ActiveState = this;
				animal.LastState?.PostExitState();
				SetSpeed();
				MovementAxisMult = Vector3.one;
				if (animal.LastState != this)
				{
					DisableModes_Temp(disable: true, DisableModes);
				}
				CanExit = false;
				CurrentEnterTime = Time.time;
				if (animal.LastState != ActiveState)
				{
					IsPending = true;
				}
				else
				{
					animal.AnimStateTag = -1;
				}
				if (animal.LastState != this)
				{
					animal.LastState.EnterExitEvent?.OnExit.Invoke();
				}
				EnterExitEvent?.OnEnter.Invoke();
				if ((float)Duration > 0f)
				{
					C_Duration = IDuration();
					animal.StartCoroutine(C_Duration);
				}
			}
		}

		public void DisableModes_Temp(bool disable, List<ModeID> modelist)
		{
			if (modelist == null || modelist.Count <= 0)
			{
				return;
			}
			foreach (ModeID item in modelist)
			{
				if (animal.modes_Dict.TryGetValue(item, out var value))
				{
					if (disable)
					{
						value.Disable_Temporal();
					}
					else
					{
						value.Enable_Temporal();
					}
				}
			}
		}

		private IEnumerator IDuration()
		{
			yield return new WaitForSeconds(Duration.Value);
			Debugging($"[Allow Exit] by Duration [{Duration.Value:F2} seg]");
			AllowExit();
		}

		public virtual void ForceActivate()
		{
			ForceActivate(-1);
		}

		public virtual void ForceActivate(int enterStatus)
		{
			Debugging("Force Activated");
			ActiveState?.EnterExitEvent?.OnExit.Invoke();
			animal.LastState = ActiveState;
			animal.ActiveState = this;
			Activate(enterStatus);
			SetSpeed();
			CanExit = false;
			CurrentEnterTime = Time.time;
			animal.AnimStateTag = -1;
			if (animal.LastState != ActiveState)
			{
				IsPending = true;
			}
			else
			{
				animal.AnimStateTag = -1;
				IsPending = false;
			}
			EnterExitEvent?.OnEnter.Invoke();
		}

		internal virtual void SetSpeed()
		{
			animal.CustomSpeed = false;
			foreach (MSpeedSet speedSet in SpeedSets)
			{
				if (((int)animal.Stance == 0 && !speedSet.HasStances) || ((int)animal.Stance != 0 && speedSet.HasStance(animal.Stance)))
				{
					animal.CurrentSpeedSet = speedSet;
					animal.CurrentSpeedIndex = speedSet.CurrentIndex;
					return;
				}
			}
			MSpeedSet mSpeedSet = new MSpeedSet
			{
				name = base.name,
				Speeds = new List<MSpeed>(1)
				{
					new MSpeed(base.name, animal.CurrentSpeedModifier.Vertical.Value, 4f, 4f)
				}
			};
			animal.CustomSpeed = true;
			animal.CurrentSpeedSet = mSpeedSet;
			animal.CurrentSpeedModifier = mSpeedSet[0];
		}

		public virtual void ResetState()
		{
			IgnoreLowerStates = false;
			InCoreAnimation = false;
			IsPersistent = false;
			IsPending = false;
			CanExit = false;
			IsSleepFromMode = false;
			IsSleepFromState = false;
			IsSleepFromStance = false;
			OnQueue = false;
			OnActiveQueue = false;
			CurrentExitTime = Time.time;
			MovementAxisMult = Vector3.one;
			EnterStatus = -1;
			ResetInputOnFailed();
			foreach (TagModifier tagModifier in TagModifiers)
			{
				tagModifier.Entered = false;
			}
		}

		protected virtual void ResetInputOnFailed()
		{
			if (resetInputOnFailed)
			{
				InputValue = false;
				animal.InputSource?.ResetInput(Input);
			}
		}

		public virtual void RestoreAnimalOnExit()
		{
		}

		public virtual void PostExitState()
		{
		}

		public virtual void ExitState()
		{
			ResetStateValues();
			ResetState();
			RestoreAnimalOnExit();
			if (C_Duration != null)
			{
				animal.StopCoroutine(C_Duration);
				C_Duration = null;
			}
			if (HasResetFrom)
			{
				OnHoldByReset = true;
			}
		}

		public void SetEnterStatus(int value)
		{
			animal.State_SetStatus(value);
		}

		public void SetStatus(int value)
		{
			SetEnterStatus(value);
		}

		public void SetFloat(float value)
		{
			animal.State_SetFloat(value);
		}

		public void SetFloatSmooth(float value, float time)
		{
			if (animal.State_Float != 0f)
			{
				animal.State_SetFloat(Mathf.MoveTowards(animal.State_Float, value, time));
			}
		}

		public void SetExitStatus(int value)
		{
			animal.State_SetExitStatus(value);
		}

		public virtual void ActivateQueued()
		{
			OnQueue = false;
			OnActiveQueue = false;
			animal.QueueState = null;
			Debugging("[No Longer on Queue]");
			Activate();
		}

		private void SendMessagesTags(List<MesssageItem> msgs)
		{
			if (msgs == null || msgs.Count <= 0)
			{
				return;
			}
			if (UseSendMessage)
			{
				foreach (MesssageItem msg in msgs)
				{
					msg.DeliverMessage(animal, IncludeChildren, animal.debugStates && m_debug);
				}
				return;
			}
			if (listeners == null || listeners.Length == 0)
			{
				return;
			}
			IAnimatorListener[] array = listeners;
			foreach (IAnimatorListener listener in array)
			{
				foreach (MesssageItem msg2 in msgs)
				{
					msg2.DeliverAnimListener(listener, animal.debugStates && m_debug);
				}
			}
		}

		public void AnimationTagEnter(int animTagHash)
		{
			if (!IsActiveState)
			{
				return;
			}
			if (MainTagHash == animTagHash || animTagHash == 0)
			{
				if (animTagHash == 0)
				{
					Debug.Log("<b>[" + base.name + "]</b> The Current Animation State does not have any animation Tag.\nThe Animation State needs at least the animation Tag [" + ID.name + "].\n See: <b>https://malbersanimations.gitbook.io/animal-controller/quickstart/common-issues#states-are-not-getting-active</b>");
				}
				General.Modify(animal);
				if (!InCoreAnimation)
				{
					Debugging("<b>[" + base.name + "]</b> Entering Core Animation");
					InternalCoreAnimation();
				}
				return;
			}
			TagModifier tagModifier = TagModifiers.Find((TagModifier tag) => tag.TagHash == animTagHash);
			if (tagModifier == null)
			{
				return;
			}
			tagModifier.modifier.Modify(animal);
			InCoreAnimation = false;
			if (!tagModifier.Entered)
			{
				tagModifier.Entered = true;
				animal.SprintUpdate();
				SendMessagesTags(tagModifier.tagMessages);
				InvokeEnterPendingFalse();
				if (ResetLastState)
				{
					animal.LastState_Reset();
				}
				Debugging("<b>[" + base.name + "]</b> Entering Tag Animation  <B>[" + tagModifier.AnimationTag + "] </B>");
				EnterTagAnimation();
			}
		}

		private void InternalCoreAnimation()
		{
			InCoreAnimation = true;
			SetExitStatus(0);
			SetEnterStatus(0);
			animal.SprintUpdate();
			SendMessagesTags(GeneralMessage);
			InvokeEnterPendingFalse();
			if (ResetLastState)
			{
				animal.LastState_Reset();
			}
			EnterCoreAnimation();
		}

		private void InvokeEnterPendingFalse()
		{
			if (IsPending)
			{
				IsPending = false;
				animal.OnStateChange.Invoke(ID);
				animal.OnState(ID);
			}
		}

		public void SetInput(bool value)
		{
			InputValue = value;
		}

		public void ReceiveMessages(string message, object value)
		{
			this.Invoke(message, value);
		}

		internal void ActivatebyInput(bool value)
		{
			InputValue = value;
			if (!Active || (ExitInput == Input && IsActiveState))
			{
				return;
			}
			if ((value && IsSleep) || OnHoldByReset || animal.LockInput || animal.JustActivateState)
			{
				if (resetInputOnFailed)
				{
					InputValue = false;
					animal.InputSource?.ResetInput(Input);
				}
			}
			else if (value && CanBeActivated)
			{
				StatebyInput();
			}
		}

		internal void ExitByInput(bool exitValue)
		{
			ExitInputValue = exitValue;
			if (IsActiveState && CanExit)
			{
				StateExitByInput();
			}
		}

		internal void SetCanExit()
		{
			if (CanExit || IsPending || animal.InTransition || !MTools.ElapsedTime(CurrentEnterTime, ExitCooldown))
			{
				return;
			}
			if (ExitOnMain)
			{
				if (InCoreAnimation)
				{
					CanExit = true;
				}
			}
			else
			{
				CanExit = true;
			}
		}

		internal void NewStateActivated(StateID stateID)
		{
			if (OnHoldByReset && ResetFrom.Contains(stateID))
			{
				OnHoldByReset = false;
				Debugging("Reseted from ResetFrom List");
			}
			NewActiveState(stateID);
		}

		public virtual void NewActiveState(StateID newState)
		{
		}

		public virtual void SpeedModifierChanged(MSpeed speed, int SpeedIndex)
		{
		}

		public bool AllowExit()
		{
			if (CanExit)
			{
				IgnoreLowerStates = false;
				IsPersistent = false;
				AllowStateExit();
			}
			return CanExit;
		}

		public virtual void AllowStateExit()
		{
		}

		public void AllowExit(int nextState, int StateExitStatus)
		{
			SetExitStatus(StateExitStatus);
			if (!AllowExitFromAnim && AllowExit() && nextState != -1)
			{
				animal.State_Activate(nextState);
			}
		}

		public void Debugging(string value)
		{
		}

		public void Enable(bool value)
		{
			Active = value;
			if (IsActiveState && !Active)
			{
				AllowExit();
			}
		}

		public virtual void InitializeState()
		{
		}

		public virtual void EnterCoreAnimation()
		{
		}

		public virtual void EnterTagAnimation()
		{
		}

		public virtual void TryExitState(float DeltaTime)
		{
		}

		public virtual void SetSpeedSets(MAnimal animal)
		{
		}

		public virtual bool TryActivate()
		{
			if (InputValue)
			{
				return CanBeActivated;
			}
			return false;
		}

		public virtual void StatebyInput()
		{
			if (!IsSleep && !animal.LockInput && TryActivate() && TryOverride)
			{
				Activate();
			}
		}

		public virtual void StateExitByInput()
		{
			if (ExitInputValue)
			{
				AllowExit();
			}
		}

		public virtual void ResetStateValues()
		{
		}

		public virtual void OnStateMove(float deltatime)
		{
		}

		public virtual void OnStatePreMove(float deltatime)
		{
		}

		public virtual void OnModeStart(Mode mode)
		{
		}

		public virtual void OnModeEnd(Mode mode)
		{
		}

		public virtual void OnPlataformChanged(Transform newPlatform)
		{
		}

		public virtual void StateGizmos(MAnimal animal)
		{
		}

		public virtual bool CustomStateInspector()
		{
			return false;
		}

		internal virtual void Reset()
		{
			ID = MTools.GetInstance<StateID>(StateIDName);
		}
	}
}
