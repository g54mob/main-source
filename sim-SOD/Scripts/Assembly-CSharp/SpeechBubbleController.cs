using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleController : MonoBehaviour
{
	public RectTransform rect;

	public RectTransform bubbleRect;

	public string actualString;

	public TextMeshProUGUI text;

	public float stringReveal;

	public int revealedChars;

	public float distance;

	public float timeStamp;

	public float oncreenTime;

	public float delayProgress;

	public float fadeProgress;

	private bool setFinalText;

	public SpeechController.QueueElement speech;

	public SpeechController speechController;

	public Vector2 sizeTreshold;

	public InterfaceController.AwarenessIcon awarenessIcon;

	public Image backgroundImg;

	public CanvasRenderer bgRend;

	public CanvasRenderer textRend;

	public Vector2 bubbleDesiredSize;

	public bool displayOnScreen;

	public Vector3 desiredPosition;

	public bool isPlayer;

	private bool firstPositionInit;

	private string[] words;

	private int wordsRevealed;

	public void Setup(SpeechController.QueueElement newSpeech, SpeechController newSpeechController)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
