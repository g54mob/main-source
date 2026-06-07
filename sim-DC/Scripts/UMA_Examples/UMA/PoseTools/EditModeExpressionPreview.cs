using UnityEngine;

namespace UMA.PoseTools
{
	[ExecuteInEditMode]
	public class EditModeExpressionPreview : MonoBehaviour
	{
		public ExpressionPlayer expressionPlayer;

		public UMAExpressionSet expressionSet;

		public Transform skeletonRoot;

		public UMAGeneratorBase umaGenerator;

		protected UMASkeleton skeleton;

		private void OnRenderObject()
		{
		}

		private void Update()
		{
		}
	}
}
