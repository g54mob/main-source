using UnityEngine;

namespace Gh
{
	public class RigSwap : MonoBehaviour
	{
		public SkinnedMeshRenderer skinnedMeshRenderer;

		public Transform newRootBone;

		[ContextMenu("Check for null bones")]
		private void CheckForNullBones()
		{
		}

		[ContextMenu("Swap Bones")]
		private void SwapBones()
		{
		}
	}
}
