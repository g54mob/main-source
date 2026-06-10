using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Hidden/Optimizers Reference")]
	public class OptimizersReference : MonoBehaviour
	{
		public Optimizer_Base Parent;

		[Tooltip("If Occlusion Culling Rays should stop on this collider, should be untoggled on lights / particle systems cause you can see them throught (transparent). Also untoggle it on models with transparent materials!")]
		public bool IsObstacle = true;
	}
}
