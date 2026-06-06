using System;
using UnityEngine;
using UnityEngine.UI;

public class CMTutorialUI : MonoBehaviour
{
	[SerializeField]
	private Button exitButton;

	private void Start()
	{
		exitButton.onClick.AddListener(Hide);
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		Hide();
	}

	private void OnDestroy()
	{
		exitButton.onClick.RemoveAllListeners();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}
}
