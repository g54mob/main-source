using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Animation")]
	[Description("Sets the value of an Animation Clip")]
	[Image(typeof(IconAnimationClip), ColorTheme.Type.Teal)]
	[Category("Animations/Set Animation")]
	[Parameter("To", "The location where to save the Animation Clip")]
	[Parameter("Animation Clip", "The Animation Clip reference to store")]
	[Keywords(new string[] { "Animation", "Clip", "Animator" })]
	public class InstructionAnimatorSetAnimation : Instruction
	{
		[SerializeField]
		protected PropertySetAnimation m_To = SetAnimationNone.Create;

		[SerializeField]
		private PropertyGetAnimation m_AnimationClip = GetAnimationInstance.Create;

		public override string Title => $"Set {m_To} = {m_AnimationClip}";

		protected override Task Run(Args args)
		{
			AnimationClip value = m_AnimationClip.Get(args);
			m_To.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
