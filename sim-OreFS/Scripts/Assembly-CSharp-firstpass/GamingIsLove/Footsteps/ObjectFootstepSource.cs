using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Object Footstep Source")]
	public class ObjectFootstepSource : FootstepSource
	{
		[Tooltip("The footstep material defines the footstep effects (audio clips and prefabs) of this game object.")]
		public FootstepMaterial material;

		public override FootstepEffect GetFootstepAt(Vector3 position, string effectTag)
		{
			if (material != null)
			{
				return material.GetEffect(effectTag);
			}
			return null;
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/ObjectFootstepSource Icon.png");
		}
	}
}
