using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class HatSelection : MonoBehaviour
{
	public HatSelectionPopupWindow hatSelectionPopupWindow;

	public Texture noHatTexture;

	public LocalizedString localizedNoHat;

	public ButtonTextWrapper textWrapper;

	public TextSizer textSizer;

	private static int index;

	public TextMeshProUGUI t_hatName;

	public RawImage i_hatIcon;

	private List<HatData> availableHats;

	private ECharacter character;

	public HatData selectedHatData;

	public static Action A_HatChanged;

	public static Action<HatData> A_HatHover;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void CheckInit(bool force)
	{
	}

	public void HoverHat(HatData hatData)
	{
	}

	public void SelectHat(HatData hatData)
	{
	}

	private void UpdateHatText()
	{
	}

	private void OnSelectCharacter(MyButtonCharacter characterButton)
	{
	}

	private int NumSongs()
	{
		return 0;
	}
}
