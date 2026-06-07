using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Add Component")]
	[Description("Adds a component class to the game object")]
	[Category("Game Objects/Components/Add Component")]
	[Keywords(new string[] { "Add", "Append", "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow, typeof(OverlayPlus))]
	public class InstructionGameObjectAddComponent : TInstructionGameObject
	{
		[SerializeField]
		private TypeReferenceComponent m_Type = new TypeReferenceComponent();

		public override string Title => $"Add {m_Type} to {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.Add(m_Type.Type);
			return Instruction.DefaultResult;
		}
	}
}
