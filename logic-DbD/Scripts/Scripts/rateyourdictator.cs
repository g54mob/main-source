using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rateyourdictator : Website
{
	[SerializeField]
	private TMP_InputField reviewInput;

	[SerializeField]
	private Button reviewButton;

	[SerializeField]
	private TextMeshProUGUI buttonText;

	[SerializeField]
	private GameObject notificationPrefab;

	private static bool hasSubmittedReview;

	private static string review;

	private void Awake()
	{
		if (hasSubmittedReview)
		{
			reviewInput.interactable = false;
			reviewButton.interactable = false;
			reviewInput.text = review;
		}
	}

	protected override void Start()
	{
		hasSubmittedReview = Save.GLOBAL_SAVE.rydr;
		base.Start();
		reviewInput.onValueChanged.AddListener(delegate
		{
			reviewButton.interactable = !hasSubmittedReview && reviewInput.text.Length > 0;
			buttonText.color = getTextColor(reviewButton.interactable);
		});
	}

	public void SubmitReview()
	{
		review = reviewInput.text;
		hasSubmittedReview = true;
		Save.GLOBAL_SAVE.rydr = true;
		reviewInput.interactable = false;
		reviewButton.interactable = false;
		buttonText.color = getTextColor(sensitive: false);
		SubmitReviewNotification();
		Save.SaveGame();
	}

	public bool HasSubmittedReview()
	{
		return hasSubmittedReview;
	}

	private Color32 getTextColor(bool sensitive)
	{
		if (!sensitive)
		{
			return new Color32(50, 50, 50, 130);
		}
		return new Color32(0, 0, 0, byte.MaxValue);
	}

	private void SubmitReviewNotification()
	{
		SoundEffectUtils.GetNotificationPlayer().PlayLogin();
		string inputText = "Thanks for submitting your positive review! \nWe'll take a close look at what you wrote.";
		PanelManager.OpenWindow(UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Thank You!", inputText, NotificationHandler.Icon.GENERIC_SUCCESS));
	}
}
