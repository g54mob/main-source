using System.Collections;
using Steamworks;
using UnityEngine;

public class ChessPieceObject : MonoBehaviour
{
	private SoundManager soundManager;

	private ChessMatchManager chessMatchManager;

	public SpriteRenderer spriteRenderer;

	public SpriteRenderer outlineRenderer;

	public Animator animator;

	public Animator fillAnimator;

	public AnimationClip trollIdleClip;

	public AnimationClip trollIdleFillClip;

	public AnimationClip kingShatterClip;

	public AnimationClip landmineExplosionClip;

	public Color originalColor;

	public GlobalColor highlightColor;

	public ObjectShake objectShake;

	public ChessPieceData pieceData;

	public ChessMatchManager.ChessColor pieceColor;

	public AnimationCurve moveCurveX;

	public AnimationCurve moveCurveY;

	public GameObject ghostPrefab;

	public GameObject ghost;

	public AnimationCurve slipRotationCurve;

	public AnimationCurve slipYCurve;

	public bool moveIsBlocked;

	private float valoriteScrapSeconds;

	public bool isSleeping;

	public bool isStoppingSleeping;

	public ParticleSystem sleepParticleSystem;

	public int sleepClicks;

	public int sleepturn;

	public int sleepAfterTurn;

	public float sleepResetTime;

	private float elapsedSleepResetTime;

	public AnimationCurve sleepResetCurve;

	public AnimationCurve ascentionCurve;

	public AnimationCurve ascentionColorCurve;

	public SpriteRenderer ascentionHalo;

	public SpriteRenderer ascentionOutline;

	public AnimationCurve ascensionEndingCurve;

	public int ascensionEndingSortOrder;

	public AnimationCurve ascensionMoveX;

	public AnimationCurve ascensionMoveY;

	private bool dragging;

	private Vector3 offset = Vector3.zero;

	private Vector3 lastPositionBeforeDragging = Vector2.zero;

	public AnimationCurve fakeOutCurveY;

	public AnimationCurve fogColorFadeCurve;

	public bool isDuckBound;

	public int rookEatScore;

	private void Start()
	{
		chessMatchManager = Object.FindObjectOfType<ChessMatchManager>();
		spriteRenderer.sprite = pieceData.pieceFillSprite;
		outlineRenderer.sprite = pieceData.pieceOutlineSprite;
		lastPositionBeforeDragging = ChessMatchManager.RoundPoint(base.transform.position);
		soundManager = Object.FindObjectOfType<SoundManager>();
		if (ascensionEndingSortOrder <= 0)
		{
			UpdateSortOrder();
		}
	}

	private void Update()
	{
		if (dragging)
		{
			base.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
			if (RuleBookScreenManager.isAttemptingCheatGuess)
			{
				dragging = false;
				base.transform.position = lastPositionBeforeDragging;
				ReleaseGrab();
			}
			bool flag = CheckIfOOB(ChessMatchManager.RoundPoint(base.transform.position));
			if (CheckIfOOB(lastPositionBeforeDragging) || flag)
			{
				if (!chessMatchManager.OOBHolder.gameObject.activeSelf)
				{
					chessMatchManager.OOBHolder.gameObject.SetActive(value: true);
				}
			}
			else if (chessMatchManager.OOBHolder.gameObject.activeSelf)
			{
				chessMatchManager.OOBHolder.gameObject.SetActive(value: false);
			}
		}
		if (pieceData.pieceType == ChessPieceData.ChessPieceType.Castle && base.transform.position.y < 15f)
		{
			ValoriteScraps();
		}
		if (isSleeping)
		{
			if (sleepturn + sleepAfterTurn < ChessMatchManager.turnCount && !sleepParticleSystem.isPlaying)
			{
				sleepParticleSystem.Play();
			}
		}
		else if (sleepParticleSystem.isPlaying)
		{
			sleepParticleSystem.Stop();
		}
		if (isSleeping && sleepClicks > 0)
		{
			if (elapsedSleepResetTime < sleepResetTime)
			{
				elapsedSleepResetTime += Time.deltaTime;
				return;
			}
			elapsedSleepResetTime = 0f;
			sleepClicks = 0;
			StartCoroutine(SleepReset());
		}
	}

	public static int CalculateSortOrder(Transform sortTransform)
	{
		return -(int)(Mathf.Round(sortTransform.position.y * 100f / 2f) * 2f);
	}

	public void UpdateSortOrder()
	{
		if (!isDuckBound)
		{
			spriteRenderer.sortingOrder = CalculateSortOrder(spriteRenderer.transform);
			outlineRenderer.sortingOrder = CalculateSortOrder(spriteRenderer.transform) + 1;
		}
	}

	public void OnGrab()
	{
		spriteRenderer.sortingOrder = 10000;
		outlineRenderer.sortingOrder = 10001;
		ghost = Object.Instantiate(ghostPrefab, spriteRenderer.transform.position, Quaternion.identity);
		SpriteRenderer component = ghost.GetComponent<SpriteRenderer>();
		component.sprite = outlineRenderer.sprite;
		component.flipX = outlineRenderer.flipX;
		component.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.45f);
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_grab);
	}

	public void ReleaseGrab()
	{
		objectShake.StartCoroutine(objectShake.Shake(0.1f, 0.05f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_drop);
		if (ghost != null)
		{
			Object.Destroy(ghost);
		}
	}

	private void OnMouseDown()
	{
		if (ChessMatchManager.blockMovement)
		{
			moveIsBlocked = true;
		}
		else
		{
			if (isDuckBound || ChessMatchManager.noMoveAllowed || TrollDialogManager.isInDialog || RuleBookScreenManager.isConfirmingCheatGuess || RuleBookScreenManager.isAnimatingAttempingCheatGuess)
			{
				return;
			}
			if (RuleBookScreenManager.isAttemptingCheatGuess)
			{
				CheatGuessEnabler();
			}
			else
			{
				if (ChessMatchManager.currentTurnColor != ChessMatchManager.ChessColor.White || ChessMatchManager.colorHasWon)
				{
					return;
				}
				lastPositionBeforeDragging = ChessMatchManager.RoundPoint(base.transform.position);
				offset = base.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if (!isSleeping)
				{
					dragging = true;
					OnGrab();
				}
				if (isSleeping)
				{
					sleepClicks++;
					if (sleepClicks < 3)
					{
						SleepWakeUp();
						elapsedSleepResetTime = 0f;
						return;
					}
					sleepClicks = 0;
					elapsedSleepResetTime = 0f;
					ChessMatchManager.blockMovement = true;
					chessMatchManager.CompleteMove(this, lastPositionBeforeDragging, lastPositionBeforeDragging);
				}
			}
		}
	}

	private void OnMouseUp()
	{
		if (moveIsBlocked)
		{
			moveIsBlocked = false;
		}
		else if (!isDuckBound && !ChessMatchManager.noMoveAllowed && !TrollDialogManager.isInDialog && !RuleBookScreenManager.isAttemptingCheatGuess && !RuleBookScreenManager.isConfirmingCheatGuess && !RuleBookScreenManager.isAnimatingAttempingCheatGuess && ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.White && !ChessMatchManager.colorHasWon && !isSleeping)
		{
			Vector3 vector = ChessMatchManager.RoundPoint(base.transform.position);
			ReleaseGrab();
			UpdateSortOrder();
			if (vector != lastPositionBeforeDragging)
			{
				ChessMatchManager.blockMovement = true;
				chessMatchManager.CompleteMove(this, lastPositionBeforeDragging, vector);
			}
			else
			{
				base.transform.position = vector;
			}
			if (chessMatchManager.OOBHolder.gameObject.activeSelf)
			{
				chessMatchManager.OOBHolder.gameObject.SetActive(value: false);
			}
			dragging = false;
		}
	}

	public void CheatGuessEnabler()
	{
		if (RuleBookScreenManager.isConfirmingCheatGuess)
		{
			return;
		}
		if (RuleBookScreenManager.cheatGuessAttemptChessPiece != this)
		{
			if (RuleBookScreenManager.cheatGuessAttemptChessPiece != null)
			{
				RuleBookScreenManager.cheatGuessAttemptChessPiece.StopHighlight();
			}
			RuleBookScreenManager.cheatGuessAttemptChessPiece = this;
			StartHighlight();
		}
		else
		{
			RuleBookScreenManager.cheatGuessAttemptChessPiece = null;
			StopHighlight();
		}
	}

	public void StartHighlight()
	{
		originalColor = spriteRenderer.color;
		spriteRenderer.color = highlightColor.globalColor;
		if (RuleBookScreenManager.cheatGuessAttemptRulebookPage == null)
		{
			Object.FindObjectOfType<RuleBookScreenManager>().PlayFirstSelectedSound();
		}
		else
		{
			Object.FindObjectOfType<RuleBookScreenManager>().PlaySecondSelectedSound();
		}
	}

	public void StopHighlight()
	{
		spriteRenderer.color = originalColor;
	}

	public void KingShatter()
	{
		animator.enabled = true;
		animator.Play("Base Layer." + kingShatterClip.name, 0, 0f);
	}

	public void LandmineExplodion()
	{
		outlineRenderer.gameObject.SetActive(value: false);
		fillAnimator.enabled = true;
		fillAnimator.Play("Base Layer." + landmineExplosionClip.name, 0, 0f);
	}

	public void TrollIdle()
	{
		animator.enabled = true;
		fillAnimator.enabled = true;
		animator.Play("Base Layer." + trollIdleClip.name, 0, 0f);
		fillAnimator.Play("Base Layer." + trollIdleFillClip.name, 0, 0f);
	}

	public void ValoriteScraps()
	{
		if (valoriteScrapSeconds < 10f)
		{
			valoriteScrapSeconds += Time.deltaTime;
			return;
		}
		valoriteScrapSeconds = 0f;
		chessMatchManager.SpawnDamageNumber(chessMatchManager.scrapsString.GetLocalizedString(), base.transform, new Vector3(0f, 1f, 0f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_castle_scraps);
		SaveSystem.currentPlayerSaveData.totalScrapCount++;
		SteamUserStats.AddStat("ScrapCounter", 1);
		SteamUserStats.StoreStats();
	}

	public void SleepWakeUp()
	{
		objectShake.StartCoroutine(objectShake.Shake(0.1f, 0.05f));
		spriteRenderer.transform.parent.Rotate(0f, 0f, -15f);
		SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_lilypad);
	}

	public bool CheckIfOOB(Vector3 position)
	{
		bool result = false;
		if (position.x < (float)(-chessMatchManager.boardSizeX / 2) + 0.5f || position.x > (float)(chessMatchManager.boardSizeX / 2))
		{
			result = true;
		}
		if (position.y < (float)(-chessMatchManager.boardSizeY / 2) + 0.5f || position.y > (float)(chessMatchManager.boardSizeY / 2))
		{
			result = true;
		}
		return result;
	}

	public IEnumerator DragChessPiece(Vector3 originPosition, Vector3 movePosition)
	{
		if (isSleeping)
		{
			chessMatchManager.CompleteMove(this, originPosition, originPosition);
		}
		else
		{
			OnGrab();
			Vector2 randomOffset = new Vector2(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f));
			Keyframe[] keys = moveCurveX.keys;
			keys[0].value = base.transform.position.x;
			keys[0].outTangent = 1f;
			keys[1].value = originPosition.x + movePosition.x + randomOffset.x;
			keys[1].time = 0.5f;
			moveCurveX.keys = keys;
			Keyframe[] keys2 = moveCurveY.keys;
			keys2[0].value = base.transform.position.y;
			keys2[0].outTangent = 1f;
			keys2[1].value = originPosition.y + movePosition.y + randomOffset.y;
			keys2[1].time = 0.5f;
			moveCurveY.keys = keys2;
			float moveSeconds = 0f;
			while (moveSeconds < moveCurveX[moveCurveX.length - 1].time)
			{
				base.transform.position = new Vector3(moveCurveX.Evaluate(moveSeconds), moveCurveY.Evaluate(moveSeconds), 0f);
				moveSeconds += Time.deltaTime;
				yield return null;
			}
			base.transform.position = originPosition + movePosition + (Vector3)randomOffset;
			chessMatchManager.CompleteMove(this, originPosition, originPosition + movePosition);
			ReleaseGrab();
		}
		UpdateSortOrder();
	}

	public IEnumerator FakeOut(Vector3 originPosition)
	{
		yield return new WaitForSeconds(0.25f);
		OnGrab();
		float num = 0.5f;
		Keyframe[] keys = fakeOutCurveY.keys;
		keys[0].value = base.transform.position.y;
		keys[1].outTangent = 0f;
		keys[1].value = originPosition.y + num;
		keys[2].value = originPosition.y + num;
		keys[1].inTangent = 0f;
		keys[3].value = originPosition.y;
		fakeOutCurveY.keys = keys;
		float moveSeconds = 0f;
		while (moveSeconds < fakeOutCurveY[fakeOutCurveY.length - 1].time)
		{
			base.transform.position = new Vector3(base.transform.position.x, fakeOutCurveY.Evaluate(moveSeconds), base.transform.position.z);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		base.transform.position = originPosition;
		ReleaseGrab();
		Object.FindObjectOfType<ChessTrollManager>().isPerformingFakeOut = false;
		UpdateSortOrder();
	}

	public IEnumerator SlipOnFloor(Transform slipTransform)
	{
		SoundManager.LoadSoundEffect(slipTransform, soundManager.chess_piece_slip);
		float slipSeconds = 0f;
		while (slipSeconds < slipYCurve[slipYCurve.length - 1].time)
		{
			slipTransform.rotation = Quaternion.Euler(0f, 0f, slipRotationCurve.Evaluate(slipSeconds));
			slipTransform.localPosition = new Vector3(0f, slipYCurve.Evaluate(slipSeconds), 0f);
			slipSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator StopSleeping(bool doRotate = true)
	{
		isStoppingSleeping = true;
		Transform slipTransform = spriteRenderer.transform.parent;
		float slipSeconds = 0f;
		if (doRotate)
		{
			slipTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		while (slipSeconds < slipYCurve[slipYCurve.length - 1].time)
		{
			slipTransform.localPosition = new Vector3(0f, slipYCurve.Evaluate(slipSeconds), 0f);
			slipSeconds += Time.deltaTime;
			yield return null;
		}
		isStoppingSleeping = false;
	}

	public IEnumerator SleepReset()
	{
		Transform slipTransform = spriteRenderer.transform.parent;
		Keyframe[] keys = sleepResetCurve.keys;
		keys[0].value = slipTransform.rotation.eulerAngles.z;
		keys[1].value = slipRotationCurve[slipRotationCurve.length - 1].value;
		sleepResetCurve.keys = keys;
		float slipSeconds = 0f;
		while (slipSeconds < sleepResetCurve[sleepResetCurve.length - 1].time && isSleeping)
		{
			slipTransform.rotation = Quaternion.Euler(0f, 0f, sleepResetCurve.Evaluate(slipSeconds));
			slipSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator Ascension()
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_pawn_ascention);
		ascentionHalo.color = spriteRenderer.color;
		ascentionHalo.transform.parent.gameObject.SetActive(value: true);
		Keyframe[] keys = ascentionCurve.keys;
		keys[0].value = base.transform.position.y;
		keys[1].value = base.transform.position.y + 20f;
		ascentionCurve.keys = keys;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < ascentionCurve[ascentionCurve.length - 1].time)
		{
			base.transform.localPosition = new Vector3(base.transform.position.x, ascentionCurve.Evaluate(elapsedSeconds), base.transform.position.z);
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, ascentionColorCurve.Evaluate(elapsedSeconds));
			outlineRenderer.color = new Color(outlineRenderer.color.r, outlineRenderer.color.g, outlineRenderer.color.b, ascentionColorCurve.Evaluate(elapsedSeconds));
			ascentionHalo.color = new Color(ascentionHalo.color.r, ascentionHalo.color.g, ascentionHalo.color.b, ascentionColorCurve.Evaluate(elapsedSeconds));
			ascentionOutline.color = new Color(ascentionOutline.color.r, ascentionOutline.color.g, ascentionOutline.color.b, ascentionColorCurve.Evaluate(elapsedSeconds));
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator AscensionEndingEntrance()
	{
		outlineRenderer.sortingOrder = 16001 + ascensionEndingSortOrder;
		spriteRenderer.sortingOrder = 16000 + ascensionEndingSortOrder;
		Keyframe[] keys = ascensionEndingCurve.keys;
		keys[0].value = base.transform.position.y;
		keys[1].value = base.transform.position.y - 20f;
		ascensionEndingCurve.keys = keys;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < ascensionEndingCurve[ascensionEndingCurve.length - 1].time)
		{
			base.transform.position = new Vector3(base.transform.position.x, ascensionEndingCurve.Evaluate(elapsedSeconds), base.transform.position.z);
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		objectShake.StartCoroutine(objectShake.Shake(0.25f, 0.1f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_manhole_blast);
	}

	public IEnumerator AscensionEndingCapture(ChessPieceObject king, float shakeAmount)
	{
		outlineRenderer.sortingOrder = 16001 + ascensionEndingSortOrder;
		spriteRenderer.sortingOrder = 16000 + ascensionEndingSortOrder;
		Keyframe[] keys = ascensionMoveX.keys;
		keys[0].value = base.transform.position.x;
		keys[0].outTangent = 1f;
		keys[1].value = king.transform.position.x;
		keys[1].inTangent = 1f;
		ascensionMoveX.keys = keys;
		Keyframe[] keys2 = ascensionMoveY.keys;
		keys2[0].value = base.transform.position.y;
		keys2[0].outTangent = 1f;
		keys2[1].value = king.transform.position.y;
		keys2[1].inTangent = 1f;
		ascensionMoveY.keys = keys2;
		float moveSeconds = 0f;
		while (moveSeconds < ascensionMoveX[ascensionMoveX.length - 1].time)
		{
			base.transform.position = new Vector3(ascensionMoveX.Evaluate(moveSeconds), ascensionMoveY.Evaluate(moveSeconds), 0f);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		king.StartCoroutine(king.objectShake.Shake(0.1f, shakeAmount));
		StartCoroutine(Camera.main.GetComponent<ObjectShake>().Shake(0.1f, shakeAmount / 1.25f));
		SoundManager.LoadSoundEffect(spriteRenderer.transform, soundManager.troll_critical_hit);
		yield return new WaitForSeconds(0.125f);
		base.transform.position = new Vector3(0f, 25f, 0f);
	}

	public IEnumerator FogFadeOut()
	{
		float elapsedSeconds = 0f;
		while (elapsedSeconds < fogColorFadeCurve[fogColorFadeCurve.length - 1].time)
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, fogColorFadeCurve.Evaluate(elapsedSeconds));
			outlineRenderer.color = new Color(outlineRenderer.color.r, outlineRenderer.color.g, outlineRenderer.color.b, fogColorFadeCurve.Evaluate(elapsedSeconds));
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator FogFadeIn()
	{
		float elapsedSeconds = fogColorFadeCurve[fogColorFadeCurve.length - 1].time;
		while (elapsedSeconds > 0f)
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, fogColorFadeCurve.Evaluate(elapsedSeconds));
			outlineRenderer.color = new Color(outlineRenderer.color.r, outlineRenderer.color.g, outlineRenderer.color.b, fogColorFadeCurve.Evaluate(elapsedSeconds));
			elapsedSeconds -= Time.deltaTime;
			yield return null;
		}
	}
}
