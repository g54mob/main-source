using System;
using System.Globalization;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Log Number")]
	[Description("Prints a text from a numeric source to the Unity Console")]
	[Category("Debug/Log Number")]
	[Parameter("Number", "The number to log")]
	[Keywords(new string[]
	{
		"Debug", "Log", "Print", "Show", "Display", "Test", "Float", "Double", "Decimal", "Integer",
		"Message"
	})]
	[Image(typeof(IconBug), ColorTheme.Type.TextLight)]
	public class InstructionCommonDebugNumber : Instruction
	{
		[SerializeField]
		private string m_Prefix = "Number";

		[SerializeField]
		private PropertyGetDecimal m_Message = new PropertyGetDecimal(5f);

		public override string Title => string.Format("{0}{1}", (!string.IsNullOrEmpty(m_Prefix)) ? (m_Prefix + ": ") : string.Empty, m_Message);

		protected override Task Run(Args args)
		{
			string obj = ((!string.IsNullOrEmpty(m_Prefix)) ? (m_Prefix + ": ") : string.Empty);
			string text = m_Message.Get(args).ToString(CultureInfo.InvariantCulture);
			Debug.Log(obj + text);
			return Instruction.DefaultResult;
		}
	}
}
