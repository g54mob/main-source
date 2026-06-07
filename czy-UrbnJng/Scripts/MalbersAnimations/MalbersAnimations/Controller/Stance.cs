using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class Stance
	{
		[Tooltip("ID value for the Stance")]
		public StanceID ID;

		[Tooltip("Enable Disable the Stance")]
		public BoolReference enabled = new BoolReference(value: true);

		[Tooltip("Unique Input to play for each Ability")]
		public StringReference Input;

		[Tooltip("Lock the Stance if its Active. No other Stances can be enabled.")]
		public BoolReference persistent = new BoolReference();

		[Tooltip("When this stance is active, no other stance can be activated, except the Default Stance. Use this when you dont want other stances to interrupt ")]
		public BoolReference activeOnly = new BoolReference();

		[Tooltip("Does this Stance allows Straffing?")]
		public BoolReference CanStrafe = new BoolReference();

		[Tooltip("After the Stance has exited, it cannot be activated again after the cooldown has passed")]
		public FloatReference CoolDown = new FloatReference(0f);

		[Tooltip("If this Stance was activated, it cannot be Exit until the Exit cooldown has passed")]
		public FloatReference ExitAfter = new FloatReference(0f);

		[Tooltip("Is/Is NOT active State on this list")]
		public bool Include = true;

		[Tooltip("Include/Exclude the States on this list that can be used with the Stance")]
		public List<StateID> states = new List<StateID>();

		[Tooltip("What States can queue the activation of this Stance")]
		public List<StateID> StateQueue = new List<StateID>();

		[Tooltip("Stances to Block while this stance is active")]
		public List<StanceID> DisableStances = new List<StanceID>();

		[Tooltip("When the stance is playing ,it will override the main capsule collider to fit better the stance")]
		public bool OverrideCapsule;

		public OverrideCapsuleCollider newCapsule;

		public bool HasStates => states.Count > 0;

		public bool InputValue { get; set; }

		public int DisableValue { get; set; }

		public bool DisableTemp => DisableValue < 0;

		public bool Enabled
		{
			get
			{
				return enabled.Value;
			}
			set
			{
				enabled.Value = value;
			}
		}

		public bool ActiveOnly
		{
			get
			{
				return activeOnly.Value;
			}
			set
			{
				activeOnly.Value = value;
			}
		}

		public bool Persistent
		{
			get
			{
				return persistent.Value;
			}
			set
			{
				persistent.Value = value;
			}
		}

		public bool Active { get; set; }

		public bool Queued { get; set; }

		public MAnimal Animal { get; set; }

		public float ActivationTime { get; private set; }

		public float ExitTime { get; private set; }

		public bool CanExit
		{
			get
			{
				if ((float)ExitAfter != 0f)
				{
					return MTools.ElapsedTime(ActivationTime, ExitAfter);
				}
				return true;
			}
		}

		public float CoolDownLeft => ExitTime + (float)CoolDown - Time.time;

		public float CanExitTimeLeft => ActivationTime + (float)ExitAfter - Time.time;

		public bool InCoolDown
		{
			get
			{
				if ((float)CoolDown > 0f)
				{
					return !MTools.ElapsedTime(ExitTime, CoolDown);
				}
				return false;
			}
		}

		public OnEnterExitStance events { get; set; }

		internal virtual void AwakeStance(MAnimal animal)
		{
			if (ID == null)
			{
				Debug.LogWarning("<B>[" + Animal.name + "]</B> Has Empty Stances. Please set the correct Stance ID ", animal.gameObject);
			}
			Animal = animal;
			events = animal.OnEnterExitStances.Find((OnEnterExitStance x) => x.ID == ID);
			ActivationTime = float.MinValue;
			ExitTime = float.MinValue;
			Queued = false;
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
		}

		public virtual void SetPersistent(bool value)
		{
			if (Active || Queued)
			{
				Debugging($"Persistent [{value}]");
				Persistent = value;
			}
			else
			{
				Debugging("Cannot Set Persistent. This is not the Active Stance");
			}
		}

		public virtual void Enable(bool value)
		{
			Enabled = value;
		}

		public virtual void SetQueued(bool value)
		{
			Queued = value;
			Debugging($"Queued [{value}]");
		}

		public void ActivatebyInput(bool Input_Value)
		{
			if (CanActivate())
			{
				InputValue = Input_Value;
				if (Input_Value)
				{
					Animal.Stance = ID;
					return;
				}
				Animal.Stance_Reset();
				Queued = false;
			}
		}

		public void Disable_Temp_Restore()
		{
			DisableValue++;
		}

		public void Disable_Temp()
		{
			DisableValue--;
		}

		public bool CanActivate()
		{
			if (!Enabled)
			{
				Debugging("Failed. Stance is Disabled");
				return false;
			}
			if (!Animal.enabled)
			{
				Debugging("Failed. Animal disabled");
				return false;
			}
			if (DisableTemp)
			{
				Debugging($"Failed. Disable by External [{DisableValue}]");
				return false;
			}
			if (Animal.ActiveStance != null)
			{
				if (Animal.ActiveStance.ActiveOnly && Animal.DefaultStanceID != ID)
				{
					Debugging("Ignored. Active Stance [" + Animal.ActiveStance.ID.name + "] Is Active Only");
					return false;
				}
				if (Animal.ActiveStance.Persistent)
				{
					Debugging("Ignored. Active Stance [" + Animal.ActiveStance.ID.name + "] is Persistent");
					return false;
				}
				if (InCoolDown)
				{
					Debugging($"Failed. Stance in CoolDown. Time left {CoolDownLeft:F2}");
					return false;
				}
				if (!Animal.ActiveStance.CanExit)
				{
					Debugging($"Failed. Active Stance [{Animal.ActiveStance.ID.name}] can't exit yet. Exit After {Animal.ActiveStance.CanExitTimeLeft:F2}");
					return false;
				}
			}
			if (HasStates)
			{
				StateID activeStateID = Animal.ActiveStateID;
				bool flag = states.Contains(activeStateID);
				if (flag && !Include)
				{
					if (OnQueueState(activeStateID))
					{
						Queued = true;
					}
					Debugging($"Failed. Active State [{activeStateID.name}] is Excluded from the allowed States. Set Queued[{Queued}]");
					return false;
				}
				if (!flag && Include)
				{
					if (OnQueueState(activeStateID))
					{
						Queued = true;
					}
					Debugging($"Failed. Active State [{activeStateID.name}] is Not Included in the allowed States. Set Queued[{Queued}]");
					return false;
				}
			}
			return true;
		}

		internal void Reset()
		{
			InputValue = false;
			Queued = false;
		}

		internal void Activate()
		{
			ActivationTime = Time.time;
			Active = true;
			Queued = false;
			if (ID == Animal.DefaultStanceID)
			{
				Animal.LastActiveStance.Queued = false;
			}
			events?.OnEnter.Invoke();
		}

		internal void Exit()
		{
			Active = false;
			ExitTime = Time.time;
			events?.OnExit.Invoke();
			if (!Queued)
			{
				Animal.InputSource?.ResetInput(Input);
			}
		}

		internal void NewStateActivated(StateID stateID)
		{
			if (CanBeUsedOnState(stateID) && Queued)
			{
				SetQueued(value: false);
				Animal.Stance = ID;
			}
		}

		internal bool CanBeUsedOnState(StateID activeStateID)
		{
			if (!HasStates)
			{
				return true;
			}
			return activeStateID.Included(states, Include);
		}

		internal bool OnQueueState(StateID activeStateID)
		{
			return StateQueue.Contains(activeStateID);
		}

		private void Debugging(string value)
		{
		}
	}
}
