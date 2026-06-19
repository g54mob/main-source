using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldMessage : MonoBehaviour
{
	public Image iconRef;

	public TextMeshProUGUI textRef;

	public GameObject iconHolderRef;

	public Canvas canvasRef;

	private float startDelay;

	private float totalFadeTime = 0.75f;

	private Vector3 mov = new Vector3(0f, 1f, 0f);

	private GUIManagerPens guiRef;

	private void Awake()
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
	}

	private void Start()
	{
		StartCoroutine(FadeRoutine());
	}

	private void Update()
	{
		if (canvasRef == null)
		{
			return;
		}
		if (PauseController.IsUIEnabled() || (guiRef != null && guiRef.IsGUIHiddenDueToPassiveMode()))
		{
			if (!canvasRef.enabled)
			{
				canvasRef.enabled = true;
			}
		}
		else
		{
			canvasRef.enabled = false;
		}
	}

	public void SetFadeTime(float newTime)
	{
		totalFadeTime = newTime;
	}

	public void SetStartDelay(float newDelay)
	{
		startDelay = newDelay;
	}

	public void SetMov(Vector3 newMov)
	{
		mov = newMov;
	}

	public void SetDisplayColor(Color newColor)
	{
		textRef.color = newColor;
	}

	public void SetDisplayMessage(string newMessage)
	{
		textRef.text = newMessage;
		iconHolderRef.SetActive(value: false);
		textRef.gameObject.SetActive(value: true);
	}

	public void SetDisplayIcon(Sprite newSprite)
	{
		iconRef.sprite = newSprite;
		iconHolderRef.SetActive(value: true);
		textRef.gameObject.SetActive(value: false);
	}

	private IEnumerator FadeRoutine()
	{
		bool iconActiveStatus = iconHolderRef.activeSelf;
		bool textActiveStatus = textRef.gameObject.activeSelf;
		iconHolderRef.SetActive(value: false);
		textRef.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(startDelay);
		iconHolderRef.SetActive(iconActiveStatus);
		textRef.gameObject.SetActive(textActiveStatus);
		float currentFadeTime = totalFadeTime;
		float fadeStart = totalFadeTime / 2f;
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		while (currentFadeTime > 0f)
		{
			currentFadeTime -= Time.deltaTime;
			base.transform.position += mov * Time.deltaTime;
			if (currentFadeTime <= fadeStart)
			{
				textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, currentFadeTime / fadeStart);
			}
			yield return frameWait;
		}
		Object.Destroy(base.gameObject);
	}
}
