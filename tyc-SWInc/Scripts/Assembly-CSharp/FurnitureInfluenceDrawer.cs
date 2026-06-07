using System.Collections.Generic;
using UnityEngine;

public class FurnitureInfluenceDrawer : MonoBehaviour
{
	public static FurnitureInfluenceDrawer Instance;

	private int _maxRooms;

	private float _maxDistance;

	private Vector3 _position;

	private Room _room;

	public Material DrawMat;

	public Material OutsideMat;

	public float FloorOffset = 0.04f;

	public bool Set(Vector3 p, int maxRooms, float maxDistance)
	{
		_room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(p);
		if (_room != null && !_room.Outside)
		{
			_position = p;
			_maxRooms = maxRooms;
			_maxDistance = maxDistance;
			DrawMat.SetVector("_Center", new Vector4(_position.x, _position.y, _position.z, _maxDistance));
			OutsideMat.SetVector("_Center", new Vector4(_position.x, _position.y, _position.z, _maxDistance));
			base.enabled = true;
			return true;
		}
		return false;
	}

	public bool Set(string type, Vector3 p)
	{
		FurnitureDistances.FurnitureDist value;
		if (FurnitureDistances.Distances.TryGetValue(type, out value))
		{
			return Set(p, value.MaxRooms, value.Distance);
		}
		return false;
	}

	public bool Set(Furniture f)
	{
		FurnitureDistances.FurnitureDist value;
		if (FurnitureDistances.Distances.TryGetValue(f.Type, out value))
		{
			return Set(f.transform.position, value.MaxRooms, value.Distance);
		}
		return false;
	}

	public void Disable()
	{
		if (this != null)
		{
			base.enabled = false;
		}
	}

	private void Awake()
	{
		Instance = this;
		DrawMat = new Material(DrawMat);
		OutsideMat = new Material(OutsideMat);
		base.enabled = false;
	}

	private void OnPreCull()
	{
		if (GameSettings.Instance.IsReferenceNull() || !(_room != null))
		{
			return;
		}
		List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(_room);
		Rect other = new Rect(_position.FlattenVector3() - Vector2.one * _maxDistance, Vector2.one * _maxDistance * 2f);
		for (int i = 0; i < connectedRooms.Count; i++)
		{
			Room key = connectedRooms[i].Key;
			if (_maxRooms >= 0 && connectedRooms[i].Value > _maxRooms)
			{
				break;
			}
			if (!(key == null) && key.Floor <= GameSettings.Instance.ActiveFloor && (key.Outdoors || key.Outside || key.Floor == GameSettings.Instance.ActiveFloor))
			{
				if (key.Outside)
				{
					DrawOutside();
				}
				else if (key.RoomBounds.Overlaps(other))
				{
					DrawRoom(key);
				}
			}
		}
	}

	private void DrawOutside()
	{
		Graphics.DrawMesh(TimeOfDay.Instance.GroundTop.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.Translate(Vector3.up * 0.05f), OutsideMat, 0, CameraScript.Instance.mainCam, 0, null, false);
	}

	private void DrawRoom(Room r)
	{
		if (r.FloorMeshFilter != null && r.FloorMeshFilter.sharedMesh != null)
		{
			Graphics.DrawMesh(r.FloorMeshFilter.sharedMesh, Matrix4x4.Translate(Vector3.up * (FloorOffset + (float)r.Floor * 2f)), DrawMat, 0, CameraScript.Instance.mainCam, 0, null, false);
		}
	}
}
