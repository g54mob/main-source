using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Disable Component")]
	[Description("Disables a component class from the game object")]
	[Category("Game Objects/Components/Disable Component")]
	[Keywords(new string[] { "Deactivate", "Turn", "Off", "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Red)]
	public class InstructionGameObjectDisableComponent : TInstructionGameObject
	{
		[SerializeField]
		private TypeReferenceBehaviour m_Type = new TypeReferenceBehaviour();

		public override string Title => $"Disable {m_Type} from {m_GameObject}";

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
				behaviour.enabled = false;
			}
			return Instruction.DefaultResult;
		}
	}
}
