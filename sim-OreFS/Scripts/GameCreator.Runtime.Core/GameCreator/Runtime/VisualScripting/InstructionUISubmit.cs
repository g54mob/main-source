using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Submit")]
	[Category("UI/Submit")]
	[Image(typeof(IconUIHoverEnter), ColorTheme.Type.TextLight)]
	[Description("Performs a submit action on a UI element")]
	[Keywords(new string[] { "Enter", "Press", "Confirm" })]
	public class InstructionUISubmit : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Submit = GetGameObjectInstance.Create();

		public override string Title => $"Submit {m_Submit}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Submit.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			ISubmitHandler[] components = gameObject.GetComponents<ISubmitHandler>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i]?.OnSubmit(null);
			}
			return Instruction.DefaultResult;
		}
	}
}
