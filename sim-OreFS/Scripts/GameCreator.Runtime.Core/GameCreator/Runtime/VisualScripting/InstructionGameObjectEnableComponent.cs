using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Enable Component")]
	[Description("Enables a component class from the game object")]
	[Category("Game Objects/Components/Enable Component")]
	[Keywords(new string[] { "Active", "Turn", "On", "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectEnableComponent : TInstructionGameObject
	{
		[SerializeField]
		private TypeReferenceBehaviour m_Type = new TypeReferenceBehaviour();

		public override string Title => $"Enable {m_Type} from {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Behaviour behaviour = gameObject.Get(m_Type.Type) as Behaviour;
			if (behaviour != null)
			{
				behaviour.enabled = true;
			}
			return Instruction.DefaultResult;
		}
	}
}
