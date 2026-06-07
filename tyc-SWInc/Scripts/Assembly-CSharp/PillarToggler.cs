using UnityEngine;

public class PillarToggler : MonoBehaviour
{
	public static PillarToggler Instance;

	public MeshFilter Roof;

	public MeshFilter Walls;

	private Room _lastRoom;

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		BuildController.Instance.ClearBuild(false, false, false, false, false, false, true);
	}

	private void OnDisable()
	{
		if (HUD.Instance != null)
		{
			HUD.Instance.UpdateBorderOverlay();
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			base.gameObject.SetActive(false);
			SelectorController.CanClick = false;
		}
		else
		{
			if (GUICheck.OverGUI)
			{
				return;
			}
			Ray mouseRay = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
			float depth;
			Room room = SelectorController.Instance.GetRoomRoofAt(mouseRay, true, true, false, out depth) as Room;
			if (room != null && (room.Outdoors || room.AtriumParent != null))
			{
				room = null;
			}
			if (room != _lastRoom)
			{
				_lastRoom = room;
				if (_lastRoom == null)
				{
					Roof.gameObject.SetActive(false);
					Walls.gameObject.SetActive(false);
				}
				else
				{
					Roof.gameObject.SetActive(false);
					Walls.gameObject.SetActive(false);
					if (_lastRoom.Roof != null)
					{
						MeshFilter component = _lastRoom.Roof.GetComponent<MeshFilter>();
						if (component != null)
						{
							Roof.sharedMesh = component.sharedMesh;
							Roof.gameObject.SetActive(true);
						}
					}
					if (_lastRoom.OuterWalls != null)
					{
						MeshFilter component2 = _lastRoom.OuterWalls.GetComponent<MeshFilter>();
						if (component2 != null)
						{
							Walls.sharedMesh = component2.sharedMesh;
							Walls.gameObject.SetActive(true);
						}
					}
				}
			}
			if (_lastRoom != null)
			{
				base.transform.position = new Vector3(0f, (float)_lastRoom.Floor * 2f, 0f);
				if (Input.GetMouseButtonDown(0) && !GUICheck.OverGUI)
				{
					_lastRoom.TogglePillar(true);
					_lastRoom = null;
				}
			}
		}
	}
}
