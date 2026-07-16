using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
	public Button button;

	public DifficultySetting difficulty;

	public GameObject lockIcon;

	public void Initialize(DifficultySetting setting, Action<DifficultySetting> onClickCallback)
	{
		difficulty = setting;
		button = GetComponent<Button>();
		button.onClick.AddListener(delegate
		{
			onClickCallback(difficulty);
		});
	}
}
