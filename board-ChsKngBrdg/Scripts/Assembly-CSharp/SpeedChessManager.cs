using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChessManager : MonoBehaviour
{
	private ChessMatchManager chessMatchManager;

	private RuleBookScreenManager ruleBookScreenManager;

	public static bool doSpeedChess;

	public static float speedChessTime;

	private float elapsedTime;

	public float incrementTime;

	private float elapsedIncrementTime;

	public Image hourglassBorder;

	public Image hourglassOutImage;

	public Image hourglassInImage;

	public Transform hourglass;

	public AnimationCurve flipRotationCurve;

	public ObjectShake objectShake;

	public ParticleSystem sandParticle;

	private void Start()
	{
		if (doSpeedChess)
		{
			hourglass.gameObject.SetActive(value: true);
			chessMatchManager = Object.FindObjectOfType<ChessMatchManager>();
			ruleBookScreenManager = Object.FindObjectOfType<RuleBookScreenManager>();
			SetOpacity(0.5f);
			UpdateHourglassFillAmount();
			hourglassBorder.color = chessMatchManager.whiteColor.globalColor;
			sandParticle.Stop();
		}
		else
		{
			hourglass.gameObject.SetActive(value: false);
		}
	}

	public void Update()
	{
		if (!doSpeedChess || chessMatchManager.lastMovedPieceByWhite == null)
		{
			return;
		}
		if (DoCountTime())
		{
			CountTime();
			return;
		}
		elapsedIncrementTime = 0f;
		if (sandParticle.isPlaying)
		{
			sandParticle.Stop();
		}
	}

	private bool DoCountTime()
	{
		if (ChessMatchManager.currentTurnColor != ChessMatchManager.ChessColor.White)
		{
			return false;
		}
		if (chessMatchManager.isEndingTurn)
		{
			return false;
		}
		if (TrollDialogManager.isInDialog)
		{
			return false;
		}
		if (RuleBookScreenManager.isConfirmingCheatGuess)
		{
			return false;
		}
		if (ruleBookScreenManager.showingCheatGuessResult)
		{
			return false;
		}
		return true;
	}

	public void CountTime()
	{
		if (elapsedIncrementTime < incrementTime)
		{
			elapsedIncrementTime += Time.deltaTime;
			SetOpacity(0.5f);
			return;
		}
		if (!sandParticle.isPlaying)
		{
			sandParticle.Play();
		}
		if (elapsedTime < speedChessTime)
		{
			elapsedTime += Time.deltaTime;
			SetOpacity(1f);
			objectShake.StartCoroutine(objectShake.Shake(0.25f, 1.5f));
		}
		else
		{
			chessMatchManager.nextPlayerWonCheat = true;
			chessMatchManager.blackWonTime = true;
			chessMatchManager.lastTurnCheatReasons.Clear();
			ChessMatchManager.currentTurnColor = ChessMatchManager.ChessColor.Black;
		}
		UpdateHourglassFillAmount();
	}

	public void UpdateHourglassFillAmount()
	{
		float num = elapsedTime / speedChessTime;
		hourglassOutImage.fillAmount = 1f - num;
		hourglassInImage.fillAmount = num;
	}

	public IEnumerator FlipHourglass(float direction, Color nextColor)
	{
		Transform flipTransform = hourglass.transform;
		Color oldColor = hourglassBorder.color;
		SetOpacity(0.5f);
		Keyframe[] keys = flipRotationCurve.keys;
		keys[0].value = flipTransform.eulerAngles.z;
		keys[1].value = direction;
		flipRotationCurve.keys = keys;
		float flipSeconds = 0f;
		while (flipSeconds < flipRotationCurve[flipRotationCurve.length - 1].time)
		{
			Color color = Color.Lerp(oldColor, nextColor, flipSeconds / flipRotationCurve[flipRotationCurve.length - 1].time);
			hourglassBorder.color = color;
			flipTransform.rotation = Quaternion.Euler(0f, 0f, flipRotationCurve.Evaluate(flipSeconds));
			flipSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public void FlipToBlack()
	{
		StartCoroutine(FlipHourglass(180f, chessMatchManager.blackColor.globalColor));
	}

	public void FlipToWhite()
	{
		StartCoroutine(FlipHourglass(0f, chessMatchManager.whiteColor.globalColor));
	}

	public void SetOpacity(float opacity)
	{
		hourglassOutImage.color = new Color(hourglassOutImage.color.r, hourglassOutImage.color.g, hourglassOutImage.color.b, opacity);
		hourglassInImage.color = new Color(hourglassInImage.color.r, hourglassInImage.color.g, hourglassInImage.color.b, opacity);
	}
}
