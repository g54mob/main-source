using System.Collections.Generic;
using UnityEngine;

public class ObjectsInCollision : MonoBehaviour
{
	public List<GameObject> blockObjectsInCollision;

	public List<GameObject> levelObjectsInCollision;

	public int level;

	public int block;

	public int outsideConstructionZoneCounter;

	private TwoPointBlock twoPointBlock;

	public BodySchematic BodySchematic { get; set; }

	public int LevelObjectsCounter { get; private set; }

	public int BlockObjectsCounter { get; private set; }

	public bool IsInsideConstructionZone { get; private set; }

	private void Awake()
	{
		blockObjectsInCollision = new List<GameObject>();
		levelObjectsInCollision = new List<GameObject>();
	}

	private void Start()
	{
		ResetStatus();
	}

	private void Update()
	{
		level = LevelObjectsCounter;
		block = BlockObjectsCounter;
	}

	private void OnTriggerEnter(Collider colliderInfo)
	{
		if (colliderInfo.CompareTag("Level") && !levelObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			LevelObjectsCounter++;
			levelObjectsInCollision.Add(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("Block") && !blockObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			BlockObjectsCounter++;
			blockObjectsInCollision.Add(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("ConstructionZoneIn"))
		{
			IsInsideConstructionZone = outsideConstructionZoneCounter == 0;
		}
		if (colliderInfo.CompareTag("ConstructionZoneOut"))
		{
			outsideConstructionZoneCounter++;
		}
	}

	private void OnTriggerStay(Collider colliderInfo)
	{
		if (colliderInfo.CompareTag("Level") && !levelObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			LevelObjectsCounter++;
			levelObjectsInCollision.Add(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("Block") && !blockObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			BlockObjectsCounter++;
			blockObjectsInCollision.Add(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("ConstructionZoneIn"))
		{
			IsInsideConstructionZone = outsideConstructionZoneCounter == 0;
		}
	}

	private void OnTriggerExit(Collider colliderInfo)
	{
		if (colliderInfo.CompareTag("Level") && levelObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			LevelObjectsCounter--;
			levelObjectsInCollision.Remove(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("Block") && blockObjectsInCollision.Contains(colliderInfo.gameObject))
		{
			BlockObjectsCounter--;
			blockObjectsInCollision.Remove(colliderInfo.gameObject);
		}
		if (colliderInfo.CompareTag("ConstructionZoneIn"))
		{
			IsInsideConstructionZone = false;
		}
		if (colliderInfo.CompareTag("ConstructionZoneOut"))
		{
			outsideConstructionZoneCounter--;
		}
	}

	public void ResetStatus()
	{
		LevelObjectsCounter = 0;
		BlockObjectsCounter = 0;
		IsInsideConstructionZone = false;
		outsideConstructionZoneCounter = 0;
		levelObjectsInCollision.Clear();
		blockObjectsInCollision.Clear();
	}

	public void RefreshForTwoPointBlock(Vector3 endPosition, Quaternion endRotation)
	{
		if (twoPointBlock == null)
		{
			twoPointBlock = base.gameObject.AddComponent<TwoPointBlock>();
		}
		twoPointBlock.Place = TwoPointBlock.PlaceEnum.PlaceholderCollider;
		twoPointBlock.endPointPosition = endPosition;
		twoPointBlock.endPointRotation = endRotation;
		twoPointBlock.MakeMesh();
	}
}
