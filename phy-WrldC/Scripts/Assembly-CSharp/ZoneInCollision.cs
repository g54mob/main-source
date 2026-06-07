using System.Collections.Generic;
using UnityEngine;

public class ZoneInCollision : MonoBehaviour
{
	[SerializeField]
	private Renderer targetRenderer;

	[SerializeField]
	private Material withoutCollisionMaterial;

	[SerializeField]
	private Material withCollisionMaterial;

	[SerializeField]
	private List<GameObject> objectsInCollisionList;

	public int ObjectsInCollisionCounter { get; private set; }

	private void Awake()
	{
		if (targetRenderer == null)
		{
			targetRenderer = GetComponentInParent<Renderer>();
		}
		objectsInCollisionList = new List<GameObject>();
		ObjectsInCollisionCounter = 0;
	}

	private void Start()
	{
		ResetStatus();
	}

	private void Update()
	{
		for (int i = 0; i < objectsInCollisionList.Count; i++)
		{
			if (objectsInCollisionList[i] == null || !objectsInCollisionList[i].activeSelf)
			{
				ResetStatus();
				break;
			}
		}
		if (ObjectsInCollisionCounter > 0)
		{
			if (targetRenderer.sharedMaterial != withCollisionMaterial)
			{
				targetRenderer.sharedMaterial = withCollisionMaterial;
			}
		}
		else if (targetRenderer.sharedMaterial != withoutCollisionMaterial)
		{
			targetRenderer.sharedMaterial = withoutCollisionMaterial;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("LevelEditor") && !(base.transform.parent.gameObject == other.gameObject) && !objectsInCollisionList.Contains(other.gameObject))
		{
			ObjectsInCollisionCounter++;
			objectsInCollisionList.Add(other.gameObject);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("LevelEditor") && !(base.transform.parent.gameObject == other.gameObject) && !objectsInCollisionList.Contains(other.gameObject))
		{
			ObjectsInCollisionCounter++;
			objectsInCollisionList.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("LevelEditor") && !(base.transform.parent.gameObject == other.gameObject) && objectsInCollisionList.Contains(other.gameObject))
		{
			ObjectsInCollisionCounter--;
			objectsInCollisionList.Remove(other.gameObject);
		}
	}

	public void ResetStatus()
	{
		ObjectsInCollisionCounter = 0;
		objectsInCollisionList.Clear();
	}
}
