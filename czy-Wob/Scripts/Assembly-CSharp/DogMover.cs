using InControl;
using UnityEngine;

public class DogMover : MonoBehaviour
{
	public bool dragEnabled = true;

	private Vector3 lastMousePos;

	private int quickClickFrameLimit = 5;

	private int quickClickFrameCounter;

	private float agitationForce = 5f;

	private float zScrollSpeed = 25f;

	private float moveMultiplier = 25f;

	private float raycastDist = 100f;

	private GameObject dogRef;

	private void Update()
	{
		if (dragEnabled)
		{
			ProcessMouseInput();
		}
	}

	private void ProcessMouseInput()
	{
		if (dogRef == null)
		{
			CheckForNewDog();
			return;
		}
		CheckDropDog();
		if (dogRef != null)
		{
			CheckDragDog();
		}
	}

	private void CheckForNewDog()
	{
		if (GameControls.actions.Interact.WasPressed && RaycastUtil.GoodRaycast(Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition()), out var hitInfo, raycastDist))
		{
			GameObject gameObject = hitInfo.transform.gameObject;
			if (gameObject.transform.root.gameObject.CompareTag(Tags.DOG))
			{
				PickupDog(gameObject);
			}
		}
	}

	private void CheckDragDog()
	{
		if (GameControls.actions.Interact.IsPressed)
		{
			DragDog();
			ScrollDog();
		}
	}

	private void CheckDropDog()
	{
		if (!GameControls.actions.Interact.IsPressed)
		{
			DropDog();
		}
	}

	private void PickupDog(GameObject newDogRef)
	{
		dogRef = newDogRef;
		lastMousePos = Camera.main.ScreenToViewportPoint(InputManager.MouseProvider.GetPosition());
		quickClickFrameCounter = 0;
	}

	private void DragDog()
	{
		quickClickFrameCounter++;
		if (quickClickFrameCounter >= quickClickFrameLimit)
		{
			if (quickClickFrameCounter == quickClickFrameLimit)
			{
				dogRef.GetComponent<Rigidbody>().isKinematic = true;
			}
			Vector3 vector = Camera.main.ScreenToViewportPoint(InputManager.MouseProvider.GetPosition());
			Vector3 position = new Vector3(dogRef.transform.position.x + (vector.x - lastMousePos.x) * moveMultiplier, dogRef.transform.position.y + (vector.y - lastMousePos.y) * moveMultiplier, dogRef.transform.position.z);
			lastMousePos = vector;
			dogRef.transform.position = position;
		}
	}

	private void ScrollDog()
	{
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis != 0f)
		{
			if (axis > 0f)
			{
				dogRef.transform.position += new Vector3(0f, 0f, zScrollSpeed * Time.deltaTime);
			}
			else
			{
				dogRef.transform.position -= new Vector3(0f, 0f, zScrollSpeed * Time.deltaTime);
			}
		}
	}

	private void DropDog()
	{
		if (quickClickFrameCounter < quickClickFrameLimit)
		{
			AgitateDog();
		}
		dogRef.GetComponent<Rigidbody>().isKinematic = false;
		dogRef = null;
	}

	private void AgitateDog()
	{
		Vector3 force = (Camera.main.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition()) - dogRef.transform.position) * (0f - agitationForce);
		dogRef.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}
}
