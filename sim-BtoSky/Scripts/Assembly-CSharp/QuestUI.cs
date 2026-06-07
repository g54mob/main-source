using System;
using System.Collections;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.Localization;

public class QuestUI : MonoBehaviour
{
	private LocalizedString newspaperText = new LocalizedString("MyTable", "parttime17");

	private LocalizedString garbageText = new LocalizedString("MyTable", "parttime14");

	private LocalizedString garageText = new LocalizedString("MyTable", "parttime16");

	private LocalizedString mowingText = new LocalizedString("MyTable", "parttime13");

	private LocalizedString cookingDeliveryText = new LocalizedString("MyTable", "cookingDelvieryQuest");

	[SerializeField]
	private Transform uiPos;

	[SerializeField]
	private GameObject questWindowPrefab;

	[SerializeField]
	private GameObject newspaperWindowPrefab;

	[SerializeField]
	private GameObject cleanupWindowPrefab;

	[SerializeField]
	private GameObject partTimeRewardQuestPrefab;

	[SerializeField]
	private GameObject cookingQuestPrefab;

	[SerializeField]
	private Food[] cookingDeliveryFoodList;

	private QuestWindow currentMainQuest;

	private QuestWindow currentPartTime;

	private bool isMotorCrafted;

	private bool isWingAttached;

	public static event Action OnWingQuestCompleted;

	public static event Action OnMotorQuestCompleted;

	public static event Action<int, Food> OnCookingDeliveryStart;

	private void Start()
	{
		QuestManager.S.OnQuestStarted += Qm_OnQuestStarted;
		QuestManager.S.OnQuestCompleted += Qm_OnQuestCompleted;
		QuestManager.S.OnNewsPaperDeliveryStarted += Qm_OnNewsPaperDeliveryStarted;
		QuestManager.S.OnNewsPaperDeliveryCompleted += Qm_OnNewsPaperDeliveryCompleted;
		QuestManager.S.OnCleanUpStarted += Qm_OnCleanUpStarted;
		QuestManager.S.OnCleanUpCompleted += Qm_OnCleanUpCompleted;
		QuestManager.S.OnMowingStarted += Qm_OnMowingStarted;
		QuestManager.S.OnMowingCompleted += Q_OnMowingCompleted;
		QuestManager.S.OnGarageCleaningStart += Qm_OnGarageCleaningStart;
		QuestManager.S.OnGarageCleaningCompleted += Qm_OnGarageCleaningCompleted;
		QuestManager.S.OnQuestRewarded += Qm_OnQuestRewarded;
		QuestWindow.OnQuestWindowCreated += QuestWindow_OnQuestWindowCreated;
		GameManager.S.OnMotorCraftingTableInteracted += S_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorCraftingDone += S_OnMotorCraftingDone;
		GameManager.S.OnCookingTable += S_OnCookingTable;
		GameManager.S.OnCookingDone += S_OnCookingDone;
		GameManager.S.OnMotorCraftingCompleted += S_OnMotorCraftingCompleted;
		GameManager.S.OnWingInstalled += S_OnWingInstalled;
		GameManager.S.OnCraftingDone += S_OnCraftingDone;
		StartCoroutine(DelayedStartQuest());
	}

	private void S_OnCraftingDone(object sender, EventArgs e)
	{
		if (isWingAttached)
		{
			QuestUI.OnWingQuestCompleted?.Invoke();
			isWingAttached = false;
		}
	}

	private void S_OnWingInstalled(object sender, EventArgs e)
	{
		isWingAttached = true;
	}

	private void S_OnMotorCraftingCompleted(object sender, EventArgs e)
	{
		isMotorCrafted = true;
	}

	private void S_OnCookingDone(object sender, EventArgs e)
	{
		base.gameObject.SetActive(value: true);
	}

	private void S_OnCookingTable(object sender, EventArgs e)
	{
		base.gameObject.SetActive(value: false);
	}

	private void S_OnMotorCraftingDone(object sender, EventArgs e)
	{
		base.gameObject.SetActive(value: true);
		if (isMotorCrafted)
		{
			isMotorCrafted = false;
			QuestUI.OnMotorQuestCompleted?.Invoke();
		}
	}

	private void S_OnMotorCraftingTableInteracted(object sender, EventArgs e)
	{
		base.gameObject.SetActive(value: false);
	}

	private void QuestWindow_OnQuestWindowCreated(QuestWindow obj)
	{
		if (currentPartTime == null)
		{
			currentPartTime = obj;
		}
	}

	private IEnumerator DelayedStartQuest()
	{
		yield return null;
		QuestData current = QuestManager.S.GetCurrentQuest();
		QuestData currentPart = QuestManager.S.GetCurrnetPartTime();
		if (current != null && !current.isCompleted)
		{
			yield return null;
			Qm_OnQuestStarted(current);
		}
		if (currentPart != null && currentPart.isCompleted)
		{
			if (currentPartTime != null)
			{
				UnityEngine.Object.Destroy(currentPartTime.gameObject);
				currentPartTime = null;
			}
			if (ES3AutoSaveMgr.Current != null)
			{
				QuestManager.S.PartTimeRewardQuestStart();
			}
		}
	}

	private void Qm_OnQuestRewarded()
	{
		if (currentPartTime != null)
		{
			currentPartTime.HideQuest();
			currentPartTime = null;
		}
	}

	private void Qm_OnGarageCleaningCompleted()
	{
		if (currentPartTime != null)
		{
			currentPartTime.HideQuest();
			currentPartTime = null;
		}
	}

	private void Qm_OnGarageCleaningStart()
	{
		QuestWindow component = UnityEngine.Object.Instantiate(newspaperWindowPrefab, uiPos).GetComponent<QuestWindow>();
		component.Description = garageText.GetLocalizedString();
		currentPartTime = component;
	}

	private void Q_OnMowingCompleted()
	{
		if (currentPartTime != null)
		{
			currentPartTime.HideQuest();
			currentPartTime = null;
		}
	}

	private void Qm_OnMowingStarted()
	{
		QuestWindow component = UnityEngine.Object.Instantiate(newspaperWindowPrefab, uiPos).GetComponent<QuestWindow>();
		component.Description = mowingText.GetLocalizedString();
		currentPartTime = component;
	}

	private void Qm_OnCleanUpCompleted()
	{
		if (currentPartTime != null)
		{
			currentPartTime.HideQuest();
			currentPartTime = null;
		}
	}

	private void Qm_OnCleanUpStarted()
	{
		QuestWindow component = UnityEngine.Object.Instantiate(newspaperWindowPrefab, uiPos).GetComponent<QuestWindow>();
		component.Description = garbageText.GetLocalizedString();
		currentPartTime = component;
	}

	private void Qm_OnNewsPaperDeliveryCompleted()
	{
		if (currentPartTime != null)
		{
			currentPartTime.HideQuest();
			currentPartTime = null;
		}
	}

	private void Qm_OnNewsPaperDeliveryStarted()
	{
		QuestWindow component = UnityEngine.Object.Instantiate(newspaperWindowPrefab, uiPos).GetComponent<QuestWindow>();
		component.Description = newspaperText.GetLocalizedString();
		currentPartTime = component;
	}

	private void OnDestroy()
	{
		QuestManager.S.OnQuestStarted -= Qm_OnQuestStarted;
		QuestManager.S.OnQuestCompleted -= Qm_OnQuestCompleted;
		QuestManager.S.OnNewsPaperDeliveryStarted -= Qm_OnNewsPaperDeliveryStarted;
		QuestManager.S.OnNewsPaperDeliveryCompleted -= Qm_OnNewsPaperDeliveryCompleted;
		QuestManager.S.OnCleanUpStarted -= Qm_OnCleanUpStarted;
		QuestManager.S.OnCleanUpCompleted -= Qm_OnCleanUpCompleted;
		QuestManager.S.OnMowingStarted -= Qm_OnMowingStarted;
		QuestManager.S.OnGarageCleaningStart -= Qm_OnGarageCleaningStart;
		QuestManager.S.OnGarageCleaningCompleted -= Qm_OnGarageCleaningCompleted;
		QuestWindow.OnQuestWindowCreated -= QuestWindow_OnQuestWindowCreated;
		GameManager.S.OnMotorCraftingTableInteracted -= S_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorCraftingDone -= S_OnMotorCraftingDone;
		GameManager.S.OnCookingTable -= S_OnCookingTable;
		GameManager.S.OnCookingDone -= S_OnCookingDone;
		GameManager.S.OnMotorCraftingCompleted -= S_OnMotorCraftingCompleted;
		GameManager.S.OnWingInstalled -= S_OnWingInstalled;
	}

	private void Qm_OnQuestCompleted(QuestData obj)
	{
		if (currentMainQuest != null)
		{
			currentMainQuest.HideQuest();
			currentMainQuest = null;
		}
	}

	private void Qm_OnQuestStarted(QuestData obj)
	{
		if (obj.questType == QuestType.MainQuest)
		{
			GameObject obj2 = UnityEngine.Object.Instantiate(questWindowPrefab, uiPos);
			obj2.transform.SetSiblingIndex(0);
			QuestWindow component = obj2.GetComponent<QuestWindow>();
			component.Description = obj.descriptionTemp.GetLocalizedString();
			currentMainQuest = component;
		}
		else if (obj.questType == QuestType.Reward)
		{
			QuestWindow component2 = UnityEngine.Object.Instantiate(partTimeRewardQuestPrefab, uiPos).GetComponent<QuestWindow>();
			component2.Description = obj.descriptionTemp.GetLocalizedString();
			currentPartTime = component2;
		}
		else if (obj.questType == QuestType.Cooking)
		{
			QuestWindow component3 = UnityEngine.Object.Instantiate(cookingQuestPrefab, uiPos).GetComponent<QuestWindow>();
			int num = UnityEngine.Random.Range(0, cookingDeliveryFoodList.Length);
			Food food = cookingDeliveryFoodList[num];
			cookingDeliveryText.Arguments = new object[2]
			{
				obj.pay,
				food.itemNameTemp.GetLocalizedString()
			};
			component3.Description = cookingDeliveryText.GetLocalizedString();
			QuestUI.OnCookingDeliveryStart?.Invoke(obj.pay, food);
			currentPartTime = component3;
		}
	}

	private void Update()
	{
	}
}
