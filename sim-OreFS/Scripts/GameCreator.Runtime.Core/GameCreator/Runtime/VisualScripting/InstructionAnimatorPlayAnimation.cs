using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Playables;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Play Animation Clip")]
	[Description("Plays an Animation Clip on the chosen Animator")]
	[Image(typeof(IconPlayCircle), ColorTheme.Type.Blue)]
	[Category("Animations/Play Animation Clip")]
	[Parameter("Animation Clip", "The Animation Clip that is played")]
	[Keywords(new string[] { "Animate", "Reproduce", "Sequence", "Cinematic" })]
	public class InstructionAnimatorPlayAnimation : TInstructionAnimator
	{
		[SerializeField]
		private PropertyGetAnimation m_AnimationClip = GetAnimationInstance.Create;

		public override string Title => $"Play {m_AnimationClip} on {m_Animator}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Animator.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Animator animator = gameObject.Get<Animator>();
			if (animator == null)
			{
				return Instruction.DefaultResult;
			}
			AnimationClip clip = m_AnimationClip.Get(args);
			AnimationPlayableUtilities.PlayClip(animator, clip, out var _);
			return Instruction.DefaultResult;
		}
	}
}
