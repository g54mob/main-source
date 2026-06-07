using UnityEngine;

namespace VRTK.Examples
{
	public class ClimbableHandLift : MonoBehaviour
	{
		public VRTK_InteractableObject interactableObject;

		public float speed = 0.1f;

		public Transform handleTop;

		public Transform ropeTop;

		public Transform ropeBottom;

		public GameObject rope;

		public GameObject handle;

		public bool isMoving;

		protected bool isMovingUp = true;

		protected virtual void OnEnable()
		{
			interactableObject = ((interactableObject == null) ? GetComponent<VRTK_InteractableObject>() : interactableObject);
			if (interactableObject != null)
			{
				interactableObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
			}
		}

		protected virtual void OnDisable()
		{
			if (interactableObject != null)
			{
				interactableObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
			}
		}

		protected virtual void Update()
		{
			if (isMoving)
			{
				Vector3 vector = (isMovingUp ? Vector3.up : Vector3.down) * speed * Time.deltaTime;
				handle.transform.position += vector;
				Vector3 localScale = rope.transform.localScale;
				localScale.y = (ropeTop.position.y - handle.transform.position.y) / 2f;
				Vector3 position = ropeTop.transform.position;
				position.y -= localScale.y;
				rope.transform.localScale = localScale;
				rope.transform.position = position;
				if ((!isMovingUp && handle.transform.position.y <= ropeBottom.position.y) || (isMovingUp && handle.transform.position.y >= handleTop.position.y))
				{
					isMoving = false;
					isMovingUp = !isMovingUp;
				}
			}
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			isMoving = true;
		}
	}
}
