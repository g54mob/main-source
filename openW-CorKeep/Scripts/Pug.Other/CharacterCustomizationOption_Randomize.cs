using UnityEngine;

public class CharacterCustomizationOption_Randomize : RadicalMenuOption
{
	public CharacterCustomizationMenu characterCustomizationMenu;

	public Animator animator;

	public GameObject selectedMarker;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		characterCustomizationMenu.Randomize();
		characterCustomizationMenu.roleSelection.RandomizeRole();
		animator.SetTrigger(-1158233568);
	}
}
