using System;
using System.Collections.Generic;
using Data.Shapes;
using Logic.Shapes;
using Presentation.Shapes;
using UnityEngine;
using UnityEngine.Serialization;

public class DioramaEditorBlueprint
{
	[Serializable]
	public struct PositionedShapeData
	{
		public int GroupID;

		[FormerlySerializedAs("ShapeData")]
		public ShapeDataSO ShapeDataSO;

		public Vector3 Position;

		public Vector3Int Rotation;
	}

	public List<ShapeLoaderSO> Shapes = new List<ShapeLoaderSO>();

	public List<PositionedShapeData> ShapeDatas = new List<PositionedShapeData>();

	public List<ShapeLoaderSO> TransparentShapes = new List<ShapeLoaderSO>();

	public Vector3 Center;

	public Vector3 Bounds;

	private bool _isVisualizingBounds;

	private LineRenderer _boundsRenderer;

	private readonly Material _lineMaterial;

	private readonly bool _placeAsGroup;

	private int _groupID = -1;

	private static int _globalGroupID;

	public Vector3 Extents => Bounds * 0.5f;

	public Vector3 RealBounds => Bounds * 0.1f;

	public Vector3 RealExtents => Extents * 0.1f;

	public bool PlaceAsGroup => _placeAsGroup;

	public int GroupID => _groupID;

	public static int GetNewGroupID()
	{
		_globalGroupID++;
		return _globalGroupID;
	}

	public static void ResetGroupIDs()
	{
		_globalGroupID = 0;
	}

	public static void SetGlobalGroupID(int id)
	{
		_globalGroupID = id;
	}

	public DioramaEditorBlueprint(ShapeLoaderSO[] shapes, Material lineMaterial)
	{
		_lineMaterial = lineMaterial;
		ShapeDatas.Clear();
		foreach (ShapeLoaderSO item in shapes)
		{
			Shapes.Add(item);
		}
		RecalculateBounds();
	}

	public DioramaEditorBlueprint(PositionedShapeData[] shapeDatas, Material transparentShapeMat, Material lineMaterial, bool placeAsGroup = false)
	{
		_lineMaterial = lineMaterial;
		_placeAsGroup = placeAsGroup;
		if (_placeAsGroup)
		{
			_groupID = GetNewGroupID();
		}
		Shapes.Clear();
		for (int i = 0; i < shapeDatas.Length; i++)
		{
			PositionedShapeData item = shapeDatas[i];
			ShapeDatas.Add(item);
			Shape shape = Shape.Create(item.ShapeDataSO.Data, item.Position);
			ShapeLoaderSO shapeLoaderSO = new GameObject("BlueprintShape").AddComponent<ShapeLoaderSO>();
			shapeLoaderSO.InitMeshRendererAndFilter(transparentShapeMat);
			int layer = LayerMask.NameToLayer("Editor");
			shapeLoaderSO.gameObject.layer = layer;
			shape.Rotate(item.Rotation);
			shapeLoaderSO.LoadShape(shape);
			shapeLoaderSO.Rotation = item.Rotation;
			TransparentShapes.Add(shapeLoaderSO);
		}
		RecalculateBounds();
	}

	public DioramaEditorBlueprint(DioramaEditorBlueprintSave save, Material transparentShapeMat, Material lineMaterial, bool placeAsGroup = false)
	{
		_lineMaterial = lineMaterial;
		_placeAsGroup = placeAsGroup;
		if (_placeAsGroup)
		{
			_groupID = GetNewGroupID();
		}
		Shapes.Clear();
		foreach (PositionedShapeData blueprintData in save.BlueprintDatas)
		{
			ShapeDatas.Add(blueprintData);
			Shape shape = Shape.Create(blueprintData.ShapeDataSO.Data, blueprintData.Position);
			ShapeLoaderSO shapeLoaderSO = new GameObject("BlueprintShape").AddComponent<ShapeLoaderSO>();
			shapeLoaderSO.InitMeshRendererAndFilter(transparentShapeMat);
			int layer = LayerMask.NameToLayer("Editor");
			shapeLoaderSO.gameObject.layer = layer;
			shape.Rotate(blueprintData.Rotation);
			shapeLoaderSO.LoadShape(shape);
			shapeLoaderSO.Rotation = blueprintData.Rotation;
			TransparentShapes.Add(shapeLoaderSO);
		}
		RecalculateBounds();
	}

	public DioramaEditorBlueprint(ShapeDataSO shapeData, Material transparentShapeMat, Material lineMaterial, bool placeAsGroup = false)
	{
		_lineMaterial = lineMaterial;
		_placeAsGroup = placeAsGroup;
		if (_placeAsGroup)
		{
			_groupID = GetNewGroupID();
		}
		Shapes.Clear();
		ShapeDatas.Add(new PositionedShapeData
		{
			ShapeDataSO = shapeData,
			Position = Vector3.zero,
			Rotation = Vector3Int.zero
		});
		Shape shape = Shape.Create(shapeData.Data, Center);
		ShapeLoaderSO shapeLoaderSO = new GameObject("BlueprintShape").AddComponent<ShapeLoaderSO>();
		shapeLoaderSO.InitMeshRendererAndFilter(transparentShapeMat);
		int layer = LayerMask.NameToLayer("Editor");
		shapeLoaderSO.gameObject.layer = layer;
		shapeLoaderSO.LoadShape(shape);
		TransparentShapes.Add(shapeLoaderSO);
		RecalculateBounds();
	}

	public void UpdateGroupID()
	{
		if (_placeAsGroup)
		{
			_groupID = GetNewGroupID();
		}
	}

	private void RecalculateBounds()
	{
		if (Shapes.Count <= 0 && ShapeDatas.Count <= 0)
		{
			Bounds = Vector3.zero;
			Center = Vector3.zero;
		}
		else if (Shapes.Count > 0)
		{
			Vector3 vector = Shapes[0].Shape.VoxelPosToWorldPos(Vector3Int.zero);
			Vector3 vector2 = Shapes[0].Shape.VoxelPosToWorldPos(Shapes[0].Shape.GetBounds() - Vector3Int.one);
			for (int i = 1; i < Shapes.Count; i++)
			{
				vector = Vector3.Min(vector, Shapes[i].Shape.VoxelPosToWorldPos(Vector3Int.zero));
				vector2 = Vector3.Max(vector2, Shapes[i].Shape.VoxelPosToWorldPos(Shapes[i].Shape.GetBounds() - Vector3Int.one));
			}
			Bounds = vector2 - vector;
			Center = vector + Bounds * 0.5f;
			Bounds = Bounds / 0.1f + Vector3.one;
			Center.y = vector.y - 0.05f;
		}
		else if (ShapeDatas.Count > 0)
		{
			Vector3Int rotatedBounds = GetRotatedBounds(ShapeDatas[0]);
			Vector3 vector3 = ShapeDatas[0].Position - new Vector3((float)rotatedBounds.x * 0.5f * 0.1f, 0f, (float)rotatedBounds.z * 0.5f * 0.1f);
			Vector3 vector4 = ShapeDatas[0].Position + new Vector3((float)rotatedBounds.x * 0.5f * 0.1f, (float)rotatedBounds.y * 0.1f, (float)rotatedBounds.z * 0.5f * 0.1f);
			for (int j = 1; j < ShapeDatas.Count; j++)
			{
				Vector3Int rotatedBounds2 = GetRotatedBounds(ShapeDatas[j]);
				vector3 = Vector3.Min(vector3, ShapeDatas[j].Position - new Vector3((float)rotatedBounds2.x * 0.5f * 0.1f, 0f, (float)rotatedBounds2.z * 0.5f * 0.1f));
				vector4 = Vector3.Max(vector4, ShapeDatas[j].Position + new Vector3((float)rotatedBounds2.x * 0.5f * 0.1f, (float)rotatedBounds2.y * 0.1f, (float)rotatedBounds2.z * 0.5f * 0.1f));
			}
			Bounds = (vector4 - vector3) / 0.1f;
			Vector3 center = Center;
			Center = vector3 + Bounds * 0.5f * 0.1f;
			Center.y = vector3.y;
			center = Center - center;
			for (int k = 0; k < ShapeDatas.Count; k++)
			{
				PositionedShapeData value = ShapeDatas[k];
				value.Position -= center;
				ShapeDatas[k] = value;
			}
		}
	}

	public void MoveTo(Vector3 pos, Vector3 priorityMoveDir)
	{
		pos = GetSnappedPos(pos);
		foreach (ShapeLoaderSO transparentShape in TransparentShapes)
		{
			Vector3 vector = transparentShape.Position - Center;
			transparentShape.Position = pos + vector;
		}
		foreach (ShapeLoaderSO shape in Shapes)
		{
			Vector3 vector2 = shape.Position - Center;
			shape.Position = pos + vector2;
		}
		Center = pos;
		List<ShapeLoaderSO> shapesToCollideWith = GetShapesToCollideWith();
		List<ShapeLoaderSO> shapes = ((TransparentShapes.Count > 0) ? TransparentShapes : Shapes);
		if (IsAnyShapeOverlappingWithOthers(shapes, shapesToCollideWith))
		{
			MoveShapesToNotOverlap(shapes, shapesToCollideWith, priorityMoveDir);
		}
		MoveBoundsVisualization();
	}

	private void MoveCenter(Vector3 pos)
	{
		foreach (ShapeLoaderSO transparentShape in TransparentShapes)
		{
			Vector3 vector = transparentShape.Position - Center;
			transparentShape.Position = pos + vector;
		}
		foreach (ShapeLoaderSO shape in Shapes)
		{
			Vector3 vector2 = shape.Position - Center;
			shape.Position = pos + vector2;
		}
		Center = pos;
	}

	public Vector3 GetSnappedPos(Vector3 pos)
	{
		Vector3Int vector3Int = new Vector3Int(Mathf.RoundToInt(pos.x / 0.05f), Mathf.RoundToInt(pos.y / 0.1f), Mathf.RoundToInt(pos.z / 0.05f));
		float x = (((Mathf.RoundToInt(Bounds.x) % 2 == 0 && vector3Int.x % 2 == 0) || (Mathf.RoundToInt(Bounds.x) % 2 != 0 && vector3Int.x % 2 != 0)) ? 1 : 0);
		float z = (((Mathf.RoundToInt(Bounds.z) % 2 == 0 && vector3Int.z % 2 == 0) || (Mathf.RoundToInt(Bounds.z) % 2 != 0 && vector3Int.z % 2 != 0)) ? 1 : 0);
		Vector3 vector = vector3Int + new Vector3(x, 0f, z);
		return new Vector3(vector.x * 0.05f, vector.y * 0.1f, vector.z * 0.05f);
	}

	public void VisualizeBounds()
	{
		_isVisualizingBounds = true;
		GameObject gameObject = new GameObject("BlueprintBoundsRenderer")
		{
			layer = LayerMask.NameToLayer("Editor")
		};
		gameObject.transform.position = Center;
		_boundsRenderer = gameObject.AddComponent<LineRenderer>();
		_boundsRenderer.widthMultiplier = 0.02f;
		_boundsRenderer.sharedMaterial = _lineMaterial;
		MoveBoundsVisualization();
	}

	public void StopVisualizingBounds()
	{
		if (_isVisualizingBounds)
		{
			UnityEngine.Object.DestroyImmediate(_boundsRenderer.gameObject);
		}
		_isVisualizingBounds = false;
	}

	private void MoveBoundsVisualization()
	{
		if (_isVisualizingBounds)
		{
			Vector3[] positions = new Vector3[18]
			{
				Center + new Vector3(0f - RealExtents.x, 0f, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, 0f, RealExtents.z),
				Center + new Vector3(RealExtents.x, 0f, RealExtents.z),
				Center + new Vector3(RealExtents.x, 0f, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, 0f, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, RealBounds.y, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, RealBounds.y, RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, 0f, RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, RealBounds.y, RealExtents.z),
				Center + new Vector3(RealExtents.x, RealBounds.y, RealExtents.z),
				Center + new Vector3(RealExtents.x, 0f, RealExtents.z),
				Center + new Vector3(RealExtents.x, RealBounds.y, RealExtents.z),
				Center + new Vector3(RealExtents.x, RealBounds.y, 0f - RealExtents.z),
				Center + new Vector3(RealExtents.x, 0f, 0f - RealExtents.z),
				Center + new Vector3(RealExtents.x, RealBounds.y, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, RealBounds.y, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, 0f, 0f - RealExtents.z),
				Center + new Vector3(0f - RealExtents.x, RealBounds.y, 0f - RealExtents.z)
			};
			_boundsRenderer.positionCount = 18;
			_boundsRenderer.SetPositions(positions);
		}
	}

	public void Dispose()
	{
		StopVisualizingBounds();
		for (int num = TransparentShapes.Count - 1; num >= 0; num--)
		{
			UnityEngine.Object.DestroyImmediate(TransparentShapes[num].gameObject);
		}
		TransparentShapes.Clear();
	}

	public PositionedShapeData[] GetPositionedShapeDatas()
	{
		PositionedShapeData[] array = new PositionedShapeData[ShapeDatas.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ShapeDatas[i];
			array[i].GroupID = (_placeAsGroup ? _groupID : ShapeDatas[i].GroupID);
			array[i].Position = Center + ShapeDatas[i].Position;
		}
		return array;
	}

	public void Rotate(bool inverse = false)
	{
		Vector3 center = Center;
		foreach (ShapeLoaderSO shape in Shapes)
		{
			Vector3 vector = shape.Shape.VoxelPosToWorldPos(Vector3Int.zero) - center;
			Vector3 obj = (inverse ? new Vector3(0f - vector.z, vector.y, vector.x) : new Vector3(vector.z, vector.y, 0f - vector.x));
			shape.RotateShapeY(inverse);
			Vector3 vector2 = shape.Shape.VoxelPosToWorldPos(inverse ? new Vector3Int(shape.Shape.GetBounds().x - 1, 0, 0) : new Vector3Int(0, 0, shape.Shape.GetBounds().z - 1)) - center;
			Vector3 vector3 = obj - vector2;
			shape.Position += vector3;
		}
		for (int i = 0; i < TransparentShapes.Count; i++)
		{
			Vector3 vector4 = TransparentShapes[i].Shape.VoxelPosToWorldPos(Vector3Int.zero) - center;
			Vector3 obj2 = (inverse ? new Vector3(0f - vector4.z, vector4.y, vector4.x) : new Vector3(vector4.z, vector4.y, 0f - vector4.x));
			TransparentShapes[i].RotateShapeY(inverse);
			Vector3 vector5 = TransparentShapes[i].Shape.VoxelPosToWorldPos(inverse ? new Vector3Int(TransparentShapes[i].Shape.GetBounds().x - 1, 0, 0) : new Vector3Int(0, 0, TransparentShapes[i].Shape.GetBounds().z - 1)) - center;
			Vector3 vector6 = (obj2 - vector5) / 0.05f;
			vector6 = new Vector3(Mathf.RoundToInt(vector6.x), Mathf.RoundToInt(vector6.y), Mathf.RoundToInt(vector6.z));
			vector6 *= 0.05f;
			TransparentShapes[i].Position += vector6;
			ShapeDatas[i] = new PositionedShapeData
			{
				GroupID = ShapeDatas[i].GroupID,
				ShapeDataSO = ShapeDatas[i].ShapeDataSO,
				Position = ShapeDatas[i].Position + vector6,
				Rotation = TransparentShapes[i].Rotation
			};
		}
		Bounds = new Vector3(Mathf.RoundToInt(Bounds.z), Mathf.RoundToInt(Bounds.y), Mathf.RoundToInt(Bounds.x));
		MoveBoundsVisualization();
	}

	public void RotateX(bool inverse = false)
	{
		Vector3 center = Center;
		foreach (ShapeLoaderSO shape in Shapes)
		{
			Vector3 vector = shape.Shape.VoxelPosToWorldPos(Vector3Int.zero) - center;
			shape.RotateShapeX(!inverse);
			Vector3Int voxelPos = (inverse ? new Vector3Int(0, 0, shape.Shape.GetBounds().z - 1) : new Vector3Int(0, shape.Shape.GetBounds().y - 1, 0));
			Vector3 vector2 = shape.Shape.VoxelPosToWorldPos(voxelPos) - center;
			Vector3 vector3 = (inverse ? new Vector3(vector.x, vector.z, 0f - vector.y) : new Vector3(vector.x, 0f - vector.z, vector.y)) - vector2;
			Vector3 vector4 = (inverse ? new Vector3(0f, Bounds.z * 0.05f, Bounds.y * 0.05f) : new Vector3(0f, Bounds.z * 0.05f, (0f - Bounds.y) * 0.05f));
			Vector3 vector5 = vector3 + vector4;
			shape.Position += vector5;
		}
		for (int i = 0; i < TransparentShapes.Count; i++)
		{
			Vector3 vector6 = TransparentShapes[i].Shape.VoxelPosToWorldPos(Vector3Int.zero) - center;
			TransparentShapes[i].RotateShapeX(!inverse);
			Vector3Int voxelPos2 = (inverse ? new Vector3Int(0, 0, TransparentShapes[i].Shape.GetBounds().z - 1) : new Vector3Int(0, TransparentShapes[i].Shape.GetBounds().y - 1, 0));
			Vector3 vector7 = TransparentShapes[i].Shape.VoxelPosToWorldPos(voxelPos2) - center;
			Vector3 vector8 = (inverse ? new Vector3(vector6.x, vector6.z, 0f - vector6.y) : new Vector3(vector6.x, 0f - vector6.z, vector6.y)) - vector7;
			Vector3 vector9 = (inverse ? new Vector3(0f, Bounds.z * 0.05f, Bounds.y * 0.05f) : new Vector3(0f, Bounds.z * 0.05f, (0f - Bounds.y) * 0.05f));
			Vector3 vector10 = (vector8 + vector9) / 0.05f;
			vector10 = new Vector3(Mathf.RoundToInt(vector10.x), Mathf.RoundToInt(vector10.y), Mathf.RoundToInt(vector10.z));
			vector10 *= 0.05f;
			TransparentShapes[i].Position += vector10;
			ShapeDatas[i] = new PositionedShapeData
			{
				GroupID = ShapeDatas[i].GroupID,
				ShapeDataSO = ShapeDatas[i].ShapeDataSO,
				Position = ShapeDatas[i].Position + vector10,
				Rotation = TransparentShapes[i].Rotation
			};
		}
		Bounds = new Vector3(Mathf.RoundToInt(Bounds.x), Mathf.RoundToInt(Bounds.z), Mathf.RoundToInt(Bounds.y));
		MoveBoundsVisualization();
	}

	private Vector3Int GetRotatedBounds(PositionedShapeData shapeData)
	{
		Shape shape = Shape.Create(shapeData.ShapeDataSO.Data, Vector3.zero);
		shape.Rotate(shapeData.Rotation);
		return shape.GetBounds();
	}

	public List<ShapeLoaderSO> GetShapesToCollideWith()
	{
		Collider[] array = Physics.OverlapBox(Center + new Vector3(0f, Bounds.y * 0.1f * 0.5f, 0f), 0.05f * (Bounds + Vector3Int.one * 16), Quaternion.identity, LayerMask.GetMask("Editor"));
		List<ShapeLoaderSO> list = new List<ShapeLoaderSO>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].TryGetComponent<ShapeLoaderSO>(out var component) && !Shapes.Contains(component))
			{
				list.Add(component);
			}
		}
		return list;
	}

	private bool IsAnyShapeOverlappingWithOthers(List<ShapeLoaderSO> shapes, List<ShapeLoaderSO> collisionShapes)
	{
		foreach (ShapeLoaderSO shape in shapes)
		{
			foreach (ShapeLoaderSO collisionShape in collisionShapes)
			{
				if (shape.Shape.IsOverlappingWithShape(collisionShape.Shape, out var _))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void MoveShapesToNotOverlap(List<ShapeLoaderSO> shapes, List<ShapeLoaderSO> collisionShapes, Vector3 priorityMoveDir)
	{
		Vector3 center = Center;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 16;
		Vector3 center2;
		int num8;
		if (shapes.Count < 2)
		{
			while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num < num7)
			{
				MoveCenter(Center + priorityMoveDir * 0.1f);
				num++;
			}
			num8 = num - 3;
			center2 = Center;
			MoveCenter(center);
		}
		while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num2 < num7)
		{
			MoveCenter(Center + Vector3.up * 0.1f);
			num2++;
		}
		num8 = num2 - 2;
		center2 = Center;
		MoveCenter(center);
		if (shapes.Count < 2)
		{
			while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num3 < num7)
			{
				MoveCenter(Center + Vector3.right * 0.1f);
				num3++;
			}
			if (num3 < num8)
			{
				num8 = num3;
				center2 = Center;
			}
			MoveCenter(center);
			while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num4 < num7)
			{
				MoveCenter(Center + -Vector3.right * 0.1f);
				num4++;
			}
			if (num4 < num8)
			{
				num8 = num4;
				center2 = Center;
			}
			MoveCenter(center);
			while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num5 < num7)
			{
				MoveCenter(Center + Vector3.forward * 0.1f);
				num5++;
			}
			if (num5 < num8)
			{
				num8 = num5;
				center2 = Center;
			}
			MoveCenter(center);
			while (IsAnyShapeOverlappingWithOthers(shapes, collisionShapes) && num6 < num7)
			{
				MoveCenter(Center + -Vector3.forward * 0.1f);
				num6++;
			}
			if (num6 < num8)
			{
				num8 = num6;
				center2 = Center;
			}
		}
		MoveCenter(center2);
	}

	public void EnableColliders(bool enable = true)
	{
		foreach (ShapeLoaderSO shape in Shapes)
		{
			shape.GetComponent<Collider>().enabled = enable;
		}
	}

	public void SetMaterialsOfShapes(Material mat)
	{
		foreach (ShapeLoaderSO shape in Shapes)
		{
			shape.MeshRenderer.sharedMaterial = mat;
		}
	}

	public DioramaEditorBlueprintSave SaveBlueprint()
	{
		List<PositionedShapeData> list = new List<PositionedShapeData>();
		foreach (PositionedShapeData shapeData in ShapeDatas)
		{
			list.Add(shapeData);
		}
		foreach (ShapeLoaderSO shape in Shapes)
		{
			list.Add(new PositionedShapeData
			{
				ShapeDataSO = shape.ShapeDataSO,
				Position = shape.Position,
				Rotation = shape.Rotation
			});
		}
		return new DioramaEditorBlueprintSave(list);
	}
}
