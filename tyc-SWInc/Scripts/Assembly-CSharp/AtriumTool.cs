using System;
using System.Collections.Generic;
using UnityEngine;

public class AtriumTool : MonoBehaviour
{
	public static AtriumTool Instance;

	public MeshFilter Self;

	[NonSerialized]
	private Room _currentRoom;

	private float _cost;

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		if (HUD.Instance != null)
		{
			BuildController.Instance.ClearBuild(false, false, false, false, false, false, false, false, true);
			HUD.Instance.UpdateBorderOverlay();
		}
		if (GameSettings.Instance.ActiveFloor < 1 || GameSettings.Instance.ActiveFloor == GameSettings.MaxFloor)
		{
			GameSettings.Instance.ActiveFloor = Mathf.Clamp(GameSettings.Instance.ActiveFloor, 1, GameSettings.MaxFloor - 1);
			Furniture.UpdateEdgeDetection();
			GameSettings.Instance.sRoomManager.ChangeFloor();
		}
	}

	private void OnDisable()
	{
		_currentRoom = null;
		Self.sharedMesh = null;
		_cost = 0f;
		if (HUD.Instance != null && !GameSettings.IsQuitting)
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
		if (Input.GetMouseButtonUp(1))
		{
			CostDisplay.Instance.Hide();
			base.gameObject.SetActive(false);
			return;
		}
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		float enter;
		if (new Plane(Vector3.up, Vector3.up * GameSettings.Instance.ActiveFloor * 2f).Raycast(ray, out enter))
		{
			Vector3 point = ray.GetPoint(enter);
			if (_currentRoom == null || !_currentRoom.IsInside(point))
			{
				_currentRoom = null;
				Self.sharedMesh = null;
				_cost = 0f;
				CostDisplay.Instance.Hide();
				Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor - 1, point.FlattenVector3());
				if (roomFromPoint != null && !roomFromPoint.Outdoors && !roomFromPoint.Pillar && !roomFromPoint.Outside && roomFromPoint.Roofing == null)
				{
					roomFromPoint = roomFromPoint.GetMainAtriumParentOrSelf();
					if (roomFromPoint.Floor + roomFromPoint.AtriumChildren.Count < GameSettings.MaxFloor)
					{
						Self.sharedMesh = roomFromPoint.Darkness.GetComponent<MeshFilter>().sharedMesh;
						Self.transform.position = Vector3.up * (roomFromPoint.Floor + roomFromPoint.AtriumChildren.Count + 1) * 2f;
						_currentRoom = roomFromPoint;
						_cost = BuildController.GetRoomCost(_currentRoom.Edges, _currentRoom.Area, false, false, _currentRoom.Floor + _currentRoom.AtriumChildren.Count + 1, false, false, true);
						UISoundFX.PlaySFX("HighlightTick", true);
					}
				}
			}
		}
		if (_cost > 0f && _currentRoom != null)
		{
			CostDisplay.Instance.Show(_cost, _currentRoom.Center.ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + 1f));
		}
		if (GUICheck.OverGUI || !(_currentRoom != null) || !Input.GetMouseButtonDown(0))
		{
			return;
		}
		if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - _cost))
		{
			RoomCloneTool.Intersection intersection = RoomCloneTool.Intersects(_currentRoom.GetExpanded(0.01f), _currentRoom.Floor + _currentRoom.AtriumChildren.Count + 1, false, true, false, false);
			Room room = null;
			if (intersection != RoomCloneTool.Intersection.None)
			{
				room = GetAtriumValidRoom(_currentRoom.Floor + _currentRoom.AtriumChildren.Count + 1, _currentRoom);
				if (room != null)
				{
					intersection = RoomCloneTool.Intersection.None;
				}
			}
			if (intersection == RoomCloneTool.Intersection.None)
			{
				Room room2;
				if (room != null)
				{
					room2 = room;
					room2.DirtyFloorMesh = true;
					room2.ClearAtriumPillarVariables();
				}
				else
				{
					BuildingPrefab prefab = BuildingPrefab.SaveRooms(new Room[1] { _currentRoom }, new Roof[0], false, true);
					RoomCloneTool.Instance.SetOptions(null, false, RoomCloneTool.GroupOption.Ignore, null, false);
					List<KeyValuePair<Room, BuildingPrefab.RoomObject>> list = RoomCloneTool.Instance.BuildPrefab(prefab, _currentRoom.AtriumChildren.Count + 1, false, false, false, false);
					room2 = ((list.Count > 0) ? list[0].Key : null);
				}
				if (room2 != null)
				{
					if (room == null)
					{
						GameSettings.Instance.MyCompany.MakeTransaction(0f - _cost, Company.TransactionCategory.Construction, true, "Atrium");
						CostDisplay.Instance.FloatAway();
						UISoundFX.PlaySFX("Kaching");
					}
					_currentRoom.AtriumParent = _currentRoom;
					room2.AtriumParent = _currentRoom;
					if (_currentRoom.AtriumChildren.Count > 0)
					{
						Room room3 = _currentRoom.AtriumChildren.Last();
						room3.DirtyRoofMesh = true;
						room3.AtriumChildren.ForEach(delegate(Room x)
						{
							x.DirtyRoofMesh = true;
						});
					}
					else
					{
						_currentRoom.DirtyRoofMesh = true;
					}
					_currentRoom.AtriumChildren.Add(room2);
					List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
					_currentRoom.UpdateAtriumFurniture(list2);
					_currentRoom.RefreshTextureTiling();
					_currentRoom.RecalculateStateVariables(true);
					if (room2.Floor != GameSettings.Instance.ActiveFloor)
					{
						GameSettings.Instance.ActiveFloor = Mathf.Clamp(room2.Floor, 1, GameSettings.MaxFloor - 1);
						Furniture.UpdateEdgeDetection();
						GameSettings.Instance.sRoomManager.ChangeFloor();
					}
					if (room == null)
					{
						list2.Insert(0, new UndoObject.UndoAction(room2, true, _cost));
					}
					else
					{
						list2.Insert(0, new UndoObject.UndoAction(room2, 1));
					}
					List<Furniture> furnitures = _currentRoom.GetFurnitures();
					for (int num = 0; num < furnitures.Count; num++)
					{
						Furniture furniture = furnitures[num];
						if (furniture.IsAliveNotNull() && furniture.PokesThroughRoof)
						{
							list2.Add(new UndoObject.UndoAction(furniture, false));
							furniture.DestroyGO();
						}
					}
					_currentRoom.UpdateAtriumNetwork();
					GameSettings.Instance.AddUndo(list2.ToArray());
					UISoundFX.PlaySFX("PlaceRoom", true);
				}
				else
				{
					UISoundFX.PlaySFX("BuildError");
				}
			}
			else
			{
				UISoundFX.PlaySFX("BuildError");
				switch (intersection)
				{
				case RoomCloneTool.Intersection.Room:
					ErrorOverlay.Instance.ShowError("RoomIntersectError", false, true, 4f);
					break;
				case RoomCloneTool.Intersection.Roof:
					ErrorOverlay.Instance.ShowError("RoofIntersectError", false, true, 4f);
					break;
				}
			}
			_currentRoom = null;
		}
		else
		{
			UISoundFX.PlaySFX("BuildError");
			HUD.FlashMoney();
		}
	}

	public Room GetAtriumValidRoom(int floor, Room main)
	{
		Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(floor, main.Center, true, false);
		if (roomFromPoint != null && !roomFromPoint.Outdoors && !roomFromPoint.Outside && roomFromPoint.AtriumParent == null)
		{
			List<Vector2> list = main.Edges.SelectInPlaceList((WallEdge x) => x.Pos);
			List<Vector2> list2 = roomFromPoint.Edges.SelectInPlaceList((WallEdge x) => x.Pos);
			if (WallDragTool.SitsOn(list, list2) && WallDragTool.SitsOn(list2, list))
			{
				return roomFromPoint;
			}
		}
		return null;
	}
}
