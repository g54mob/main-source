using UnityEngine.EventSystems;

public class LessonButton : BaseButtonImage
{
	private static bool m_LumberNew;

	private float m_Timer;

	private Quest m_Quest;

	private NewThing m_NewThing;

	protected new void Awake()
	{
		base.Awake();
		m_NewThing = base.transform.Find("NewThing").GetComponent<NewThing>();
		m_NewThing.gameObject.SetActive(false);
	}

	public static void SetLumberNew(bool New)
	{
		m_LumberNew = New;
		TabQuests.Instance.UpdateLumber();
	}

	public void SetQuest(Quest NewQuest)
	{
		m_Quest = NewQuest;
	}

	public void UpdateNew(bool UpdatePaused = false)
	{
		if (m_Quest.m_ID == Quest.ID.AcademyLumber2 && m_LumberNew)
		{
			m_NewThing.gameObject.SetActive(true);
			if (UpdatePaused)
			{
				m_NewThing.UpdateWhilePaused();
			}
		}
		else
		{
			m_NewThing.gameObject.SetActive(false);
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (m_Quest.m_ID == Quest.ID.AcademyLumber2)
		{
			SetLumberNew(false);
			m_NewThing.gameObject.SetActive(false);
		}
		base.OnPointerClick(eventData);
	}

	public override void SetIndicated(bool Indicated)
	{
		base.SetIndicated(Indicated);
		BaseSetIndicated(Indicated);
	}
}
