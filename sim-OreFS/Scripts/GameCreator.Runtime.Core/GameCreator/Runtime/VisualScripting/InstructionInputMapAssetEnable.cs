using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enable Input Map")]
	[Description("Enables an Input Action asset with a Map value which allows reading user input")]
	[Category("Input/Enable Input Map")]
	[Parameter("Input Asset", "The Input Asset reference")]
	[Keywords(new string[] { "Activate", "Active", "Start" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Green)]
	public class InstructionInputMapAssetEnable : Instruction
	{
		[SerializeField]
		private InputMapFromAsset m_InputAsset = new InputMapFromAsset();

		public override string Title => $"Enable {m_InputAsset}";

		protected override Task Run(Args args)
		{
			InputActionMap inputMap = m_InputAsset.InputMap;
			if (inputMap != null && !inputMap.enabled)
			{
				inputMap.Enable();
			}
			return Instruction.DefaultResult;
		}
	}
}
