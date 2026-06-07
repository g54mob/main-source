using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Play Gesture")]
	[Description("Plays an Animation Clip on a Character once")]
	[Category("Characters/Animation/Play Gesture")]
	[Parameter("Character", "The character that plays the animation")]
	[Parameter("Animation Clip", "The Animation Clip that is played")]
	[Parameter("Avatar Mask", "(Optional) Allows to play the animation on specific body parts of the Character")]
	[Parameter("Blend Mode", "Additively adds the new animation on top of the rest or overrides any lower layer animations")]
	[Parameter("Delay", "Amount of seconds to wait before the animation starts to play")]
	[Parameter("Speed", "Speed coefficient at which the animation plays. 1 means normal speed")]
	[Parameter("Transition In", "The amount of seconds the animation takes to blend in")]
	[Parameter("Transition Out", "The amount of seconds the animation takes to blend out")]
	[Parameter("Wait To Complete", "If true this Instruction waits until the animation is complete")]
	[Keywords(new string[] { "Characters", "Animation", "Animate", "Gesture", "Play" })]
	[Image(typeof(IconCharacterGesture), ColorTheme.Type.Green)]
	public class InstructionCharacterGesture : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetAnimation m_AnimationClip = GetAnimationInstance.Create;

		[SerializeField]
		private AvatarMask m_AvatarMask;

		[SerializeField]
		private BlendMode m_BlendMode;

		[SerializeField]
		private PropertyGetDecimal m_Delay = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Speed = GetDecimalConstantOne.Create;

		[SerializeField]
		private bool m_UseRootMotion;

		[SerializeField]
		private PropertyGetDecimal m_TransitionIn = new PropertyGetDecimal(0.1f);

		[SerializeField]
		private PropertyGetDecimal m_TransitionOut = new PropertyGetDecimal(0.1f);

		[Space]
		[SerializeField]
		private bool m_WaitToComplete = true;

		public override string Title => $"Gesture {m_AnimationClip} on {m_Character}";

		protected override async Task Run(Args args)
		{
			AnimationClip animationClip = m_AnimationClip.Get(args);
			if (animationClip == null)
			{
				return;
			}
			Character character = m_Character.Get<Character>(args);
			if (!(character == null))
			{
				ConfigGesture config = new ConfigGesture((float)m_Delay.Get(args), animationClip.length, (float)m_Speed.Get(args), m_UseRootMotion, (float)m_TransitionIn.Get(args), (float)m_TransitionOut.Get(args));
				Task task = character.Gestures.CrossFade(animationClip, m_AvatarMask, m_BlendMode, config, stopPreviousGestures: false);
				if (m_WaitToComplete)
				{
					await task;
				}
			}
		}
	}
}
