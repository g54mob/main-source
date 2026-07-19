using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
	public static GameObject hover;

	public static Vector3 gridPosition;

	public static Vector3 gridRotation;

	public static Vector3 axis = Vector3.up;

	public static Transform axisToggle;

	public static Transform layerInput;

	public LayerMask layerMask;

	private RaycastHit hit;

	private RaycastHit[] hits;

	public GameObject boxSelection;

	private string hitType;

	private bool normalRotation;

	public static float grid = 1f;

	public static float gridRotate = 15f;

	public static int gridShape = 0;

	public static bool gridDivide = true;

	public static float layer = 0f;

	public Tabs tabs;

	private EventSystem system;

	private Camera cameraMain;

	private bool boxDragging;

	private Vector2 boxStart;

	private void Start()
	{
		cameraMain = Camera.main;
		system = EventSystem.current;
		Selection.Update();
	}

	private void Update()
	{
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		if (list.Count > 0)
		{
			hover = list[0].gameObject;
		}
		ToolMain();
		if (tabs.tab != 2)
		{
			ToolBlocks();
		}
		if (tabs.tab == 2)
		{
			ToolMaterials();
		}
		ActionLayer();
		string hint = "default";
		if (tabs.tab < 2)
		{
			if (Selection.list.Count > 0)
			{
				hint = "selection";
			}
			if (Global.elements["selector"].childCount > 0)
			{
				hint = "placement";
			}
		}
		else if (tabs.tab == 2)
		{
			hint = "material";
		}
		Hints.instance.SetHint(hint);
		TabSelection();
	}

	public static float GetGrid()
	{
		float num = grid;
		if (gridDivide)
		{
			num /= 10f;
		}
		return num;
	}

	public void ToolMain()
	{
		if (Global.control)
		{
			if (Hotkey.GetKeyDown("Camera/Screenshot"))
			{
				StartCoroutine(Global.Screenshot());
			}
			if (Hotkey.GetKeyDown("Camera/Screenshot without UI"))
			{
				StartCoroutine(Global.Screenshot(ui: false));
			}
			if (Hotkey.GetKeyDown("Edit/Undo"))
			{
				Undo.UndoState();
			}
			if (Hotkey.GetKeyDown("Edit/Redo"))
			{
				Undo.RedoState();
			}
			if (Hotkey.GetKeyDown("Script/Repeat"))
			{
				Procedural.RepeatLua();
			}
			if (Hotkey.GetKeyDown("File/Save"))
			{
				Project.Save();
			}
			if (Hotkey.GetKeyDown("File/Save As"))
			{
				Project.SaveAs();
			}
			if (Hotkey.GetKeyDown("File/Open"))
			{
				Project.Open();
			}
			if (Hotkey.GetKeyDown("Edit/Unhide"))
			{
				Unhide();
			}
			else if (Hotkey.GetKeyDown("Edit/Hide"))
			{
				Hide();
			}
		}
	}

	public void TabSelection()
	{
		if (!Input.GetKeyDown(KeyCode.Tab))
		{
			return;
		}
		Selectable selectable = ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp() : system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown());
		if (selectable != null)
		{
			InputField component = selectable.GetComponent<InputField>();
			if (component != null)
			{
				component.OnPointerClick(new PointerEventData(system));
			}
			system.SetSelectedGameObject(selectable.gameObject);
		}
		else
		{
			selectable = Selectable.allSelectables[0];
			system.SetSelectedGameObject(selectable.gameObject);
		}
	}

	public void ToolBlocks()
	{
		if (!Global.control)
		{
			return;
		}
		CursorRaycast();
		if (gridShape == 0)
		{
			gridPosition = Global.RoundVector(hit.point, grid);
		}
		else
		{
			gridPosition = Grid.Hex(hit.point);
		}
		if (Hotkey.GetKey("Modifier/Alt"))
		{
			gridPosition.y = Mathf.Round(hit.point.y * 10f) / 10f;
		}
		if (Hotkey.GetKey("Edit/Greeble"))
		{
			gridRotation = Quaternion.LookRotation(hit.normal, Vector3.up).eulerAngles + Quaternion.AngleAxis(90f, Vector3.right).eulerAngles;
			gridPosition = SnapToSurface(hit, grid / 10f);
			normalRotation = true;
		}
		else if (normalRotation)
		{
			gridRotation = Vector3.zero;
			normalRotation = false;
		}
		Global.elements["selector"].position = Vector3.Lerp(Global.elements["selector"].position, gridPosition, Time.deltaTime * 40f);
		Global.elements["selector"].rotation = Quaternion.Lerp(Global.elements["selector"].rotation, Quaternion.Euler(gridRotation), Time.deltaTime * 24f);
		if (Hotkey.GetKeyDown("Edit/Rotate"))
		{
			if (Global.elements["selector"].childCount > 0)
			{
				int num = 0;
				num = ((gridShape != 0) ? 60 : ((!Hotkey.GetKey("Modifier/Control")) ? 90 : 45));
				if (Hotkey.GetKey("Modifier/Shift"))
				{
					num = -num;
				}
				gridRotation.y += num;
			}
			else
			{
				ActionRotate();
			}
		}
		if (!EventSystem.current.IsPointerOverGameObject() && Gizmo.instance.handleDrag == null && hitType != "widget")
		{
			if (Input.GetMouseButton(0))
			{
				if (!boxDragging)
				{
					boxDragging = true;
					boxStart = Input.mousePosition;
				}
			}
			else if (boxDragging)
			{
				boxDragging = false;
				Vector2 vector = Input.mousePosition;
				if ((boxStart - vector).magnitude > 100f)
				{
					Vector3[] array = new Vector3[4];
					Vector3[] array2 = new Vector3[4];
					int num2 = 0;
					Vector2 p = boxStart;
					Vector3 mousePosition = Input.mousePosition;
					Vector2[] boundingBox = GetBoundingBox(p, mousePosition);
					foreach (Vector2 vector2 in boundingBox)
					{
						Ray ray = Camera.main.ScreenPointToRay(vector2);
						Vector3 vector3 = (array[num2] = ray.origin + ray.direction * 100f);
						array2[num2] = ray.origin - vector3;
						num2++;
					}
					boxSelection.GetComponent<MeshCollider>().sharedMesh = GenerateSelectionMesh(array, array2);
				}
			}
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			boxDragging = false;
		}
		if (!boxDragging && Input.GetMouseButton(0) && Hotkey.GetKey("Modifier/Control") && Gizmo.instance.handleDrag == null && hitType != "widget" && hitType == "object")
		{
			Selection.Add(hit.transform);
		}
		if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
		{
			if (Global.elements["selector"].childCount > 0)
			{
				PlaceSelector(Hotkey.GetKey("Modifier/Shift"));
				Tips.Show("selection");
			}
			else if (hitType != "widget")
			{
				if (hitType == "object")
				{
					if (!Hotkey.GetKey("Modifier/Shift"))
					{
						Selection.Clear();
					}
					Selection.Toggle(hit.transform);
					if (!Hotkey.GetKey("Modifier/Control"))
					{
						Groups.SelectGroup(hit.transform);
					}
				}
				else
				{
					Selection.Clear();
				}
			}
		}
		if (tabs.tab != 2)
		{
			ControlVertexSnap.instance.Snap();
		}
		if (Hotkey.GetKeyDown("Edit/Cancel"))
		{
			ClearSelector();
		}
		if (Hotkey.GetKeyDown("Edit/Delete"))
		{
			Delete();
		}
		if (Hotkey.GetKeyDown("Edit/Cut"))
		{
			Cut();
		}
		if (Hotkey.GetKeyDown("Edit/Copy"))
		{
			Copy();
		}
		if (Hotkey.GetKeyDown("Edit/Paste"))
		{
			Paste();
		}
		if (Hotkey.GetKeyDown("Edit/Clone"))
		{
			Clone();
		}
		if (Hotkey.GetKeyDown("Edit/Ungroup"))
		{
			Ungroup();
		}
		else if (Hotkey.GetKeyDown("Edit/Group"))
		{
			Group();
		}
		if (Hotkey.GetKeyDown("Edit/Unlock"))
		{
			Unlock();
		}
		else if (Hotkey.GetKeyDown("Edit/Lock"))
		{
			Lock();
		}
		if (Hotkey.GetKeyDown("Edit/Mirror"))
		{
			ActionMirror();
		}
		if (Hotkey.GetKeyDown("Selection/Select all"))
		{
			Selection.SelectAll();
		}
		if (Hotkey.GetKeyDown("Selection/Select none"))
		{
			Selection.Clear();
		}
		if (Hotkey.GetKey("Selection/Focus"))
		{
			Focus();
		}
		if (Hotkey.GetKeyDown("Grid/Axis"))
		{
			ToggleAxis();
		}
	}

	public void ToolMaterials()
	{
		Selection.Clear();
		if (EventSystem.current.IsPointerOverGameObject() || Interface.drag || !Physics.Raycast(cameraMain.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity, layerMask))
		{
			return;
		}
		if (Input.GetMouseButton(0) && Swatches.swatch != null)
		{
			Swatches.ReplaceRaycastMaterial(hitInfo);
			Undo.AddState();
		}
		if (Input.GetMouseButtonDown(2))
		{
			string raycastMaterial = Swatches.GetRaycastMaterial(hitInfo);
			if (raycastMaterial != "")
			{
				Swatches.SetSwatch(raycastMaterial);
			}
		}
	}

	public static void ToggleAxis()
	{
		ComponentIconToggle component = axisToggle.GetComponent<ComponentIconToggle>();
		if (axis == Vector3.right)
		{
			axis = Vector3.up;
			component.SetValue(1);
		}
		else if (axis == Vector3.up)
		{
			axis = Vector3.forward;
			component.SetValue(2);
		}
		else if (axis == Vector3.forward)
		{
			axis = Vector3.right;
			component.SetValue(0);
		}
	}

	public void ActionLayer()
	{
		if (Hotkey.GetKeyDown("Grid/Up"))
		{
			layer += 1f;
			layerInput.GetComponent<ComponentRocker>().SetValue(layer);
		}
		if (Hotkey.GetKeyDown("Grid/Down"))
		{
			layer -= 1f;
			layerInput.GetComponent<ComponentRocker>().SetValue(layer);
		}
		Global.elements["studio"].position = Vector3.Lerp(Global.elements["studio"].position, new Vector3(0f, layer, 0f), Time.deltaTime * 10f);
	}

	public void SetLayer(float i)
	{
		layer = i;
	}

	public void ActionMirror()
	{
		Vector3 localScale = Global.elements["selector"].localScale;
		if (axis == Vector3.right)
		{
			Global.elements["selection"].localScale = new Vector3(0f - Global.elements["selection"].localScale.x, localScale.y, localScale.z);
		}
		else if (axis == Vector3.up)
		{
			Global.elements["selection"].localScale = new Vector3(localScale.x, 0f - Global.elements["selection"].localScale.y, localScale.z);
		}
		else if (axis == Vector3.forward)
		{
			Global.elements["selection"].localScale = new Vector3(localScale.x, localScale.y, 0f - Global.elements["selection"].localScale.z);
		}
		Selection.Update();
		Undo.AddState();
	}

	public void ActionRotate()
	{
		if (!Hotkey.GetKey("Modifier/Shift"))
		{
			Global.elements["selection"].Rotate(-(axis * gridRotate));
		}
		else
		{
			Global.elements["selection"].Rotate(axis * gridRotate);
		}
		Selection.Update();
		Undo.AddState();
		Tips.Show("rotate");
	}

	public static void Delete()
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Selection.list)
		{
			list.Add(item);
		}
		Selection.Clear();
		foreach (Transform item2 in list)
		{
			Object.DestroyImmediate(item2.gameObject);
		}
		Undo.AddState();
	}

	public void Focus()
	{
		if (Selection.list.Count == 0)
		{
			Orbit.instance.SetPosition(Vector3.zero);
			return;
		}
		Vector3 zero = Vector3.zero;
		foreach (Transform item in Selection.list)
		{
			zero += item.position;
		}
		zero /= (float)Selection.list.Count;
		Orbit.instance.SetPosition(zero);
	}

	public static void Group()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Selection.list)
		{
			list.Add(item);
		}
		Groups.CreateGroup(list);
		Undo.AddState();
	}

	public static void Ungroup()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		foreach (Transform item in Selection.list)
		{
			BlockComponent component = item.GetComponent<BlockComponent>();
			if (component != null)
			{
				component.data.group = "";
			}
			Selection.UpdateLayer(item);
		}
		Global.ShowMessage("Ungrouped");
		Undo.AddState();
	}

	public static void Hide()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.hidden = true;
			item.gameObject.layer = LayerMask.NameToLayer("Hidden");
		}
		Global.ShowMessage("Hidden " + Selection.list.Count + " block(s)");
		Selection.Clear();
		Undo.AddState();
	}

	public static void Unhide()
	{
		foreach (Transform item in Global.SceneBlocks())
		{
			item.GetComponent<BlockComponent>().data.hidden = false;
			item.gameObject.layer = 0;
		}
		Global.ShowMessage("All blocks visible again");
		Undo.AddState();
	}

	public static void Lock()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.locked = true;
		}
		Global.ShowMessage("Locked " + Selection.list.Count + " block(s)");
		Selection.Clear();
		Undo.AddState();
	}

	public static void Unlock()
	{
		foreach (Transform item in Global.SceneBlocks())
		{
			item.GetComponent<BlockComponent>().data.locked = false;
		}
		Global.ShowMessage("All blocks unlocked again");
		Undo.AddState();
	}

	public void CursorRaycast()
	{
		hitType = "";
		Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
		hits = (from h in Physics.RaycastAll(ray, float.PositiveInfinity, layerMask)
			orderby h.distance
			select h).ToArray();
		RaycastHit[] array = hits;
		for (int num = 0; num < array.Length; num++)
		{
			RaycastHit raycastHit = array[num];
			if (raycastHit.transform.gameObject.layer == 9)
			{
				hit = raycastHit;
				hitType = "widget";
				break;
			}
			if ((bool)raycastHit.transform.parent && (raycastHit.transform.parent == Global.elements["workbench"] || raycastHit.transform.parent == Global.elements["selection"]) && (hitType == "" || hitType == "object"))
			{
				hit = raycastHit;
				hitType = "object";
			}
			if (Preferences.data.gridSelection)
			{
				if (raycastHit.transform.name == "grid" && Global.elements["selector"].childCount > 0 && hitType == "")
				{
					hit = raycastHit;
					hitType = "grid";
				}
			}
			else if (raycastHit.transform.name == "grid" && hitType == "")
			{
				hit = raycastHit;
				hitType = "grid";
			}
		}
		if (hitType == "object" && Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, layerMask) && (bool)hitInfo.transform.parent && (hitInfo.transform.parent == Global.elements["workbench"] || hitInfo.transform.parent == Global.elements["selection"]))
		{
			hit = hitInfo;
		}
	}

	public static void PlaceSelector(bool copy = false)
	{
		Global.elements["selector"].position = gridPosition;
		Global.elements["selector"].rotation = Quaternion.Euler(gridRotation);
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Global.elements["selector"])
		{
			list.Add(item);
		}
		Selection.Clear();
		Transform parent = Global.elements["workbench"];
		foreach (Transform item2 in list)
		{
			Transform parent2 = item2;
			if (copy)
			{
				GameObject obj = Object.Instantiate(item2.gameObject, item2.transform.position, item2.transform.rotation);
				obj.name = item2.name;
				obj.transform.SetParent(parent);
				obj.layer = 0;
				parent2 = obj.transform;
			}
			else
			{
				item2.SetParent(parent);
				if (!Hotkey.GetKey("Modifier/Shift"))
				{
					Selection.Add(item2);
				}
			}
			foreach (Material material in Swatches.GetMaterials(parent2))
			{
				Swatches.AddMaterial(material);
			}
		}
		Swatches.UpdateMaterials();
		UpdateScale();
		Undo.AddState();
	}

	public static void ClearSelector()
	{
		foreach (Transform item in Global.elements["selector"])
		{
			Object.Destroy(item.gameObject);
		}
	}

	public static void Cut()
	{
		Copy();
		Delete();
	}

	public static void Copy()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		Selection.Refresh();
		foreach (Transform item in Global.elements["clipboard"])
		{
			Object.Destroy(item.gameObject);
		}
		Vector3 zero = Vector3.zero;
		foreach (Transform item2 in Selection.list)
		{
			zero += item2.position;
		}
		zero /= (float)Selection.list.Count;
		zero.x = Mathf.Round(zero.x);
		zero.z = Mathf.Round(zero.z);
		foreach (Transform item3 in Selection.list)
		{
			item3.GetComponent<BlockComponent>().data.select = false;
			GameObject obj = Object.Instantiate(item3.gameObject, item3.position, item3.rotation);
			obj.name = item3.name;
			obj.transform.position -= new Vector3(zero.x, 0f, zero.z);
			obj.transform.SetParent(Global.elements["clipboard"]);
		}
		Global.ShowMessage(Selection.list.Count + " block(s) copied to clipboard");
	}

	public static void Paste()
	{
		Selection.Clear();
		ClearSelector();
		Global.elements["selector"].eulerAngles = Vector3.zero;
		gridRotation = Vector3.zero;
		foreach (Transform item in Global.elements["clipboard"])
		{
			GameObject obj = Object.Instantiate(item.gameObject, item.localPosition, item.rotation);
			obj.name = item.name;
			obj.transform.SetParent(Global.elements["selector"], worldPositionStays: false);
			Block data = obj.GetComponent<BlockComponent>().data;
			if (data.group != "")
			{
				data.group = "Group_" + Groups.groupIndex;
			}
		}
		Groups.groupIndex++;
		Global.SetLayerRecursively(Global.elements["selector"], 2);
	}

	public static void Clone()
	{
		if (Selection.list.Count == 0)
		{
			return;
		}
		Selection.Refresh();
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.select = false;
			GameObject gameObject = Object.Instantiate(item.gameObject, item.position, item.rotation);
			gameObject.name = item.name;
			gameObject.transform.SetParent(Global.elements["workbench"]);
			list.Add(gameObject.transform);
		}
		Selection.Clear();
		foreach (Transform item2 in list)
		{
			Selection.Add(item2);
		}
		Global.ShowMessage(list.Count + " block(s) cloned");
	}

	public static void MoveFloor()
	{
		Bounds bounds = Global.GetBounds(Selection.list);
		Vector3 center = bounds.center;
		center.x = 0f;
		center.z = 0f;
		center -= new Vector3(0f, bounds.extents.y, 0f);
		foreach (Transform item in Selection.list)
		{
			item.position -= center;
		}
		Selection.Refresh();
		Undo.AddState();
	}

	public static void MoveCenter()
	{
		Vector3 center = Global.GetBounds(Selection.list).center;
		foreach (Transform item in Selection.list)
		{
			item.position -= center;
		}
		Selection.Refresh();
		Undo.AddState();
	}

	private void OnGUI()
	{
		Vector2 vector = Input.mousePosition;
		if (boxDragging && (boxStart - vector).magnitude > 100f)
		{
			Rect screenRect = Utils.GetScreenRect(boxStart, Input.mousePosition);
			Utils.DrawScreenRect(screenRect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
			Utils.DrawScreenRectBorder(screenRect, 1f, new Color(0.8f, 0.8f, 0.95f));
		}
	}

	public static void UpdateScale()
	{
		foreach (Transform item in Selection.list)
		{
			try
			{
				if (Global.uvmap)
				{
					UVMapping.BoxUV(item.GetComponent<MeshFilter>().sharedMesh, item);
				}
			}
			catch
			{
			}
		}
	}

	public static Vector3 SnapToSurface(RaycastHit hit, float gridSize)
	{
		Vector3 v = hit.transform.InverseTransformPoint(hit.point);
		Vector3 vector = hit.transform.TransformPoint(Global.RoundVector(v, gridSize));
		new Plane(hit.normal, hit.point).Raycast(new Ray(vector, -hit.normal), out var enter);
		return vector + -hit.normal * enter;
	}

	private Vector2[] GetBoundingBox(Vector2 p1, Vector2 p2)
	{
		Vector3 vector = Vector3.Min(p1, p2);
		Vector3 vector2 = Vector3.Max(p1, p2);
		return new Vector2[4]
		{
			new Vector2(vector.x, vector2.y),
			new Vector2(vector2.x, vector2.y),
			new Vector2(vector.x, vector.y),
			new Vector2(vector2.x, vector.y)
		};
	}

	private Mesh GenerateSelectionMesh(Vector3[] corners, Vector3[] vecs)
	{
		Vector3[] array = new Vector3[8];
		int[] triangles = new int[36]
		{
			0, 1, 2, 2, 1, 3, 4, 6, 0, 0,
			6, 2, 6, 7, 2, 2, 7, 3, 7, 5,
			3, 3, 5, 1, 5, 0, 1, 1, 4, 0,
			4, 5, 6, 6, 5, 7
		};
		for (int i = 0; i < 4; i++)
		{
			array[i] = corners[i];
		}
		for (int j = 4; j < 8; j++)
		{
			array[j] = corners[j - 4] + vecs[j - 4];
		}
		return new Mesh
		{
			vertices = array,
			triangles = triangles
		};
	}
}
