using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Toggle")]
	[Category("UI/Change Toggle")]
	[Image(typeof(IconUIToggle), ColorTheme.Type.TextLight)]
	[Description("Changes the value of a Toggle component")]
	[Parameter("Toggle", "The Toggle component that changes its value")]
	[Parameter("Value", "The new value set")]
	public class InstructionUIChangeToggle : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Toggle = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetBool m_Value = GetBoolValue.Create(value: true);

		public override string Title => $"Toggle {m_Toggle} = {m_Value}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Toggle.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Toggle toggle = gameObject.Get<Toggle>();
			if (toggle == null)
			{
				return Instruction.DefaultResult;
			}
			toggle.isOn = m_Value.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
