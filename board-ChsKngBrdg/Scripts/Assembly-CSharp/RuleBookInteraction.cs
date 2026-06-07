using System.Collections;
using UnityEngine;

public class RuleBookInteraction : MonoBehaviour
{
	private SoundManager soundManager;

	public RuleBookScreenManager ruleBookScreenManager;

	public BoxCollider2D ruleBookInteractionCollider;

	public AnimationCurve moveCurveShakeX;

	private bool isShakingBook;

	private float shakeDelaySeconds;

	public float shakeDelayTimer;

	public bool isInspectingBook;

	public AnimationCurve moveCurveEnterX;

	public AnimationCurve cameraMoveCurveEnterX;

	public Transform cameraHolder;

	public Vector3 inspectColliderOffset;

	private bool isEnteringBook;

	public AnimationCurve moveCurveExitX;

	public AnimationCurve cameraMoveCurveExitX;

	private bool isExitingBook;

	public void Awake()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void Update()
	{
		if (shakeDelaySeconds < shakeDelayTimer)
		{
			shakeDelaySeconds += Time.deltaTime;
		}
	}

	public void OnMouseEnter()
	{
		if (!(shakeDelaySeconds < shakeDelayTimer) && !isShakingBook && !isEnteringBook && !isExitingBook)
		{
			if (isInspectingBook)
			{
				StartCoroutine(HoverRuleBookShake(isInspecting: true));
			}
			else
			{
				StartCoroutine(HoverRuleBookShake(isInspecting: false));
			}
		}
	}

	public void OnMouseDown()
	{
		if (!RuleBookScreenManager.isConfirmingCheatGuess && !RuleBookScreenManager.isAnimatingAttempingCheatGuess && !isEnteringBook && !isExitingBook)
		{
			shakeDelaySeconds = 0f;
			if (!isInspectingBook)
			{
				StartInspecting();
			}
			else
			{
				StopInspecting();
			}
		}
	}

	public void StartInspecting()
	{
		isShakingBook = false;
		isEnteringBook = false;
		isExitingBook = false;
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_rulebook_slide_in);
		StopAllCoroutines();
		StartCoroutine(OnEnterRuleBook());
	}

	public void StopInspecting()
	{
		ruleBookScreenManager.StopCheatGuessAttempt();
		isShakingBook = false;
		isEnteringBook = false;
		isExitingBook = false;
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_rulebook_slide_out);
		StopAllCoroutines();
		StartCoroutine(OnExitRuleBook());
	}

	public IEnumerator HoverRuleBookShake(bool isInspecting)
	{
		isShakingBook = true;
		Keyframe[] keys = moveCurveShakeX.keys;
		keys[0].value = base.transform.position.x;
		keys[0].outTangent = 1f;
		if (!isInspecting)
		{
			keys[1].value = base.transform.position.x - 0.5f;
		}
		else
		{
			keys[1].value = base.transform.position.x + 0.5f;
		}
		keys[2].value = base.transform.position.x;
		moveCurveShakeX.keys = keys;
		float moveSeconds = 0f;
		while (moveSeconds < moveCurveShakeX[moveCurveShakeX.length - 1].time)
		{
			base.transform.position = new Vector3(moveCurveShakeX.Evaluate(moveSeconds), base.transform.position.y, base.transform.position.z);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		isShakingBook = false;
	}

	public IEnumerator OnEnterRuleBook()
	{
		isEnteringBook = true;
		Keyframe[] keys = moveCurveEnterX.keys;
		keys[0].value = base.transform.position.x;
		keys[0].outTangent = 1f;
		moveCurveEnterX.keys = keys;
		Keyframe[] keys2 = cameraMoveCurveEnterX.keys;
		keys2[0].value = cameraHolder.position.x;
		keys2[0].outTangent = 1f;
		cameraMoveCurveEnterX.keys = keys2;
		float moveSeconds = 0f;
		while (moveSeconds < moveCurveEnterX[moveCurveEnterX.length - 1].time)
		{
			base.transform.position = new Vector3(moveCurveEnterX.Evaluate(moveSeconds), base.transform.position.y, base.transform.position.z);
			cameraHolder.position = new Vector3(cameraMoveCurveEnterX.Evaluate(moveSeconds), cameraHolder.position.y, cameraHolder.position.z);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		ruleBookInteractionCollider.offset = inspectColliderOffset;
		isEnteringBook = false;
		isInspectingBook = true;
	}

	public IEnumerator OnExitRuleBook()
	{
		isExitingBook = true;
		Keyframe[] keys = moveCurveExitX.keys;
		keys[0].value = base.transform.position.x;
		keys[0].outTangent = 1f;
		moveCurveExitX.keys = keys;
		Keyframe[] keys2 = cameraMoveCurveExitX.keys;
		keys2[0].value = cameraHolder.position.x;
		keys2[0].outTangent = 1f;
		cameraMoveCurveExitX.keys = keys2;
		float moveSeconds = 0f;
		while (moveSeconds < moveCurveExitX[moveCurveExitX.length - 1].time)
		{
			base.transform.position = new Vector3(moveCurveExitX.Evaluate(moveSeconds), base.transform.position.y, base.transform.position.z);
			cameraHolder.position = new Vector3(cameraMoveCurveExitX.Evaluate(moveSeconds), cameraHolder.position.y, cameraHolder.position.z);
			moveSeconds += Time.deltaTime;
			yield return null;
		}
		ruleBookInteractionCollider.offset = Vector3.zero;
		isExitingBook = false;
		isInspectingBook = false;
	}
}
