using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Component Enabled")]
	[Description("Returns true if the game object has the component enabled")]
	[Category("Game Objects/Is Component Enabled")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Parameter("Component", "The component type checked")]
	[Keywords(new string[] { "Null", "Active" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Green)]
	public class ConditionGameObjectComponentEnabled : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private TypeReferenceComponent m_Component = new TypeReferenceComponent();

		protected override string Summary => $"{m_Component} on {m_GameObject} Enabled";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			Component component = gameObject.Get(m_Component.Type);
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (!(behaviour == null))
			{
				return behaviour.isActiveAndEnabled;
			}
			return true;
		}
	}
}
