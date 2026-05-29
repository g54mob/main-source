using System.Collections.Generic;
using UnityEngine;

public class HatSelectionPopupWindow : Window
{
	public HatSelection hatSelection;

	private List<MyButtonHat> hatButtons;

	public GameObject hatButtonPrefab;

	private HatData selectedHatBeforeOpenWindow;

	public MyButton b_hats;

	private HatData hatDataHover;

	public RectTransform windowRect;

	private new void Update()
	{
	}

	public void FindStartButton(HatData hatData)
	{
	}

	public void RefreshHatButtons(List<HatData> availableHats, HatData selectedHat)
	{
	}

	public void HoverButton(HatData hatData)
	{
	}

	public void StopHoverButton(HatData hatData)
	{
	}

	public void ClickButton(HatData hatData)
	{
	}

	private void CloseWindow()
	{
	}

	private new void OnDisable()
	{
	}
}
