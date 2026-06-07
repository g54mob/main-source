using UnityEngine;

public class CorruptedKingSpawnHelper : MonoBehaviour
{
	public GameObject meshParent;

	public Cloth cloth;

	public float meshHide = 3f;

	public float movementFreeze = 3f;

	public float jumpFreeze = 6f;

	private UnitDashJumpEnemy jumper;

	private PathfindMovementEnemy pathing;

	private float defaultMovementSpeed;

	private float clock;

	private bool movementActive;

	private bool jumpingActive;

	private bool meshActive;

	private void Start()
	{
		jumper = GetComponent<UnitDashJumpEnemy>();
		pathing = GetComponent<PathfindMovementEnemy>();
		defaultMovementSpeed = pathing.movementSpeed;
		jumper.enabled = false;
		pathing.movementSpeed = 0f;
		meshParent.SetActive(value: false);
		if ((bool)cloth)
		{
			cloth.enabled = false;
		}
	}

	private void Update()
	{
		clock += Time.deltaTime;
		if (clock > movementFreeze && !movementActive)
		{
			movementActive = true;
			pathing.movementSpeed = defaultMovementSpeed;
		}
		if (clock > jumpFreeze && !jumpingActive)
		{
			jumpingActive = true;
			jumper.enabled = true;
		}
		if (clock > meshHide && !meshActive)
		{
			meshActive = true;
			meshParent.SetActive(value: true);
			if ((bool)cloth)
			{
				cloth.enabled = true;
			}
		}
		if (jumpingActive && movementActive && meshActive)
		{
			Object.Destroy(this);
		}
	}
}
