using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
	public enum DuckState
	{
		Inactive = 0,
		Swimming = 1,
		Walking = 2,
		HeldByPlayer = 3
	}

	[Header("References")]
	public Rigidbody2D rb;

	public SpriteRenderer spriteRenderer;

	public Animator animator;

	public SineMovement sineMovement;

	private ChessMatchManager chessMatchManager;

	private SoundManager soundManager;

	public Transform pieceHolder;

	public DuckState duckState;

	[Header("Animations")]
	public AnimationClip idleClip;

	public AnimationClip walkClip;

	public AnimationClip swimClip;

	public AnimationClip flapClip;

	public AnimationClip honkClip;

	[Header("Sorting")]
	public string swimSortLayer;

	public int swimSortOrder;

	public string heldByPlayerSortLayer;

	public int heldByPlayerSortOrder;

	public string walkSortLayer;

	public int walkSortOrder;

	[Header("Values")]
	public float minInactivityTime;

	public float maxInactivityTime;

	public float inactivityDistance;

	public float swimSpeed;

	public float walkSpeed;

	public float minTimeBetweenWalk;

	public float maxTimeBetweenWalk;

	public float nextSpotMaxDistance;

	public AnimationCurve walkCurveX;

	public AnimationCurve walkCurveY;

	public float flipTime;

	public int spotVisitsBeforeLeaving;

	public AnimationCurve leaveCurveX;

	public AnimationCurve leaveCurveY;

	[Header("Private")]
	public bool holdingPiece;

	public ChessPieceObject heldPiece;

	private Vector3 offset;

	private bool isMoving;

	private bool isHoldable = true;

	private float inactivtyTime;

	private float elapsedInactivityTime;

	private int visitedSpots;

	private bool isWet;

	private float elapsedFlipTime;

	private float xDelta;

	private bool triedToLeave;

	public void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Start()
	{
		chessMatchManager = Object.FindObjectOfType<ChessMatchManager>();
		soundManager = Object.FindObjectOfType<SoundManager>();
		StartInactive();
	}

	public void Update()
	{
		UpdateDuckState();
	}

	public void OnMouseDown()
	{
		if (duckState != DuckState.Inactive)
		{
			if (isHoldable && !holdingPiece)
			{
				StartHeldByPlayer();
			}
			else
			{
				SoundManager.LoadSoundEffect(base.transform, soundManager.duck_flap);
			}
		}
	}

	public void OnMouseUp()
	{
		if (duckState != DuckState.Inactive && isHoldable && !holdingPiece && !(chessMatchManager == null))
		{
			if (base.transform.position.x < (float)(chessMatchManager.boardSizeX / 2) && base.transform.position.x > (float)(-chessMatchManager.boardSizeX / 2))
			{
				StartWalking();
				return;
			}
			StartSwimming();
			SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_lilypad);
		}
	}

	public void StartInactive()
	{
		if (holdingPiece)
		{
			GetComponentInChildren<ChessPieceObject>().transform.SetParent(chessMatchManager.transform, worldPositionStays: true);
			heldPiece = null;
			holdingPiece = false;
		}
		duckState = DuckState.Inactive;
		inactivtyTime = Random.Range(minInactivityTime, maxInactivityTime);
		elapsedInactivityTime = 0f;
		visitedSpots = 0;
		triedToLeave = false;
		rb.velocity = Vector2.zero;
		base.transform.position = new Vector3(inactivityDistance, Random.Range(5, -5), 0f);
		FlipLeft();
		pieceHolder.transform.localPosition = new Vector3(-0.25f, pieceHolder.transform.localPosition.y, pieceHolder.transform.localPosition.z);
	}

	public void StartSwimming()
	{
		duckState = DuckState.Swimming;
		SetSortLayer(swimSortLayer, swimSortOrder);
		sineMovement.enabled = true;
		LoadAnimation(animator, swimClip, doOverride: true);
		FlipLeft();
		if (heldPiece != null)
		{
			heldPiece.spriteRenderer.sortingLayerName = "Background";
			heldPiece.outlineRenderer.sortingLayerName = "Background";
			heldPiece.spriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 2;
			heldPiece.outlineRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;
		}
		isWet = true;
	}

	public void StartWalking()
	{
		duckState = DuckState.Walking;
		rb.velocity = Vector2.zero;
		xDelta = 0f;
		SetSortLayer(walkSortLayer, walkSortOrder);
		LoadAnimation(animator, idleClip, doOverride: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_drop);
		if (triedToLeave)
		{
			SteamAchievements.UnlockAchievement("DUCK_FORCE");
		}
	}

	public void StartHeldByPlayer()
	{
		if (!(chessMatchManager == null))
		{
			duckState = DuckState.HeldByPlayer;
			rb.velocity = Vector2.zero;
			offset = base.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
			SetSortLayer(heldByPlayerSortLayer, heldByPlayerSortOrder);
			sineMovement.enabled = false;
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_grab);
			SoundManager.LoadSoundEffect(spriteRenderer.transform, soundManager.duck_honk);
		}
	}

	public void UpdateDuckState()
	{
		switch (duckState)
		{
		case DuckState.Inactive:
			UpdateDuckInactive();
			break;
		case DuckState.Swimming:
			UpdateDuckSwimming();
			break;
		case DuckState.Walking:
			UpdateDuckWalking();
			break;
		case DuckState.HeldByPlayer:
			UpdateDuckHeldByPlayer();
			break;
		}
	}

	public void UpdateDuckInactive()
	{
		if (elapsedInactivityTime < inactivtyTime)
		{
			elapsedInactivityTime += Time.deltaTime;
		}
		else
		{
			StartSwimming();
		}
	}

	public void UpdateDuckSwimming()
	{
		if (ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.Black)
		{
			rb.velocity = Vector2.zero;
		}
		else
		{
			rb.velocity = Vector2.left * swimSpeed;
		}
		if (base.transform.position.x < -24f)
		{
			StartInactive();
		}
	}

	public void UpdateDuckWalking()
	{
		if (!isMoving)
		{
			StartCoroutine(WalkToSpot());
		}
		UpdateSpriteFlip();
		spriteRenderer.sortingOrder = ChessPieceObject.CalculateSortOrder(spriteRenderer.transform);
	}

	public void UpdateDuckHeldByPlayer()
	{
		base.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
	}

	public IEnumerator WalkToSpot()
	{
		isMoving = true;
		isHoldable = false;
		if (isWet)
		{
			isWet = false;
			LoadAnimation(animator, flapClip, doOverride: true);
			yield return new WaitForSeconds(flapClip.length);
		}
		LoadAnimation(animator, honkClip, doOverride: true);
		yield return new WaitForSeconds(honkClip.length);
		LoadAnimation(animator, walkClip, doOverride: true);
		Vector3 newSpotPosition = GetNewSpot();
		if (visitedSpots >= spotVisitsBeforeLeaving)
		{
			newSpotPosition = new Vector3(-3.75f, Random.Range(-3f, 3f), 0f);
		}
		Vector3 randomOffset = new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f));
		float num = Vector3.Distance(base.transform.position, newSpotPosition + randomOffset) / walkSpeed;
		Vector3 vector = Vector3.Lerp(base.transform.position, newSpotPosition + randomOffset, 0.5f);
		Keyframe[] keys = walkCurveX.keys;
		keys[0].value = base.transform.position.x;
		keys[0].outTangent = 0f;
		keys[1].value = vector.x;
		keys[1].time = num / 2f;
		keys[1].inTangent = keys[0].outTangent;
		keys[1].outTangent = keys[2].inTangent;
		keys[2].value = newSpotPosition.x + randomOffset.x;
		keys[2].time = num;
		keys[2].inTangent = 0f;
		walkCurveX.keys = keys;
		Keyframe[] keys2 = walkCurveY.keys;
		keys2[0].value = base.transform.position.y;
		keys2[0].outTangent = 0f;
		keys2[1].value = newSpotPosition.y + randomOffset.y;
		keys2[1].time = num;
		keys2[1].inTangent = 0f;
		walkCurveY.keys = keys2;
		float moveSeconds = 0f;
		while (moveSeconds < walkCurveX[walkCurveX.length - 1].time)
		{
			base.transform.position = new Vector3(walkCurveX.Evaluate(moveSeconds), walkCurveY.Evaluate(moveSeconds), 0f);
			xDelta = walkCurveX.Evaluate(moveSeconds) - walkCurveX.Evaluate(moveSeconds - Time.deltaTime);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		base.transform.position = newSpotPosition + randomOffset;
		if (visitedSpots >= spotVisitsBeforeLeaving)
		{
			FlipLeft();
			LoadAnimation(animator, swimClip, doOverride: true);
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_flap);
			Vector3 originLeavePosition = base.transform.position;
			float leaveSeconds = 0f;
			while (leaveSeconds < leaveCurveX[leaveCurveX.length - 1].time)
			{
				base.transform.position = new Vector3(originLeavePosition.x + leaveCurveX.Evaluate(leaveSeconds), originLeavePosition.y + leaveCurveY.Evaluate(leaveSeconds), 0f);
				leaveSeconds += Time.deltaTime;
				yield return null;
			}
			triedToLeave = true;
			StartSwimming();
			SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_lilypad);
		}
		else
		{
			visitedSpots++;
			LoadAnimation(animator, idleClip, doOverride: true);
			isHoldable = true;
			yield return new WaitForSeconds(Random.Range(minTimeBetweenWalk, maxTimeBetweenWalk));
		}
		isHoldable = true;
		isMoving = false;
	}

	public Vector3 GetNewSpot()
	{
		Vector3 result = default(Vector3);
		List<Vector3> list = new List<Vector3>();
		List<ChessPieceObject> list2 = new List<ChessPieceObject>();
		list2.AddRange(chessMatchManager.whitePieces);
		list2.AddRange(chessMatchManager.blackPieces);
		list2.AddRange(chessMatchManager.utilityPieces);
		for (float num = (float)(-chessMatchManager.boardSizeX / 2) + 0.5f; num < (float)(chessMatchManager.boardSizeX / 2) + 0.5f; num += 1f)
		{
			for (float num2 = (float)(-chessMatchManager.boardSizeY / 2) + 0.5f; num2 < (float)(chessMatchManager.boardSizeY / 2) + 0.5f; num2 += 1f)
			{
				Vector2 vector = new Vector2(num, num2);
				float num3 = Vector3.Distance(vector, base.transform.position);
				if (!(num3 < nextSpotMaxDistance) || !(num3 > 1f))
				{
					continue;
				}
				bool flag = false;
				if ((Vector2)ChessMatchManager.RoundPoint(base.transform.position) == vector)
				{
					flag = true;
					break;
				}
				foreach (ChessPieceObject item in list2)
				{
					if ((Vector2)ChessMatchManager.RoundPoint(item.transform.position) == vector)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(vector);
				}
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return result;
	}

	public static void LoadAnimation(Animator animator, AnimationClip animationClip, bool doOverride)
	{
		string text = animationClip.name;
		if (doOverride)
		{
			animator.Play("Base Layer." + text, 0, 0f);
		}
		else
		{
			animator.Play("Base Layer." + text, 0);
		}
	}

	private void SetSortLayer(string layer, int order)
	{
		spriteRenderer.sortingLayerName = layer;
		spriteRenderer.sortingOrder = order;
	}

	private void UpdateSpriteFlip()
	{
		if (elapsedFlipTime < flipTime)
		{
			elapsedFlipTime += Time.deltaTime;
			return;
		}
		elapsedFlipTime = 0f;
		if (xDelta <= 0f)
		{
			FlipLeft();
		}
		else
		{
			FlipRight();
		}
	}

	private void FlipRight()
	{
		spriteRenderer.flipX = false;
		pieceHolder.transform.localPosition = new Vector3(-0.25f, pieceHolder.transform.localPosition.y, pieceHolder.transform.localPosition.z);
	}

	private void FlipLeft()
	{
		spriteRenderer.flipX = true;
		pieceHolder.transform.localPosition = new Vector3(0.25f, pieceHolder.transform.localPosition.y, pieceHolder.transform.localPosition.z);
	}
}
