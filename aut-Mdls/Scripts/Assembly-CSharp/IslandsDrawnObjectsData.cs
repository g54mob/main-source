using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Presentation.Locators;
using UnityEngine;

[CreateAssetMenu(fileName = "IslandsDrawnObjectsData", menuName = "PlaceBrushToolData/IslandsDrawnObjectsData")]
public class IslandsDrawnObjectsData : ScriptableObject
{
	[Serializable]
	public struct DrawnObjectData
	{
		public GameObject PrefabRef;

		public Material Material;

		public Mesh Mesh;

		public int LayerMask;

		public float SpawnChance;

		public Vector3 MinScale;

		public Vector3 MaxScale;
	}

	[SerializeField]
	private IslandLayer _islandLayer;

	[SerializeField]
	private List<DrawnObjectData> _drawnObjectDatas = new List<DrawnObjectData>();

	[SerializeField]
	private GridLocator _gridLocator;

	[SerializeField]
	private int _pointsPerCellDensity = 10;

	[Tooltip("After relaxation, the max spread dilation a grass point can have based of cell size")]
	[SerializeField]
	[Range(0f, 1f)]
	private float _generatedPointsDilation;

	[Tooltip("same as above but for elevated grass tiles")]
	[SerializeField]
	[Range(0f, 1f)]
	private float _heightPointsDilation;

	[Tooltip("when using relaxation, a smaller randomized initial spread might better")]
	[SerializeField]
	[Range(0f, 1f)]
	private float _randomPointsInitialSpread;

	[SerializeField]
	[Range(0f, 10f)]
	private int _pointsRelaxIterations;

	[SerializeField]
	[Range(0f, 5f)]
	private float _pointsRelaxStrength;

	private const float ELEVATED_GRASS_HEIGHT = 6f;

	public void BuildIslandsObjMatrices(IslandInstancedObjectsData instancedObjects, IslandData islandData)
	{
		float x = _gridLocator.GetCellSize().x;
		CreatePerIslandData(instancedObjects);
		List<Vector3> positions = CreateObjPositions(islandData, x);
		CreateObjectsFromPos(positions, x, instancedObjects);
	}

	private void CreatePerIslandData(IslandInstancedObjectsData instancedObjects)
	{
		List<ObjectsAndMatricesData> list = new List<ObjectsAndMatricesData>();
		int num = _islandLayer.GetAllIslands().Count * 10;
		int num2 = 0;
		foreach (DrawnObjectData drawnObjectData in _drawnObjectDatas)
		{
			ObjectsAndMatricesData objectsAndMatricesData = new ObjectsAndMatricesData(drawnObjectData.PrefabRef, drawnObjectData.Material, drawnObjectData.Mesh, drawnObjectData.LayerMask, num + num2++);
			objectsAndMatricesData.TransformMatrices = new List<Matrix4x4>();
			list.Add(objectsAndMatricesData);
		}
		instancedObjects.SetObjectsData(list);
	}

	private static List<Vector3> CreateObjPositions(IslandData data, float cellSize)
	{
		List<Vector3> list = new List<Vector3>();
		Color32[] pixels = data.Texture2D.GetPixels32();
		Vector3 vector = new Vector3(cellSize / 2f, 0f, cellSize / 2f);
		for (int i = 0; i < data.Size.x; i++)
		{
			for (int j = 0; j < data.Size.x; j++)
			{
				if (EnvironmentColorIDs.IsGrass(pixels[i + j * data.Size.x]))
				{
					Vector3 vector2 = new Vector3((float)i * cellSize, 0f, (float)j * cellSize);
					Vector3 vector3 = new Vector3((float)(data.Size.x / 2) * cellSize, 0f, (float)(data.Size.x / 2) * cellSize);
					Vector3 vector4 = data.Position - vector3 + (vector2 + vector);
					if (EnvironmentColorIDs.IsElevatedGrass(pixels[i + j * data.Size.x]))
					{
						vector4.y = 6f;
					}
					Vector3 vector5 = vector4 - data.Position;
					Vector3 item = Quaternion.Euler(0f, data.Rotation, 0f) * vector5;
					item += (Vector3)data.Position;
					list.Add(item);
				}
			}
		}
		return list;
	}

	private void CreateObjectsFromPos(List<Vector3> positions, float cellSize, IslandInstancedObjectsData instancedObjects)
	{
		foreach (Vector3 position in positions)
		{
			List<Vector3> list = GenerateRandomPoints(position, cellSize);
			RelaxPoints(list, position, cellSize);
			FillTransformMatrices(list, instancedObjects);
		}
	}

	private void FillTransformMatrices(List<Vector3> rndPositions, IslandInstancedObjectsData instancedObjects)
	{
		foreach (Vector3 rndPosition in rndPositions)
		{
			int randomIndex = GetRandomIndex();
			GetRandomMatrice(randomIndex, rndPosition, out var mat);
			instancedObjects.ObjectsAndMatrices[randomIndex].TransformMatrices.Add(mat);
		}
	}

	private void GetRandomMatrice(int rndIndex, Vector3 rndPos, out Matrix4x4 mat)
	{
		Vector3 randomScale = GetRandomScale(rndIndex);
		Quaternion q = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up);
		mat = Matrix4x4.TRS(rndPos, q, randomScale);
	}

	private Vector3 GetRandomScale(int rndIndex)
	{
		Vector3 minScale = _drawnObjectDatas[rndIndex].MinScale;
		Vector3 maxScale = _drawnObjectDatas[rndIndex].MaxScale;
		return new Vector3(UnityEngine.Random.Range(minScale.x, maxScale.x), UnityEngine.Random.Range(minScale.y, maxScale.y), UnityEngine.Random.Range(minScale.z, maxScale.z));
	}

	private int GetRandomIndex()
	{
		int num = 0;
		float num2 = 0f;
		float value = UnityEngine.Random.value;
		for (int i = 0; i < _drawnObjectDatas.Count; i++)
		{
			num2 += _drawnObjectDatas[i].SpawnChance;
			if (value <= num2)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private List<Vector3> GenerateRandomPoints(Vector3 center, float size)
	{
		List<Vector3> list = new List<Vector3>();
		float num = size / 2f * _randomPointsInitialSpread;
		for (int i = 0; i < _pointsPerCellDensity; i++)
		{
			float x = UnityEngine.Random.Range(0f - num, num);
			float z = UnityEngine.Random.Range(0f - num, num);
			list.Add(center + new Vector3(x, 0f, z));
		}
		return list;
	}

	private void RelaxPoints(List<Vector3> points, Vector3 center, float size)
	{
		float num = size / 2f;
		float num2 = num * _generatedPointsDilation;
		if (center.y == 6f)
		{
			num2 = num * _heightPointsDilation;
		}
		for (int i = 0; i < _pointsRelaxIterations; i++)
		{
			Vector3[] array = new Vector3[points.Count];
			for (int j = 0; j < points.Count; j++)
			{
				Vector3 zero = Vector3.zero;
				for (int k = 0; k < points.Count; k++)
				{
					if (j != k)
					{
						Vector3 vector = points[j] - points[k];
						float num3 = vector.magnitude + 0.001f;
						zero += vector.normalized / num3;
					}
				}
				array[j] = zero * _pointsRelaxStrength;
			}
			for (int l = 0; l < points.Count; l++)
			{
				points[l] += array[l];
				points[l] = new Vector3(Mathf.Clamp(points[l].x, center.x - num2, center.x + num2), points[l].y, Mathf.Clamp(points[l].z, center.z - num2, center.z + num2));
			}
		}
	}

	public void GenerateObjectsFrom(FactoryObject factoryObject, IslandInstancedObjectsData instancedObjects)
	{
		if (!instancedObjects.FacObjGrassRefs.ContainsKey(factoryObject))
		{
			instancedObjects.FacObjGrassRefs.Add(factoryObject, new Dictionary<ObjectsAndMatricesData, List<Matrix4x4>>());
		}
		foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
		{
			float x = _gridLocator.GetCellSize().x;
			Vector3 center = occupiedPosition + new Vector3(x / 2f, 0f, x / 2f);
			List<Vector3> list = GenerateRandomPoints(center, x);
			RelaxPoints(list, center, x);
			foreach (Vector3 item in list)
			{
				int randomIndex = GetRandomIndex();
				GetRandomMatrice(randomIndex, item, out var mat);
				instancedObjects.GrassOperatorsObjsAndMats[randomIndex].TransformMatrices.Add(mat);
				if (!instancedObjects.FacObjGrassRefs[factoryObject].ContainsKey(instancedObjects.GrassOperatorsObjsAndMats[randomIndex]))
				{
					instancedObjects.FacObjGrassRefs[factoryObject].Add(instancedObjects.GrassOperatorsObjsAndMats[randomIndex], new List<Matrix4x4>());
				}
				instancedObjects.FacObjGrassRefs[factoryObject][instancedObjects.GrassOperatorsObjsAndMats[randomIndex]].Add(mat);
			}
		}
	}

	public void RemoveObjectsFrom(FactoryObject factoryObject, IslandInstancedObjectsData instancedObjects)
	{
		foreach (KeyValuePair<ObjectsAndMatricesData, List<Matrix4x4>> item in instancedObjects.FacObjGrassRefs[factoryObject])
		{
			foreach (ObjectsAndMatricesData grassOperatorsObjsAndMat in instancedObjects.GrassOperatorsObjsAndMats)
			{
				if (!(item.Key.PrefabRef == grassOperatorsObjsAndMat.PrefabRef))
				{
					continue;
				}
				foreach (Matrix4x4 item2 in item.Value)
				{
					grassOperatorsObjsAndMat.TransformMatrices.Remove(item2);
				}
				break;
			}
		}
		instancedObjects.FacObjGrassRefs.Remove(factoryObject);
	}
}
