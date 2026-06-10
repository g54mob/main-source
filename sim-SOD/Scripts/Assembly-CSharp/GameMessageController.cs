using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMessageController : MonoBehaviour
{
	public enum PingOnComplete
	{
		none = 0,
		lockpicks = 1,
		money = 2
	}

	public RectTransform rect;

	public string displayMessage;

	public TextMeshProUGUI messageText;

	public Image img;

	public JuiceController juice;

	public RectTransform lensFlare;

	public bool isKeyMergeMessage;

	public ProgressBarController keyMergeProgress;

	public bool isSocialCreditMessage;

	public int originalCredit;

	public Sprite checkedSprite;

	public Image puzzleBG;

	public Image namePiece;

	public Image photoPiece;

	public Image voicePiece;

	public Image fingerprintPiece;

	public TextMeshProUGUI socialCreditLevelText;

	public PingOnComplete ping;

	public float progress;

	public float delayProgress;

	public float fadeProgress;

	public float revealProgress;

	public float keyTieProgress;

	public float socCreditProgress;

	private int tiedKeysValue;

	[ReorderableList]
	public List<CanvasRenderer> renderers;

	public RectTransform moveToTargetOnDestroy;

	private void OnEnable()
	{
	}

	public void Setup(Sprite graphic, string message, RectTransform moveToTarget, bool colourOverride = false, Color col = default(Color), PingOnComplete newPing = PingOnComplete.none, Evidence keyTieEvidence = null, List<Evidence.DataKey> newTiedKeys = null, int value = 0)
	{
	}

	public void SocialScoreVisualUpdate(int points)
	{
	}

	private void Update()
	{
	}
}
