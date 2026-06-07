using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Child Of")]
	[Description("Returns true if the game object is the parent of the other one")]
	[Category("Transforms/Is Child Of")]
	[Parameter("Child", "The game object instance further down in the hierarchy of the parent")]
	[Parameter("Parent", "The game object instance that is higher in the hierarchy")]
	[Keywords(new string[] { "Transform", "Hierarchy", "Descendant", "Ancestor", "Parent", "Father", "Mother" })]
	[Image(typeof(IconHanger), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	public class ConditionTransformIsChild : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_Child = new PropertyGetGameObject();

		[SerializeField]
		private PropertyGetGameObject m_Parent = new PropertyGetGameObject();

		protected override string Summary => $"{m_Parent} is child of {m_Child}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_Child.Get(args);
			GameObject gameObject2 = m_Parent.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			if (gameObject2 == null)
			{
				return false;
			}
			return gameObject.transform.IsChildOf(gameObject2.transform);
		}
	}
}
