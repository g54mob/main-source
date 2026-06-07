using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Raycast 3D")]
	[Description("Returns true if there's an object between two positions")]
	[Category("Physics/Raycast 3D")]
	[Parameter("Source", "The scene position where the raycast originates")]
	[Parameter("Target", "The targeted position where the raycast ends")]
	[Parameter("Layer Mask", "A bitmask that skips any objects that don't belong to the list")]
	[Example("Note that this Instruction uses Unity's 3D physics engine. It won't collide with any 2D objects")]
	[Keywords(new string[] { "Check", "Collide", "Linecast", "See", "3D" })]
	[Image(typeof(IconLineStartEnd), ColorTheme.Type.Green)]
	public class ConditionPhysicsRaycast3D : Condition
	{
		[SerializeField]
		private PropertyGetPosition m_Source = GetPositionCamerasMain.Create;

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		protected override string Summary => $"obstacle [{m_Source} and {m_Target}]";

		protected override bool Run(Args args)
		{
			Vector3 vector = m_Source.Get(args);
			GameObject gameObject = m_Target.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			if (Physics.Raycast(vector, gameObject.transform.position - vector, out var hitInfo, Vector3.Distance(vector, gameObject.transform.position), m_LayerMask, QueryTriggerInteraction.Ignore))
			{
				return hitInfo.collider.gameObject != gameObject;
			}
			return false;
		}
	}
}
