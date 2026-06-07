using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class Mode
	{
		[SerializeField]
		private bool active = true;

		public int TemporalActivation = 1;

		[SerializeField]
		private bool ignoreLowerModes;

		[Tooltip("The Abilities animations have cooldown. If this is set to false then the animations needs to finish before activating a new Ability")]
		[SerializeField]
		private bool hasCoolDown;

		protected int ModeTagHash;

		public string Input;

		[SerializeField]
		public ModeID ID;

		[ExposeScriptableAsset]
		public ModeModifier modifier;

		[Tooltip("Elapsed time needed to interrupt the current ability by another Mode. [Has Cooldown needs to be true]")]
		public FloatReference CoolDown = new FloatReference(0f);

		public List<Ability> Abilities;

		[SerializeField]
		private IntReference m_AbilityIndex = new IntReference(-99);

		public IntReference DefaultIndex = new IntReference(0);

		public IntEvent OnAbilityIndex = new IntEvent();

		public bool ResetToDefault;

		[SerializeField]
		private bool allowRotation;

		[SerializeField]
		private bool allowMovement;

		public UnityEvent OnEnterMode = new UnityEvent();

		public UnityEvent OnExitMode = new UnityEvent();

		[SubclassSelector]
		[SerializeReference]
		public Reaction OnEnterReaction;

		[SubclassSelector]
		[SerializeReference]
		public Reaction OnExitReaction;

		[Tooltip("Global Audio Source assigned to the Mode to Play Audio Clips")]
		public AudioSource m_Source;

		public float ActivationTime;

		private bool m_InputValue;

		private Ability ExitAbility;

		private IEnumerator I_CoolDown;

		public float PositionMultiplier => ActiveAbility.AdditivePosition;

		public float RotatioMultiplier => ActiveAbility.AdditiveRotation;

		public bool PlayingMode { get; set; }

		public float ChargeValue { get; set; }

		public bool IsInTransition { get; set; }

		public bool Active
		{
			get
			{
				if (active)
				{
					return TemporalActivation > 0;
				}
				return false;
			}
			set
			{
				if (value != active)
				{
					active = value;
					Debugging($"<b><color=green>Set Active: </color>[{value}] </b>");
				}
			}
		}

		public int Priority { get; set; }

		public bool AllowRotation
		{
			get
			{
				return allowRotation;
			}
			set
			{
				allowRotation = value;
			}
		}

		public bool AllowMovement
		{
			get
			{
				return allowMovement;
			}
			set
			{
				allowMovement = value;
			}
		}

		public string Name
		{
			get
			{
				if (!(ID != null))
				{
					return string.Empty;
				}
				return ID.name;
			}
		}

		public bool HasCoolDown
		{
			get
			{
				return hasCoolDown;
			}
			set
			{
				hasCoolDown = value;
			}
		}

		public bool InCoolDown { get; set; }

		public bool IgnoreLowerModes
		{
			get
			{
				return ignoreLowerModes;
			}
			set
			{
				ignoreLowerModes = value;
			}
		}

		public int AbilityIndex
		{
			get
			{
				return m_AbilityIndex;
			}
			set
			{
				m_AbilityIndex.Value = value;
				OnAbilityIndex.Invoke(value);
			}
		}

		public MAnimal Animal { get; private set; }

		public Ability ActiveAbility { get; private set; }

		public bool InputValue
		{
			get
			{
				return m_InputValue;
			}
			set
			{
				m_InputValue = value;
				if (value)
				{
					Animal.ModeQueueInput.Add(this);
				}
				else
				{
					Animal.ModeQueueInput.Remove(this);
				}
			}
		}

		public void SetAbilityIndex(int index)
		{
			AbilityIndex = index;
		}

		public void Interrupt()
		{
			if (Animal.ActiveMode == this)
			{
				Animal.Mode_Interrupt();
			}
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
			foreach (Ability a in Abilities)
			{
				if (a.InputListener == null)
				{
					a.InputListener = delegate(bool x)
					{
						ActivateAbilitybyInput(a, x);
					};
				}
				if (connect)
				{
					InputSource.ConnectInput(a.Input, a.InputListener);
				}
				else
				{
					InputSource.DisconnectInput(a.Input, a.InputListener);
				}
			}
		}

		public virtual void AwakeMode(MAnimal animal)
		{
			Animal = animal;
			OnAbilityIndex.Invoke(AbilityIndex);
			ActivationTime = (0f - (float)CoolDown) * 2f;
			InCoolDown = false;
			TemporalActivation = 1;
			if (m_Source != null)
			{
				m_Source.playOnAwake = false;
			}
			foreach (Ability ability in Abilities)
			{
				ability.mode = this;
				if (ability.audioSource != null)
				{
					ability.audioSource.playOnAwake = false;
				}
				ModeProperties limits = ability.Limits;
				if (limits.Stances == null)
				{
					limits.Stances = new List<StanceID>();
				}
				limits = ability.Limits;
				if (limits.affectStates == null)
				{
					limits.affectStates = new List<StateID>();
				}
			}
		}

		public virtual void ResetMode()
		{
			if (!(Animal != null))
			{
				return;
			}
			if (Animal.ActiveMode == this)
			{
				Animal.Set_State_Sleep_FromMode(playingMode: false);
			}
			PlayingMode = false;
			modifier?.OnModeExit(this);
			if (ActiveAbility != null)
			{
				ActiveAbility.modifier?.OnModeExit(this);
				if (ActiveAbility.m_stopAudio)
				{
					if (ActiveAbility.audioSource != null)
					{
						ActiveAbility.audioSource.Stop();
					}
					if (m_Source != null)
					{
						m_Source.Stop();
					}
				}
				ExitAbility = ActiveAbility;
			}
			if (ResetToDefault && !InputValue)
			{
				m_AbilityIndex.Value = DefaultIndex.Value;
			}
			ActiveAbility = null;
		}

		public virtual void ModeExit(bool forced = false)
		{
			if (!forced)
			{
				Animal.ModeTime = 0f;
				Animal.ModeAbility = 0;
				Animal.SetModeStatus(0);
			}
			Animal.ActiveMode = null;
			OnExitMode.Invoke();
			OnExitReaction?.React(Animal);
			if (ExitAbility != null)
			{
				ExitAbility.OnExit.Invoke();
				ExitAbility.ReactExit?.React(Animal);
			}
		}

		public virtual void ResetAbilityIndex()
		{
			if (!Animal.InZone)
			{
				SetAbilityIndex(DefaultIndex);
			}
		}

		public bool HasAbilityIndex(int index)
		{
			return Abilities.Find((Ability ab) => (int)ab.Index == index) != null;
		}

		public void SetActive(bool value)
		{
			Active = value;
		}

		public void ActivatebyInput(bool Input_Value)
		{
			if (!Active || (Animal != null && !Animal.enabled) || Animal.LockInput || InputValue == Input_Value)
			{
				return;
			}
			InputValue = Input_Value;
			if (InputValue)
			{
				Debugging("<B><color=yellow>[Try Activate by Input <" + Input + ">]</color></B>");
				if (Animal.InZone && Animal.Zone.IsMode && Animal.Zone.ZoneID == (int)ID)
				{
					Animal.Zone.ActivateZone(Animal);
				}
				else
				{
					TryActivate();
				}
			}
			else if (PlayingMode && CheckStatus(AbilityStatus.Charged))
			{
				Animal.Mode_Interrupt();
				Debugging("<B><color=orange>[INTERRUPTED]</color> Ability: <color=white>[" + ActiveAbility.Name + "]</color> Status: <color=white>[Input Released]</color></B>");
			}
		}

		public void ActivateAbilitybyInput(Ability ability, bool Input_Value)
		{
			if (ability.InputValue == Input_Value)
			{
				return;
			}
			ability.InputValue = Input_Value;
			if (Active && Animal.enabled && !Animal.LockInput)
			{
				if (ability.InputValue)
				{
					TryActivate(ability);
				}
				else if (PlayingMode && ActiveAbility.Index == ability.Index && CheckStatus(AbilityStatus.Charged))
				{
					Animal.Mode_Interrupt();
					Debugging("<B><color=yellow>[INTERRUPTED]</color> Ability: <color=white>[" + ActiveAbility.Name + "]</color> Status: <color=white>[Input Released]</color></B>");
				}
			}
		}

		private void Activate(Ability newAbility, int modeStatus, string deb)
		{
			ActiveAbility = newAbility;
			Animal.SetModeParameters(this, modeStatus);
			ChargeValue = 0f;
			ActiveAbility.modifier?.OnModeEnter(this);
			AudioSource source = ((ActiveAbility.audioSource != null) ? ActiveAbility.audioSource : m_Source);
			if ((bool)source && source.isActiveAndEnabled && !ActiveAbility.audioClip.NullOrEmpty())
			{
				Animal.Delay_Action(ActiveAbility.ClipDelay, delegate
				{
					if (source.isPlaying)
					{
						source.Stop();
					}
					ActiveAbility?.audioClip.Play(source);
				});
			}
			Debugging("<B><color=yellow>[PREPARED]</color></B> Ability: <B><color=white>[" + ActiveAbility.Name + "] " + $"[{Mathf.Abs((int)ID * 1000) + Mathf.Abs(ActiveAbility.Index)}]</color>. {deb}</b>");
		}

		public bool ForceActivate()
		{
			return ForceActivate(AbilityIndex);
		}

		public bool ForceActivate(int abilityIndex)
		{
			if (abilityIndex != 0)
			{
				AbilityIndex = abilityIndex;
			}
			Animal.IsPreparingMode = false;
			Debugging("<B><color=Cyan>[FORCED ACTIVATE] Next Ability:[" + Abilities.FirstOrDefault((Ability x) => (int)x.Index == AbilityIndex).Name + "]</color></B>");
			if (Animal.IsPlayingMode)
			{
				Animal.ActiveMode.ResetMode();
				Animal.ActiveMode.ModeExit(forced: true);
			}
			PlayingMode = false;
			return TryActivate();
		}

		public bool ForceActivate(int abilityIndex, AbilityStatus status, float time = 0f)
		{
			if (abilityIndex != 0)
			{
				AbilityIndex = abilityIndex;
			}
			Animal.IsPreparingMode = false;
			Debugging($"<B><color=Cyan>[FORCED ACTIVATE] Next Ability:[{AbilityIndex}]</color></B>");
			if (Animal.IsPlayingMode)
			{
				Animal.ActiveMode.ResetMode();
				Animal.ActiveMode.ModeExit();
			}
			return TryActivate(abilityIndex, status, time);
		}

		public virtual bool TryActivate()
		{
			return TryActivate(AbilityIndex);
		}

		public virtual bool TryActivate(int index)
		{
			return TryActivate(GetTryAbility(index));
		}

		public virtual bool TryActivate(int index, AbilityStatus status, float time = 0f)
		{
			Ability tryAbility = GetTryAbility(index);
			if (tryAbility != null)
			{
				tryAbility.Status = status;
				if (status == AbilityStatus.ActiveByTime)
				{
					tryAbility.AbilityTime = time;
				}
				return TryActivate(tryAbility);
			}
			return false;
		}

		public virtual bool TryActivate(Ability newAbility)
		{
			if (!Active)
			{
				Debugging("<color=red><B>[" + ((newAbility != null) ? newAbility.Name : "Null") + "]</B> Failed to play.</color>" + $" Mode Disabled. Temporal Deactivation [{TemporalActivation}]");
				return false;
			}
			if (Animal.ActiveState.NoModes)
			{
				Debugging("<color=orange><B>[" + ((newAbility != null) ? newAbility.Name : "<Empty>") + "]</B> Failed to play. <B>[" + Animal.ActiveStateID.name + "]</B> state won't allow it. (No Modes is set to <B>True</b>)</color>");
				return false;
			}
			int num = 0;
			string deb = "<-->";
			if (newAbility == null)
			{
				Debugging($"<Color=red> Skip Ability is [NULL] Index is {AbilityIndex}.</color>");
				Animal.IsPreparingMode = false;
				return false;
			}
			if (Animal.IsPreparingMode)
			{
				Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play. Its already preparing another Mode [Skip]</color>" + $" [{(double)Time.time - Animal.ModeActivationTime:F2}]");
				if (Animal.ModeActivationTime + 0.10000000149011612 < (double)Time.time)
				{
					Animal.Mode_Interrupt();
				}
				return false;
			}
			if (Animal.IsPlayingMode && PlayingMode && Animal.ActiveMode != this)
			{
				PlayingMode = false;
			}
			if (!newAbility.Active)
			{
				Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play. <Disabled></color>");
				return false;
			}
			if (StateCanInterrupt(Animal.ActiveState.ID, newAbility))
			{
				Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play. Active State [" + Animal.ActiveStateID.name + "] won't allow it</color>");
				return false;
			}
			if (StanceCanInterrupt(Animal.Stance, newAbility))
			{
				Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play. The current Stance won't allow it</color>");
				return false;
			}
			if (PlayingMode)
			{
				if (ActiveAbility.Index == newAbility.Index && CheckStatus(AbilityStatus.Toggle))
				{
					InputValue = false;
					Animal.Mode_Interrupt();
					Debugging("<B><color=yellow>[INTERRUPTED]</color> Ability: <Color=white>[" + ActiveAbility.Name + "]</color> Status: <Color=white>[Toggle Off]</color></B>");
					return false;
				}
				if (newAbility.HasTransitionFrom && newAbility.Limits.TransitionFrom.Contains(ActiveAbility.Index))
				{
					num = ActiveAbility.Index;
					deb = $"Last Ability [{num}] is allowing it. <Check ModeBehaviour>";
					ResetMode();
				}
				else
				{
					if (!HasCoolDown)
					{
						Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play.Ability [" + ActiveAbility.Name + "] needs to finish</color>");
						return false;
					}
					if (InCoolDown)
					{
						Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play.Ability [" + ActiveAbility.Name + "] is in cooldown</color>");
						return false;
					}
					if (!InCoolDown)
					{
						ResetMode();
						ModeExit();
						deb = "No Longer in Cooldown [Same Mode]";
					}
				}
			}
			else if (Animal.IsPlayingMode)
			{
				Mode activeMode = Animal.ActiveMode;
				if (Priority > activeMode.Priority && IgnoreLowerModes)
				{
					activeMode.ResetMode();
					activeMode.InputValue = false;
					activeMode.ModeExit();
					activeMode.InCoolDown = false;
					deb = "Exit [" + activeMode.Name + "] Mode, New [" + Name + "] has Higher Priority";
				}
				else
				{
					if (!activeMode.HasCoolDown || activeMode.InCoolDown)
					{
						if (newAbility != null)
						{
							Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play.<b>[" + activeMode.ID.name + "]</b> needs to finish the current ability</color>");
						}
						return false;
					}
					if (!activeMode.InCoolDown)
					{
						activeMode.ResetMode();
						activeMode.ModeExit();
						deb = "[Mode " + activeMode.Name + "] is no Longer in Cooldown ";
					}
				}
			}
			else if (HasCoolDown && (float)CoolDown + (float)newAbility.CoolDown > 0f && InCoolDown)
			{
				Debugging("<color=red><B>[" + newAbility.Name + "]</B> Failed to play. <b>[Mode: " + Name + "]</b> is still in Long Cooldown</color>");
				return false;
			}
			Activate(newAbility, num, deb);
			return true;
		}

		public void AnimationTagEnter(int _)
		{
			if (ActiveAbility != null && !PlayingMode)
			{
				PlayingMode = true;
				Animal.IsPreparingMode = false;
				Animal.ActiveMode = this;
				Animal.Set_State_Sleep_FromMode(playingMode: true);
				OnEnterInvoke();
				ActivationTime = Time.time;
				AbilityStatus status = ActiveAbility.Status;
				string text = status.ToString();
				int modeStatus = -1;
				if (status == AbilityStatus.PlayOneTime)
				{
					modeStatus = 1;
					SetCoolDown(ActiveAbility.CoolDown);
				}
				switch (status)
				{
				case AbilityStatus.ActiveByTime:
				{
					float abilityTime = ActiveAbility.AbilityTime;
					Animal.StartCoroutine(Ability_By_Time(abilityTime));
					text = text + ": " + abilityTime;
					break;
				}
				case AbilityStatus.Toggle:
					text += " On";
					break;
				}
				Debugging("<B><color=yellow>[ANIM-ENTER]</color></B> Ability: <B><color=white>[" + ActiveAbility.Name + "]</color> Status: <color=white> [" + text + "]</color></B>");
				Animal.SetModeStatus(modeStatus);
				bool flag = ActiveAbility.InputValue || InputValue;
				if (CheckStatus(AbilityStatus.Charged) && !flag)
				{
					Animal.Mode_Interrupt();
					Debugging("<B><color=orange>[**INTERRUPTED .]</color> Ability: <color=white>[" + ActiveAbility.Name + "]</color> Status: <color=white>[Input Released]</color></B>");
				}
			}
		}

		internal void OnAnimatorMove(float deltaTime)
		{
			if (ActiveAbility.Status == AbilityStatus.Charged && ActiveAbility.AbilityTime > 0f)
			{
				float num = (Time.time - ActivationTime) / ActiveAbility.AbilityTime;
				float num2 = ActiveAbility.ChargeCurve.Evaluate(num);
				ChargeValue = num2 * (float)ActiveAbility.ChargeValue;
				Animal.Mode_SetPower(num2);
				ActiveAbility.OnCharged.Invoke(ChargeValue);
				if (num > 1f && ActiveAbility.Release)
				{
					InputValue = false;
					Interrupt();
				}
			}
			modifier?.OnModeMove(this);
			ActiveAbility.modifier?.OnModeMove(this);
		}

		public void AnimationTagExit(Ability exitingAbility, int ExitTransitionAbility)
		{
			string text = "<B><color=red>[ANIM-EXIT]</color></B> Ability: <B><color=white>[" + ((exitingAbility != null) ? exitingAbility.Name : "NULL") + "]</color> </B> ";
			string text2 = "Status: <B><color=white>[Skip Exit Logic]</color></B>";
			if (Animal.ActiveMode == this && ActiveAbility != null && ActiveAbility.Index.Value == exitingAbility.Index.Value)
			{
				text2 = $"Status: <B><color=white>[Mode Reseted] Status:[{ActiveAbility.Status}] " + $"ExitAb:[{exitingAbility.Index.Value}]</color></B>";
				Debugging(text + text2);
				if (ActiveAbility.Status != AbilityStatus.PlayOneTime)
				{
					SetCoolDown(exitingAbility.CoolDown);
				}
				ResetMode();
				ModeExit();
				if (ExitTransitionAbility != -1)
				{
					IsInTransition = false;
					if (TryActivate(ExitTransitionAbility))
					{
						text2 = "Status: <B><color=white>[Exit to another Ability]</color></B>";
						Debugging(text + text2);
						AnimationTagEnter(0);
					}
				}
				else
				{
					if (InCoolDown)
					{
						return;
					}
					if (!InputValue)
					{
						foreach (Ability ability in Abilities)
						{
							if (ability.InputValue && TryActivate(ability))
							{
								break;
							}
						}
						return;
					}
					TryActivate();
				}
				return;
			}
			Debugging(text + text2);
			if (Animal.IsPreparingMode)
			{
				if (Animal.debugModes)
				{
					Debug.Log("<color= white>Preparing Mode failed, Reseting [Is Preparing Mode]</color>. Make sure your ability transitions are set to Interrupt Source -> Next State");
				}
				Animal.IsPreparingMode = false;
			}
		}

		public virtual Ability GetTryAbility(int index)
		{
			if (!Active)
			{
				return null;
			}
			AbilityIndex = index;
			modifier?.OnModeEnter(this);
			if (AbilityIndex == 0)
			{
				return null;
			}
			if (Abilities == null || Abilities.Count == 0)
			{
				Debugging("There's no Abilities Please set a list of Abilities");
				return null;
			}
			if (AbilityIndex == -99)
			{
				return GetAbility(Abilities[UnityEngine.Random.Range(0, Abilities.Count)].Index.Value);
			}
			return GetAbility(AbilityIndex);
		}

		public virtual Ability GetAbility(int NewIndex)
		{
			Ability ability = Abilities.Find((Ability item) => (int)item.Index == NewIndex);
			if ((int)DefaultIndex != 0 && ability != null && !ability.Active)
			{
				ability = Abilities.Find((Ability item) => (int)item.Index == DefaultIndex.Value);
			}
			return ability;
		}

		public virtual Ability GetAbility(string abilityName)
		{
			return Abilities.Find((Ability item) => item.Name == abilityName);
		}

		public virtual void OnModeStateMove(AnimatorStateInfo stateInfo, Animator anim, int Layer)
		{
			if (Animal.ActiveMode == this)
			{
				Animal.ModeTime = stateInfo.normalizedTime;
			}
		}

		public virtual bool StateCanInterrupt(StateID ID, Ability ability = null)
		{
			if (ability == null)
			{
				ability = ActiveAbility;
			}
			ModeProperties limits = ability.Limits;
			if (limits.affect == AffectStates.None)
			{
				return false;
			}
			if (ability.HasAffectStates && ((limits.affect == AffectStates.Exclude && HasState(limits, ID)) || (limits.affect == AffectStates.Include && !HasState(limits, ID))))
			{
				return true;
			}
			return false;
		}

		public virtual bool StanceCanInterrupt(StanceID ID, Ability ability = null)
		{
			if (ability == null)
			{
				ability = ActiveAbility;
			}
			ModeProperties limits = ability.Limits;
			if (limits.affect_Stance == AffectStates.None)
			{
				return false;
			}
			if (ability.HasAffectStances && ((limits.affect_Stance == AffectStates.Exclude && HasStance(limits, ID)) || (limits.affect_Stance == AffectStates.Include && !HasStance(limits, ID))))
			{
				Debugging("Current Stance [" + ID.name + "] is Blocking <B>" + ability.Name + "</B>");
				return true;
			}
			return false;
		}

		protected static bool HasState(ModeProperties properties, StateID ID)
		{
			return properties.affectStates.Exists((StateID x) => x.ID == ID.ID);
		}

		protected static bool HasStance(ModeProperties properties, StanceID ID)
		{
			return properties.Stances.Exists((StanceID x) => x.ID == ID.ID);
		}

		private void SetCoolDown(float additiveCoolDown)
		{
			if (HasCoolDown)
			{
				if (I_CoolDown != null)
				{
					Animal.StopCoroutine(I_CoolDown);
				}
				Animal.StartCoroutine(I_CoolDown = C_SetCoolDown((float)CoolDown + additiveCoolDown));
			}
		}

		public IEnumerator C_SetCoolDown(float time)
		{
			if (time == 0f)
			{
				InCoolDown = false;
				yield break;
			}
			InCoolDown = true;
			yield return new WaitForSeconds(time);
			InCoolDown = false;
		}

		protected IEnumerator Ability_By_Time(float time)
		{
			yield return new WaitForSeconds(time);
			Animal.SetModeStatus(0);
			Debugging("<B><color=yellow>[INTERRUPTED]</color> Ability: <Color=white>[" + ActiveAbility.Name + "]</color> Status: <Color=white>[Time elapsed]</color></B>");
		}

		private void OnEnterInvoke()
		{
			ActiveAbility.OnEnter.Invoke();
			ActiveAbility.ReactEnter?.React(Animal);
			OnEnterMode.Invoke();
			OnEnterReaction?.React(Animal);
		}

		private bool CheckStatus(AbilityStatus status)
		{
			if (ActiveAbility == null)
			{
				return false;
			}
			return ActiveAbility.Status == status;
		}

		public virtual void Disable()
		{
			Active = false;
			InputValue = false;
			InCoolDown = false;
			if (PlayingMode && !CheckStatus(AbilityStatus.PlayOneTime))
			{
				Animal.Mode_Interrupt();
			}
		}

		public virtual void Enable()
		{
			Active = true;
		}

		public virtual void Enable_Temporal()
		{
			TemporalActivation++;
			Debugging($"Enable Temporal Activation++: {TemporalActivation}");
		}

		public virtual void Enable_Temporal(bool value)
		{
			TemporalActivation = (value ? (TemporalActivation + 1) : (TemporalActivation - 1));
			Debugging($"Enable Temporal Activation {value}: {TemporalActivation}");
		}

		public virtual void Disable_Temporal()
		{
			TemporalActivation--;
			Debugging($"Disable Temporal Activation--: {TemporalActivation}");
		}

		public virtual void Reset_Temporal()
		{
			TemporalActivation = 1;
			Debugging("Reset Temporal Activation [1]");
		}

		internal void Debugging(string deb)
		{
		}
	}
}
