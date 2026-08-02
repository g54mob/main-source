using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[CreateAssetMenu(fileName = "Ragdoll Animator 2 Preset", menuName = "FImpossible Creations/Ragdoll Animator 2 Preset", order = 10)]
	public class RagdollAnimator2Preset : ScriptableObject
	{
		public RagdollHandler Settings = new RagdollHandler();
	}
}
