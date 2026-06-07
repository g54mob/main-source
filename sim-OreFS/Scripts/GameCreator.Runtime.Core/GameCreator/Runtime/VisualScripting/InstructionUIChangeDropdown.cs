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
	[Title("Change Dropdown")]
	[Category("UI/Change Dropdown")]
	[Image(typeof(IconUIDropdown), ColorTheme.Type.TextLight)]
	[Description("Changes the value of a Dropdown or Text Mesh Pro Dropdown component")]
	[Parameter("Text", "The Text or Text Mesh Pro component that changes its value")]
	[Parameter("Index", "The new index value of the Dropdown")]
	public class InstructionUIChangeDropdown : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Dropdown = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetDecimal m_Index = GetDecimalInteger.Create(0);

		public override string Title => $"Dropdown {m_Dropdown} = {m_Index}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Dropdown.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Dropdown dropdown = gameObject.Get<Dropdown>();
			if (dropdown != null)
			{
				dropdown.value = Mathf.FloorToInt((float)m_Index.Get(args));
				return Instruction.DefaultResult;
			}
			TMP_Dropdown tMP_Dropdown = gameObject.Get<TMP_Dropdown>();
			if (tMP_Dropdown != null)
			{
				tMP_Dropdown.value = Mathf.FloorToInt((float)m_Index.Get(args));
			}
			return Instruction.DefaultResult;
		}
	}
}
