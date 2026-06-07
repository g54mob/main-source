using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Game Object")]
	[Description("Sets a game object value equal to another one")]
	[Category("Game Objects/Set Game Object")]
	[Parameter("Set", "Where the value is set")]
	[Parameter("From", "The value that is set")]
	[Keywords(new string[] { "Change", "Instance", "Variable", "Asset" })]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	public class InstructionGameObjectSetGameObject : Instruction
	{
		[SerializeField]
		private PropertySetGameObject m_Set = SetGameObjectNone.Create;

		[SerializeField]
		private PropertyGetGameObject m_From = new PropertyGetGameObject();

		public override string Title => $"Set {m_Set} = {m_From}";

		protected override Task Run(Args args)
		{
			GameObject value = m_From.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
