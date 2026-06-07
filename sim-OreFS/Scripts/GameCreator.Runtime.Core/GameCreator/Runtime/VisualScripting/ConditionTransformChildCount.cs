using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Child Count")]
	[Description("Compares the amount of direct children of a game object")]
	[Category("Transforms/Child Count")]
	[Parameter("Target", "The children amount of this game object instance")]
	[Parameter("Comparison", "The comparison operation between the child count and a value")]
	[Parameter("Compare To", "The second value compared")]
	[Keywords(new string[] { "Transform", "Hierarchy", "Descendant", "Ancestor", "Parent", "Father", "Amount" })]
	[Image(typeof(IconHanger), ColorTheme.Type.Green)]
	public class ConditionTransformChildCount : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_Child = new PropertyGetGameObject();

		[SerializeField]
		private CompareInteger m_Compare = new CompareInteger(1);

		protected override string Summary => $"{m_Child} children {m_Compare}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_Child.Get(args);
			int value = ((gameObject != null) ? gameObject.transform.childCount : 0);
			return m_Compare.Match(value, args);
		}
	}
}
