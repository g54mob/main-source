using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;

public class UnlocksFooter : MonoBehaviour
{
	public TextMeshProUGUI t_unlockName;

	public TextMeshProUGUI t_unlockDescription;

	public UnlockContainer unlockContainer;

	public MyButton buyButton;

	public RequirementPrefab[] reqContainers;

	public RequirementsContainer requirementsContainer;

	public GameObject buyContainer;

	public TextMeshProUGUI t_buyPrice;

	public TextMeshProUGUI t_suggestedBy;

	public UnlocksExtraInformation extraInformation;

	public ButtonNavigationSelectionOnly tabNavigation;

	public static Action<UnlockableBase> A_Purchased;

	private UnlockContainer lastSelected;

	private Vector2 reqContainerPosDefault;

	private Vector2 reqContainerPosSmall;

	private Vector2 reqContainerScaleDefault;

	private Vector2 reqContainerScaleSmall;

	public Window parentWindow;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnTabChanged(int index)
	{
	}

	private void SetEmpty()
	{
	}

	private void OnUnlockSelected(UnlockContainer container)
	{
	}

	private void Refresh(UnlockContainer container)
	{
	}

	private void OnUnlockClicked(UnlockContainer container)
	{
	}

	public void TryBuyUnlockable()
	{
	}
}
