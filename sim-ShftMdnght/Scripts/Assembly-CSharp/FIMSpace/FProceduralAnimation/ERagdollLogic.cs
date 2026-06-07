using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public enum ERagdollLogic
	{
		[Tooltip("Main Ragdoll Animator purpose, using all features for active and animated ragdoll")]
		ActiveRagdoll = 0,
		[Tooltip("Very limited features, no animation matching, just letting unity physics control over character ragdoll source bones. DISABLE mecanim animator to let character fall on the ground.")]
		JustBoneComponents = 1
	}
}
