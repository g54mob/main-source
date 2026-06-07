using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Remove Component")]
	[Description("Removes an existing component from the game object")]
	[Category("Game Objects/Components/Remove Component")]
	[Keywords(new string[] { "Delete", "Destroy", "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Red, typeof(OverlayMinus))]
	public class InstructionGameObjectRemoveComponent : TInstructionGameObject
	{
		[SerializeField]
		private TypeReferenceComponent m_Type = new TypeReferenceComponent();

		public override string Title => $"Remove {m_Type} from {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Component component = gameObject.Get(m_Type.Type);
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			return Instruction.DefaultResult;
		}
	}
}
