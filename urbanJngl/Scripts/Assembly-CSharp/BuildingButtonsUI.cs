using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonsUI : MonoBehaviour
{
	[SerializeField]
	private Transform plantButtonTemplate;

	[SerializeField]
	private ChooseNextPlantWindowUI chooseNextPlantWindowUI;

	[SerializeField]
	private NewPlantButtonUI newPlantButtonUI;

	[SerializeField]
	private ScrollRect scrollRect;

	private List<PlantButtonUI> plantButtonUIList = new List<PlantButtonUI>();

	private int currentSelectedButtonIndex;

	private void Start()
	{
		ProgressManager.Instance.OnPlantCreated += ProgressManagerOnPlantCreated;
		ProgressManager instance = ProgressManager.Instance;
		instance.OnLoadIsFinished = (Action)Delegate.Combine(instance.OnLoadIsFinished, new Action(ProgressManager_OnLoadIsFinished));
		ProgressManager instance2 = ProgressManager.Instance;
		instance2.SpawnButtonOnPanel = (Action<ObjectSO, string>)Delegate.Combine(instance2.SpawnButtonOnPanel, new Action<ObjectSO, string>(SpawnButton));
		chooseNextPlantWindowUI.OnNewPlantChosen += ChooseNextPlantWindowUI_OnNewPlantChosen;
		InputManager instance3 = InputManager.Instance;
		instance3.OnPlantScrollRight = (Action)Delegate.Combine(instance3.OnPlantScrollRight, new Action(ScrollRight));
		InputManager instance4 = InputManager.Instance;
		instance4.OnPlantScrollLeft = (Action)Delegate.Combine(instance4.OnPlantScrollLeft, new Action(ScrollLeft));
		InputManager instance5 = InputManager.Instance;
		instance5.OnSelectPlant = (Action)Delegate.Combine(instance5.OnSelectPlant, new Action(SelectCurrentButton));
		if (plantButtonUIList.Count > 0)
		{
			SelectButton(currentSelectedButtonIndex);
		}
	}

	private void ScrollLeft()
	{
		NavigateButtons(-1);
	}

	private void ScrollRight()
	{
		NavigateButtons(1);
	}

	private void NavigateButtons(int direction)
	{
		if (plantButtonUIList.Count != 0)
		{
			DeselectButton(currentSelectedButtonIndex);
			currentSelectedButtonIndex += direction;
			if (currentSelectedButtonIndex >= plantButtonUIList.Count)
			{
				currentSelectedButtonIndex = 0;
			}
			else if (currentSelectedButtonIndex < 0)
			{
				currentSelectedButtonIndex = plantButtonUIList.Count - 1;
			}
			SelectButton(currentSelectedButtonIndex);
			ScrollToSelectedButton();
		}
	}

	private void ScrollToSelectedButton()
	{
		RectTransform rectTransform = plantButtonUIList[currentSelectedButtonIndex].transform as RectTransform;
		RectTransform content = scrollRect.content;
		Vector3[] array = new Vector3[4];
		rectTransform.GetWorldCorners(array);
		Vector3 vector = content.InverseTransformPoint(array[0]);
		Vector3[] array2 = new Vector3[4];
		scrollRect.viewport.GetWorldCorners(array2);
		Vector3 vector2 = content.InverseTransformPoint(array2[0]);
		float x = vector.x;
		float num = vector.x + rectTransform.rect.width;
		float x2 = vector2.x;
		float num2 = vector2.x + scrollRect.viewport.rect.width;
		if (x < x2)
		{
			float x3 = x2 - x;
			content.anchoredPosition += new Vector2(x3, 0f);
		}
		else if (num > num2)
		{
			float x4 = num - num2;
			content.anchoredPosition -= new Vector2(x4, 0f);
		}
	}

	private void SelectButton(int index)
	{
		plantButtonUIList[index].Select();
	}

	private void DeselectButton(int index)
	{
		plantButtonUIList[index].Deselect();
	}

	private void SelectCurrentButton()
	{
		if (currentSelectedButtonIndex >= 0 && currentSelectedButtonIndex < plantButtonUIList.Count)
		{
			plantButtonUIList[currentSelectedButtonIndex].OnClick();
		}
	}

	private void ProgressManager_OnLoadIsFinished()
	{
		newPlantButtonUI.CheckVisibility();
		foreach (string item in ProgressManager.Instance.GetPlantsForLoad())
		{
			ObjectSO plantSOByGUID = CollectionManager.Instance.GetPlantSOByGUID(item);
			SpawnButton(plantSOByGUID, item);
		}
		if (plantButtonUIList.Count > 0)
		{
			SelectButton(currentSelectedButtonIndex);
		}
	}

	private void ChooseNextPlantWindowUI_OnNewPlantChosen(object sender, ChooseNextPlantWindowUI.OnNewPlantChosenEventArgs e)
	{
		SpawnButton(e.objectSo, e.GUID);
	}

	private void ProgressManagerOnPlantCreated(object sender, ProgressManager.OnPlantCreatedEventArgs e)
	{
		DeleteButtonFromPanel(e.GUID);
	}

	private void OnDestroy()
	{
		ProgressManager.Instance.OnPlantCreated -= ProgressManagerOnPlantCreated;
		ProgressManager instance = ProgressManager.Instance;
		instance.OnLoadIsFinished = (Action)Delegate.Remove(instance.OnLoadIsFinished, new Action(ProgressManager_OnLoadIsFinished));
		chooseNextPlantWindowUI.OnNewPlantChosen -= ChooseNextPlantWindowUI_OnNewPlantChosen;
		ProgressManager instance2 = ProgressManager.Instance;
		instance2.SpawnButtonOnPanel = (Action<ObjectSO, string>)Delegate.Remove(instance2.SpawnButtonOnPanel, new Action<ObjectSO, string>(SpawnButton));
		InputManager instance3 = InputManager.Instance;
		instance3.OnPlantScrollRight = (Action)Delegate.Remove(instance3.OnPlantScrollRight, new Action(ScrollRight));
		InputManager instance4 = InputManager.Instance;
		instance4.OnPlantScrollLeft = (Action)Delegate.Remove(instance4.OnPlantScrollLeft, new Action(ScrollLeft));
		InputManager instance5 = InputManager.Instance;
		instance5.OnSelectPlant = (Action)Delegate.Remove(instance5.OnSelectPlant, new Action(SelectCurrentButton));
	}

	public void SpawnButton(ObjectSO objectSO, string GUID)
	{
		PlantButtonUI item = PlantButtonUI.Create(plantButtonTemplate, objectSO, GUID);
		plantButtonUIList.Add(item);
		ProgressManager.Instance.GetPlantsOnPanel().Add(GUID);
		if (plantButtonUIList.Count == 1)
		{
			SelectButton(0);
		}
	}

	private void DeleteButtonFromPanel(string guid)
	{
		PlantButtonUI plantButtonUI = plantButtonUIList.Find((PlantButtonUI plantButtonUI2) => plantButtonUI2.GetGUID() == guid);
		plantButtonUIList.Remove(plantButtonUI);
		plantButtonUI.DeleteButton();
		if (plantButtonUIList.Count > 0 && currentSelectedButtonIndex >= plantButtonUIList.Count)
		{
			currentSelectedButtonIndex = plantButtonUIList.Count - 1;
			SelectButton(currentSelectedButtonIndex);
		}
	}
}
