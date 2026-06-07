using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrollDialogManager : MonoBehaviour
{
	private SoundManager soundManager;

	public AudioSource audioSource;

	public Canvas canvas;

	public GameObject dialogBoxPrefab;

	public GameObject textBalloon;

	public GameObject textBalloonPrefab;

	public Vector3 textBalloonOffset;

	public ChessMatchManager chessMatchManager;

	public Transform trollTransform;

	public DialogTopic introductionTopic;

	public List<DialogTopic> rematchAcceptTopics = new List<DialogTopic>();

	public List<DialogTopic> rematchInvitationTopics = new List<DialogTopic>();

	public DialogTopic outroCheaterTopic;

	public DialogTopic outroFairPlayerTopic;

	public List<DialogTopic> discardedTopics = new List<DialogTopic>();

	public List<DialogTopic> startTopics = new List<DialogTopic>();

	public List<DialogTopic> caughtCheatingTopics = new List<DialogTopic>();

	public List<DialogTopic> falseAccusationTopics = new List<DialogTopic>();

	public List<DialogTopic> tauntTopics = new List<DialogTopic>();

	public List<DialogTopic> hintTopics = new List<DialogTopic>();

	public List<DialogTopic> speedChessFailTopics = new List<DialogTopic>();

	public List<DialogTopic> jugglerFailTopics = new List<DialogTopic>();

	public List<DialogTopic> duckBoundBlackTopics = new List<DialogTopic>();

	public List<DialogTopic> duckBoundWhiteTopics = new List<DialogTopic>();

	public List<DialogTopic> duckBoundTrollTopics = new List<DialogTopic>();

	public static bool isInDialog;

	private bool mouseClicked;

	public float topicChance;

	public float topicChanceIncreaseMin;

	public float topicChanceIncreaseMax;

	public void Awake()
	{
		isInDialog = false;
	}

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void Update()
	{
		if (isInDialog && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")))
		{
			mouseClicked = true;
		}
	}

	public IEnumerator PerformDialog(DialogTopic dialogTopic, float delay, bool noAnimation = false, bool cancelStopMovement = false)
	{
		isInDialog = true;
		yield return new WaitForSeconds(0.25f);
		if (textBalloon == null)
		{
			SpawnTextBalloon();
		}
		yield return new WaitForSeconds(delay);
		DialogBox dialogBox = Object.Instantiate(dialogBoxPrefab, canvas.transform.position, Quaternion.identity, canvas.transform).GetComponent<DialogBox>();
		TMP_Text dialogBoxText = dialogBox.dialogBoxText;
		ObjectGrow objectGrow = dialogBox.dialogBoxObjectgrow;
		Coroutine dialogGrowCoroutine = null;
		if (noAnimation)
		{
			dialogBox.dialogBoxSpriteOutline.GetComponent<Animator>().enabled = false;
			dialogBox.dialogBoxSpriteFill.GetComponent<Animator>().enabled = false;
			dialogBox.spriteShake.StartCoroutine(dialogBox.spriteShake.Shake(float.PositiveInfinity, 1f));
		}
		mouseClicked = false;
		foreach (Dialog dialog in dialogTopic.dialogs)
		{
			string dialogString = (dialogBoxText.text = dialog.dialogString.GetLocalizedString());
			dialogBoxText.maxVisibleCharacters = 0;
			dialogGrowCoroutine = StartCoroutine(objectGrow.Grow());
			for (int i = 0; i <= dialogString.Length - 1; i++)
			{
				dialogBoxText.maxVisibleCharacters = i + 1;
				if (!char.IsWhiteSpace(dialogString[i]))
				{
					SoundManager.LoadSoundEffect(base.transform, soundManager.troll_dialog_voice);
					yield return new WaitForSeconds(dialog.dialogSpeed);
				}
				if (mouseClicked && (dialog.canSkip || SpeedrunTimer.doSpeedrunTimer))
				{
					break;
				}
			}
			dialogBoxText.maxVisibleCharacters = dialogString.Length;
			mouseClicked = false;
			yield return new WaitUntil(() => mouseClicked);
			mouseClicked = false;
		}
		dialogBox.spriteShake.enabled = false;
		StopCoroutine(dialogGrowCoroutine);
		if (textBalloon != null)
		{
			Object.Destroy(textBalloon.gameObject);
		}
		Object.Destroy(dialogBox.gameObject);
		ChessMatchManager.noMoveAllowed = false;
		if (cancelStopMovement)
		{
			ChessMatchManager.blockMovement = false;
		}
		isInDialog = false;
	}

	public void SpawnTextBalloon()
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.troll_dialog_alert);
		if (chessMatchManager == null)
		{
			textBalloon = Object.Instantiate(textBalloonPrefab, trollTransform.position + textBalloonOffset, Quaternion.identity, trollTransform);
		}
		else if (chessMatchManager.blackPieces.Count > 0)
		{
			ChessPieceObject chessPieceObject = chessMatchManager.GetPiecesByColorAndType(ChessMatchManager.ChessColor.Black, ChessPieceData.ChessPieceType.King)[0];
			textBalloon = Object.Instantiate(textBalloonPrefab, chessPieceObject.transform.position + textBalloonOffset, Quaternion.identity, chessPieceObject.transform);
		}
	}

	public DialogTopic GetRandomTopic(List<DialogTopic> topicList)
	{
		if (topicList.Count < 1)
		{
			Debug.Log(topicList?.ToString() + " is empty!");
			return null;
		}
		List<DialogTopic> list = new List<DialogTopic>();
		foreach (DialogTopic topic in topicList)
		{
			if (!discardedTopics.Contains(topic))
			{
				list.Add(topic);
			}
		}
		if (list.Count < 1)
		{
			foreach (DialogTopic topic2 in topicList)
			{
				if (discardedTopics.Contains(topic2))
				{
					discardedTopics.Remove(topic2);
					list.Add(topic2);
				}
			}
		}
		DialogTopic dialogTopic = list[Random.Range(0, list.Count)];
		discardedTopics.Add(dialogTopic);
		return dialogTopic;
	}

	public void RollForRandomDialog()
	{
		if (!SpeedrunTimer.doSpeedrunTimer)
		{
			bool flag = false;
			if (Random.Range(0f, 100f) <= topicChance)
			{
				topicChance = 0f;
				flag = true;
			}
			topicChance += Random.Range(topicChanceIncreaseMin, topicChanceIncreaseMax);
			if (flag)
			{
				List<DialogTopic> list = new List<DialogTopic>();
				list.AddRange(tauntTopics);
				list.AddRange(hintTopics);
				StartCoroutine(PerformDialog(GetRandomTopic(list), 0.5f));
			}
		}
	}
}
