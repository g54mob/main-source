using System.Collections.Generic;
using UnityEngine;

public class Objects : AutopediaPage
{
	public static Objects Instance;

	private static ObjectType m_CurrentType;

	public ObjectSelect m_Select;

	private ObjectRecipe m_Recipe;

	private List<ObjectType> m_NavigationStack;

	private LockedByResearch m_LockedByResearch;

	private LockedByCertificate m_LockedByCertificate;

	private LockedByTickets m_LockedByTickets;

	private GameObject m_Tickets;

	public static void Init()
	{
		m_CurrentType = ObjectType.ToolAxeStone;
	}

	private void Awake()
	{
		Instance = this;
		m_NavigationStack = new List<ObjectType>();
	}

	private void Start()
	{
		m_Select = base.transform.Find("ObjectSelect").GetComponent<ObjectSelect>();
		m_Select.Init(false, true);
		m_Recipe = base.transform.Find("ObjectRecipe").GetComponent<ObjectRecipe>();
		m_LockedByResearch = base.transform.Find("LockedByResearch").GetComponent<LockedByResearch>();
		m_LockedByResearch.SetActive(false);
		m_LockedByCertificate = base.transform.Find("LockedByCertificate").GetComponent<LockedByCertificate>();
		m_LockedByCertificate.SetActive(false);
		m_LockedByTickets = base.transform.Find("LockedByTickets").GetComponent<LockedByTickets>();
		m_LockedByTickets.SetActive(false);
		m_Tickets = base.transform.Find("Tickets").gameObject;
		SetObjectType(m_CurrentType);
		UpdateTickets();
		UpdateCategory();
	}

	public void UpdateCategory()
	{
		bool flag = m_Select.m_CurrentCategory == ObjectCategory.Prizes;
		m_Tickets.SetActive(flag);
		if (!QuestManager.Instance.GetIsObjectLockedAny(m_CurrentType) || !flag)
		{
			m_LockedByTickets.SetActive(false);
			return;
		}
		m_LockedByTickets.SetActive(true);
		m_LockedByTickets.Init(m_CurrentType);
	}

	public void UpdateTickets()
	{
		int tickets = OffworldMissionsManager.Instance.m_Tickets;
		BaseText component = m_Tickets.transform.Find("Text").GetComponent<BaseText>();
		string text = TextManager.Instance.Get("ObjectsTickets", tickets.ToString());
		component.SetText(text);
		m_Select.UpdateLockedObjects();
		m_Recipe.UpdateLockedObjects();
	}

	public void SetObjectType(ObjectType NewType, bool Flash = false, bool ScrollTo = false)
	{
		m_CurrentType = NewType;
		m_Recipe.SetObjectType(NewType);
		m_Select.SetObject(NewType, Flash, ScrollTo);
		bool isObjectLockedAny = QuestManager.Instance.GetIsObjectLockedAny(NewType);
		Quest.ID questFromUnlockedObjectType = QuestData.Instance.m_ResearchData.GetQuestFromUnlockedObjectType(NewType);
		if (!isObjectLockedAny || questFromUnlockedObjectType == Quest.ID.Total)
		{
			m_LockedByResearch.SetActive(false);
		}
		else
		{
			m_LockedByResearch.SetActive(true);
			m_LockedByResearch.Init(questFromUnlockedObjectType);
		}
		questFromUnlockedObjectType = QuestData.Instance.m_AcademyData.GetQuestFromUnlockedObjectType(NewType);
		if (!isObjectLockedAny || questFromUnlockedObjectType == Quest.ID.Total)
		{
			m_LockedByCertificate.SetActive(false);
		}
		else
		{
			m_LockedByCertificate.SetActive(true);
			m_LockedByCertificate.Init(questFromUnlockedObjectType);
		}
		UpdateCategory();
	}

	public bool IsNavigationBackAvailable()
	{
		return m_NavigationStack.Count != 0;
	}

	public void NavigateDestroy()
	{
		m_NavigationStack.Clear();
		m_Recipe.SetObjectType(ObjectTypeList.m_Total);
		m_LockedByResearch.SetActive(false);
		m_LockedByCertificate.SetActive(false);
	}

	public void NavigateBack()
	{
		ObjectType newType = m_NavigationStack[m_NavigationStack.Count - 1];
		m_NavigationStack.RemoveAt(m_NavigationStack.Count - 1);
		SetObjectType(newType, false, true);
	}

	public void NavigateForward(ObjectType NewType)
	{
		m_NavigationStack.Add(NewType);
	}
}
