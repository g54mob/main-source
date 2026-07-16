using System.Collections.Generic;
using MLCN_Localization;
using TMPro;
using UnityEngine;

public class PopupTaskCheckListComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelTitle;

	[SerializeField]
	private GameObject checklistOptionPrefab;

	[SerializeField]
	private RectTransform content;

	private List<TutorialChecklistOptionSlot> slots = new List<TutorialChecklistOptionSlot>();

	[SerializeField]
	private UIContentAnimator animator;

	private bool isVisible;

	private void Start()
	{
		animator.BeginWithTargetState();
		CleanUp();
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public void InitCheckList(string titleKey, List<TutorialChecklistOption> options)
	{
		CleanUp();
		labelTitle.text = LocalizationManager.GetLocalizedString(titleKey, LocalizationDataTable.Tables.UI);
		for (int i = 0; i < options.Count; i++)
		{
			GameObject slotObject = Object.Instantiate(checklistOptionPrefab, content);
			AddSlot(slotObject, options[i]);
		}
		animator.OnReverse();
		isVisible = true;
	}

	public void AddSlot(GameObject slotObject, TutorialChecklistOption option)
	{
		TutorialChecklistOptionSlot component = slotObject.GetComponent<TutorialChecklistOptionSlot>();
		component.Init(option.checkListTitleKey, option.optionNameKey, option.check);
		slots.Add(component);
	}

	public void UpdateSlot(string slotKey)
	{
		TutorialChecklistOptionSlot tutorialChecklistOptionSlot = slots.Find((TutorialChecklistOptionSlot x) => x.GetKey() == slotKey);
		if (!(tutorialChecklistOptionSlot == null))
		{
			tutorialChecklistOptionSlot.Check();
		}
	}

	public void Hide()
	{
		CleanUp();
		animator.OnPlay();
		isVisible = false;
	}

	private void CleanUp()
	{
		if (labelTitle != null)
		{
			labelTitle.text = "";
		}
		foreach (TutorialChecklistOptionSlot slot in slots)
		{
			Object.Destroy(slot.gameObject);
		}
		slots.Clear();
	}
}
