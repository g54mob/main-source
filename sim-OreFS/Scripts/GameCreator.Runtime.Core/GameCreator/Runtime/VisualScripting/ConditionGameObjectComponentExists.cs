using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Does Component Exist")]
	[Description("Returns true if the game object has the component attached")]
	[Category("Game Objects/Does Component Exist")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Parameter("Component", "The component type that is searched")]
	[Keywords(new string[] { "Null", "Scene", "Lives" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	public class ConditionGameObjectComponentExists : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private TypeReferenceComponent m_Component = new TypeReferenceComponent();

		protected override string Summary => $"{m_GameObject} has {m_Component}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			return gameObject.Get(m_Component.Type) != null;
		}
	}
}
