using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGrassScatterer : MonoBehaviour
{
	[Serializable]
	public class GrassType
	{
		public GameObject prefab;

		public int density = 100;

		public float minScale = 0.8f;

		public float maxScale = 1.2f;

		public float randomRotationRange = 180f;
	}

	[SerializeField]
	private Terrain targetTerrain;

	[SerializeField]
	private Transform grassContainer;

	[SerializeField]
	private List<GrassType> grassTypes = new List<GrassType>();

	[SerializeField]
	private float minDistanceBetweenGrass = 0.5f;

	[SerializeField]
	private float raycastHeight = 100f;

	private void ScatterGrass()
	{
		if (targetTerrain == null)
		{
			targetTerrain = GetComponent<Terrain>();
			if (targetTerrain == null)
			{
				Debug.LogError("No terrain found!");
				return;
			}
		}
		ClearExistingGrass();
		if (grassContainer == null)
		{
			GameObject gameObject = new GameObject("Grass Container");
			gameObject.transform.parent = base.transform;
			grassContainer = gameObject.transform;
		}
		foreach (GrassType grassType in grassTypes)
		{
			if (!(grassType.prefab == null))
			{
				PlaceGrassType(grassType);
			}
		}
	}

	private void ClearExistingGrass()
	{
		if (grassContainer != null)
		{
			UnityEngine.Object.DestroyImmediate(grassContainer.gameObject);
		}
	}

	private void PlaceGrassType(GrassType grassType)
	{
		Vector3 position = grassContainer.transform.position;
		Vector3 size = targetTerrain.terrainData.size;
		int num = 0;
		int num2 = grassType.density * 3;
		int num3 = 0;
		while (num < grassType.density && num3 < num2)
		{
			num3++;
			float num4 = UnityEngine.Random.Range(0f, size.x);
			float num5 = UnityEngine.Random.Range(0f, size.z);
			if (Physics.Raycast(new Vector3(position.x + num4, position.y + raycastHeight, position.z + num5), Vector3.down, out var hitInfo, raycastHeight * 2f))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(grassType.prefab, hitInfo.point, Quaternion.identity, grassContainer);
				float y = UnityEngine.Random.Range(0f - grassType.randomRotationRange, grassType.randomRotationRange);
				gameObject.transform.rotation = Quaternion.Euler(0f, y, 0f);
				float num6 = UnityEngine.Random.Range(grassType.minScale, grassType.maxScale);
				gameObject.transform.localScale = Vector3.one * num6;
				AlignToNormal(gameObject.transform, hitInfo.normal);
				num++;
			}
		}
		Debug.Log($"Placed {num} of {grassType.prefab.name}");
	}

	private void AlignToNormal(Transform obj, Vector3 normal)
	{
		Vector3 vector = Vector3.Cross(obj.transform.right, normal);
		if (vector != Vector3.zero)
		{
			obj.transform.rotation = Quaternion.LookRotation(vector, normal);
			obj.transform.Rotate(0f, UnityEngine.Random.Range(0, 360), 0f, Space.Self);
		}
	}

	private void AutoFindTerrain()
	{
		targetTerrain = GetComponent<Terrain>();
		if (targetTerrain == null)
		{
			targetTerrain = UnityEngine.Object.FindObjectOfType<Terrain>();
		}
	}
}
