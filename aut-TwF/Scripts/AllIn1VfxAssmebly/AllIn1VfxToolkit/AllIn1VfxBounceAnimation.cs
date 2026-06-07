using UnityEngine;

namespace AllIn1VfxToolkit
{
	public class AllIn1VfxBounceAnimation : MonoBehaviour
	{
		[SerializeField]
		private Vector3 targetOffset = Vector3.up;

		[SerializeField]
		private float speed = 1f;

		private Vector3 startPosition;

		private Vector3 animationMovementVector;

		private void Start()
		{
			startPosition = base.transform.position;
		}

		private void Update()
		{
			animationMovementVector = targetOffset * ((Mathf.Sin(Time.time * speed) + 1f) / 2f);
			base.transform.position = startPosition + animationMovementVector;
		}
	}
}
