using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Tag")]
	[Description("Returns true if the game object is tagged with a concrete name")]
	[Category("Game Objects/Compare Tag")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Parameter("Tag", "The Tag name checked against the game object")]
	[Keywords(new string[] { "Belong", "Has", "Is" })]
	[Image(typeof(IconTag), ColorTheme.Type.Yellow)]
	public class ConditionGameObjectTag : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private TagValue m_Tag = new TagValue();

		protected override string Summary => $"{m_GameObject} tagged as {m_Tag}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject != null)
			{
				return gameObject.CompareTag(m_Tag.Value);
			}
			return false;
		}
	}
}
