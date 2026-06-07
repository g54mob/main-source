using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public abstract class Reaction : ScriptableObject, IReaction
	{
		[SerializeField]
		private float m_TransitionIn = 0.1f;

		[SerializeField]
		private float m_TransitionOut = 0.25f;

		[SerializeField]
		private bool m_UseRootMotion = true;

		[SerializeField]
		private PropertyGetDecimal m_Speed = GetDecimalConstantOne.Create;

		[SerializeField]
		private ReactionList m_ReactionList = new ReactionList();

		[SerializeField]
		private RunInstructionsList m_OnEnter = new RunInstructionsList();

		[SerializeField]
		private RunInstructionsList m_OnExit = new RunInstructionsList();

		public float TransitionIn => m_TransitionIn;

		public float TransitionOut => m_TransitionOut;

		public bool UseRootMotion => m_UseRootMotion;

		public ReactionItem CanRun(Character character, Args args, ReactionInput input)
		{
			if (!(character != null))
			{
				return null;
			}
			return m_ReactionList.Get(args, input.Direction, input.Power);
		}

		public ReactionOutput Run(Character character, Args args, ReactionInput input)
		{
			ReactionItem reaction = ((character != null) ? m_ReactionList.Get(args, input.Direction, input.Power) : null);
			return Run(character, args, input, reaction);
		}

		public ReactionOutput Run(Character character, Args args, ReactionInput input, ReactionItem reaction)
		{
			if (character == null)
			{
				return default(ReactionOutput);
			}
			if (reaction == null)
			{
				return default(ReactionOutput);
			}
			RotateCharacter(character, input.Direction, reaction.Rotation);
			AnimationClip animationClip = reaction.AnimationClip;
			AvatarMask avatarMask = reaction.AvatarMask;
			float cancelTime = reaction.CancelTime;
			float gravity = reaction.Gravity;
			float speed = (float)m_Speed.Get(args);
			if (animationClip == null)
			{
				m_OnEnter.Run(args);
				return default(ReactionOutput);
			}
			ReactionOutput result = new ReactionOutput(animationClip.length, speed, cancelTime, gravity, this);
			ConfigGesture config = new ConfigGesture(0f, (animationClip != null) ? animationClip.length : 0f, speed, m_UseRootMotion, m_TransitionIn, m_TransitionOut);
			Task task = character.Gestures.CrossFade(animationClip, avatarMask, BlendMode.Blend, config, stopPreviousGestures: true);
			OnRun(this, task, args);
			return result;
		}

		private void RotateCharacter(Character character, Vector3 direction, ReactionRotation mode)
		{
			Vector3 vector = Vector3.Scale(direction, Vector3Plane.NormalUp);
			if (!(vector.sqrMagnitude <= 0f))
			{
				switch (mode)
				{
				case ReactionRotation.None:
					return;
				case ReactionRotation.FollowDirection:
					direction = vector.normalized;
					break;
				case ReactionRotation.AgainstDirection:
					direction = -vector.normalized;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				Quaternion rotation = Quaternion.LookRotation(character.transform.TransformDirection(direction), Vector3.up);
				character.Driver.SetRotation(rotation);
			}
		}

		private static async Task OnRun(Reaction reaction, Task task, Args args)
		{
			if (!(reaction == null))
			{
				reaction.m_OnEnter.Run(args);
				await task;
				if (!ApplicationManager.IsExiting && !(reaction == null))
				{
					reaction.m_OnExit.Run(args);
				}
			}
		}
	}
}
