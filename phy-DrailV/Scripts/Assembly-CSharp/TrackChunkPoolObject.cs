using System.Collections.Generic;
using UnityEngine;

public class TrackChunkPoolObject
{
	private const string GAMEOBJECT_NAME = "TrackChunkPoolObject";

	public GameObject gameObject;

	public Mesh mesh;

	public MeshFilter meshFilter;

	public MeshRenderer meshRenderer;

	private static Queue<TrackChunkPoolObject> freePoolObjects = new Queue<TrackChunkPoolObject>();

	private static Transform poolStorageParent;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		freePoolObjects.Clear();
		poolStorageParent = null;
	}

	public TrackChunkPoolObject()
	{
		gameObject = new GameObject("TrackChunkPoolObject");
		meshFilter = gameObject.AddComponent<MeshFilter>();
		mesh = new Mesh();
		meshFilter.sharedMesh = mesh;
		meshRenderer = gameObject.AddComponent<MeshRenderer>();
	}

	public void SetMaterial(Material mat)
	{
		meshRenderer.sharedMaterial = mat;
	}

	public void ReturnToPool()
	{
		gameObject.transform.SetParent(GetPoolParent());
		mesh.Clear();
		freePoolObjects.Enqueue(this);
	}

	public static Transform GetPoolParent()
	{
		if (!poolStorageParent)
		{
			GameObject obj = new GameObject("TrackChunkPoolObject pool");
			obj.SetActive(value: false);
			poolStorageParent = obj.transform;
			freePoolObjects.Clear();
		}
		return poolStorageParent;
	}

	public static TrackChunkPoolObject TakeFromPool(Transform parentTo, Vector3 position)
	{
		GetPoolParent();
		TrackChunkPoolObject trackChunkPoolObject;
		if (freePoolObjects.Count == 0)
		{
			trackChunkPoolObject = new TrackChunkPoolObject();
		}
		else
		{
			trackChunkPoolObject = freePoolObjects.Dequeue();
			trackChunkPoolObject.gameObject.SetActive(value: true);
		}
		trackChunkPoolObject.gameObject.transform.SetParent(parentTo);
		trackChunkPoolObject.gameObject.transform.localPosition = position;
		return trackChunkPoolObject;
	}
}
