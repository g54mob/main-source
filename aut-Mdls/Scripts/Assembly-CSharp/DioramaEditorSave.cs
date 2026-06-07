using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Shapes;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class DioramaEditorSave : ScriptableObject
{
	[Serializable]
	public struct DioramaShape
	{
		public int GroupID;

		public Vector3 Position;

		[FormerlySerializedAs("ShapeData")]
		public ShapeDataSO ShapeDataSO;

		public Vector3Int Rotation;
	}

	[Serializable]
	public struct DioramaShapeCollection
	{
		public ShapeDataSO ShapeData;

		public List<DioramaShape> Shapes;
	}

	public List<DioramaShape> DioramaShapes = new List<DioramaShape>();

	public List<ShapeDataSO> ToolBarShapes = new List<ShapeDataSO>();

	public List<DioramaEditorBlueprintSave> Blueprints = new List<DioramaEditorBlueprintSave>();

	public SerializedDictionary<ShapeHashPair, DioramaShapeCollection> DioramaShapesDictionary = new SerializedDictionary<ShapeHashPair, DioramaShapeCollection>();

	public Vector3 Center;

	public Vector3 CameraPivotPos;

	public Vector3 CameraRotationEulerAngles;

	public float CameraZoomLevel;

	public string Name;

	public List<Vector3Int> OccupiedPositions = new List<Vector3Int>();
}
