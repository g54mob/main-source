using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsWindowUI : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private Scrollbar scrollbar;

	private bool isAutoScroll = true;

	private float speed = 0.02f;

	private float fastSpeed = 0.1f;

	private float currentSpeed;

	private bool pointerDown;

	private void Start()
	{
		MainMenuUI.Instance.OnCreditsButton += MainMenuUI_OnCreditsButton;
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		exitButton.onClick.AddListener(Hide);
		Hide();
	}

	private void OnDestroy()
	{
		MainMenuUI.Instance.OnCreditsButton -= MainMenuUI_OnCreditsButton;
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		exitButton.onClick.RemoveAllListeners();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void MainMenuUI_OnCreditsButton(object sender, EventArgs e)
	{
		Show();
	}

	private void Update()
	{
		if (isAutoScroll)
		{
			if (pointerDown)
			{
				currentSpeed = fastSpeed;
			}
			else
			{
				currentSpeed = speed;
			}
			scrollbar.value = Mathf.MoveTowards(scrollbar.value, 0f, currentSpeed * Time.deltaTime);
		}
	}

	private void Show()
	{
		scrollbar.value = 1f;
		MainMenuUI.Instance.InnerWindowOpen = true;
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		if (base.isActiveAndEnabled)
		{
			scrollbar.value = 1f;
			MainMenuUI.Instance.ToggleMainMenu(value: true);
			MainMenuUI.Instance.InnerWindowOpen = false;
			base.gameObject.SetActive(value: false);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pointerDown = false;
	}
}
