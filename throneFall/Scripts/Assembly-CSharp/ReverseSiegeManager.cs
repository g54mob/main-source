using System.Collections.Generic;
using UnityEngine;

public class ReverseSiegeManager : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private GameObject uphillBlocker;

	[SerializeField]
	private List<GameObject> enemyBaseSetups;

	private Vector3 playerStartPos;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		uphillBlocker.SetActive(value: true);
		playerStartPos = PlayerMovement.instance.transform.position;
		foreach (GameObject enemyBaseSetup in enemyBaseSetups)
		{
			enemyBaseSetup.SetActive(value: false);
		}
	}

	public void OnDawn_BeforeSunrise()
	{
		foreach (GameObject enemyBaseSetup in enemyBaseSetups)
		{
			enemyBaseSetup.SetActive(value: false);
		}
	}

	public void OnDawn_AfterSunrise()
	{
		uphillBlocker.SetActive(value: true);
		PlayerMovement.instance.TeleportTo(playerStartPos);
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.PlayerUnit);
		foreach (TaggedObject item in list)
		{
			PathfindMovementPlayerunit component = item.GetComponent<PathfindMovementPlayerunit>();
			component.transform.position = component.HomePositionOriginal;
			component.HomePosition = component.HomePositionOriginal;
			component.HoldPosition = false;
		}
	}

	public void OnDusk()
	{
		uphillBlocker.SetActive(value: false);
	}

	public void OnDuskEarly()
	{
	}
}
