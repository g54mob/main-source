using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Layer")]
	[Description("Returns true if the game object belongs to any of the layer mask values")]
	[Category("Game Objects/Compare Layer")]
	[Parameter("Game Object", "The game object instance used in the condition")]
	[Parameter("Layer Mask", "A bitmask of Layer values")]
	[Keywords(new string[] { "Mask", "Physics", "Belong", "Has" })]
	[Image(typeof(IconLayers), ColorTheme.Type.Yellow)]
	public class ConditionGameObjectLayerMask : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		protected override string Summary => $"{m_GameObject} belongs to {LayerMaskValue.GetLayerMaskName(m_LayerMask)}";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			return (m_LayerMask.value & (1 << gameObject.layer)) > 0;
		}
	}
}
