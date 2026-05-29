using SoulGames.EasyGridBuilderPro;
using TMPro;
using UnityEngine;

namespace SoulGames.Examples
{
	public class ExampleInventoryBuildCondition : MonoBehaviour
	{
		[Header("Inventory Resources Amount")]
		[Space]
		[SerializeField]
		private int currentFoodInInventory = 10;

		[SerializeField]
		private int currentMetalInInventory = 10;

		[SerializeField]
		private int currentWoodInInventory = 10;

		[Header("Inventory Add Resources")]
		[Space]
		[SerializeField]
		private int foodAddAmount = 5;

		[SerializeField]
		private int metalAddAmount = 5;

		[SerializeField]
		private int woodAddAmount = 5;

		[Header("Inventory UI")]
		[Space]
		[SerializeField]
		private AudioClip UIClickSound;

		[SerializeField]
		private TextMeshProUGUI foodAmountText;

		[SerializeField]
		private TextMeshProUGUI metalAmountText;

		[SerializeField]
		private TextMeshProUGUI woodAmountText;

		[Header("Debug")]
		[Space]
		[SerializeField]
		private bool showConsoleText = true;

		private void Update()
		{
			UpdateUIText();
		}

		private void UpdateUIText()
		{
			if ((bool)foodAmountText)
			{
				foodAmountText.text = currentFoodInInventory.ToString();
			}
			if ((bool)metalAmountText)
			{
				metalAmountText.text = currentMetalInInventory.ToString();
			}
			if ((bool)woodAmountText)
			{
				woodAmountText.text = currentWoodInInventory.ToString();
			}
		}

		public void AddFood()
		{
			currentFoodInInventory += foodAddAmount;
			if ((bool)UIClickSound)
			{
				AudioSource.PlayClipAtPoint(UIClickSound, base.transform.position);
			}
			if (showConsoleText)
			{
				Debug.Log("<color=green>Food added :</color> " + foodAddAmount + " <color=green>Current Food amount in inventory :</color>" + currentFoodInInventory);
			}
		}

		public void AddMetal()
		{
			currentMetalInInventory += metalAddAmount;
			if ((bool)UIClickSound)
			{
				AudioSource.PlayClipAtPoint(UIClickSound, base.transform.position);
			}
			if (showConsoleText)
			{
				Debug.Log("<color=green>Metal added :</color> " + metalAddAmount + " <color=green>Current Metal amount in inventory :</color>" + currentMetalInInventory);
			}
		}

		public void AddWood()
		{
			currentWoodInInventory += woodAddAmount;
			if ((bool)UIClickSound)
			{
				AudioSource.PlayClipAtPoint(UIClickSound, base.transform.position);
			}
			if (showConsoleText)
			{
				Debug.Log("<color=green>Wood added :</color> " + woodAddAmount + " <color=green>Current Wood amount in inventory :</color>" + currentWoodInInventory);
			}
		}

		private void OnEnable()
		{
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableGridObject += CheckBuildConditionBuildableGridObject;
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableGridObject += CompleteBuildConditionBuildableGridObject;
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableFreeObject += CheckBuildConditionBuildableFreeObject;
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableFreeObject += CompleteBuildConditionBuildableFreeObject;
		}

		private void OnDisable()
		{
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableGridObject -= CheckBuildConditionBuildableGridObject;
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableGridObject -= CompleteBuildConditionBuildableGridObject;
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableFreeObject -= CheckBuildConditionBuildableFreeObject;
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableFreeObject -= CompleteBuildConditionBuildableFreeObject;
		}

		private void CheckBuildConditionBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO2 in MultiGridBuildConditionManager.BuildableGridObjectTypeSOList)
			{
				if (buildableGridObjectTypeSO2 == buildableGridObjectTypeSO && buildableGridObjectTypeSO2.enableBuildCondition)
				{
					if (buildableGridObjectTypeSO.buildConditionSO.foodAmount <= currentFoodInInventory && buildableGridObjectTypeSO.buildConditionSO.metalAmount <= currentMetalInInventory && buildableGridObjectTypeSO.buildConditionSO.woodAmount <= currentWoodInInventory)
					{
						MultiGridBuildConditionManager.BuidConditionResponseBuildableGridObject = true;
					}
					else
					{
						MultiGridBuildConditionManager.BuidConditionResponseBuildableGridObject = false;
					}
					return;
				}
			}
			MultiGridBuildConditionManager.BuidConditionResponseBuildableGridObject = false;
		}

		private void CompleteBuildConditionBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO2 in MultiGridBuildConditionManager.BuildableGridObjectTypeSOList)
			{
				if (buildableGridObjectTypeSO2 == buildableGridObjectTypeSO && buildableGridObjectTypeSO2.enableBuildCondition)
				{
					if (buildableGridObjectTypeSO.buildConditionSO.consumeFoodOnBuild)
					{
						currentFoodInInventory -= buildableGridObjectTypeSO.buildConditionSO.foodAmount;
					}
					if (buildableGridObjectTypeSO.buildConditionSO.consumeMetalOnBuild)
					{
						currentMetalInInventory -= buildableGridObjectTypeSO.buildConditionSO.metalAmount;
					}
					if (buildableGridObjectTypeSO.buildConditionSO.consumeWoodOnBuild)
					{
						currentWoodInInventory -= buildableGridObjectTypeSO.buildConditionSO.woodAmount;
					}
				}
			}
		}

		private void CheckBuildConditionBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO2 in MultiGridBuildConditionManager.BuildableFreeObjectTypeSOList)
			{
				if (buildableFreeObjectTypeSO2 == buildableFreeObjectTypeSO && buildableFreeObjectTypeSO2.enableBuildCondition)
				{
					if (buildableFreeObjectTypeSO.buildConditionSO.foodAmount <= currentFoodInInventory && buildableFreeObjectTypeSO.buildConditionSO.metalAmount <= currentMetalInInventory && buildableFreeObjectTypeSO.buildConditionSO.woodAmount <= currentWoodInInventory)
					{
						MultiGridBuildConditionManager.BuidConditionResponseBuildableFreeObject = true;
					}
					else
					{
						MultiGridBuildConditionManager.BuidConditionResponseBuildableFreeObject = false;
					}
					return;
				}
			}
			MultiGridBuildConditionManager.BuidConditionResponseBuildableFreeObject = false;
		}

		private void CompleteBuildConditionBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO2 in MultiGridBuildConditionManager.BuildableFreeObjectTypeSOList)
			{
				if (buildableFreeObjectTypeSO2 == buildableFreeObjectTypeSO && buildableFreeObjectTypeSO2.enableBuildCondition)
				{
					if (buildableFreeObjectTypeSO.buildConditionSO.consumeFoodOnBuild)
					{
						currentFoodInInventory -= buildableFreeObjectTypeSO.buildConditionSO.foodAmount;
					}
					if (buildableFreeObjectTypeSO.buildConditionSO.consumeMetalOnBuild)
					{
						currentMetalInInventory -= buildableFreeObjectTypeSO.buildConditionSO.metalAmount;
					}
					if (buildableFreeObjectTypeSO.buildConditionSO.consumeWoodOnBuild)
					{
						currentWoodInInventory -= buildableFreeObjectTypeSO.buildConditionSO.woodAmount;
					}
				}
			}
		}
	}
}
