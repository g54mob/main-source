using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Name")]
	[Description("Changes the name of a game object")]
	[Parameter("Name", "The new name assigned to the game object")]
	[Category("Game Objects/Change Name")]
	[Keywords(new string[] { "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectName : TInstructionGameObject
	{
		[SerializeField]
		private PropertyGetString m_Name = GetStringString.Create;

		public override string Title => $"Name of {m_GameObject} = {m_Name}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.name = m_Name.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
