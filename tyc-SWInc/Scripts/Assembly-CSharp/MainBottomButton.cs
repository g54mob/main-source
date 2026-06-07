using System;
using UnityEngine;
using UnityEngine.UI;

public class MainBottomButton : MonoBehaviour
{
	[NonSerialized]
	public GameObject CurrentNothingButton;

	public Button Button;

	public string UnlockMission;

	private bool _pulse;

	private bool _warning;

	public bool Pulse
	{
		get
		{
			return _pulse;
		}
		set
		{
			if (value != _pulse)
			{
				_pulse = value;
				Button.image.color = Color.white;
			}
		}
	}

	public bool Warning
	{
		get
		{
			return _warning;
		}
		set
		{
			if (value != _warning)
			{
				_warning = value;
				Button.image.color = Color.white;
			}
		}
	}

	private void Update()
	{
		if (Warning)
		{
			Button.image.color = Utilities.Blink(Color.white, Color.red, 1f);
		}
		else if (Pulse)
		{
			Button.image.color = Utilities.Blink(Color.white, new Color(0.33f, 0.5f, 1f), 1f);
		}
	}

	public void InitSearchMode()
	{
		if (GameSettings.Instance.EditMode || GameData.EditMode)
		{
			return;
		}
		GUIButton component = GetComponent<GUIButton>();
		Button bb = GetComponent<Button>();
		if (component != null && bb != null && (string.IsNullOrEmpty(UnlockMission) || GameSettings.HasCompletedOrInMission(UnlockMission)))
		{
			GlobalSearchPanel.Instance.AddSearchItem(this, component.ToolTipValue.Loc(), delegate
			{
				bb.onClick.Invoke();
			}, component.ButtonImage.sprite, false, false);
		}
	}

	public void HideMe(GameObject nothingButtonPrefab)
	{
		if (CurrentNothingButton == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(nothingButtonPrefab);
			gameObject.transform.SetParent(base.transform.parent, false);
			gameObject.transform.SetSiblingIndex(base.transform.GetSiblingIndex());
			base.gameObject.SetActive(false);
			CurrentNothingButton = gameObject;
		}
	}

	public void ShowMe()
	{
		if (CurrentNothingButton != null)
		{
			UnityEngine.Object.Destroy(CurrentNothingButton);
			base.gameObject.SetActive(true);
			Pulse = true;
			Button.onClick.AddListener(delegate
			{
				Pulse = false;
				Button.image.color = Color.white;
				Button.onClick.RemoveAllListeners();
			});
		}
	}
}
