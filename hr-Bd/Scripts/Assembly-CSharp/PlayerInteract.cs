using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	[SerializeField]
	private Transform cam;

	[SerializeField]
	private GameObject cursorIcon;

	private bool interactable = true;

	private InteractObject selectingObject;

	[HideInInspector]
	public float distance = 6.5f;

	[HideInInspector]
	public bool Interactable
	{
		set
		{
			interactable = value;
			if (!interactable)
			{
				cursorIcon.SetActive(value: false);
			}
		}
	}

	private void Update()
	{
		if (!interactable)
		{
			return;
		}
		if (Physics.Raycast(cam.position, cam.forward, out var hitInfo, distance) && Time.timeScale > 0f)
		{
			selectingObject = hitInfo.collider.GetComponent<InteractObject>();
			InteractObject interactObject = selectingObject;
			if ((object)interactObject != null && interactObject.interactable)
			{
				cursorIcon.SetActive(value: true);
			}
			else
			{
				cursorIcon.SetActive(value: false);
			}
		}
		else
		{
			cursorIcon.SetActive(value: false);
			selectingObject = null;
		}
		if ((Input.GetKeyDown(KeyCode.E) && Time.timeScale > 0f) || (Input.GetMouseButtonDown(0) && Time.timeScale > 0f))
		{
			selectingObject?.InvokeEvent();
		}
	}
}
