using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
	public enum Mode
	{
		Door = 0,
		Bars = 1
	}

	public float openDistance = 5f;

	public float clearDistance = 10f;

	public Mode mode;

	public Transform doorL;

	public Transform doorR;

	public float maxAngle;

	public Transform bars;

	public Vector3 openPositionOffset = new Vector3(0f, -3.6f, 0f);

	public float animationTime = 1f;

	private bool open;

	private List<TagManager.ETag> tagList = new List<TagManager.ETag>(new TagManager.ETag[2]
	{
		TagManager.ETag.Player,
		TagManager.ETag.PlayerUnit
	});

	private float openAnimationClock;

	private IReadOnlyList<TaggedObject> playerUnits;

	private IReadOnlyList<TaggedObject> players;

	private Vector3 doorLInitRotation;

	private Vector3 doorRInitRotation;

	private Vector3 barsInitPosition;

	private bool isDoor => mode == Mode.Door;

	private bool isBars => mode == Mode.Bars;

	private void Start()
	{
		if ((bool)doorL)
		{
			doorLInitRotation = doorL.rotation.eulerAngles;
		}
		if ((bool)doorR)
		{
			doorRInitRotation = doorR.rotation.eulerAngles;
		}
		if ((bool)bars)
		{
			barsInitPosition = bars.transform.position;
		}
		if (!TagManager.instance)
		{
			Debug.LogError("No Tag Manager in scene.");
			return;
		}
		playerUnits = TagManager.instance.PlayerUnits;
		players = TagManager.instance.Players;
	}

	private void Update()
	{
		if (!TagManager.instance)
		{
			return;
		}
		if (open)
		{
			bool flag = true;
			foreach (TaggedObject playerUnit in TagManager.instance.PlayerUnits)
			{
				if (playerUnit.gameObject.activeInHierarchy && Vector3.Distance(base.transform.position, playerUnit.transform.position) <= clearDistance && playerUnit.Tags.Contains(TagManager.ETag.AUTO_Alive) && !(Vector3.Distance(playerUnit.transform.position, playerUnit.GetComponent<PathfindMovementPlayerunit>().HomePosition) < 0.5f))
				{
					flag = false;
					break;
				}
			}
			foreach (TaggedObject player in players)
			{
				if (player.gameObject.activeInHierarchy && Vector3.Distance(base.transform.position, player.transform.position) <= openDistance && player.Tags.Contains(TagManager.ETag.AUTO_Alive))
				{
					flag = false;
				}
			}
			if (flag)
			{
				Close();
			}
		}
		else
		{
			foreach (TaggedObject playerUnit2 in playerUnits)
			{
				if (playerUnit2.gameObject.activeInHierarchy && Vector3.Distance(base.transform.position, playerUnit2.transform.position) <= openDistance && playerUnit2.Tags.Contains(TagManager.ETag.AUTO_Alive) && !(Vector3.Distance(playerUnit2.transform.position, playerUnit2.GetComponent<PathfindMovementPlayerunit>().HomePosition) < 0.5f))
				{
					Open();
					return;
				}
			}
			foreach (TaggedObject player2 in players)
			{
				if (player2.gameObject.activeInHierarchy && Vector3.Distance(base.transform.position, player2.transform.position) <= openDistance && player2.Tags.Contains(TagManager.ETag.AUTO_Alive))
				{
					Open();
				}
			}
		}
		if (open && openAnimationClock < animationTime)
		{
			openAnimationClock += Time.deltaTime;
			if (openAnimationClock > animationTime)
			{
				openAnimationClock = animationTime;
			}
		}
		else if (!open && openAnimationClock > 0f)
		{
			openAnimationClock -= Time.deltaTime;
			if (openAnimationClock < 0f)
			{
				openAnimationClock = 0f;
			}
		}
		switch (mode)
		{
		case Mode.Door:
		{
			float num = Mathf.SmoothStep(0f, maxAngle, openAnimationClock / animationTime);
			doorL.rotation = Quaternion.Euler(doorLInitRotation + Vector3.forward * num);
			doorR.rotation = Quaternion.Euler(doorRInitRotation + Vector3.forward * (0f - num));
			break;
		}
		case Mode.Bars:
			bars.transform.position = Vector3.Slerp(barsInitPosition, barsInitPosition + openPositionOffset, openAnimationClock / animationTime);
			break;
		}
	}

	private void Close()
	{
		open = false;
	}

	private void Open()
	{
		open = true;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, openDistance);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, clearDistance);
	}
}
