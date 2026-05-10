using TinyGiantStudio.Modules;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[DisallowMultipleComponent]
	public class LayoutElementAnimator : MonoBehaviour
	{
		private bool settingPosition;

		public float moveDuration;

		public Vector3 startingPosition;

		public Vector3 targetPosition;

		public AnimationCurve positionAnimationCurve;

		private bool settingRotation;

		public float rotateDuration;

		public Quaternion startingRotation;

		public Quaternion targetRotation;

		public AnimationCurve rotationAnimationCurve;

		public float positionTimer;

		public float rotationTimer;

		private void Update()
		{
		}

		public void NewTargetLocalPosition(VariableHolder[] variableHolders, Vector3 newTargetPosition)
		{
		}

		public void NewTargetLocalRotation(VariableHolder[] variableHolders, Quaternion target)
		{
		}

		private bool IsNaN(Quaternion q)
		{
			return false;
		}
	}
}
