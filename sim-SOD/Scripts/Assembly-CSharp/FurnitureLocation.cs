using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FurnitureLocation
{
	public struct OwnerKey
	{
		public Human human;

		public NewAddress address;

		public OwnerKey(Human newHuman)
		{
			human = null;
			address = null;
		}

		public OwnerKey(NewAddress newAddress)
		{
			human = null;
			address = null;
		}
	}

	public int id;

	public List<FurnitureClass> furnitureClasses;

	public int angle;

	public Vector3 offset;

	public NewNode anchorNode;

	public List<NewNode> coversNodes;

	public FurnitureClusterLocation cluster;

	public bool useFOVBLock;

	public Vector2 fovDirection;

	public int fovMaxDistance;

	public Vector3 scaleMultiplier;

	public List<Interactable.UsagePoint> usage;

	public Dictionary<NewNode, List<Vector3>> sublocations;

	public FurniturePreset furniture;

	public GameObject spawnedObject;

	public List<MeshRenderer> meshes;

	public bool pickedMaterials;

	public bool createdInteractables;

	public bool pickedOwners;

	public bool pickedArt;

	public bool userPlaced;

	public int diagonalAngle;

	public Toolbox.MaterialKey matKey;

	public List<Interactable> integratedInteractables;

	public int integratedIDAssign;

	public List<Interactable> spawnedInteractables;

	public ArtPreset art;

	public Toolbox.MaterialKey artMatKey;

	public List<int> loadOwners;

	public Dictionary<OwnerKey, int> ownerMap;

	public List<MonoBehaviour> debugOwners;

	public FurnitureLocation(List<FurnitureClass> newClasses, int newAngle, NewNode newAnchor, List<NewNode> newCoversNodes, bool newUseFOVBlock = false, Vector2 newFovDirection = default(Vector2), int newFOVBlockMax = 5, Vector3 newScale = default(Vector3), bool newUserPlaced = false, Vector3 newOffset = default(Vector3))
	{
	}

	public void AssignID(NewRoom fromRoom)
	{
	}

	public FurnitureLocation(FurnitureClusterLocation newCluster, List<FurnitureClass> newClasses, int newAngle, NewNode newAnchor, List<NewNode> newCoversNodes, bool newUseFOVBlock = false, Vector2 newFovDirection = default(Vector2), int newFOVBlockMax = 5, Vector3 newScale = default(Vector3), bool newUserPlaced = false, Vector3 newOffset = default(Vector3))
	{
	}

	public FurnitureLocation(int loadID, FurnitureClusterLocation newCluster, List<FurnitureClass> newClasses, int newAngle, NewNode newAnchor, List<NewNode> newCoversNodes, bool newUseFOVBlock = false, Vector2 newFovDirection = default(Vector2), int newFOVBlockMax = 5, Vector3 newScale = default(Vector3), bool newUserPlaced = false, Vector3 newOffset = default(Vector3))
	{
	}

	public void RaiseLightswitch()
	{
	}

	private void DiagonalRotation()
	{
	}

	public void SpawnObject(bool forceSpawnImmediate = false)
	{
	}

	public void DespawnObject()
	{
	}

	public void Delete(bool removeIntegratedInteractables, FurnitureClusterLocation.RemoveInteractablesOption removeSpawnedInteractables)
	{
	}

	public void RemoveSpawnedInteractables()
	{
	}

	public void RemoveIntegratedInteractables()
	{
	}

	public void CreateInteractables()
	{
	}

	public void AssignOwner(Human newOwner, bool updateIntegratedObjectOwnership)
	{
	}

	public void AssignOwner(NewAddress newOwner, bool updateIntegratedObjectOwnership)
	{
	}

	public void UpdateIntegratedObjectOwnership()
	{
	}

	public Vector3 GetWorldAveragePosition()
	{
		return default(Vector3);
	}

	public void CalculateWalkableSublocations()
	{
	}

	public Vector3 GetSubObjectLocalPosition(FurniturePreset.SubObject subObj)
	{
		return default(Vector3);
	}

	public Vector3 GetSubObjectLocalEuler(FurniturePreset.SubObject subObj)
	{
		return default(Vector3);
	}
}
