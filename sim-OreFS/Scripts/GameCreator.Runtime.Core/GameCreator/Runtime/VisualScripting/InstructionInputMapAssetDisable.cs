using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Disable Input Map")]
	[Description("Disables an Input Action asset with a Map value which stops reading user input")]
	[Category("Input/Disable Input Map")]
	[Parameter("Input Asset", "The Input Asset reference")]
	[Keywords(new string[] { "Deactivate", "Inactive" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Red)]
	public class InstructionInputMapAssetDisable : Instruction
	{
		[SerializeField]
		private InputMapFromAsset m_InputAsset = new InputMapFromAsset();

		public override string Title => $"Disable {m_InputAsset}";

		protected override Task Run(Args args)
		{
			InputActionMap inputMap = m_InputAsset.InputMap;
			if (inputMap != null && inputMap.enabled)
			{
				inputMap.Disable();
			}
			return Instruction.DefaultResult;
		}
	}
}
