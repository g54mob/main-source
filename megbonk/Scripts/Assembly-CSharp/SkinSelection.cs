using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
	public GameObject skinContainerPrefab;

	private List<SkinContainer> containers;

	public MyButton b_confirm;

	private List<SkinData> skins;

	private int currentlySelected;

	private SkinContainer previousSelected;

	public static Action<SkinContainer> A_ForceSkinDisplay;

	private SkinContainer lastSelectedSkinContainer;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnSkinHover(SkinContainer skinContainer)
	{
	}

	private void OnSkinHoverMouse(SkinContainer skinContainer)
	{
	}

	private void OnSkinHoverMouseExit(SkinContainer skinContainer)
	{
	}

	private void SetCurrentlySelected(int index, ECharacter character)
	{
	}

	public void DisableNavigation()
	{
	}

	public void CreateNavigation(Button backButton)
	{
	}

	public void EnableNavigation(Button backButton)
	{
	}

	private void SetConfirmButtonNav()
	{
	}

	public void SetCharacter(MyButtonCharacter charButton)
	{
	}

	public void SetNotUnlocked()
	{
	}
}
