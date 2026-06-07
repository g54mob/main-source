using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleBookScreenManager : MonoBehaviour
{
	private SoundManager soundManager;

	public RuleBookInteraction ruleBookInteraction;

	public RulebookFogManager ruleBookFogManager;

	public ChessMatchManager chessMatchManager;

	public TransitionManager transitionManager;

	public RulebookTableOfContents rulebookTableOfContents;

	public List<RuleBookScreenData> ruleBookScreens = new List<RuleBookScreenData>();

	public RuleBookScreenData currentRuleBookScreen;

	public List<int> pageFlipInputBuffer = new List<int>();

	private bool isFlipping;

	public SpriteRenderer leftBookArrow;

	public SpriteRenderer rightBookArrow;

	public SpriteRenderer leftPageImage;

	public SpriteRenderer rightPageImage;

	public Animator pageFlipAnimator;

	public Animator pageFlipOutlineAnimator;

	public AnimationClip pageFlipAnimation;

	public AnimationClip pageFlipOutlineAnimation;

	public GlobalColor outlineColor;

	public GlobalColor whiteColor;

	public GlobalColor blackColor;

	public GlobalColor dangerColor;

	public bool doChangeColor = true;

	public GuessButtonBar guessButtonBar;

	public TMP_Text cheatGuessText;

	public ObjectShake cheatGuessTextShake;

	public Transform cheatGuessHolder;

	public bool showingCheatGuessResult;

	public static bool isAnimatingAttempingCheatGuess;

	public static bool isAttemptingCheatGuess;

	public static bool isConfirmingCheatGuess;

	public static ChessPieceObject cheatGuessAttemptChessPiece;

	public static RuleBookPage cheatGuessAttemptRulebookPage;

	public AnimationCurve confirmCheatGuessCurve;

	public Transform confirmGuessHolder;

	private bool gameIsOver;

	public GameObject retryHolder;

	public GuessButtonBar retryButtonBar;

	public Transform fogLeft;

	public Transform fogRight;

	public ParticleSystem fogLeftParticle;

	public ParticleSystem fogRightParticle;

	public ObjectShake bookShake;

	public Transform bookTransform;

	public Button LeftFlipButton;

	public Button rightFlipButton;

	public int startPageIndex;

	public LocalizedString whiteString;

	public LocalizedString blackString;

	public LocalizedString chessPieceString;

	public LocalizedString violatedRuleString;

	public LocalizedString accusePromptString;

	public LocalizedString youMayCheatString;

	public LocalizedString falseAccusationString;

	public LocalizedString youCheatedString;

	public void Awake()
	{
		isAttemptingCheatGuess = false;
		isConfirmingCheatGuess = false;
		cheatGuessAttemptChessPiece = null;
		cheatGuessAttemptRulebookPage = null;
		cheatGuessText.text = accusePromptString.GetLocalizedString();
		ruleBookScreens.InsertRange(0, rulebookTableOfContents.GenerateTableOfContents(ruleBookScreens, bookTransform));
		currentRuleBookScreen = ruleBookScreens[startPageIndex];
	}

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
		ruleBookFogManager = Object.FindObjectOfType<RulebookFogManager>();
		ruleBookFogManager.ruleBookScreenManager = this;
		fogLeftParticle.Play();
		fogRightParticle.Play();
		leftPageImage.sprite = currentRuleBookScreen.ruleBookPages[0].localizedSprite.LoadAsset();
		rightPageImage.sprite = currentRuleBookScreen.ruleBookPages[1].localizedSprite.LoadAsset();
		UpdateBookArrows(ruleBookScreens.IndexOf(currentRuleBookScreen));
	}

	public void Update()
	{
		if (!isFlipping && pageFlipInputBuffer.Count > 0)
		{
			StartCoroutine(TransitionToCurrentScreen(pageFlipInputBuffer[0]));
			pageFlipInputBuffer.RemoveAt(0);
		}
		if (ChessMatchManager.colorHasWon)
		{
			if (Input.GetKeyDown("y"))
			{
				OnRetryButton();
			}
			if (Input.GetKeyDown("n"))
			{
				OnExitButton();
			}
			if (!gameIsOver)
			{
				gameIsOver = true;
				OnGameOver();
			}
			return;
		}
		if (isConfirmingCheatGuess)
		{
			if (Input.GetKeyDown("y"))
			{
				OnCheatGuessConfirmButton();
			}
			if (Input.GetKeyDown("n"))
			{
				OnCheatGuessCancelButton();
			}
		}
		if (ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.Black)
		{
			return;
		}
		if (Input.GetKeyDown("space"))
		{
			if (isAttemptingCheatGuess)
			{
				OnCheatGuessButton();
			}
			else if (!isConfirmingCheatGuess)
			{
				StartCheatGuessAttempt();
			}
		}
		if (!isAttemptingCheatGuess)
		{
			return;
		}
		StartCoroutine(cheatGuessTextShake.Shake(0.15f, 1.5f));
		string text = "";
		string localizedString = chessPieceString.GetLocalizedString();
		string text2 = "+ " + violatedRuleString.GetLocalizedString();
		if (cheatGuessAttemptChessPiece != null)
		{
			switch (cheatGuessAttemptChessPiece.pieceColor)
			{
			case ChessMatchManager.ChessColor.Utility:
				text = "";
				break;
			case ChessMatchManager.ChessColor.White:
				text = whiteString.GetLocalizedString();
				break;
			case ChessMatchManager.ChessColor.Black:
				text = blackString.GetLocalizedString();
				break;
			}
			localizedString = cheatGuessAttemptChessPiece.pieceData.pieceNameString.GetLocalizedString();
		}
		if (cheatGuessAttemptRulebookPage != null)
		{
			text2 = cheatGuessAttemptRulebookPage.ruleBreakString.GetLocalizedString();
			if (ruleBookFogManager.CheckIfPageIsFogged(cheatGuessAttemptRulebookPage))
			{
				text2 = "?";
			}
		}
		string text3 = (text + " " + localizedString + " " + text2).ToUpper();
		if (cheatGuessText.text != text3)
		{
			cheatGuessText.text = text3;
		}
		if (cheatGuessAttemptChessPiece != null && cheatGuessAttemptRulebookPage != null && !isConfirmingCheatGuess && !isAnimatingAttempingCheatGuess)
		{
			StartCoroutine(StartCheatGuessConfirmation());
		}
	}

	public IEnumerator StartCheatGuessConfirmation()
	{
		isAnimatingAttempingCheatGuess = true;
		chessMatchManager.whiteFlash.SetActive(value: true);
		chessMatchManager.whiteFlash.GetComponent<SpriteRenderer>().color = outlineColor.globalColor;
		Keyframe[] keys = confirmCheatGuessCurve.keys;
		keys[0].value = cheatGuessHolder.localPosition.y;
		confirmCheatGuessCurve.keys = keys;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < confirmCheatGuessCurve[confirmCheatGuessCurve.length - 1].time)
		{
			cheatGuessHolder.transform.localPosition = new Vector3(cheatGuessHolder.transform.localPosition.x, confirmCheatGuessCurve.Evaluate(elapsedSeconds), cheatGuessHolder.transform.localPosition.z);
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		yield return new WaitForSeconds(1f);
		isAnimatingAttempingCheatGuess = false;
		isConfirmingCheatGuess = true;
		confirmGuessHolder.gameObject.SetActive(value: true);
		yield return null;
	}

	public IEnumerator StopCheatGuessConfirmation()
	{
		confirmGuessHolder.gameObject.SetActive(value: false);
		chessMatchManager.whiteFlash.SetActive(value: false);
		cheatGuessHolder.transform.localPosition = new Vector3(cheatGuessHolder.transform.localPosition.x, confirmCheatGuessCurve[0].value, cheatGuessHolder.transform.localPosition.z);
		StopCheatGuessAttempt();
		isConfirmingCheatGuess = false;
		yield return null;
	}

	public void OnCheatGuessConfirmButton()
	{
		isConfirmingCheatGuess = false;
		confirmGuessHolder.gameObject.SetActive(value: false);
		bool guessedCorrect = chessMatchManager.CheckIfPlayerGuessedCheat(cheatGuessAttemptChessPiece, cheatGuessAttemptRulebookPage);
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_confirm);
		StopCheatGuessAttempt();
		StartCoroutine(CheatGuessResultScreen(guessedCorrect));
	}

	public void OnCheatGuessCancelButton()
	{
		StartCoroutine(StopCheatGuessConfirmation());
	}

	public void StartCheatGuessAttempt()
	{
		if (!chessMatchManager.nextPlayerWonCheat)
		{
			isAttemptingCheatGuess = true;
			cheatGuessText.color = dangerColor.globalColor;
			cheatGuessAttemptChessPiece = null;
			StartCoroutine(guessButtonBar.GrowIncreaseBar());
			if (!ruleBookInteraction.isInspectingBook)
			{
				ruleBookInteraction.StartInspecting();
			}
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_in);
		}
	}

	public void StopCheatGuessAttempt()
	{
		isAttemptingCheatGuess = false;
		if (!chessMatchManager.nextPlayerWonCheat)
		{
			cheatGuessText.text = accusePromptString.GetLocalizedString();
		}
		cheatGuessText.color = whiteColor.globalColor;
		if (cheatGuessAttemptChessPiece != null)
		{
			cheatGuessAttemptChessPiece.StopHighlight();
		}
		cheatGuessAttemptChessPiece = null;
		StartCoroutine(guessButtonBar.GrowDecreaseBar());
		leftPageImage.color = outlineColor.globalColor;
		rightPageImage.color = outlineColor.globalColor;
		cheatGuessAttemptRulebookPage = null;
	}

	public void OnCheatGuessButton()
	{
		if (!isConfirmingCheatGuess && !isAnimatingAttempingCheatGuess && !ChessMatchManager.colorHasWon && ChessMatchManager.currentTurnColor != ChessMatchManager.ChessColor.Black)
		{
			if (!isAttemptingCheatGuess)
			{
				StartCheatGuessAttempt();
			}
			else
			{
				StopCheatGuessAttempt();
			}
		}
	}

	public void OnLeftPageClick()
	{
		if (isConfirmingCheatGuess || isAnimatingAttempingCheatGuess || !ruleBookInteraction.isInspectingBook || (ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.Black && !ChessMatchManager.colorHasWon))
		{
			return;
		}
		if (isAttemptingCheatGuess)
		{
			if (cheatGuessAttemptRulebookPage != currentRuleBookScreen.ruleBookPages[0])
			{
				leftPageImage.color = dangerColor.globalColor;
				rightPageImage.color = outlineColor.globalColor;
				cheatGuessAttemptRulebookPage = currentRuleBookScreen.ruleBookPages[0];
				if (cheatGuessAttemptChessPiece == null)
				{
					PlayFirstSelectedSound();
				}
				else
				{
					PlaySecondSelectedSound();
				}
			}
			else
			{
				cheatGuessAttemptRulebookPage = null;
				leftPageImage.color = outlineColor.globalColor;
			}
		}
		else
		{
			SwitchScreenLeft();
		}
	}

	public void OnRightPageClick()
	{
		if (isConfirmingCheatGuess || isAnimatingAttempingCheatGuess || !ruleBookInteraction.isInspectingBook || (ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.Black && !ChessMatchManager.colorHasWon))
		{
			return;
		}
		if (isAttemptingCheatGuess)
		{
			if (cheatGuessAttemptRulebookPage != currentRuleBookScreen.ruleBookPages[1])
			{
				leftPageImage.color = outlineColor.globalColor;
				rightPageImage.color = dangerColor.globalColor;
				cheatGuessAttemptRulebookPage = currentRuleBookScreen.ruleBookPages[1];
				if (cheatGuessAttemptChessPiece == null)
				{
					PlayFirstSelectedSound();
				}
				else
				{
					PlaySecondSelectedSound();
				}
			}
			else
			{
				cheatGuessAttemptRulebookPage = null;
				rightPageImage.color = outlineColor.globalColor;
			}
		}
		else
		{
			SwitchScreenRight();
		}
	}

	public void OnReturnToFirstPage()
	{
		FlipToSpecificPage(ruleBookScreens[0]);
	}

	public void SwitchScreenLeft()
	{
		pageFlipInputBuffer.Add(-1);
	}

	public void SwitchScreenRight()
	{
		pageFlipInputBuffer.Add(1);
	}

	public IEnumerator TransitionToCurrentScreen(int indexShift)
	{
		bool flipX = false;
		if (indexShift < 0)
		{
			flipX = true;
		}
		int currentScreenIndex = ruleBookScreens.IndexOf(currentRuleBookScreen);
		if (currentScreenIndex + indexShift >= 0 && currentScreenIndex + indexShift <= ruleBookScreens.Count - 1)
		{
			leftPageImage.color = outlineColor.globalColor;
			rightPageImage.color = outlineColor.globalColor;
			cheatGuessAttemptRulebookPage = null;
			isFlipping = true;
			RuleBookScreenData nextScreen = ruleBookScreens[currentScreenIndex + indexShift];
			pageFlipAnimator.gameObject.SetActive(value: true);
			pageFlipOutlineAnimator.gameObject.SetActive(value: true);
			pageFlipAnimator.GetComponent<SpriteRenderer>().flipX = flipX;
			pageFlipOutlineAnimator.GetComponent<SpriteRenderer>().flipX = flipX;
			pageFlipAnimator.Play("Base Layer." + pageFlipAnimation.name, 0, 0f);
			pageFlipOutlineAnimator.Play("Base Layer." + pageFlipOutlineAnimation.name, 0, 0f);
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_rulebook_page_flip);
			if (flipX)
			{
				UpdateFogLeft(nextScreen.ruleBookPages[0]);
				leftPageImage.sprite = nextScreen.ruleBookPages[0].localizedSprite.LoadAsset();
				UpdateContentLinksLeft(currentScreenIndex, indexShift);
			}
			else
			{
				UpdateFogRight(nextScreen.ruleBookPages[1]);
				rightPageImage.sprite = nextScreen.ruleBookPages[1].localizedSprite.LoadAsset();
				UpdateContentLinksRight(currentScreenIndex, indexShift);
			}
			yield return new WaitForSeconds(pageFlipAnimation.length);
			if (flipX)
			{
				UpdateFogRight(nextScreen.ruleBookPages[1]);
				rightPageImage.sprite = nextScreen.ruleBookPages[1].localizedSprite.LoadAsset();
				UpdateContentLinksRight(currentScreenIndex, indexShift);
			}
			else
			{
				UpdateFogLeft(nextScreen.ruleBookPages[0]);
				leftPageImage.sprite = nextScreen.ruleBookPages[0].localizedSprite.LoadAsset();
				UpdateContentLinksLeft(currentScreenIndex, indexShift);
			}
			UpdateBookArrows(currentScreenIndex + indexShift);
			currentRuleBookScreen = nextScreen;
			pageFlipAnimator.gameObject.SetActive(value: false);
			pageFlipOutlineAnimator.gameObject.SetActive(value: false);
			isFlipping = false;
		}
	}

	public void UpdateContentLinksLeft(int currentScreenIndex, int indexShift)
	{
		if (ruleBookScreens[currentScreenIndex].isTableOfContents)
		{
			rulebookTableOfContents.DisableLinkByScreen(ruleBookScreens[currentScreenIndex], doRight: false);
		}
		if (ruleBookScreens[currentScreenIndex + indexShift].isTableOfContents)
		{
			rulebookTableOfContents.EnableLinksByScreen(ruleBookScreens[currentScreenIndex + indexShift], doRight: false);
		}
	}

	public void UpdateContentLinksRight(int currentScreenIndex, int indexShift)
	{
		if (ruleBookScreens[currentScreenIndex].isTableOfContents)
		{
			rulebookTableOfContents.DisableLinkByScreen(ruleBookScreens[currentScreenIndex], doRight: true);
		}
		if (ruleBookScreens[currentScreenIndex + indexShift].isTableOfContents)
		{
			rulebookTableOfContents.EnableLinksByScreen(ruleBookScreens[currentScreenIndex + indexShift], doRight: true);
		}
	}

	public void UpdateBookArrows(int screenIndex)
	{
		if (screenIndex <= 0)
		{
			leftBookArrow.color = new Color(leftBookArrow.color.r, leftBookArrow.color.g, leftBookArrow.color.b, 0.25f);
		}
		else
		{
			leftBookArrow.color = new Color(leftBookArrow.color.r, leftBookArrow.color.g, leftBookArrow.color.b, 1f);
		}
		if (screenIndex >= ruleBookScreens.Count - 1)
		{
			rightBookArrow.color = new Color(rightBookArrow.color.r, rightBookArrow.color.g, rightBookArrow.color.b, 0.25f);
		}
		else
		{
			rightBookArrow.color = new Color(rightBookArrow.color.r, rightBookArrow.color.g, rightBookArrow.color.b, 1f);
		}
	}

	public void UpdateFogLeft(RuleBookPage page)
	{
		if (ruleBookFogManager.CheckIfPageIsFogged(page))
		{
			fogLeft.gameObject.SetActive(value: true);
			RandomizeFogPosition(fogLeft.transform);
			fogLeftParticle.Play();
		}
		else
		{
			fogLeft.gameObject.SetActive(value: false);
		}
	}

	public void UpdateFogRight(RuleBookPage page)
	{
		if (ruleBookFogManager.CheckIfPageIsFogged(page))
		{
			fogRight.gameObject.SetActive(value: true);
			RandomizeFogPosition(fogRight.transform);
			fogRightParticle.Play();
		}
		else
		{
			fogRight.gameObject.SetActive(value: false);
		}
	}

	public void RandomizeFogPosition(Transform fog)
	{
		float num = 0.125f;
		Vector3 localPosition = new Vector3(Random.Range(0f - num, num), Random.Range(0f - num, num), fog.transform.localPosition.z);
		fog.transform.localPosition = localPosition;
	}

	public RuleBookPage FindCheatReasonInRuleBook(List<ChessMatchManager.ChessCheatReason> cheatReasons, ChessPieceData.ChessPieceType cheatType, bool doReverseCheat)
	{
		RuleBookScreenData ruleBookScreenData = ruleBookScreens[startPageIndex + 1];
		RuleBookPage result = ruleBookScreenData.ruleBookPages[1];
		int num = 0;
		if (!doReverseCheat)
		{
			for (int i = 0; i <= ruleBookScreens.Count - 1; i++)
			{
				foreach (ChessMatchManager.ChessCheatReason cheatReason in cheatReasons)
				{
					foreach (RuleBookPage ruleBookPage in ruleBookScreens[i].ruleBookPages)
					{
						int num2 = 0;
						if (ruleBookPage.ruleCheatReason == cheatReason)
						{
							num2 = ruleBookPage.ruleCheatScore;
							if (!ruleBookPage.checkForSpecificPiece)
							{
								num2 *= 2;
							}
						}
						if (ruleBookPage.ruleSpecificPiece == cheatType && ruleBookPage.checkForSpecificPiece)
						{
							num2 += ruleBookPage.ruleCheatScore;
						}
						if (num2 > num)
						{
							result = ruleBookPage;
							ruleBookScreenData = ruleBookScreens[i];
							num = num2;
						}
					}
				}
			}
		}
		FlipToSpecificPage(ruleBookScreenData);
		return result;
	}

	public void FlipToSpecificPage(RuleBookScreenData ruleBookScreen)
	{
		int num = ruleBookScreens.IndexOf(currentRuleBookScreen);
		int num2 = ruleBookScreens.IndexOf(ruleBookScreen);
		int num3 = 0;
		foreach (int item in pageFlipInputBuffer)
		{
			num3 += item;
		}
		int num4 = num2 - (num + num3);
		int num5 = Mathf.Abs(num4);
		bool flag = num4 < 0;
		for (int i = 0; i < num5; i++)
		{
			if (flag)
			{
				pageFlipInputBuffer.Add(-1);
			}
			else
			{
				pageFlipInputBuffer.Add(1);
			}
		}
		if (!ruleBookInteraction.isInspectingBook)
		{
			ruleBookInteraction.StartInspecting();
		}
	}

	public IEnumerator CheatGuessResultScreen(bool guessedCorrect)
	{
		showingCheatGuessResult = true;
		Vector3 textOriginPosition = new Vector3(cheatGuessHolder.transform.localPosition.x, confirmCheatGuessCurve[0].value, cheatGuessHolder.transform.localPosition.z);
		cheatGuessHolder.transform.localPosition = Vector3.zero;
		cheatGuessText.gameObject.SetActive(value: false);
		chessMatchManager.whiteFlash.SetActive(value: true);
		chessMatchManager.whiteFlash.GetComponent<SpriteRenderer>().color = outlineColor.globalColor;
		ChessMatchManager.noMoveAllowed = true;
		yield return new WaitForSeconds(2f);
		cheatGuessText.gameObject.SetActive(value: true);
		if (guessedCorrect)
		{
			cheatGuessText.text = youMayCheatString.GetLocalizedString();
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_correct);
		}
		else
		{
			cheatGuessText.text = falseAccusationString.GetLocalizedString();
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_false);
		}
		yield return new WaitForSeconds(1f);
		cheatGuessHolder.transform.localPosition = textOriginPosition;
		chessMatchManager.whiteFlash.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		showingCheatGuessResult = false;
	}

	public IEnumerator CheatScreen()
	{
		showingCheatGuessResult = true;
		yield return new WaitForSeconds(1f);
		Vector3 textOriginPosition = cheatGuessHolder.transform.localPosition;
		cheatGuessHolder.transform.localPosition = Vector3.zero;
		cheatGuessText.gameObject.SetActive(value: false);
		chessMatchManager.whiteFlash.SetActive(value: true);
		chessMatchManager.whiteFlash.GetComponent<SpriteRenderer>().color = outlineColor.globalColor;
		yield return new WaitForSeconds(1f);
		cheatGuessText.gameObject.SetActive(value: true);
		cheatGuessText.text = youCheatedString.GetLocalizedString();
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_false);
		yield return new WaitForSeconds(1f);
		cheatGuessHolder.transform.localPosition = textOriginPosition;
		chessMatchManager.whiteFlash.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		showingCheatGuessResult = false;
	}

	public void PlayFirstSelectedSound()
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_chesspiece);
	}

	public void PlaySecondSelectedSound()
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_accusation_rulebreak);
	}

	public void OnGameOver()
	{
		SaveSystem.currentPlayerSaveData.overworldState = OverworldTrollManager.OverworldState.ACT_II;
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		cheatGuessText.transform.parent.gameObject.SetActive(value: false);
		retryHolder.gameObject.SetActive(value: true);
		StartCoroutine(retryButtonBar.GrowIncreaseBar());
	}

	public void OnRetryButton()
	{
		chessMatchManager.canvas.gameObject.SetActive(value: false);
		StartCoroutine(Retry());
	}

	public void OnExitButton()
	{
		chessMatchManager.canvas.gameObject.SetActive(value: false);
		StartCoroutine(Exit());
	}

	public IEnumerator Retry()
	{
		yield return new WaitForSeconds(transitionManager.StartTransition(TransitionManager.TransitionState.Out) + 0.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public IEnumerator Exit()
	{
		yield return new WaitForSeconds(transitionManager.StartTransition(TransitionManager.TransitionState.Out) + 0.5f);
		SceneManager.GetActiveScene();
		SceneManager.LoadScene("Overworld");
	}
}
