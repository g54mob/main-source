using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class LookAtTarget : MonoBehaviour
	{
		[SerializeField]
		private Transform lookAtTarget;

		[SerializeField]
		private Transform positionTarget;

		[SerializeField]
		private bool invertForwardDirection = true;

		private Vector3 initialPositionOffset;

		private void Start()
		{
			if (positionTarget != null)
			{
				initialPositionOffset = positionTarget.position - base.transform.position;
			}
		}

		private void Update()
		{
			if (lookAtTarget != null)
			{
				base.transform.LookAt(lookAtTarget);
				if (invertForwardDirection)
				{
					base.transform.Rotate(Vector3.up * 180f);
				}
			}
			if (positionTarget != null)
			{
				base.transform.position = positionTarget.position + initialPositionOffset;
			}
		}
	}
}
