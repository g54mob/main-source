using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Animator Trigger")]
	[Description("Sets the value of a 'Trigger' Animator parameter")]
	[Image(typeof(IconAnimator), ColorTheme.Type.Green)]
	[Category("Animations/Set Animator Trigger")]
	[Parameter("Parameter Name", "The Animator parameter name modified")]
	[Keywords(new string[] { "Parameter", "Once", "Flag", "Notify" })]
	public class InstructionAnimatorSetTrigger : TInstructionAnimator
	{
		[SerializeField]
		private PropertyGetString m_Parameter = new PropertyGetString("My Parameter");

		public override string Title => $"Set Animator Trigger {m_Parameter} on {m_Animator}";

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
			int trigger = Animator.StringToHash(m_Parameter.Get(args));
			animator.SetTrigger(trigger);
			return Instruction.DefaultResult;
		}
	}
}
