using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct StateData
	{
		public enum StateType
		{
			AnimationClip = 0,
			RuntimeController = 1,
			State = 2
		}

		[SerializeField]
		private StateType m_StateType;

		[SerializeField]
		private PropertyGetAnimation m_AnimationClip;

		[SerializeField]
		private RuntimeAnimatorController m_RuntimeController;

		[SerializeField]
		private State m_State;

		[SerializeField]
		private AvatarMask m_AvatarMask;

		public StateType Type => m_StateType;

		public RuntimeAnimatorController RuntimeController => m_RuntimeController;

		public State State => m_State;

		public AvatarMask AvatarMask => m_AvatarMask;

		public float EntryDuration
		{
			get
			{
				if (Type != StateType.State)
				{
					return 0f;
				}
				if (m_State == null)
				{
					return 0f;
				}
				if (!m_State.HasEntryClip)
				{
					return 0f;
				}
				return m_State.EntryClip.length;
			}
		}

		public float ExitDuration
		{
			get
			{
				if (Type != StateType.State)
				{
					return 0f;
				}
				if (m_State == null)
				{
					return 0f;
				}
				if (!m_State.HasExitClip)
				{
					return 0f;
				}
				return m_State.ExitClip.length;
			}
		}

		public StateData(StateType stateType)
		{
			m_StateType = stateType;
			m_AnimationClip = GetAnimationInstance.Create;
			m_RuntimeController = null;
			m_State = null;
			m_AvatarMask = null;
		}

		public StateData(AnimationClip animationClip, AvatarMask avatarMask)
			: this(StateType.AnimationClip)
		{
			m_AnimationClip = new PropertyGetAnimation(new GetAnimationInstance(animationClip));
			m_AvatarMask = avatarMask;
		}

		public StateData(RuntimeAnimatorController runtimeController, AvatarMask avatarMask)
			: this(StateType.RuntimeController)
		{
			m_RuntimeController = runtimeController;
			m_AvatarMask = avatarMask;
		}

		public StateData(StateOverrideAnimator state)
			: this(StateType.State)
		{
			m_State = state;
		}

		public AnimationClip GetAnimationClip(Args args)
		{
			return m_AnimationClip.Get(args);
		}

		public bool IsValid(Character character)
		{
			return m_StateType switch
			{
				StateType.AnimationClip => m_AnimationClip.Get(character.Args) != null, 
				StateType.RuntimeController => m_RuntimeController != null, 
				StateType.State => m_State != null, 
				_ => false, 
			};
		}

		public override string ToString()
		{
			switch (m_StateType)
			{
			case StateType.AnimationClip:
				if (!(m_AnimationClip.EditorValue != null))
				{
					return "(none)";
				}
				return m_AnimationClip.EditorValue.name;
			case StateType.RuntimeController:
				if (!(m_RuntimeController != null))
				{
					return "(none)";
				}
				return m_RuntimeController.name;
			case StateType.State:
				if (!(m_State != null))
				{
					return "(none)";
				}
				return m_State.name;
			default:
				return string.Empty;
			}
		}
	}
}
