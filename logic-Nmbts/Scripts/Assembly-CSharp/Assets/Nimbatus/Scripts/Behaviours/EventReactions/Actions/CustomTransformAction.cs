using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public abstract class CustomTransformAction : NimbatusAction
	{
		public bool HasCustomTransform;

		[ShowIf("HasCustomTransform", true)]
		public Transform CustomTransform;

		protected Transform GetTransform()
		{
			Transform result = OwnWorldObject.transform;
			if (HasCustomTransform)
			{
				result = CustomTransform;
			}
			return result;
		}
	}
}
