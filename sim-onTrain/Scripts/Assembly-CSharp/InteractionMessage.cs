using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionMessage : MonoBehaviour
{
	public TextMeshProUGUI keyCodeText;

	public TextMeshProUGUI messageText;

	public Image loadingImage;

	public Image keyIconImage;

	[SerializeField]
	private float disabledAlpha = 0.3f;

	private InteractionData currentInteractionData;

	private float currentHoldTime;

	private RectTransform rectTransform;

	private float padding;

	public bool isHolding { get; private set; }

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		padding = Mathf.Abs(messageText.rectTransform.sizeDelta.x);
	}

	public void ShowMessage(InteractionData interactionData)
	{
		currentInteractionData = interactionData;
		keyCodeText.text = GetKeyCodeDisplayText(interactionData.keyCode);
		messageText.text = interactionData.message;
		Color color = interactionData.messageColor ?? Color.white;
		float a = (interactionData.isDisabled ? disabledAlpha : 1f);
		messageText.color = new Color(color.r, color.g, color.b, a);
		keyCodeText.color = new Color(keyCodeText.color.r, keyCodeText.color.g, keyCodeText.color.b, a);
		SetMouseIcon(interactionData.keyCode);
		if (keyIconImage != null && keyIconImage.gameObject.activeSelf)
		{
			keyIconImage.color = new Color(keyIconImage.color.r, keyIconImage.color.g, keyIconImage.color.b, a);
		}
		ResizeToFitText();
		ResetLoading();
	}

	public void ShowMessage(KeyCode keyCode, string message)
	{
		currentInteractionData = new InteractionData(keyCode, message);
		keyCodeText.text = GetKeyCodeDisplayText(keyCode);
		messageText.text = message;
		messageText.color = Color.white;
		SetMouseIcon(keyCode);
		ResizeToFitText();
		ResetLoading();
	}

	private void ResizeToFitText()
	{
		messageText.ForceMeshUpdate();
		float preferredWidth = messageText.preferredWidth;
		float num = messageText.fontSize * 1.5f;
		float x = preferredWidth + padding + num;
		rectTransform.sizeDelta = new Vector2(x, rectTransform.sizeDelta.y);
	}

	private void SetMouseIcon(KeyCode keyCode)
	{
		if (!(keyIconImage == null))
		{
			Sprite mouseSprite = GetMouseSprite(keyCode);
			if (mouseSprite != null)
			{
				keyIconImage.sprite = mouseSprite;
				keyIconImage.gameObject.SetActive(value: true);
			}
			else
			{
				keyIconImage.gameObject.SetActive(value: false);
			}
		}
	}

	private Sprite GetMouseSprite(KeyCode keyCode)
	{
		if (InteractionPanel.Instance == null)
		{
			return null;
		}
		return keyCode switch
		{
			KeyCode.Mouse0 => InteractionPanel.Instance.mouseLeftClickIcon, 
			KeyCode.Mouse1 => InteractionPanel.Instance.mouseRightClickIcon, 
			KeyCode.Mouse2 => InteractionPanel.Instance.mouseMiddleClickIcon, 
			_ => null, 
		};
	}

	private string GetKeyCodeDisplayText(KeyCode keyCode)
	{
		if ((uint)(keyCode - 323) <= 6u)
		{
			return "";
		}
		return keyCode.ToString();
	}

	private void Update()
	{
		if (currentInteractionData == null || !base.gameObject.activeInHierarchy || currentInteractionData.isDisabled)
		{
			return;
		}
		if (currentInteractionData.hasHoldAction)
		{
			if (Input.GetKeyDown(currentInteractionData.keyCode))
			{
				currentInteractionData.onKeyDown?.Invoke();
			}
			if (Input.GetKey(currentInteractionData.keyCode))
			{
				if (!isHolding)
				{
					isHolding = true;
					currentHoldTime = 0f;
				}
				currentHoldTime += Time.deltaTime;
				float num = currentHoldTime / currentInteractionData.holdDuration;
				ShowLoading(num);
				if (InteractionPanel.Instance != null)
				{
					InteractionPanel.Instance.ShowCenterProgress(num);
				}
				if (currentHoldTime >= currentInteractionData.holdDuration)
				{
					currentInteractionData.onHoldComplete?.Invoke();
					ResetLoading();
					isHolding = false;
				}
			}
			else if (Input.GetKeyUp(currentInteractionData.keyCode))
			{
				Debug.Log("Key released - calling onKeyUp");
				currentInteractionData.onKeyUp?.Invoke();
				ResetLoading();
				isHolding = false;
			}
		}
		else if (Input.GetKeyDown(currentInteractionData.keyCode))
		{
			currentInteractionData.onHoldComplete?.Invoke();
		}
	}

	public void ShowLoading(float value)
	{
		loadingImage.fillAmount = value;
	}

	public void ResetLoading()
	{
		loadingImage.fillAmount = 0f;
		currentHoldTime = 0f;
		isHolding = false;
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideCenterProgress();
		}
	}

	private void OnDisable()
	{
		ResetLoading();
	}
}
