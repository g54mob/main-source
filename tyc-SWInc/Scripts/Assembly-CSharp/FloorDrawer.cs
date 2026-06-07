using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FloorDrawer : MonoBehaviour
{
	public Material Mat;

	private int _lastFloor = int.MinValue;

	private List<ValueTuple<Mesh, int>> _meshes = new List<ValueTuple<Mesh, int>>();

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || _lastFloor == GameSettings.Instance.ActiveFloor)
		{
			return;
		}
		_lastFloor = GameSettings.Instance.ActiveFloor;
		_meshes.Clear();
		if (_lastFloor > 0)
		{
			return;
		}
		int num = -(1 + _lastFloor);
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.Floor == num)
			{
				if (room.FloorMesh != null)
				{
					_meshes.Add(new ValueTuple<Mesh, int>(room.FloorMesh.GetComponent<MeshFilter>().sharedMesh, 0));
				}
				else if (room.Roof != null)
				{
					_meshes.Add(new ValueTuple<Mesh, int>(room.Roof.GetComponent<MeshFilter>().sharedMesh, 1));
				}
			}
		}
	}

	private void OnDisable()
	{
		_meshes.Clear();
	}

	private void OnEnable()
	{
		_lastFloor = int.MinValue;
	}

	private void OnPreCull()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			for (int i = 0; i < _meshes.Count; i++)
			{
				ValueTuple<Mesh, int> valueTuple = _meshes[i];
				Graphics.DrawMesh(valueTuple.Item1, Matrix4x4.Translate(new Vector3(0f, (float)(GameSettings.Instance.ActiveFloor - valueTuple.Item2) * 2f + 0.004f, 0f)), Mat, 0, CameraScript.Instance.mainCam, 0, null, ShadowCastingMode.Off, false);
			}
		}
	}
}
