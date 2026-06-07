using System.Collections.Generic;
using Data.FactoryFloor;
using UnityEngine;

[CreateAssetMenu(fileName = "IslandInstancedObjectsData", menuName = "PlaceBrushToolData/IslandInstancedObjectsData")]
public class IslandInstancedObjectsData : ScriptableObject
{
	[SerializeField]
	private List<ObjectsAndMatricesData> _objectsAndMatrices = new List<ObjectsAndMatricesData>();

	[HideInInspector]
	public List<ObjectsAndMatricesData> GrassOperatorsObjsAndMats;

	[HideInInspector]
	public Dictionary<FactoryObject, Dictionary<ObjectsAndMatricesData, List<Matrix4x4>>> FacObjGrassRefs = new Dictionary<FactoryObject, Dictionary<ObjectsAndMatricesData, List<Matrix4x4>>>();

	public List<ObjectsAndMatricesData> ObjectsAndMatrices => _objectsAndMatrices;

	public void SetObjectsData(List<ObjectsAndMatricesData> buildIslandsObjMatrices)
	{
		_objectsAndMatrices.Clear();
		foreach (ObjectsAndMatricesData buildIslandsObjMatrix in buildIslandsObjMatrices)
		{
			_objectsAndMatrices.Add(buildIslandsObjMatrix);
		}
		GrassOperatorsObjsAndMats = new List<ObjectsAndMatricesData>();
		foreach (ObjectsAndMatricesData buildIslandsObjMatrix2 in buildIslandsObjMatrices)
		{
			ObjectsAndMatricesData item = new ObjectsAndMatricesData(buildIslandsObjMatrix2, buildIslandsObjMatrix2.ID + 10000);
			GrassOperatorsObjsAndMats.Add(item);
		}
	}
}
