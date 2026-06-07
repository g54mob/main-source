using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Input Field")]
	[Category("UI/Change Input Field")]
	[Image(typeof(IconUIInputField), ColorTheme.Type.TextLight)]
	[Description("Changes the value of an Input Field or Text Mesh Pro Input Field")]
	[Parameter("Input Field", "The Input Field or TMP Input Field component that changes its value")]
	[Parameter("Value", "The new value set")]
	public class InstructionUIChangeInputField : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_InputField = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetString m_Value = GetStringString.Create;

		public override string Title => $"Input {m_InputField} = {m_Value}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_InputField.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			InputField inputField = gameObject.Get<InputField>();
			if (inputField != null)
			{
				inputField.text = m_Value.Get(args);
				return Instruction.DefaultResult;
			}
			TMP_InputField tMP_InputField = gameObject.Get<TMP_InputField>();
			if (tMP_InputField != null)
			{
				tMP_InputField.text = m_Value.Get(args);
			}
			return Instruction.DefaultResult;
		}
	}
}
