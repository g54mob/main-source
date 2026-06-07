using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogueButtonUI : MonoBehaviour
{
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

	private Button button;

	private Sequence showAnimation;

	private Sequence hideAnimation;

	private float yOffset = 200f;

	private Vector3 position;

	private Tween iconAnimation;

	public static NextDialogueButtonUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		position = base.transform.position;
	}

	private void Start()
	{
		button = GetComponentInChildren<Button>();
		DialogueManager.Instance.OnDialogueLeft += DialogueManager_OnDialogueLeft;
		button.onClick.AddListener(delegate
		{
			ShowNextDialogue();
		});
		Hide();
	}

	private void OnDestroy()
	{
		DialogueManager.Instance.OnDialogueLeft -= DialogueManager_OnDialogueLeft;
		button.onClick.RemoveAllListeners();
	}

	private void DialogueManager_OnDialogueLeft(object sender, DialogueManager.OnDialogueLeftEventArgs e)
	{
		SetupButtonVisual(e.isPhone);
		Show();
		ShowAnimation();
		IconAnimation();
		SoundManager.Instance.OnDing();
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

	private void ShowNextDialogue()
	{
		DialogueManager.Instance.ShowNextDialogueWithID(1);
		HideAnimation();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void ShowAnimation()
	{
		showAnimation = DOTween.Sequence();
		base.transform.position = new Vector3(position.x, position.y + yOffset, position.z);
		showAnimation.Append(base.transform.DOMoveY(position.y - 5f, 0.2f).SetEase(Ease.OutSine)).Append(base.transform.DOMoveY(position.y, 0.1f).SetEase(Ease.InOutSine)).Play();
	}

	private void HideAnimation()
	{
		hideAnimation = DOTween.Sequence();
		hideAnimation.Append(base.transform.DOMoveY(base.transform.position.y - 5f, 0.1f).SetEase(Ease.InOutSine)).Append(base.transform.DOMoveY(base.transform.position.y + yOffset, 0.2f).SetEase(Ease.InSine)).AppendCallback(delegate
		{
			Hide();
		})
			.Play();
	}

	private void IconAnimation()
	{
		iconAnimation = iconScaleTransform.DOScale(1.2f, 0.6f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		iconAnimation.Play();
	}
}
