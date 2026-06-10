using DG.Tweening;
using UnityEngine;

public class RailCartMover : MonoBehaviour
{
	private enum Dir
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	[Header("Waypoints")]
	[Tooltip("Ordered list of waypoints the cart follows")]
	public Transform[] waypoints;

	[Header("Speed")]
	public float speed = 2f;

	[Tooltip("Speed multiplier at the slowest point of a turn")]
	[Range(0.1f, 1f)]
	public float turnSpeedMultiplier = 0.65f;

	[Tooltip("How far from a turn to start slowing down")]
	public float turnEaseDistance = 0.8f;

	[Header("Straight Sprites")]
	public Sprite spriteHorizontal;

	public Sprite spriteVertical;

	[Header("Turn Sprites (45 deg diagonal, one for each corner)")]
	public Sprite turnUpRight;

	public Sprite turnUpLeft;

	public Sprite turnDownRight;

	public Sprite turnDownLeft;

	[Header("Options")]
	public bool loop = true;

	[Tooltip("How far from a turn corner before switching to the straight sprite")]
	public float turnRadius = 0.3f;

	[Header("Bobbing")]
	[Tooltip("How far the cart bobs up and down")]
	public float bobAmount = 0.04f;

	[Tooltip("Duration of one bob (up or down)")]
	public float bobDuration = 0.18f;

	private SpriteRenderer spriteRenderer;

	private int currentWaypointIndex;

	private bool moving = true;

	private bool inTurn;

	private Vector3 turnPosition;

	private Dir outgoingDirAfterTurn;

	private Vector3 pathPosition;

	private float bobOffset;

	private Tweener bobTween;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnEnable()
	{
		if (waypoints != null && waypoints.Length >= 2)
		{
			pathPosition = waypoints[0].position;
			base.transform.position = pathPosition;
			currentWaypointIndex = 1;
			moving = true;
			inTurn = false;
			SetStraightSprite(waypoints[1].position - waypoints[0].position);
			StartBobbing();
		}
	}

	private void OnDisable()
	{
		bobTween?.Kill();
		bobTween = null;
		bobOffset = 0f;
	}

	private void StartBobbing()
	{
		bobTween?.Kill();
		bobOffset = 0f;
		bobTween = DOTween.To(() => bobOffset, delegate(float x)
		{
			bobOffset = x;
		}, bobAmount, bobDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
	}

	private void Update()
	{
		if (!moving || waypoints == null || waypoints.Length < 2)
		{
			return;
		}
		if (inTurn && Vector3.Distance(pathPosition, turnPosition) >= turnRadius)
		{
			inTurn = false;
			SetStraightSpriteFromDir(outgoingDirAfterTurn);
		}
		float num = CalculateSpeed();
		Transform transform = waypoints[currentWaypointIndex];
		Vector3 vector = transform.position - pathPosition;
		float num2 = num * Time.deltaTime;
		if (vector.magnitude <= num2)
		{
			pathPosition = transform.position;
			int num3 = currentWaypointIndex - 1;
			if (num3 < 0)
			{
				num3 = (loop ? (waypoints.Length - 1) : 0);
			}
			currentWaypointIndex++;
			if (currentWaypointIndex >= waypoints.Length)
			{
				if (!loop)
				{
					moving = false;
					base.transform.position = pathPosition + new Vector3(0f, bobOffset, 0f);
					return;
				}
				currentWaypointIndex = 0;
			}
			Vector3 dir = transform.position - waypoints[num3].position;
			Vector3 vector2 = waypoints[currentWaypointIndex].position - transform.position;
			Dir cardinalDir = GetCardinalDir(dir);
			Dir cardinalDir2 = GetCardinalDir(vector2);
			if (cardinalDir != cardinalDir2)
			{
				SetTurnSprite(cardinalDir, cardinalDir2);
				inTurn = true;
				turnPosition = transform.position;
				outgoingDirAfterTurn = cardinalDir2;
			}
			else
			{
				inTurn = false;
				SetStraightSprite(vector2);
			}
		}
		else
		{
			pathPosition += vector.normalized * num2;
		}
		base.transform.position = pathPosition + new Vector3(0f, bobOffset, 0f);
	}

	private float CalculateSpeed()
	{
		float num = Vector3.Distance(pathPosition, waypoints[currentWaypointIndex].position);
		int num2 = currentWaypointIndex + 1;
		if (num2 >= waypoints.Length)
		{
			num2 = ((!loop) ? (waypoints.Length - 1) : 0);
		}
		Vector3 dir = waypoints[currentWaypointIndex].position - pathPosition;
		Vector3 dir2 = waypoints[num2].position - waypoints[currentWaypointIndex].position;
		bool num3 = GetCardinalDir(dir) != GetCardinalDir(dir2);
		float num4 = 1f;
		if (num3 && num < turnEaseDistance)
		{
			float t = num / turnEaseDistance;
			num4 = Mathf.Lerp(turnSpeedMultiplier, 1f, t);
		}
		if (inTurn)
		{
			float num5 = Vector3.Distance(pathPosition, turnPosition);
			if (num5 < turnEaseDistance)
			{
				float t2 = num5 / turnEaseDistance;
				float b = Mathf.Lerp(turnSpeedMultiplier, 1f, t2);
				num4 = Mathf.Min(num4, b);
			}
		}
		return speed * num4;
	}

	private Dir GetCardinalDir(Vector3 dir)
	{
		if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
		{
			if (!(dir.x > 0f))
			{
				return Dir.Left;
			}
			return Dir.Right;
		}
		if (!(dir.y > 0f))
		{
			return Dir.Down;
		}
		return Dir.Up;
	}

	private void SetStraightSprite(Vector3 direction)
	{
		spriteRenderer.flipX = false;
		spriteRenderer.flipY = false;
		if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
		{
			spriteRenderer.sprite = spriteHorizontal;
			spriteRenderer.flipX = direction.x < 0f;
		}
		else
		{
			spriteRenderer.sprite = spriteVertical;
		}
	}

	private void SetStraightSpriteFromDir(Dir dir)
	{
		spriteRenderer.flipX = false;
		spriteRenderer.flipY = false;
		switch (dir)
		{
		case Dir.Left:
			spriteRenderer.sprite = spriteHorizontal;
			spriteRenderer.flipX = true;
			break;
		case Dir.Right:
			spriteRenderer.sprite = spriteHorizontal;
			break;
		case Dir.Up:
		case Dir.Down:
			spriteRenderer.sprite = spriteVertical;
			break;
		}
	}

	private void SetTurnSprite(Dir incoming, Dir outgoing)
	{
		spriteRenderer.flipX = false;
		spriteRenderer.flipY = false;
		if (IsCorner(incoming, outgoing, Dir.Up, Dir.Right))
		{
			spriteRenderer.sprite = turnUpRight;
		}
		else if (IsCorner(incoming, outgoing, Dir.Up, Dir.Left))
		{
			spriteRenderer.sprite = turnUpLeft;
		}
		else if (IsCorner(incoming, outgoing, Dir.Down, Dir.Right))
		{
			spriteRenderer.sprite = turnDownRight;
		}
		else if (IsCorner(incoming, outgoing, Dir.Down, Dir.Left))
		{
			spriteRenderer.sprite = turnDownLeft;
		}
	}

	private bool IsCorner(Dir incoming, Dir outgoing, Dir a, Dir b)
	{
		if (incoming != a || outgoing != b)
		{
			if (incoming == b)
			{
				return outgoing == a;
			}
			return false;
		}
		return true;
	}
}
