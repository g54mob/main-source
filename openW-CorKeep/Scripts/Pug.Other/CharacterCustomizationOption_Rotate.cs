using UnityEngine;

public class CharacterCustomizationOption_Rotate : RadicalMenuOption
{
	public CharacterCustomizationMenu characterCustomizationMenu;

	public Animator animator;

	public GameObject selectedMarker;

	public bool rotateRight;

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
		if (rotateRight)
		{
			characterCustomizationMenu.RotateCharacterRight();
		}
		else
		{
			characterCustomizationMenu.RotateCharacterLeft();
		}
		animator.SetTrigger(-1158233568);
	}
}
