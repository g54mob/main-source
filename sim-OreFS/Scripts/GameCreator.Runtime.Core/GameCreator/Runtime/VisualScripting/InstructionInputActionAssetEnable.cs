using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enable Input Action")]
	[Description("Enables an Input Action asset which allows it to start reading user input")]
	[Category("Input/Enable Input Action")]
	[Parameter("Input Asset", "The Input Asset reference")]
	[Keywords(new string[] { "Activate", "Active", "Start" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Green, typeof(OverlayDot))]
	public class InstructionInputActionAssetEnable : Instruction
	{
		[SerializeField]
		private InputActionFromAsset m_InputAsset = new InputActionFromAsset();

		public override string Title => $"Enable {m_InputAsset}";

		protected override Task Run(Args args)
		{
			InputAction inputAction = m_InputAsset.InputAction;
			if (inputAction != null && !inputAction.enabled)
			{
				inputAction.Enable();
			}
			return Instruction.DefaultResult;
		}
	}
}
