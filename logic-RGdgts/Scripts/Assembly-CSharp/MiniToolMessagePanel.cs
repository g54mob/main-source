using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MiniToolMessagePanel : MonoBehaviour
{
	public MiniTool miniTool;

	public CanvasGroup canvasGroup;

	public Image backgorund;

	public RetroUIText uiText;

	private RectTransform rectTransform;

	private Sequence tween;

	private float scroll;

	private float scrollVel;

	private float startTime;

	private MiniTool.MessageType messageType;

	public bool persistent { get; private set; }

	public string message { get; private set; }

	public bool IsShowing => false;

	private void Awake()
	{
	}

	public void Hide()
	{
	}

	private void _Hide()
	{
	}

	public void Show(string message, MiniTool.MessageType messageType, bool persistent)
	{
	}

	private void _Animate()
	{
	}

	private void Update()
	{
	}
}
