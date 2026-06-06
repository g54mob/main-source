using System;
using System.Collections.Generic;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class PlantCategoryItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject buttons;

		[SerializeField]
		private CreativeModePlantButtonsUI creativeModeButtons;

		[SerializeField]
		private ObjectSO objectSo;

		[SerializeField]
		private Image icon;

		[SerializeField]
		private GameObject rowTemplatePrefab;

		[SerializeField]
		private Transform rowContainer;

		private List<CreatePlantButtonUI> plantButtons = new List<CreatePlantButtonUI>();

		private Button button;

		private void Start()
		{
			CreateRowsAndButtons();
			button = base.transform.GetComponent<Button>();
			button.onClick.AddListener(ToggleButtons);
			CollectionManager instance = CollectionManager.Instance;
			instance.OnLoadCollection = (Action)Delegate.Combine(instance.OnLoadCollection, new Action(LoadButtons));
		}

		private void CreateRowsAndButtons()
		{
			if (objectSo == null || rowTemplatePrefab == null || rowContainer == null)
			{
				Debug.LogError("Please assign all references in the inspector.");
				return;
			}
			int count = objectSo.variantsList.Count;
			int num = count / 3;
			int num2 = count % 3;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(rowTemplatePrefab, rowContainer);
				gameObject.name = "Row_" + i;
				for (int j = 0; j < 3; j++)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(j).gameObject;
					plantButtons.Add(gameObject2.GetComponent<CreatePlantButtonUI>());
				}
			}
			if (num2 <= 0)
			{
				return;
			}
			GameObject gameObject3 = UnityEngine.Object.Instantiate(rowTemplatePrefab, rowContainer);
			gameObject3.name = "Row_" + num;
			for (int k = 0; k < 3; k++)
			{
				GameObject gameObject4 = gameObject3.transform.GetChild(k).gameObject;
				if (k < num2)
				{
					plantButtons.Add(gameObject4.GetComponent<CreatePlantButtonUI>());
				}
				else
				{
					gameObject4.SetActive(value: false);
				}
			}
		}

		private void LoadButtons()
		{
			icon.sprite = objectSo.sprite;
			int num = 0;
			foreach (CreatePlantButtonUI plantButton in plantButtons)
			{
				plantButton.CreateButton(objectSo, num);
				num++;
			}
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
			CollectionManager instance = CollectionManager.Instance;
			instance.OnLoadCollection = (Action)Delegate.Remove(instance.OnLoadCollection, new Action(LoadButtons));
		}

		public void HideButtons()
		{
			buttons.SetActive(value: false);
		}

		private void ToggleButtons()
		{
			if (!MovementSystem.Instance.IsMoving())
			{
				if (buttons.activeSelf)
				{
					HideButtons();
					return;
				}
				creativeModeButtons.HideAllButtons();
				buttons.SetActive(value: true);
			}
		}
	}
}
