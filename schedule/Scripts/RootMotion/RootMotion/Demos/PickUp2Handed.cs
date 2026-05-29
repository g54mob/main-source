using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public abstract class PickUp2Handed : MonoBehaviour
	{
		public int GUIspace;

		public InteractionSystem interactionSystem;

		public InteractionObject obj;

		public Transform pivot;

		public Transform holdPoint;

		public float pickUpTime;

		private float holdWeight;

		private float holdWeightVel;

		private Vector3 pickUpPosition;

		private Quaternion pickUpRotation;

		private bool holding => false;

		private bool holdingLeft => false;

		private bool holdingRight => false;

		private void OnGUI()
		{
		}

		protected abstract void RotatePivot();

		private void Start()
		{
		}

		private void OnPause(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
		}

		private void OnStart(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
		}

		private void OnDrop(FullBodyBipedEffector effectorType, InteractionObject interactionObject)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
