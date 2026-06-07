using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change ID")]
	[Description("Changes the Local Name or List Variable's ID. It only works on non-Savable variables")]
	[Category("Variables/Change ID")]
	[Parameter("ID", "The new ID of the Local Variable")]
	[Keywords(new string[] { "Unique", "Guid" })]
	[Image(typeof(IconID), ColorTheme.Type.Purple)]
	public class InstructionVariablesChangeId : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_LocalVariables = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetString m_ID = GetStringGuid.Create;

		public override string Title => $"ID of {m_LocalVariables} = {m_ID}";

		protected override Task Run(Args args)
		{
			TLocalVariables tLocalVariables = m_LocalVariables.Get<TLocalVariables>(args);
			if (tLocalVariables == null)
			{
				return Instruction.DefaultResult;
			}
			string value = m_ID.Get(args);
			if (string.IsNullOrEmpty(value))
			{
				return Instruction.DefaultResult;
			}
			IdString nextId = new IdString(value);
			tLocalVariables.ChangeId(nextId);
			return Instruction.DefaultResult;
		}
	}
}
