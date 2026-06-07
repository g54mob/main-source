using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Disable Input Action")]
	[Description("Disables an Input Action asset which stops it from reading user input")]
	[Category("Input/Disable Input Action")]
	[Parameter("Input Asset", "The Input Asset reference")]
	[Keywords(new string[] { "Deactivate", "Inactive" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Red, typeof(OverlayDot))]
	public class InstructionInputActionAssetDisable : Instruction
	{
		[SerializeField]
		private InputActionFromAsset m_InputAsset = new InputActionFromAsset();

		public override string Title => $"Disable {m_InputAsset}";

		protected override Task Run(Args args)
		{
			InputAction inputAction = m_InputAsset.InputAction;
			if (inputAction != null && inputAction.enabled)
			{
				inputAction.Disable();
			}
			return Instruction.DefaultResult;
		}
	}
}
