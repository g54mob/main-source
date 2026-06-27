using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementDirtMaskCreationRestrictions", fileName = "ElementDirtMaskCreationRestrictions")]
	public class ElementDirtMaskCreationRestrictions : ScriptableObject
	{
		[SerializeField]
		private float minDirtyPixelsToTotalPixelsInMeshRatio = 0.05f;

		[SerializeField]
		private int maxGenerationAttempts = 5;

		public int MaxGenerationAttempts => maxGenerationAttempts;

		public float MinDirtyPixelsToTotalPixelsInMeshRatio => minDirtyPixelsToTotalPixelsInMeshRatio;
	}
}
