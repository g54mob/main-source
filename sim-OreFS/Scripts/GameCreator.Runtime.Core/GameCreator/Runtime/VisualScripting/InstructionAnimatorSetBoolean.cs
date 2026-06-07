using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Animator Boolean")]
	[Description("Sets the value of a 'Bool' Animator parameter")]
	[Image(typeof(IconAnimator), ColorTheme.Type.Green)]
	[Category("Animations/Set Animator Boolean")]
	[Parameter("Parameter Name", "The Animator parameter name to be modified")]
	[Parameter("Value", "The value of the parameter that is set")]
	[Keywords(new string[] { "Parameter", "Bool" })]
	public class InstructionAnimatorSetBoolean : TInstructionAnimator
	{
		[SerializeField]
		private PropertyGetString m_Parameter = new PropertyGetString("My Parameter");

		[SerializeField]
		private ChangeBool m_Value = new ChangeBool(value: true);

		public override string Title => $"Set Animator Parameter {m_Parameter} on {m_Animator}";

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
			int id = Animator.StringToHash(m_Parameter.Get(args));
			bool value = animator.GetBool(id);
			bool value2 = m_Value.Get(value, args);
			animator.SetBool(id, value2);
			return Instruction.DefaultResult;
		}
	}
}
