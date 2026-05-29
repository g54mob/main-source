using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class UnlocksUi : MonoBehaviour
{
	private List<UnlockContainer> unlockContainers;

	public GameObject unlockContainerPrefab;

	public Transform contentParent;

	public ButtonNavigationSelectionOnly tabButtons;

	public TabGridNavigation tabGridNavigation;

	public GameObject exclChar;

	public GameObject exclWeapon;

	public GameObject exclTome;

	public GameObject exclItem;

	public GameObject exclHats;

	public GameObject[] exclamationMarks;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	public void FocusCharacterPurchase(CharacterData character)
	{
	}

	private void UpdateExclamationMarks()
	{
	}

	private void OnTabSelected(int index)
	{
	}

	private void Refresh(List<UnlockableBase> unlockables)
	{
	}
}
