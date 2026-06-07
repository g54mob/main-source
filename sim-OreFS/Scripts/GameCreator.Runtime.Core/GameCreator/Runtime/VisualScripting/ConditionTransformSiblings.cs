using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Sibling Of")]
	[Description("Returns true if the game object shares the same parent as the other one")]
	[Category("Transforms/Is Sibling Of")]
	[Parameter("Sibling A", "The game object instance compared")]
	[Parameter("Sibling B", "Another game object instance compared")]
	[Keywords(new string[] { "Transform", "Hierarchy", "Ancestor", "Brother", "Sister" })]
	[Image(typeof(IconHanger), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	public class ConditionTransformSiblings : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_SiblingA = new PropertyGetGameObject();

		[SerializeField]
		private PropertyGetGameObject m_SiblingB = new PropertyGetGameObject();

		protected override string Summary => $"{m_SiblingB} is sibling of {m_SiblingA}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_SiblingA.Get(args);
			GameObject gameObject2 = m_SiblingB.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			if (gameObject2 == null)
			{
				return false;
			}
			return gameObject.transform.parent == gameObject2.transform.parent;
		}
	}
}
