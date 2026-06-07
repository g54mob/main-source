using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_TitleScreenBackgroundEntry : MonoBehaviour
{
	[SerializeField]
	private CoinPage.eBackGroundType backGroundType;

	[SerializeField]
	private Button button;

	[SerializeField]
	private TMP_Text text_DebugName;

	private Action<CoinPage.eBackGroundType> OnBackgroundSelected;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(Action<CoinPage.eBackGroundType> onBackgroundSelected)
	{
	}

	private void OnClick()
	{
	}
}
