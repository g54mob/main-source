using System;
using System.Text;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[HideInSelector]
	[Title("Tester")]
	[Category("Testing/Instruction Tester")]
	[Image(typeof(IconCheckSolid), ColorTheme.Type.Green)]
	[Description("Appends a character to a static Chain field. For internal testing use only")]
	[Parameter("Character", "A character that will be appended to InstructionTester.Chain")]
	[Example("\n        Note that this Instruction is not accessible through the Inspector to avoid confusing new \n        users. To run the test suit environment, create a new `InstructionList` object and append\n        as many `InstructionTester` instances as your test requires.\n \n        ```csharp\n        InstructionList instructions = new InstructionList(\n            new InstructionTester('a'),\n            new InstructionTester('b'),\n            new InstructionTester('c')\n        );\n\n        InstructionTester.Clear();\n        instructions.Run(null);\n\n        Debug.Log(InstructionTester.Chain);\n        // Prints: 'abc'\n        ```\n        This instruction is for internal testing only.\n    ")]
	public class InstructionTester : Instruction
	{
		private static StringBuilder _Chain = new StringBuilder();

		[SerializeField]
		private char m_Character = 'a';

		public static string Chain => _Chain.ToString();

		public override string Title => $"Append '{m_Character}'";

		public static void Clear()
		{
			_Chain.Clear();
		}

		public InstructionTester()
		{
		}

		public InstructionTester(char character)
			: this()
		{
			m_Character = character;
		}

		protected override Task Run(Args args)
		{
			_Chain.Append(m_Character);
			return Instruction.DefaultResult;
		}
	}
}
