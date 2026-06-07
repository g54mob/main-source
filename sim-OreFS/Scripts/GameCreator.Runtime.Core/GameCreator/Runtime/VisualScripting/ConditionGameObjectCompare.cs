using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Game Objects")]
	[Description("Returns true if the game object is the same as another one")]
	[Category("Game Objects/Compare Game Objects")]
	[Parameter("Game Object", "The game object instance used in the comparison")]
	[Parameter("Compare To", "The game object instance that is compared against")]
	[Keywords(new string[] { "Same", "Equal", "Exact", "Instance" })]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow)]
	public class ConditionGameObjectCompare : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private PropertyGetGameObject m_CompareTo = new PropertyGetGameObject();

		protected override string Summary => $"{m_GameObject} = {m_CompareTo}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			GameObject gameObject2 = m_CompareTo.Get(args);
			return gameObject == gameObject2;
		}
	}
}
