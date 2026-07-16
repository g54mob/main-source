using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupUI : SlidingUIElement
{
	private struct Popup
	{
		public float slideInTimer;

		public float slideOutTimer;

		public float stayTimer;

		public Sprite img;

		public string text;

		public string name;

		public EnhancementType enhancementType;

		public Rarity rarity;
	}

	[SerializeField]
	protected float stayTime;

	protected float stayTimer = 5f;

	private Queue<Popup> popupQueue = new Queue<Popup>();

	[Header("UI Elements")]
	[SerializeField]
	private Image popupImage;

	[SerializeField]
	private Image popupBorder;

	[SerializeField]
	private Image popupMask;

	[SerializeField]
	private Rarity popupRarity;

	[SerializeField]
	private TextMeshProUGUI popupText;

	[SerializeField]
	private TextMeshProUGUI popupName;

	[SerializeField]
	private SlidingUIElement popupMain;

	[SerializeField]
	private Animator mainAnimator;

	[SerializeField]
	private Animator cogsAnimator;

	[SerializeField]
	private List<Sprite> enhancementBorders;

	[SerializeField]
	private List<Sprite> enhancementMasks;

	private Popup currentPopup;

	private bool readyToDisplay;

	private bool slideInFinished;

	private bool slideOutStarted;

	private bool slideOutFinished;

	private bool slideInStarted;

	private void Awake()
	{
		popupMain.OnSlideInFinished += MainSlideInFinished;
		popupMain.OnSlideOutFinished += MainSlideOutFinished;
	}

	private new void Update()
	{
		if (popupQueue.Count == 0 || !readyToDisplay)
		{
			return;
		}
		if (currentPopup.slideInTimer < slideInTime)
		{
			if (slideInStarted)
			{
				DisplaySlideInStarted();
			}
			slideInStarted = true;
			slideInFinished = false;
			currentPopup.slideInTimer += Time.unscaledDeltaTime;
			float t = Mathf.Clamp01(currentPopup.slideInTimer / slideInTime);
			rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
			return;
		}
		if (currentPopup.stayTimer < stayTime)
		{
			if (!slideInFinished)
			{
				DisplaySlideInFinished();
			}
			slideInStarted = false;
			slideInFinished = true;
			currentPopup.stayTimer += Time.unscaledDeltaTime;
			return;
		}
		if (currentPopup.slideOutTimer < slideOutTime)
		{
			if (!slideOutStarted)
			{
				DisplaySlideOutStarted();
			}
			slideOutFinished = false;
			slideOutStarted = true;
			currentPopup.slideOutTimer += Time.unscaledDeltaTime;
			float t2 = Mathf.Clamp01(currentPopup.slideOutTimer / slideOutTime);
			rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t2);
			return;
		}
		slideOutStarted = false;
		if (!slideOutFinished)
		{
			DisplaySlideOutFinished();
		}
		slideOutFinished = true;
		popupQueue.Dequeue();
		if (popupQueue.Count > 0)
		{
			SetNextPopup();
		}
	}

	public void ShowPopup(Enhancement enhancement, string text)
	{
		if (!popupMain.SlidingOutRunning)
		{
			popupMain.SlideIn();
		}
		EnhancementType enhancementType = EnhancementType.Upgrade;
		if (enhancement is EnhancementModule)
		{
			enhancementType = EnhancementType.Module;
		}
		else if (enhancement is EnhancementUpgrade enhancementUpgrade)
		{
			enhancementType = ((!enhancementUpgrade.IsRelic) ? EnhancementType.Upgrade : EnhancementType.Relic);
		}
		popupQueue.Enqueue(new Popup
		{
			slideInTimer = 0f,
			stayTimer = 0f,
			slideOutTimer = 0f,
			img = enhancement.Icon,
			text = text,
			name = enhancement.NameKey.GetLocalizedString(),
			enhancementType = enhancementType,
			rarity = enhancement.Rarity
		});
		if (popupQueue.Count == 1)
		{
			SetNextPopup();
		}
	}

	private void SetNextPopup()
	{
		currentPopup = popupQueue.Peek();
		popupImage.sprite = currentPopup.img;
		popupText.text = currentPopup.text;
		popupName.text = currentPopup.name;
		popupRarity = currentPopup.rarity;
		switch (currentPopup.enhancementType)
		{
		case EnhancementType.Module:
			popupBorder.sprite = enhancementBorders[0];
			popupMask.sprite = enhancementMasks[0];
			break;
		case EnhancementType.Upgrade:
			popupBorder.sprite = enhancementBorders[(int)(1 + currentPopup.rarity)];
			popupMask.sprite = enhancementMasks[1];
			break;
		case EnhancementType.Relic:
			popupBorder.sprite = enhancementBorders[(int)(5 + currentPopup.rarity)];
			popupMask.sprite = enhancementMasks[2];
			break;
		case EnhancementType.General:
			break;
		}
	}

	private void MainSlideInFinished()
	{
		readyToDisplay = true;
	}

	private void MainSlideOutFinished()
	{
		readyToDisplay = false;
	}

	private void DisplaySlideInFinished()
	{
		cogsAnimator.Play("PopupCogsIdle");
	}

	private void DisplaySlideOutStarted()
	{
		cogsAnimator.Play("PopupCogsBackwards");
		mainAnimator.Play("PopupMainIdle");
	}

	private void DisplaySlideOutFinished()
	{
		if (popupQueue.Count == 1)
		{
			cogsAnimator.Play("PopupCogsIdle");
			popupMain.SlideOut();
		}
	}

	private void DisplaySlideInStarted()
	{
		mainAnimator.Play("PopupMainRunning");
		cogsAnimator.Play("PopupCogsForwards");
	}
}
