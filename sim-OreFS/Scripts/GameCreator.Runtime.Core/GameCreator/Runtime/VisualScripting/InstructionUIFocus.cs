using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Focus On")]
	[Category("UI/Focus On")]
	[Image(typeof(IconBullsEye), ColorTheme.Type.TextLight)]
	[Description("Focuses on a specific UI component")]
	[Parameter("Focus On", "The UI component that takes focus")]
	[Keywords(new string[] { "Select" })]
	public class InstructionUIFocus : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_FocusOn = GetGameObjectInstance.Create();

		public override string Title => $"Focus on {m_FocusOn}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_FocusOn.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			if (EventSystem.current == null)
			{
				return Instruction.DefaultResult;
			}
			EventSystem.current.SetSelectedGameObject(gameObject);
			return Instruction.DefaultResult;
		}
	}
}
