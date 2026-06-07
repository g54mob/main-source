using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_JournalTowerFilterButton : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_FilterName;

	[SerializeField]
	private Button button;

	[SerializeField]
	private eItemFilterType filterType;

	private Action<eItemFilterType, UI_JournalTowerFilterButton> onClickCallback;

	public eItemFilterType FilterType => default(eItemFilterType);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Reset()
	{
	}

	private void OnValidate()
	{
	}

	private void OnClickButton()
	{
	}

	public void Setup(Action<eItemFilterType, UI_JournalTowerFilterButton> onClickCallback)
	{
	}

	private void Start()
	{
	}
}
