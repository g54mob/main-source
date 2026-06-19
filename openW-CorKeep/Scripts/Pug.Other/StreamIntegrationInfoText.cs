using UnityEngine;

public class StreamIntegrationInfoText : MonoBehaviour
{
	public PugText text;

	public GameObject container;

	public PugText giftCountText;

	public GameObject containerGiftCount;

	private const string YOU_ARE_IN_GUEST_MODE = "youAreInGuestMode";

	public void Awake()
	{
		container.gameObject.SetActive(value: false);
		containerGiftCount.gameObject.SetActive(value: false);
		text.SetText("");
		giftCountText.SetText("");
	}

	private void LateUpdate()
	{
	}

	public void ShowText(string text)
	{
		container.gameObject.SetActive(value: true);
		SetTextAndRender(text);
	}

	public void ShowGiftCountText(string text)
	{
		containerGiftCount.gameObject.SetActive(value: true);
		SetGiftCountTextAndRender(text);
	}

	public void HideText()
	{
		container.gameObject.SetActive(value: false);
		containerGiftCount.gameObject.SetActive(value: false);
	}

	public void SetTextAndRender(string textString)
	{
		text.SetText(textString);
		text.Render();
	}

	public void SetGiftCountTextAndRender(string textString)
	{
		giftCountText.SetText(textString);
		giftCountText.Render();
	}
}
