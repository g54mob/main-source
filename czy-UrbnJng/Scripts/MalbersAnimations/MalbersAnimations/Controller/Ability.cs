using System;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class Ability
	{
		public BoolReference active = new BoolReference(value: true);

		public string Name;

		public IntReference Index = new IntReference(0);

		[Tooltip("Unique Input to play for each Ability")]
		public StringReference Input;

		[Tooltip("Clip to play when the ability is played")]
		public AudioClipReference audioClip;

		[Tooltip("Clip Sound Delay")]
		public FloatReference ClipDelay = new FloatReference(0f);

		[Tooltip("Cooldown to add to the Mode Global CoolDown")]
		public FloatReference CoolDown = new FloatReference(0f);

		[Tooltip("Local AudioSource for an specific Ability")]
		public AudioSource audioSource;

		[Tooltip("Stop the Audio sound on Ability Exit")]
		public bool m_stopAudio = true;

		[Tooltip("Local Mode Modifier to Add to the Ability")]
		[ExposeScriptableAsset]
		public ModeModifier modifier;

		public ModeProperties Limits;

		[Tooltip("The Ability can Stay Active until it finish the Animation, by Holding the Input Down, by x time ")]
		public AbilityStatus Status;

		[Tooltip("The Ability will be completely charged after x seconds. If the value is zero, the charge logic will be ignored")]
		public FloatReference abilityTime = new FloatReference(3f);

		[Tooltip("Curve value for the charged ability")]
		public AnimationCurve ChargeCurve = new AnimationCurve(MTools.DefaultCurve);

		[Tooltip("Charge maximun value for the Charged ability")]
		public FloatReference ChargeValue = new FloatReference(1f);

		[Tooltip("Release the Charged Ability when it reaches is Time")]
		public bool Release;

		[Tooltip("Multiplier added to the Additive position when the mode is playing. This will fix the issue Additive Speeds to mess with RootMotion Modes")]
		public float AdditivePosition = 1f;

		[Tooltip("Multiplier added to the Additive rotation when the mode is playing.")]
		public float AdditiveRotation = 1f;

		[Tooltip("The Mode can ignore if the Animal is Grounded. Useful for when the Mode moves in the Y Axis")]
		public bool IgnoreGrounded;

		[Tooltip("The Mode can ignore Gravity. Useful for when the Mode is already on the Air and you don't want Gravity Aplied to it")]
		public bool IgnoreGravity;

		[Tooltip("Remove Y Movement from the Current States and animations")]
		public bool NoYMovement;

		[Tooltip("While the Animal is Playing the Ability, No other State is allow to be Activated")]
		public bool Persistent;

		private bool m_InputValue;

		[NonSerialized]
		public Mode mode;

		public UnityAction<bool> InputListener;

		[SerializeReference]
		[SubclassSelector]
		public Reaction ReactEnter;

		[SerializeReference]
		[SubclassSelector]
		public Reaction ReactExit;

		public UnityEvent OnEnter = new UnityEvent();

		public UnityEvent OnExit = new UnityEvent();

		public FloatEvent OnCharged = new FloatEvent();

		public float AbilityTime
		{
			get
			{
				return abilityTime.Value;
			}
			set
			{
				abilityTime.Value = value;
			}
		}

		public bool HasAffectStates
		{
			get
			{
				if (Limits.affectStates != null)
				{
					return Limits.affectStates.Count > 0;
				}
				return false;
			}
		}

		public bool HasAffectStances
		{
			get
			{
				if (Limits.Stances != null)
				{
					return Limits.Stances.Count > 0;
				}
				return false;
			}
		}

		public bool HasTransitionFrom
		{
			get
			{
				if (Limits.TransitionFrom != null)
				{
					return Limits.TransitionFrom.Count > 0;
				}
				return false;
			}
		}

		public bool Active
		{
			get
			{
				return active.Value;
			}
			set
			{
				active.Value = value;
			}
		}

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
					mode.Animal.AbilityQueueInput.Add(this);
				}
				else
				{
					mode.Animal.AbilityQueueInput.Remove(this);
				}
			}
		}
	}
}
