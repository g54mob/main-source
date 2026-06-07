using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Layer")]
	[Description("Changes the layer value of a game object")]
	[Parameter("Layer", "The layer where the game object belongs to")]
	[Parameter("Children Too", "Whether to also change the layer of the game object's children or not")]
	[Category("Game Objects/Change Layer")]
	[Keywords(new string[] { "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconLayers), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectLayer : TInstructionGameObject
	{
		[SerializeField]
		private LayerMaskValue m_Layer = new LayerMaskValue();

		[SerializeField]
		private bool m_ChildrenToo;

		public override string Title => string.Format("Change Layer to {0} on {1} {2}", m_Layer, m_GameObject, m_ChildrenToo ? "and children" : string.Empty);

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.layer = m_Layer.Value;
			if (m_ChildrenToo)
			{
				Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = m_Layer.Value;
				}
			}
			return Instruction.DefaultResult;
		}
	}
}
