using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Game Object Active")]
	[Description("Returns true if the game object reference exists and is active")]
	[Category("Game Objects/Is Game Object Active")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Keywords(new string[] { "Null", "Scene", "Enabled" })]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Green)]
	public class ConditionGameObjectActive : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		protected override string Summary => $"is Active {m_GameObject}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject != null)
			{
				return gameObject.activeInHierarchy;
			}
			return false;
		}
	}
}
