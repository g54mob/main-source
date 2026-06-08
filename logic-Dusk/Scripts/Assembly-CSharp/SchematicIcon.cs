using UnityEngine;

public class SchematicIcon : MonoBehaviour, IToggleVisibilityInSchematic, IUpdateCameraView
{
	public RoomItem roomItem;

	public bool IsInvisibleDueToToggle { get; set; }

	private void Start()
	{
		UpdateCameraView();
	}

	private void Update()
	{
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			if (roomItem != null)
			{
				GetComponent<Renderer>().enabled = roomItem.Explored;
			}
			else
			{
				GetComponent<Renderer>().enabled = true;
			}
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
		}
	}

	public void SetSchematicVisibility(bool show)
	{
		if (!show && GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().enabled = false;
			IsInvisibleDueToToggle = true;
		}
		else if (show && IsInvisibleDueToToggle && !GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().enabled = true;
			IsInvisibleDueToToggle = false;
		}
	}
}
