using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Does Game Object Exist")]
	[Description("Returns true if the game object reference is not null")]
	[Category("Game Objects/Does Game Object Exist")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Keywords(new string[] { "Null", "Scene", "Lives" })]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	public class ConditionGameObjectExists : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		protected override string Summary => $"{m_GameObject} Exist";

		protected override bool Run(Args args)
		{
			return m_GameObject.Get(args) != null;
		}
	}
}
