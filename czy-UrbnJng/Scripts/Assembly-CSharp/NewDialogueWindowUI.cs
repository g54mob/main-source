using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Transform iconScaleTransform;

	[SerializeField]
	private Image iconPhone;

	[SerializeField]
	private Image iconDialogue;

	[SerializeField]
	private TextMeshProUGUI textPhone;

	[SerializeField]
	private TextMeshProUGUI textDialogue;

	private Tween iconAnimation;

	public static NewDialogueWindowUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		DialogueManager.Instance.OnDialogueLeft += DialogueManager_OnDialogueLeft;
		yesButton.onClick.AddListener(ShowNextDialogue);
		Hide();
	}

	private void OnDestroy()
	{
		DialogueManager.Instance.OnDialogueLeft -= DialogueManager_OnDialogueLeft;
		yesButton.onClick.RemoveAllListeners();
	}

	private void DialogueManager_OnDialogueLeft(object sender, DialogueManager.OnDialogueLeftEventArgs e)
	{
		SetupButtonVisual(e.isPhone);
		IconAnimation();
		Show();
	}

	private void ShowNextDialogue()
	{
		DialogueManager.Instance.ShowNextDialogueWithID(1);
		Hide();
	}

	private void SetupButtonVisual(bool isPhone)
	{
		if (isPhone)
		{
			iconPhone.gameObject.SetActive(value: true);
			textPhone.gameObject.SetActive(value: true);
			iconDialogue.gameObject.SetActive(value: false);
			textDialogue.gameObject.SetActive(value: false);
		}
		else
		{
			iconPhone.gameObject.SetActive(value: false);
			textPhone.gameObject.SetActive(value: false);
			iconDialogue.gameObject.SetActive(value: true);
			textDialogue.gameObject.SetActive(value: true);
		}
	}

	private void IconAnimation()
	{
		iconAnimation = iconScaleTransform.DOScale(1.2f, 0.6f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		iconAnimation.Play();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
