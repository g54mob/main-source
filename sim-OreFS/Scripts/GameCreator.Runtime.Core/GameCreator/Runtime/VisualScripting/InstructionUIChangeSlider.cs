using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Slider")]
	[Category("UI/Change Slider")]
	[Image(typeof(IconUISlider), ColorTheme.Type.TextLight)]
	[Description("Changes the value of a Slider component")]
	[Parameter("Slider", "The Slider component that changes its value")]
	[Parameter("Value", "The new value set")]
	public class InstructionUIChangeSlider : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Toggle = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetDecimal m_Value = GetDecimalDecimal.Create(0.75f);

		public override string Title => $"Slider {m_Toggle} = {m_Value}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Toggle.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Slider slider = gameObject.Get<Slider>();
			if (slider == null)
			{
				return Instruction.DefaultResult;
			}
			slider.value = (float)m_Value.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
