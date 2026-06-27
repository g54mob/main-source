using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public abstract class InteractiveObjectPackage : MonoBehaviour
	{
		[SerializeField]
		protected PackageInteractionTrigger packageInteractionTrigger;

		public InteractiveObjectStoreDimensions GetStoreDimensions()
		{
			return new InteractiveObjectStoreDimensions
			{
				Size = packageInteractionTrigger.Collider.size,
				Center = packageInteractionTrigger.Collider.center,
				Rotation = Quaternion.identity
			};
		}

		public bool HasCollision()
		{
			return packageInteractionTrigger.HasCollision();
		}
	}
}
